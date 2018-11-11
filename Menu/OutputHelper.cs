using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingCompany.DAL;

namespace Menu
{
    internal class OutputHelper
    {
        private static int TableHorizontalLength { get; set; }
        internal static bool IsActivated { get; set; }
        internal static bool IsBlocked { get; set; }

        internal static void Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tLOGIN PAGE");

                TableHorizontalLength = 40;

                Console.OutputEncoding = Encoding.Unicode;
                for (int i = 0; i < TableHorizontalLength; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine("\n");

                Console.Write("Email | ".PadLeft(12));
                var email = Console.ReadLine();
                Console.Write("Password | ".PadLeft(12));
                var password = Console.ReadLine();

                UserDTO user = null;

                try
                {
                    user = NavigationHelper.users.GetByEmail(email);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("\nNo user with this email.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn error occured.\n{ex.Message}");
                }

                if(user?.Password == password && user?.IsAdmin == true)
                {
                    break;
                }
            }
        }

        internal static void OutputUserTableData()
        {
            Console.Clear();

            var str = " First/Last name".PadRight(20) + "| Phone number".PadRight(15) + "| Email".PadRight(30) + "| DoB".PadRight(15) +
                "| Sex".PadRight(9) + "| Main address".PadRight(40) + "| Role".PadRight(11) + "| Status".PadRight(17) + "| Status".PadRight(15);
            TableHorizontalLength = str.Length;

            Console.OutputEncoding = Encoding.Unicode;
            for (int i = 0; i < TableHorizontalLength; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine('\n' + str);
            for (int i = 0; i < TableHorizontalLength; i++)
            {
                Console.Write("\u0305");
            }
            Console.WriteLine('\n');
        }

        internal static void OutputUnderline()
        {
            for (int i = 0; i < TableHorizontalLength; i++)
            {
                Console.Write('_');
            }
            Console.WriteLine('\n');
        }

        internal static void OutputUser(UserDTO user, AddressDTO address)
        {
            IsActivated = user.IsActivated == true ? true : false;
            IsBlocked = user.IsBlocked == true ? true : false;

            Console.WriteLine($" {user.FirstName} {user.LastName}".PadRight(20) +
                            $"| {user.PhoneNumber}".PadRight(15) + $"| {user.Email}".PadRight(30) +
                            $"| {(user.DateOfBirth != null ? "" + $"{user.DateOfBirth.Value.Day}.{user.DateOfBirth.Value.Month}.{user.DateOfBirth.Value.Year}" : "-")}".PadRight(15) +
                            $"| {(user.IsFemale != null ? (user.IsFemale == null ? "Female" : "Male") : "-")}".PadRight(9) +
                            $"| {(address != null ? $"{address.City}, {address.Country}, {address.HouseNumber} {address.Street}" : "-")}".PadRight(40) +
                            $"| {(user.IsAdmin == true ? "Admin" : "User")}".PadRight(11) +
                            $"| {(user.IsActivated == true ? "Activated" : "Not activated")}".PadRight(17) +
                            $"| {(user.IsBlocked == true ? "Blocked" : "Not blocked")}".PadRight(15) +
                            $"| {(user.FirstName == "Anna" && user.LastName == "Bagriy" ? " (you)" : "")}");
        }

        internal static void OutputUsers(UserDAL users, AddressDAL addresses, string sortingKey = "UserId", string orderBy = "a")
        {
            List<UserDTO> u = null;

            if (orderBy == "a")
            {
                u = users.Get().OrderBy(s => s.GetType()?.GetProperty(sortingKey)?.GetValue(s)).ToList();
            }
            else
            {
                u = users.Get().OrderByDescending(s => s.GetType()?.GetProperty(sortingKey)?.GetValue(s)).ToList();
            }

            foreach (var user in u)
            {
                var adr = addresses.GetByUserId(user.UserId);
                OutputUser(user, adr.FirstOrDefault());
            }

            OutputUnderline();
        }

        internal static void OutputAddressesTable() { }

        internal static void OutputUserAddresses(UserDTO user, AddressDAL addresses)
        {
            var adr = addresses.GetByUserId(user.UserId);
            var str = $"\t{user.FirstName} {user.LastName}";
            TableHorizontalLength = 40;

            Console.Clear();
            Console.Write(str + '\n');
            OutputUnderline();

            adr.ForEach(a => { Console.WriteLine($" {a.City}, {a.Country}, {a.HouseNumber} {a.Street}"); });
            OutputUnderline();
        }

        internal static BlockingDataDTO InputBlockingData()
        {
            BlockingDataDTO data = new BlockingDataDTO();
            int temp;
            bool tempBool;

            Console.Write("\nDelete user: ");
            tempBool = Convert.ToBoolean(int.TryParse(Console.ReadLine(), out temp));
            data.BlockAndDelete = tempBool;

            if (temp == 1)
            {
                data.BlockAndDelete = true;

                return data;
            }
            else if (temp == 0)
            {
                data.BlockAndDelete = false;
            }

            Console.Write("Reason: ");
            data.Reason = Console.ReadLine();
            Console.Write("Term in hours: ");
            int.TryParse(Console.ReadLine(), out temp);
            data.TermInHours = temp;

            return data;
        }

        internal static void BlockingConfirmation(UserDTO user, UserDAL userDAL, BlockingDataDAL blockingDataDAL)
        {
            Console.Clear();
            Console.WriteLine($"Are you sure to want to block {user.FirstName} {user.LastName}?");
            Console.WriteLine("\nYes - 1\nNo - 0\n");

            int res;
            int.TryParse(Console.ReadLine(), out res);

            switch (res)
            {
                case 1:
                    BlockingDataDTO blockingData = null;

                    try
                    {
                        blockingData = InputBlockingData();
                        blockingData.UserId = user.UserId;
                        blockingData.AdminId = 15;

                        user.IsBlocked = true;

                        Console.Clear();
                        if (blockingData.BlockAndDelete == false)
                        {
                            userDAL.Update(user, user.UserId);
                            blockingDataDAL.Add(blockingData);

                            Console.WriteLine($"User {user.FirstName} {user.LastName} was blocked successfully for {blockingData.TermInHours} hours.");
                        }
                        else
                        {
                            userDAL.Delete(user.UserId);
                            Console.WriteLine($"User {user.FirstName} {user.LastName} was blocked and deleted successfully");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occured.\n{ex.Message}");
                    }

                    break;
                case 0:
                    Menu.StartPage();

                    break;
            }
        }

        internal static void OutputBlockingInfo(UserDTO user, UserDAL userDAL, BlockingDataDAL blockingDataDAL)
        {
            var data = blockingDataDAL.GetById(user.UserId);
            var admin = userDAL.GetById(data.AdminId);

            var str = $"\t{user.FirstName} {user.LastName}";
            TableHorizontalLength = 40;

            Console.Clear();
            Console.Write(str + '\n');
            OutputUnderline();

            Console.WriteLine("By".PadRight(7) + $"| {admin.FirstName} {admin.LastName}\n" +
                "Why".PadRight(7) + $"| {data.Reason}\n" +
                "Term".PadRight(7) + $"| {data.TermInHours}\n");

            OutputUnderline();
        }

        internal static void OutputActivationInfo(UserDTO user, UserDAL userDAL, ActivatingDataDAL activatingDataDAL)
        {
            var data = activatingDataDAL.GetById(user.UserId);
            var admin = userDAL.GetById(data.AdminId);

            var str = $"\t{user.FirstName} {user.LastName}";
            TableHorizontalLength = 40;

            Console.Clear();
            Console.Write(str + '\n');
            OutputUnderline();

            Console.WriteLine("By".PadRight(7) + $"| {admin.FirstName} {admin.LastName}\n" +
                "When".PadRight(7) + $"| {data.ActivatingDate}");

            OutputUnderline();
        }

        internal static void ActivationConfirmation(UserDTO user, UserDAL userDAL, ActivatingDataDAL activatingDataDAL)
        {
            Console.Clear();
            Console.WriteLine($"Are you sure to want to activate {user.FirstName} {user.LastName}?");
            Console.WriteLine("\nYes - 1\nNo - 0\n");

            int res;
            int.TryParse(Console.ReadLine(), out res);

            switch (res)
            {
                case 1:
                    var activatingData = new ActivatingDataDTO() { UserId = user.UserId, ActivatingDate = DateTime.Now, AdminId = 15 };
                    user.IsActivated = true;

                    try
                    {
                        userDAL.Update(user, user.UserId);
                        activatingDataDAL.Add(activatingData);

                        Console.Clear();
                        Console.WriteLine($"User {user.FirstName} {user.LastName} was activated successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine($"An error occured.\n{ex.Message}");
                    }

                    break;
                case 0:
                    Menu.StartPage();

                    break;
            }
        }

        internal static void OutputError()
        {
            Console.WriteLine("Wrong input.");
        }
    }
}
