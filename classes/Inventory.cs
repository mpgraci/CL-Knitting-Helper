using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;

public class RootObject
{
    public List<Needles> needles { get; set; }
    public List<Yarn> yarn { get; set; }
}

public class Inventory {

    public void Display() {

        //loops menu
        bool showMenu = true;
        while (showMenu){
            showMenu = InvMenu();
        }

        //menu     
        static bool InvMenu(){
        Console.WriteLine(@"
            ------------------------------            

                  ***INVENTORY MENU***
            What would you like to view? (1-4):
                
            1 - Neeldes
            2 - Yarn 
            0 - Go back
            
            ------------------------------
            
            ");
            
            string menuInput;                           
            menuInput = Console.ReadLine();              
            switch (menuInput){

                case "1": //display needles
                    Console.Clear();
                    ReadJson(menuInput);                    
                    return true;
                    
                case "2": //display yarn
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
    
    public void Add() {    
        Console.WriteLine("Added");
    }

    public void Remove() {
        Console.WriteLine("Removed");
    }

    private static void ReadJson(string option) {
        
        var json = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(@"data\testInventory.json"));

        switch (option){

            case "1": //lists needles

                foreach(var i in json.needles){                    

                    foreach(var prop in i.GetType().GetProperties()) {
                        
                        Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(i, null));
                        
                    } 
                    Console.WriteLine("\n");

                }      
                return; 

            case "2": //lists yarn

                foreach(var i in json.yarn){

                    foreach(var prop in i.GetType().GetProperties()) {
                        Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(i, null));
                    }                
                    Console.WriteLine("\n");

                }        
                return;

            default:
                Console.WriteLine("default");
                return;

        }
        
    }
}