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
            Console.WriteLine($"Value of MyString instance is: {myString}");
            Console.WriteLine();

            Console.WriteLine("Second constructor takes char array from start index in array to length: MyString(char, 2, 3).");

            myString = new MyString(chars, 2, 3);
            Console.WriteLine($"New value of MyString instance is: {myString}");
            Console.WriteLine();

            Console.WriteLine("Third constructor takes specified char as first parameter and integer as a count: MyString('a', 5).");
            myString = new MyString('a', 5);
            Console.WriteLine($"New value of MyString instance is: {myString}");
            Console.WriteLine();

            Console.WriteLine("To get a specified char from MyString instance by index use indexer: myString[int index].");

            myString = new MyString(chars);
            Console.WriteLine($"Value of MyString instance: {myString}");

            Console.WriteLine($"The char form MyString instance by index 1 'myString[1]': {myString[1]}");
            Console.WriteLine();

            Console.WriteLine("Static Concat method has 4 overloads, can take as paramenters: one, two, three object instances or object array.");

            object obj = "Hi ";
            Console.WriteLine($"Object instance: {obj.ToString()}");

            myString = MyString.Concat(obj);
            Console.WriteLine($"myString = MyString.Concat(obj): {myString}");

            object obj1 = 4;
            Console.WriteLine($"Second object instance: {obj1.ToString()}");

            myString = MyString.Concat(obj, obj1);
            Console.WriteLine($"myString = MyString.Concat(obj, obj1): {myString}");

            object obj2 = " times";
            Console.WriteLine($"Third object instance: {obj2.ToString()}");

            myString = MyString.Concat(obj, obj1, obj2);
            Console.WriteLine($"myString = MyString.Concat(obj, obj1, obj2): {myString}");

            object obj3 = " again";

            object[] objects =
            {
                obj,
                obj1,
                obj2,
                obj3
            };

            myString = MyString.Concat(objects);
            Console.WriteLine($"myString = MyString.Concat(objects): {myString}");
            Console.WriteLine();

            Console.WriteLine("Concat method has same 4 overloads with MyString type.");
            Console.WriteLine();

            Console.WriteLine("Contains method defines if MyString instance contains another MyString instance: bool Contains(MyString value).");
            MyString ms = "times";
            Console.WriteLine($"'{myString}' contains '{ms}': {myString.Contains(ms)}");
            Console.WriteLine();

            Console.WriteLine("Static method MyString.Copy(MyString value) returns a copy of value instance.");

            MyString copy = MyString.Copy(myString);
            Console.WriteLine($"Value of myString: {myString}");
            Console.WriteLine($"Value of copy: {copy}");
            Console.WriteLine($"Object.ReferenceEquals(myString, copy): {object.ReferenceEquals(myString, copy)}");
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
            Console.WriteLine();

            Console.WriteLine("EndsWith method serves to find out if MyString instance ends with another MyString instance: bool EndsWith(value).");
            Console.WriteLine($"Value of myString: {myString}");
            MyString addString = "again";
            Console.WriteLine($"Value of addString: {addString}");
            Console.WriteLine($"myString ends with addString - myString.EndsWith(addString): {myString.EndsWith(addString)}");
            Console.WriteLine();

            Console.WriteLine("There is three overloads for IndexOf method:");
            Console.WriteLine($"int IndexOf(char) - myString.IndexOf('i'): {myString.IndexOf('i')}");
            Console.WriteLine($"int IndexOf(char, startIndex) - myString.IndexOf('i', 5): {myString.IndexOf('i', 5)}");
            Console.WriteLine($"int IndexOf(char, startIndex, count) - myString.IndexOf('i', 7, 4): {myString.IndexOf('i', 7, 4)}");
            Console.WriteLine();

            Console.WriteLine("Three overloads for IndexOf method taking MyString instance as a parameter:");
            Console.WriteLine($"myString.IndexOf(addString): {myString.IndexOf(addString)}");
            Console.WriteLine($"myString.IndexOf(addString, 11): {myString.IndexOf(addString, 11)}");
            Console.WriteLine($"myString.IndexOf(addString, 10, 5): {myString.IndexOf(addString, 10, 5)}");
            Console.WriteLine();

            Console.WriteLine("There is three overloads for IndexOfAny method taking char array as a parameter to search:");
            chars = new char[] { 't', 'H', 'i'};
            Console.Write("Char array named 'chars' has: ");
            foreach (char ch in chars)
            {
                Console.Write(ch + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"myString.IndexOfAny(chars): {myString.IndexOfAny(chars)}");
            Console.WriteLine($"myString.IndexOfAny(chars, 3): {myString.IndexOfAny(chars, 3)}");
            Console.WriteLine($"myString.IndexOfAny(chars, 7, 5): {myString.IndexOfAny(chars, 7, 5)}");
            Console.WriteLine();

            Console.WriteLine("Insert method takes an integer as a start index and MyString value to insert to calling MyString instance. Reternes new MyString instance:");
            MyString insertMS = "again ";
            Console.WriteLine($"Value to insert: '{insertMS}'");
            myString = myString.Insert(11, insertMS);
            Console.WriteLine($"myString = myString.Insert(11, insertMS): {myString}");
            Console.WriteLine();

            Console.WriteLine("There is three overloads for LastIndexOf method:");
            Console.WriteLine($"myString.LastIndexOf('g'): {myString.LastIndexOf('g')}");
            Console.WriteLine($"myString.LastIndexOf('g', 16): {myString.LastIndexOf('g', 16)}");
            Console.WriteLine($"myString.LastIndexOf('g', 16, 3): {myString.LastIndexOf('g', 16, 3)}");

            Console.WriteLine("Three overloads for LastIndexOf method taking MyString instance as a parameter:");
            Console.WriteLine($"myString.LastIndexOf(addString): {myString.LastIndexOf(addString)}");
            Console.WriteLine($"myString.LastIndexOf(addString, 11): {myString.LastIndexOf(addString, 16)}");
            Console.WriteLine($"myString.LastIndexOf(addString, 10, 5): {myString.LastIndexOf(addString, 16, 5)}");
            Console.WriteLine();

            Console.WriteLine("There is three overloads for LastIndexOfAny method taking char array as a parameter to search:");
            Console.Write("Char array named 'chars' has: ");
            foreach (char ch in chars)
            {
                Console.Write(ch + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"myString.LastIndexOfAny(chars): {myString.LastIndexOfAny(chars)}");
            Console.WriteLine($"myString.LastIndexOfAny(chars, 3): {myString.LastIndexOfAny(chars, 3)}");
            Console.WriteLine($"myString.LastIndexOfAny(chars, 7, 5): {myString.LastIndexOfAny(chars, 7, 5)}");
            Console.WriteLine();

            Console.WriteLine("Remove method has two overloads - remove from start index to end of MyString instance and remove from start count chars. Reterns new MyString instance:");
            myString = myString.Remove(10, 6);
            Console.WriteLine($"myString = myString.Remove(10, 6): '{myString}'");
            myString = myString.Remove(10);
            Console.WriteLine($"myString = myString.Remove(10): '{myString}'");
            Console.WriteLine();

            Console.WriteLine("There is two overloads for Replace method - first replaces old char for new char int whole MyString instance ind second replaces old MyString value to new MyString value. Returns new MyString instance:");
            myString = "Hi bi mi bi";
            Console.WriteLine($"Value of myString: '{myString}'");
            myString = myString.Replace('i', 'e');
            Console.WriteLine($"Value after myString = myString.Replace('i', 'e'): '{myString}'");
            MyString oldValue = "be";
            Console.WriteLine($"MyString instance to be changed (oldValue): '{oldValue}'");
            MyString newValue = "big";
            Console.WriteLine($"MyString instance which is to replace the old value (newValue): '{newValue}'");
            myString = myString.Replace(oldValue, newValue);
            Console.WriteLine($"After myString = myString.Replace(oldValue, newValue): '{myString = myString.Replace(oldValue, newValue)}'");

            Console.WriteLine("StartsWith method defines if MyString instance starts with specified MyString value:");
            MyString startsWith = "He";
            Console.WriteLine($"MyString instance to compare 'startWith' named: '{startsWith}'");
            Console.WriteLine($"myString.StartsWith(startsWith): {myString.StartsWith(startsWith)}");
            Console.WriteLine();

            Console.WriteLine("There is two overloads for SubMyString method - from start index to end of MyString instance and from start index to count. Returns new MyString instance:");
            Console.WriteLine($"myString.SubMyString(3): '{myString.SubMyString(3)}'");
            Console.WriteLine($"myString.SubMyString(3, 3): '{myString.SubMyString(3, 3)}'");
            Console.WriteLine();

            Console.WriteLine($"ToLower method returns new MyString instance with all lower case chars: '{myString.ToLower()}'");
            Console.WriteLine($"And ToUpper method with all upper case chars: '{myString.ToUpper()}'");
            Console.WriteLine();

            Console.WriteLine($"ToCharArray method returns char array with all chars form MyString instance: chars = myString.ToCharArray(){chars = myString.ToCharArray()}");
            Console.Write("Chars array consists of: ");
            foreach (char ch in chars)
            {
                Console.Write(ch + ", ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("There is implicit casts from MyString to string, from string to MyString, from MyString to StringBuilder, from StringBuilder to MyString.");
            Console.WriteLine();

            Console.WriteLine("Also ToString(), GetHashCode() overrided methods, IEquatable<MyString>, IComparable<MyString> and IComparable implementation, '==' and '!=' operatiors.");

            MyString ms1 = "Hello";
            MyString ms2 = "Hello";
            Console.WriteLine($"MyString instance named ms1: '{ms1}'");
            Console.WriteLine($"MyString instance named ms2: '{ms2}'");
            Console.WriteLine($"Object.ReferenceEquals(ms1, ms2): {object.ReferenceEquals(ms1, ms2)}");
            Console.WriteLine($"ms1.Equals(ms2): {ms1.Equals(ms2)}");
            Console.WriteLine();
        }
    }
}
