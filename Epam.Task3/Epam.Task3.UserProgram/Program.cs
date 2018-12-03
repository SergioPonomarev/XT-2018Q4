using System;

namespace Epam.Task3.User
{
    internal class Program
    {
        private static bool surnameCheck;
        private static bool nameCheck;
        private static bool middleNameCheck;
        private static bool birthdayCheck;
        private static bool check;

        private static void Main()
        {
            User user = new User();

            Console.WriteLine("Greetings! You are using The User Creating Program!");
            Console.WriteLine();

            while (!surnameCheck)
            {
                try
                {
                    Console.Write("Please, enter the surname: ");
                    string surname = Console.ReadLine();

                    user.Surname = surname;

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

                    user.Name = name;

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

                    user.MiddleName = middleName;

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

                    user.Birthday = birthday;

                    birthdayCheck = true;
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

            Console.WriteLine("New user is created:");
            Console.WriteLine($"\t- surname is: {user.Surname};");
            Console.WriteLine($"\t- name is: {user.Name};");
            Console.WriteLine($"\t- patronymic is: {user.MiddleName};");

            string birth = user.Birthday.ToShortDateString();
            Console.WriteLine($"\t- date of birth is: {birth};");

            string age = user.Age.ToString();
            Console.WriteLine($"\t- age is: {age}.");
        }

        private static bool CheckValue(bool check)
        {
            if (!check)
            {
                throw new ArgumentException("The value must be an integer.");
            }

            return true;
        }
    }
}
