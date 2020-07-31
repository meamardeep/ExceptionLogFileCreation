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
        const string eDrive = "E:\\";
        const string dDrive = "D:\\";
        const string cDrive = "C:\\";

        static string dDriveLogPath = "D:\\Logs";
        static string eDriveLogPath = "D:\\Logs";

        public static void CreateLogFile()
        {
            bool isLogFileCreated = false;
            List<string> logicalDrives = new List<string>();
            logicalDrives = Directory.GetLogicalDrives().ToList();

            foreach (var drive in logicalDrives)
            {
                switch (drive)
                {
                    case eDrive:
                        isLogFileCreated = CreateNoteFileInSpecificDrive(eDriveLogPath, "message");
                        break;
                    case dDrive:
                        isLogFileCreated = CreateNoteFileInSpecificDrive(dDriveLogPath, "message");
                        break;

                    default:
                        break;
                }
                if (isLogFileCreated == true)
                {
                    return;
                }
            }
        }

        private static bool CreateNoteFileInSpecificDrive(string logDirectoryPath, string message)
        {
            if (!Directory.Exists(@logDirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(@logDirectoryPath);
                }
                catch (Exception ex)
                {
                    return false;

                }
            }

            string logFilePath = @logDirectoryPath + "\\NoteFile" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".txt";
            StreamWriter writer = new StreamWriter(logFilePath);
            writer.WriteLine(message);
            writer.Close();

            return true;
        }

        internal static void CreateNoteFileWithAppConfigFilePath()
        {
            string noteFilePath = ConfigurationManager.AppSettings["NoteFilePath"];
            StreamWriter writer = new StreamWriter(noteFilePath);
            writer.WriteLine("Amardeep's Message ");
            writer.Close();
        }



        //public static void CreateNoteFileWithJsonConfigFilePath()
        //{
        //    string noteFilePath = _configuration.GetSection("NoteFilePathWithJson").Value.ToString();
        //    StreamWriter writer = new StreamWriter(noteFilePath);
        //    writer.WriteLine("Amardeep's Message ");

        //    writer.Close();
        //}
    }


}
