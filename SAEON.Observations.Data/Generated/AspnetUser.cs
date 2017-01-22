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
namespace SAEON.Observations.Data
{
	/// <summary>
	/// Strongly-typed collection for the AspnetUser class.
	/// </summary>
    [Serializable]
	public partial class AspnetUserCollection : ActiveList<AspnetUser, AspnetUserCollection>
	{	   
		public AspnetUserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AspnetUserCollection</returns>
		public AspnetUserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AspnetUser o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the aspnet_Users table.
	/// </summary>
	[Serializable]
	public partial class AspnetUser : ActiveRecord<AspnetUser>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AspnetUser()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AspnetUser(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AspnetUser(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AspnetUser(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("aspnet_Users", TableType.Table, DataService.GetInstance("ObservationsDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarApplicationId = new TableSchema.TableColumn(schema);
				colvarApplicationId.ColumnName = "ApplicationId";
				colvarApplicationId.DataType = DbType.Guid;
				colvarApplicationId.MaxLength = 0;
				colvarApplicationId.AutoIncrement = false;
				colvarApplicationId.IsNullable = false;
				colvarApplicationId.IsPrimaryKey = false;
				colvarApplicationId.IsForeignKey = true;
				colvarApplicationId.IsReadOnly = false;
				colvarApplicationId.DefaultSetting = @"";
				
					colvarApplicationId.ForeignKeyTableName = "aspnet_Applications";
				schema.Columns.Add(colvarApplicationId);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = true;
				colvarUserId.IsForeignKey = false;
				colvarUserId.IsReadOnly = false;
				
						colvarUserId.DefaultSetting = @"(newid())";
				colvarUserId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserId);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.String;
				colvarUserName.MaxLength = 256;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = false;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarLoweredUserName = new TableSchema.TableColumn(schema);
				colvarLoweredUserName.ColumnName = "LoweredUserName";
				colvarLoweredUserName.DataType = DbType.String;
				colvarLoweredUserName.MaxLength = 256;
				colvarLoweredUserName.AutoIncrement = false;
				colvarLoweredUserName.IsNullable = false;
				colvarLoweredUserName.IsPrimaryKey = false;
				colvarLoweredUserName.IsForeignKey = false;
				colvarLoweredUserName.IsReadOnly = false;
				colvarLoweredUserName.DefaultSetting = @"";
				colvarLoweredUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoweredUserName);
				
				TableSchema.TableColumn colvarMobileAlias = new TableSchema.TableColumn(schema);
				colvarMobileAlias.ColumnName = "MobileAlias";
				colvarMobileAlias.DataType = DbType.String;
				colvarMobileAlias.MaxLength = 16;
				colvarMobileAlias.AutoIncrement = false;
				colvarMobileAlias.IsNullable = true;
				colvarMobileAlias.IsPrimaryKey = false;
				colvarMobileAlias.IsForeignKey = false;
				colvarMobileAlias.IsReadOnly = false;
				
						colvarMobileAlias.DefaultSetting = @"(NULL)";
				colvarMobileAlias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMobileAlias);
				
				TableSchema.TableColumn colvarIsAnonymous = new TableSchema.TableColumn(schema);
				colvarIsAnonymous.ColumnName = "IsAnonymous";
				colvarIsAnonymous.DataType = DbType.Boolean;
				colvarIsAnonymous.MaxLength = 0;
				colvarIsAnonymous.AutoIncrement = false;
				colvarIsAnonymous.IsNullable = false;
				colvarIsAnonymous.IsPrimaryKey = false;
				colvarIsAnonymous.IsForeignKey = false;
				colvarIsAnonymous.IsReadOnly = false;
				
						colvarIsAnonymous.DefaultSetting = @"((0))";
				colvarIsAnonymous.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsAnonymous);
				
				TableSchema.TableColumn colvarLastActivityDate = new TableSchema.TableColumn(schema);
				colvarLastActivityDate.ColumnName = "LastActivityDate";
				colvarLastActivityDate.DataType = DbType.DateTime;
				colvarLastActivityDate.MaxLength = 0;
				colvarLastActivityDate.AutoIncrement = false;
				colvarLastActivityDate.IsNullable = false;
				colvarLastActivityDate.IsPrimaryKey = false;
				colvarLastActivityDate.IsForeignKey = false;
				colvarLastActivityDate.IsReadOnly = false;
				colvarLastActivityDate.DefaultSetting = @"";
				colvarLastActivityDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastActivityDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ObservationsDB"].AddSchema("aspnet_Users",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ApplicationId")]
		[Bindable(true)]
		public Guid ApplicationId 
		{
			get { return GetColumnValue<Guid>(Columns.ApplicationId); }
			set { SetColumnValue(Columns.ApplicationId, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid UserId 
		{
			get { return GetColumnValue<Guid>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		  
		[XmlAttribute("UserName")]
		[Bindable(true)]
		public string UserName 
		{
			get { return GetColumnValue<string>(Columns.UserName); }
			set { SetColumnValue(Columns.UserName, value); }
		}
		  
		[XmlAttribute("LoweredUserName")]
		[Bindable(true)]
		public string LoweredUserName 
		{
			get { return GetColumnValue<string>(Columns.LoweredUserName); }
			set { SetColumnValue(Columns.LoweredUserName, value); }
		}
		  
		[XmlAttribute("MobileAlias")]
		[Bindable(true)]
		public string MobileAlias 
		{
			get { return GetColumnValue<string>(Columns.MobileAlias); }
			set { SetColumnValue(Columns.MobileAlias, value); }
		}
		  
		[XmlAttribute("IsAnonymous")]
		[Bindable(true)]
		public bool IsAnonymous 
		{
			get { return GetColumnValue<bool>(Columns.IsAnonymous); }
			set { SetColumnValue(Columns.IsAnonymous, value); }
		}
		  
		[XmlAttribute("LastActivityDate")]
		[Bindable(true)]
		public DateTime LastActivityDate 
		{
			get { return GetColumnValue<DateTime>(Columns.LastActivityDate); }
			set { SetColumnValue(Columns.LastActivityDate, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public SAEON.Observations.Data.AspnetMembershipCollection AspnetMembershipRecords()
		{
			return new SAEON.Observations.Data.AspnetMembershipCollection().Where(AspnetMembership.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.AspnetPersonalizationPerUserCollection AspnetPersonalizationPerUserRecords()
		{
			return new SAEON.Observations.Data.AspnetPersonalizationPerUserCollection().Where(AspnetPersonalizationPerUser.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.AspnetProfileCollection AspnetProfileRecords()
		{
			return new SAEON.Observations.Data.AspnetProfileCollection().Where(AspnetProfile.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.AspnetUsersInRoleCollection AspnetUsersInRoles()
		{
			return new SAEON.Observations.Data.AspnetUsersInRoleCollection().Where(AspnetUsersInRole.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.AuditLogCollection AuditLogRecords()
		{
			return new SAEON.Observations.Data.AuditLogCollection().Where(AuditLog.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.DataLogCollection DataLogRecords()
		{
			return new SAEON.Observations.Data.DataLogCollection().Where(DataLog.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.DataSchemaCollection DataSchemaRecords()
		{
			return new SAEON.Observations.Data.DataSchemaCollection().Where(DataSchema.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.DataSourceCollection DataSourceRecords()
		{
			return new SAEON.Observations.Data.DataSourceCollection().Where(DataSource.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.DataSourceRoleCollection DataSourceRoleRecords()
		{
			return new SAEON.Observations.Data.DataSourceRoleCollection().Where(DataSourceRole.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.DataSourceTransformationCollection DataSourceTransformationRecords()
		{
			return new SAEON.Observations.Data.DataSourceTransformationCollection().Where(DataSourceTransformation.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.DataSourceTypeCollection DataSourceTypeRecords()
		{
			return new SAEON.Observations.Data.DataSourceTypeCollection().Where(DataSourceType.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.ImportBatchCollection ImportBatchRecords()
		{
			return new SAEON.Observations.Data.ImportBatchCollection().Where(ImportBatch.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.InstrumentCollection InstrumentRecords()
		{
			return new SAEON.Observations.Data.InstrumentCollection().Where(Instrument.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.InstrumentDataSourceCollection InstrumentDataSourceRecords()
		{
			return new SAEON.Observations.Data.InstrumentDataSourceCollection().Where(InstrumentDataSource.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.InstrumentSensorCollection InstrumentSensorRecords()
		{
			return new SAEON.Observations.Data.InstrumentSensorCollection().Where(InstrumentSensor.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.ObservationCollection ObservationRecords()
		{
			return new SAEON.Observations.Data.ObservationCollection().Where(Observation.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.OfferingCollection OfferingRecords()
		{
			return new SAEON.Observations.Data.OfferingCollection().Where(Offering.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.OrganisationCollection OrganisationRecords()
		{
			return new SAEON.Observations.Data.OrganisationCollection().Where(Organisation.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.OrganisationInstrumentCollection OrganisationInstrumentRecords()
		{
			return new SAEON.Observations.Data.OrganisationInstrumentCollection().Where(OrganisationInstrument.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.OrganisationSiteCollection OrganisationSiteRecords()
		{
			return new SAEON.Observations.Data.OrganisationSiteCollection().Where(OrganisationSite.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.OrganisationStationCollection OrganisationStationRecords()
		{
			return new SAEON.Observations.Data.OrganisationStationCollection().Where(OrganisationStation.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.OrganisationRoleCollection OrganisationRoleRecords()
		{
			return new SAEON.Observations.Data.OrganisationRoleCollection().Where(OrganisationRole.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.PhenomenonCollection PhenomenonRecords()
		{
			return new SAEON.Observations.Data.PhenomenonCollection().Where(Phenomenon.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.PhenomenonOfferingCollection PhenomenonOfferingRecords()
		{
			return new SAEON.Observations.Data.PhenomenonOfferingCollection().Where(PhenomenonOffering.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.PhenomenonUOMCollection PhenomenonUOMRecords()
		{
			return new SAEON.Observations.Data.PhenomenonUOMCollection().Where(PhenomenonUOM.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.ProgrammeCollection ProgrammeRecords()
		{
			return new SAEON.Observations.Data.ProgrammeCollection().Where(Programme.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.ProjectCollection ProjectRecords()
		{
			return new SAEON.Observations.Data.ProjectCollection().Where(Project.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.ProjectStationCollection ProjectStationRecords()
		{
			return new SAEON.Observations.Data.ProjectStationCollection().Where(ProjectStation.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.ProjectSiteCollection ProjectSiteRecords()
		{
			return new SAEON.Observations.Data.ProjectSiteCollection().Where(ProjectSite.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.SchemaColumnCollection SchemaColumnRecords()
		{
			return new SAEON.Observations.Data.SchemaColumnCollection().Where(SchemaColumn.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.SchemaColumnTypeCollection SchemaColumnTypeRecords()
		{
			return new SAEON.Observations.Data.SchemaColumnTypeCollection().Where(SchemaColumnType.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.SensorCollection SensorRecords()
		{
			return new SAEON.Observations.Data.SensorCollection().Where(Sensor.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.SiteCollection SiteRecords()
		{
			return new SAEON.Observations.Data.SiteCollection().Where(Site.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.StationCollection StationRecords()
		{
			return new SAEON.Observations.Data.StationCollection().Where(Station.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.StationInstrumentCollection StationInstrumentRecords()
		{
			return new SAEON.Observations.Data.StationInstrumentCollection().Where(StationInstrument.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.StatusCollection StatusRecords()
		{
			return new SAEON.Observations.Data.StatusCollection().Where(Status.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.StatusReasonCollection StatusReasonRecords()
		{
			return new SAEON.Observations.Data.StatusReasonCollection().Where(StatusReason.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.TransformationTypeCollection TransformationTypeRecords()
		{
			return new SAEON.Observations.Data.TransformationTypeCollection().Where(TransformationType.Columns.UserId, UserId).Load();
		}
		public SAEON.Observations.Data.UnitOfMeasureCollection UnitOfMeasureRecords()
		{
			return new SAEON.Observations.Data.UnitOfMeasureCollection().Where(UnitOfMeasure.Columns.UserId, UserId).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AspnetApplication ActiveRecord object related to this AspnetUser
		/// 
		/// </summary>
		public SAEON.Observations.Data.AspnetApplication AspnetApplication
		{
			get { return SAEON.Observations.Data.AspnetApplication.FetchByID(this.ApplicationId); }
			set { SetColumnValue("ApplicationId", value.ApplicationId); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public SAEON.Observations.Data.AspnetRoleCollection GetAspnetRoleCollection() { return AspnetUser.GetAspnetRoleCollection(this.UserId); }
		public static SAEON.Observations.Data.AspnetRoleCollection GetAspnetRoleCollection(Guid varUserId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[aspnet_Roles] INNER JOIN [aspnet_UsersInRoles] ON [aspnet_Roles].[RoleId] = [aspnet_UsersInRoles].[RoleId] WHERE [aspnet_UsersInRoles].[UserId] = @UserId", AspnetUser.Schema.Provider.Name);
			cmd.AddParameter("@UserId", varUserId, DbType.Guid);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AspnetRoleCollection coll = new AspnetRoleCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAspnetRoleMap(Guid varUserId, AspnetRoleCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [aspnet_UsersInRoles] WHERE [aspnet_UsersInRoles].[UserId] = @UserId", AspnetUser.Schema.Provider.Name);
			cmdDel.AddParameter("@UserId", varUserId, DbType.Guid);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (AspnetRole item in items)
			{
				AspnetUsersInRole varAspnetUsersInRole = new AspnetUsersInRole();
				varAspnetUsersInRole.SetColumnValue("UserId", varUserId);
				varAspnetUsersInRole.SetColumnValue("RoleId", item.GetPrimaryKeyValue());
				varAspnetUsersInRole.Save();
			}
		}
		public static void SaveAspnetRoleMap(Guid varUserId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [aspnet_UsersInRoles] WHERE [aspnet_UsersInRoles].[UserId] = @UserId", AspnetUser.Schema.Provider.Name);
			cmdDel.AddParameter("@UserId", varUserId, DbType.Guid);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					AspnetUsersInRole varAspnetUsersInRole = new AspnetUsersInRole();
					varAspnetUsersInRole.SetColumnValue("UserId", varUserId);
					varAspnetUsersInRole.SetColumnValue("RoleId", l.Value);
					varAspnetUsersInRole.Save();
				}
			}
		}
		public static void SaveAspnetRoleMap(Guid varUserId , Guid[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [aspnet_UsersInRoles] WHERE [aspnet_UsersInRoles].[UserId] = @UserId", AspnetUser.Schema.Provider.Name);
			cmdDel.AddParameter("@UserId", varUserId, DbType.Guid);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Guid item in itemList) 
			{
				AspnetUsersInRole varAspnetUsersInRole = new AspnetUsersInRole();
				varAspnetUsersInRole.SetColumnValue("UserId", varUserId);
				varAspnetUsersInRole.SetColumnValue("RoleId", item);
				varAspnetUsersInRole.Save();
			}
		}
		
		public static void DeleteAspnetRoleMap(Guid varUserId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [aspnet_UsersInRoles] WHERE [aspnet_UsersInRoles].[UserId] = @UserId", AspnetUser.Schema.Provider.Name);
			cmdDel.AddParameter("@UserId", varUserId, DbType.Guid);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varApplicationId,Guid varUserId,string varUserName,string varLoweredUserName,string varMobileAlias,bool varIsAnonymous,DateTime varLastActivityDate)
		{
			AspnetUser item = new AspnetUser();
			
			item.ApplicationId = varApplicationId;
			
			item.UserId = varUserId;
			
			item.UserName = varUserName;
			
			item.LoweredUserName = varLoweredUserName;
			
			item.MobileAlias = varMobileAlias;
			
			item.IsAnonymous = varIsAnonymous;
			
			item.LastActivityDate = varLastActivityDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varApplicationId,Guid varUserId,string varUserName,string varLoweredUserName,string varMobileAlias,bool varIsAnonymous,DateTime varLastActivityDate)
		{
			AspnetUser item = new AspnetUser();
			
				item.ApplicationId = varApplicationId;
			
				item.UserId = varUserId;
			
				item.UserName = varUserName;
			
				item.LoweredUserName = varLoweredUserName;
			
				item.MobileAlias = varMobileAlias;
			
				item.IsAnonymous = varIsAnonymous;
			
				item.LastActivityDate = varLastActivityDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ApplicationIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UserNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LoweredUserNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MobileAliasColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsAnonymousColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn LastActivityDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ApplicationId = @"ApplicationId";
			 public static string UserId = @"UserId";
			 public static string UserName = @"UserName";
			 public static string LoweredUserName = @"LoweredUserName";
			 public static string MobileAlias = @"MobileAlias";
			 public static string IsAnonymous = @"IsAnonymous";
			 public static string LastActivityDate = @"LastActivityDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
