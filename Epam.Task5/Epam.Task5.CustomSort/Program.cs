using System;

namespace Epam.Task5.CustomSort
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greetings! This is Custom Sort Demonstrating Program.");
            Console.WriteLine();

            Console.WriteLine($"CustomSort generic method takes an array as the first parameter{Environment.NewLine}and the method to compare via delegate Func<T, T, int> as the second parameter.");
            Console.WriteLine();

            Console.WriteLine($"Let's create an array of Person instances. Person class has two properties:{Environment.NewLine}string typed for Name and int typed for Age.");
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

            Console.WriteLine("Person array elements:");
            ConsolePrintPersonArray(people);

            Console.WriteLine($"First, let's sort people array by Age using CompareByAge static method as the second parameter:{Environment.NewLine}CustomSort(people, CompareByAge).");

            CustomSort(people, CompareByAge);

            Console.WriteLine("Person array elements after sorting:");
            ConsolePrintPersonArray(people);

            Console.WriteLine($"Now let's sort it by Name using CompareByName static method as the second parameter:{Environment.NewLine}CustomSort(people, CompareByName).");

            CustomSort(people, CompareByName);

            Console.WriteLine("Person array elements after sorting:");
            ConsolePrintPersonArray(people);

            Console.WriteLine("Also it is possible to use a lambda expression as the second parameter.");
            Console.WriteLine("Let's create an array of integers.");

            int[] nums = { 1, 5, 2, 6, -4, 6, 9, 3, 2, 7 };

            Console.Write("Integer array elements: ");
            ConsolePrintIntArray(nums);

            Console.WriteLine("Now sort it using lambda expression:");
            Console.WriteLine(@"CustomSort(nums, (n1, n2) =>
            {
                if (n1 < n2) return -1;
                else if (n1 > n2) return 1;
                else return 0;
            });");

            CustomSort(
                nums, 
                (n1, n2) =>
                {
                    if (n1 < n2)
                    {
                        return -1;
                    }
                    else if (n1 > n2)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                });

            Console.Write("Integer array elements: ");
            ConsolePrintIntArray(nums);
        }

        private static void CustomSort<T>(T[] arr, Func<T, T, int> compareMethod)
        {
            CustomSort(arr, 0, arr.Length - 1, compareMethod);
        }

        private static void CustomSort<T>(T[] arr, int l, int r, Func<T, T, int> compareMethod)
        {
            int i = l;
            int j = r;
            T x = arr[l + ((r - l) / 2)];

            while (i <= j)
            {
                while (compareMethod(arr[i], x) < 0)
                {
                    i++;
                }

                while (compareMethod(arr[j], x) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                CustomSort(arr, l, j, compareMethod);
            }

            if (i < r)
            {
                CustomSort(arr, i, r, compareMethod);
            }
        }

        private static void ConsolePrintPersonArray(Person[] arr)
        {
            foreach (Person p in arr)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
        }

        private static void ConsolePrintIntArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write($"{num.ToString()} ");
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
