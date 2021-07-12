using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.

        /// <summary>
        /// Hold a list of catering item objects
        /// </summary>
        

        public List<CateringItem> GenerateInventory()
        {
            List<CateringItem> cateringItems = new List<CateringItem>();
        string filePath = @"C:\Catering\cateringsystem.csv";

            //ensure no out of range exception
            
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {

                    while (reader.EndOfStream == false)
                    {
                        string line = reader.ReadLine();

                        //private List<CateringItem> items = new List<CateringItem>();
                        string[] menuItems = line.Split("|");
                        
                        string cateringItemNum = menuItems[0];
                        string cateringItemName = menuItems[1];
                        decimal cateringItemPrice = Decimal.Parse(menuItems[2]);
                        
                        cateringItems.Add(new CateringItem(cateringItemNum, cateringItemName, cateringItemPrice));

                    }
                  
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(filePath + " does not exist!");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Encountered an error working with " + filePath + ": " + ex.Message);
            }


            return cateringItems;


        }
        
        
        


        

        

    }
}
