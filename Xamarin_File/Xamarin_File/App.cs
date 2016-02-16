﻿using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_File.Pages;

namespace Xamarin_File
{
    
        public class App : Application
        {
            public App()
            {
                // The root page of your application
                MainPage = GetMainPage();
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
            public static Page GetMainPage()
            {
                return new FileSystemPage();
            }
        }
}
