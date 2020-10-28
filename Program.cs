using System;
using System.IO;


namespace CL_Knitting
{
    class Program
    {
        static void Main(string[] args)
        {
            //sample objects
            Needles needle1 = new Needles()
            {
                size = 10,
                type = "straight"
            };

            Yarn yarn1 = new Yarn()
            {
                color = "blue",
                weight = "bulky",
                length = 50
            };

            //initial prompt
            Console.WriteLine("Welcome to Knitting Helper! What would you like help with today? \n\n 1) Check inventory \n 2) Add to inventory \n 3) Check Guage");
        }
    }
}
