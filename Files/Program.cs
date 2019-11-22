using System;
using System.IO;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\mac1005\source\repos\Files\file1.txt";
            string targetPath = @"C:\Users\mac1005\source\repos\Files\file2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach(string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }



            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }


        }
    }
}
