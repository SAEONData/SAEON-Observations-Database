﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using SAEON.Observations.Core.Entities;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    /// <summary>
    /// Sensors
    /// </summary>
    [ODataRoutePrefix("Sensors")]
    public class SensorsController : BaseODataController<Sensor>
    {

        // GET: odata/Sensors
        /// <summary>
        /// Get all Sensors
        /// </summary>
        /// <returns>ListOf(Sensor)</returns>
        [EnableQuery, ODataRoute]
        public override IQueryable<Sensor> GetAll()
        {
            return base.GetAll();
        }

        // GET: odata/Sensors(5)
        /// <summary>
        /// Sensor by Id
        /// </summary>
        /// <param name="id">Id of Sensor</param>
        /// <returns>Sensor</returns>
        [EnableQuery, ODataRoute("({id})")]
        public override SingleResult<Sensor> GetById([FromODataUri] Guid id)
        {
            return base.GetById(id);
        }

        // GET: odata/Sensors(5)
        /// <summary>
        /// Sensor by Name
        /// </summary>
        /// <param name="name">Name of Sensor</param>
        /// <returns>Sensor</returns>
        [EnableQuery, ODataRoute("({name})")]
        public override SingleResult<Sensor> GetByName([FromODataUri] string name)
        {
            return base.GetByName(name);
        }

        // GET: odata/Sensors(5)/Instruments
        /// <summary>
        /// Instruments for the Sensor
        /// </summary>
        /// <param name="id">Id of the Sensor</param>
        /// <returns>ListOf(Instrument)</returns>
        [EnableQuery, ODataRoute("({id})/Instruments")]
        public IQueryable<Instrument> GetInstruments([FromODataUri] Guid id)
        {
            return GetMany<Instrument>(id, s => s.Instruments, i => i.Sensors);
        }

        // GET: odata/Sensors(5)/Phenomenon
        /// <summary>
        /// Phenomena for the Sensor
        /// </summary>
        /// <param name="id">Id of the Sensor</param>
        /// <returns>ListOf(Phenomenon)</returns>
        [EnableQuery, ODataRoute("({id})/Phenomenon")]
        public SingleResult<Phenomenon> GetPhenomenon([FromODataUri] Guid id)
        {
            return GetSingle(id, s => s.Phenomenon, i => i.Sensors);
        }

    }
}