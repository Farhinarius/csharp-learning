using System;
using System.Text;

namespace Workspace.Learning.Basics
{
    public static class Basics
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
            
            int i = int.Parse ("8") ;
            Console.WriteLine ("Value of l: {0}", i) ; // Вывод значения i
            
            char c = char.Parse ("w") ;
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
        
        public static void StringsAreImmutable()
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
}