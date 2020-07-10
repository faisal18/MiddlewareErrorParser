using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareErrorParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> files = GetAllFiles();
            if (files.Count > 0)
            {
                foreach (string file in files)
                {
                    Console.WriteLine("Working on file " + Path.GetFileNameWithoutExtension(file));
                    ParsebyFilePath(file);
                }
            }
            else
            {
                Console.WriteLine("Log files not found");
            }
            Console.WriteLine("Program Executed Successfully");
            Console.Read();
        }

        public static List<string> GetAllFiles()
        {
            List<string> list_files = new List<string>();
            try
            {
                Console.WriteLine("Enter logs folder path");
                string path = Console.ReadLine();
                string[] files = Directory.GetFiles(path);

                if(files.Count()>0)
                {
                    list_files = files.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list_files;
        }
        public static bool ParsebyFilePath(string path)
        {
            bool result = false;
            try
            {

                string[] lines =  File.ReadAllLines(path);
                StringBuilder sb = new StringBuilder();

                for (int i = 1; i < lines.Count(); i++) 
                {
                    if(lines[i].Contains("| ERROR |"))
                    {
                        Console.WriteLine("Working on line number " + i);
                        if(i == 7202)
                        {

                        }
                        //capture i+1 and i-1 and i

                        if(lines.ElementAtOrDefault(i-1) != null)
                        {
                            sb.Append(lines[i-1]+"\n");
                        }

                        if (lines.ElementAtOrDefault(i) != null)
                        {
                            sb.Append(lines[i] + "\n");
                        }

                        if (lines.ElementAtOrDefault(i+1) != null)
                        {
                            sb.Append(lines[i + 1] + "\n");
                        }
                    }
                }
                Writefile(sb.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.Read();
            }
            return result;
        }

        private static void Writefile(string data)
        {
            try
            {
                string path = @"C:\tmp\Middlewarelogs\logs.csv";
                using (StreamWriter wrtier = File.AppendText(path))
                {
                    wrtier.Write(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.Read();

            }
        }
    }
}
