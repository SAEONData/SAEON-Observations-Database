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
    /// Strongly-typed collection for the VInventoryDataStream class.
    /// </summary>
    [Serializable]
    public partial class VInventoryDataStreamCollection : ReadOnlyList<VInventoryDataStream, VInventoryDataStreamCollection>
    {        
        public VInventoryDataStreamCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vInventoryDataStreams view.
    /// </summary>
    [Serializable]
    public partial class VInventoryDataStream : ReadOnlyRecord<VInventoryDataStream>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vInventoryDataStreams", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Int64;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = true;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarSiteID = new TableSchema.TableColumn(schema);
                colvarSiteID.ColumnName = "SiteID";
                colvarSiteID.DataType = DbType.Guid;
                colvarSiteID.MaxLength = 0;
                colvarSiteID.AutoIncrement = false;
                colvarSiteID.IsNullable = false;
                colvarSiteID.IsPrimaryKey = false;
                colvarSiteID.IsForeignKey = false;
                colvarSiteID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteID);
                
                TableSchema.TableColumn colvarSiteCode = new TableSchema.TableColumn(schema);
                colvarSiteCode.ColumnName = "SiteCode";
                colvarSiteCode.DataType = DbType.AnsiString;
                colvarSiteCode.MaxLength = 50;
                colvarSiteCode.AutoIncrement = false;
                colvarSiteCode.IsNullable = false;
                colvarSiteCode.IsPrimaryKey = false;
                colvarSiteCode.IsForeignKey = false;
                colvarSiteCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteCode);
                
                TableSchema.TableColumn colvarSiteName = new TableSchema.TableColumn(schema);
                colvarSiteName.ColumnName = "SiteName";
                colvarSiteName.DataType = DbType.AnsiString;
                colvarSiteName.MaxLength = 150;
                colvarSiteName.AutoIncrement = false;
                colvarSiteName.IsNullable = false;
                colvarSiteName.IsPrimaryKey = false;
                colvarSiteName.IsForeignKey = false;
                colvarSiteName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteName);
                
                TableSchema.TableColumn colvarSiteDescription = new TableSchema.TableColumn(schema);
                colvarSiteDescription.ColumnName = "SiteDescription";
                colvarSiteDescription.DataType = DbType.AnsiString;
                colvarSiteDescription.MaxLength = 5000;
                colvarSiteDescription.AutoIncrement = false;
                colvarSiteDescription.IsNullable = true;
                colvarSiteDescription.IsPrimaryKey = false;
                colvarSiteDescription.IsForeignKey = false;
                colvarSiteDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteDescription);
                
                TableSchema.TableColumn colvarSiteUrl = new TableSchema.TableColumn(schema);
                colvarSiteUrl.ColumnName = "SiteUrl";
                colvarSiteUrl.DataType = DbType.AnsiString;
                colvarSiteUrl.MaxLength = 250;
                colvarSiteUrl.AutoIncrement = false;
                colvarSiteUrl.IsNullable = true;
                colvarSiteUrl.IsPrimaryKey = false;
                colvarSiteUrl.IsForeignKey = false;
                colvarSiteUrl.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteUrl);
                
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
                
                TableSchema.TableColumn colvarStationDescription = new TableSchema.TableColumn(schema);
                colvarStationDescription.ColumnName = "StationDescription";
                colvarStationDescription.DataType = DbType.AnsiString;
                colvarStationDescription.MaxLength = 5000;
                colvarStationDescription.AutoIncrement = false;
                colvarStationDescription.IsNullable = true;
                colvarStationDescription.IsPrimaryKey = false;
                colvarStationDescription.IsForeignKey = false;
                colvarStationDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationDescription);
                
                TableSchema.TableColumn colvarStationUrl = new TableSchema.TableColumn(schema);
                colvarStationUrl.ColumnName = "StationUrl";
                colvarStationUrl.DataType = DbType.AnsiString;
                colvarStationUrl.MaxLength = 250;
                colvarStationUrl.AutoIncrement = false;
                colvarStationUrl.IsNullable = true;
                colvarStationUrl.IsPrimaryKey = false;
                colvarStationUrl.IsForeignKey = false;
                colvarStationUrl.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationUrl);
                
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
                
                TableSchema.TableColumn colvarPhenomenonCode = new TableSchema.TableColumn(schema);
                colvarPhenomenonCode.ColumnName = "PhenomenonCode";
                colvarPhenomenonCode.DataType = DbType.AnsiString;
                colvarPhenomenonCode.MaxLength = 50;
                colvarPhenomenonCode.AutoIncrement = false;
                colvarPhenomenonCode.IsNullable = false;
                colvarPhenomenonCode.IsPrimaryKey = false;
                colvarPhenomenonCode.IsForeignKey = false;
                colvarPhenomenonCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonCode);
                
                TableSchema.TableColumn colvarPhenomenonName = new TableSchema.TableColumn(schema);
                colvarPhenomenonName.ColumnName = "PhenomenonName";
                colvarPhenomenonName.DataType = DbType.AnsiString;
                colvarPhenomenonName.MaxLength = 150;
                colvarPhenomenonName.AutoIncrement = false;
                colvarPhenomenonName.IsNullable = false;
                colvarPhenomenonName.IsPrimaryKey = false;
                colvarPhenomenonName.IsForeignKey = false;
                colvarPhenomenonName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonName);
                
                TableSchema.TableColumn colvarPhenomenonDescription = new TableSchema.TableColumn(schema);
                colvarPhenomenonDescription.ColumnName = "PhenomenonDescription";
                colvarPhenomenonDescription.DataType = DbType.AnsiString;
                colvarPhenomenonDescription.MaxLength = 5000;
                colvarPhenomenonDescription.AutoIncrement = false;
                colvarPhenomenonDescription.IsNullable = true;
                colvarPhenomenonDescription.IsPrimaryKey = false;
                colvarPhenomenonDescription.IsForeignKey = false;
                colvarPhenomenonDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonDescription);
                
                TableSchema.TableColumn colvarPhenomenonUrl = new TableSchema.TableColumn(schema);
                colvarPhenomenonUrl.ColumnName = "PhenomenonUrl";
                colvarPhenomenonUrl.DataType = DbType.AnsiString;
                colvarPhenomenonUrl.MaxLength = 250;
                colvarPhenomenonUrl.AutoIncrement = false;
                colvarPhenomenonUrl.IsNullable = true;
                colvarPhenomenonUrl.IsPrimaryKey = false;
                colvarPhenomenonUrl.IsForeignKey = false;
                colvarPhenomenonUrl.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonUrl);
                
                TableSchema.TableColumn colvarPhenomenonOfferingID = new TableSchema.TableColumn(schema);
                colvarPhenomenonOfferingID.ColumnName = "PhenomenonOfferingID";
                colvarPhenomenonOfferingID.DataType = DbType.Guid;
                colvarPhenomenonOfferingID.MaxLength = 0;
                colvarPhenomenonOfferingID.AutoIncrement = false;
                colvarPhenomenonOfferingID.IsNullable = false;
                colvarPhenomenonOfferingID.IsPrimaryKey = false;
                colvarPhenomenonOfferingID.IsForeignKey = false;
                colvarPhenomenonOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonOfferingID);
                
                TableSchema.TableColumn colvarOfferingID = new TableSchema.TableColumn(schema);
                colvarOfferingID.ColumnName = "OfferingID";
                colvarOfferingID.DataType = DbType.Guid;
                colvarOfferingID.MaxLength = 0;
                colvarOfferingID.AutoIncrement = false;
                colvarOfferingID.IsNullable = false;
                colvarOfferingID.IsPrimaryKey = false;
                colvarOfferingID.IsForeignKey = false;
                colvarOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingID);
                
                TableSchema.TableColumn colvarOfferingCode = new TableSchema.TableColumn(schema);
                colvarOfferingCode.ColumnName = "OfferingCode";
                colvarOfferingCode.DataType = DbType.AnsiString;
                colvarOfferingCode.MaxLength = 50;
                colvarOfferingCode.AutoIncrement = false;
                colvarOfferingCode.IsNullable = false;
                colvarOfferingCode.IsPrimaryKey = false;
                colvarOfferingCode.IsForeignKey = false;
                colvarOfferingCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingCode);
                
                TableSchema.TableColumn colvarOfferingName = new TableSchema.TableColumn(schema);
                colvarOfferingName.ColumnName = "OfferingName";
                colvarOfferingName.DataType = DbType.AnsiString;
                colvarOfferingName.MaxLength = 150;
                colvarOfferingName.AutoIncrement = false;
                colvarOfferingName.IsNullable = false;
                colvarOfferingName.IsPrimaryKey = false;
                colvarOfferingName.IsForeignKey = false;
                colvarOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingName);
                
                TableSchema.TableColumn colvarOfferingDescription = new TableSchema.TableColumn(schema);
                colvarOfferingDescription.ColumnName = "OfferingDescription";
                colvarOfferingDescription.DataType = DbType.AnsiString;
                colvarOfferingDescription.MaxLength = 5000;
                colvarOfferingDescription.AutoIncrement = false;
                colvarOfferingDescription.IsNullable = true;
                colvarOfferingDescription.IsPrimaryKey = false;
                colvarOfferingDescription.IsForeignKey = false;
                colvarOfferingDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingDescription);
                
                TableSchema.TableColumn colvarPhenomenonUOMID = new TableSchema.TableColumn(schema);
                colvarPhenomenonUOMID.ColumnName = "PhenomenonUOMID";
                colvarPhenomenonUOMID.DataType = DbType.Guid;
                colvarPhenomenonUOMID.MaxLength = 0;
                colvarPhenomenonUOMID.AutoIncrement = false;
                colvarPhenomenonUOMID.IsNullable = false;
                colvarPhenomenonUOMID.IsPrimaryKey = false;
                colvarPhenomenonUOMID.IsForeignKey = false;
                colvarPhenomenonUOMID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonUOMID);
                
                TableSchema.TableColumn colvarUnitOfMeasureID = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureID.ColumnName = "UnitOfMeasureID";
                colvarUnitOfMeasureID.DataType = DbType.Guid;
                colvarUnitOfMeasureID.MaxLength = 0;
                colvarUnitOfMeasureID.AutoIncrement = false;
                colvarUnitOfMeasureID.IsNullable = false;
                colvarUnitOfMeasureID.IsPrimaryKey = false;
                colvarUnitOfMeasureID.IsForeignKey = false;
                colvarUnitOfMeasureID.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureID);
                
                TableSchema.TableColumn colvarUnitOfMeasureCode = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureCode.ColumnName = "UnitOfMeasureCode";
                colvarUnitOfMeasureCode.DataType = DbType.AnsiString;
                colvarUnitOfMeasureCode.MaxLength = 50;
                colvarUnitOfMeasureCode.AutoIncrement = false;
                colvarUnitOfMeasureCode.IsNullable = false;
                colvarUnitOfMeasureCode.IsPrimaryKey = false;
                colvarUnitOfMeasureCode.IsForeignKey = false;
                colvarUnitOfMeasureCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureCode);
                
                TableSchema.TableColumn colvarUnitOfMeasureUnit = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureUnit.ColumnName = "UnitOfMeasureUnit";
                colvarUnitOfMeasureUnit.DataType = DbType.AnsiString;
                colvarUnitOfMeasureUnit.MaxLength = 100;
                colvarUnitOfMeasureUnit.AutoIncrement = false;
                colvarUnitOfMeasureUnit.IsNullable = false;
                colvarUnitOfMeasureUnit.IsPrimaryKey = false;
                colvarUnitOfMeasureUnit.IsForeignKey = false;
                colvarUnitOfMeasureUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureUnit);
                
                TableSchema.TableColumn colvarUnitOfMeasureSymbol = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureSymbol.ColumnName = "UnitOfMeasureSymbol";
                colvarUnitOfMeasureSymbol.DataType = DbType.AnsiString;
                colvarUnitOfMeasureSymbol.MaxLength = 20;
                colvarUnitOfMeasureSymbol.AutoIncrement = false;
                colvarUnitOfMeasureSymbol.IsNullable = false;
                colvarUnitOfMeasureSymbol.IsPrimaryKey = false;
                colvarUnitOfMeasureSymbol.IsForeignKey = false;
                colvarUnitOfMeasureSymbol.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureSymbol);
                
                TableSchema.TableColumn colvarCount = new TableSchema.TableColumn(schema);
                colvarCount.ColumnName = "Count";
                colvarCount.DataType = DbType.Int32;
                colvarCount.MaxLength = 0;
                colvarCount.AutoIncrement = false;
                colvarCount.IsNullable = true;
                colvarCount.IsPrimaryKey = false;
                colvarCount.IsForeignKey = false;
                colvarCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarCount);
                
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
                
                TableSchema.TableColumn colvarLatitudeNorth = new TableSchema.TableColumn(schema);
                colvarLatitudeNorth.ColumnName = "LatitudeNorth";
                colvarLatitudeNorth.DataType = DbType.Double;
                colvarLatitudeNorth.MaxLength = 0;
                colvarLatitudeNorth.AutoIncrement = false;
                colvarLatitudeNorth.IsNullable = true;
                colvarLatitudeNorth.IsPrimaryKey = false;
                colvarLatitudeNorth.IsForeignKey = false;
                colvarLatitudeNorth.IsReadOnly = false;
                
                schema.Columns.Add(colvarLatitudeNorth);
                
                TableSchema.TableColumn colvarLatitudeSouth = new TableSchema.TableColumn(schema);
                colvarLatitudeSouth.ColumnName = "LatitudeSouth";
                colvarLatitudeSouth.DataType = DbType.Double;
                colvarLatitudeSouth.MaxLength = 0;
                colvarLatitudeSouth.AutoIncrement = false;
                colvarLatitudeSouth.IsNullable = true;
                colvarLatitudeSouth.IsPrimaryKey = false;
                colvarLatitudeSouth.IsForeignKey = false;
                colvarLatitudeSouth.IsReadOnly = false;
                
                schema.Columns.Add(colvarLatitudeSouth);
                
                TableSchema.TableColumn colvarLongitudeWest = new TableSchema.TableColumn(schema);
                colvarLongitudeWest.ColumnName = "LongitudeWest";
                colvarLongitudeWest.DataType = DbType.Double;
                colvarLongitudeWest.MaxLength = 0;
                colvarLongitudeWest.AutoIncrement = false;
                colvarLongitudeWest.IsNullable = true;
                colvarLongitudeWest.IsPrimaryKey = false;
                colvarLongitudeWest.IsForeignKey = false;
                colvarLongitudeWest.IsReadOnly = false;
                
                schema.Columns.Add(colvarLongitudeWest);
                
                TableSchema.TableColumn colvarLongitudeEast = new TableSchema.TableColumn(schema);
                colvarLongitudeEast.ColumnName = "LongitudeEast";
                colvarLongitudeEast.DataType = DbType.Double;
                colvarLongitudeEast.MaxLength = 0;
                colvarLongitudeEast.AutoIncrement = false;
                colvarLongitudeEast.IsNullable = true;
                colvarLongitudeEast.IsPrimaryKey = false;
                colvarLongitudeEast.IsForeignKey = false;
                colvarLongitudeEast.IsReadOnly = false;
                
                schema.Columns.Add(colvarLongitudeEast);
                
                TableSchema.TableColumn colvarElevationMinimum = new TableSchema.TableColumn(schema);
                colvarElevationMinimum.ColumnName = "ElevationMinimum";
                colvarElevationMinimum.DataType = DbType.Double;
                colvarElevationMinimum.MaxLength = 0;
                colvarElevationMinimum.AutoIncrement = false;
                colvarElevationMinimum.IsNullable = true;
                colvarElevationMinimum.IsPrimaryKey = false;
                colvarElevationMinimum.IsForeignKey = false;
                colvarElevationMinimum.IsReadOnly = false;
                
                schema.Columns.Add(colvarElevationMinimum);
                
                TableSchema.TableColumn colvarElevationMaximum = new TableSchema.TableColumn(schema);
                colvarElevationMaximum.ColumnName = "ElevationMaximum";
                colvarElevationMaximum.DataType = DbType.Double;
                colvarElevationMaximum.MaxLength = 0;
                colvarElevationMaximum.AutoIncrement = false;
                colvarElevationMaximum.IsNullable = true;
                colvarElevationMaximum.IsPrimaryKey = false;
                colvarElevationMaximum.IsForeignKey = false;
                colvarElevationMaximum.IsReadOnly = false;
                
                schema.Columns.Add(colvarElevationMaximum);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vInventoryDataStreams",schema);
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
	    public VInventoryDataStream()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VInventoryDataStream(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VInventoryDataStream(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VInventoryDataStream(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public long? Id 
	    {
		    get
		    {
			    return GetColumnValue<long?>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("SiteID")]
        [Bindable(true)]
        public Guid SiteID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SiteID");
		    }
            set 
		    {
			    SetColumnValue("SiteID", value);
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
	      
        [XmlAttribute("SiteDescription")]
        [Bindable(true)]
        public string SiteDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteDescription");
		    }
            set 
		    {
			    SetColumnValue("SiteDescription", value);
            }
        }
	      
        [XmlAttribute("SiteUrl")]
        [Bindable(true)]
        public string SiteUrl 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteUrl");
		    }
            set 
		    {
			    SetColumnValue("SiteUrl", value);
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
	      
        [XmlAttribute("StationDescription")]
        [Bindable(true)]
        public string StationDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationDescription");
		    }
            set 
		    {
			    SetColumnValue("StationDescription", value);
            }
        }
	      
        [XmlAttribute("StationUrl")]
        [Bindable(true)]
        public string StationUrl 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationUrl");
		    }
            set 
		    {
			    SetColumnValue("StationUrl", value);
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
	      
        [XmlAttribute("PhenomenonCode")]
        [Bindable(true)]
        public string PhenomenonCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonCode");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonCode", value);
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
	      
        [XmlAttribute("PhenomenonDescription")]
        [Bindable(true)]
        public string PhenomenonDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonDescription");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonDescription", value);
            }
        }
	      
        [XmlAttribute("PhenomenonUrl")]
        [Bindable(true)]
        public string PhenomenonUrl 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonUrl");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonUrl", value);
            }
        }
	      
        [XmlAttribute("PhenomenonOfferingID")]
        [Bindable(true)]
        public Guid PhenomenonOfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonOfferingID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonOfferingID", value);
            }
        }
	      
        [XmlAttribute("OfferingID")]
        [Bindable(true)]
        public Guid OfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("OfferingID");
		    }
            set 
		    {
			    SetColumnValue("OfferingID", value);
            }
        }
	      
        [XmlAttribute("OfferingCode")]
        [Bindable(true)]
        public string OfferingCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingCode");
		    }
            set 
		    {
			    SetColumnValue("OfferingCode", value);
            }
        }
	      
        [XmlAttribute("OfferingName")]
        [Bindable(true)]
        public string OfferingName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingName");
		    }
            set 
		    {
			    SetColumnValue("OfferingName", value);
            }
        }
	      
        [XmlAttribute("OfferingDescription")]
        [Bindable(true)]
        public string OfferingDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingDescription");
		    }
            set 
		    {
			    SetColumnValue("OfferingDescription", value);
            }
        }
	      
        [XmlAttribute("PhenomenonUOMID")]
        [Bindable(true)]
        public Guid PhenomenonUOMID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonUOMID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonUOMID", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureID")]
        [Bindable(true)]
        public Guid UnitOfMeasureID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("UnitOfMeasureID");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureID", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureCode")]
        [Bindable(true)]
        public string UnitOfMeasureCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureCode");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureCode", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureUnit")]
        [Bindable(true)]
        public string UnitOfMeasureUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureUnit");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureUnit", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureSymbol")]
        [Bindable(true)]
        public string UnitOfMeasureSymbol 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureSymbol");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureSymbol", value);
            }
        }
	      
        [XmlAttribute("Count")]
        [Bindable(true)]
        public int? Count 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Count");
		    }
            set 
		    {
			    SetColumnValue("Count", value);
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
	      
        [XmlAttribute("LatitudeNorth")]
        [Bindable(true)]
        public double? LatitudeNorth 
	    {
		    get
		    {
			    return GetColumnValue<double?>("LatitudeNorth");
		    }
            set 
		    {
			    SetColumnValue("LatitudeNorth", value);
            }
        }
	      
        [XmlAttribute("LatitudeSouth")]
        [Bindable(true)]
        public double? LatitudeSouth 
	    {
		    get
		    {
			    return GetColumnValue<double?>("LatitudeSouth");
		    }
            set 
		    {
			    SetColumnValue("LatitudeSouth", value);
            }
        }
	      
        [XmlAttribute("LongitudeWest")]
        [Bindable(true)]
        public double? LongitudeWest 
	    {
		    get
		    {
			    return GetColumnValue<double?>("LongitudeWest");
		    }
            set 
		    {
			    SetColumnValue("LongitudeWest", value);
            }
        }
	      
        [XmlAttribute("LongitudeEast")]
        [Bindable(true)]
        public double? LongitudeEast 
	    {
		    get
		    {
			    return GetColumnValue<double?>("LongitudeEast");
		    }
            set 
		    {
			    SetColumnValue("LongitudeEast", value);
            }
        }
	      
        [XmlAttribute("ElevationMinimum")]
        [Bindable(true)]
        public double? ElevationMinimum 
	    {
		    get
		    {
			    return GetColumnValue<double?>("ElevationMinimum");
		    }
            set 
		    {
			    SetColumnValue("ElevationMinimum", value);
            }
        }
	      
        [XmlAttribute("ElevationMaximum")]
        [Bindable(true)]
        public double? ElevationMaximum 
	    {
		    get
		    {
			    return GetColumnValue<double?>("ElevationMaximum");
		    }
            set 
		    {
			    SetColumnValue("ElevationMaximum", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string SiteID = @"SiteID";
            
            public static string SiteCode = @"SiteCode";
            
            public static string SiteName = @"SiteName";
            
            public static string SiteDescription = @"SiteDescription";
            
            public static string SiteUrl = @"SiteUrl";
            
            public static string StationID = @"StationID";
            
            public static string StationCode = @"StationCode";
            
            public static string StationName = @"StationName";
            
            public static string StationDescription = @"StationDescription";
            
            public static string StationUrl = @"StationUrl";
            
            public static string PhenomenonID = @"PhenomenonID";
            
            public static string PhenomenonCode = @"PhenomenonCode";
            
            public static string PhenomenonName = @"PhenomenonName";
            
            public static string PhenomenonDescription = @"PhenomenonDescription";
            
            public static string PhenomenonUrl = @"PhenomenonUrl";
            
            public static string PhenomenonOfferingID = @"PhenomenonOfferingID";
            
            public static string OfferingID = @"OfferingID";
            
            public static string OfferingCode = @"OfferingCode";
            
            public static string OfferingName = @"OfferingName";
            
            public static string OfferingDescription = @"OfferingDescription";
            
            public static string PhenomenonUOMID = @"PhenomenonUOMID";
            
            public static string UnitOfMeasureID = @"UnitOfMeasureID";
            
            public static string UnitOfMeasureCode = @"UnitOfMeasureCode";
            
            public static string UnitOfMeasureUnit = @"UnitOfMeasureUnit";
            
            public static string UnitOfMeasureSymbol = @"UnitOfMeasureSymbol";
            
            public static string Count = @"Count";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string LatitudeNorth = @"LatitudeNorth";
            
            public static string LatitudeSouth = @"LatitudeSouth";
            
            public static string LongitudeWest = @"LongitudeWest";
            
            public static string LongitudeEast = @"LongitudeEast";
            
            public static string ElevationMinimum = @"ElevationMinimum";
            
            public static string ElevationMaximum = @"ElevationMaximum";
            
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
