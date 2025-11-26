namespace StructPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 2 points x, y coordinate");
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            var distance = distanceOfPoints(p1,p2);
            Console.WriteLine($"distance from ({x1},{y1}) to ({x2},{y2}) is {distance:F2}");
        }
        public struct Point
        {
            public int x; 
            public int y;
            public Point(int x, int y) 
            {
                this.x = x;
                this.y = y;
            }
        }
        public static double distanceOfPoints(Point p1, Point p2)
        {
            int x = p1.x - p2.x;
            int y = p1.y - p2.y;
            double distance = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2)); 
            return distance;
        }
    }
}
