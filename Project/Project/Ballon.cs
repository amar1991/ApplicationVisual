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
    
    public class Ballon: ContentControl
    {
        int life;//declare variable life of ballon.
        public int Life { // get and set life value from the main page
            get { return life; }
            set { life = value; }
        }

        public Ballon(int x, int y) { 
            life = 0;
            Random random = new Random();// random ballon with random height and width.
            Image ballonImage = new Image();
            ballonImage.Height = random.Next(60, 80);
            ballonImage.Width = ballonImage.Height;
            ballonImage.Source = new BitmapImage(new Uri("Ballon.png", UriKind.RelativeOrAbsolute));//source of the image of ballon
            
            this.Content = ballonImage;          
            Canvas.SetLeft(this, random.Next(10, x-1));// set random left and right of ballon image in a canvas
            Canvas.SetTop(this, random.Next(10, y-1));
         }
    }
}


