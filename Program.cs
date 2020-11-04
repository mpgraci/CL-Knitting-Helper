using System;
using System.IO;

namespace CL_Knitting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
            
            ***Welcome to Knitting Helper!***");
            bool showMenu = true;
            while (showMenu){
                showMenu = MainMenu();
            }            
        }

        private static bool MainMenu(){
            
            Inventory Inv = new Inventory();
            CalcGauge Calc  = new CalcGauge();

            //initial prompt
            Console.WriteLine(@"
            ------------------------------            

            Please select an option (1-4):
                
            1) Check inventory
            2) Add to inventory
            3) Check Guage
            4) Exit
            
            ------------------------------
            
            ");
            string menuInput;                           
            menuInput = Console.ReadLine();              
            switch (menuInput){

                case "1": //display inventory
                    Inv.Display();                    
                    return true;
                case "2": //add to inventory
                    Inv.Add();
                    return true;
                case "3": //calcgauge
                    Calc.Prompt();
                    return true;
                case "4": //exit
                    Console.WriteLine("Goodbye!");
                    return false;
                default:
                    Console.WriteLine("That wasn't a 1, 2 ,3 or 4...");
                    return true;
            }                        
        }
    }
}
