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
namespace SAEON.ObservationsDB.Data
{
    /// <summary>
    /// Strongly-typed collection for the DataSourceRole class.
    /// </summary>
    [Serializable]
    public partial class DataSourceRoleCollection : ActiveList<DataSourceRole, DataSourceRoleCollection>
    {	   
        public DataSourceRoleCollection() {}
        
        /// <summary>
        /// Filters an existing collection based on the set criteria. This is an in-memory filter
        /// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DataSourceRoleCollection</returns>
        public DataSourceRoleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DataSourceRole o = this[i];
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
    /// This is an ActiveRecord class which wraps the DataSourceRole table.
    /// </summary>
    [Serializable]
    public partial class DataSourceRole : ActiveRecord<DataSourceRole>, IActiveRecord
    {
        #region .ctors and Default Settings
        
        public DataSourceRole()
        {
          SetSQLProps();
          InitSetDefaults();
          MarkNew();
        }
        
        private void InitSetDefaults() { SetDefaults(); }
        
        public DataSourceRole(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if(useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        
        public DataSourceRole(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }
         
        public DataSourceRole(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("DataSourceRole", TableType.Table, DataService.GetInstance("SqlDataProvider"));
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
                
                TableSchema.TableColumn colvarRoleId = new TableSchema.TableColumn(schema);
                colvarRoleId.ColumnName = "RoleId";
                colvarRoleId.DataType = DbType.Guid;
                colvarRoleId.MaxLength = 0;
                colvarRoleId.AutoIncrement = false;
                colvarRoleId.IsNullable = false;
                colvarRoleId.IsPrimaryKey = false;
                colvarRoleId.IsForeignKey = true;
                colvarRoleId.IsReadOnly = false;
                colvarRoleId.DefaultSetting = @"";
                
                    colvarRoleId.ForeignKeyTableName = "aspnet_Roles";
                schema.Columns.Add(colvarRoleId);
                
                TableSchema.TableColumn colvarDateStart = new TableSchema.TableColumn(schema);
                colvarDateStart.ColumnName = "DateStart";
                colvarDateStart.DataType = DbType.DateTime;
                colvarDateStart.MaxLength = 0;
                colvarDateStart.AutoIncrement = false;
                colvarDateStart.IsNullable = true;
                colvarDateStart.IsPrimaryKey = false;
                colvarDateStart.IsForeignKey = false;
                colvarDateStart.IsReadOnly = false;
                colvarDateStart.DefaultSetting = @"";
                colvarDateStart.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDateStart);
                
                TableSchema.TableColumn colvarDateEnd = new TableSchema.TableColumn(schema);
                colvarDateEnd.ColumnName = "DateEnd";
                colvarDateEnd.DataType = DbType.DateTime;
                colvarDateEnd.MaxLength = 0;
                colvarDateEnd.AutoIncrement = false;
                colvarDateEnd.IsNullable = true;
                colvarDateEnd.IsPrimaryKey = false;
                colvarDateEnd.IsForeignKey = false;
                colvarDateEnd.IsReadOnly = false;
                colvarDateEnd.DefaultSetting = @"";
                colvarDateEnd.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDateEnd);
                
                TableSchema.TableColumn colvarRoleName = new TableSchema.TableColumn(schema);
                colvarRoleName.ColumnName = "RoleName";
                colvarRoleName.DataType = DbType.AnsiString;
                colvarRoleName.MaxLength = 256;
                colvarRoleName.AutoIncrement = false;
                colvarRoleName.IsNullable = true;
                colvarRoleName.IsPrimaryKey = false;
                colvarRoleName.IsForeignKey = false;
                colvarRoleName.IsReadOnly = false;
                colvarRoleName.DefaultSetting = @"";
                colvarRoleName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoleName);
                
                TableSchema.TableColumn colvarIsRoleReadOnly = new TableSchema.TableColumn(schema);
                colvarIsRoleReadOnly.ColumnName = "IsRoleReadOnly";
                colvarIsRoleReadOnly.DataType = DbType.Boolean;
                colvarIsRoleReadOnly.MaxLength = 0;
                colvarIsRoleReadOnly.AutoIncrement = false;
                colvarIsRoleReadOnly.IsNullable = true;
                colvarIsRoleReadOnly.IsPrimaryKey = false;
                colvarIsRoleReadOnly.IsForeignKey = false;
                colvarIsRoleReadOnly.IsReadOnly = false;
                colvarIsRoleReadOnly.DefaultSetting = @"";
                colvarIsRoleReadOnly.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIsRoleReadOnly);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SqlDataProvider"].AddSchema("DataSourceRole",schema);
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
          
