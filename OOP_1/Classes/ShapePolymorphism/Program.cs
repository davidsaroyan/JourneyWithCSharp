namespace ShapePolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Square(5);                       
            Shape shape1 = new Circle(5);
            Shape shape2 = new Shape(5);
            Console.WriteLine($"Square area: {shape.GetArea()}");
            Console.WriteLine($"Circle area: {shape1.GetArea()}");
            Console.WriteLine($"Shape area: {shape2.GetArea()}");
        }
    }
    public class Shape
    {
        private double _area;
        public Shape()
        {
            Console.WriteLine("Base ctor working...");
        }
        public Shape(double area)
        {
            _area = area;
        }
        public virtual double GetArea()
        {                        
            return _area;
        }
    }
    public class Square : Shape 
    {
        private double _side;
        public Square(double side)
        {
            _side = side;
        }
        public override double GetArea() 
        {
            return _side * _side;
        }
    }
    public class Circle : Shape
    {
        private double _radius;
        public Circle(double radius) 
        {
            _radius = radius;
        }
        public override double GetArea() 
        {
            return _radius  * _radius * 3.14;
        }
    }
}
