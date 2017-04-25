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
    /// Controller class for DataLog
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DataLogController
    {
        // Preload our schema..
        DataLog thisSchemaLoad = new DataLog();
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
        public DataLogCollection FetchAll()
        {
            DataLogCollection coll = new DataLogCollection();
            Query qry = new Query(DataLog.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataLogCollection FetchByID(object Id)
        {
            DataLogCollection coll = new DataLogCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataLogCollection FetchByQuery(Query qry)
        {
            DataLogCollection coll = new DataLogCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (DataLog.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (DataLog.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,Guid? SensorID,DateTime ImportDate,DateTime? ValueDate,DateTime? ValueTime,DateTime? ValueDay,string ValueText,string TransformValueText,double? RawValue,double? DataValue,string Comment,string InvalidDateValue,string InvalidTimeValue,string InvalidOffering,string InvalidUOM,Guid? DataSourceTransformationID,Guid StatusID,Guid? StatusReasonID,string ImportStatus,Guid? UserId,Guid? PhenomenonOfferingID,Guid? PhenomenonUOMID,Guid ImportBatchID,string RawRecordData,string RawFieldValue,Guid? CorrelationID,DateTime? AddedAt,DateTime? UpdatedAt)
	    {
		    DataLog item = new DataLog();
		    
            item.Id = Id;
            
            item.SensorID = SensorID;
            
            item.ImportDate = ImportDate;
            
            item.ValueDate = ValueDate;
            
            item.ValueTime = ValueTime;
            
            item.ValueDay = ValueDay;
            
            item.ValueText = ValueText;
            
            item.TransformValueText = TransformValueText;
            
            item.RawValue = RawValue;
            
            item.DataValue = DataValue;
            
            item.Comment = Comment;
            
            item.InvalidDateValue = InvalidDateValue;
            
            item.InvalidTimeValue = InvalidTimeValue;
            
            item.InvalidOffering = InvalidOffering;
            
            item.InvalidUOM = InvalidUOM;
            
            item.DataSourceTransformationID = DataSourceTransformationID;
            
            item.StatusID = StatusID;
            
            item.StatusReasonID = StatusReasonID;
            
            item.ImportStatus = ImportStatus;
            
            item.UserId = UserId;
            
            item.PhenomenonOfferingID = PhenomenonOfferingID;
            
            item.PhenomenonUOMID = PhenomenonUOMID;
            
            item.ImportBatchID = ImportBatchID;
            
            item.RawRecordData = RawRecordData;
            
            item.RawFieldValue = RawFieldValue;
            
            item.CorrelationID = CorrelationID;
            
            item.AddedAt = AddedAt;
            
            item.UpdatedAt = UpdatedAt;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,Guid? SensorID,DateTime ImportDate,DateTime? ValueDate,DateTime? ValueTime,DateTime? ValueDay,string ValueText,string TransformValueText,double? RawValue,double? DataValue,string Comment,string InvalidDateValue,string InvalidTimeValue,string InvalidOffering,string InvalidUOM,Guid? DataSourceTransformationID,Guid StatusID,Guid? StatusReasonID,string ImportStatus,Guid? UserId,Guid? PhenomenonOfferingID,Guid? PhenomenonUOMID,Guid ImportBatchID,string RawRecordData,string RawFieldValue,Guid? CorrelationID,DateTime? AddedAt,DateTime? UpdatedAt)
	    {
		    DataLog item = new DataLog();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SensorID = SensorID;
				
			item.ImportDate = ImportDate;
				
			item.ValueDate = ValueDate;
				
			item.ValueTime = ValueTime;
				
			item.ValueDay = ValueDay;
				
			item.ValueText = ValueText;
				
			item.TransformValueText = TransformValueText;
				
			item.RawValue = RawValue;
				
			item.DataValue = DataValue;
				
			item.Comment = Comment;
				
			item.InvalidDateValue = InvalidDateValue;
				
			item.InvalidTimeValue = InvalidTimeValue;
				
			item.InvalidOffering = InvalidOffering;
				
			item.InvalidUOM = InvalidUOM;
				
			item.DataSourceTransformationID = DataSourceTransformationID;
				
			item.StatusID = StatusID;
				
			item.StatusReasonID = StatusReasonID;
				
			item.ImportStatus = ImportStatus;
				
			item.UserId = UserId;
				
			item.PhenomenonOfferingID = PhenomenonOfferingID;
				
			item.PhenomenonUOMID = PhenomenonUOMID;
				
			item.ImportBatchID = ImportBatchID;
				
			item.RawRecordData = RawRecordData;
				
			item.RawFieldValue = RawFieldValue;
				
			item.CorrelationID = CorrelationID;
				
			item.AddedAt = AddedAt;
				
			item.UpdatedAt = UpdatedAt;
				
	        item.Save(UserName);
	    }
    }
}
