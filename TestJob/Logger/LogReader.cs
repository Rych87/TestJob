using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob.Logger
{
    internal abstract class LogReader
    {
        internal abstract LogInfo Read(string inputString);
        protected bool TryParseLevel(string str, out Level level)
        {
            level = default;
            if (Enum.TryParse<Level>(str, out Level ret))
            {
                level = ret;
                return true;
            }
            else
            {
                switch (str)
                {
                    case "INFORMATION": level = Level.INFO; return true;
                    case "WARNING": level = Level.WARN; return true;
                    default: return false;
                }

            }
        }
    }

    internal class LogReaderFormat1 : LogReader
    {
        internal override LogInfo Read(string inputString)
        {
            LogInfo logInfo = new LogInfo();

            string[] lines = inputString.Split(' ');
            LogModel logModel = new LogModel();

            if (!DateTime.TryParse(string.Join(" ",lines.Take(2)), out DateTime dateTime))
                return logInfo;
            logModel.DateTime = dateTime;

            if(!TryParseLevel(lines[2], out Level level))
                return logInfo;
            logModel.Level = level;

            logModel.Message = string.Join(" ", lines.Skip(3));

            logInfo.LogModel = logModel;
            logInfo.Success = true;

            return logInfo;
        }
    }

    internal class LogReaderFormat2 : LogReader
    {
        internal override LogInfo Read(string inputString)
        {
            LogInfo logInfo = new LogInfo();

            string[] lines = inputString.Split('|');
            LogModel logModel = new LogModel();

            if (!DateTime.TryParse(lines[0], out DateTime dateTime))
                return logInfo;
            logModel.DateTime = dateTime;

            if (!TryParseLevel(lines[1], out Level level))
                return logInfo;
            logModel.Level = level;

            logModel.Caller = lines[2];

            logModel.Message = lines[3];

            logInfo.LogModel = logModel;
            logInfo.Success = true;

            return logInfo;
        }
    }
}
