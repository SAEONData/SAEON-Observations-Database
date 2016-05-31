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
    /// Strongly-typed collection for the VOrganisationStation class.
    /// </summary>
    [Serializable]
    public partial class VOrganisationStationCollection : ReadOnlyList<VOrganisationStation, VOrganisationStationCollection>
    {        
        public VOrganisationStationCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vOrganisationStation view.
    /// </summary>
    [Serializable]
    public partial class VOrganisationStation : ReadOnlyRecord<VOrganisationStation>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vOrganisationStation", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                colvarStartDate.DataType = DbType.DateTime;
                colvarStartDate.MaxLength = 0;
                colvarStartDate.AutoIncrement = false;
                colvarStartDate.IsNullable = true;
                colvarStartDate.IsPrimaryKey = false;
                colvarStartDate.IsForeignKey = false;
                colvarStartDate.IsReadOnly = false;
                
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
                
                TableSchema.TableColumn colvarStationCode = new TableSchema.TableColumn(schema);
                colvarStationCode.ColumnName = "StationCode";
                colvarStationCode.DataType = DbType.AnsiString;
                colvarStationCode.MaxLength = 50;
                colvarStationCode.AutoIncrement = false;
                colvarStationCode.IsNullable = false;
                colvarStationCode.IsPrimaryKey = false;
                colvarStationCode.IsForeignKey = false;
                colvarStationCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationCode);
                
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
                DataService.Providers["ObservationsDB"].AddSchema("vOrganisationStation",schema);
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
	    public VOrganisationStation()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VOrganisationStation(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VOrganisationStation(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VOrganisationStation(string columnName, object columnValue)
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
	      
        [XmlAttribute("StationCode")]
        [Bindable(true)]
        public string StationCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationCode");
		    }
            set 
		    {
			    SetColumnValue("StationCode", value);
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
            
            public static string StationID = @"StationID";
            
            public static string OrganisationRoleID = @"OrganisationRoleID";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string UserId = @"UserId";
            
            public static string AddedAt = @"AddedAt";
            
            public static string UpdatedAt = @"UpdatedAt";
            
            public static string OrganisationCode = @"OrganisationCode";
            
            public static string OrganisationName = @"OrganisationName";
            
            public static string StationCode = @"StationCode";
            
            public static string StationName = @"StationName";
            
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
