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
namespace SAEON.Observations.Data{
    /// <summary>
    /// Strongly-typed collection for the VSchemaColumn class.
    /// </summary>
    [Serializable]
    public partial class VSchemaColumnCollection : ReadOnlyList<VSchemaColumn, VSchemaColumnCollection>
    {        
        public VSchemaColumnCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vSchemaColumn view.
    /// </summary>
    [Serializable]
    public partial class VSchemaColumn : ReadOnlyRecord<VSchemaColumn>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vSchemaColumn", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarDataSchemaID = new TableSchema.TableColumn(schema);
                colvarDataSchemaID.ColumnName = "DataSchemaID";
                colvarDataSchemaID.DataType = DbType.Guid;
                colvarDataSchemaID.MaxLength = 0;
                colvarDataSchemaID.AutoIncrement = false;
                colvarDataSchemaID.IsNullable = false;
                colvarDataSchemaID.IsPrimaryKey = false;
                colvarDataSchemaID.IsForeignKey = false;
                colvarDataSchemaID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSchemaID);
                
                TableSchema.TableColumn colvarNumber = new TableSchema.TableColumn(schema);
                colvarNumber.ColumnName = "Number";
                colvarNumber.DataType = DbType.Int32;
                colvarNumber.MaxLength = 0;
                colvarNumber.AutoIncrement = false;
                colvarNumber.IsNullable = false;
                colvarNumber.IsPrimaryKey = false;
                colvarNumber.IsForeignKey = false;
                colvarNumber.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumber);
                
                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.AnsiString;
                colvarName.MaxLength = 100;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                
                schema.Columns.Add(colvarName);
                
                TableSchema.TableColumn colvarSchemaColumnTypeID = new TableSchema.TableColumn(schema);
                colvarSchemaColumnTypeID.ColumnName = "SchemaColumnTypeID";
                colvarSchemaColumnTypeID.DataType = DbType.Guid;
                colvarSchemaColumnTypeID.MaxLength = 0;
                colvarSchemaColumnTypeID.AutoIncrement = false;
                colvarSchemaColumnTypeID.IsNullable = false;
                colvarSchemaColumnTypeID.IsPrimaryKey = false;
                colvarSchemaColumnTypeID.IsForeignKey = false;
                colvarSchemaColumnTypeID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSchemaColumnTypeID);
                
                TableSchema.TableColumn colvarWidth = new TableSchema.TableColumn(schema);
                colvarWidth.ColumnName = "Width";
                colvarWidth.DataType = DbType.Int32;
                colvarWidth.MaxLength = 0;
                colvarWidth.AutoIncrement = false;
                colvarWidth.IsNullable = true;
                colvarWidth.IsPrimaryKey = false;
                colvarWidth.IsForeignKey = false;
                colvarWidth.IsReadOnly = false;
                
                schema.Columns.Add(colvarWidth);
                
                TableSchema.TableColumn colvarFormat = new TableSchema.TableColumn(schema);
                colvarFormat.ColumnName = "Format";
                colvarFormat.DataType = DbType.AnsiString;
                colvarFormat.MaxLength = 50;
                colvarFormat.AutoIncrement = false;
                colvarFormat.IsNullable = true;
                colvarFormat.IsPrimaryKey = false;
                colvarFormat.IsForeignKey = false;
                colvarFormat.IsReadOnly = false;
                
                schema.Columns.Add(colvarFormat);
                
                TableSchema.TableColumn colvarPhenomenonID = new TableSchema.TableColumn(schema);
                colvarPhenomenonID.ColumnName = "PhenomenonID";
                colvarPhenomenonID.DataType = DbType.Guid;
                colvarPhenomenonID.MaxLength = 0;
                colvarPhenomenonID.AutoIncrement = false;
                colvarPhenomenonID.IsNullable = true;
                colvarPhenomenonID.IsPrimaryKey = false;
                colvarPhenomenonID.IsForeignKey = false;
                colvarPhenomenonID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonID);
                
                TableSchema.TableColumn colvarPhenomenonOfferingID = new TableSchema.TableColumn(schema);
                colvarPhenomenonOfferingID.ColumnName = "PhenomenonOfferingID";
                colvarPhenomenonOfferingID.DataType = DbType.Guid;
                colvarPhenomenonOfferingID.MaxLength = 0;
                colvarPhenomenonOfferingID.AutoIncrement = false;
                colvarPhenomenonOfferingID.IsNullable = true;
                colvarPhenomenonOfferingID.IsPrimaryKey = false;
                colvarPhenomenonOfferingID.IsForeignKey = false;
                colvarPhenomenonOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonOfferingID);
                
                TableSchema.TableColumn colvarPhenomenonUOMID = new TableSchema.TableColumn(schema);
                colvarPhenomenonUOMID.ColumnName = "PhenomenonUOMID";
                colvarPhenomenonUOMID.DataType = DbType.Guid;
                colvarPhenomenonUOMID.MaxLength = 0;
                colvarPhenomenonUOMID.AutoIncrement = false;
                colvarPhenomenonUOMID.IsNullable = true;
                colvarPhenomenonUOMID.IsPrimaryKey = false;
                colvarPhenomenonUOMID.IsForeignKey = false;
                colvarPhenomenonUOMID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonUOMID);
                
                TableSchema.TableColumn colvarFixedTime = new TableSchema.TableColumn(schema);
                colvarFixedTime.ColumnName = "FixedTime";
                colvarFixedTime.DataType = DbType.Int32;
                colvarFixedTime.MaxLength = 0;
                colvarFixedTime.AutoIncrement = false;
                colvarFixedTime.IsNullable = true;
                colvarFixedTime.IsPrimaryKey = false;
                colvarFixedTime.IsForeignKey = false;
                colvarFixedTime.IsReadOnly = false;
                
                schema.Columns.Add(colvarFixedTime);
                
                TableSchema.TableColumn colvarEmptyValue = new TableSchema.TableColumn(schema);
                colvarEmptyValue.ColumnName = "EmptyValue";
                colvarEmptyValue.DataType = DbType.AnsiString;
                colvarEmptyValue.MaxLength = 50;
                colvarEmptyValue.AutoIncrement = false;
                colvarEmptyValue.IsNullable = true;
                colvarEmptyValue.IsPrimaryKey = false;
                colvarEmptyValue.IsForeignKey = false;
                colvarEmptyValue.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmptyValue);
                
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
                
                TableSchema.TableColumn colvarAddedAt = new TableSchema.TableColumn(schema);
                colvarAddedAt.ColumnName = "AddedAt";
                colvarAddedAt.DataType = DbType.DateTime;
                colvarAddedAt.MaxLength = 0;
                colvarAddedAt.AutoIncrement = false;
                colvarAddedAt.IsNullable = true;
                colvarAddedAt.IsPrimaryKey = false;
                colvarAddedAt.IsForeignKey = false;
                colvarAddedAt.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarUpdatedAt);
                
                TableSchema.TableColumn colvarColumnTypeName = new TableSchema.TableColumn(schema);
                colvarColumnTypeName.ColumnName = "ColumnTypeName";
                colvarColumnTypeName.DataType = DbType.AnsiString;
                colvarColumnTypeName.MaxLength = 50;
                colvarColumnTypeName.AutoIncrement = false;
                colvarColumnTypeName.IsNullable = false;
                colvarColumnTypeName.IsPrimaryKey = false;
                colvarColumnTypeName.IsForeignKey = false;
                colvarColumnTypeName.IsReadOnly = false;
                
                schema.Columns.Add(colvarColumnTypeName);
                
                TableSchema.TableColumn colvarPhenomenonName = new TableSchema.TableColumn(schema);
                colvarPhenomenonName.ColumnName = "PhenomenonName";
                colvarPhenomenonName.DataType = DbType.AnsiString;
                colvarPhenomenonName.MaxLength = 150;
                colvarPhenomenonName.AutoIncrement = false;
                colvarPhenomenonName.IsNullable = true;
                colvarPhenomenonName.IsPrimaryKey = false;
                colvarPhenomenonName.IsForeignKey = false;
                colvarPhenomenonName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonName);
                
                TableSchema.TableColumn colvarPhenomenonOfferingName = new TableSchema.TableColumn(schema);
                colvarPhenomenonOfferingName.ColumnName = "PhenomenonOfferingName";
                colvarPhenomenonOfferingName.DataType = DbType.AnsiString;
                colvarPhenomenonOfferingName.MaxLength = 150;
                colvarPhenomenonOfferingName.AutoIncrement = false;
                colvarPhenomenonOfferingName.IsNullable = true;
                colvarPhenomenonOfferingName.IsPrimaryKey = false;
                colvarPhenomenonOfferingName.IsForeignKey = false;
                colvarPhenomenonOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonOfferingName);
                
                TableSchema.TableColumn colvarPhenomenonUOMUnit = new TableSchema.TableColumn(schema);
                colvarPhenomenonUOMUnit.ColumnName = "PhenomenonUOMUnit";
                colvarPhenomenonUOMUnit.DataType = DbType.AnsiString;
                colvarPhenomenonUOMUnit.MaxLength = 100;
                colvarPhenomenonUOMUnit.AutoIncrement = false;
                colvarPhenomenonUOMUnit.IsNullable = true;
                colvarPhenomenonUOMUnit.IsPrimaryKey = false;
                colvarPhenomenonUOMUnit.IsForeignKey = false;
                colvarPhenomenonUOMUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonUOMUnit);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vSchemaColumn",schema);
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
	    public VSchemaColumn()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSchemaColumn(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VSchemaColumn(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VSchemaColumn(string columnName, object columnValue)
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
	      
        [XmlAttribute("DataSchemaID")]
        [Bindable(true)]
        public Guid DataSchemaID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("DataSchemaID");
		    }
            set 
		    {
			    SetColumnValue("DataSchemaID", value);
            }
        }
	      
        [XmlAttribute("Number")]
        [Bindable(true)]
        public int Number 
	    {
		    get
		    {
			    return GetColumnValue<int>("Number");
		    }
            set 
		    {
			    SetColumnValue("Number", value);
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
	      
        [XmlAttribute("SchemaColumnTypeID")]
        [Bindable(true)]
        public Guid SchemaColumnTypeID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SchemaColumnTypeID");
		    }
            set 
		    {
			    SetColumnValue("SchemaColumnTypeID", value);
            }
        }
	      
        [XmlAttribute("Width")]
        [Bindable(true)]
        public int? Width 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Width");
		    }
            set 
		    {
			    SetColumnValue("Width", value);
            }
        }
	      
        [XmlAttribute("Format")]
        [Bindable(true)]
        public string Format 
	    {
		    get
		    {
			    return GetColumnValue<string>("Format");
		    }
            set 
		    {
			    SetColumnValue("Format", value);
            }
        }
	      
        [XmlAttribute("PhenomenonID")]
        [Bindable(true)]
        public Guid? PhenomenonID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("PhenomenonID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonID", value);
            }
        }
	      
        [XmlAttribute("PhenomenonOfferingID")]
        [Bindable(true)]
        public Guid? PhenomenonOfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("PhenomenonOfferingID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonOfferingID", value);
            }
        }
	      
        [XmlAttribute("PhenomenonUOMID")]
        [Bindable(true)]
        public Guid? PhenomenonUOMID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("PhenomenonUOMID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonUOMID", value);
            }
        }
	      
        [XmlAttribute("FixedTime")]
        [Bindable(true)]
        public int? FixedTime 
	    {
		    get
		    {
			    return GetColumnValue<int?>("FixedTime");
		    }
            set 
		    {
			    SetColumnValue("FixedTime", value);
            }
        }
	      
        [XmlAttribute("EmptyValue")]
        [Bindable(true)]
        public string EmptyValue 
	    {
		    get
		    {
			    return GetColumnValue<string>("EmptyValue");
		    }
            set 
		    {
			    SetColumnValue("EmptyValue", value);
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
	      
        [XmlAttribute("AddedAt")]
        [Bindable(true)]
        public DateTime? AddedAt 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("AddedAt");
		    }
            set 
		    {
			    SetColumnValue("AddedAt", value);
            }
        }
	      
        [XmlAttribute("UpdatedAt")]
        [Bindable(true)]
        public DateTime? UpdatedAt 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("UpdatedAt");
		    }
            set 
		    {
			    SetColumnValue("UpdatedAt", value);
            }
        }
	      
        [XmlAttribute("ColumnTypeName")]
        [Bindable(true)]
        public string ColumnTypeName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ColumnTypeName");
		    }
            set 
		    {
			    SetColumnValue("ColumnTypeName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonName")]
        [Bindable(true)]
        public string PhenomenonName 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonName");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonOfferingName")]
        [Bindable(true)]
        public string PhenomenonOfferingName 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonOfferingName");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonOfferingName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonUOMUnit")]
        [Bindable(true)]
        public string PhenomenonUOMUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonUOMUnit");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonUOMUnit", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string DataSchemaID = @"DataSchemaID";
            
            public static string Number = @"Number";
            
            public static string Name = @"Name";
            
            public static string SchemaColumnTypeID = @"SchemaColumnTypeID";
            
            public static string Width = @"Width";
            
            public static string Format = @"Format";
            
            public static string PhenomenonID = @"PhenomenonID";
            
            public static string PhenomenonOfferingID = @"PhenomenonOfferingID";
            
            public static string PhenomenonUOMID = @"PhenomenonUOMID";
            
            public static string FixedTime = @"FixedTime";
            
            public static string EmptyValue = @"EmptyValue";
            
            public static string UserId = @"UserId";
            
            public static string AddedAt = @"AddedAt";
            
            public static string UpdatedAt = @"UpdatedAt";
            
            public static string ColumnTypeName = @"ColumnTypeName";
            
            public static string PhenomenonName = @"PhenomenonName";
            
            public static string PhenomenonOfferingName = @"PhenomenonOfferingName";
            
            public static string PhenomenonUOMUnit = @"PhenomenonUOMUnit";
            
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
