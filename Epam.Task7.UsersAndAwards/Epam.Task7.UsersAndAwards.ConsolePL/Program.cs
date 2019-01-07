using System;
using System.Collections.Generic;
using Epam.Task7.UsersAndAwards.BLL.Interfaces;
using Epam.Task7.UsersAndAwards.Common;
using Epam.Task7.UsersAndAwards.Entities;

namespace Epam.Task7.UsersAndAwards.ConsolePL
{
    internal class Program
    {
        private static IUsersLogic usersLogic;
        private static IAwardsLogic awardsLogic;
        private static IAwardUsersLogic awardUsersLogic;

        private static void Main()
        {
            usersLogic = DependencyResolver.UsersLogic;
            awardsLogic = DependencyResolver.AwardsLogic;
            awardUsersLogic = DependencyResolver.AwardUsersLogic;

            Console.WriteLine("Greetings! You are using The User Creating Program.");
            Console.WriteLine();

            while (true)
            {
                ShowMenu();
                string choice = ReadMenuChoice();
                switch (choice)
                {
                    case "user list":
                        ShowAllUsers();
                        break;

                    case "award list":
                        ShowAllAwards();
                        break;

                    case "add user":
                        AddNewUser();
                        break;

                    case "add award":
                        AddNewAward();
                        break;

                    case "award user":
                        AwardUser();
                        break;

                    case "remove user":
                        RemoveUser();
                        break;

                    case "remove award":
                        RemoveAward();
                        break;

                    case "remove all users":
                        RemoveAllUsers();
                        break;

                    case "remove all awards":
                        RemoveAllAwards();
                        break;

                    case "quit":
                        return;

                    default:
                        break;
                }
            }
        }

        private static void AwardUser()
        {
            Console.Write("Enter Id of user to award: ");
            string inputUserId = Console.ReadLine();
            Console.Write("Enter Id of award: ");
            string inputAwardId = Console.ReadLine();

            if (int.TryParse(inputUserId, out int userId) &&
                int.TryParse(inputAwardId, out int awardId))
            {
                if (awardUsersLogic.AddAwardUser(userId, awardId))
                {
                    Console.WriteLine("User successfully awarded.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("User awarding error.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong user or award Id.");
                Console.WriteLine();
            }
        }

        private static void RemoveAllAwards()
        {
            Console.WriteLine("Are you sure you want to remove all awards?");
            Console.WriteLine("Press Enter to remove all awards or any another key to get back to main menu:");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (awardsLogic.RemoveAll())
                {
                    Console.WriteLine("All awards was removed successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Awards removing error.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
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

        private static void RemoveAward()
        {
            Console.Write("Enter an Id of award to remove: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                if (awardsLogic.Remove(id))
                {
                    Console.WriteLine("Award was removed successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Award removing error.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong award Id.");
                Console.WriteLine();
            }
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

        private static void AddNewAward()
        {
            Console.Write("Enter new award title: ");
            string awardTitle = Console.ReadLine();

            try
            {
                awardsLogic.Add(awardTitle);
                Console.WriteLine("Award was added successfully.");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Award adding error.");
                Console.WriteLine(ex.Message);
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

        private static void ShowAllAwards()
        {
            IEnumerable<Award> awards = awardsLogic.GetAll();

            foreach (Award award in awards)
            {
                ShowAward(award);
            }

            Console.WriteLine();
        }

        private static void ShowAward(Award award)
        {
            Console.WriteLine($"Id: {award.Id}, Title: {award.Title}");
        }

        private static void ShowAllUsers()
        {
            IEnumerable<User> users = usersLogic.GetAll();

            foreach (User user in users)
            {
                ShowUser(user);
            }

            Console.WriteLine();
        }

        private static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Date of birth: {user.DateOfBirth.ToShortDateString()}, Age: {user.Age}");
            Console.Write("Awards: ");
            foreach (var award in user.UserAwards)
            {
                Console.Write($"*{award.Title}* ");
            }

            Console.WriteLine();
        }

        private static string ReadMenuChoice()
        {
            return Console.ReadLine().ToLower();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("User list - show list of users.");
            Console.WriteLine("Award list - show list of awards.");
            Console.WriteLine("Add user - add new user.");
            Console.WriteLine("Add award - add new award.");
            Console.WriteLine("Award user - to award specified user with specified award.");
            Console.WriteLine("Remove user - remove specified user.");
            Console.WriteLine("Remove award - remove specified award.");
            Console.WriteLine("Remove all users - remove all users.");
            Console.WriteLine("Remove all awards - remove all awards.");
            Console.WriteLine("Quit - quit the program.");
            Console.Write("Choose your option: ");
        }
    }
}
