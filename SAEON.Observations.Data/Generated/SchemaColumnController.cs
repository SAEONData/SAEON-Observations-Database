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
    /// Controller class for SchemaColumn
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SchemaColumnController
    {
        // Preload our schema..
        SchemaColumn thisSchemaLoad = new SchemaColumn();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SchemaColumnCollection FetchAll()
        {
            SchemaColumnCollection coll = new SchemaColumnCollection();
            Query qry = new Query(SchemaColumn.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SchemaColumnCollection FetchByID(object Id)
        {
            SchemaColumnCollection coll = new SchemaColumnCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SchemaColumnCollection FetchByQuery(Query qry)
        {
            SchemaColumnCollection coll = new SchemaColumnCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SchemaColumn.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SchemaColumn.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,Guid DataSchemaID,int Number,string Name,Guid SchemaColumnTypeID,int? Width,string Format,Guid? PhenomenonID,Guid? PhenomenonOfferingID,Guid? PhenomenonUOMID,string EmptyValue,string FixedTime,Guid UserId,DateTime? AddedAt,DateTime? UpdatedAt,byte[] RowVersion)
	    {
		    SchemaColumn item = new SchemaColumn();
		    
            item.Id = Id;
            
            item.DataSchemaID = DataSchemaID;
            
            item.Number = Number;
            
            item.Name = Name;
            
            item.SchemaColumnTypeID = SchemaColumnTypeID;
            
            item.Width = Width;
            
            item.Format = Format;
            
            item.PhenomenonID = PhenomenonID;
            
            item.PhenomenonOfferingID = PhenomenonOfferingID;
            
            item.PhenomenonUOMID = PhenomenonUOMID;
            
            item.EmptyValue = EmptyValue;
            
            item.FixedTime = FixedTime;
            
            item.UserId = UserId;
            
            item.AddedAt = AddedAt;
            
            item.UpdatedAt = UpdatedAt;
            
            item.RowVersion = RowVersion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,Guid DataSchemaID,int Number,string Name,Guid SchemaColumnTypeID,int? Width,string Format,Guid? PhenomenonID,Guid? PhenomenonOfferingID,Guid? PhenomenonUOMID,string EmptyValue,string FixedTime,Guid UserId,DateTime? AddedAt,DateTime? UpdatedAt,byte[] RowVersion)
	    {
		    SchemaColumn item = new SchemaColumn();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.DataSchemaID = DataSchemaID;
				
			item.Number = Number;
				
			item.Name = Name;
				
			item.SchemaColumnTypeID = SchemaColumnTypeID;
				
			item.Width = Width;
				
			item.Format = Format;
				
			item.PhenomenonID = PhenomenonID;
				
			item.PhenomenonOfferingID = PhenomenonOfferingID;
				
			item.PhenomenonUOMID = PhenomenonUOMID;
				
			item.EmptyValue = EmptyValue;
				
			item.FixedTime = FixedTime;
				
			item.UserId = UserId;
				
			item.AddedAt = AddedAt;
				
			item.UpdatedAt = UpdatedAt;
				
			item.RowVersion = RowVersion;
				
	        item.Save(UserName);
	    }
    }
}
