using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    public class Pin
    {
        public Pin()
        {
            Image pin = new Image();
            pin.Height = 40;
            pin.Width = 40;
            pin.Source = new BitmapImage(new Uri("Pin.png", UriKind.RelativeOrAbsolute));

        }

        public void Update(Canvas theCanvas)
        {

        }

        public void Move()
        { 
        
        }
    }
}
