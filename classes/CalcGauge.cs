using System;

public class CalcGauge
{
  public void Prompt(){
    
    double tS = 0;
    double tR = 0;

    //patern info
    Console.WriteLine("According to the pattern, what is the finished LENGTH of the project in INCHES (ex: 24.5)?");
    double fL = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("According to the pattern, what is the finished WIDTH of the project in INCHES (ex: 24.5)?");
    double fW = Convert.ToDouble(Console.ReadLine());

    //4x4 swatch
    Console.WriteLine("Please make a 4\" x 4\" swatch using desired needles and yarn.");
    Console.WriteLine("");
    Console.WriteLine("How many stitches per row?");                               
    int c = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("How many rows?");
    int r = Convert.ToInt32(Console.ReadLine());    

    CalcGauge.Calc(c, r, fL, fW, out tS, out tR);
    Console.WriteLine(@"
    
    Your project should have " + Math.Ceiling(tS) + " stiches and " + Math.Ceiling(tR) + " rows.");

    return;
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