using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI124Lecture16_AssignmentReadCSV
{
    public static class FilePaths
    {
        // Gotten our file location
        static string mainDirectory = Directory.GetCurrentDirectory();
        static string folder = @"\InClassExample\";

        static string fileName = @"class_data.csv";
        static string videoGameSytemFileName = @"videoGameSystemdata.csv";
       public static string studentFileName = @"student_Data.csv";


        public static string filePath = mainDirectory + folder + fileName;
        public static string videoGameFilePath = mainDirectory + folder + videoGameSytemFileName;
        public static string studentFilePath = mainDirectory + folder + studentFileName;
        internal static string vidioGameFilePath;

    }
   
}
