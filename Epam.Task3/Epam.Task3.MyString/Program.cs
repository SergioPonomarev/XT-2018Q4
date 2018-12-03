using System;

namespace Epam.Task3.MyString
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greetings! In this program you will see MyString class demonstration.");
            Console.WriteLine();

            Console.WriteLine("Class has three constructors.");
            Console.WriteLine("First constructor takes char array as a parameter: MyString(chars).");
            char[] chars = { 'H', 'e', 'l', 'l', 'o' };
            Console.Write("Char array has: ");

            foreach  (char ch in chars)
            {
                Console.Write(ch + ", ");
            }

            MyString myString = new MyString(chars);
            Console.WriteLine("Value of MyString instance is: " + myString);
            Console.WriteLine();

            Console.WriteLine("Second constructor takes char array from start index in array to length: MyString(char, 2, 3).");

            myString = new MyString(chars, 2, 3);
            Console.WriteLine("New value of MyString instance is: " + myString);
            Console.WriteLine();

            Console.WriteLine("Third constructor takes specified char as first parameter and integer as a count: MyString('a', 5).");
            myString = new MyString('a', 5);
            Console.WriteLine("New value of MyString instance is: " + myString);
            Console.WriteLine();

            Console.WriteLine("To get a specified char from MyString instance by index use indexer: myString[int index].");

            myString = new MyString(chars);
            Console.WriteLine("Value of MyString instance: " + myString);

            Console.WriteLine("The char form MyString instance by index 1 'myString[1]': " + myString[1]);
            Console.WriteLine();

            Console.WriteLine("Static Concat method has 4 overloads, can take as paramenters: one, two, three object instances or object array.");

            object obj = "Hi ";
            Console.WriteLine("Object instance: " + obj.ToString());

            myString = MyString.Concat(obj);
            Console.WriteLine("myString = MyString.Concat(obj): " + myString);

            object obj1 = 4;
            Console.WriteLine("Second object instance: " + obj1.ToString());

            myString = MyString.Concat(obj, obj1);
            Console.WriteLine("myString = MyString.Concat(obj, obj1): " + myString);

            object obj2 = " times";
            Console.WriteLine("Third object instance: " + obj2.ToString());

            myString = MyString.Concat(obj, obj1, obj2);
            Console.WriteLine("myString = MyString.Concat(obj, obj1, obj2): " + myString);

            object obj3 = " again";

            object[] objects =
            {
                obj,
                obj1,
                obj2,
                obj3
            };

            myString = MyString.Concat(objects);
            Console.WriteLine("myString = MyString.Concat(objects): " + myString);
            Console.WriteLine();

            Console.WriteLine("Concat method has same 4 overloads with MyString type.");
            Console.WriteLine();

            Console.WriteLine("Contains method defines if MyString instance contains another MyString instance: bool Contains(MyString value).");
            MyString ms = "times";
            Console.WriteLine("'" + myString + "' contains '" + ms + "': " + myString.Contains(ms));
            Console.WriteLine();

            Console.WriteLine("Static method MyString.Copy(MyString value) returns a copy of value instance.");

            MyString copy = MyString.Copy(myString);
            Console.WriteLine("Value of myString: " + myString);
            Console.WriteLine("Value of copy: " + copy);
            Console.WriteLine("Object.ReferenceEquals(myString, copy): " + object.ReferenceEquals(myString, copy));
            Console.WriteLine();

            char[] destination = new char[4];
            myString.CopyTo(5, destination, 0, 4);
            Console.WriteLine("Void CopyTo(int sourceIndex, char[] destintion, int destionationIndex, int count) copies specified part of chars in MyString instance to char array.");
            Console.Write("After 'myString.CopyTo(5, destination, 0, 4)' destination array contents: ");
            foreach (char ch in destination)
            {
                Console.Write(ch + ", ");
            }

            Console.WriteLine();


        }
    }
}
