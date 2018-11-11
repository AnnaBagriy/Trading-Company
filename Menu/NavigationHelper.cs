using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL;

namespace Menu
{
    internal class NavigationHelper
    {
        public static UserDAL users = new UserDAL();
        public static AddressDAL addresses = new AddressDAL();
        public static ActivatingDataDAL activatingData = new ActivatingDataDAL();
        public static BlockingDataDAL blockingData = new BlockingDataDAL();

        internal static void StartPage(out int MenuIndex)
        {
            Console.Clear();
            Console.WriteLine("\tADMINISTRATION PAGE");

            Console.WriteLine("\n1.Get all users"
                + "\n2.Search"
                + "\n3.Exit"
                + "\n\nEnter a number to continue...\n");

            int.TryParse(Console.ReadLine(), out MenuIndex);
        }

        internal static void ChangeUserStatus(out int MenuIndex)
        {
            Console.WriteLine($"{(OutputHelper.IsActivated == false ? "Activate user - 2\n" : "Show users's activation info - 2\n")}" +
                $"{(OutputHelper.IsBlocked == false ? "Block user - 3\n" : "Show users's blocking info - 3\n")}" +
                $"Show all user's addresses - 4\n");

            int.TryParse(Console.ReadLine(), out MenuIndex);
        }

        internal static void SearchPage(int MenuIndex)
        {
            Console.Clear();
            Console.WriteLine("Choose the way of searching:\n" +
                "\n1.By phone number" +
                "\n2.By email" +
                "\n3.By country\n");

            int.TryParse(Console.ReadLine(), out MenuIndex);

            switch (MenuIndex)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter user's phone number:\n");

                    var number = Console.ReadLine();
                    UserDTO user = null;
                    List<AddressDTO> address = null;

                    try
                    {
                        user = users.GetByNumber(number);
                        address = addresses.GetByUserId(user.UserId);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("\nAn error occured. User with this number does not exist.");
                        DefaultNavigation(MenuIndex);

                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nAn error occured.\n{ex.Message}");
                        DefaultNavigation(MenuIndex);

                        return;
                    }

                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUser(user, address.FirstOrDefault());
                    OutputHelper.OutputUnderline();

                    ChangeUserStatus(out MenuIndex);

                    switch (MenuIndex)
                    {
                        case 2:
                            if (OutputHelper.IsActivated)
                            {
                                OutputHelper.OutputActivationInfo(user, users, activatingData);

                                break;
                            }

                            OutputHelper.ActivationConfirmation(user, users, activatingData);

                            break;
                        case 3:
                            if (OutputHelper.IsBlocked)
                            {
                                OutputHelper.OutputBlockingInfo(user, users, blockingData);

                                break;
                            }

                            OutputHelper.BlockingConfirmation(user, users, blockingData);

                            break;
                        case 4:
                            OutputHelper.OutputUserAddresses(user, addresses);

                            break;
                    }

                    DefaultNavigation(MenuIndex);

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter user's email:\n");

                    var email = Console.ReadLine();

                    try
                    {
                        user = users.GetByEmail(email);
                        address = addresses.GetByUserId(user.UserId);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("\nAn error occured. User with this email does not exist.");
                        DefaultNavigation(MenuIndex);

                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occured.\n{ex.Message}");
                        DefaultNavigation(MenuIndex);

                        return;
                    }

                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUser(user, address.FirstOrDefault());
                    OutputHelper.OutputUnderline();

                    ChangeUserStatus(out MenuIndex);

                    switch (MenuIndex)
                    {
                        case 2:
                            if (OutputHelper.IsActivated)
                            {
                                OutputHelper.OutputActivationInfo(user, users, activatingData);

                                break;
                            }

                            OutputHelper.ActivationConfirmation(user, users, activatingData);

                            break;
                        case 3:
                            if (OutputHelper.IsBlocked)
                            {
                                OutputHelper.OutputBlockingInfo(user, users, blockingData);

                                break;
                            }

                            OutputHelper.BlockingConfirmation(user, users, blockingData);

                            break;
                        case 4:
                            OutputHelper.OutputUserAddresses(user, addresses);

                            break;
                    }

                    DefaultNavigation(MenuIndex);

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Enter country:\n");

                    var country = Console.ReadLine();
                    List<AddressDTO> adrs = null;

                    try
                    {
                        adrs = addresses.GetByCountry(country);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("\nNo users were found with this address.");
                        DefaultNavigation(MenuIndex);

                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred.\n{ex.Message}");
                        DefaultNavigation(MenuIndex);

                        return;
                    }

                    List<UserDTO> usrs = new List<UserDTO>();

                    OutputHelper.OutputUserTableData();

                    foreach (var u in adrs)
                    {
                        user = users.GetById(u.UserId);
                        var userAdr = user.tblAddresses.Where(uu => uu.UserId == user.UserId);
                        usrs.Add(users.GetById(u.UserId));

                        Console.WriteLine($" {user.FirstName} {user.LastName}".PadRight(20) +
                            $"| {user.PhoneNumber}".PadRight(15) + $"| {user.Email}".PadRight(30) +
                            $"| {(user.DateOfBirth != null ? "" + $"{user.DateOfBirth.Value.Day}.{user.DateOfBirth.Value.Month}.{user.DateOfBirth.Value.Year}" : "-")}".PadRight(15) +
                            $"| {(user.IsFemale != null ? (user.IsFemale == null ? "Female" : "Male") : "-")}".PadRight(9) +
                            $"| {$"{u.City}, {u.Country}, {u.HouseNumber} {u.Street}"}".PadRight(40) +
                            $"| {(user.IsAdmin == true ? "Admin" : "User")}".PadRight(11) +
                            $"| {(user.IsActivated == true ? "Activated" : "Not activated")}".PadRight(17) +
                            $"| {(user.IsBlocked == true ? "Blocked" : "Not blocked")}".PadRight(15) +
                            $"| {(user.FirstName == "Anna" && user.LastName == "Bagriy" ? " (you)" : "")}");
                    }

                    OutputHelper.OutputUnderline();

                    DefaultNavigation(MenuIndex);

                    break;
                default:
                    OutputHelper.OutputError();

                    DefaultNavigation(MenuIndex);

                    break;
            }
        }

