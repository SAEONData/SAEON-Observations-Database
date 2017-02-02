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
    /// Controller class for UserDownloads
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserDownloadController
    {
        // Preload our schema..
        UserDownload thisSchemaLoad = new UserDownload();
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
        public UserDownloadCollection FetchAll()
        {
            UserDownloadCollection coll = new UserDownloadCollection();
            Query qry = new Query(UserDownload.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserDownloadCollection FetchByID(object Id)
        {
            UserDownloadCollection coll = new UserDownloadCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserDownloadCollection FetchByQuery(Query qry)
        {
            UserDownloadCollection coll = new UserDownloadCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (UserDownload.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (UserDownload.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,string UserId,string Name,string Description,string QueryURI,string DownloadURI,DateTime? AddedAt,string AddedBy,DateTime? UpdatedAt,string UpdatedBy)
	    {
		    UserDownload item = new UserDownload();
		    
            item.Id = Id;
            
            item.UserId = UserId;
            
            item.Name = Name;
            
            item.Description = Description;
            
            item.QueryURI = QueryURI;
            
            item.DownloadURI = DownloadURI;
            
            item.AddedAt = AddedAt;
            
            item.AddedBy = AddedBy;
            
            item.UpdatedAt = UpdatedAt;
            
            item.UpdatedBy = UpdatedBy;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,string UserId,string Name,string Description,string QueryURI,string DownloadURI,DateTime? AddedAt,string AddedBy,DateTime? UpdatedAt,string UpdatedBy)
	    {
		    UserDownload item = new UserDownload();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.UserId = UserId;
				
			item.Name = Name;
				
			item.Description = Description;
				
			item.QueryURI = QueryURI;
				
			item.DownloadURI = DownloadURI;
				
			item.AddedAt = AddedAt;
				
			item.AddedBy = AddedBy;
				
			item.UpdatedAt = UpdatedAt;
				
			item.UpdatedBy = UpdatedBy;
				
	        item.Save(UserName);
	    }
    }
}