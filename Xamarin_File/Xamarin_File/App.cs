using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_File.Pages;

namespace Xamarin_File
{
/*        public class App : Application // superclass new in 1.3
        {
            public App()
            {
                var tabs = new TabbedPage();

                tabs.Children.Add(new LoadResourceTextBig { Title = "1 MB Text File"});

                tabs.Children.Add(new LoadResourceTextSmall { Title = "512KB Text File"});

                MainPage = tabs;
            }
        }*/
    
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
