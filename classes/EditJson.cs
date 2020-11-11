using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RootObject
{
    public List<Needles> needles { get; set; }
    public List<Yarn> yarn { get; set; }
}

public class EditJson
{
    private static string jsonLocation = "data\\Inventory.json"; 

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
                return;                
        }        
    }
}