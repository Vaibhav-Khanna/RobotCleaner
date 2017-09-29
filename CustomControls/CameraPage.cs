using System;

using Xamarin.Forms;

namespace RobotCleaner.CustomControls
{
    public class CameraPage : ContentPage
    {
        
        public delegate void PhotoResultEventHandler(PhotoResultEventArgs result);
       
        public event PhotoResultEventHandler OnPhotoResult;

		public void SetPhotoResult(byte[] image, int width = -1, int height = -1)
		{
			OnPhotoResult?.Invoke(new PhotoResultEventArgs(image, width, height));
		}

        public CameraPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

		public void Cancel()
		{
			OnPhotoResult?.Invoke(new PhotoResultEventArgs());
		}

	}

    public class PhotoResultEventArgs
    {
		public bool Success { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
        public byte[] Image { get; set; }

        public PhotoResultEventArgs()
        {
            Success = false;
        }

        public PhotoResultEventArgs(byte[] _img,int w,int h)
        {
            Image = _img;
            Width = w;
            Height = h;
            Success = _img != null ? true : false;
        }

    }

}

