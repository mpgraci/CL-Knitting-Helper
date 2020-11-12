using System;
using System.IO;

namespace CL_Knitting
{
    class Program
    {
        static void Main(string[] args)
        {

            //checks if inventory file exists and creates it
            string path = @"data\inventory.json";
            if (!File.Exists(path))
            {
                using (var inv = new StreamWriter(path, true))
                {
                    inv.WriteLine("{\"needles\": [],  \"yarn\": []}");
                }
            }
            

            //introS
            Console.WriteLine(@"
            
            ***Welcome to Knitting Helper!***");

            //loops menu
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }           
        }

        //menu
        private static bool MainMenu()
        {
            Inventory Inv = new Inventory();
            CalcGauge Calc  = new CalcGauge();
            
            //initial prompt
            Console.Clear();
            Console.WriteLine(@"
               ------------------------------       

                     ***MAIN MENU***
               Please select an option:
                
               1 - View inventory
               2 - Edit inventory
               3 - Check Guage
               0 - Exit
            
             ------------------------------
            
            ");
            string menuInput;                           
            menuInput = Console.ReadLine();              
            switch (menuInput)
            {
                case "1": //display inventory
                    Console.Clear();
                    Inv.Display();                    
                    return true;
                case "2": //edit inventory
                    Console.Clear();
                    Inv.Edit();
                    return true;
                case "3": //calcgauge
                    Console.Clear();
                    Calc.Prompt();
                    return true;
                case "0": //exit
                    Console.Clear();
                    Console.WriteLine("Goodbye!\n");
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a 1, 2 ,3 or 0...");
                    return true;
            }                        
        }
    }
}
