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
	/// Strongly-typed collection for the StationOrganisation class.
	/// </summary>
    [Serializable]
	public partial class StationOrganisationCollection : ActiveList<StationOrganisation, StationOrganisationCollection>
	{	   
		public StationOrganisationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>StationOrganisationCollection</returns>
		public StationOrganisationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                StationOrganisation o = this[i];
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
	/// This is an ActiveRecord class which wraps the Station_Organisation table.
	/// </summary>
	[Serializable]
	public partial class StationOrganisation : ActiveRecord<StationOrganisation>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public StationOrganisation()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public StationOrganisation(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public StationOrganisation(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public StationOrganisation(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Station_Organisation", TableType.Table, DataService.GetInstance("ObservationsDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Guid;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				
						colvarId.DefaultSetting = @"(newid())";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarStationID = new TableSchema.TableColumn(schema);
				colvarStationID.ColumnName = "StationID";
				colvarStationID.DataType = DbType.Guid;
				colvarStationID.MaxLength = 0;
				colvarStationID.AutoIncrement = false;
				colvarStationID.IsNullable = false;
				colvarStationID.IsPrimaryKey = false;
				colvarStationID.IsForeignKey = false;
				colvarStationID.IsReadOnly = false;
				colvarStationID.DefaultSetting = @"";
				colvarStationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStationID);
				
				TableSchema.TableColumn colvarOrganisationID = new TableSchema.TableColumn(schema);
				colvarOrganisationID.ColumnName = "OrganisationID";
				colvarOrganisationID.DataType = DbType.Guid;
				colvarOrganisationID.MaxLength = 0;
				colvarOrganisationID.AutoIncrement = false;
				colvarOrganisationID.IsNullable = false;
				colvarOrganisationID.IsPrimaryKey = false;
				colvarOrganisationID.IsForeignKey = true;
				colvarOrganisationID.IsReadOnly = false;
				colvarOrganisationID.DefaultSetting = @"";
				
					colvarOrganisationID.ForeignKeyTableName = "Organisation";
				schema.Columns.Add(colvarOrganisationID);
				
				TableSchema.TableColumn colvarOrganisationRoleID = new TableSchema.TableColumn(schema);
				colvarOrganisationRoleID.ColumnName = "OrganisationRoleID";
				colvarOrganisationRoleID.DataType = DbType.Guid;
				colvarOrganisationRoleID.MaxLength = 0;
				colvarOrganisationRoleID.AutoIncrement = false;
				colvarOrganisationRoleID.IsNullable = false;
				colvarOrganisationRoleID.IsPrimaryKey = false;
				colvarOrganisationRoleID.IsForeignKey = false;
				colvarOrganisationRoleID.IsReadOnly = false;
				colvarOrganisationRoleID.DefaultSetting = @"";
				colvarOrganisationRoleID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrganisationRoleID);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = true;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
				colvarEndDate.ColumnName = "EndDate";
				colvarEndDate.DataType = DbType.DateTime;
				colvarEndDate.MaxLength = 0;
				colvarEndDate.AutoIncrement = false;
				colvarEndDate.IsNullable = true;
				colvarEndDate.IsPrimaryKey = false;
				colvarEndDate.IsForeignKey = false;
				colvarEndDate.IsReadOnly = false;
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = true;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				
					colvarUserId.ForeignKeyTableName = "aspnet_Users";
				schema.Columns.Add(colvarUserId);
				
				TableSchema.TableColumn colvarAddedAt = new TableSchema.TableColumn(schema);
				colvarAddedAt.ColumnName = "AddedAt";
				colvarAddedAt.DataType = DbType.DateTime;
				colvarAddedAt.MaxLength = 0;
				colvarAddedAt.AutoIncrement = false;
				colvarAddedAt.IsNullable = true;
				colvarAddedAt.IsPrimaryKey = false;
				colvarAddedAt.IsForeignKey = false;
				colvarAddedAt.IsReadOnly = false;
				
						colvarAddedAt.DefaultSetting = @"(getdate())";
				colvarAddedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddedAt);
				
				TableSchema.TableColumn colvarUpdatedAt = new TableSchema.TableColumn(schema);
				colvarUpdatedAt.ColumnName = "UpdatedAt";
				colvarUpdatedAt.DataType = DbType.DateTime;
				colvarUpdatedAt.MaxLength = 0;
				colvarUpdatedAt.AutoIncrement = false;
				colvarUpdatedAt.IsNullable = true;
				colvarUpdatedAt.IsPrimaryKey = false;
				colvarUpdatedAt.IsForeignKey = false;
				colvarUpdatedAt.IsReadOnly = false;
				
						colvarUpdatedAt.DefaultSetting = @"(getdate())";
				colvarUpdatedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedAt);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ObservationsDB"].AddSchema("Station_Organisation",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public Guid Id 
		{
			get { return GetColumnValue<Guid>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("StationID")]
		[Bindable(true)]
		public Guid StationID 
		{
			get { return GetColumnValue<Guid>(Columns.StationID); }
			set { SetColumnValue(Columns.StationID, value); }
		}
		  
		[XmlAttribute("OrganisationID")]
		[Bindable(true)]
		public Guid OrganisationID 
		{
			get { return GetColumnValue<Guid>(Columns.OrganisationID); }
			set { SetColumnValue(Columns.OrganisationID, value); }
		}
		  
		[XmlAttribute("OrganisationRoleID")]
		[Bindable(true)]
		public Guid OrganisationRoleID 
		{
			get { return GetColumnValue<Guid>(Columns.OrganisationRoleID); }
			set { SetColumnValue(Columns.OrganisationRoleID, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public DateTime? StartDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("EndDate")]
		[Bindable(true)]
		public DateTime? EndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EndDate); }
			set { SetColumnValue(Columns.EndDate, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid UserId 
		{
			get { return GetColumnValue<Guid>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		  
		[XmlAttribute("AddedAt")]
		[Bindable(true)]
		public DateTime? AddedAt 
		{
			get { return GetColumnValue<DateTime?>(Columns.AddedAt); }
			set { SetColumnValue(Columns.AddedAt, value); }
		}
		  
		[XmlAttribute("UpdatedAt")]
		[Bindable(true)]
		public DateTime? UpdatedAt 
		{
			get { return GetColumnValue<DateTime?>(Columns.UpdatedAt); }
			set { SetColumnValue(Columns.UpdatedAt, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AspnetUser ActiveRecord object related to this StationOrganisation
		/// 
		/// </summary>
		public SAEON.Observations.Data.AspnetUser AspnetUser
		{
			get { return SAEON.Observations.Data.AspnetUser.FetchByID(this.UserId); }
			set { SetColumnValue("UserId", value.UserId); }
		}
		
		
		/// <summary>
		/// Returns a Organisation ActiveRecord object related to this StationOrganisation
		/// 
		/// </summary>
		public SAEON.Observations.Data.Organisation Organisation
		{
			get { return SAEON.Observations.Data.Organisation.FetchByID(this.OrganisationID); }
			set { SetColumnValue("OrganisationID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,Guid varStationID,Guid varOrganisationID,Guid varOrganisationRoleID,DateTime? varStartDate,DateTime? varEndDate,Guid varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt)
		{
			StationOrganisation item = new StationOrganisation();
			
			item.Id = varId;
			
			item.StationID = varStationID;
			
			item.OrganisationID = varOrganisationID;
			
			item.OrganisationRoleID = varOrganisationRoleID;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.UserId = varUserId;
			
			item.AddedAt = varAddedAt;
			
			item.UpdatedAt = varUpdatedAt;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varId,Guid varStationID,Guid varOrganisationID,Guid varOrganisationRoleID,DateTime? varStartDate,DateTime? varEndDate,Guid varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt)
		{
			StationOrganisation item = new StationOrganisation();
			
				item.Id = varId;
			
				item.StationID = varStationID;
			
				item.OrganisationID = varOrganisationID;
			
				item.OrganisationRoleID = varOrganisationRoleID;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.UserId = varUserId;
			
				item.AddedAt = varAddedAt;
			
				item.UpdatedAt = varUpdatedAt;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StationIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OrganisationIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn OrganisationRoleIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EndDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedAtColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string StationID = @"StationID";
			 public static string OrganisationID = @"OrganisationID";
			 public static string OrganisationRoleID = @"OrganisationRoleID";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string UserId = @"UserId";
			 public static string AddedAt = @"AddedAt";
			 public static string UpdatedAt = @"UpdatedAt";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
