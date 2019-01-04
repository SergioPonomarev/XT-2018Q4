using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.Entities;
using Epam.Task7.Users.FakeBLL.UsersLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.ConsolePL
{
    internal class Program
    {
        private static IUsersLogic userLogic;

        private static void Main()
        {
            userLogic = new FakeUsersLogic();

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

                    case "create":
                        CreateNewUser();
                        break;

                    case "delete":
                        DeleteUser();
                        break;

                    case "delete all":
                        DeleteAllUsers();
                        break;

                    case "quit":
                        return;

                    default:
                        break;
                }
            }
        }

        private static void DeleteAllUsers()
        {
            Console.WriteLine("Are you sure you want to delete all users?");
            Console.WriteLine("Press Enter to delete all users or any another key to get back to main menu:");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (userLogic.DeleteAll())
                {
                    Console.WriteLine("All users was deleted successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Users deleting error.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        private static void DeleteUser()
        {
            Console.Write("Enter an Id of user to delete: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                if (userLogic.Delete(id))
                {
                    Console.WriteLine("User was deleted successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("User deleting error.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong user Id.");
                Console.WriteLine();
            }
        }

        private static void CreateNewUser()
        {
            Console.Write("Enter new user name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter date of birth in format yyyy-MM-dd: ");
            string userDateOfBirth = Console.ReadLine();

            try
            {
                userLogic.Create(userName, userDateOfBirth);
                Console.WriteLine("User was created successfully.");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("User creation error.");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private static void ShowAllUsers()
        {
            IEnumerable<User> users = userLogic.GetAll();

            foreach (User user in users)
            {
                ShowUser(user);
            }

            Console.WriteLine();

            //PressAnyKey();
        }

        private static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
            Console.WriteLine($"Date of birth: {user.DateOfBirth}, Age: {user.Age}");
        }

        private static string ReadMenuChoice()
        {
            return Console.ReadLine().ToLower();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("List - show list of users.");
            Console.WriteLine("Create - create new user.");
            Console.WriteLine("Delete - delete specified user.");
            Console.WriteLine("Delete all - delete all users.");
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
