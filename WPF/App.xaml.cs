using AutoMapper;
using BLL;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TradingCompany.DAL;
using TradingCompany.DAL.DAL.DALAbstractions;
using Unity;
using WPF.ViewModels;
using WPF.Views;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnityContainer Container { get; set; }

        public App()
        {
            ConfigureUnity();

            var viewModel = Container.Resolve<UserListViewModel>();

            UserList mainWindow = new UserList(viewModel);
            mainWindow.Show();
        }

        private static void ConfigureUnity()
        {
            Container = new UnityContainer();

            // Register DAL
            Container.RegisterType<IUserDAL, UserDAL>();
            Container.RegisterType<IActivatingDataDAL, ActivatingDataDAL>();
            Container.RegisterType<IBlockingDataDAL, BlockingDataDAL>();
            Container.RegisterType<IAddressDAL, AddressDAL>();

            // Register BL
            Container.RegisterType<IUserBL, UserBLL>();
            Container.RegisterType<IActivatingDataBL, ActivatingDataBL>();
            Container.RegisterType<IBlockingDataBL, BlockingDataBL>();
            Container.RegisterType<IAddressBL, AddressBL>();
        }
    }
}
