using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace SAEON.ObservationsDB.Data
{
    /// <summary>
    /// Controller class for DataSourceTransformation
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DataSourceTransformationController
    {
        // Preload our schema..
        DataSourceTransformation thisSchemaLoad = new DataSourceTransformation();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataSourceTransformationCollection FetchAll()
        {
            DataSourceTransformationCollection coll = new DataSourceTransformationCollection();
            Query qry = new Query(DataSourceTransformation.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataSourceTransformationCollection FetchByID(object Id)
        {
            DataSourceTransformationCollection coll = new DataSourceTransformationCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataSourceTransformationCollection FetchByQuery(Query qry)
        {
            DataSourceTransformationCollection coll = new DataSourceTransformationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (DataSourceTransformation.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (DataSourceTransformation.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,Guid TransformationTypeID,Guid PhenomenonID,Guid? PhenomenonOfferingID,Guid? PhenomenonUOMID,DateTime StartDate,DateTime? EndDate,Guid DataSourceID,string Definition,Guid? NewPhenomenonOfferingID,Guid? NewPhenomenonUOMID,int? Rank,Guid? SensorID,Guid? UserId)
	    {
		    DataSourceTransformation item = new DataSourceTransformation();
		    
            item.Id = Id;
            
            item.TransformationTypeID = TransformationTypeID;
            
            item.PhenomenonID = PhenomenonID;
            
            item.PhenomenonOfferingID = PhenomenonOfferingID;
            
            item.PhenomenonUOMID = PhenomenonUOMID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.DataSourceID = DataSourceID;
            
            item.Definition = Definition;
            
            item.NewPhenomenonOfferingID = NewPhenomenonOfferingID;
            
            item.NewPhenomenonUOMID = NewPhenomenonUOMID;
            
            item.Rank = Rank;
            
            item.SensorID = SensorID;
            
            item.UserId = UserId;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,Guid TransformationTypeID,Guid PhenomenonID,Guid? PhenomenonOfferingID,Guid? PhenomenonUOMID,DateTime StartDate,DateTime? EndDate,Guid DataSourceID,string Definition,Guid? NewPhenomenonOfferingID,Guid? NewPhenomenonUOMID,int? Rank,Guid? SensorID,Guid? UserId)
	    {
		    DataSourceTransformation item = new DataSourceTransformation();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.TransformationTypeID = TransformationTypeID;
				
			item.PhenomenonID = PhenomenonID;
				
			item.PhenomenonOfferingID = PhenomenonOfferingID;
				
			item.PhenomenonUOMID = PhenomenonUOMID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.DataSourceID = DataSourceID;
				
			item.Definition = Definition;
				
			item.NewPhenomenonOfferingID = NewPhenomenonOfferingID;
				
			item.NewPhenomenonUOMID = NewPhenomenonUOMID;
				
			item.Rank = Rank;
				
			item.SensorID = SensorID;
				
			item.UserId = UserId;
				
	        item.Save(UserName);
	    }
    }
}
