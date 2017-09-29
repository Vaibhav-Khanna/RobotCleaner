using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lottie.Forms;
using RobotCleaner.CustomControls;
using Xamarin.Forms;
using Plugin.Media;
using SegmentedControl.FormsPlugin.Abstractions;

namespace RobotCleaner
{
    public class InputPage : ContentPage
    {

        MaterialEntry en_username;

        public InputPage()
        {
            
            NavigationPage.SetHasNavigationBar(this, false);

            var abso = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


			
            var lottie_Back = new AnimationView
            {
                Animation = "vr_animation.json",
                AutoPlay = true,
                Loop = true,
                TranslationY = -50
            };
            AbsoluteLayout.SetLayoutFlags(lottie_Back,AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(lottie_Back,new Rectangle(0.5,0,0.8,0.5));

            en_username = new MaterialEntry() {
				BackgroundColor = Color.Transparent,
                WidthRequest = App.Width*0.4,
                HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.Start,
                Placeholder = "Phone Number", AccentColor = Color.Teal ,Keyboard = Keyboard.Numeric };

			var en_Password = new MaterialEntry()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.Transparent,
				Placeholder = "Password",
                AccentColor = Color.Green
			};

      //      var materialEntry = new MaterialEntry() { AccentColor = Color.Green, Placeholder = "Name", Keyboard = Keyboard.Plain };

            var button = new Material_Button { HeightRequest = 50, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(0,20,0,0), VerticalOptions = LayoutOptions.StartAndExpand };

            var lb = new Label
            {
                Text = "By signing up, you agree to our" + Environment.NewLine + "terms & conditions.",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                FontFamily = "Avenir",
                VerticalOptions = LayoutOptions.End
            };


            var pg = new Material_ProgressBar()
            {              
                HeightRequest = 80,
                WidthRequest = 80,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            AbsoluteLayout.SetLayoutFlags(pg, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(pg, new Rectangle(0.5,0.8,80,80));
			   
            var st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(40,270,40,20),
                Spacing = 5,
                BackgroundColor = Color.Transparent,
                Children = 
                {
                    en_username, button ,lb
                }
            };
			AbsoluteLayout.SetLayoutFlags(st, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(st, new Rectangle(0, 0, 1, 1));

        
            abso.Children.Add(lottie_Back);
            abso.Children.Add(st);
            abso.Children.Add(pg);

            button.Touch += async () =>
			{

                //if(CrossMedia.Current.IsPickPhotoSupported)
                //{

                //    var photo = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions(){ PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small, CompressionQuality = 80 });

                //    if(photo!= null)
                //    {
                //        //var result = await Networking.MakeOCRRequest(photo.Path);

                //        //if(result!=null)
                //        //{
                            
                //        //}

                //    }

                //}
             
                if (!pg.IsVisible)
                {
                    pg.IsVisible = true;
                   
                    en_username.IsEnabled = false;
                    en_Password.IsEnabled = false;
                                    

                    await Task.Delay(3000);

                    pg.IsVisible = false;
                    en_username.IsEnabled = true;
                    en_Password.IsEnabled = true;

                    await Navigation.PushAsync(new HomePage() {  },false);
              
                }
			};
		

            Content = abso;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            en_username.Focus();
        }

    }
}

