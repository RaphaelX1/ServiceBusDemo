using Microsoft.AspNetCore.Mvc;
using ServiceBus.Models;
using ServiceBus.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.API.Controllers
{
    [Route("v1/queue")]
    [ApiController]
    public class QueueController: Controller
    {
        public readonly QueueSenderService _queueService;
        public QueueController(QueueSenderService queueService)
        {
            _queueService = queueService;
        }

        [HttpPost]
        [Route("send")]
        [SwaggerOperation(OperationId = "6d1d59ac-6072-4c25-96bb-4f17588e425c")]
        public async Task<IActionResult> SendMessageAsync(Usuario usuario) 
        {
            try
            {
                await _queueService.SendMessageAsync(usuario);
                return Ok();
            }
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}
