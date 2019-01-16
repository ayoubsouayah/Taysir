using formation.Context;
using formation.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace formation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientController:ControllerBase
    {
        private readonly EspaceClientContext appContext;

        public ClientController(EspaceClientContext appContext)
        {
            this.appContext = appContext;

        }
        [HttpGet]
        public ActionResult Get()
        {
            var clients = appContext.Clients.Where(i=>i.Id>0).ToList();
            return Ok(clients);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Client client)
        {
            appContext.Clients.Add(client);
            appContext.SaveChanges();
            return Created("/api/client/"+client.Id, client);
        }
        [HttpPut]
        public ActionResult Put([FromBody]Client client)
        {
            appContext.Clients.Attach(client);
            appContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var client = new Client();
            client.Id = id;
            appContext.Clients.Attach(client);
            appContext.Clients.Remove(client);
            int rows=appContext.SaveChanges();
            if(rows>0)
            {
               return Ok("deleted");
            }
            return Ok("no rows affected");
            
        }
    }
}
