using LoanRimender.Data;
using LoanRimender.Vistas;
using System;
using System.IO;
using Xamarin.Forms;

namespace LoanRimender
{
    public partial class App : Application
    {
        static RimenderDatabase database;

        public static RimenderDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RimenderDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rimender.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
          // MainPage = new NavigationPage(new LoanRimender.Vistas.Main());
           MainPage = new NavigationPage(new Addprestamo());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
