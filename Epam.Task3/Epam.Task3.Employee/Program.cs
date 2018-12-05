using System;

namespace Epam.Task3.Employee
{
    internal class Program
    {
        private static bool surnameCheck;
        private static bool nameCheck;
        private static bool middleNameCheck;
        private static bool birthdayCheck;
        private static bool positionCheck;
        private static bool startWorkDateCheck;
        private static bool check;

        private static void Main(string[] args)
        {
            Employee employee = new Employee();

            Console.WriteLine("Greetings! You are using The Employee Creating Program!");
            Console.WriteLine();

            while (!surnameCheck)
            {
                try
                {
                    Console.Write("Please, enter the surname: ");
                    string surname = Console.ReadLine();

                    employee.Surname = surname;

                    surnameCheck = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!nameCheck)
            {
                try
                {
                    Console.Write("Please, enter the name: ");
                    string name = Console.ReadLine();

                    employee.Name = name;

                    nameCheck = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!middleNameCheck)
            {
                try
                {
                    Console.Write("Please, enter the middle name if you have it: ");
                    string middleName = Console.ReadLine();

                    employee.MiddleName = middleName;

                    middleNameCheck = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!birthdayCheck)
            {
                try
                {
                    Console.Write("Please, enter the year of birth in format yyyy: ");
                    check = int.TryParse(Console.ReadLine(), out int year);
                    CheckValue(check);

                    Console.Write("Please, enter the month of birth in format mm: ");
                    check = int.TryParse(Console.ReadLine(), out int month);
                    CheckValue(check);

                    Console.Write("Please, enter the day of birth in format dd: ");
                    check = int.TryParse(Console.ReadLine(), out int day);
                    CheckValue(check);

                    DateTime birthday = new DateTime(year, month, day);

                    employee.Birthday = birthday;

                    if (CheckAge(employee.Age))
                    {
                        birthdayCheck = true;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!positionCheck)
            {
                try
                {
                    Console.Write("Please, enter employee position: ");
                    string position = Console.ReadLine();

                    employee.Position = position;

                    positionCheck = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (!startWorkDateCheck)
            {
                try
                {
                    Console.Write("Please, enter the year of work starting in format yyyy: ");
                    check = int.TryParse(Console.ReadLine(), out int year);
                    CheckValue(check);

                    Console.Write("Please, enter the month of work starting in format mm: ");
                    check = int.TryParse(Console.ReadLine(), out int month);
                    CheckValue(check);

                    Console.Write("Please, enter the day of work starting in format dd: ");
                    check = int.TryParse(Console.ReadLine(), out int day);
                    CheckValue(check);

                    DateTime startingWorkDate = new DateTime(year, month, day);

                    employee.StartWorkDate = startingWorkDate;

                    startWorkDateCheck = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("New employee is created:");
            Console.WriteLine($"\t- surname is: {employee.Surname};");
            Console.WriteLine($"\t- name is: {employee.Name};");
            Console.WriteLine($"\t- middle name is: {employee.MiddleName};");
            Console.WriteLine($"\t- employee position is: {employee.Position}");

            string birth = employee.Birthday.ToShortDateString();
            Console.WriteLine($"\t- date of birth is: {birth};");

            string age = employee.Age.ToString();
            Console.WriteLine($"\t- age is: {age}.");

            string startWorkDate = employee.StartWorkDate.ToShortDateString();
            Console.WriteLine($"\t- starting date of work: {startWorkDate}");

            Console.WriteLine($"\t- working expirience time: {employee.TimeEmployment}");
        }

        private static bool CheckValue(bool check)
        {
            if (!check)
            {
                throw new ArgumentException("The value must be an integer.");
            }

            return true;
        }

        private static bool CheckAge(int age)
        {
            if (age < 18)
            {
                throw new ArgumentException("Employee must be adult.");
            }

            return true;
        }
    }
}
