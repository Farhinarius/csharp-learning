using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Workspace.ExecutionHandler;

namespace Workspace
{
    internal static class Program
    {
        private static void Main(string[] args) =>
            Execute(ProcessBytesAnotherVers);
        
        private static void Execute(Action method) => method();

        private static void ExecuteWithLineSpace(Action method)
        {
            Console.WriteLine($"{Environment.NewLine}");
            method();
            Console.WriteLine($"{Environment.NewLine}Implementation was successful");
        }
    }
}

namespace Workspace
{
    public static class ExecutionHandler
    {
        public static void Hello()
        {
            Console.WriteLine("Hello World!");
        }

        public static void Input()
        {
            Console.WriteLine("Input string: ");
            var someString = Console.ReadLine();
            Console.Write(someString);
        }

        public static void LinqForEach()
        {
            List<string> words = new List<string>();
            words.Add("Bruce");
            words.Add("Alfred");
            words.Add("Tim");
            words.Add("Richard");

            words.ForEach(word => Console.WriteLine(word));
        }

        public static void AnomyousConstructor()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 20);

            Console.WriteLine($"P1 : {p1.X}, {p1.Y}");
            Console.WriteLine($"P2 : {p2.X}, {p2.Y}");
        }

        public static void InheritanceConstructor()
        {
            Point3D p3 = new Point3D(10, 10, 10);
        }

        public static void ParametricPolymorphism()
        {
            Point pointToDraw = new Point();
            Point.Draw(pointToDraw);
            Point.Draw(pointToDraw, 5.5f);
        }

        public static void Polymorphism()
        {
            Point p4 = new Point(10, 10);
            Point p5 = new Point3D(1, 2, 3);
        }

        public static void OverridingPolymorphism()
        {
            // Enemy.attack()       ->  virtual method of abstract class
            // Lizard.attack()      ->  override method for real class
        } 

        public static void Tuples()
        {
            (double Sum, int Count) t2 = (4.5, 3);      // (double, int) t1 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
        }

        public static void DelegateUsage()
        {
            double[] a = { 0.0, 0.5, 1.0 };
            double[] squares = DelegateExample.Apply(a, (x) => x * x);
            DelegateExample.OutputArray(squares);

            double[] sines = DelegateExample.Apply(a, Math.Sin);
            DelegateExample.OutputArray(sines);

            Multiplier m = new Multiplier(2.0);
            double[] doubles = DelegateExample.Apply(a, m.Multiply);
            DelegateExample.OutputArray(doubles);
        }

        public static void NullableValueTypes()
        {
            Point point = null;
            Point? newPoint = point;
            
            newPoint?.Show();       // show nothing

            newPoint = point ?? new Point(2, 2);
            newPoint?.Show();       // show point (2, 2)
        }

        public static void DefaultDeclarations()
        {
            Console.WriteLine("Default declarations:");
            
            int myInt = default;
            Console.WriteLine(myInt);

            var defaultInt = new int();
            Console.WriteLine(defaultInt);
        }

        public static void FormatNumericalData()
        {
            Console.WriteLine("The value 9999 in various formats: ");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            
            Console.WriteLine ( "Е format: {0:Е}", 99999);
            Console.WriteLine ("е format: {0:е}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
            
            var output = $"{99999:X}";
            Console.WriteLine(output);
        }

        public static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            
            Console.WriteLine("char.IsDigit ( 'a') : {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter ( 'a ’ ) : {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There’, 5): {0}", char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}", char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation(’?'): {0}", char.IsPunctuation('?'));
            
            Console.WriteLine();
        }
        
        public static void ParseFromStrings()
        {
            Console.WriteLine("=> Data type parsing:");
            
            bool b = bool.Parse("True");
            Console.WriteLine ("Value of b: {0} ", b) ; // Вывод значения b
            
            double d = double.Parse ("99.884") ;
            Console.WriteLine ("Value of d: {0} ", d) ; // Вывод значения d
            
            int i = int.Parse ( "8") ;
            Console.WriteLine ("Value of l: {0}", i) ; // Вывод значения i
            
            char c = Char.Parse ( "w" ) ;
            Console.WriteLine ("Value of c: {0}" , c) ; // Вывод значения с
            
            Console.WriteLine();
        }
        
        public static void ParseFromStringsWithTryParse()
        {
            Console.WriteLine ("=> Data type parsing with TryParse:");
            
            if ( bool.TryParse("True", out bool b) ) ;
            {
                Console.WriteLine("Value of b: {0}", b);
            }
            
            string value = "Hello";
            if ( double.TryParse(value, out double d) )
            {
                Console.WriteLine("Value of d: {0}", d);
            }
            else
            {
                Console.WriteLine("Failed to convert the input ({0}) to a double", value);
            }
            
            Console.WriteLine();
        }

        public static void StringAreImmutable()
        {
            var s1 = "Welcome";
            var s2 = s1;        // s1 returns copy
            s1 = "Salam";            // changes s1 but allocates new memory
            Console.WriteLine(s2);
        }
        
        public static void StringBuilderClassUsage()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }
        
        private static int Add(int b1, int b2) => b1 + b2;
        
        public static void ProcessBytes()
        {
            byte bl = 100;
            byte b2 = 250;
            try
            {
                byte sum = checked((byte) Add(bl, b2));
                Console.WriteLine("sum = {0}", sum);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static void ProcessBytesAnotherVers()
        {
            byte b1 = 250;
            byte b2 = 100;
            try
            {
                checked
                {
                    byte sum = (byte)Add(b1, b2);
                    Console.WriteLine("sum = {0}", sum);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point() {}

        public Point(int x, int y) => (X, Y) = (x, y);

        public void Show()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }
        public static void Draw(Point p)
        {
            // drawline logic with some library
        }

        public static void Draw(Point p, float thickness)
        {
            // drawline with thickness with some logic
        }
    }

    public class Point3D : Point
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
    }

    // delegate usage
    internal delegate double Function(double x);
    
    class Multiplier
    {
        double _factor;

        public Multiplier(double factor) => _factor = factor;

        public double Multiply(double x) => x * _factor;
    }

    class DelegateExample
    {
        public static double[] Apply(double[] a, Function f)
        {
            var result = new double[a.Length];
            for (int i = 0; i < a.Length; i++) 
                result[i] = f(a[i]);
            return result;
        }

        public static void OutputArray(double[] a)
        {
            foreach (var element in a)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
    }
}
