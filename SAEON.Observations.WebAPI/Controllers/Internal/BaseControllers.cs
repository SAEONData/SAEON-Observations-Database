﻿using AutoMapper;
using SAEON.Logs;
using SAEON.Observations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SAEON.Observations.WebAPI.Controllers.Internal
{

    [ApiExplorerSettings(IgnoreApi = true)]
    //[ClientAuthorization("SAEON.Observations.QuerySite")] Uncomment when going live
    public abstract class BaseController : ApiController
    {
        protected ObservationsDbContext db = null;

        public BaseController() : base()
        {
            using (Logging.MethodCall(GetType()))
            {
                db = new ObservationsDbContext();
            }
        }

        ~BaseController()
        {
            db = null;
        }
    }

    public abstract class BaseListController<TEntity> : BaseController where TEntity : BaseEntity
    {
        /// <summary>
        /// query for items
        /// </summary>
        /// <returns></returns>
        protected virtual List<TEntity> GetList()
        {
            var result = new List<TEntity>();
            return result;
        }

        /// <summary>
        /// Get all TEntity
        /// </summary>
        /// <returns>ListOf(TEntity)</returns>
        [HttpGet]
        [Route]
        public IQueryable<TEntity> GetAll()
        {
            using (Logging.MethodCall<TEntity>(GetType()))
            {
                try
                {
                    //Logging.Information("GetAll");
                    return GetList().AsQueryable();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
    }

    public class OrderBy<TEntity>
    {
        public Expression<Func<TEntity, object>> Expression { get; set; }
        public bool Ascending { get; set; } = true;

        public OrderBy() { }
        public OrderBy(Expression<Func<TEntity, object>> expression)
        {
            Expression = expression;
        }
        public OrderBy(Expression<Func<TEntity, object>> expression, bool ascending)
        {
            Expression = expression;
            Ascending = ascending;
        }
    }

    public abstract class BaseContoller<TEntity> : BaseController where TEntity : IDEntity
    {
        /// <summary>
        /// Overwrite to filter entities
        /// </summary>
        /// <returns>ListOf(PredicateOf(TEntity))</returns>
        protected virtual List<Expression<Func<TEntity, bool>>> GetWheres()
        {
            return new List<Expression<Func<TEntity, bool>>>();
        }

        /// <summary>
        /// Overwrite to order of entities
        /// </summary>
        /// <returns>ListOf(PredicateOf(TEntity))</returns>
        protected virtual List<OrderBy<TEntity>> GetOrderBys()
        {
            return new List<OrderBy<TEntity>>();
        }

        /// <summary>
        /// Overwrite to order of entities
        /// </summary>
        /// <returns>ListOf(PredicateOf(TEntity))</returns>
        protected virtual List<Expression<Func<TEntity, object>>> GetOrderBysDesc()
        {
            return new List<Expression<Func<TEntity, object>>>();
        }

        /// <summary>
        /// query for items
        /// </summary>
        /// <returns></returns>
        protected IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> extraWhere = null)
        {
            var query = db.Set<TEntity>().AsQueryable();
            //foreach (var include in GetIncludes())
            //{
            //    query = query.Include(include);
            //}
            foreach (var where in GetWheres())
            {
                query = query.Where(where);
            }
            if (extraWhere != null)
            {
                query = query.Where(extraWhere);
            }
            var orderBys = GetOrderBys();
            var orderBy = orderBys.First();
            if (orderBy != null)
            {
                if (orderBy.Ascending)
                {
                    query = query.OrderBy(orderBy.Expression);
                }
                else
                {
                    query = query.OrderByDescending(orderBy.Expression);
                }
                foreach (var thenBy in orderBys.Skip(1))
                {
                    if (thenBy.Ascending)
                    {
                        query = ((IOrderedQueryable<TEntity>)query).ThenBy(thenBy.Expression);
                    }
                    else
                    {
                        query = ((IOrderedQueryable<TEntity>)query).ThenByDescending(thenBy.Expression);
                    }
                }
            }
            return query;
        }

        /// <summary>
        /// Get all TEntity
        /// </summary>
        /// <returns>ListOf(TEntity)</returns>
        [HttpGet]
        [Route]
        public virtual IQueryable<TEntity> GetAll()
        {
            using (Logging.MethodCall<TEntity>(GetType()))
            {
                try
                {
                    return GetQuery();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get all");
                    throw;
                }
            }
        }

        /// <summary>
        /// Get a TEntity by Id
        /// </summary>
        /// <param name="id">The Id of the TEntity</param>
        /// <returns>TEntity</returns>
        [HttpGet]
        [Route("{id:guid}")]
        //[ResponseType(typeof(TEntity))] required in derived classes
        public virtual async Task<IHttpActionResult> GetById([FromUri] Guid id)
        {
            using (Logging.MethodCall<TEntity>(GetType(), new ParameterList { { "Id", id } }))
            {
                try
                {
                    TEntity item = await GetQuery(i => (i.Id == id)).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        Logging.Error("{id} not found", id);
                        return NotFound();
                    }
                    return Ok(item);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get {id}", id);
                    throw;
                }
            }
        }
    }

    [Authorize]
    public abstract class BaseWriteController<TEntity> : BaseContoller<TEntity> where TEntity : NamedEntity
    {
        /// <summary>
        /// Overwrite to do additional checks before Post or Put
        /// </summary>
        /// <param name="item">TEntity</param>
        /// <param name="isPost"></param>
        /// <returns>True if TEntity is Ok else False</returns>
        protected virtual bool IsEntityOk(TEntity item, bool isPost)
        {
            return true;
        }

        /// <summary>
        /// Overwrite to do additional checks before Post or Put
        /// </summary>
        /// <param name="item">TEntity</param>
        /// <param name="isPost"></param>
        protected virtual void SetEntity(ref TEntity item, bool isPost)
        { }

        protected List<string> ModelStateErrors
        {
            get
            {
                return ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage + " " + v.Exception).ToList();
            }
        }

        protected List<string> GetValidationErrors(DbEntityValidationException ex)
        {
            return ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors.Select(m => m.PropertyName + ": " + m.ErrorMessage)).ToList();
        }

        /// <summary>
        /// Create a TEntity
        /// </summary>
        /// <param name="item">The new TEntity </param>
        [HttpPost]
        //[Route] Required in derived classes
        public virtual async Task<IHttpActionResult> Post([FromBody]TEntity item)
        {
            using (Logging.MethodCall<TEntity>(GetType(), new ParameterList { { "item", item } }))
            {
                try
                {
                    Logging.Verbose("Adding {Name} {@item}", item.Name, item);
                    if (item == null)
                    {
                        Logging.Error("item cannot be null");
                        return BadRequest("item cannot be null");
                    }
                    if (!ModelState.IsValid)
                    {
                        Logging.Error("ModelState.Invalid {ModelStateErrors}", ModelStateErrors);
                        return BadRequest(ModelState);
                    }
                    if (!IsEntityOk(item, true))
                    {
                        Logging.Error("{Name} invalid", item.Name);
                        return BadRequest($"{item.Name} invalid");
                    }
                    try
                    {
                        SetEntity(ref item, true);
                        Logging.Verbose("Add {@item}", item);
                        db.Set<TEntity>().Add(item);
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var validationErrors = GetValidationErrors(ex);
                        Logging.Exception(ex, "Unable to add {Name} {EntityValidationErrors}", item.Name, validationErrors);
                        return BadRequest($"Unable to add {item.Name} EntityValidationErrors: {string.Join("; ", validationErrors)}");
                    }
                    catch (DbUpdateException ex)
                    {
                        if (await GetQuery().Where(i => i.Name == item.Name).AnyAsync())
                        {
                            Logging.Error("{Name} conflict", item.Name);
                            return Conflict();
                        }
                        else
                        {
                            Logging.Exception(ex, "Unable to add {Name}", item.Name);
                            return BadRequest(ex.Message);
                        }
                    }
                    var attr = (RoutePrefixAttribute)GetType().GetCustomAttributes(typeof(RoutePrefixAttribute), true)?[0];
                    var location = $"{attr?.Prefix ?? typeof(TEntity).Name}/{item.Id}";
                    Logging.Verbose("Location: {location} Id: {Id} Item: {@item}", location, item.Id, item);
                    return Created<TEntity>(location, item);
                    //return CreatedAtRoute(name, new { id = item.Id }, item);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to add {Name}", item.Name);
                    throw;
                }
            }
        }

        /// <summary>
        /// Update a TEntity by Id
        /// </summary>
        /// <param name="id">The Id of the TEnity</param>
        /// <param name="delta">The new TEntity</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        //[Route("{id:guid}")] Required in derived classes
        public virtual async Task<IHttpActionResult> PutById(Guid id, [FromBody]TEntity delta)
        {
            using (Logging.MethodCall<TEntity>(GetType(), new ParameterList { { "id", id }, { "delta", delta } }))
            {
                try
                {
                    Logging.Verbose("Updating {id} {@delta}", id, delta);
                    if (!ModelState.IsValid)
                    {
                        Logging.Error("ModelState.Invalid {ModelStateErrors}", ModelStateErrors);
                        return BadRequest(ModelState);
                    }
                    if (id != delta.Id)
                    {
                        Logging.Error("{id} Id not same", id);
                        return BadRequest($"{id} Id not same");
                    }
                    if (!IsEntityOk(delta, false))
                    {
                        Logging.Error("{delta.Name} invalid", delta);
                        return BadRequest($"{delta.Name} invalid");
                    }
                    var item = await GetQuery().Where(i => i.Id == id).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        Logging.Error("{id} not found", id);
                        return NotFound();
                    }
                    try
                    {
                        //Logging.Verbose("Loaded {@item}", item);
                        Mapper.Map(delta, item);
                        //Logging.Verbose("Mapped delta {@item}", item);
                        SetEntity(ref item, false);
                        Logging.Verbose("Set {@item}", item);
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var validationErrors = GetValidationErrors(ex);
                        Logging.Exception(ex, "Unable to update {id} {EntityValidationErrors}", item.Id, validationErrors);
                        return BadRequest($"Unable to update {item.Id} EntityValidationErrors: {string.Join("; ", validationErrors)}");
                    }
                    catch (DbUpdateException ex)
                    {
                        Logging.Exception(ex, "Unable to update {id}", id);
                        return BadRequest(ex.Message);
                    }
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to update {id}", id);
                    throw;
                }
            }
        }

        /*
        /// <summary>
        /// Update a TEntity by Name
        /// </summary>
        /// <param name="name">The Name of the TEnity</param>
        /// <param name="delta">The new TEntity</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        //[Route] Required in derived classes
        public virtual async Task<IHttpActionResult> PutByName(string name, [FromBody]TEntity delta)
        {
            using (Logging.MethodCall<TEntity>(GetType(), new ParameterList { { "name", name }, { "delta", delta } }))
            {
                try
                {
                    Logging.Verbose("Updating {id} {@delta}", name, delta);
                    if (!ModelState.IsValid)
                    {
                        Logging.Error("ModelState.Invalid {ModelStateErrors}", ModelStateErrors);
                        return BadRequest(ModelState);
                    }
                    if (name != delta.Name)
                    {
                        Logging.Error("{name} Name not same", name);
                        return BadRequest($"{name} Name not same");
                    }
                    if (!IsEntityOk(delta, false))
                    {
                        Logging.Error("{delta.Name} invalid", delta);
                        return BadRequest($"{delta.Name} invalid");
                    }
                    var item = await GetQuery().Where(i => i.Name == name).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        Logging.Error("{name} not found", name);
                        return NotFound();
                    }
                    try
                    {
                        //Logging.Verbose("Loaded {@item}", item);
                        Mapper.Map(delta, item);
                        //Logging.Verbose("Mapped delta {@item}", item);
                        SetEntity(ref item, false);
                        Logging.Verbose("Set {@item}", item);
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var validationErrors = GetValidationErrors(ex);
                        Logging.Exception(ex, "Unable to update {Name} {EntityValidationErrors}", item.Name, validationErrors);
                        return BadRequest($"Unable to update {item.Name} EntityValidationErrors: {string.Join("; ", validationErrors)}");
                    }
                    catch (DbUpdateException ex)
                    {
                        Logging.Exception(ex, "Unable to update {name}", name);
                        return BadRequest(ex.Message);
                    }
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to update {name}", name);
                    throw;
                }
            }
        }
        */

        /// <summary>
        /// Delete a TEntity by Id
        /// </summary>
        /// <param name="id">The Id of the TEntity</param>
        [HttpDelete]
        [ResponseType(typeof(void))]
        //[Route("{id:guid}")] Required in derived classes
        public virtual async Task<IHttpActionResult> DeleteById(Guid id)
        {
            using (Logging.MethodCall<TEntity>(GetType(), new ParameterList { { "Id", id } }))
            {
                try
                {
                    Logging.Verbose("Deleting {id}", id);
                    var item = await GetQuery().Where(i => i.Id == id).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        Logging.Error("{id} not found", id);
                        return NotFound();
                    }
                    try
                    {
                        db.Set<TEntity>().Remove(item);
                        Logging.Verbose("Delete {@item}", item);
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var validationErrors = GetValidationErrors(ex);
                        Logging.Exception(ex, "Unable to delete {id} {EntityValidationErrors}", item.Id, validationErrors);
                        return BadRequest($"Unable to delete {item.Id} EntityValidationErrors: {string.Join("; ", validationErrors)}");
                    }
                    catch (DbUpdateException ex)
                    {
                        Logging.Exception(ex, "Unable to delete {id}", id);
                        return BadRequest(ex.Message);
                    }
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to delete {id}", id);
                    throw;
                }
            }
        }

        /*
        /// <summary>
        /// Delete a TEntity by Name
        /// </summary>
        /// <param name="name">The Name of the TEntity</param>
        [HttpDelete]
        [ResponseType(typeof(void))]
        //[Route] Required in derived classes
        public virtual async Task<IHttpActionResult> DeleteByName(string name)
        {
            using (Logging.MethodCall<TEntity>(GetType(), new ParameterList { { "Name", name } }))
            {
                try
                {
                    Logging.Verbose("Deleting {name}", name);
                    var item = await GetQuery().Where(i => i.Name == name).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        Logging.Error("{name} not found", name);
                        return NotFound();
                    }
                    try
                    {
                        db.Set<TEntity>().Remove(item);
                        Logging.Verbose("Delete {@item}", item);
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var validationErrors = GetValidationErrors(ex);
                        Logging.Exception(ex, "Unable to delete {Name} {EntityValidationErrors}", item.Name, validationErrors);
                        return BadRequest($"Unable to delete {item.Name} EntityValidationErrors: {string.Join("; ", validationErrors)}");
                    }
                    catch (DbUpdateException ex)
                    {
                        Logging.Exception(ex, "Unable to delete {name}", name);
                        return BadRequest(ex.Message);
                    }
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to delete {name}", name);
                    throw;
                }
            }
        }
        */
    }
}

