using System;

public class CalcGauge
{
  public void Prompt()
  {
    
    double tS = 0;
    double tR = 0;

    //patern info
    Console.WriteLine("According to the pattern, what is the finished LENGTH of the project in INCHES (ex: 24.5)?");
    string fL = Console.ReadLine();
    while (!double.TryParse(fL, out double result))
    {
        Console.WriteLine("Please enter a valid length in inches (10, 10.5, etc)");            
        fL = Console.ReadLine();                
    }
  
    Console.WriteLine("According to the pattern, what is the finished WIDTH of the project in INCHES (ex: 24.5)?");
    string fW = Console.ReadLine();
    while (!double.TryParse(fW, out double result))
    {
        Console.WriteLine("Please enter a valid width in inches (10, 10.5, etc)");            
        fW = Console.ReadLine();                
    }    

    //4x4 swatch
    Console.WriteLine("Please make a 4\" x 4\" swatch using desired needles and yarn.");
    Console.WriteLine("");
    Console.WriteLine("How many stitches per row?");                               
    string c = Console.ReadLine();
    while (!int.TryParse(c, out int result))
    {
        Console.WriteLine("Please enter a WHOLE NUMBER for # of stitches");            
        c = Console.ReadLine();                
    }    
    
    Console.WriteLine("How many rows?");
    string r = Console.ReadLine();
    while (!int.TryParse(r, out int result))
    {
        Console.WriteLine("Please enter a WHOLE NUMBER for # of rows");            
        r = Console.ReadLine();                
    }
    
    CalcGauge.Calc(Convert.ToInt32(c), Convert.ToInt32(r), Convert.ToDouble(fL), Convert.ToDouble(fW), out tS, out tR);
    Console.WriteLine(@"
    
    Your project should have " + Math.Ceiling(tS) + " stiches and " + Math.Ceiling(tR) + " rows.");

    Console.WriteLine("\nWould you like to calculate another gauge? (y/n)");
    string again = Console.ReadLine();    
    switch (again)
    {
        case "y":            
            Prompt();
            return;
        case "n":
            return;
        default:
            Console.WriteLine("\nThat wasn't a valid input. Press any key to return to main menu");      
            Console.ReadKey();                          
            return;
    }
  }

  //c = stitches
  //r = rows
  //fL = finished length
  //fW = finished width
  //tS = total stitches
  //tR = total rows
  private static void Calc(int c, int r, double fL, double fW, out double tS, out double tR) {
    
    tS = (c/4)*fW;
    tR = (r/4)*fL;    
    
  }
}