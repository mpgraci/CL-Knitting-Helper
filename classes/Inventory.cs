using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RootObject
{
    public List<Needles> needles { get; set; }
    public List<Yarn> yarn { get; set; }
}

public class Inventory {

    private static string jsonLocation = "data\\inventory.json"; 
    private static string logLocation = "data\\log.txt";

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
                        ReadJson(menuInput);
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

                        string size = Console.ReadLine();
                        while (!double.TryParse(size, out double result))
                        {
                            Console.WriteLine("Please enter a valid needle size (10, 10.5, etc)");            
                            size = Console.ReadLine();                
                        }
                        
                        Console.WriteLine("What type of needles are they? (straight, ciruclar, etc)");
                        string type = Console.ReadLine();

                        Console.WriteLine("What material are they made from? (wood, metal, etc)");        
                        string material = Console.ReadLine();

                        WriteJson(Convert.ToDouble(size), type, material);
                        return true;
                        
                        
                    case "2": //addes yarn
                        Console.Clear();                    
                        Console.WriteLine("What color is the yarn?");
                        string color = Console.ReadLine();

                        Console.WriteLine("What weight is the yarn? (bulky, light, etc)");
                        string weight = Console.ReadLine();

                        Console.WriteLine("What is the length of the yarn? (in yards)");        
                        
                        string length = Console.ReadLine();
                        while (!double.TryParse(length, out double result))
                        {
                            Console.WriteLine("Please enter a valid length in yards (10, 10.5, etc)");            
                            length = Console.ReadLine();                
                        }

                        WriteJson(color, weight, Convert.ToDouble(length));
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

                        if (ReadJson(menuInput))
                        {
                            Console.WriteLine("Please enter the id # of the item you wish to remove");   
                            id = Console.ReadLine();

                            while (!int.TryParse(id, out int result))
                                {
                                Console.WriteLine("Please enter a valid id # (1, 2, etc)");            
                                id = Console.ReadLine();                
                                }

                            Console.WriteLine("Are you sure? (y/n)");       
                            confirm = Console.ReadLine();

                            switch (confirm)
                            {
                                case "y":
                                    DeleteJson(menuInput, id);
                                    return true;
                                case "n":
                                    return true;
                                default:
                                    Console.WriteLine("That wasn't a valid input, aborting removal of items");                                    
                                    return false;
                            }
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

    //manipulates json file
    public static bool ReadJson(string menuInput) 
    {        
        var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));
        
        if (json != null)
        {
            switch (menuInput){

                case "1": //lists needles
                    if (json.needles != null && json.needles.Count > 0)
                    {
                        foreach(var i in json.needles){                    

                            foreach(var prop in i.GetType().GetProperties()) {
                                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(i, null));
                            } 
                            Console.WriteLine("\n");
                        }      
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry! You don't have any needles in your inventory.");
                        return false;
                    } 

                case "2": //lists yarn
                    if (json.yarn != null && json.yarn.Count > 0)
                    {
                        foreach(var i in json.yarn)
                        {
                            foreach(var prop in i.GetType().GetProperties()) {
                                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(i, null));
                            }                
                            Console.WriteLine("\n");
                        }        
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry! You don't have any yarn in your inventory.");
                        return false;
                    } 

                default:
                    Console.WriteLine("That's not a 1 or 2....");
                    
                    return false;
            }        
        }
        else
        {
            Console.WriteLine("Sorry! You don't have anything in your inventory.");
            return false;
        }
    }
    
    public static void WriteJson(double size, string type, string material)
    {
        var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));        
        int highestID = 0;

        foreach(var i in json.needles)
        {
            if (i.id > highestID) {
                highestID = i.id;                
            }
            else {
                break;
            }     
        }               
        
        json.needles.Add(new Needles()
        {
            id = highestID + 1,
            size = size,
            type = type,
            material = material
        });

        string json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
        File.WriteAllText(jsonLocation, json1);
        File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item added Needles");
    }

    public static void WriteJson(string color, string weight, double length)
    {
        var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));        
        
        int highestID = 0;
        foreach(var i in json.yarn)
        {
            if (i.id > highestID) {
                highestID = i.id;                
            }                       
        }

        Yarn yarn = new Yarn{
            id = highestID + 1,
            color = color,
            weight = weight,
            length = length
        };

       json.yarn.Add(new Yarn()
        {
            id = highestID + 1,
            color = color,
            weight = weight,
            length = length
        });

        string json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
        File.WriteAllText(jsonLocation, json1);
        File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item added to Yarn");
    }

    public static void DeleteJson(string menuInput, string id)
    {
        var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(jsonLocation));        
        string json1 = "";

        switch (menuInput) 
        {
            case "1":                
                foreach (var i in json.needles)
                {
                    if (i.id ==  Convert.ToInt32(id))
                    {
                        json.needles.Remove(i);
                        Console.WriteLine("Item Removed");
                        break;
                    }
                }

                json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
                File.WriteAllText(jsonLocation, json1);
                File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item removed from Needles");
            return;                

            case "2":                
                foreach (var i in json.yarn)
                {
                    if (i.id ==  Convert.ToInt32(id))
                    {
                        json.yarn.Remove(i);
                        Console.WriteLine("Item Removed");
                        break;
                    }
                }

                json1 = JsonConvert.SerializeObject(json, Formatting.Indented);
                File.WriteAllText(jsonLocation, json1);
                File.AppendAllText(logLocation, Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Item removed from Yarn");
                return;                
        }        
    }
}