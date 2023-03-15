using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI124Lecture16_AssignmentReadCSV
{
    internal class FileLocation_Ex
    {
        private static string projectLocation = Directory.GetCurrentDirectory();
        private static string folder = @"\DataExample\";
        private static string dataExamplefile = @"example_data.csv";

        public static string dataExample = projectLocation + folder + dataExamplefile;

        static FileLocation_Ex()
        {

        }

    }
}
