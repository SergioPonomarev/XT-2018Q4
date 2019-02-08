using System;
using System.Collections.Generic;
using System.Globalization;
using Epam.Task11_12.UsersAndAwards.BLL.Interfaces;
using Epam.Task11_12.UsersAndAwards.Common;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.ConsolePL
{
    internal class Program
    {
        private static IUsersLogic usersLogic;
        private static IAwardsLogic awardsLogic;
        private static IAwardsUsersLogic awardsUsersLogic;
        private static string choice;
        private static string userName;
        private static string awardTitle;
        private static string input;
        private static string inputUserId;
        private static string inputAwardId;
        private const string DateFormat = "yyyy-MM-dd";

        private static void Main()
        {
            usersLogic = DependencyResolver.UsersLogic;
            awardsLogic = DependencyResolver.AwardsLogic;
            awardsUsersLogic = DependencyResolver.AwardsUsersLogic;

            Console.WriteLine("Greetings! You are using The User Creating Program.");
            Console.WriteLine();

            while (true)
            {
                ShowMenu();
                choice = ReadMenuChoice();
                switch (choice)
                {
                    case "user list":
                        ShowAllUsers();
                        break;

                    case "add user":
                        AddNewUser();
                        break;

                    case "update user":
                        UpdateUser();
                        break;

                    case "remove user":
                        RemoveUser();
                        break;

                    case "award list":
                        ShowAllAwards();
                        break;

                    case "add award":
                        AddNewAward();
                        break;

                    case "update award":
                        UpdateAward();
                        break;

                    case "remove award":
                        RemoveAward();
                        break;

                    case "award user":
                        AwardUser();
                        break;

                    case "remove award from user":
                        RemoveAwardFromUser();
                        break;

                    case "quit":
                        return;

                    default:
                        Console.WriteLine("Invalid command.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static void RemoveAwardFromUser()
        {
            Console.Write("Enter an Id of user to award: ");
            inputUserId = Console.ReadLine();
            Console.Write("Enter an Id of award: ");
            inputAwardId = Console.ReadLine();

            if (int.TryParse(inputUserId, out int userId) &&
                int.TryParse(inputAwardId, out int awardId))
            {
                if (awardsUsersLogic.RemoveAwardFromUser(userId, awardId))
                {
                    Console.WriteLine("Award was successfully removed from user.");
                    Console.WriteLine();
                }
                else
                {
                    RemovingAwardFromUserError();
                }
            }
            else
            {
                RemovingAwardFromUserError();
            }
        }

        private static void AwardUser()
        {
            Console.Write("Enter an Id of user to award: ");
            inputUserId = Console.ReadLine();
            Console.Write("Enter an Id of award: ");
            inputAwardId = Console.ReadLine();

            if (int.TryParse(inputUserId, out int userId) &&
                int.TryParse(inputAwardId, out int awardId))
            {
                //try
                //{
                    if (awardsUsersLogic.AwardUser(userId, awardId))
                    {
                        Console.WriteLine("User was successfully awarded.");
                        Console.WriteLine();
                    }
                    else
                    {
                        UserAwardingError();
                    }
                //}
                //catch (Exception ex)
                //{
                //    UserAwardingError();
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    inputUserId = null;
                //    inputAwardId = null;
                //}
            }
            else
            {
                UserAwardingError();
            }
        }

        private static void RemoveAward()
        {
            Console.Write("Enter an Id of award to remove: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int awardId))
            {
                //try
                //{
                    if (awardsLogic.Remove(awardId))
                    {
                        Console.WriteLine("Award was removed successfully.");
                        Console.WriteLine();
                    }
                    else
                    {
                        AwardRemovingError();
                    }
                //}
                //catch (Exception ex)
                //{
                //    AwardRemovingError();
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    input = null;
                //}
            }
            else
            {
                AwardRemovingError();
            }
        }

        private static void UpdateAward()
        {
            Console.Write("Enter an Id of award to update: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int awardId))
            {
                //try
                //{
                    Award award = awardsLogic.GetAwardById(awardId);

                    if (award != null)
                    {
                        ShowAward(award);

                        Console.Write("Enter new award title: ");
                        awardTitle = Console.ReadLine();
                        if (awardsLogic.Update(awardId, awardTitle))
                        {
                            Console.WriteLine("Award was updated successfully.");
                            Console.WriteLine();
                        }
                        else
                        {
                            AwardUpdatingError();
                        }
                    }
                    else
                    {
                        AwardUpdatingError();
                    }
                //}
                //catch (Exception ex)
                //{
                //    AwardUpdatingError();
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    awardTitle = null;
                //}
            }
            else
            {
                AwardUpdatingError();
            }
        }

        private static void AddNewAward()
        {
            Console.Write("Enter new award title: ");
            awardTitle = Console.ReadLine();

            //try
            //{
                if (awardsLogic.Add(awardTitle))
                {
                    Console.WriteLine("Award was added successfully.");
                    Console.WriteLine();
                }
                else
                {
                    AwardAddingError();
                }
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine();
            //}
            //catch (Exception ex)
            //{
            //    AwardAddingError();
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    awardTitle = null;
            //}
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
            Console.WriteLine($"Id: {award.AwardId}, Title: {award.AwardTitle}");
        }

        private static void RemoveUser()
        {
            Console.Write("Enter an Id of user to remove: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int userId))
            {
                //try
                //{
                    if (usersLogic.Remove(userId))
                    {
                        Console.WriteLine("User was removed successfully.");
                        Console.WriteLine();
                    }
                    else
                    {
                        UserRemovingError();
                    }
                //}
                //catch (Exception ex)
                //{
                //    UserRemovingError();
                //    Console.WriteLine(ex.Message);
                //}
            }
            else
            {
                UserRemovingError();
            }
        }

        private static void UpdateUser()
        {
            Console.Write("Enter an Id of user to update: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int userId))
            {
                //try
                //{
                    User user = usersLogic.GetUserById(userId);
                    if (user != null)
                    {
                        ShowUser(user);
                        ShowUserUpdateMenu();
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "name":
                                Console.Write("Enter new user name: ");
                                userName = Console.ReadLine();
                                if (usersLogic.Update(userId, userName: userName))
                                {
                                    Console.WriteLine("User was updated successfully.");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    UserUpdatingError();
                                }
                                break;

                            case "date":
                                Console.Write("Enter new user date of birth in format yyyy-MM-dd: ");
                                input = Console.ReadLine();

                                if (DateTime.TryParseExact(input, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime userDateOfBirth))
                                {
                                    if (usersLogic.Update(userId, userDateOfBirth: userDateOfBirth))
                                    {
                                        Console.WriteLine("User updated successfully.");
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        UserUpdatingError();
                                    }
                                }
                                else
                                {
                                    UserUpdatingError();
                                }
                                break;
                        }

                    }
                    else
                    {
                        UserUpdatingError();
                    }
                //}
                //catch (ArgumentException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    Console.WriteLine();
                //}
                //catch (Exception ex)
                //{
                //    UserUpdatingError();
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    userName = null;
                //    choice = null;
                //    input = null;
                //}
            }
            else
            {
                UserUpdatingError();
            }
        }

        private static void AddNewUser()
        {
            Console.Write("Enter new user name: ");
            userName = Console.ReadLine();
            Console.Write("Enter date of birth in format yyyy-MM-dd: ");
            input = Console.ReadLine();

            if (DateTime.TryParseExact(input, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime userDateOfBirth))
            {
                //try
                //{
                    if (usersLogic.Add(userName, userDateOfBirth))
                    {
                        Console.WriteLine("User was added successfully.");
                        Console.WriteLine();
                    }
                    else
                    {
                        UserAddingError();
                    }
                //}
                //catch (ArgumentException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    Console.WriteLine();
                //}
                //catch (Exception ex)
                //{
                //    UserAddingError();
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    userName = null;
                //    input = null;
                //}
            }
            else
            {
                UserAddingError();
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
        }

        private static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.UserId}, Name: {user.UserName}, Date of birth: {user.UserDateOfBirth.ToShortDateString()}, Age: {user.UserAge}");
            Console.Write("Awards: ");
            foreach (Award award in user.UserAwards)
            {
                Console.Write($"*{award.AwardTitle}* ");
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
            Console.WriteLine("Add user - add new user.");
            Console.WriteLine("Update user - update specified user.");
            Console.WriteLine("Remove user - remove specified user.");
            Console.WriteLine("Award list - show list of awards.");
            Console.WriteLine("Add award - add new award.");
            Console.WriteLine("Update award - update specified award.");
            Console.WriteLine("Remove award - remove specified award.");
            Console.WriteLine("Award user - to award specified user with specified award.");
            Console.WriteLine("Remove award from user - to remove specified award from specified user.");
            Console.WriteLine("Quit - quit the program.");
            Console.Write("Choose your option: ");
        }

        private static void ShowUserUpdateMenu()
        {
            Console.WriteLine("Name - to update user name.");
            Console.WriteLine("Date - to update user date of birth.");
            Console.Write("Choose your option: ");
        }

        private static void UserAddingError()
        {
            Console.WriteLine("User adding error.");
            Console.WriteLine();
        }

        private static void UserUpdatingError()
        {
            Console.WriteLine("User updating error.");
            Console.WriteLine();
        }

        private static void UserRemovingError()
        {
            Console.WriteLine("User removing error.");
            Console.WriteLine();
        }

        private static void AwardAddingError()
        {
            Console.WriteLine("Award adding error.");
            Console.WriteLine();
        }

        private static void AwardUpdatingError()
        {
            Console.WriteLine("Award updating error.");
            Console.WriteLine();
        }

        private static void AwardRemovingError()
        {
            Console.WriteLine("Award removing error.");
            Console.WriteLine();
        }

        private static void UserAwardingError()
        {
            Console.WriteLine("User awarding error.");
            Console.WriteLine();
        }

        private static void RemovingAwardFromUserError()
        {
            Console.WriteLine("Removing award from user error.");
            Console.WriteLine();
        }
    }
}
