using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class LogWriter
    {

        public void GenerateLogEntry(string entry)
        {
        
            string path = @"C:\Users\Student\source\team1-c-sharp-purple-week04-pair-exercises\module-1_Mini-Capstone\Log.txt";

            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(DateTime.Now + " " + entry);
                        
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Could not write to " + path + ": " + ex.Message);
                }


                // PART 1 - Writing to a File


            }
        }
    }
}
                

            
            

   
