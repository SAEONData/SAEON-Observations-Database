﻿using Microsoft.AspNet.OData.Routing;
using System;
using System.Linq;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    [ODataRoutePrefix("Stations")]
    public class StationsController : NamedODataController<Station>
    {
        [ODataRoute("({id})/Site")]
        public Site GetSite(Guid id)
        {
            return GetSingle(id, s => s.Site);
        }

        [ODataRoute("({id})/Organisations")]
        public IQueryable<Organisation> GetOrganisations(Guid id)
        {
            var site = GetSingle(id, s => s.Site);
            var siteOrganiations = DbContext.Sites.Where(i => i.Id == site.Id).SelectMany(i => i.Organisations);
            return GetManyWithGuidId(id, s => s.Organisations).Union(siteOrganiations); ;
        }

        [ODataRoute("({id})/Projects")]
        public IQueryable<Project> GetProjects(Guid id)
        {
            return GetManyWithGuidId(id, s => s.Projects);
        }

        [ODataRoute("({id})/Instruments")]
        public IQueryable<Instrument> GetInstruments(Guid id)
        {
            return GetManyWithGuidId(id, s => s.Instruments);
        }

        //[ODataRoute("({id})/DataStreams")] @@
        //public IQueryable<Dataset> GetDatasets(Guid id)
        //{
        //    return GetManyWithLongId(id, s => s.Datastreams);
        //}

        //[ODataRoute("({id})/Observations")] @@
        //public IQueryable<Observation> GetObservations(Guid id)
        //{
        //    return GetManyWithIntId(id, s => s.Observations);
        //}

    }
}
