using System;
using RobotCleaner.CustomControls;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RobotCleaner
{
    public class TakeImagePage : CameraPage
    {
        public TakeImagePage()
        {

            NavigationPage.SetHasNavigationBar(this, false);

            this.OnPhotoResult += async(result) => 
            {
                
                if (!result.Success)
                    return;
                
                var json = await Networking.MakeOCRRequest(result.Image);

                if (json != null)
                {
                    var data = JsonConvert.DeserializeObject<ImageResponseModel.Example>(json);
                   
                    await SendPhoto(data);
                }
                else
                {
                    var snb = new MaterialControls.MDSnackbar("An error occured", "Ok");   
                    snb.Show();
                }

            };

		}

        public async Task SendPhoto(ImageResponseModel.Example response)
		{
            var navigationPage = new NavigationPage(new OutputImagePage(response){ Title = "Text" })
			{

			};

            await App.Current.MainPage.Navigation.PushModalAsync(navigationPage);	
        }

		void Bt_Touch()
        {
			// await DisplayActionSheet("Choose","Cancel",null, new string[] { "Edit","Delete","Report","Post"});
		}
    }
}

