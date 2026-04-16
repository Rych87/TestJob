using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob.Logger
{
    public class Logger
    {
        public void TransformLog(string path)
        {
            string inputStr = File.ReadAllText(path);
            if (TryTransformLog(inputStr, out string result))
            {
                string name = Path.GetFileNameWithoutExtension(path);
                string extension = Path.GetExtension(path);
                File.WriteAllText($"{name}_transformed.{extension}", result); 
            }
            else
            {
                File.WriteAllText("problems.txt", inputStr);
            }

        }

        public bool TryTransformLog(string input, out string result)
        {
            LogReader[] readers = new LogReader[] {new LogReaderFormat1(), new LogReaderFormat2()};
            
            var logInfo = readers.Select(r => r.Read(input)).FirstOrDefault(r => r.Success);

            if (logInfo != null)
            {
                var lw = new LogWriter();
                result = lw.WriteLog(logInfo.LogModel);
                return true;
            }

            result = input;
            return false;
        }
    }
}
