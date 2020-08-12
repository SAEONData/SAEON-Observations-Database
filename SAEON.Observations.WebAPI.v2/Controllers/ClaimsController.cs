﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SAEON.Observations.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Policy = Constants.ODPAuthorizationPolicy)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ClaimsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User?.Claims select new { c.Type, c.Value });
        }
    }
}
