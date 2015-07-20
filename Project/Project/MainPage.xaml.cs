using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    public partial class MainPage : UserControl
    {





        List<Ballon> ballons; // create a list of ballons
        int ballonCount = 0; // set the ballon count to 0
        int ballonTimer = 0; // timer to 0 
        bool persisted = false; // set persistent to false value
        int counter = 0; // declare counter to 0
        
      
        
        

        string[] sums = new string[]{ "1+1","2+2","3+3","7-1","4+5"};// create a array of sums 
        int sumNumber = 0;//set sumNumber to 0 for getting the random index
    




        public MainPage()



        {
            InitializeComponent();

            

           

            //initialize rendering of ballons and backgron

            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            ballons = new List<Ballon>();
            CompositionTarget.Rendering += new EventHandler(RenderBallons);
                       
        }


        public string GetRandomSum() // method to get random sum from the arrays
        {

            Random rnd = new Random();
            sumNumber = rnd.Next(0, sums.Length);
            return sums[sumNumber];

        }

       

  
        private void RenderBallons(object sender, EventArgs e)
        {
            Random r = new Random(); //random 
            ballonTimer += 1;
            
            if (ballons.Count < 10) //display 10 ballons
            {
                if (ballonTimer > r.Next(10, 50)) 
                {
                    ballonTimer = 0;
                    AddBallon(new Ballon((int)this.Width, (int)this.Height));
                }
            }

            for (int i = 0; i < ballons.Count; i++) //itiration 
            {
                ballons[i].Life++; 
            }

            for (int i = 0; i < ballons.Count; i++)
            {
                if (ballons[i].Life > r.Next(100, 250))
                {                   
                    if (i == ballons.Count - 1 && persisted == false) // if there are no ballon left and the persisted is false then the textblock is visible and display score.
                    {
                        persisted = true;
                        tbScores.Visibility = Visibility.Visible;
                        tbScores.Text = "Game Over. Your score is " + ballonCount;
                        
                    }
                }
            }
        }
             




        private void AddBallon(Ballon a)// method to add ballon in layout
        {
            ballons.Add(a);
            LayoutRoot.Children.Add(a);
            a.MouseLeftButtonDown += new MouseButtonEventHandler(a_MouseEnter);// left button event control
        }

        private void a_MouseEnter(object sender, MouseButtonEventArgs e)//mouse enter event controll
        {
          
            
                       
            RemoveBallon((Ballon)sender);// remove the ballon
            ballonCount++;// count the button clicked on ballon                                  
            
                     


        }

        private void RemoveBallon(Ballon a) //remove the ballon from the layout
        {
            LayoutRoot.Children.Remove(a);
            
        }            



        void CompositionTarget_Rendering(object sender, EventArgs e)//background rendering
        {

            if (Canvas.GetLeft(bg) < -(this.bg.ActualWidth - this.Width))
            {
                Canvas.SetLeft(bg, 0);
            }
            Canvas.SetLeft(bg, Canvas.GetLeft(bg) - 1);          

        }

        private void Button_Click(object sender, RoutedEventArgs e) //navigation back to home
        {
            ((App)App.Current).Navigate(new Welcome());
        }

        private void btnSum_Click(object sender, RoutedEventArgs e)// button click method to get the sums from the arrays
        {
            counter++;

            if (counter < 100)//change the visibility to visible and display the array of sums in label
            {
                lblSum.Visibility = Visibility.Visible;
                
                counter = 0;
                lblSum.Content = GetRandomSum();             
                

            }
        }

        private void lblSum_Loaded(object sender, RoutedEventArgs e) // load event at the begining which is for displaying the sums
        {
            lblSum.Visibility = Visibility.Visible;
            lblSum.Content = GetRandomSum();
        }      


    }
}
