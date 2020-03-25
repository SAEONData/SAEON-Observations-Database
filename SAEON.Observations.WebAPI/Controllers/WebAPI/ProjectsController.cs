﻿using SAEON.Observations.Core.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SAEON.Observations.WebAPI.Controllers.WebAPI
{
    /// <summary>
    /// </summary>
    [RoutePrefix("Api/Projects")]
    public class ProjectsController : CodedApiController<Project>
    {
        protected override IQueryable<Project> GetQuery(Expression<Func<Project, bool>> extraWhere = null)
        {
            return base.GetQuery(extraWhere).Include(i => i.Programme).Include(i => i.Stations);
        }

        /// <summary>
        /// All Projects
        /// </summary>
        /// <returns>ListOf(Project)</returns>
        public override IQueryable<Project> GetAll()
        {
            return base.GetAll();
        }

        /// <summary>
        /// Project by Id
        /// </summary>
        /// <param name="id">The Id of the Project</param>
        /// <returns>Project</returns>
        [ResponseType(typeof(Project))]
        public override async Task<IHttpActionResult> GetByIdAsync([FromUri] Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        /// <summary>
        /// Project by Code
        /// </summary>
        /// <param name="code">The Code of the Project</param>
        /// <returns>Project</returns>
        [ResponseType(typeof(Project))]
        public override async Task<IHttpActionResult> GetByCodeAsync([FromUri] string code)
        {
            return await base.GetByCodeAsync(code);
        }

        /// <summary>
        /// Project by Name
        /// </summary>
        /// <param name="name">The Name of the Project</param>
        /// <returns>Project</returns>
        [ResponseType(typeof(Project))]
        public override async Task<IHttpActionResult> GetByNameAsync([FromUri] string name)
        {
            return await base.GetByNameAsync(name);
        }

        //GET: Projects/5/Programme
        /// <summary>
        /// Programme of the Project
        /// </summary>
        /// <param name="id">Id of Project</param>
        /// <returns>Programme</returns>
        [HttpGet] // No idea why required here
        [Route("{id:guid}/Programme")]
        [ResponseType(typeof(Programme))]
        public async Task<IHttpActionResult> ProgrammeAsync([FromUri] Guid id)
        {
            return await GetSingleAsync<Programme>(id, s => s.Programme);
        }

        //GET: Projects/5/Stations
        /// <summary>
        /// Stations of the Project
        /// </summary>
        /// <param name="id">Id of Project</param>
        /// <returns>ListOf(Station)</returns>
        [Route("{id:guid}/Stations")]
        public IQueryable<Station> GetStations([FromUri] Guid id)
        {
            return GetManyWithGuidId<Station>(id, s => s.Stations);
        }

    }
}