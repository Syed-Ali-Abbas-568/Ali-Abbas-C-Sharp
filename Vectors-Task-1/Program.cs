using System;

namespace Task1
{

    public class Driver
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to C# TASK1");
            Console.WriteLine("Ali and Amir are Both Pulling at force 30N and 25N respectively");
            Console.WriteLine("Angle Between Ali and Amir is 46 Degrees");
            Console.WriteLine("How Much force should Usman pull with to take the toy away?");

            Vector Ali = new Vector(30, 46 / 2, "Ali");
            Vector Amir = new Vector(25, -46 / 2, "Amir");

            Ali.Print();
            Amir.Print();

            double totalHorizontalComponent = Ali.HorizontalComponent + Amir.HorizontalComponent;
            double totalVerticalComponent = Ali.VerticalComponent + Amir.VerticalComponent;

            

            Console.WriteLine($"Amount of Force required by Usman should be greater than {totalHorizontalComponent}");

            Vector Usman = new Vector(totalHorizontalComponent, 0, "Usman");
            Usman.Print();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Driver.Start();
        }
    }
}
