using System;
using RobotCleaner.CustomControls;
using Xamarin.Forms;

namespace RobotCleaner
{
    public class App : Application
    {
        public App()
        {
            
            var content = new InputPage();

            MainPage = new NavigationPage(content);

        }

        public static double Height { get; set; }
        public static double Width { get; set; }

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
