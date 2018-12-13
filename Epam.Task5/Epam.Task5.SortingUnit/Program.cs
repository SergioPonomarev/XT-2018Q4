using System;
using Epam.Task5.CustomSort;

namespace Epam.Task5.SortingUnit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Greetings! This is The Sorting Unit demonstration program.");
            Console.WriteLine();

            Person[] people =
            {
                new Person { Name = "Masha", Age = 10 },
                new Person { Name = "Maria", Age = 11 },
                new Person { Name = "Yan", Age = 39 },
                new Person { Name = "Oxana", Age = 41 },
                new Person { Name = "Sergey", Age = 33 },
                new Person { Name = "Tatiana", Age = 66 },
                new Person { Name = "Sofia", Age = 27 },
                new Person { Name = "Anton", Age = 33 },
                new Person { Name = "Andrey", Age = 33 },
                new Person { Name = "Dmitriy", Age = 34 },
                new Person { Name = "Svetlana", Age = 34 },
                new Person { Name = "Artem", Age = 9 },
                new Person { Name = "Vasiliy", Age = 32 },
                new Person { Name = "Ksenia", Age = 22 }
            };

            Console.WriteLine("Here is an array of Person instances:");

            ConsolePrintPersonArray(people);

            Console.WriteLine($"Let's create a SortingUnit<Person> instance:{Environment.NewLine}SortingUnit<Person> su = new SortingUnit<Person>();");
            Console.WriteLine();

            SortingUnit<Person> su = new SortingUnit<Person>();

            Console.WriteLine($"Add a listener to the End of sorting event:{Environment.NewLine}su.EndOfSorting += PrintSortingEvent;");
            Console.WriteLine();

            su.EndOfSorting += PrintSortingEvent;

            Console.WriteLine($"Run sorting comparing by Age in additional thread:{Environment.NewLine}su.RunSortInNewThread(people, CompareByAge);");
            Console.WriteLine();
            
            su.RunSortInNewThread(people, CompareByAge);

            Console.WriteLine($"Define the moment of thread ending:{Environment.NewLine}su.SortingUnitThread.Join();");
            Console.WriteLine();

            su.SortingUnitThread.Join();

            Console.WriteLine("And print the array again:");
            ConsolePrintPersonArray(people);
        }

        private static void PrintSortingEvent(object sender, SortingUnitEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Sorting time: {e.TimePerformance}");
            Console.WriteLine();
        }

        private static void ConsolePrintPersonArray(Person[] arr)
        {
            foreach (Person p in arr)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
        }

        private static int CompareByName(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return 0;
            }

            if (ReferenceEquals(p1, null))
            {
                return -1;
            }

            if (ReferenceEquals(p2, null))
            {
                return 1;
            }

            int min = p1.Name.Length < p2.Name.Length
                ? p1.Name.Length
                : p2.Name.Length;

            for (int i = 0; i < min; i++)
            {
                if (p1.Name[i] < p2.Name[i])
                {
                    return -1;
                }

                if (p1.Name[i] > p2.Name[i])
                {
                    return 1;
                }
            }

            if (p1.Name.Length < p2.Name.Length)
            {
                return -1;
            }
            else if (p1.Name.Length > p2.Name.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static int CompareByAge(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return 0;
            }

            if (ReferenceEquals(p1, null))
            {
                return -1;
            }

            if (ReferenceEquals(p2, null))
            {
                return 1;
            }

            if (p1.Age < p2.Age)
            {
                return -1;
            }
            else if (p1.Age > p2.Age)
            {
                return 1;
            }
            else
            {
                return CompareByName(p1, p2);
            }
        }
    }
}
