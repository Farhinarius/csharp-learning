using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Workspace.Learning.Basics.Resources;

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
            
            // compile error without specification of value
            // int myInt;
            // Console.WriteLine($"Value of var myInt is {myInt} and type of {myInt.GetType()}");
            
            int defaultInt = default;
            Console.WriteLine($"Value of var defaultInt is {defaultInt} and type of {defaultInt.GetType()}");
            
            // use case of internal standard constructor
            var allocatedInt = new int();
            Console.WriteLine($"Value of var allocatedInt is {allocatedInt} and type of {allocatedInt.GetType()}");
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
            
            if ( bool.TryParse("True", out bool b) )
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

        public static void WorkWithStringBuilder()
        {
            StringBuilder sb = new StringBuilder(128);
            sb.Append("This is line");
            Console.WriteLine(sb);
            sb.Replace("is", "the");
            Console.WriteLine(sb);
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

        public static void BasicSwitchUsage()
        {
            while (Enum.TryParse(Console.ReadLine(), out DaysOfWeek favDay))
            {
                switch (favDay)
                {
                    case DaysOfWeek.Sunday:
                        Console.WriteLine("Day of the Sun has become");
                        break;
                    case DaysOfWeek.Monday:
                        Console.WriteLine("Here we go again");
                        break;
                    case DaysOfWeek.Tuesday:
                        Console.WriteLine("Mo money mo problems");
                        break; 
                    case DaysOfWeek.Wednesday:
                        Console.WriteLine("It's ok");
                        break;
                    case DaysOfWeek.Thursday:
                        Console.WriteLine("Work hard, play hard");
                        break;
                    case DaysOfWeek.Friday:
                        Console.WriteLine("Today was a good day");
                        break;
                    case DaysOfWeek.Saturday:
                        Console.WriteLine("Date night, big night, Sa-tur-day night!!!");
                        break;
                }
            }
            
            Console.WriteLine("Wrong input of the day!!!");
        }
        
        public static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.Write("Please choose an option: ");
            string userChoice = Console.ReadLine();
            object choice;
            
            // Стандартный оператор switch, в котором применяется
            // сопоставление с образцом с константами
            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = 5;
                    break;
            }
            
            // Новый оператор switch, в котором применяется
            // сопоставление с образцом с типами
            switch (choice)
            {
                case int i:
                    Console.WriteLine("Your choice is an integer.");
                    break;
                case string s:
                    Console.WriteLine("Your choice is a string.");
                    break;
                case double d:
                    Console.WriteLine("Your choice is a double.");
                    break;
                default:
                    Console.WriteLine("Your choice is something else");
                    break;
            }
            Console.WriteLine();
        }

        public static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Please pick your language preference: ");
            object langChoice = Console.ReadLine();
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;
            
            switch (choice)
            {
                case int i when i == 2:
                case string s when s.Equals("VB",
                    StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                case int i when i == 1:
                case string s when s.Equals("C#",
                    StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    break;
            }
            Console.WriteLine();
        }

        public static void BrandNewSwitchWithRainbow()
        {
            Console.WriteLine("Input color:");
            var colorBand = Console.ReadLine();
            
            var colorValue = colorBand switch
            {
                "Red" => "#FF0000",
                "Orange" => "#FF7F00",
                "Yellow" => "#FFFF00",
                "Green" => "#00FF00",
                "Blue" => "#OOOOFF",
                "Indigo" => "#4B0082",
                "Violet" => "#9400D3",
                _ => "#FFFFFF"
            } ;
            
            Console.WriteLine(colorValue);
        }

        public static void ArrayOfObjects()
        {
            Console.WriteLine("=> Array of Objects.");
            
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form & Void";
            foreach (object obj in myObjects)
            {
                Console.WriteLine("Type; {0}, Value: {1}", obj.GetType(), obj);
            }
            Console.WriteLine();
        }
        
        public static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Rectangular multidimensional array.");
            int[,] myMatrix;
            myMatrix = new int[3,4];
            
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    myMatrix[i, j] = i * j;
                }
            }
            
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(myMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");

            int[][] myJagArray = new int[5][];
            for (int i = 0; i < myJagArray.Length; i++)
            {
                myJagArray[i] = new int[i + 7];
            }
            
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < myJagArray[i].Length; j++)
                {
                    Console.Write(myJagArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void IndexAndRangesExample()
        {
            var gothicBands = new string[] { "ra", "papa", "atatata" };
            
            for (int i = 0; i < gothicBands.Length; i++)
            {
                Index idx = i;
                Console.Write(gothicBands[idx] + ", ");
            }
            
            for (int i = 1; i <= gothicBands.Length; i++)
            {
                Index idx = ^i;     // gothicBands.Length - i (i cannot be 0)
                Console.Write(gothicBands[idx] + ", ");
            }
            
            foreach (var itm in gothicBands[0..2])
            {
                Console.Write(itm + ", ");
            }
            Console.WriteLine("\n");

            Range r = 0..2;
            foreach (var itm in gothicBands[r])
            {
                Console.Write(itm + ", ");
            }
            Console.WriteLine("\n");
        }

    }
}