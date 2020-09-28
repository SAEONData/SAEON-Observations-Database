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
	/// Strongly-typed collection for the PhenomenonUOM class.
	/// </summary>
    [Serializable]
	public partial class PhenomenonUOMCollection : ActiveList<PhenomenonUOM, PhenomenonUOMCollection>
	{	   
		public PhenomenonUOMCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PhenomenonUOMCollection</returns>
		public PhenomenonUOMCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PhenomenonUOM o = this[i];
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
	/// This is an ActiveRecord class which wraps the PhenomenonUOM table.
	/// </summary>
	[Serializable]
	public partial class PhenomenonUOM : ActiveRecord<PhenomenonUOM>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PhenomenonUOM()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PhenomenonUOM(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PhenomenonUOM(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PhenomenonUOM(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PhenomenonUOM", TableType.Table, DataService.GetInstance("ObservationsDB"));
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
				
				TableSchema.TableColumn colvarPhenomenonID = new TableSchema.TableColumn(schema);
				colvarPhenomenonID.ColumnName = "PhenomenonID";
				colvarPhenomenonID.DataType = DbType.Guid;
				colvarPhenomenonID.MaxLength = 0;
				colvarPhenomenonID.AutoIncrement = false;
				colvarPhenomenonID.IsNullable = false;
				colvarPhenomenonID.IsPrimaryKey = false;
				colvarPhenomenonID.IsForeignKey = true;
				colvarPhenomenonID.IsReadOnly = false;
				colvarPhenomenonID.DefaultSetting = @"";
				
					colvarPhenomenonID.ForeignKeyTableName = "Phenomenon";
				schema.Columns.Add(colvarPhenomenonID);
				
				TableSchema.TableColumn colvarUnitOfMeasureID = new TableSchema.TableColumn(schema);
				colvarUnitOfMeasureID.ColumnName = "UnitOfMeasureID";
				colvarUnitOfMeasureID.DataType = DbType.Guid;
				colvarUnitOfMeasureID.MaxLength = 0;
				colvarUnitOfMeasureID.AutoIncrement = false;
				colvarUnitOfMeasureID.IsNullable = false;
				colvarUnitOfMeasureID.IsPrimaryKey = false;
				colvarUnitOfMeasureID.IsForeignKey = true;
				colvarUnitOfMeasureID.IsReadOnly = false;
				colvarUnitOfMeasureID.DefaultSetting = @"";
				
					colvarUnitOfMeasureID.ForeignKeyTableName = "UnitOfMeasure";
				schema.Columns.Add(colvarUnitOfMeasureID);
				
				TableSchema.TableColumn colvarIsDefault = new TableSchema.TableColumn(schema);
				colvarIsDefault.ColumnName = "IsDefault";
				colvarIsDefault.DataType = DbType.Boolean;
				colvarIsDefault.MaxLength = 0;
				colvarIsDefault.AutoIncrement = false;
				colvarIsDefault.IsNullable = false;
				colvarIsDefault.IsPrimaryKey = false;
				colvarIsDefault.IsForeignKey = false;
				colvarIsDefault.IsReadOnly = false;
				
						colvarIsDefault.DefaultSetting = @"((0))";
				colvarIsDefault.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDefault);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = true;
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
				
				TableSchema.TableColumn colvarRowVersion = new TableSchema.TableColumn(schema);
				colvarRowVersion.ColumnName = "RowVersion";
				colvarRowVersion.DataType = DbType.Binary;
				colvarRowVersion.MaxLength = 0;
				colvarRowVersion.AutoIncrement = false;
				colvarRowVersion.IsNullable = false;
				colvarRowVersion.IsPrimaryKey = false;
				colvarRowVersion.IsForeignKey = false;
				colvarRowVersion.IsReadOnly = true;
				colvarRowVersion.DefaultSetting = @"";
				colvarRowVersion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRowVersion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ObservationsDB"].AddSchema("PhenomenonUOM",schema);
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
		  
		[XmlAttribute("PhenomenonID")]
		[Bindable(true)]
		public Guid PhenomenonID 
		{
			get { return GetColumnValue<Guid>(Columns.PhenomenonID); }
			set { SetColumnValue(Columns.PhenomenonID, value); }
		}
		  
		[XmlAttribute("UnitOfMeasureID")]
		[Bindable(true)]
		public Guid UnitOfMeasureID 
		{
			get { return GetColumnValue<Guid>(Columns.UnitOfMeasureID); }
			set { SetColumnValue(Columns.UnitOfMeasureID, value); }
		}
		  
		[XmlAttribute("IsDefault")]
		[Bindable(true)]
		public bool IsDefault 
		{
			get { return GetColumnValue<bool>(Columns.IsDefault); }
			set { SetColumnValue(Columns.IsDefault, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid? UserId 
		{
			get { return GetColumnValue<Guid?>(Columns.UserId); }
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
		  
		[XmlAttribute("RowVersion")]
		[Bindable(true)]
		public byte[] RowVersion 
		{
			get { return GetColumnValue<byte[]>(Columns.RowVersion); }
			set { SetColumnValue(Columns.RowVersion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public SAEON.Observations.Data.DataLogCollection DataLogRecords()
		{
			return new SAEON.Observations.Data.DataLogCollection().Where(DataLog.Columns.PhenomenonUOMID, Id).Load();
		}
		public SAEON.Observations.Data.DataSourceTransformationCollection DataSourceTransformationRecords()
		{
			return new SAEON.Observations.Data.DataSourceTransformationCollection().Where(DataSourceTransformation.Columns.NewPhenomenonUOMID, Id).Load();
		}
		public SAEON.Observations.Data.DataSourceTransformationCollection DataSourceTransformationRecordsFromPhenomenonUOM()
		{
			return new SAEON.Observations.Data.DataSourceTransformationCollection().Where(DataSourceTransformation.Columns.PhenomenonUOMID, Id).Load();
		}
		public SAEON.Observations.Data.ImportBatchSummaryCollection ImportBatchSummaryRecords()
		{
			return new SAEON.Observations.Data.ImportBatchSummaryCollection().Where(ImportBatchSummary.Columns.PhenomenonUOMID, Id).Load();
		}
		public SAEON.Observations.Data.ObservationCollection ObservationRecords()
		{
			return new SAEON.Observations.Data.ObservationCollection().Where(Observation.Columns.PhenomenonUOMID, Id).Load();
		}
		public SAEON.Observations.Data.SchemaColumnCollection SchemaColumnRecords()
		{
			return new SAEON.Observations.Data.SchemaColumnCollection().Where(SchemaColumn.Columns.PhenomenonUOMID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
        private SAEON.Observations.Data.AspnetUser _AspnetUser = null;
		/// <summary>
		/// Returns a AspnetUser ActiveRecord object related to this PhenomenonUOM
		/// 
		/// </summary>
		public SAEON.Observations.Data.AspnetUser AspnetUser
		{
//			get { return SAEON.Observations.Data.AspnetUser.FetchByID(this.UserId); }  
			get { return _AspnetUser ?? (_AspnetUser = SAEON.Observations.Data.AspnetUser.FetchByID(this.UserId)); }
			set { SetColumnValue("UserId", value.UserId); }
		}
		
		
        private SAEON.Observations.Data.Phenomenon _Phenomenon = null;
		/// <summary>
		/// Returns a Phenomenon ActiveRecord object related to this PhenomenonUOM
		/// 
		/// </summary>
		public SAEON.Observations.Data.Phenomenon Phenomenon
		{
//			get { return SAEON.Observations.Data.Phenomenon.FetchByID(this.PhenomenonID); }  
			get { return _Phenomenon ?? (_Phenomenon = SAEON.Observations.Data.Phenomenon.FetchByID(this.PhenomenonID)); }
			set { SetColumnValue("PhenomenonID", value.Id); }
		}
		
		
        private SAEON.Observations.Data.UnitOfMeasure _UnitOfMeasure = null;
		/// <summary>
		/// Returns a UnitOfMeasure ActiveRecord object related to this PhenomenonUOM
		/// 
		/// </summary>
		public SAEON.Observations.Data.UnitOfMeasure UnitOfMeasure
		{
//			get { return SAEON.Observations.Data.UnitOfMeasure.FetchByID(this.UnitOfMeasureID); }  
			get { return _UnitOfMeasure ?? (_UnitOfMeasure = SAEON.Observations.Data.UnitOfMeasure.FetchByID(this.UnitOfMeasureID)); }
			set { SetColumnValue("UnitOfMeasureID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,Guid varPhenomenonID,Guid varUnitOfMeasureID,bool varIsDefault,Guid? varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt,byte[] varRowVersion)
		{
			PhenomenonUOM item = new PhenomenonUOM();
			
			item.Id = varId;
			
			item.PhenomenonID = varPhenomenonID;
			
			item.UnitOfMeasureID = varUnitOfMeasureID;
			
			item.IsDefault = varIsDefault;
			
			item.UserId = varUserId;
			
			item.AddedAt = varAddedAt;
			
			item.UpdatedAt = varUpdatedAt;
			
			item.RowVersion = varRowVersion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varId,Guid varPhenomenonID,Guid varUnitOfMeasureID,bool varIsDefault,Guid? varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt,byte[] varRowVersion)
		{
			PhenomenonUOM item = new PhenomenonUOM();
			
				item.Id = varId;
			
				item.PhenomenonID = varPhenomenonID;
			
				item.UnitOfMeasureID = varUnitOfMeasureID;
			
				item.IsDefault = varIsDefault;
			
				item.UserId = varUserId;
			
				item.AddedAt = varAddedAt;
			
				item.UpdatedAt = varUpdatedAt;
			
				item.RowVersion = varRowVersion;
			
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
        
        
        
        public static TableSchema.TableColumn PhenomenonIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UnitOfMeasureIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDefaultColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedAtColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn RowVersionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string PhenomenonID = @"PhenomenonID";
			 public static string UnitOfMeasureID = @"UnitOfMeasureID";
			 public static string IsDefault = @"IsDefault";
			 public static string UserId = @"UserId";
			 public static string AddedAt = @"AddedAt";
			 public static string UpdatedAt = @"UpdatedAt";
			 public static string RowVersion = @"RowVersion";
						
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
