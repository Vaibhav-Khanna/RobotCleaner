using System;
using RobotCleaner.CustomControls;
using Xamarin.Forms;
using SegmentedControl.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;

namespace RobotCleaner
{
    public class FirstPage : ExtendedPage
    {
        public FirstPage()
        {

            var segment = new SegmentedControl.FormsPlugin.Abstractions.SegmentedControl() {  SelectedSegment = 0, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TintColor = Color.Teal  };
           
            segment.Children.Add(new SegmentedControlOption(){ Text = "  My Collection  " });
            segment.Children.Add(new SegmentedControlOption(){ Text = "Gallery" });

            TitleView = segment;


            Content = segment;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var listview = new ListView(ListViewCachingStrategy.RecycleElement) { RowHeight = 45, ItemsSource = new ObservableCollection<string> { "This is Me", "Siya Singla","wow","done" }, VerticalOptions = LayoutOptions.FillAndExpand };

            listview.ItemTapped += async(sender, e) => 
            {
                await Navigation.PushAsync(new ContentPage(){ Title = e.Item as string });
                listview.SelectedItem = null;
            };

			Content = new StackLayout
			{
				Children = { listview },
				Orientation = StackOrientation.Vertical
			};

		}

    }
}

