using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;

namespace CSI124Lecture16_AssignmentReadCSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<VidioGameSystem> systems = new List<VidioGameSystem>();
        public MainWindow()
        {
            InitializeComponent();
           // PreloadVidioGames();
            //ReadFileNoHelper();
            //ReadFileHelper();
            // ReadFullList();

            /* foreach(VidioGameSystem vidioGameSystem in systems)
             {
                 runDisplay.Text += vidioGameSystem + "\n";
             }*/
        }

        //What does .csv stand for? Comma Separated Values
        //What package do we use to help import CSV files? He have been using CSV helper
        //What keyword do we use when reading and saving to files?
        //Using a user to make sure that our file streams are closed
        //What's the different between FileMode.Append and FileMode.OpenOrCreate?
        //We can use such code to open or create file and then write
        //some data into it (all contents will be replaced).
        //It's wise to save your file locations in a Static class so
        //that all files can access the same file locations.

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile(FileMode.OpenOrCreate);
        }

        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile(FileMode.Append);
        }
        private void btnSaveVideoGame_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }

        private void btnLoadGameSystem_Click(object sender, RoutedEventArgs e)
        {
            ReadFullList();
            DisplayVideoGames();
        }

        public void DisplayVideoGames()
        {
            runDisplay.Text = "";
            foreach(VidioGameSystem gameSystem in systems)
            {
                runDisplay.Text += gameSystem + "\n";
            }
        }
       

        #region Save File


        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = FilePaths.videoGameFilePath;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(systems);
                writer.Flush();
            }
        } // SaveList

        public void SaveToFile(FileMode mode)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            // Append - Continue to add to our code

            using (var stream = File.Open(FilePaths.studentFilePath, mode))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {

                // Grabbing text from first name, saving it as a field
                csvWriter.WriteField(txtFirstName.Text);
                // Grabbing grade and saving as a second field
                csvWriter.WriteField(txtLastName.Text);
                // Grabbing grade and saving as a second field
                csvWriter.WriteField(txtGrade.Text);
                // Going to next record
                csvWriter.NextRecord();
                //// flushing writer
                writer.Flush();
            }
            MessageBox.Show("File was saved");
        }

        #endregion

        #region Read File
        // Read back a full list , as a type
        public void ReadFullList()
        {
            string filePath = FilePaths.videoGameFilePath;

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                // Pull the entire csv file as a list of VideoGameSystem
               
               systems = csv.GetRecords<VidioGameSystem>().ToList<VidioGameSystem>();
            }

        }

        // Read a csv WITH CSVHelper
        public void ReadFileHelper()
        {
            string filePath = FilePaths.filePath;
            CultureInfo info = CultureInfo.InvariantCulture;

            double average = 0;
            int count = 0;

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, info))
            {
                while (csv.Read())
                {
                    count++;

                    string firstName = csv.GetField(0);
                    string lastName = csv.GetField(1);
                    int grade = csv.GetField<int>(2);

                    average += grade;

                    runDisplay.Text += $"{count} : First Name: {firstName} - Last Name: {lastName} \n";

                }

                runDisplay.Text += $"Average Grade: {average / count}";
            }
        }

        //Reading CVS file without the Helper
        public void ReadFileNoHelper()
        {
           // string mainDirectory = Directory.GetCurrentDirectory();
            //string fileName = @"/Class_data.csv";
           // string filePath = mainDirectory + fileName;
            // Using StreamReader
            using (StreamReader sr = new StreamReader(FilePaths.filePath))
            { // Opens connection to file

                // Runs until the end of the file
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // returns a line as a string
                    string[] split = line.Split(",");

                    // How we are formatting how the line is displayed
                    foreach (string field in split)
                    {
                        runDisplay.Text += field + " ";
                    }
                    runDisplay.Text += "\n";
                }
            } // Closes connection to file

        } // ReadFileNoHelper()

        #endregion

        public void PreloadVidioGames()
        {
            systems.Add(new VidioGameSystem()
            {
                Company = "Sony",
                SystemName = "Playstation 5",
                Storage = "Blu Ray",
                InventoryCount = 10000

            });

            systems.Add(new VidioGameSystem("Nintendo", "N64", "Catridge", 1888));
            systems.Add(new VidioGameSystem("Nintendo", "Gamecube", "Mini CD", 1888));
            systems.Add(new VidioGameSystem("Sega", "Dreamcast", "Dvd", 1888));
        }
    }
}