        [XmlAttribute("DataSourceID")]
        [Bindable(true)]
        public Guid DataSourceID 
        {
            get { return GetColumnValue<Guid>(Columns.DataSourceID); }
            set { SetColumnValue(Columns.DataSourceID, value); }
        }
          
        [XmlAttribute("RoleId")]
        [Bindable(true)]
        public Guid RoleId 
        {
            get { return GetColumnValue<Guid>(Columns.RoleId); }
            set { SetColumnValue(Columns.RoleId, value); }
        }
          
        [XmlAttribute("DateStart")]
        [Bindable(true)]
        public DateTime? DateStart 
        {
            get { return GetColumnValue<DateTime?>(Columns.DateStart); }
            set { SetColumnValue(Columns.DateStart, value); }
        }
          
        [XmlAttribute("DateEnd")]
        [Bindable(true)]
        public DateTime? DateEnd 
        {
            get { return GetColumnValue<DateTime?>(Columns.DateEnd); }
            set { SetColumnValue(Columns.DateEnd, value); }
        }
          
        [XmlAttribute("RoleName")]
        [Bindable(true)]
        public string RoleName 
        {
            get { return GetColumnValue<string>(Columns.RoleName); }
            set { SetColumnValue(Columns.RoleName, value); }
        }
          
        [XmlAttribute("IsRoleReadOnly")]
        [Bindable(true)]
        public bool? IsRoleReadOnly 
        {
            get { return GetColumnValue<bool?>(Columns.IsRoleReadOnly); }
            set { SetColumnValue(Columns.IsRoleReadOnly, value); }
        }
        
        #endregion
        
        
            
        
        #region ForeignKey Properties
        
        /// <summary>
        /// Returns a AspnetRole ActiveRecord object related to this DataSourceRole
        /// 
        /// </summary>
        public SAEON.ObservationsDB.Data.AspnetRole AspnetRole
        {
            get { return SAEON.ObservationsDB.Data.AspnetRole.FetchByID(this.RoleId); }
            set { SetColumnValue("RoleId", value.RoleId); }
        }
        
        
        /// <summary>
        /// Returns a DataSource ActiveRecord object related to this DataSourceRole
        /// 
        /// </summary>
        public SAEON.ObservationsDB.Data.DataSource DataSource
        {
            get { return SAEON.ObservationsDB.Data.DataSource.FetchByID(this.DataSourceID); }
            set { SetColumnValue("DataSourceID", value.Id); }
        }
        
        
        #endregion
        
        
        
        //no ManyToMany tables defined (0)
        
        
        
        #region ObjectDataSource support
        
        
        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(Guid varId,Guid varDataSourceID,Guid varRoleId,DateTime? varDateStart,DateTime? varDateEnd,string varRoleName,bool? varIsRoleReadOnly)
        {
            DataSourceRole item = new DataSourceRole();
            
            item.Id = varId;
            
            item.DataSourceID = varDataSourceID;
            
            item.RoleId = varRoleId;
            
            item.DateStart = varDateStart;
            
            item.DateEnd = varDateEnd;
            
            item.RoleName = varRoleName;
            
            item.IsRoleReadOnly = varIsRoleReadOnly;
            
        
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        
        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(Guid varId,Guid varDataSourceID,Guid varRoleId,DateTime? varDateStart,DateTime? varDateEnd,string varRoleName,bool? varIsRoleReadOnly)
        {
            DataSourceRole item = new DataSourceRole();
            
                item.Id = varId;
            
                item.DataSourceID = varDataSourceID;
            
                item.RoleId = varRoleId;
            
                item.DateStart = varDateStart;
            
                item.DateEnd = varDateEnd;
            
                item.RoleName = varRoleName;
            
                item.IsRoleReadOnly = varIsRoleReadOnly;
            
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
        
        
        
        public static TableSchema.TableColumn DataSourceIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RoleIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DateStartColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DateEndColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn RoleNameColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsRoleReadOnlyColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
        #region Columns Struct
        public struct Columns
        {
             public static string Id = @"ID";
             public static string DataSourceID = @"DataSourceID";
             public static string RoleId = @"RoleId";
             public static string DateStart = @"DateStart";
             public static string DateEnd = @"DateEnd";
             public static string RoleName = @"RoleName";
             public static string IsRoleReadOnly = @"IsRoleReadOnly";
                        
        }
        #endregion
        
        #region Update PK Collections
        
        #endregion
    
        #region Deep Save
        
        #endregion
    }
}
