using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationsDashboard.Common;
using ServiceStack.Redis;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ServerMapping")]
    public class ServerMappingController : Controller
    {
        [HttpGet]
        public IEnumerable<ServerMappingEntry> Get()
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var RedisContext = RedisConnection.As<ServerMappingEntry>();
                return RedisContext.GetAll();
            }
        }
    }
}