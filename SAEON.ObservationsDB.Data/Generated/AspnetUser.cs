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
        
		
		public SAEON.ObservationsDB.Data.PhenomenonCollection PhenomenonRecords()
		{
			return new SAEON.ObservationsDB.Data.PhenomenonCollection().Where(Phenomenon.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.ImportBatchCollection ImportBatchRecords()
		{
			return new SAEON.ObservationsDB.Data.ImportBatchCollection().Where(ImportBatch.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.OfferingCollection OfferingRecords()
		{
			return new SAEON.ObservationsDB.Data.OfferingCollection().Where(Offering.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.OrganisationCollection OrganisationRecords()
		{
			return new SAEON.ObservationsDB.Data.OrganisationCollection().Where(Organisation.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.OrganisationRoleCollection OrganisationRoleRecords()
		{
			return new SAEON.ObservationsDB.Data.OrganisationRoleCollection().Where(OrganisationRole.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.UnitOfMeasureCollection UnitOfMeasureRecords()
		{
			return new SAEON.ObservationsDB.Data.UnitOfMeasureCollection().Where(UnitOfMeasure.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.SiteCollection SiteRecords()
		{
			return new SAEON.ObservationsDB.Data.SiteCollection().Where(Site.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.DataSourceTransformationCollection DataSourceTransformationRecords()
		{
			return new SAEON.ObservationsDB.Data.DataSourceTransformationCollection().Where(DataSourceTransformation.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.SiteOrganisationCollection SiteOrganisationRecords()
		{
			return new SAEON.ObservationsDB.Data.SiteOrganisationCollection().Where(SiteOrganisation.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.StationOrganisationCollection StationOrganisationRecords()
		{
			return new SAEON.ObservationsDB.Data.StationOrganisationCollection().Where(StationOrganisation.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.DataSourceRoleCollection DataSourceRoleRecords()
		{
			return new SAEON.ObservationsDB.Data.DataSourceRoleCollection().Where(DataSourceRole.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.DataSourceTypeCollection DataSourceTypeRecords()
		{
			return new SAEON.ObservationsDB.Data.DataSourceTypeCollection().Where(DataSourceType.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.PhenomenonOfferingCollection PhenomenonOfferingRecords()
		{
			return new SAEON.ObservationsDB.Data.PhenomenonOfferingCollection().Where(PhenomenonOffering.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.PhenomenonUOMCollection PhenomenonUOMRecords()
		{
			return new SAEON.ObservationsDB.Data.PhenomenonUOMCollection().Where(PhenomenonUOM.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.StatusCollection StatusRecords()
		{
			return new SAEON.ObservationsDB.Data.StatusCollection().Where(Status.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.TransformationTypeCollection TransformationTypeRecords()
		{
			return new SAEON.ObservationsDB.Data.TransformationTypeCollection().Where(TransformationType.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.StationCollection StationRecords()
		{
			return new SAEON.ObservationsDB.Data.StationCollection().Where(Station.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.AspnetMembershipCollection AspnetMembershipRecords()
		{
			return new SAEON.ObservationsDB.Data.AspnetMembershipCollection().Where(AspnetMembership.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.ProjectSiteCollection ProjectSiteRecords()
		{
			return new SAEON.ObservationsDB.Data.ProjectSiteCollection().Where(ProjectSite.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.AspnetProfileCollection AspnetProfileRecords()
		{
			return new SAEON.ObservationsDB.Data.AspnetProfileCollection().Where(AspnetProfile.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.AspnetUsersInRoleCollection AspnetUsersInRoles()
		{
			return new SAEON.ObservationsDB.Data.AspnetUsersInRoleCollection().Where(AspnetUsersInRole.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.DataLogCollection DataLogRecords()
		{
			return new SAEON.ObservationsDB.Data.DataLogCollection().Where(DataLog.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.AuditLogCollection AuditLogRecords()
		{
			return new SAEON.ObservationsDB.Data.AuditLogCollection().Where(AuditLog.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.DataSourceCollection DataSourceRecords()
		{
			return new SAEON.ObservationsDB.Data.DataSourceCollection().Where(DataSource.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.SensorCollection SensorRecords()
		{
			return new SAEON.ObservationsDB.Data.SensorCollection().Where(Sensor.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.ObservationCollection ObservationRecords()
		{
			return new SAEON.ObservationsDB.Data.ObservationCollection().Where(Observation.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.DataSourceOrganisationCollection DataSourceOrganisationRecords()
		{
			return new SAEON.ObservationsDB.Data.DataSourceOrganisationCollection().Where(DataSourceOrganisation.Columns.UserId, UserId).Load();
		}
		public SAEON.ObservationsDB.Data.AspnetPersonalizationPerUserCollection AspnetPersonalizationPerUserRecords()
		{
			return new SAEON.ObservationsDB.Data.AspnetPersonalizationPerUserCollection().Where(AspnetPersonalizationPerUser.Columns.UserId, UserId).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AspnetApplication ActiveRecord object related to this AspnetUser
		/// 
		/// </summary>
		public SAEON.ObservationsDB.Data.AspnetApplication AspnetApplication
		{
			get { return SAEON.ObservationsDB.Data.AspnetApplication.FetchByID(this.ApplicationId); }
			set { SetColumnValue("ApplicationId", value.ApplicationId); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public SAEON.ObservationsDB.Data.AspnetRoleCollection GetAspnetRoleCollection() { return AspnetUser.GetAspnetRoleCollection(this.UserId); }
		public static SAEON.ObservationsDB.Data.AspnetRoleCollection GetAspnetRoleCollection(Guid varUserId)
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
