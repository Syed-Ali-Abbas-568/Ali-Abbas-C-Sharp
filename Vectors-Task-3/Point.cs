
namespace CircleCollision
{
    public class Point(double X, double Y)
    {
        double X { get; set; } = X;
        double Y { get; set; } = Y;

        public void Print()
        {
            Console.WriteLine($"X={X} Y={Y}");
        }

        public static double DistanceBetween2Points(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
        }


    }


}
