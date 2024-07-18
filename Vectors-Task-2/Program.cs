using System;




// Three friends, Alice, Bob, and Charlie, are pulling a sled together. 
// Alice pulls with a force of 40N at an angle of 30 degrees from the horizontal,
// Bob pulls with a force of 50N at an angle of 60 degrees from the horizontal,
// and Charlie pulls with a force of 60N at an angle of 120 degrees from the horizontal. 
// Determine the resultant force and its direction.

namespace Task2
{

    class Program
    {
        static void Main(string[] args)
        {
            // VECTORS FOR ALICE BOB AND CHARLIE
            Vector Alice = new Vector(40, 30, "Alice");
            Vector Bob = new Vector(50, 60, "Bob");
            Vector Charlie = new Vector(60, 120, "Charlie");


            Alice.Print();
            Bob.Print();
            Charlie.Print();

            // Calculate resultant Horizontal and verticel and magnitude
            double resultantHorizontal = Alice.HorizontalComponent + Bob.HorizontalComponent + Charlie.HorizontalComponent;
            double resultantVertical = Alice.VerticalComponent + Bob.VerticalComponent + Charlie.VerticalComponent;


            double resultantForce = Math.Sqrt(resultantHorizontal * resultantHorizontal + resultantVertical * resultantVertical);

            // Calculatign the angle of the resulant vector
            double resultantAngleInRadians = Math.Atan2(resultantVertical, resultantHorizontal);

            double resultantAngleInDegrees = resultantAngleInRadians * (180 / Math.PI);


            Vector Resultant = new Vector(resultantForce, resultantAngleInDegrees, "Resultant");

            Resultant.Print();
        }
    }
}
