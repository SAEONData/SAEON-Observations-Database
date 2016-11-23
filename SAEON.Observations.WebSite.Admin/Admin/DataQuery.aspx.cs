﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SAEON.Observations.Data;
using SubSonic;
using System.Xml;
using System.Xml.Xsl;
using Newtonsoft.Json;
using System.Collections;
using System.Dynamic;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;
using Serilog;

public partial class _DataQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            FromFilter.SelectedDate = DateTime.Now.AddYears(-100);
            ToFilter.SelectedDate = DateTime.Now;
            ResourceManager1.RegisterIcon(Icon.ResultsetNext);
            ResourceManager1.RegisterIcon((Icon)new ModuleX("A5C81FF7-69D6-4344-8548-E3EF7F08C4E7").Icon);
            ResourceManager1.RegisterIcon((Icon)new ModuleX("0585e63d-0f9f-4dda-98ec-7de9397dc614").Icon);
            ResourceManager1.RegisterIcon((Icon)new ModuleX("2610866B-8CBF-44E1-9A38-6511B31A8350").Icon);
            ResourceManager1.RegisterIcon((Icon)new ModuleX("9992ba10-cb0c-4a22-841c-1d695e8293d5").Icon);
            BuildTree();
        }
    }

    protected void NodeLoad(object sender, NodeLoadEventArgs e)
    {
        if (e.NodeID.StartsWith("Organisations"))
        {
            var col = new Select()
                .From(Organisation.Schema)
                .InnerJoin(OrganisationSite.Schema)
                .Distinct()
                .OrderAsc(Organisation.Columns.Name)
                .ExecuteAsCollection<OrganisationCollection>();
            foreach (var item in col)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode("Organisation_" + item.Id.ToString(), item.Name, Icon.ResultsetNext);
                e.Nodes.Add(node);
                var q = new Query(OrganisationSite.Schema).AddWhere(OrganisationSite.Columns.OrganisationID, item.Id).GetCount(OrganisationSite.Columns.SiteID);
                if (q == 0)
                    node.Leaf = true;
                else
                {
                    AsyncTreeNode root = new AsyncTreeNode("Sites_" + item.Id.ToString(), "Sites");
                    root.Icon = (Icon)new ModuleX("A5C81FF7-69D6-4344-8548-E3EF7F08C4E7").Icon;
                    node.Nodes.Add(root);
                }
            }
        }
        else if (e.NodeID.StartsWith("Sites_"))
        {
            var organisation = new Organisation(e.NodeID.Split('_')[1]);
            var col = new Select()
                .From(SAEON.Observations.Data.Site.Schema)
                .InnerJoin(OrganisationSite.Schema)
                .Where(OrganisationSite.Columns.OrganisationID)
                .IsEqualTo(organisation.Id)
                .OrderAsc(SAEON.Observations.Data.Site.Columns.Name)
                .Distinct()
                .ExecuteAsCollection<SiteCollection>();
            foreach (var item in col)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode("Site_" + item.Id.ToString(), item.Name, Icon.ResultsetNext);
                e.Nodes.Add(node);
                var q = new Query(Station.Schema).AddWhere(Station.Columns.SiteID, item.Id).GetCount(Station.Columns.Id);
                if (q == 0)
                    node.Leaf = true;
                else
                {
                    AsyncTreeNode root = new AsyncTreeNode("Stations_" + item.Id.ToString(), "Stations");
                    root.Icon = (Icon)new ModuleX("0585e63d-0f9f-4dda-98ec-7de9397dc614").Icon;
                    node.Nodes.Add(root);
                }
            }
        }
        else if (e.NodeID.StartsWith("Stations_"))
        {
            var site = new SAEON.Observations.Data.Site(e.NodeID.Split('_')[1]);
            var col = new Select()
                .From(Station.Schema)
                .InnerJoin(SAEON.Observations.Data.Site.Schema)
                .Where(Station.Columns.SiteID)
                .IsEqualTo(site.Id)
                .OrderAsc(Station.Columns.Name)
                .Distinct()
                .ExecuteAsCollection<StationCollection>();
            foreach (var item in col)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode("Station_" + item.Id.ToString(), item.Name, Icon.ResultsetNext);
                node.Checked = ThreeStateBool.False;
                e.Nodes.Add(node);
                var q = new Query(StationInstrument.Schema).AddWhere(StationInstrument.Columns.StationID, item.Id).GetCount(StationInstrument.Columns.InstrumentID);
                if (q == 0)
                    node.Leaf = true;
                else
                {
                    AsyncTreeNode root = new AsyncTreeNode("Instruments_" + item.Id.ToString(), "Instruments");
                    root.Icon = (Icon)new ModuleX("2610866B-8CBF-44E1-9A38-6511B31A8350").Icon;
                    node.Nodes.Add(root);
                }
            }

        }
        else if (e.NodeID.StartsWith("Instruments_"))
        {
            var station = new Station(e.NodeID.Split('_')[1]);
            var col = new Select()
                .From(Instrument.Schema)
                .InnerJoin(StationInstrument.Schema)
                .Where(StationInstrument.Columns.StationID)
                .IsEqualTo(station.Id)
                .OrderAsc(Instrument.Columns.Name)
                .Distinct()
                .ExecuteAsCollection<InstrumentCollection>();
            foreach (var item in col)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode("Instrument_" + item.Id.ToString(), item.Name, Icon.ResultsetNext);
                node.Checked = ThreeStateBool.False;
                e.Nodes.Add(node);
                var q = new Query(InstrumentSensor.Schema).AddWhere(InstrumentSensor.Columns.InstrumentID, item.Id).GetCount(InstrumentSensor.Columns.SensorID);
                if (q == 0)
                    node.Leaf = true;
                else
                {
                    AsyncTreeNode root = new AsyncTreeNode("Sensors_" + item.Id.ToString(), "Sensors");
                    root.Icon = (Icon)new ModuleX("9992ba10-cb0c-4a22-841c-1d695e8293d5").Icon;
                    node.Nodes.Add(root);
                }
            }

        }
        else if (e.NodeID.StartsWith("Sensors_"))
        {
            var instrument = new Instrument(e.NodeID.Split('_')[1]);
            var col = new Select()
                .From(Sensor.Schema)
                .InnerJoin(InstrumentSensor.Schema)
                .Where(InstrumentSensor.Columns.InstrumentID)
                .IsEqualTo(instrument.Id)
                .OrderAsc(Instrument.Columns.Name)
                .Distinct()
                .ExecuteAsCollection<SensorCollection>();
            foreach (var item in col)
            {
                AsyncTreeNode node = new AsyncTreeNode("Sensor_" + item.Id.ToString(), item.Name);
                node.Icon = Icon.ResultsetNext;
                node.Checked = ThreeStateBool.False;
                e.Nodes.Add(node);
                var q = new Query(PhenomenonOffering.Schema).AddWhere(PhenomenonOffering.Columns.PhenomenonID, item.PhenomenonID).GetCount(PhenomenonOffering.Columns.OfferingID);
                if (q == 0)
                    node.Leaf = true;
                else
                {
                    //AsyncTreeNode root = new AsyncTreeNode("Phenomena_" + item.PhenomenonID.ToString(), "Phenomena");
                    //root.Icon = Icon.ResultsetNext;
                    //node.Nodes.Add(root);
                }
            }
        }
        else if (e.NodeID.StartsWith("Sensor_"))
        {
            var sensor = new Sensor(e.NodeID.Split('_')[1]);
            AsyncTreeNode root = new AsyncTreeNode("Phenomenon_" + sensor.PhenomenonID.ToString(), sensor.Phenomenon.Name);
            root.Icon = Icon.ResultsetNext;
            e.Nodes.Add(root);
        }
        else if (e.NodeID.StartsWith("Phenomenon_"))
        {
            var phenomenon = new Phenomenon(e.NodeID.Split('_')[1]);
            var col = new Select()
                .From(PhenomenonOffering.Schema)
                .InnerJoin(Offering.Schema)
                .Where(PhenomenonOffering.Columns.PhenomenonID)
                .IsEqualTo(phenomenon.Id)
                .OrderAsc(Offering.Columns.Name)
                //.Distinct()
                .ExecuteAsCollection<PhenomenonOfferingCollection>();
            foreach (var item in col)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode("Offering_" + item.Id.ToString(), item.Offering.Name, Icon.ResultsetNext);
                node.Checked = ThreeStateBool.False;
                node.Leaf = true;
                e.Nodes.Add(node);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void BuildTree()
    {
        AsyncTreeNode root = new AsyncTreeNode("Organisations", "Organisations");
        root.Icon = (Icon)new ModuleX("e4c08bfa-a8f0-4112-b45c-dd1788ade5a0").Icon;
        FilterTree.Root.Add(root);
        //OrganisationCollection organisationCol = new Select()
        //    .From(Organisation.Schema)
        //    .InnerJoin(OrganisationSite.Schema)
        //    .Distinct()
        //    .OrderAsc(Organisation.Columns.Name)
        //    .ExecuteAsCollection<OrganisationCollection>();

        ////        OrganisationCollection organisationCol = new OrganisationCollection().Where("ID", SubSonic.Comparison.IsNot, null).OrderByAsc(Organisation.Columns.Name).Load();

        //foreach (Organisation organisation in organisationCol)
        //{
        //    Ext.Net.TreeNode organisationNode = new Ext.Net.TreeNode(organisation.Name, Icon.ResultsetNext);
        //    root.Nodes.Add(organisationNode);

        //    SiteCollection siteCol = new Select()
        //        .From(SAEON.Observations.Data.Site.Schema)
        //        .InnerJoin(OrganisationSite.Schema)
        //        .Where(OrganisationSite.Columns.OrganisationID)
        //        .IsEqualTo(organisation.Id)
        //        .OrderAsc(SAEON.Observations.Data.Site.Columns.Name)
        //        .Distinct()
        //        .ExecuteAsCollection<SiteCollection>();
        //    modx = new ModuleX("A5C81FF7-69D6-4344-8548-E3EF7F08C4E7");
        //    Ext.Net.TreeNode siteRoot = new Ext.Net.TreeNode("Site", (Icon)modx.Icon);
        //    organisationNode.Nodes.Add(siteRoot);
        //    foreach (var site in siteCol)
        //    {
        //        Ext.Net.TreeNode siteNode = new Ext.Net.TreeNode(site.Name, Icon.ResultsetNext);
        //        siteRoot.Nodes.Add(siteNode);

        //        StationCollection stationCol = new Select()
        //            .From(Station.Schema)
        //            .InnerJoin(SAEON.Observations.Data.Site.Schema)
        //            .Where(Station.Columns.SiteID)
        //            .IsEqualTo(site.Id)
        //            .OrderAsc(Station.Columns.Name)
        //            .Distinct()
        //            .ExecuteAsCollection<StationCollection>();

        //        modx = new ModuleX("0585e63d-0f9f-4dda-98ec-7de9397dc614");
        //        Ext.Net.TreeNode stationRoot = new Ext.Net.TreeNode("Station", (Icon)modx.Icon);
        //        siteNode.Nodes.Add(stationRoot);

        //        foreach (var station in stationCol)
        //        {
        //            Ext.Net.TreeNode stationNode = new Ext.Net.TreeNode(station.Name, Icon.ResultsetNext);
        //            stationNode.Checked = Ext.Net.ThreeStateBool.False;
        //            stationNode.NodeID = station.Id.ToString() + "_Station";
        //            stationRoot.Nodes.Add(stationNode);

        //            modx = new ModuleX("2610866B-8CBF-44E1-9A38-6511B31A8350");
        //            Ext.Net.TreeNode instrumentRoot = new Ext.Net.TreeNode("Instrument", (Icon)modx.Icon);
        //            stationNode.Nodes.Add(instrumentRoot);

        //            InstrumentCollection instrumentCol = new Select()
        //                .From(Instrument.Schema)
        //                .InnerJoin(StationInstrument.Schema)
        //                .Where(StationInstrument.Columns.StationID)
        //                .IsEqualTo(station.Id)
        //                .OrderAsc(Instrument.Columns.Name)
        //                .Distinct()
        //                .ExecuteAsCollection<InstrumentCollection>();

        //            foreach (var instrument in instrumentCol)
        //            {
        //                Ext.Net.TreeNode instrumentNode = new Ext.Net.TreeNode(instrument.Name, Icon.ResultsetNext);
        //                instrumentNode.Checked = Ext.Net.ThreeStateBool.False;
        //                instrumentNode.NodeID = stationNode.NodeID + "|" + instrument.Id.ToString() + "_Instrument";
        //                instrumentRoot.Nodes.Add(instrumentNode);

        //                modx = new ModuleX("9992ba10-cb0c-4a22-841c-1d695e8293d5");
        //                Ext.Net.TreeNode sensorRoot = new Ext.Net.TreeNode("Sensor", (Icon)modx.Icon);
        //                instrumentNode.Nodes.Add(sensorRoot);

        //                SensorCollection sensorCol = new Select()
        //                    .From(Sensor.Schema)
        //                    .InnerJoin(InstrumentSensor.Schema)
        //                    .Where(InstrumentSensor.Columns.InstrumentID)
        //                    .IsEqualTo(instrument.Id)
        //                    .OrderAsc(Instrument.Columns.Name)
        //                    .Distinct()
        //                    .ExecuteAsCollection<SensorCollection>();
        //                foreach (var sensor in sensorCol)
        //                {
        //                    Ext.Net.TreeNode sensorNode = new Ext.Net.TreeNode(sensor.Name, Icon.ResultsetNext);
        //                    sensorNode.Checked = Ext.Net.ThreeStateBool.False;
        //                    sensorNode.NodeID = instrumentNode.NodeID + "|" + sensor.Id.ToString() + "_Sensor";
        //                    sensorRoot.Nodes.Add(sensorNode);
        //                    Phenomenon phenomenon = new Phenomenon(sensor.PhenomenonID);
        //                    Ext.Net.TreeNode phenomenonNode = new Ext.Net.TreeNode(phenomenon.Name, Icon.ResultsetNext);
        //                    phenomenonNode.Checked = Ext.Net.ThreeStateBool.False;
        //                    phenomenonNode.NodeID = sensorNode.NodeID + "|" + phenomenon.Id.ToString() + "_Phenomenon";
        //                    sensorNode.Nodes.Add(phenomenonNode);

        //                    PhenomenonOfferingCollection phenomenonOfferingCol = new Select()
        //                        .From(PhenomenonOffering.Schema)
        //                        .InnerJoin(Offering.Schema)
        //                        .Where(PhenomenonOffering.Columns.PhenomenonID)
        //                        .IsEqualTo(phenomenon.Id)
        //                        .OrderAsc(Offering.Columns.Name)
        //                        //.Distinct()
        //                        .ExecuteAsCollection<PhenomenonOfferingCollection>();
        //                    int n = 0;
        //                    foreach (var phenomenonOffering in phenomenonOfferingCol)
        //                    {
        //                        n++;
        //                        if (n > 20) break;
        //                        Ext.Net.TreeNode phenomenonOfferingNode = new Ext.Net.TreeNode(phenomenonOffering.Offering.Name, Icon.ResultsetNext);
        //                        phenomenonOfferingNode.Checked = Ext.Net.ThreeStateBool.False;
        //                        phenomenonOfferingNode.NodeID = phenomenonNode.NodeID + "|" + phenomenonOffering.Offering.Id.ToString() + "_Offering";
        //                        phenomenonNode.Nodes.Add(phenomenonOfferingNode);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //ProjectSiteCollection projectSiteCol = new ProjectSiteCollection().Where("ID", SubSonic.Comparison.IsNot, null)
        //    .Where("OrganisationID", SubSonic.Comparison.Equals, organisation.Id)
        //    .OrderByAsc(ProjectSite.Columns.Name).Load();

        //modx = new ModuleX("bd5f2a82-3dd3-46b1-8ce3-7ee99d5c77ad");
        //Ext.Net.TreeNode projectSiteroot = new Ext.Net.TreeNode("Project Site", (Icon)modx.Icon);
        //organisationNode.Nodes.Add(projectSiteroot);

        //foreach (ProjectSite projectSite in projectSiteCol)
        //{
        //    Ext.Net.TreeNode projectSiteNode = new Ext.Net.TreeNode(projectSite.Name, Icon.ResultsetNext);
        //    projectSiteroot.Nodes.Add(projectSiteNode);

        //    StationCollection StationCol = new StationCollection().Where("ID", SubSonic.Comparison.IsNot, null)
        //        .Where("ProjectSiteID", SubSonic.Comparison.Equals, projectSite.Id)
        //        .OrderByAsc(Station.Columns.Name).Load();

        //    modx = new ModuleX("0585e63d-0f9f-4dda-98ec-7de9397dc614");
        //    Ext.Net.TreeNode stationroot = new Ext.Net.TreeNode("Station", (Icon)modx.Icon);
        //    projectSiteNode.Nodes.Add(stationroot);

        //    foreach (Station station in StationCol)
        //    {
        //        Ext.Net.TreeNode stationNode = new Ext.Net.TreeNode(station.Name, Icon.ResultsetNext);
        //        stationNode.Checked = Ext.Net.ThreeStateBool.False;
        //        stationNode.NodeID = station.Id.ToString() + "_Station";
        //        stationroot.Nodes.Add(stationNode);

        //        SensorCollection SensorCol = new SensorCollection().Where("ID", SubSonic.Comparison.IsNot, null)
        //            .Where("StationID", SubSonic.Comparison.Equals, station.Id)
        //            .OrderByAsc(Sensor.Columns.Name).Load();

        //        modx = new ModuleX("9992ba10-cb0c-4a22-841c-1d695e8293d5");
        //        Ext.Net.TreeNode Sensorroot = new Ext.Net.TreeNode("Sensor Procedure", (Icon)modx.Icon);
        //        stationNode.Nodes.Add(Sensorroot);

        //        foreach (Sensor sensor in SensorCol)
        //        {
        //            Ext.Net.TreeNode SensorNode = new Ext.Net.TreeNode(sensor.Name, Icon.ResultsetNext);
        //            SensorNode.Checked = Ext.Net.ThreeStateBool.False;
        //            SensorNode.NodeID = sensor.Id.ToString() + "_Sensor";
        //            Sensorroot.Nodes.Add(SensorNode);
        //            Phenomenon phenomenon = new Phenomenon(sensor.PhenomenonID);


        //            Ext.Net.TreeNode phenomenonNode = new Ext.Net.TreeNode(phenomenon.Name, Icon.ResultsetNext);
        //            phenomenonNode.Checked = Ext.Net.ThreeStateBool.False;

        //            phenomenonNode.NodeID = sensor.Id.ToString() + "_Phenomenon";
        //            SensorNode.Nodes.Add(phenomenonNode);

        //            //PhenomenonOfferingCollection phenomenonOfferingCollection = new PhenomenonOfferingCollection().Where("ID", SubSonic.Comparison.IsNot, null)
        //            //    .Where("PhenomenonID", SubSonic.Comparison.Equals, phenomenon.Id).Load();


        //            // this.cbUnitofMeasure.GetStore().DataSource = new Select(PhenomenonUOM.IdColumn, UnitOfMeasure.UnitColumn)
        //            //.From(UnitOfMeasure.Schema)
        //            //.InnerJoin(PhenomenonUOM.UnitOfMeasureIDColumn, UnitOfMeasure.IdColumn)
        //            //.Where(PhenomenonUOM.Columns.PhenomenonID).IsEqualTo(Id)
        //            //.ExecuteDataSet().Tables[0];

        //            PhenomenonOfferingCollection phenomenonOfferingCollection = new Select().From(PhenomenonOffering.Schema)
        //                        .InnerJoin(Phenomenon.IdColumn, PhenomenonOffering.PhenomenonIDColumn)
        //                        .Where(Phenomenon.IdColumn).IsEqualTo(phenomenon.Id)
        //                        .OrderAsc(Phenomenon.Columns.Name)
        //                        .ExecuteAsCollection<PhenomenonOfferingCollection>();

        //            foreach (PhenomenonOffering phenomenonOffering in phenomenonOfferingCollection)
        //            {
        //                Ext.Net.TreeNode phenomenonOfferingNode = new Ext.Net.TreeNode(phenomenonOffering.Offering.Name, Icon.ResultsetNext);
        //                phenomenonOfferingNode.Checked = Ext.Net.ThreeStateBool.False;
        //                phenomenonOfferingNode.NodeID = phenomenonOffering.Offering.Id.ToString() + "_Offering#" + sensor.Id;
        //                phenomenonNode.Nodes.Add(phenomenonOfferingNode);
        //            }
        //        }
        //    }
        //}
        //}
    }

    protected class QueryDataClass
    {
        public string NodeID { get; set; }
        public Guid ID { get; set; }
        public string Type { get; set; }
    }

    protected void DQStore_Submit(object sender, StoreSubmitDataEventArgs e)
    {
        string type = FormatType.Text;
        string json = GridData.Text;
        string sortCol = SortInfo.Text.Substring(0, SortInfo.Text.IndexOf("|"));
        string sortDir = SortInfo.Text.Substring(SortInfo.Text.IndexOf("|") + 1);
        string visCols = VisCols.Value.ToString();



        string js = BuildQ(json, visCols, FromFilter.SelectedDate, ToFilter.SelectedDate, sortCol, sortDir);


        BaseRepository.doExport(type, js);

    }

    protected void DQStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {

        DateTime fromDate = FromFilter.SelectedDate;
        DateTime ToDate = ToFilter.SelectedDate;

        SqlQuery q = new Select().From(VObservationRole.Schema);

        if (FilterTree.CheckedNodes != null)
        {
            List<SubmittedNode> nodes = FilterTree.CheckedNodes;
            List<QueryDataClass> QueryDataClassList = new List<QueryDataClass>();

            foreach (var item in nodes)
            {
                var items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                QueryDataClassList.Add(new QueryDataClass() { NodeID = item.NodeID, ID = new Guid(items[0].Item1), Type = items[0].Item2 });
            }

            Log.Information("Items: {@items}", QueryDataClassList);

            #region buildQ
            foreach (QueryDataClass item in QueryDataClassList)
            {

                int count = 0;
                //Offering offering = new Offering();
                //Phenomenon Phenomenon = new Phenomenon();
                //Sensor Sensor = new Sensor();
                //Station station = new Station();
                List<Tuple<string, string>> items = null;
                Offering offering = null;
                Phenomenon phenomenon = null;
                Sensor sensor = null;
                Instrument instrument = null;
                Station station = null;
                switch (item.Type)
                {
                    case "Offering":
                        count++;
                        items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                        Log.Information("Items: {@items}", items);
                        offering = new Offering(item.ID);
                        phenomenon = new Phenomenon(new Guid(items[1].Item1));
                        sensor = new Sensor(new Guid(items[2].Item1));
                        instrument = new Instrument(new Guid(items[3].Item1));
                        station = new Station(new Guid(items[4].Item1));
                        q.OrExpression(VObservation.Columns.OfferingID).IsEqualTo(offering.Id)
                            .And(VObservation.Columns.PhenomenonID).IsEqualTo(phenomenon.Id)
                            .And(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                            .And(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Phenomenon":
                        count++;
                        items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                        phenomenon = new Phenomenon(item.ID);
                        sensor = new Sensor(new Guid(items[1].Item1));
                        instrument = new Instrument(new Guid(items[2].Item1));
                        station = new Station(new Guid(items[3].Item1));
                        q.OrExpression(VObservation.Columns.PhenomenonID).IsEqualTo(phenomenon.Id)
                            .And(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                            .And(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Sensor":
                        items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                        sensor = new Sensor(item.ID);
                        instrument = new Instrument(new Guid(items[1].Item1));
                        station = new Station(new Guid(items[2].Item1));
                        q.OrExpression(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                            .And(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Instrument":
                        instrument = new Instrument(item.ID);
                        station = new Station(new Guid(items[1].Item1));
                        q.OrExpression(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Station":
                        station = new Station(item.ID);
                        q.OrExpression(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                }


                //if (item.Type.Length > 20)
                //{
                //    if (item.Type == "Offering")
                //    {
                //        count++;
                //        Offering offering = new Offering(item.ID);
                //        Sensor sensor = new Sensor(item.Type.Substring(item.Type.IndexOf("#") + 1, item.Type.Substring(item.Type.IndexOf("#") + 1, 36).Length));
                //        q.OrExpression(VObservation.Columns.OfferingID).IsEqualTo(offering.Id)
                //       .And(VObservation.Columns.PhenomenonID).IsEqualTo(sensor.PhenomenonID)
                //       .And(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                //       //.And(VObservation.Columns.InstrumentID).IsEqualTo()
                //       .And(VObservation.Columns.StationID).IsEqualTo(sensor.StationID);
                //    }
                //}

                //if (item.Type == "Phenomenon")
                //{
                //    count++;
                //    Sensor sp = new Sensor(item.ID);
                //    Phenomenon phenomenon = new Phenomenon(sp.PhenomenonID);

                //    q.OrExpression(VObservation.Columns.PhenomenonID).IsEqualTo(phenomenon.Id)
                //    .And(VObservation.Columns.SensorID).IsEqualTo(sp.Id)
                //    .And(VObservation.Columns.StationID).IsEqualTo(sp.StationID);

                //}

                //if (item.Type == "Sensor")
                //{
                //    count++;
                //    //Sensor = new Sensor(item.ID);

                //    //q.OrExpression(VObservation.Columns.SensorID).IsEqualTo(item.ID)
                //    //.And(VObservation.Columns.StationID).IsEqualTo(Sensor.StationID);

                //}

                //if (item.Type == "Station")
                //{
                //    count++;
                //    //station = new Station(item.ID);
                //    q.OrExpression(VObservation.Columns.StationID).IsEqualTo(item.ID);

                //}

                if (count != 0)
                {
                    if (fromDate.ToString() != "0001/01/01 00:00:00")
                    {
                        q.And(VObservation.Columns.ValueDate).IsGreaterThanOrEqualTo(fromDate.ToString());
                    }
                    if (ToDate.ToString() != "0001/01/01 00:00:00")
                    {
                        q.And(VObservation.Columns.ValueDate).IsLessThanOrEqualTo(ToDate.AddHours(23).AddMinutes(59).AddSeconds(59).ToString());
                    }
                    q.And(VObservationRole.Columns.RoleUserId).IsEqualTo(AuthHelper.GetLoggedInUserId);
                    DataQueryRepository.qFilterNSort(ref q, ref e);

                    q.CloseExpression();


                }
            }
            #endregion buildQ

            Log.Information("SQL: {sql}", q.BuildSqlStatement());

            DataQueryRepository.qPage(ref q, ref e);
            Ext.Net.GridFilters gfs = FindControl("GridFilters1") as Ext.Net.GridFilters;
            this.ObservationsGrid.GetStore().DataSource = DataQueryRepository.GetPagedFilteredList(e, e.Parameters[this.GridFilters1.ParamPrefix], ref q);


        }
        else

            this.ObservationsGrid.GetStore().DataSource = DataQueryRepository.GetPagedList(e, e.Parameters[this.GridFilters1.ParamPrefix], fromDate, ToDate);


    }



    public string BuildQ(string json, string visCols, DateTime dateFrom, DateTime dateTo, string sortCol, string sortDir)
    {
        Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(visCols);

        List<string> colmsL = new List<string>();
        List<string> colmsDisplayNamesL = new List<string>();

        foreach (var item in values)
        {
            if (string.IsNullOrWhiteSpace(item.Value) || string.IsNullOrWhiteSpace(item.Key))
            {

            }
            else
            {
                //colms[i] = item.Value;
                //colmsDisplayNames[i] = item.Key;
                //i++;
                colmsL.Add(item.Value);
                colmsDisplayNamesL.Add(item.Key.Replace(" ", "").Replace("/", ""));

            }
        }

        string[] colms = colmsL.ToArray();
        string[] colmsDisplayNames = colmsDisplayNamesL.ToArray();


        SqlQuery q = new Select(colms).From(VObservationRole.Schema);

        //q.And(VObservationRole.Columns.Expr5).IsEqualTo(AuthHelper.GetLoggedInUserId);


        if (FilterTree.CheckedNodes != null)
        {
            List<SubmittedNode> nodes = FilterTree.CheckedNodes;
            List<QueryDataClass> QueryDataClassList = new List<QueryDataClass>();

            foreach (var item in nodes)
            {
                var items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                QueryDataClassList.Add(new QueryDataClass() { NodeID = item.NodeID, ID = new Guid(items[0].Item1), Type = items[0].Item2 });
                //QueryDataClassList.Add(new QueryDataClass() { ID = new Guid(item.NodeID.Substring(0, item.NodeID.IndexOf("_"))), Type = item.NodeID.Substring(item.NodeID.IndexOf("_") + 1) });
            }

            #region buildQ
            foreach (QueryDataClass item in QueryDataClassList)
            {

                int count = 0;
                List<Tuple<string, string>> items = null;
                Offering offering = null;
                Phenomenon phenomenon = null;
                Sensor sensor = null;
                Instrument instrument = null;
                Station station = null;
                switch (item.Type)
                {
                    case "Offering":
                        count++;
                        items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                        Log.Information("Items: {@items}", items);
                        offering = new Offering(item.ID);
                        phenomenon = new Phenomenon(new Guid(items[1].Item1));
                        sensor = new Sensor(new Guid(items[2].Item1));
                        instrument = new Instrument(new Guid(items[3].Item1));
                        station = new Station(new Guid(items[4].Item1));
                        q.OrExpression(VObservation.Columns.OfferingID).IsEqualTo(offering.Id)
                            .And(VObservation.Columns.PhenomenonID).IsEqualTo(phenomenon.Id)
                            .And(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                            .And(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Phenomenon":
                        count++;
                        items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                        phenomenon = new Phenomenon(item.ID);
                        sensor = new Sensor(new Guid(items[1].Item1));
                        instrument = new Instrument(new Guid(items[2].Item1));
                        station = new Station(new Guid(items[3].Item1));
                        q.OrExpression(VObservation.Columns.PhenomenonID).IsEqualTo(phenomenon.Id)
                            .And(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                            .And(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Sensor":
                        items = item.NodeID.Split('|').Reverse().Select(i => new Tuple<string, string>(i.Split('_')[0], i.Split('_')[1])).ToList();
                        sensor = new Sensor(item.ID);
                        instrument = new Instrument(new Guid(items[1].Item1));
                        station = new Station(new Guid(items[2].Item1));
                        q.OrExpression(VObservation.Columns.SensorID).IsEqualTo(sensor.Id)
                            .And(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Instrument":
                        instrument = new Instrument(item.ID);
                        station = new Station(new Guid(items[1].Item1));
                        q.OrExpression(VObservation.Columns.InstrumentID).IsEqualTo(instrument.Id)
                            .And(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                    case "Station":
                        station = new Station(item.ID);
                        q.OrExpression(VObservation.Columns.StationID).IsEqualTo(station.Id);
                        break;
                }
                //Offering offering = new Offering();
                //Phenomenon Phenomenon = new Phenomenon();
                //Sensor Sensor = new Sensor();
                //Station station = new Station();

                //if (item.Type.Length > 20)
                //{
                //    if (item.Type.Substring(0, 8) == "Offering")
                //    {
                //        count++;
                //        Offering off = new Offering(item.ID);
                //        Sensor sp = new Sensor(item.Type.Substring(item.Type.IndexOf("#") + 1, item.Type.Substring(item.Type.IndexOf("#") + 1, 36).Length));


                //        q.OrExpression(VObservation.Columns.OfferingID).IsEqualTo(off.Id)
                //       .And(VObservation.Columns.PhenomenonID).IsEqualTo(sp.PhenomenonID)
                //       .And(VObservation.Columns.SensorID).IsEqualTo(sp.Id)
                //       .And(VObservation.Columns.StationID).IsEqualTo(sp.StationID);
                //    }
                //}

                //if (item.Type == "Phenomenon")
                //{
                //    count++;
                //    Sensor sp = new Sensor(item.ID);
                //    Phenomenon phenomenon = new Phenomenon(sp.PhenomenonID);

                //    q.OrExpression(VObservation.Columns.PhenomenonID).IsEqualTo(phenomenon.Id)
                //    .And(VObservation.Columns.SensorID).IsEqualTo(sp.Id)
                //    .And(VObservation.Columns.StationID).IsEqualTo(sp.StationID);

                //}

                //if (item.Type == "Sensor")
                //{
                //    count++;
                //    Sensor = new Sensor(item.ID);

                //    q.OrExpression(VObservation.Columns.SensorID).IsEqualTo(item.ID)
                //    .And(VObservation.Columns.StationID).IsEqualTo(Sensor.StationID);

                //}

                //if (item.Type == "Station")
                //{
                //    count++;
                //    station = new Station(item.ID);
                //    q.OrExpression(VObservation.Columns.StationID).IsEqualTo(item.ID);

                //}

                if (count != 0)
                {

                    q.And(VObservation.Columns.ValueDate).IsGreaterThanOrEqualTo(dateFrom);

                    q.And(VObservation.Columns.ValueDate).IsLessThanOrEqualTo(dateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    if (json != null)
                    {
                        if (!string.IsNullOrEmpty(json))
                        {
                            FilterConditions fc = new FilterConditions(json);

                            foreach (FilterCondition condition in fc.Conditions)
                            {
                                switch (condition.FilterType)
                                {
                                    case FilterType.Date:
                                        switch (condition.Comparison.ToString())
                                        {
                                            case "Eq":
                                                q.And(condition.Name).IsEqualTo(condition.Value);

                                                break;
                                            case "Gt":
                                                q.And(condition.Name).IsGreaterThanOrEqualTo(condition.Value);

                                                break;
                                            case "Lt":
                                                q.And(condition.Name).IsLessThanOrEqualTo(condition.Value);

                                                break;
                                            default:
                                                break;
                                        }

                                        break;

                                    case FilterType.Numeric:
                                        switch (condition.Comparison.ToString())
                                        {
                                            case "Eq":
                                                q.And(condition.Name).IsEqualTo(condition.Value);

                                                break;
                                            case "Gt":
                                                q.And(condition.Name).IsGreaterThanOrEqualTo(condition.Value);

                                                break;
                                            case "Lt":
                                                q.And(condition.Name).IsLessThanOrEqualTo(condition.Value);

                                                break;
                                            default:
                                                break;
                                        }

                                        break;

                                    case FilterType.String:
                                        q.And(condition.Name).Like("%" + condition.Value + "%");


                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }

                            }

                        }
                    }

                    q.And(VObservationRole.Columns.RoleUserId).IsEqualTo(AuthHelper.GetLoggedInUserId);
                    q.CloseExpression();


                }
            }
            #endregion buildQ

            Ext.Net.GridFilters gfs = FindControl("GridFilters1") as Ext.Net.GridFilters;


        }

        if (!(string.IsNullOrEmpty(sortCol) && string.IsNullOrEmpty(sortDir)))
        {
            if (sortDir.ToLower() == Ext.Net.SortDirection.DESC.ToString().ToLower())
            {
                q.OrderDesc(sortCol);
            }
            else
            {
                q.OrderAsc(sortCol);
            }
        }

        DataTable dt = q.ExecuteDataSet().Tables[0];

        for (int k = 0; k < dt.Columns.Count; k++)
        {
            for (int j = 0; j < colms.Length; j++)
            {
                if (colms[j].ToLower() == dt.Columns[k].ToString().ToLower())
                {
                    dt.Columns[k].ColumnName = colmsDisplayNames[j];
                }
            }
        }

        JavaScriptSerializer ser = new JavaScriptSerializer();
        ser.MaxJsonLength = 2147483647;

        string js = JsonConvert.SerializeObject(dt);

        return js;
    }


    protected void ToExcel(object sender, DirectEventArgs e)
    {
        //Ext.Net.Hidden hiddenfield = FindControl("GridData") as Ext.Net.Hidden;
        //string json = hiddenfield.Value.ToString();
        ///////
        //Ext.Net.Hidden VisCols = FindControl("VisCols") as Ext.Net.Hidden;
        //string visCols = VisCols.Value.ToString();



        //string js = BuildQ(json, visCols, e.ExtraParams["dateFrom"], e.ExtraParams["dateTo"]);


        //System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
        //new System.Web.Script.Serialization.JavaScriptSerializer();
        ////json = oSerializer.Serialize(LOutDynamic);

        //StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(js, null);
        //XmlNode xml = eSubmit.Xml;

        //this.Response.Clear();
        //this.Response.ContentType = "application/vnd.ms-excel";
        //this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
        //XslCompiledTransform xtExcel = new XslCompiledTransform();
        //xtExcel.Load(Server.MapPath("../Templates/Excel.xsl"));
        //xtExcel.Transform(xml, null, this.Response.OutputStream);
        //this.Response.End();
    }

}