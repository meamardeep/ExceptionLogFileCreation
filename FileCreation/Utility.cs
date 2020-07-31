using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace FileCreation
{
    static class Utility
    {      
      
        public static void CreateNoteFile()
        {
            bool isNoteFileCreated = false;
            //List<string> logicalDrives = new List<string>();
            //logicalDrives = Directory.GetLogicalDrives().ToList();

            //switch (drive)
            //{
            //    case eDrive:
            //         isNoteFileCreated = CreateNoteFileInSpecificDrive(drive);
            //        break;
            //    case dDrive:
            //        isNoteFileCreated = CreateNoteFileInSpecificDrive(drive);
            //        break;

            //    default:
            //        break;
            //}

            if (isNoteFileCreated == false)
            {
                isNoteFileCreated = CreateNoteFileInSpecificDrive(ConfigurationManager.AppSettings["gDriveLog"], "Amar");
            }
            else if (isNoteFileCreated == false)
            {
                isNoteFileCreated = CreateNoteFileInSpecificDrive(ConfigurationManager.AppSettings["eDriveLog"],"Amar");
            }
            else if ( isNoteFileCreated == false)
            {
                isNoteFileCreated = CreateNoteFileInSpecificDrive(ConfigurationManager.AppSettings["dDriveLog"],"Amar");
            }
        }

        private static bool CreateNoteFileInSpecificDrive(string drivePath, string message)
        {
            string LogDirectoryPath = @drivePath; //+ ConfigurationManager.AppSettings["LogFoler"];

            if (!Directory.Exists(LogDirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(LogDirectoryPath);
                }
                catch (Exception ex)
                {
                    return false;

                }
            }

            string NoteFilePath = LogDirectoryPath + "\\NoteFile" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".txt";
            StreamWriter writer = new StreamWriter(NoteFilePath);
            writer.WriteLine(message);

            writer.Close();           
            return true;
        }

        internal static void CreateNoteFileWithAppConfigFilePath()
        {           
            string noteFilePath =  ConfigurationManager.AppSettings["NoteFilePath"];
            StreamWriter writer = new StreamWriter(noteFilePath);
            writer.WriteLine("Amardeep's Message ");

            writer.Close();
        }



        public static void CreateNoteFileWithJsonConfigFilePath()
        {
            string noteFilePath = _configuration.GetSection("NoteFilePathWithJson").Value.ToString();
            StreamWriter writer = new StreamWriter(noteFilePath);
            writer.WriteLine("Amardeep's Message ");

            writer.Close();
        }
    }

    
}
