using System;

namespace Epam.Task4.CycledDynamicArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Greetings! This is Cycling Dynamic Array demonstrating program.");

            Console.WriteLine("Let's go round and round...");

            CycledDynamicArray<int> cda = new CycledDynamicArray<int>();
            for (int i = 0; i < 10; i++)
            {
                cda.Add(i);
            }

            Console.WriteLine();

            foreach (int item in cda)
            {
                Console.WriteLine(item);
            }
        }
    }
}
