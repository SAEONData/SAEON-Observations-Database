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
    /// Strongly-typed collection for the ProgressProgressResolved class.
    /// </summary>
    [Serializable]
    public partial class ProgressProgressResolvedCollection : ReadOnlyList<ProgressProgressResolved, ProgressProgressResolvedCollection>
    {        
        public ProgressProgressResolvedCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the progress_Progress_Resolved view.
    /// </summary>
    [Serializable]
    public partial class ProgressProgressResolved : ReadOnlyRecord<ProgressProgressResolved>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("progress_Progress_Resolved", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarImportDate = new TableSchema.TableColumn(schema);
                colvarImportDate.ColumnName = "ImportDate";
                colvarImportDate.DataType = DbType.DateTime;
                colvarImportDate.MaxLength = 0;
                colvarImportDate.AutoIncrement = false;
                colvarImportDate.IsNullable = true;
                colvarImportDate.IsPrimaryKey = false;
                colvarImportDate.IsForeignKey = false;
                colvarImportDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarImportDate);
                
                TableSchema.TableColumn colvarFileName = new TableSchema.TableColumn(schema);
                colvarFileName.ColumnName = "FileName";
                colvarFileName.DataType = DbType.AnsiString;
                colvarFileName.MaxLength = 250;
                colvarFileName.AutoIncrement = false;
                colvarFileName.IsNullable = true;
                colvarFileName.IsPrimaryKey = false;
                colvarFileName.IsForeignKey = false;
                colvarFileName.IsReadOnly = false;
                
                schema.Columns.Add(colvarFileName);
                
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
                
                TableSchema.TableColumn colvarObservations = new TableSchema.TableColumn(schema);
                colvarObservations.ColumnName = "Observations";
                colvarObservations.DataType = DbType.Int64;
                colvarObservations.MaxLength = 0;
                colvarObservations.AutoIncrement = false;
                colvarObservations.IsNullable = true;
                colvarObservations.IsPrimaryKey = false;
                colvarObservations.IsForeignKey = false;
                colvarObservations.IsReadOnly = false;
                
                schema.Columns.Add(colvarObservations);
                
                TableSchema.TableColumn colvarDateUploaded = new TableSchema.TableColumn(schema);
                colvarDateUploaded.ColumnName = "DateUploaded";
                colvarDateUploaded.DataType = DbType.DateTime;
                colvarDateUploaded.MaxLength = 0;
                colvarDateUploaded.AutoIncrement = false;
                colvarDateUploaded.IsNullable = true;
                colvarDateUploaded.IsPrimaryKey = false;
                colvarDateUploaded.IsForeignKey = false;
                colvarDateUploaded.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateUploaded);
                
                TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
                colvarUserName.ColumnName = "UserName";
                colvarUserName.DataType = DbType.String;
                colvarUserName.MaxLength = 256;
                colvarUserName.AutoIncrement = false;
                colvarUserName.IsNullable = true;
                colvarUserName.IsPrimaryKey = false;
                colvarUserName.IsForeignKey = false;
                colvarUserName.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserName);
                
                TableSchema.TableColumn colvarSensor = new TableSchema.TableColumn(schema);
                colvarSensor.ColumnName = "Sensor";
                colvarSensor.DataType = DbType.AnsiString;
                colvarSensor.MaxLength = 150;
                colvarSensor.AutoIncrement = false;
                colvarSensor.IsNullable = true;
                colvarSensor.IsPrimaryKey = false;
                colvarSensor.IsForeignKey = false;
                colvarSensor.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensor);
                
                TableSchema.TableColumn colvarStationID = new TableSchema.TableColumn(schema);
                colvarStationID.ColumnName = "StationID";
                colvarStationID.DataType = DbType.Guid;
                colvarStationID.MaxLength = 0;
                colvarStationID.AutoIncrement = false;
                colvarStationID.IsNullable = true;
                colvarStationID.IsPrimaryKey = false;
                colvarStationID.IsForeignKey = false;
                colvarStationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationID);
                
                TableSchema.TableColumn colvarStation = new TableSchema.TableColumn(schema);
                colvarStation.ColumnName = "Station";
                colvarStation.DataType = DbType.AnsiString;
                colvarStation.MaxLength = 150;
                colvarStation.AutoIncrement = false;
                colvarStation.IsNullable = true;
                colvarStation.IsPrimaryKey = false;
                colvarStation.IsForeignKey = false;
                colvarStation.IsReadOnly = false;
                
                schema.Columns.Add(colvarStation);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("progress_Progress_Resolved",schema);
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
	    public ProgressProgressResolved()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ProgressProgressResolved(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ProgressProgressResolved(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ProgressProgressResolved(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ImportDate")]
        [Bindable(true)]
        public DateTime? ImportDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("ImportDate");
		    }
            set 
		    {
			    SetColumnValue("ImportDate", value);
            }
        }
	      
        [XmlAttribute("FileName")]
        [Bindable(true)]
        public string FileName 
	    {
		    get
		    {
			    return GetColumnValue<string>("FileName");
		    }
            set 
		    {
			    SetColumnValue("FileName", value);
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
	      
        [XmlAttribute("Observations")]
        [Bindable(true)]
        public long? Observations 
	    {
		    get
		    {
			    return GetColumnValue<long?>("Observations");
		    }
            set 
		    {
			    SetColumnValue("Observations", value);
            }
        }
	      
        [XmlAttribute("DateUploaded")]
        [Bindable(true)]
        public DateTime? DateUploaded 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("DateUploaded");
		    }
            set 
		    {
			    SetColumnValue("DateUploaded", value);
            }
        }
	      
        [XmlAttribute("UserName")]
        [Bindable(true)]
        public string UserName 
	    {
		    get
		    {
			    return GetColumnValue<string>("UserName");
		    }
            set 
		    {
			    SetColumnValue("UserName", value);
            }
        }
	      
        [XmlAttribute("Sensor")]
        [Bindable(true)]
        public string Sensor 
	    {
		    get
		    {
			    return GetColumnValue<string>("Sensor");
		    }
            set 
		    {
			    SetColumnValue("Sensor", value);
            }
        }
	      
        [XmlAttribute("StationID")]
        [Bindable(true)]
        public Guid? StationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("StationID");
		    }
            set 
		    {
			    SetColumnValue("StationID", value);
            }
        }
	      
        [XmlAttribute("Station")]
        [Bindable(true)]
        public string Station 
	    {
		    get
		    {
			    return GetColumnValue<string>("Station");
		    }
            set 
		    {
			    SetColumnValue("Station", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ImportDate = @"ImportDate";
            
            public static string FileName = @"FileName";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string Observations = @"Observations";
            
            public static string DateUploaded = @"DateUploaded";
            
            public static string UserName = @"UserName";
            
            public static string Sensor = @"Sensor";
            
            public static string StationID = @"StationID";
            
            public static string Station = @"Station";
            
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
