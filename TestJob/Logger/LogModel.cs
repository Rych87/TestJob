using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob.Logger
{
    public class LogInfo
    {
        public bool Success { get; set; } = false;
        public LogModel LogModel { get; set; }
    }

    public enum Level
    {
        INFO,
        WARN, 
        ERROR,
        DEBUG
    }

    public class LogModel
    {
        public DateTime DateTime { get; set; }
        public Level Level { get; set; }

        public string Caller { get; set; } = "DEFAULT";

        public string Message { get; set; } = string.Empty;
    }
}
