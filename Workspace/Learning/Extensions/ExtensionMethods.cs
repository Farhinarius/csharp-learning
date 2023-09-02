using System;
using System.Reflection;

namespace Workspace.Learning.Extensions
{
    public static class ExtensionMethods
    {
        // Extension method overview
        // First parameter of method always is object that this method called from

        // Этот метод позволяет объекту любого типа
        // отобразить сборку, в которой он определен.
        public static void DisplayDefiningAssembly(this Object obj)
        {

            // Этот метод позволяет объекту любого типа
            // отобразить сборку, в которой он определен.
            Console.WriteLine("{0} lives here: => {1}\n",
                obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // Этот метод позволяет любому целочисленному значению изменить
        // порядок следования десятичных цифр на обратный.
        // Например, для 56 возвратится 65.
        public static int ReverseDigits(this int number)
        {
            // Транслировать int в string и затем получить все его символы.
            char[] digits = number.ToString().ToCharArray();
            // Изменить порядок следования элементов массива.
            Array.Reverse(digits);
            // Поместить обратно в строку,
            string newDigits = new string(digits);
            // Возвратить модифицированную строку как int.
            return int.Parse(newDigits);
        }
    }
}
