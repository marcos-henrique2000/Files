using System;
using System.IO;
using System.Globalization;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\mac1005\source\repos\Files\vendidos.csv";
            
            StreamReader sr = null;

            try
            {
                sr = File.OpenText(sourcePath);
                var sep = Path.DirectorySeparatorChar;
                var path = Path.GetDirectoryName(sourcePath);
                
                Directory.CreateDirectory(path + sep + "out");

                string targetPath = path + sep + "out" + sep + "sumary.csv";

                using(StreamWriter sw = File.AppendText(targetPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string info = sr.ReadLine();

                        string[] doc = info.Split(",");

                        string product = doc[0];
                        double price = double.Parse(doc[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(doc[2]);

                        double total = quantity * price;

                        sw.WriteLine($"{product},{total.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }

            }catch(IOException e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
//https://github.com/acenelio/files1-csharp/blob/master/Course/Program.cs