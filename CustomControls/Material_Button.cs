using System;
using Xamarin.Forms;

namespace RobotCleaner.CustomControls
{
    public class Material_Button : View
    {
        public delegate void EventHandler();

        public event EventHandler Touch;

        public void Start()
        {
            Touch.Invoke();
        }
    }
}
