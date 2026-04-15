using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob
{
    public static class StringCompressor
    {
        public static string CompressString(string inputString)
        {
            var charArray = inputString.ToCharArray();
            if (!charArray.All(c => char.IsLower(c))) throw new ArgumentException("по условию все символы в нижнем регистре");

            StringBuilder sb = new StringBuilder();

            char? prevChar = null;
            int charOccurency = 1;
            for (int i = 0; i < charArray.Length; i++) 
            {
                char currChar = charArray[i];
                if(currChar == prevChar)
                {
                    charOccurency++;
                    if (i + 1 == charArray.Length) sb.Append(charOccurency);    // последний символ
                }
                else
                {
                    if (charOccurency > 1)
                    {
                        sb.Append(charOccurency);
                        charOccurency = 1;
                    }
                    sb.Append(currChar);
                }
                prevChar = currChar;
            }
            return sb.ToString();
        }
    }
}
