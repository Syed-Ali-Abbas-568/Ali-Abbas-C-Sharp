namespace Task1
{
    public class Vector
    {
        public double Force { get; private set; }
        public double AngleInRadians { get; private set; }
        public double AngleInDegrees {get; private set;}
        public string Name { get; private set; }
        public double HorizontalComponent { get; private set; }
        public double VerticalComponent { get; private set; }

        public Vector(double force, double angleInDegrees, string name)
        {
            Force = force;
            AngleInDegrees=angleInDegrees;
            // Convert angle to radians since Math library uses radians to perform calculations
            double angleInRadians = angleInDegrees * (Math.PI / 180);
        
            AngleInRadians = angleInRadians;
            Name = name;

            HorizontalComponent = Math.Cos(angleInRadians) * force;
            VerticalComponent = Math.Sin(angleInRadians) * force;
        }

        public void Print()
        {
            Console.WriteLine($"Vector: {Name} FORCE={Force} ANGLE={AngleInDegrees} degrees");
            Console.WriteLine($"Horizontal Component={HorizontalComponent} Vertical Component={VerticalComponent}");
        }
    }
}
