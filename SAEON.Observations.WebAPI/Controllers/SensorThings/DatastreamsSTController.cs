﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using SAEON.Observations.SensorThings;
using System;
using System.Linq;
using System.Web.Http;
using db = SAEON.Observations.Core.Entities;

namespace SAEON.Observations.WebAPI.Controllers.SensorThings
{

    [ODataRoutePrefix("Datastreams")]
    public class DatastreamsSTController : BaseGuidIdController<Datastream, db.SensorThingsDatastream>
    {
        [EnableQuery(PageSize = Config.PageSize), ODataRoute]
        public override IQueryable<Datastream> GetAll() => base.GetAll();

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})")]
        public override SingleResult<Datastream> GetById([FromODataUri] Guid id) => base.GetById(id);

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})/Observations")]
        public IQueryable<Observation> GetObservations([FromUri] Guid id) => GetRelatedManyIntId<Observation, db.SensorThingsObservation>(id);

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})/ObservedProperty")]
        public SingleResult<ObservedProperty> GetObservedProperty([FromUri] Guid id) => GetRelatedSingle<ObservedProperty, db.SensorThingsObservedProperty>(id);

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})/Sensor")]
        public SingleResult<Sensor> GetSensor([FromUri] Guid id) => GetRelatedSingle<Sensor, db.SensorThingsSensor>(id);

        [EnableQuery(PageSize = Config.PageSize), ODataRoute("({id})/Thing")]
        public SingleResult<Thing> GetThing([FromUri] Guid id) => GetRelatedSingle<Thing, db.SensorThingsThing>(id);
    }
}
