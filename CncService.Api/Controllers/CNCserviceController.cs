using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CncService.Api.Application.Commands;
using CncService.Api.Application.Queries;
using CncService.Api.Application;
using System.Net;

namespace CncService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CNCserviceController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICNCserviceQuery query;
        
        public CNCserviceController(IMediator mediator, ICNCserviceQuery query)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<CNCservice>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CNCservice>>> GetAllCNCserviceAsync()
        {
            var services = await query.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("id={id}")]
        [ProducesResponseType(typeof(CNCservice), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CNCservice>>GetCNCserviceByIdAsync(string id)
        {
            try
            {
                var service = await query.GetByIdAsync(id);
                if (service != null)
                    return Ok(service);
                else
                    return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("granularity={id:int}")]
        [ProducesResponseType(typeof(IEnumerable<CNCservice>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CNCservice>>>GetByGranularityAsync(int id)
        {
            var services = await query.GetByGranularityAsync(id);
            return Ok(services);
        }


    }
}
