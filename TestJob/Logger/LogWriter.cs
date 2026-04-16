using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob.Logger
{
    internal class LogWriter
    {
        public string WriteLog(LogModel model)
        {
            StringBuilder sb = new StringBuilder();

            string date = model.DateTime.ToString("dd-mm-yyyy");
            string time = model.DateTime.TimeOfDay.ToString().TrimEnd('0');

            sb.AppendJoin("\t", date, time, model.Level, model.Caller, model.Message);
            return sb.ToString();
        }
    }
}
