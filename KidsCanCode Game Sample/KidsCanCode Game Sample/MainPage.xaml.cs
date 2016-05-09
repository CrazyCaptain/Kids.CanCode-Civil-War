using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KidsCanCode_Game_Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //Starting HP of Characters
        int IronManHP = 100;
        int CaptainAmericaHP = 100;

        //Click Counter for Continue
        int ContinueCounter = 0;

        public MainPage()
        {
            this.InitializeComponent();

            //Display HP of Characters    
            txtCaptainAmericaHP.Text = CaptainAmericaHP.ToString();
            pbCaptainAmericaHP.Value = CaptainAmericaHP;
            txtIronManHP.Text = IronManHP.ToString();
            pbIronManHP.Value = IronManHP;

        }

        private void btnThrow_Click(object sender, RoutedEventArgs e)
        {
            imgCaptainAmerica.Opacity = 0;        
            IronManHP = IronManHP - 20;
            pbIronManHP.Value = IronManHP;
            txtIronManHP.Text = IronManHP.ToString();
            btnThrow.IsEnabled = false;
            btnThrow.Opacity = 0;
            tbDisplay.Opacity = 100;
            tbDisplay.Text = "Captain America throws his shield to Iron Man. Iron Man is hurt.";
            imgThrow.Opacity = 100;
            //Declare Winner
            if (IronManHP == 0)
            {
                tbDisplay.Text = "Congratulations! You won against Iron Man!";
            }
            else
            {
                btnContinue.Opacity = 100;
                btnContinue.IsEnabled = true;
            }
        }

        public void Blast()
        {
            CaptainAmericaHP = CaptainAmericaHP - 5;
            pbCaptainAmericaHP.Value = CaptainAmericaHP;
            txtCaptainAmericaHP.Text = CaptainAmericaHP.ToString();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            ContinueCounter = ContinueCounter + 1;
            imgCaptainAmerica.Opacity = 100;

            if (ContinueCounter != 2)
            {
                imgIronMan.Opacity = 0;
                imgThrow.Opacity = 0;
                tbDisplay.Text = "Iron Man blasts Captain America. Captain America is hurt.";
                imgBlast.Opacity = 100;
                Blast();    
            }

            else if(ContinueCounter == 2)
            {
                imgIronMan.Opacity = 100;
                imgBlast.Opacity = 0;
                btnContinue.Opacity = 0;
                tbDisplay.Text = "Defend yourself!";
                btnThrow.Opacity = 100;
                btnContinue.IsEnabled = false;
                ContinueCounter = 0;
                btnThrow.IsEnabled = true;
            }


        }
    }
}