        internal static void SortUserList(int MenuIndex)
        {
            Console.WriteLine("\nSorting options:" +
                "\n  by last name - 2" +
                "\n  by country - 3 (does not work)" +
                "\n  by date of birth - 4" +
                "\n  by activating data - 5" +
                "\n  by blocking data - 6");

            int.TryParse(Console.ReadLine(), out MenuIndex);
            switch (MenuIndex)
            {
                case 2:
                    Console.WriteLine("\nby ascending - 1\nby descending - 2");
                    int.TryParse(Console.ReadLine(), out MenuIndex);
                    string orderBy = "";

                    switch (MenuIndex)
                    {
                        case 1:
                            orderBy = "a";
                            break;
                        case 2:
                            orderBy = "d";
                            break;
                        default:
                            SortUserList(MenuIndex);
                            break;
                    }

                    Console.Clear();
                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUsers(users, addresses, "LastName", orderBy);
                    SortUserList(MenuIndex);
                    break;
                case 3:
                    Console.WriteLine("\nby ascending - 1\nby descending - 2");
                    int.TryParse(Console.ReadLine(), out MenuIndex);
                    orderBy = "";

                    switch (MenuIndex)
                    {
                        case 1:
                            orderBy = "a";
                            break;
                        case 2:
                            orderBy = "d";
                            break;
                        default:
                            SortUserList(MenuIndex);
                            break;
                    }

                    Console.Clear();
                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUsers(users, addresses, "tblAddresses?.FirstOrDefault()?.Country", orderBy);
                    // Unable to sort by nested collection keys
                    SortUserList(MenuIndex);
                    break;
                case 4:
                    Console.WriteLine("\nby ascending - 1\nby descending - 2");
                    int.TryParse(Console.ReadLine(), out MenuIndex);
                    orderBy = "";

                    switch (MenuIndex)
                    {
                        case 1:
                            orderBy = "a";
                            break;
                        case 2:
                            orderBy = "d";
                            break;
                        default:
                            SortUserList(MenuIndex);
                            break;
                    }

                    Console.Clear();
                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUsers(users, addresses, "DateOfBirth", orderBy);
                    SortUserList(MenuIndex);
                    break;
                case 5:
                    Console.WriteLine("\nby ascending - 1\nby descending - 2");
                    int.TryParse(Console.ReadLine(), out MenuIndex);
                    orderBy = "";

                    switch (MenuIndex)
                    {
                        case 1:
                            orderBy = "a";
                            break;
                        case 2:
                            orderBy = "d";
                            break;
                        default:
                            SortUserList(MenuIndex);
                            break;
                    }

                    Console.Clear();
                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUsers(users, addresses, "IsActivated", orderBy);
                    SortUserList(MenuIndex);
                    break;
                case 6:
                    Console.WriteLine("\nby ascending - 1\nby descending - 2");
                    int.TryParse(Console.ReadLine(), out MenuIndex);
                    orderBy = "";

                    switch (MenuIndex)
                    {
                        case 1:
                            orderBy = "a";
                            break;
                        case 2:
                            orderBy = "d";
                            break;
                        default:
                            SortUserList(MenuIndex);
                            break;
                    }

                    Console.Clear();
                    OutputHelper.OutputUserTableData();
                    OutputHelper.OutputUsers(users, addresses, "IsBlocked", orderBy);
                    SortUserList(MenuIndex);
                    break;
            }

            DefaultNavigation(MenuIndex);
        }

        #region Default navigation
        internal static void DefaultNavigation(int MenuIndex)
        {

            Console.WriteLine("\n\nReturn to the start page - 1\nExit the application - 0\n");
            int.TryParse(Console.ReadLine(), out MenuIndex);

            switch (MenuIndex)
            {
                case 0:
                    Console.WriteLine("Proccessing...");
                    Environment.Exit(0);
                    break;
                case 1:
                    Menu.StartPage();
                    break;
            }
        }
        #endregion
    }
}
