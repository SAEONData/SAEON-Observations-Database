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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string RefactorLog = @"__RefactorLog";
        
		public static readonly string AspnetApplication = @"aspnet_Applications";
        
		public static readonly string AspnetMembership = @"aspnet_Membership";
        
		public static readonly string AspnetPath = @"aspnet_Paths";
        
		public static readonly string AspnetPersonalizationAllUser = @"aspnet_PersonalizationAllUsers";
        
		public static readonly string AspnetPersonalizationPerUser = @"aspnet_PersonalizationPerUser";
        
		public static readonly string AspnetProfile = @"aspnet_Profile";
        
		public static readonly string AspnetRole = @"aspnet_Roles";
        
		public static readonly string AspnetSchemaVersion = @"aspnet_SchemaVersions";
        
		public static readonly string AspnetUser = @"aspnet_Users";
        
		public static readonly string AspnetUsersInRole = @"aspnet_UsersInRoles";
        
		public static readonly string AspnetWebEventEvent = @"aspnet_WebEvent_Events";
        
		public static readonly string AuditLog = @"AuditLog";
        
		public static readonly string DataLog = @"DataLog";
        
		public static readonly string DataSchema = @"DataSchema";
        
		public static readonly string DataSource = @"DataSource";
        
		public static readonly string DataSourceOrganisation = @"DataSource_Organisation";
        
		public static readonly string DataSourceRole = @"DataSourceRole";
        
		public static readonly string DataSourceTransformation = @"DataSourceTransformation";
        
		public static readonly string DataSourceType = @"DataSourceType";
        
		public static readonly string ImportBatch = @"ImportBatch";
        
		public static readonly string ModuleX = @"Module";
        
		public static readonly string Observation = @"Observation";
        
		public static readonly string Offering = @"Offering";
        
		public static readonly string Organisation = @"Organisation";
        
		public static readonly string OrganisationRole = @"OrganisationRole";
        
		public static readonly string Phenomenon = @"Phenomenon";
        
		public static readonly string PhenomenonOffering = @"PhenomenonOffering";
        
		public static readonly string PhenomenonUOM = @"PhenomenonUOM";
        
		public static readonly string Progress = @"Progress";
        
		public static readonly string ProjectSite = @"ProjectSite";
        
		public static readonly string RoleModule = @"RoleModule";
        
		public static readonly string Sensor = @"Sensor";
        
		public static readonly string Site = @"Site";
        
		public static readonly string SiteOrganisation = @"Site_Organisation";
        
		public static readonly string Station = @"Station";
        
		public static readonly string StationOrganisation = @"Station_Organisation";
        
		public static readonly string Status = @"Status";
        
		public static readonly string TransformationType = @"TransformationType";
        
		public static readonly string UnitOfMeasure = @"UnitOfMeasure";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table RefactorLog
		{
            get { return DataService.GetSchema("__RefactorLog", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetApplication
		{
            get { return DataService.GetSchema("aspnet_Applications", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetMembership
		{
            get { return DataService.GetSchema("aspnet_Membership", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetPath
		{
            get { return DataService.GetSchema("aspnet_Paths", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetPersonalizationAllUser
		{
            get { return DataService.GetSchema("aspnet_PersonalizationAllUsers", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetPersonalizationPerUser
		{
            get { return DataService.GetSchema("aspnet_PersonalizationPerUser", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetProfile
		{
            get { return DataService.GetSchema("aspnet_Profile", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetRole
		{
            get { return DataService.GetSchema("aspnet_Roles", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetSchemaVersion
		{
            get { return DataService.GetSchema("aspnet_SchemaVersions", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetUser
		{
            get { return DataService.GetSchema("aspnet_Users", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetUsersInRole
		{
            get { return DataService.GetSchema("aspnet_UsersInRoles", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AspnetWebEventEvent
		{
            get { return DataService.GetSchema("aspnet_WebEvent_Events", "ObservationsDB"); }
		}
        
		public static TableSchema.Table AuditLog
		{
            get { return DataService.GetSchema("AuditLog", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataLog
		{
            get { return DataService.GetSchema("DataLog", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataSchema
		{
            get { return DataService.GetSchema("DataSchema", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataSource
		{
            get { return DataService.GetSchema("DataSource", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataSourceOrganisation
		{
            get { return DataService.GetSchema("DataSource_Organisation", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataSourceRole
		{
            get { return DataService.GetSchema("DataSourceRole", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataSourceTransformation
		{
            get { return DataService.GetSchema("DataSourceTransformation", "ObservationsDB"); }
		}
        
		public static TableSchema.Table DataSourceType
		{
            get { return DataService.GetSchema("DataSourceType", "ObservationsDB"); }
		}
        
		public static TableSchema.Table ImportBatch
		{
            get { return DataService.GetSchema("ImportBatch", "ObservationsDB"); }
		}
        
		public static TableSchema.Table ModuleX
		{
            get { return DataService.GetSchema("Module", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Observation
		{
            get { return DataService.GetSchema("Observation", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Offering
		{
            get { return DataService.GetSchema("Offering", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Organisation
		{
            get { return DataService.GetSchema("Organisation", "ObservationsDB"); }
		}
        
		public static TableSchema.Table OrganisationRole
		{
            get { return DataService.GetSchema("OrganisationRole", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Phenomenon
		{
            get { return DataService.GetSchema("Phenomenon", "ObservationsDB"); }
		}
        
		public static TableSchema.Table PhenomenonOffering
		{
            get { return DataService.GetSchema("PhenomenonOffering", "ObservationsDB"); }
		}
        
		public static TableSchema.Table PhenomenonUOM
		{
            get { return DataService.GetSchema("PhenomenonUOM", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Progress
		{
            get { return DataService.GetSchema("Progress", "ObservationsDB"); }
		}
        
		public static TableSchema.Table ProjectSite
		{
            get { return DataService.GetSchema("ProjectSite", "ObservationsDB"); }
		}
        
		public static TableSchema.Table RoleModule
		{
            get { return DataService.GetSchema("RoleModule", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Sensor
		{
            get { return DataService.GetSchema("Sensor", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Site
		{
            get { return DataService.GetSchema("Site", "ObservationsDB"); }
		}
        
		public static TableSchema.Table SiteOrganisation
		{
            get { return DataService.GetSchema("Site_Organisation", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Station
		{
            get { return DataService.GetSchema("Station", "ObservationsDB"); }
		}
        
		public static TableSchema.Table StationOrganisation
		{
            get { return DataService.GetSchema("Station_Organisation", "ObservationsDB"); }
		}
        
		public static TableSchema.Table Status
		{
            get { return DataService.GetSchema("Status", "ObservationsDB"); }
		}
        
		public static TableSchema.Table TransformationType
		{
            get { return DataService.GetSchema("TransformationType", "ObservationsDB"); }
		}
        
		public static TableSchema.Table UnitOfMeasure
		{
            get { return DataService.GetSchema("UnitOfMeasure", "ObservationsDB"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static readonly string ProgressProgressResolved = @"progress_Progress_Resolved";
        
		public static readonly string VAuditLog = @"vAuditLog";
        
		public static readonly string VDataLog = @"vDataLog";
        
		public static readonly string VDataQuery = @"vDataQuery";
        
		public static readonly string VDataSchema = @"vDataSchema";
        
		public static readonly string VDataSource = @"vDataSource";
        
		public static readonly string VDataSourceOrganisation = @"vDataSourceOrganisation";
        
		public static readonly string VDataSourceTransformation = @"vDataSourceTransformation";
        
		public static readonly string VImportBatch = @"vImportBatch";
        
		public static readonly string VInventory = @"vInventory";
        
		public static readonly string VModuleRoleModule = @"vModuleRoleModule";
        
		public static readonly string VObservation = @"vObservation";
        
		public static readonly string VObservationRole = @"vObservationRoles";
        
		public static readonly string VProjectSite = @"vProjectSite";
        
		public static readonly string VSensor = @"vSensor";
        
		public static readonly string VSensorProcedure = @"vSensorProcedure";
        
		public static readonly string VSiteOrganisation = @"vSiteOrganisation";
        
		public static readonly string VStation = @"vStation";
        
		public static readonly string VStationOrganisation = @"vStationOrganisation";
        
		public static readonly string VUserInfo = @"vUserInfo";
        
		public static readonly string VwAspnetApplication = @"vw_aspnet_Applications";
        
		public static readonly string VwAspnetMembershipUser = @"vw_aspnet_MembershipUsers";
        
		public static readonly string VwAspnetProfile = @"vw_aspnet_Profiles";
        
		public static readonly string VwAspnetRole = @"vw_aspnet_Roles";
        
		public static readonly string VwAspnetUser = @"vw_aspnet_Users";
        
		public static readonly string VwAspnetUsersInRole = @"vw_aspnet_UsersInRoles";
        
		public static readonly string VwAspnetWebPartStatePath = @"vw_aspnet_WebPartState_Paths";
        
		public static readonly string VwAspnetWebPartStateShared = @"vw_aspnet_WebPartState_Shared";
        
		public static readonly string VwAspnetWebPartStateUser = @"vw_aspnet_WebPartState_User";
        
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["ObservationsDB"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static readonly string ObservationsDB = @"ObservationsDB";
    
}
#endregion