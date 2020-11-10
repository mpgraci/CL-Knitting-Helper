using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Inventory {

    public List<Needles> needles { get; set; } 
    public List<Yarn> yarn { get; set; } 

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
                
            1) All
            2) Neeldes
            3) Yarn 
            4) Go back
            
            ------------------------------
            
            ");
            
            string menuInput;                           
            menuInput = Console.ReadLine();              
            switch (menuInput){

                case "1": //display all          
                    Console.Clear();
                    Console.WriteLine("Displays all items");                    
                    return true;                      
                    
                case "2": //display needles
                    Console.Clear();
                    Console.WriteLine("Displays needles");                    
                    return true;
                    
                case "3": //display yarn
                    Console.Clear();
                    Console.WriteLine("Displays yarn");                    
                    return true;

                case "4": //exit
                    Console.Clear();
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a 1, 2 , or 3...");                    
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

}