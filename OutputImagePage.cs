using System;
using System.IO;
using Xamarin.Forms;

namespace RobotCleaner
{
    public class OutputImagePage : ContentPage
    {
        
        public OutputImagePage(ImageResponseModel.Example data)
        {            
            ToolbarItems.Add(new ToolbarItem("Close","", async() => { await Navigation.PopModalAsync(); }));

            var img = new Image(){ HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            var editor = new Editor() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = App.Width };

            string text = "";

            data.regions.ForEach( (obj) => 
            {
                obj.lines.ForEach((o) => o.words.ForEach( (ob) => text += ob.text + " " ));               
            });

            editor.Text = text;

            Content = editor;
        }
    }
}

