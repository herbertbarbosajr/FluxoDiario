﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Presentation.API.Controllers
{
    [Route("api/healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Check()
        {
            return Ok("Ping");
        }
    }
}
