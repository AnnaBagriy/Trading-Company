using System;
using System.Threading;
using TradingCompany.DAL;

namespace Menu
{
    public class Menu
    {
        public static int MenuIndex;

        public static void Login()
        {
            OutputHelper.Login();
        }

        public static void StartPage()
        {
            NavigationHelper.StartPage(out MenuIndex);

            switch (MenuIndex)
            {
                case 1:
                    UsersPage();

                    break;
                case 2:
                    SearchPage();

                    break;
                case 3:
                    ExitPage();

                    break;
                default:
                    DefaultPage();

                    break;
            }
        }

        private static void UsersPage()
        {
            OutputHelper.OutputUserTableData();
            OutputHelper.OutputUsers(NavigationHelper.users, NavigationHelper.addresses);

            NavigationHelper.SortUserList(MenuIndex);
            NavigationHelper.DefaultNavigation(MenuIndex);
        }

        private static void SearchPage()
        {
            NavigationHelper.SearchPage(MenuIndex);
        }

        private static void ExitPage()
        {
            Console.WriteLine("Proccessing...");
            Thread.Sleep(1200);
            Environment.Exit(0);
        }

        private static void DefaultPage()
        {
            Console.Clear();
            OutputHelper.OutputError();

            NavigationHelper.DefaultNavigation(MenuIndex);
        }
    }
}
