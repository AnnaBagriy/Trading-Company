using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompany.DAL;
using TradingCompany.DAL.DAL.DALAbstractions;
using Unity;
using BLL.Interfaces;
using AppUI;

namespace UI
{
    static class Program
    {
        public static UnityContainer Container { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = Container.Resolve<SignInForm>();

            Application.Run(loginForm);

            if (!loginForm.IsDisposed && loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<AdministrationMenuForm>());
            }
            else
            {
                Application.Exit();
            }

            Application.Exit();
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

            //var config = new MapperConfiguration(c => c.AddProfiles(typeof(UserDAL).Assembly));
            //Container.RegisterInstance(config.CreateMapper());
        }
    }
}
