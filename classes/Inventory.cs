using System;

public class Inventory {

    EditJson editjson = new EditJson();

    public void Display() {

        //loops menu
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = InvMenu();
        }

        //menu     
        static bool InvMenu()
        {
            Console.WriteLine(@"
                ------------------------------            

                    ***INVENTORY MENU***
                What would you like to view?:
                    
                1 - Neeldes
                2 - Yarn 
                0 - Go back
                
                ------------------------------
                
                ");
                
                string menuInput;                           
                menuInput = Console.ReadLine();              
                switch (menuInput)
                {
                    case "1":
                    case "2": //displays item
                        Console.Clear();
                        EditJson.ReadJson(menuInput);
                        return true;

                    case "0": //exit
                        Console.Clear();
                        return false;

                    default:
                        Console.Clear();
                        Console.WriteLine("That wasn't a 1, 2 , or 0...");                    
                        return true;
                }          
            }        
        }
    
    public void Edit()
    {
         //loops menu
        bool showMenu = true;
        while (showMenu){
            showMenu = AddMenu();
        }

        //menu     
        static bool AddMenu()
        {
            Console.WriteLine(@"
                ------------------------------            

                   ***EDIT INVENTORY***
                What would you like to do?:
                    
                1 - Add items
                2 - Remove items
                0 - Go back
                
                ------------------------------
                
                ");
                
                string menuInput;                           
                menuInput = Console.ReadLine();              
                switch (menuInput){

                    case "1": //add
                        Console.Clear();
                        Add();
                        return true;
                        
                    case "2": //remove
                        Console.Clear();
                        Remove();
                        return true;

                    case "0": //exit
                        Console.Clear();
                        return false;

                    default:
                        Console.Clear();
                        Console.WriteLine("That wasn't a 1, 2 , or 0...");                    
                        return true;
                }          
            }        
        return;
    }

    public static void Add() {    

        //loops menu
        bool showMenu = true;
        while (showMenu){
            showMenu = AddMenu();
        }

        //menu     
        static bool AddMenu()
        {
            Console.WriteLine(@"
                ------------------------------            

                   ***ADD TO INVENTORY***
                What would you like to add?:
                    
                1 - Neeldes
                2 - Yarn 
                0 - Go back
                
                ------------------------------
                
                ");
                
                string menuInput;                           
                menuInput = Console.ReadLine();              
                switch (menuInput){

                    case "1": //adds needles
                        Console.Clear();                                        
                        Console.WriteLine("What size are the needles? (US sizes)");
                        double size = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("What type of needles are they? (straight, ciruclar, etc)");
                        string type = Console.ReadLine();

                        Console.WriteLine("What material are they made from? (wood, metal, etc)");        
                        string material = Console.ReadLine();

                        EditJson.WriteJson(size, type, material);
                        return true;
                        
                    case "2": //addes yarn
                        Console.Clear();                    
                        Console.WriteLine("What color is the yarn?");
                        string color = Console.ReadLine();

                        Console.WriteLine("What weight is the yarn? (bulky, light, etc)");
                        string weight = Console.ReadLine();

                        Console.WriteLine("What is the length of the yarn? (in yards)");        
                        double length = Convert.ToDouble(Console.ReadLine());

                        EditJson.WriteJson(color, weight, length);
                        return true;

                    case "0": //exit
                        Console.Clear();
                        return false;

                    default:
                        Console.Clear();
                        Console.WriteLine("That wasn't a 1, 2 , or 0...");                    
                        return true;
                }          
            }        
        return;
    }

    public static void Remove() 
    {
        //loops menu
        bool showMenu = true;
        while (showMenu){
            showMenu = RemoveMenu();
        }

        //menu     
        static bool RemoveMenu()
        {
            string id = "";
            string confirm = "";

            Console.WriteLine(@"
                ------------------------------            

                  ***REMOVE FROM INVENTORY***
                What would you like to remove?:
                    
                1 - Needles
                2 - Yarn 
                0 - Go back
                
               ------------------------------
                
                ");                      

                string menuInput;                           
                menuInput = Console.ReadLine();              
                switch (menuInput)
                {
                    case "1":                        
                    case "2": //removes item
                        Console.Clear();                                                                

                        if (EditJson.ReadJson(menuInput))
                        {
                            Console.WriteLine("Please enter the id # of the yarn you wish to remove");   
                            id = Console.ReadLine();

                            Console.WriteLine("Are you sure? (y/n)");       
                            confirm = Console.ReadLine();

                            if (confirm == "y")
                            {
                                EditJson.DeleteJson(menuInput, id);
                            }     
                            return true;
                        }
                        else
                        {
                            return true;
                        }

                    case "0": //exit
                        Console.Clear();
                        return false;

                    default:
                        Console.Clear();
                        Console.WriteLine("That wasn't a 1, 2 , or 0...");                    
                        return true;
                }          
            }        
        return;
    }
}