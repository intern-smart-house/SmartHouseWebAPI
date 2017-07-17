using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHouseWebAPI.Data.Models;
using SmartHouseWebAPI.Data;

namespace SmartHouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TemperaturesController : Controller
    {
        private SmartHouseDbContext _context;

        public TemperaturesController(SmartHouseDbContext context)
        {
            _context = context;
        }

        // GET api/temperatures
        [HttpGet]
        public IEnumerable<TemperatureLog> Get()
        {
            return _context.TemperatureLogs.ToList();
        }

        // GET api/temperatures/5-5-2054 00:51:...
        [HttpGet("{date}")]
        public JsonResult Get(DateTime date)
        {
            return new JsonResult(_context.TemperatureLogs.Where(tl => tl.Date == date));
        }

        // POST api/temperatures
        [HttpPost]
        public void Post([FromBody]string temperature = null)
        {
            if (temperature is null)
            {
                // do nothing..
            }
            else
            {
                _context.TemperatureLogs.Add(new Data.Models.TemperatureLog() { Teperature = Convert.ToDouble(temperature), Date = DateTime.Now });
                _context.SaveChanges();
            }
        }
    }
}
