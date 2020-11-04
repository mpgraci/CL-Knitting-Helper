using System;

public class CalcGauge
{
  public void Prompt(){
    
    Console.WriteLine("How many stitches per row is your 4in by 4in swatch?");
                               
    int c = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("How many rows is your 4in by 4in swatch?");

    int r = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("According to the patern, what is the finished LENGTH of the project?");

    int fL = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("According to the patern, what is the finished WIDTH of the project?");

    int fW = Convert.ToInt32(Console.ReadLine());

    int tS;
    int tR;
    CalcGauge.Calc(c, r, fL, fW, out tS, out tR);
    Console.WriteLine("Your project should have " + tS + " stiches and " + tR + " rows.");

    return;

  }

  //c = stitches
  //r = rows
  //fL = finished length
  //fW = finished width
  private static void Calc(int c, int r, int fL, int fW, out int tS, out int tR) {
    
    tS = (c/4)*fW;
    tR = (r/4)*fL;    
    
  }
}