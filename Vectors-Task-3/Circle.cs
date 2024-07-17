
namespace CircleCollision
{
    public class Circle(double radius, Point origin, string name)
    {

        double Radius { get; set; } = radius;
        string Name { get; set; } = name;
        Point origin = origin;

        public void Print()
        {
            Console.WriteLine($"CIRCLE: {Name} ");
            Console.WriteLine("ORIGIN:");
            origin.Print();
            Console.WriteLine($"RADIUS: {Radius}");

        }

        public static string CheckCollision2Circles(Circle A, Circle B)
        {

            double distance = Point.DistanceBetween2Points(A.origin, B.origin);

            System.Console.WriteLine($"Distance {distance}");

            double r1Minusr2 = ((A.Radius - B.Radius) < 0) ? (A.Radius - B.Radius) * -1 : (A.Radius - B.Radius);

            double r1Plusr2 = A.Radius + B.Radius;

            if (distance == r1Plusr2)
            {
                return "Both Circles Touch Externally";

            }
            else if (r1Minusr2 < distance && distance < r1Plusr2)
            {
                return "Both Circles Touch at 2 Points";

            }
            else if (distance == A.Radius)
            {
                return "Circle B's origin lies on Circles A's Circumference";
            }
            else if (distance == B.Radius)
            {
                return "Circle A's origin lies on Circles B's Circumference";

            }
            else if (distance == 0)
            {
                return "Circles are concenteric AKA have same origin";
            }
            else if(distance==r1Minusr2)
            {
                return "Circles Touch Internally";
            }
            else
            {
                return "Circles do not overlap at all";
            }




        }



    }


}
