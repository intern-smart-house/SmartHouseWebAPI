using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHouseWebAPI.Data.Models;
using SmartHouseWebAPI.Data;

namespace SmartHouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommandsController : Controller
    {
        private SmartHouseDbContext _context;

        public CommandsController(SmartHouseDbContext context)
        {
            _context = context;
        }

        // GET api/commands
        [HttpGet]
        public IEnumerable<CommandLog> Get()
        {
            return _context.CommandLogs.ToList();
        }

        // GET api/commands/5
        [HttpGet("{daybefore}")]
        public JsonResult Get(int daybefore)
        {
            var commandsForDate = _context.CommandLogs.Where(c => c.Date.Day == DateTime.Now.Day - daybefore).ToList();

            return new JsonResult(commandsForDate);
        }

        // POST api/commands
        [HttpPost]
        public void Post([FromBody]dynamic command = null)
        {
            if (command is null)
            {
                // do nothing..
            }
            else
            {
                _context.CommandLogs.Add(new Data.Models.CommandLog() { CommandName = command.commandName, Date = DateTime.Now });
                _context.SaveChanges();
            }
        }
    }
}
