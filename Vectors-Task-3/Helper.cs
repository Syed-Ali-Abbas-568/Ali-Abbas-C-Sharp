
namespace CircleCollision
{
    public static class Helper
    {
        public static bool ValidateRadius(double radius)
        {
            if (radius > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("ERROR: Invalid Raidus. The Radius must be greater than equal to zero.");
                return false;
            }
        }
        public static double GetInputDouble(string message)
        {
            Console.Write(message);
            double.TryParse(Console.ReadLine(), out double input);
            return input;
        }

        public static double EnsureValidRadiusInput(string name)
        {
            double input;
            do
            {
                input = GetInputDouble($"Please Input {name}'s Radius:");
            }
            while (!ValidateRadius(input));
            return input;

        }
    }


}
