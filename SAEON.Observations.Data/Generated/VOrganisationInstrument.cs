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
    /// Strongly-typed collection for the VOrganisationInstrument class.
    /// </summary>
    [Serializable]
    public partial class VOrganisationInstrumentCollection : ReadOnlyList<VOrganisationInstrument, VOrganisationInstrumentCollection>
    {        
        public VOrganisationInstrumentCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vOrganisationInstrument view.
    /// </summary>
    [Serializable]
    public partial class VOrganisationInstrument : ReadOnlyRecord<VOrganisationInstrument>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vOrganisationInstrument", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarOrganisationID = new TableSchema.TableColumn(schema);
                colvarOrganisationID.ColumnName = "OrganisationID";
                colvarOrganisationID.DataType = DbType.Guid;
                colvarOrganisationID.MaxLength = 0;
                colvarOrganisationID.AutoIncrement = false;
                colvarOrganisationID.IsNullable = false;
                colvarOrganisationID.IsPrimaryKey = false;
                colvarOrganisationID.IsForeignKey = false;
                colvarOrganisationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationID);
                
                TableSchema.TableColumn colvarInstrumentID = new TableSchema.TableColumn(schema);
                colvarInstrumentID.ColumnName = "InstrumentID";
                colvarInstrumentID.DataType = DbType.Guid;
                colvarInstrumentID.MaxLength = 0;
                colvarInstrumentID.AutoIncrement = false;
                colvarInstrumentID.IsNullable = false;
                colvarInstrumentID.IsPrimaryKey = false;
                colvarInstrumentID.IsForeignKey = false;
                colvarInstrumentID.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentID);
                
                TableSchema.TableColumn colvarOrganisationRoleID = new TableSchema.TableColumn(schema);
                colvarOrganisationRoleID.ColumnName = "OrganisationRoleID";
                colvarOrganisationRoleID.DataType = DbType.Guid;
                colvarOrganisationRoleID.MaxLength = 0;
                colvarOrganisationRoleID.AutoIncrement = false;
                colvarOrganisationRoleID.IsNullable = false;
                colvarOrganisationRoleID.IsPrimaryKey = false;
                colvarOrganisationRoleID.IsForeignKey = false;
                colvarOrganisationRoleID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationRoleID);
                
                TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
                colvarStartDate.ColumnName = "StartDate";
                colvarStartDate.DataType = DbType.Date;
                colvarStartDate.MaxLength = 0;
                colvarStartDate.AutoIncrement = false;
                colvarStartDate.IsNullable = true;
                colvarStartDate.IsPrimaryKey = false;
                colvarStartDate.IsForeignKey = false;
                colvarStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStartDate);
                
                TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
                colvarEndDate.ColumnName = "EndDate";
                colvarEndDate.DataType = DbType.Date;
                colvarEndDate.MaxLength = 0;
                colvarEndDate.AutoIncrement = false;
                colvarEndDate.IsNullable = true;
                colvarEndDate.IsPrimaryKey = false;
                colvarEndDate.IsForeignKey = false;
                colvarEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEndDate);
                
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
                
                TableSchema.TableColumn colvarOrganisationCode = new TableSchema.TableColumn(schema);
                colvarOrganisationCode.ColumnName = "OrganisationCode";
                colvarOrganisationCode.DataType = DbType.AnsiString;
                colvarOrganisationCode.MaxLength = 50;
                colvarOrganisationCode.AutoIncrement = false;
                colvarOrganisationCode.IsNullable = false;
                colvarOrganisationCode.IsPrimaryKey = false;
                colvarOrganisationCode.IsForeignKey = false;
                colvarOrganisationCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationCode);
                
                TableSchema.TableColumn colvarOrganisationName = new TableSchema.TableColumn(schema);
                colvarOrganisationName.ColumnName = "OrganisationName";
                colvarOrganisationName.DataType = DbType.AnsiString;
                colvarOrganisationName.MaxLength = 150;
                colvarOrganisationName.AutoIncrement = false;
                colvarOrganisationName.IsNullable = false;
                colvarOrganisationName.IsPrimaryKey = false;
                colvarOrganisationName.IsForeignKey = false;
                colvarOrganisationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationName);
                
                TableSchema.TableColumn colvarInstrumentCode = new TableSchema.TableColumn(schema);
                colvarInstrumentCode.ColumnName = "InstrumentCode";
                colvarInstrumentCode.DataType = DbType.AnsiString;
                colvarInstrumentCode.MaxLength = 50;
                colvarInstrumentCode.AutoIncrement = false;
                colvarInstrumentCode.IsNullable = false;
                colvarInstrumentCode.IsPrimaryKey = false;
                colvarInstrumentCode.IsForeignKey = false;
                colvarInstrumentCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentCode);
                
                TableSchema.TableColumn colvarInstrumentName = new TableSchema.TableColumn(schema);
                colvarInstrumentName.ColumnName = "InstrumentName";
                colvarInstrumentName.DataType = DbType.AnsiString;
                colvarInstrumentName.MaxLength = 150;
                colvarInstrumentName.AutoIncrement = false;
                colvarInstrumentName.IsNullable = false;
                colvarInstrumentName.IsPrimaryKey = false;
                colvarInstrumentName.IsForeignKey = false;
                colvarInstrumentName.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentName);
                
                TableSchema.TableColumn colvarOrganisationRoleCode = new TableSchema.TableColumn(schema);
                colvarOrganisationRoleCode.ColumnName = "OrganisationRoleCode";
                colvarOrganisationRoleCode.DataType = DbType.AnsiString;
                colvarOrganisationRoleCode.MaxLength = 50;
                colvarOrganisationRoleCode.AutoIncrement = false;
                colvarOrganisationRoleCode.IsNullable = false;
                colvarOrganisationRoleCode.IsPrimaryKey = false;
                colvarOrganisationRoleCode.IsForeignKey = false;
                colvarOrganisationRoleCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationRoleCode);
                
                TableSchema.TableColumn colvarOrganisationRoleName = new TableSchema.TableColumn(schema);
                colvarOrganisationRoleName.ColumnName = "OrganisationRoleName";
                colvarOrganisationRoleName.DataType = DbType.AnsiString;
                colvarOrganisationRoleName.MaxLength = 150;
                colvarOrganisationRoleName.AutoIncrement = false;
                colvarOrganisationRoleName.IsNullable = false;
                colvarOrganisationRoleName.IsPrimaryKey = false;
                colvarOrganisationRoleName.IsForeignKey = false;
                colvarOrganisationRoleName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationRoleName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vOrganisationInstrument",schema);
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
	    public VOrganisationInstrument()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VOrganisationInstrument(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VOrganisationInstrument(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VOrganisationInstrument(string columnName, object columnValue)
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
	      
        [XmlAttribute("OrganisationID")]
        [Bindable(true)]
        public Guid OrganisationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("OrganisationID");
		    }
            set 
		    {
			    SetColumnValue("OrganisationID", value);
            }
        }
	      
        [XmlAttribute("InstrumentID")]
        [Bindable(true)]
        public Guid InstrumentID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("InstrumentID");
		    }
            set 
		    {
			    SetColumnValue("InstrumentID", value);
            }
        }
	      
        [XmlAttribute("OrganisationRoleID")]
        [Bindable(true)]
        public Guid OrganisationRoleID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("OrganisationRoleID");
		    }
            set 
		    {
			    SetColumnValue("OrganisationRoleID", value);
            }
        }
	      
        [XmlAttribute("StartDate")]
        [Bindable(true)]
        public DateTime? StartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StartDate");
		    }
            set 
		    {
			    SetColumnValue("StartDate", value);
            }
        }
	      
        [XmlAttribute("EndDate")]
        [Bindable(true)]
        public DateTime? EndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("EndDate");
		    }
            set 
		    {
			    SetColumnValue("EndDate", value);
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
	      
        [XmlAttribute("OrganisationCode")]
        [Bindable(true)]
        public string OrganisationCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("OrganisationCode");
		    }
            set 
		    {
			    SetColumnValue("OrganisationCode", value);
            }
        }
	      
        [XmlAttribute("OrganisationName")]
        [Bindable(true)]
        public string OrganisationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OrganisationName");
		    }
            set 
		    {
			    SetColumnValue("OrganisationName", value);
            }
        }
	      
        [XmlAttribute("InstrumentCode")]
        [Bindable(true)]
        public string InstrumentCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("InstrumentCode");
		    }
            set 
		    {
			    SetColumnValue("InstrumentCode", value);
            }
        }
	      
        [XmlAttribute("InstrumentName")]
        [Bindable(true)]
        public string InstrumentName 
	    {
		    get
		    {
			    return GetColumnValue<string>("InstrumentName");
		    }
            set 
		    {
			    SetColumnValue("InstrumentName", value);
            }
        }
	      
        [XmlAttribute("OrganisationRoleCode")]
        [Bindable(true)]
        public string OrganisationRoleCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("OrganisationRoleCode");
		    }
            set 
		    {
			    SetColumnValue("OrganisationRoleCode", value);
            }
        }
	      
        [XmlAttribute("OrganisationRoleName")]
        [Bindable(true)]
        public string OrganisationRoleName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OrganisationRoleName");
		    }
            set 
		    {
			    SetColumnValue("OrganisationRoleName", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string OrganisationID = @"OrganisationID";
            
            public static string InstrumentID = @"InstrumentID";
            
            public static string OrganisationRoleID = @"OrganisationRoleID";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string UserId = @"UserId";
            
            public static string AddedAt = @"AddedAt";
            
            public static string UpdatedAt = @"UpdatedAt";
            
            public static string OrganisationCode = @"OrganisationCode";
            
            public static string OrganisationName = @"OrganisationName";
            
            public static string InstrumentCode = @"InstrumentCode";
            
            public static string InstrumentName = @"InstrumentName";
            
            public static string OrganisationRoleCode = @"OrganisationRoleCode";
            
            public static string OrganisationRoleName = @"OrganisationRoleName";
            
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
