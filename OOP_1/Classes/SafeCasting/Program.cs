namespace SafeCasting
{
    using System;
    using System.Collections.Generic;

    namespace SafeCasting
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Shape> shapes = new List<Shape>
            {
                new Square(5),
                new Circle(5),
                new Square(3),
                new Circle(2)
            };

                foreach (Shape shape in shapes)
                {
                    Console.WriteLine($"Area: {shape.GetArea()}");

                    if (shape is Square square)
                    {
                        Console.WriteLine($"This is a Square with side {square.Side}");
                    }
                    else if (shape is Circle circle)
                    {
                        Console.WriteLine($"This is a Circle with radius {circle.Radius}");
                    }

                    Console.WriteLine();
                }
            }
        }

        public abstract class Shape
        {
            public abstract double GetArea();
        }

        public class Square : Shape
        {
            public double Side { get; }

            public Square(double side)
            {
                Side = side;
            }

            public override double GetArea()
            {
                return Side * Side;
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }
    }

}
