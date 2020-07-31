using System;
using System.IO;
namespace FileCreation
{
    class Program
    {
        static void Main(string[] args)
        {
           // Utility.CreateLogFile();  
            Utility.CreateNoteFileWithAppConfigFilePath();
            
            //utility.CreateNoteFileWithJsonConfigFilePath();
            Console.ReadLine();
            
        }
    }
}
