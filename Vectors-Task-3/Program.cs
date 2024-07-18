

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Formats.Asn1;
using System.IO;


namespace CircleCollision
{

    public class Driver
    {
        // This class ensures the functionality of collision detection

        public void Start()
        {   Console.Clear();
            Console.WriteLine("Welcome to Circle Collision Detector");

            Console.WriteLine("Input Circle A's Position:");
            Point OriginA = new Point(Helper.GetInputDouble("INPUT X:"), Helper.GetInputDouble("INPUT Y:"));
            Circle A = new Circle(Helper.EnsureValidRadiusInput("A"), OriginA, "A");

            Console.WriteLine("Input Circle B's Position:");

            Point OriginB = new Point(Helper.GetInputDouble("INPUT X:"), Helper.GetInputDouble("INPUT Y:"));
            Circle B = new Circle(Helper.EnsureValidRadiusInput("B"), OriginB, "B");


            Console.Clear();
            A.Print();
            Console.WriteLine();
            B.Print();
            Console.WriteLine();

            Console.WriteLine("NOW CHECKING FOR COLLISION:");
            Console.WriteLine(Circle.CheckCollision2Circles(A, B));

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Driver app = new Driver();
            app.Start();

        }

    }


}
