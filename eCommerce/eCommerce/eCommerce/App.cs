using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.Data;
using Xamarin.Forms;

namespace eCommerce
{
    public class App : Application
    {
        static CartItemDatabase database;

        public App()
        {
            // The root page of your application
            MainPage = new MainPage();
        }

        public static CartItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CartItemDatabase();
                }
                return database;
            }
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
