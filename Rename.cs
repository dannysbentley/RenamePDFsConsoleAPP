using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace RenamePDFSConsoleApp
{
    class Rename
    {
        private string fileName;
        private string newFileName;
        public Rename()
        {
        }

        public void setFileName(string filename)
        {
            fileName = filename;
        }

        public string getFileName()
        {
            return newFileName;
        }

        public void renamefile()
        {
            try
            {
                string input;
                var pattRegex = @"S\d.\d.*";
                var fileNameRegex = Regex.Match(fileName, pattRegex, RegexOptions.None);
                input = fileNameRegex.ToString();

                //Seattle format. 
                string renamedCorrect = ReplaceAt(input);
                newFileName = renamedCorrect;
                
            }
            catch { }
        }

        public bool IsPDFHeader(string fileName)
        {
            var pattRegex = @"\.(pdf)$";
            var fileNameRegex = Regex.Match(fileName, pattRegex, RegexOptions.None);
            if (fileNameRegex.ToString() == ".pdf")
            {
                return true;
            }
            return false;
        }

        public static string ReplaceAt(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char period = '.';
            char[] chars = input.ToCharArray();
            for(int i = 0; i < input.Length; i++)
            {
                if (!char.IsWhiteSpace(chars[i]))
                {
                    if(chars[i] == '-')
                    {
                        chars[i] = period;
                    }

                }
                else
                {
                    break;
                }
            }
            return new string(chars);
        }

    }
}
