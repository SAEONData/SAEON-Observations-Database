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
	/// Strongly-typed collection for the Sensor class.
	/// </summary>
    [Serializable]
	public partial class SensorCollection : ActiveList<Sensor, SensorCollection>
	{	   
		public SensorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SensorCollection</returns>
		public SensorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sensor o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sensor table.
	/// </summary>
	[Serializable]
	public partial class Sensor : ActiveRecord<Sensor>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Sensor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Sensor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Sensor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Sensor(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sensor", TableType.Table, DataService.GetInstance("ObservationsDB"));
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
				
				TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
				colvarCode.ColumnName = "Code";
				colvarCode.DataType = DbType.AnsiString;
				colvarCode.MaxLength = 75;
				colvarCode.AutoIncrement = false;
				colvarCode.IsNullable = false;
				colvarCode.IsPrimaryKey = false;
				colvarCode.IsForeignKey = false;
				colvarCode.IsReadOnly = false;
				colvarCode.DefaultSetting = @"";
				colvarCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCode);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 150;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 5000;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "Url";
				colvarUrl.DataType = DbType.AnsiString;
				colvarUrl.MaxLength = 250;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = true;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
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
				
				TableSchema.TableColumn colvarDataSourceID = new TableSchema.TableColumn(schema);
				colvarDataSourceID.ColumnName = "DataSourceID";
				colvarDataSourceID.DataType = DbType.Guid;
				colvarDataSourceID.MaxLength = 0;
				colvarDataSourceID.AutoIncrement = false;
				colvarDataSourceID.IsNullable = false;
				colvarDataSourceID.IsPrimaryKey = false;
				colvarDataSourceID.IsForeignKey = true;
				colvarDataSourceID.IsReadOnly = false;
				colvarDataSourceID.DefaultSetting = @"";
				
					colvarDataSourceID.ForeignKeyTableName = "DataSource";
				schema.Columns.Add(colvarDataSourceID);
				
				TableSchema.TableColumn colvarDataSchemaID = new TableSchema.TableColumn(schema);
				colvarDataSchemaID.ColumnName = "DataSchemaID";
				colvarDataSchemaID.DataType = DbType.Guid;
				colvarDataSchemaID.MaxLength = 0;
				colvarDataSchemaID.AutoIncrement = false;
				colvarDataSchemaID.IsNullable = true;
				colvarDataSchemaID.IsPrimaryKey = false;
				colvarDataSchemaID.IsForeignKey = true;
				colvarDataSchemaID.IsReadOnly = false;
				colvarDataSchemaID.DefaultSetting = @"";
				
					colvarDataSchemaID.ForeignKeyTableName = "DataSchema";
				schema.Columns.Add(colvarDataSchemaID);
				
				TableSchema.TableColumn colvarLatitude = new TableSchema.TableColumn(schema);
				colvarLatitude.ColumnName = "Latitude";
				colvarLatitude.DataType = DbType.Double;
				colvarLatitude.MaxLength = 0;
				colvarLatitude.AutoIncrement = false;
				colvarLatitude.IsNullable = true;
				colvarLatitude.IsPrimaryKey = false;
				colvarLatitude.IsForeignKey = false;
				colvarLatitude.IsReadOnly = false;
				colvarLatitude.DefaultSetting = @"";
				colvarLatitude.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLatitude);
				
				TableSchema.TableColumn colvarLongitude = new TableSchema.TableColumn(schema);
				colvarLongitude.ColumnName = "Longitude";
				colvarLongitude.DataType = DbType.Double;
				colvarLongitude.MaxLength = 0;
				colvarLongitude.AutoIncrement = false;
				colvarLongitude.IsNullable = true;
				colvarLongitude.IsPrimaryKey = false;
				colvarLongitude.IsForeignKey = false;
				colvarLongitude.IsReadOnly = false;
				colvarLongitude.DefaultSetting = @"";
				colvarLongitude.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLongitude);
				
				TableSchema.TableColumn colvarElevation = new TableSchema.TableColumn(schema);
				colvarElevation.ColumnName = "Elevation";
				colvarElevation.DataType = DbType.Double;
				colvarElevation.MaxLength = 0;
				colvarElevation.AutoIncrement = false;
				colvarElevation.IsNullable = true;
				colvarElevation.IsPrimaryKey = false;
				colvarElevation.IsForeignKey = false;
				colvarElevation.IsReadOnly = false;
				colvarElevation.DefaultSetting = @"";
				colvarElevation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarElevation);
				
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
				DataService.Providers["ObservationsDB"].AddSchema("Sensor",schema);
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
		  
		[XmlAttribute("Code")]
		[Bindable(true)]
		public string Code 
		{
			get { return GetColumnValue<string>(Columns.Code); }
			set { SetColumnValue(Columns.Code, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("PhenomenonID")]
		[Bindable(true)]
		public Guid PhenomenonID 
		{
			get { return GetColumnValue<Guid>(Columns.PhenomenonID); }
			set { SetColumnValue(Columns.PhenomenonID, value); }
		}
		  
		[XmlAttribute("DataSourceID")]
		[Bindable(true)]
		public Guid DataSourceID 
		{
			get { return GetColumnValue<Guid>(Columns.DataSourceID); }
			set { SetColumnValue(Columns.DataSourceID, value); }
		}
		  
		[XmlAttribute("DataSchemaID")]
		[Bindable(true)]
		public Guid? DataSchemaID 
		{
			get { return GetColumnValue<Guid?>(Columns.DataSchemaID); }
			set { SetColumnValue(Columns.DataSchemaID, value); }
		}
		  
		[XmlAttribute("Latitude")]
		[Bindable(true)]
		public double? Latitude 
		{
			get { return GetColumnValue<double?>(Columns.Latitude); }
			set { SetColumnValue(Columns.Latitude, value); }
		}
		  
		[XmlAttribute("Longitude")]
		[Bindable(true)]
		public double? Longitude 
		{
			get { return GetColumnValue<double?>(Columns.Longitude); }
			set { SetColumnValue(Columns.Longitude, value); }
		}
		  
		[XmlAttribute("Elevation")]
		[Bindable(true)]
		public double? Elevation 
		{
			get { return GetColumnValue<double?>(Columns.Elevation); }
			set { SetColumnValue(Columns.Elevation, value); }
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
			return new SAEON.Observations.Data.DataLogCollection().Where(DataLog.Columns.SensorID, Id).Load();
		}
		public SAEON.Observations.Data.DataSourceTransformationCollection DataSourceTransformationRecords()
		{
			return new SAEON.Observations.Data.DataSourceTransformationCollection().Where(DataSourceTransformation.Columns.SensorID, Id).Load();
		}
		public SAEON.Observations.Data.ImportBatchSummaryCollection ImportBatchSummaryRecords()
		{
			return new SAEON.Observations.Data.ImportBatchSummaryCollection().Where(ImportBatchSummary.Columns.SensorID, Id).Load();
		}
		public SAEON.Observations.Data.InstrumentSensorCollection InstrumentSensorRecords()
		{
			return new SAEON.Observations.Data.InstrumentSensorCollection().Where(InstrumentSensor.Columns.SensorID, Id).Load();
		}
		public SAEON.Observations.Data.ObservationCollection ObservationRecords()
		{
			return new SAEON.Observations.Data.ObservationCollection().Where(Observation.Columns.SensorID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
        private SAEON.Observations.Data.AspnetUser _AspnetUser = null;
		/// <summary>
		/// Returns a AspnetUser ActiveRecord object related to this Sensor
		/// 
		/// </summary>
		public SAEON.Observations.Data.AspnetUser AspnetUser
		{
//			get { return SAEON.Observations.Data.AspnetUser.FetchByID(this.UserId); }  
			get { return _AspnetUser ?? (_AspnetUser = SAEON.Observations.Data.AspnetUser.FetchByID(this.UserId)); }
			set { SetColumnValue("UserId", value.UserId); }
		}
		
		
        private SAEON.Observations.Data.DataSchema _DataSchema = null;
		/// <summary>
		/// Returns a DataSchema ActiveRecord object related to this Sensor
		/// 
		/// </summary>
		public SAEON.Observations.Data.DataSchema DataSchema
		{
//			get { return SAEON.Observations.Data.DataSchema.FetchByID(this.DataSchemaID); }  
			get { return _DataSchema ?? (_DataSchema = SAEON.Observations.Data.DataSchema.FetchByID(this.DataSchemaID)); }
			set { SetColumnValue("DataSchemaID", value.Id); }
		}
		
		
        private SAEON.Observations.Data.DataSource _DataSource = null;
		/// <summary>
		/// Returns a DataSource ActiveRecord object related to this Sensor
		/// 
		/// </summary>
		public SAEON.Observations.Data.DataSource DataSource
		{
//			get { return SAEON.Observations.Data.DataSource.FetchByID(this.DataSourceID); }  
			get { return _DataSource ?? (_DataSource = SAEON.Observations.Data.DataSource.FetchByID(this.DataSourceID)); }
			set { SetColumnValue("DataSourceID", value.Id); }
		}
		
		
        private SAEON.Observations.Data.Phenomenon _Phenomenon = null;
		/// <summary>
		/// Returns a Phenomenon ActiveRecord object related to this Sensor
		/// 
		/// </summary>
		public SAEON.Observations.Data.Phenomenon Phenomenon
		{
//			get { return SAEON.Observations.Data.Phenomenon.FetchByID(this.PhenomenonID); }  
			get { return _Phenomenon ?? (_Phenomenon = SAEON.Observations.Data.Phenomenon.FetchByID(this.PhenomenonID)); }
			set { SetColumnValue("PhenomenonID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,string varCode,string varName,string varDescription,string varUrl,Guid varPhenomenonID,Guid varDataSourceID,Guid? varDataSchemaID,double? varLatitude,double? varLongitude,double? varElevation,Guid varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt,byte[] varRowVersion)
		{
			Sensor item = new Sensor();
			
			item.Id = varId;
			
			item.Code = varCode;
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.Url = varUrl;
			
			item.PhenomenonID = varPhenomenonID;
			
			item.DataSourceID = varDataSourceID;
			
			item.DataSchemaID = varDataSchemaID;
			
			item.Latitude = varLatitude;
			
			item.Longitude = varLongitude;
			
			item.Elevation = varElevation;
			
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
		public static void Update(Guid varId,string varCode,string varName,string varDescription,string varUrl,Guid varPhenomenonID,Guid varDataSourceID,Guid? varDataSchemaID,double? varLatitude,double? varLongitude,double? varElevation,Guid varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt,byte[] varRowVersion)
		{
			Sensor item = new Sensor();
			
				item.Id = varId;
			
				item.Code = varCode;
			
				item.Name = varName;
			
				item.Description = varDescription;
			
				item.Url = varUrl;
			
				item.PhenomenonID = varPhenomenonID;
			
				item.DataSourceID = varDataSourceID;
			
				item.DataSchemaID = varDataSchemaID;
			
				item.Latitude = varLatitude;
			
				item.Longitude = varLongitude;
			
				item.Elevation = varElevation;
			
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
        
        
        
        public static TableSchema.TableColumn CodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PhenomenonIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DataSourceIDColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DataSchemaIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn LatitudeColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LongitudeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ElevationColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedAtColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn RowVersionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Code = @"Code";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string Url = @"Url";
			 public static string PhenomenonID = @"PhenomenonID";
			 public static string DataSourceID = @"DataSourceID";
			 public static string DataSchemaID = @"DataSchemaID";
			 public static string Latitude = @"Latitude";
			 public static string Longitude = @"Longitude";
			 public static string Elevation = @"Elevation";
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
