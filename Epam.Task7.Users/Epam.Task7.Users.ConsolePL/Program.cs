using Epam.Task7.Users.BLL;
using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.Common;
using Epam.Task7.Users.Entities;
using Epam.Task7.Users.FakeBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.ConsolePL
{
    internal class Program
    {
        private static IUsersLogic usersLogic;

        private static void Main()
        {
            usersLogic = DependencyResolver.UsersLogic;

            Console.WriteLine("Greetings! You are using The User Creating Program.");
            Console.WriteLine();

            while (true)
            {
                ShowMenu();
                string choice = ReadMenuChoice();
                switch (choice)
                {
                    case "list":
                        ShowAllUsers();
                        break;

                    case "add":
                        AddNewUser();
                        break;

                    case "remove":
                        RemoveUser();
                        break;

                    case "remove all":
                        RemoveAllUsers();
                        break;

                    case "quit":
                        return;

                    default:
                        break;
                }
            }
        }

        private static void RemoveAllUsers()
        {
            Console.WriteLine("Are you sure you want to remove all users?");
            Console.WriteLine("Press Enter to remove all users or any another key to get back to main menu:");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (usersLogic.RemoveAll())
                {
                    Console.WriteLine("All users was removed successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Users removing error.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        private static void RemoveUser()
        {
            Console.Write("Enter an Id of user to remove: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                if (usersLogic.Remove(id))
                {
                    Console.WriteLine("User was removed successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("User removing error.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong user Id.");
                Console.WriteLine();
            }
        }

        private static void AddNewUser()
        {
            Console.Write("Enter new user name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter date of birth in format yyyy-MM-dd: ");
            string userDateOfBirth = Console.ReadLine();

            try
            {
                usersLogic.Add(userName, userDateOfBirth);
                Console.WriteLine("User was added successfully.");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("User adding error.");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private static void ShowAllUsers()
        {
            IEnumerable<User> users = usersLogic.GetAll();

            foreach (User user in users)
            {
                ShowUser(user);
            }

            Console.WriteLine();

            //PressAnyKey();
        }

        private static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Date of birth: {user.DateOfBirth.ToShortDateString()}, Age: {user.Age}");
        }

        private static string ReadMenuChoice()
        {
            return Console.ReadLine().ToLower();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("List - show list of users.");
            Console.WriteLine("Add - add new user.");
            Console.WriteLine("Remove - remove specified user.");
            Console.WriteLine("Remove all - remove all users.");
            Console.WriteLine("Quit - quit the program.");
            Console.Write("Choose your option: ");
        }

        //private static void PressAnyKey()
        //{
        //    Console.WriteLine("Press any key to get back to manu.");
        //    Console.ReadKey();
        //}
    }
}
