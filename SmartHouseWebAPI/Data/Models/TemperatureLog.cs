using System;

namespace SmartHouseWebAPI.Data.Models
{
    public class TemperatureLog
    {
        public long Id { get; set; }
        public double Teperature { get; set; }
        public DateTime Date { get; set; }
    }
}
