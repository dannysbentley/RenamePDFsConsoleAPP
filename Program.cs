using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RenamePDFSConsoleApp
{
    class RenameAndMove
    {
        static void Main(string[] args)
        {
            //Gets the directory path and directory to copy too.
            string sourcePath = @"C:\Users\Danny.Bentley\Documents";
            string targetPath = @"W:\S\BIM\_Current PDFs";

            //check to see if the directory exists
            //if (!(Directory.Exists(targetPath)))
            //{
            //    Console.WriteLine("This folder dose not exist");
            //}

            //Gets files from directory 
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName;
                    string destfile;

                    fileName = Path.GetFileName(s);

                    //renames the file using regular expressions 
                    Rename renameFile = new Rename();
                    bool result = renameFile.IsPDFHeader(fileName);
                    if (result == true)
                    {
                        renameFile.setFileName(fileName);

                        renameFile.renamefile();
                        string fileRename = renameFile.getFileName();

                        //sets the new name to the old name
                        string newName = fileRename;

                        Console.WriteLine("File Renamed \n" + newName);

                        //combines the new name to the directory 
                        destfile = Path.Combine(targetPath, newName);

                        //copies the files and will override the file if it already exists. 
                        File.Copy(s, destfile, true);
                    }
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist");
            }

            do
            {
                Console.WriteLine("Press x to exit >");
            }
            while (Console.ReadKey().KeyChar != 'x');
        }

        
    }
}
