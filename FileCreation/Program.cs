using System;
using System.IO;
namespace FileCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.CreateNoteFile();  
            Utility.CreateNoteFileWithAppConfigFilePath();
            //Utility utility = new Utility();
            //utility.CreateNoteFileWithJsonConfigFilePath();
            Console.ReadLine();
            
        }
    }
}
