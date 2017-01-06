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
namespace NorthwindRepository{
    /// <summary>
    /// Strongly-typed collection for the OrderSubtotal class.
    /// </summary>
    [Serializable]
    public partial class OrderSubtotalCollection : ReadOnlyList<OrderSubtotal, OrderSubtotalCollection>
    {        
        public OrderSubtotalCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the Order Subtotals view.
    /// </summary>
    [Serializable]
    public partial class OrderSubtotal : ReadOnlyRecord<OrderSubtotal>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("Order Subtotals", TableType.View, DataService.GetInstance("NorthwindRepository"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarOrderID = new TableSchema.TableColumn(schema);
                colvarOrderID.ColumnName = "OrderID";
                colvarOrderID.DataType = DbType.Int32;
                colvarOrderID.MaxLength = 0;
                colvarOrderID.AutoIncrement = false;
                colvarOrderID.IsNullable = false;
                colvarOrderID.IsPrimaryKey = false;
                colvarOrderID.IsForeignKey = false;
                colvarOrderID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrderID);
                
                TableSchema.TableColumn colvarSubtotal = new TableSchema.TableColumn(schema);
                colvarSubtotal.ColumnName = "Subtotal";
                colvarSubtotal.DataType = DbType.Currency;
                colvarSubtotal.MaxLength = 0;
                colvarSubtotal.AutoIncrement = false;
                colvarSubtotal.IsNullable = true;
                colvarSubtotal.IsPrimaryKey = false;
                colvarSubtotal.IsForeignKey = false;
                colvarSubtotal.IsReadOnly = false;
                
                schema.Columns.Add(colvarSubtotal);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["NorthwindRepository"].AddSchema("Order Subtotals",schema);
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
	    public OrderSubtotal()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public OrderSubtotal(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public OrderSubtotal(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public OrderSubtotal(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("OrderID")]
        [Bindable(true)]
        public int OrderID 
	    {
		    get
		    {
			    return GetColumnValue<int>("OrderID");
		    }
            set 
		    {
			    SetColumnValue("OrderID", value);
            }
        }
	      
        [XmlAttribute("Subtotal")]
        [Bindable(true)]
        public decimal? Subtotal 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("Subtotal");
		    }
            set 
		    {
			    SetColumnValue("Subtotal", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string OrderID = @"OrderID";
            
            public static string Subtotal = @"Subtotal";
            
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
