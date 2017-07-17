using System;

namespace SmartHouseWebAPI.Data.Models
{
    public class CommandLog
    {
        public long Id { get; set; }
        public string CommandName { get; set; }
        public DateTime Date { get; set; }
    }
}
