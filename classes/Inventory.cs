using System;

public class Inventory {

    public void Add() {    
        Console.WriteLine("Added");
    }

    public void Remove() {
        Console.WriteLine("Removed");
    }

    public void Display() {

        Console.WriteLine("Displayed");
        Console.WriteLine("1) Go Back");

        string prompt = Console.ReadLine();
        int a = Int32.Parse(prompt);
        if (a == 1){
            return;
        }
        else {
            Console.WriteLine("It wasn't question, sending you back to the main menu");
        }
    }
}