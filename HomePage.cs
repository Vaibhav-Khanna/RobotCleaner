using System;
using RobotCleaner.CustomControls;
using Xamarin.Forms;

namespace RobotCleaner
{
    public class HomePage : CustomControls.Material_RippleTab
    {
        public HomePage()
        {
           

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);

          
            Children.Add(new NavigationPage(new FirstPage(){  }){ Title = "Click" });
            Children.Add(new ContentPage()
            {
                Title = "Gallery"
            });
			Children.Add(new ContentPage()
			{
				Title = "Share"
			});
			Children.Add(new ContentPage()
			{
				Title = "Profile"
			});
			Children.Add(new ContentPage()
			{
				Title = "Offers"
			});



        }



    }
}

