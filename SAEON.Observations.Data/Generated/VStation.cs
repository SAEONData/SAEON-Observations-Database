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
    /// Strongly-typed collection for the VStation class.
    /// </summary>
    [Serializable]
    public partial class VStationCollection : ReadOnlyList<VStation, VStationCollection>
    {        
        public VStationCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vStation view.
    /// </summary>
    [Serializable]
    public partial class VStation : ReadOnlyRecord<VStation>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vStation", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarLatitude = new TableSchema.TableColumn(schema);
                colvarLatitude.ColumnName = "Latitude";
                colvarLatitude.DataType = DbType.Double;
                colvarLatitude.MaxLength = 0;
                colvarLatitude.AutoIncrement = false;
                colvarLatitude.IsNullable = true;
                colvarLatitude.IsPrimaryKey = false;
                colvarLatitude.IsForeignKey = false;
                colvarLatitude.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarLongitude);
                
                TableSchema.TableColumn colvarElevation = new TableSchema.TableColumn(schema);
                colvarElevation.ColumnName = "Elevation";
                colvarElevation.DataType = DbType.Int32;
                colvarElevation.MaxLength = 0;
                colvarElevation.AutoIncrement = false;
                colvarElevation.IsNullable = true;
                colvarElevation.IsPrimaryKey = false;
                colvarElevation.IsForeignKey = false;
                colvarElevation.IsReadOnly = false;
                
                schema.Columns.Add(colvarElevation);
                
                TableSchema.TableColumn colvarProjectSiteID = new TableSchema.TableColumn(schema);
                colvarProjectSiteID.ColumnName = "ProjectSiteID";
                colvarProjectSiteID.DataType = DbType.Guid;
                colvarProjectSiteID.MaxLength = 0;
                colvarProjectSiteID.AutoIncrement = false;
                colvarProjectSiteID.IsNullable = true;
                colvarProjectSiteID.IsPrimaryKey = false;
                colvarProjectSiteID.IsForeignKey = false;
                colvarProjectSiteID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProjectSiteID);
                
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
                
                TableSchema.TableColumn colvarSiteID = new TableSchema.TableColumn(schema);
                colvarSiteID.ColumnName = "SiteID";
                colvarSiteID.DataType = DbType.Guid;
                colvarSiteID.MaxLength = 0;
                colvarSiteID.AutoIncrement = false;
                colvarSiteID.IsNullable = true;
                colvarSiteID.IsPrimaryKey = false;
                colvarSiteID.IsForeignKey = false;
                colvarSiteID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteID);
                
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
                
                TableSchema.TableColumn colvarProjectSiteName = new TableSchema.TableColumn(schema);
                colvarProjectSiteName.ColumnName = "ProjectSiteName";
                colvarProjectSiteName.DataType = DbType.AnsiString;
                colvarProjectSiteName.MaxLength = 203;
                colvarProjectSiteName.AutoIncrement = false;
                colvarProjectSiteName.IsNullable = true;
                colvarProjectSiteName.IsPrimaryKey = false;
                colvarProjectSiteName.IsForeignKey = false;
                colvarProjectSiteName.IsReadOnly = false;
                
                schema.Columns.Add(colvarProjectSiteName);
                
                TableSchema.TableColumn colvarSiteCode = new TableSchema.TableColumn(schema);
                colvarSiteCode.ColumnName = "SiteCode";
                colvarSiteCode.DataType = DbType.AnsiString;
                colvarSiteCode.MaxLength = 50;
                colvarSiteCode.AutoIncrement = false;
                colvarSiteCode.IsNullable = true;
                colvarSiteCode.IsPrimaryKey = false;
                colvarSiteCode.IsForeignKey = false;
                colvarSiteCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteCode);
                
                TableSchema.TableColumn colvarSiteName = new TableSchema.TableColumn(schema);
                colvarSiteName.ColumnName = "SiteName";
                colvarSiteName.DataType = DbType.AnsiString;
                colvarSiteName.MaxLength = 150;
                colvarSiteName.AutoIncrement = false;
                colvarSiteName.IsNullable = true;
                colvarSiteName.IsPrimaryKey = false;
                colvarSiteName.IsForeignKey = false;
                colvarSiteName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vStation",schema);
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
	    public VStation()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VStation(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VStation(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VStation(string columnName, object columnValue)
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
	      
        [XmlAttribute("Latitude")]
        [Bindable(true)]
        public double? Latitude 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Latitude");
		    }
            set 
		    {
			    SetColumnValue("Latitude", value);
            }
        }
	      
        [XmlAttribute("Longitude")]
        [Bindable(true)]
        public double? Longitude 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Longitude");
		    }
            set 
		    {
			    SetColumnValue("Longitude", value);
            }
        }
	      
        [XmlAttribute("Elevation")]
        [Bindable(true)]
        public int? Elevation 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Elevation");
		    }
            set 
		    {
			    SetColumnValue("Elevation", value);
            }
        }
	      
        [XmlAttribute("ProjectSiteID")]
        [Bindable(true)]
        public Guid? ProjectSiteID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("ProjectSiteID");
		    }
            set 
		    {
			    SetColumnValue("ProjectSiteID", value);
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
	      
        [XmlAttribute("SiteID")]
        [Bindable(true)]
        public Guid? SiteID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("SiteID");
		    }
            set 
		    {
			    SetColumnValue("SiteID", value);
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
	      
        [XmlAttribute("ProjectSiteName")]
        [Bindable(true)]
        public string ProjectSiteName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProjectSiteName");
		    }
            set 
		    {
			    SetColumnValue("ProjectSiteName", value);
            }
        }
	      
        [XmlAttribute("SiteCode")]
        [Bindable(true)]
        public string SiteCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteCode");
		    }
            set 
		    {
			    SetColumnValue("SiteCode", value);
            }
        }
	      
        [XmlAttribute("SiteName")]
        [Bindable(true)]
        public string SiteName 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteName");
		    }
            set 
		    {
			    SetColumnValue("SiteName", value);
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
            
            public static string Latitude = @"Latitude";
            
            public static string Longitude = @"Longitude";
            
            public static string Elevation = @"Elevation";
            
            public static string ProjectSiteID = @"ProjectSiteID";
            
            public static string UserId = @"UserId";
            
            public static string SiteID = @"SiteID";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string AddedAt = @"AddedAt";
            
            public static string UpdatedAt = @"UpdatedAt";
            
            public static string ProjectSiteName = @"ProjectSiteName";
            
            public static string SiteCode = @"SiteCode";
            
            public static string SiteName = @"SiteName";
            
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
