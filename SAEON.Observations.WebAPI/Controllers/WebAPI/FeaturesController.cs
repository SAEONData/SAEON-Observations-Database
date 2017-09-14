﻿using SAEON.Logs;
using SAEON.Observations.Core;
using SAEON.Observations.Core.Entities;
using SAEON.Observations.WebAPI.Filters;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SAEON.Observations.WebAPI.Controllers.WebAPI
{
    [RoutePrefix("Features")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ClientId("SAEON.Observations.QuerySite")]
    public class FeaturesController : ApiController
    {
        ObservationsDbContext db = new ObservationsDbContext();

        [HttpGet]
        [Route]
        public IQueryable<Feature> GetAll()
        {
            using (Logging.MethodCall<Feature>(GetType()))
            {
                try
                {
                    Logging.Verbose("Request.Uri: {uri}", Request.RequestUri);
                    //Logging.Verbose("QueryString: {querystring}", string.Join(", ", Request.GetQueryNameValuePairs().Select(kv => $"{kv.Key}: {kv.Value}")));
                    return FeaturesHelper.GetFeatures(db);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get all");
                    throw;
                }
            }
        }
    }
}
