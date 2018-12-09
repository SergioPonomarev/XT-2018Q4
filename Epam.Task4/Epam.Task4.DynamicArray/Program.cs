using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DynamicArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Greetings! This is Dynamic Array Demonstrating Program.");
            Console.WriteLine();

            Console.WriteLine("There is three constractors to create a Dynamic Array collection.");
            Console.WriteLine();

            Console.WriteLine("First one with no parameters creates a collection with default 8 elements capacity - new DynamicArray<T>().");
            var da = new DynamicArray<int>();
            Console.WriteLine($"Let's create one for integers and see{Environment.NewLine}length - number of elements contained: {da.Length}{Environment.NewLine}and capacity - total number of elements the internal data structure can hold without resizing: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine($"To add an element there is a method Add(T). Let's add 10 elements to existing dynamic array and print them{Environment.NewLine}to console using foreach operator. The capacity will duplicates automatically:");

            for (int i = 0; i < 10; i++)
            {
                da.Add(i + 1);
            }

            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"The length now is: {da.Length} and the capacity is: {da.Capacity}");
            Console.WriteLine();

            var dinArrStrings = new DynamicArray<string>(5);
            Console.WriteLine($"Second constructor takes as a parameter an integer to set initial capacity.{Environment.NewLine}Let's create one with strings as type-parameter: length - {dinArrStrings.Length}, capacity - {dinArrStrings.Capacity}.");
            Console.WriteLine("Now let's add some string objects and print it to console:");
            dinArrStrings.Add("This");
            dinArrStrings.Add("is");
            dinArrStrings.Add("Dynamic");
            dinArrStrings.Add("Array");
            dinArrStrings.Add("!");

            foreach (string item in dinArrStrings)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"The length now is: {dinArrStrings.Length} and the capacity is: {dinArrStrings.Capacity}");
            Console.WriteLine();

            Console.WriteLine("Third constructor takes a IEnumerable<T> collection as a parameter.");
            Console.WriteLine("Let's create a List<int> with 20 numbers and use it as a parameter:");

            List<int> list = new List<int>(20);
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(i + 11);
            }

            Console.Write("List<int> contains: ");
            foreach (int item in list)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();

            var anotherDa = new DynamicArray<int>(list);

            Console.Write("Dynamic array contains: ");
            foreach (int item in anotherDa)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Length: {anotherDa.Length}, capacity: {anotherDa.Capacity}");
            Console.WriteLine();

            Console.WriteLine("There is another method to add elements named AddRange which takes IEnumerable<T> collection as a parameter and adds all its elements to the end.");
            Console.WriteLine("Let's add one Dynamic array to another.");
            da.AddRange(anotherDa);

            Console.Write("Now first Dynamic array contains: ");
            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {da.Length}, capacity: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine("To remove specified element there is a method Remove(T item). Returns true if success and false if not.");
            Console.WriteLine($"Removing number 10: {da.Remove(10)}");
            Console.Write("Dynamic array contains: ");
            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {da.Length}, capacity: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine("Also there is a void method to remove element by index RemoveAt(int index). Let's remove element by index 18.");
            da.RemoveAt(18);
            Console.Write("Dynamic array contains: ");
            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {da.Length}, capacity: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine("Capacity property not only gets but also set the capacity of the Dynamic array.");
            Console.WriteLine("Setting the capacity less than items in the collection will cause a loss of elements.");
            da.Capacity = 20;
            Console.Write("Dynamic array contains: ");
            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {da.Length}, capacity: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine("To insert an element in the collection there is Insert(int index, T item) method. Returns true if success.");
            Console.WriteLine($"Inserting number 10 to 9th index: {da.Insert(9, 10)}");
            Console.Write("Dynamic array contains: ");
            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {da.Length}, capacity: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine("Using the indexer it is possible to get or change element.");
            Console.WriteLine("Changing 19th element to 20: da[19] = 20,");
            Console.WriteLine("and last element to 21 using negative index: da[-1] = 21.");
            da[19] = 20;
            da[-1] = 21;
            Console.Write("Dynamic array contains: ");
            foreach (int item in da)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {da.Length}, capacity: {da.Capacity}");
            Console.WriteLine();

            Console.WriteLine($"There is ICloneable interface implemented so it is possible to copy the collection:{Environment.NewLine}anotherDa = (DynamicArray<int>)da.Clone();");
            anotherDa = (DynamicArray<int>)da.Clone();
            Console.Write("Dynamic array anotherDa contains: ");
            foreach (int item in anotherDa)
            {
                Console.Write($"{item.ToString()} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lenth: {anotherDa.Length}, capacity: {anotherDa.Capacity}");
            Console.WriteLine();

            Console.WriteLine($"And finally there is the ToArray() method to copy elements from Dynamic array to regular array:{Environment.NewLine}int[] array = da.ToArray()");
            int[] array = da.ToArray();
            Console.Write("Array contains: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i].ToString()} ");
            }

            Console.WriteLine();
        }
    }
}
