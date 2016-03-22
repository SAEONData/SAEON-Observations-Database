﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net;
using SubSonic;
using SAEON.ObservationsDB.Data;

/// <summary>
/// Summary description for DataLogRepository
/// </summary>
public class DataLogRepository : BaseRepository
{
    public DataLogRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<VDataLog> GetPagedListByBatch(StoreRefreshDataEventArgs e, string paramPrefix, Int64 BatchID)
    {


        SqlQuery q = new Select().From(VDataLog.Schema);
        q.Where(VDataLog.Columns.ImportBatchID).IsEqualTo(BatchID);

        GetPagedQuery(ref q, e, paramPrefix);

        VDataLogCollection col = q.ExecuteAsCollection<VDataLogCollection>();

        return col.ToList<VDataLog>();

    }
}