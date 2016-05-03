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
namespace SAEON.ObservationsDB.Data{
    /// <summary>
    /// Strongly-typed collection for the VSensor class.
    /// </summary>
    [Serializable]
    public partial class VSensorCollection : ReadOnlyList<VSensor, VSensorCollection>
    {        
        public VSensorCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vSensor view.
    /// </summary>
    [Serializable]
    public partial class VSensor : ReadOnlyRecord<VSensor>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vSensor", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Guid;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
                colvarCode.ColumnName = "Code";
                colvarCode.DataType = DbType.AnsiString;
                colvarCode.MaxLength = 50;
                colvarCode.AutoIncrement = false;
                colvarCode.IsNullable = false;
                colvarCode.IsPrimaryKey = false;
                colvarCode.IsForeignKey = false;
                colvarCode.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarUrl);
                
                TableSchema.TableColumn colvarStationID = new TableSchema.TableColumn(schema);
                colvarStationID.ColumnName = "StationID";
                colvarStationID.DataType = DbType.Guid;
                colvarStationID.MaxLength = 0;
                colvarStationID.AutoIncrement = false;
                colvarStationID.IsNullable = false;
                colvarStationID.IsPrimaryKey = false;
                colvarStationID.IsForeignKey = false;
                colvarStationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationID);
                
                TableSchema.TableColumn colvarDataSourceID = new TableSchema.TableColumn(schema);
                colvarDataSourceID.ColumnName = "DataSourceID";
                colvarDataSourceID.DataType = DbType.Guid;
                colvarDataSourceID.MaxLength = 0;
                colvarDataSourceID.AutoIncrement = false;
                colvarDataSourceID.IsNullable = true;
                colvarDataSourceID.IsPrimaryKey = false;
                colvarDataSourceID.IsForeignKey = false;
                colvarDataSourceID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSourceID);
                
                TableSchema.TableColumn colvarPhenomenonID = new TableSchema.TableColumn(schema);
                colvarPhenomenonID.ColumnName = "PhenomenonID";
                colvarPhenomenonID.DataType = DbType.Guid;
                colvarPhenomenonID.MaxLength = 0;
                colvarPhenomenonID.AutoIncrement = false;
                colvarPhenomenonID.IsNullable = false;
                colvarPhenomenonID.IsPrimaryKey = false;
                colvarPhenomenonID.IsForeignKey = false;
                colvarPhenomenonID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonID);
                
                TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
                colvarUserId.ColumnName = "UserId";
                colvarUserId.DataType = DbType.Guid;
                colvarUserId.MaxLength = 0;
                colvarUserId.AutoIncrement = false;
                colvarUserId.IsNullable = false;
                colvarUserId.IsPrimaryKey = false;
                colvarUserId.IsForeignKey = false;
                colvarUserId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserId);
                
                TableSchema.TableColumn colvarStationName = new TableSchema.TableColumn(schema);
                colvarStationName.ColumnName = "StationName";
                colvarStationName.DataType = DbType.AnsiString;
                colvarStationName.MaxLength = 150;
                colvarStationName.AutoIncrement = false;
                colvarStationName.IsNullable = false;
                colvarStationName.IsPrimaryKey = false;
                colvarStationName.IsForeignKey = false;
                colvarStationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationName);
                
                TableSchema.TableColumn colvarDataSourceName = new TableSchema.TableColumn(schema);
                colvarDataSourceName.ColumnName = "DataSourceName";
                colvarDataSourceName.DataType = DbType.AnsiString;
                colvarDataSourceName.MaxLength = 150;
                colvarDataSourceName.AutoIncrement = false;
                colvarDataSourceName.IsNullable = false;
                colvarDataSourceName.IsPrimaryKey = false;
                colvarDataSourceName.IsForeignKey = false;
                colvarDataSourceName.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSourceName);
                
                TableSchema.TableColumn colvarDataSchemaName = new TableSchema.TableColumn(schema);
                colvarDataSchemaName.ColumnName = "DataSchemaName";
                colvarDataSchemaName.DataType = DbType.AnsiString;
                colvarDataSchemaName.MaxLength = 5000;
                colvarDataSchemaName.AutoIncrement = false;
                colvarDataSchemaName.IsNullable = true;
                colvarDataSchemaName.IsPrimaryKey = false;
                colvarDataSchemaName.IsForeignKey = false;
                colvarDataSchemaName.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSchemaName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vSensor",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public VSensor()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSensor(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VSensor(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VSensor(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public Guid Id 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("Code")]
        [Bindable(true)]
        public string Code 
	    {
		    get
		    {
			    return GetColumnValue<string>("Code");
		    }
            set 
		    {
			    SetColumnValue("Code", value);
            }
        }
	      
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name");
		    }
            set 
		    {
			    SetColumnValue("Name", value);
            }
        }
	      
        [XmlAttribute("Description")]
        [Bindable(true)]
        public string Description 
	    {
		    get
		    {
			    return GetColumnValue<string>("Description");
		    }
            set 
		    {
			    SetColumnValue("Description", value);
            }
        }
	      
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url 
	    {
		    get
		    {
			    return GetColumnValue<string>("Url");
		    }
            set 
		    {
			    SetColumnValue("Url", value);
            }
        }
	      
        [XmlAttribute("StationID")]
        [Bindable(true)]
        public Guid StationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("StationID");
		    }
            set 
		    {
			    SetColumnValue("StationID", value);
            }
        }
	      
        [XmlAttribute("DataSourceID")]
        [Bindable(true)]
        public Guid? DataSourceID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("DataSourceID");
		    }
            set 
		    {
			    SetColumnValue("DataSourceID", value);
            }
        }
	      
        [XmlAttribute("PhenomenonID")]
        [Bindable(true)]
        public Guid PhenomenonID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonID", value);
            }
        }
	      
        [XmlAttribute("UserId")]
        [Bindable(true)]
        public Guid UserId 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("UserId");
		    }
            set 
		    {
			    SetColumnValue("UserId", value);
            }
        }
	      
        [XmlAttribute("StationName")]
        [Bindable(true)]
        public string StationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationName");
		    }
            set 
		    {
			    SetColumnValue("StationName", value);
            }
        }
	      
        [XmlAttribute("DataSourceName")]
        [Bindable(true)]
        public string DataSourceName 
	    {
		    get
		    {
			    return GetColumnValue<string>("DataSourceName");
		    }
            set 
		    {
			    SetColumnValue("DataSourceName", value);
            }
        }
	      
        [XmlAttribute("DataSchemaName")]
        [Bindable(true)]
        public string DataSchemaName 
	    {
		    get
		    {
			    return GetColumnValue<string>("DataSchemaName");
		    }
            set 
		    {
			    SetColumnValue("DataSchemaName", value);
            }
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
            
            public static string StationID = @"StationID";
            
            public static string DataSourceID = @"DataSourceID";
            
            public static string PhenomenonID = @"PhenomenonID";
            
            public static string UserId = @"UserId";
            
            public static string StationName = @"StationName";
            
            public static string DataSourceName = @"DataSourceName";
            
            public static string DataSchemaName = @"DataSchemaName";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
