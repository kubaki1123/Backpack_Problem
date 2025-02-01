using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Plecak
{
    struct Data
    {
        public string przedmiot;
        public double waga;
        public int punkty;

    }

    internal class Read_file
    {

        public List<Data> read() {
            try
            {
                const string path = @"C:\\Users\\kplew\\OneDrive\\Pulpit\\Plecak\\backpack.txt";
                List<Data> input_data = new List<Data>();
                string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                Data temp_data = new Data();
                string[] buf_string = new string[3];
                buf_string = lines[i].Split('\t'); 


                temp_data.przedmiot = buf_string[0];
                temp_data.waga = Convert.ToDouble(buf_string[1]);       //c# jako zmienno przecinkowych nie uzywa 2.2 tylko 2,2
                temp_data.punkty = Convert.ToInt32(buf_string[2]);
                    
                input_data.Add(temp_data);

            }
                
                return input_data;
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("brak dostepu do pliku");
                Environment.Exit(1);
                return null;
            }
        }

    }
    
}


