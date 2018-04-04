using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using FontAwesome.WPF;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Onallo_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    
    {
       
        int DobasokSzama = 0;
        Random DoboKocka = new Random();
        FontAwesomeIcon[] Kartyak = new FontAwesomeIcon[4];
        TimeSpan hatralevoIdo=TimeSpan.FromSeconds(3);
        DispatcherTimer Idozito;



        FontAwesomeIcon Elozokartya = FontAwesomeIcon.None;
        

        public MainWindow()
        {
            InitializeComponent();
            //Kártyák létrehozása
            Kartyak[0] = FontAwesomeIcon.Gift;
            Kartyak[1] = FontAwesomeIcon.Github;
            Kartyak[2] = FontAwesomeIcon.Glass;
            Kartyak[3] = FontAwesomeIcon.Gamepad;



            Idozito = new DispatcherTimer(TimeSpan.FromSeconds(1)
                , DispatcherPriority.Normal
                , OraUtes
                , Application.Current.Dispatcher);
        }

        private void OraUtes(object sender, EventArgs e)
        {
            hatralevoIdo = hatralevoIdo - TimeSpan.FromSeconds(1);
            BackTime.Content = $"Visszaszámláló: {hatralevoIdo}";
            if (hatralevoIdo==TimeSpan.Zero)
            {
                JatekVege();

               
            }
        }

        private void JatekVege()
        {
            Idozito.Stop();
            MessageBoxResult S = MessageBox.Show("VÉGE A JÁTÉKNAK. Folytatod????", "ttt", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (S == MessageBoxResult.Yes)
            {
                JatekVege();
            }

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewCardShow();
           

        }
        /// <summary>
        /// Ez a függvény új kártyát ad az Új kártya az Igen és a Nem válasz esetén is.
        /// </summary>
        private void NewCardShow()
        {
           

           
            var Dobas = DoboKocka.Next(0, 3);

            Debug.WriteLine(DobasokSzama);
            Elozokartya = RightCard.Icon;
            RightCard.Icon = Kartyak[Dobas];
            //Régi kártí WLTÜNTETÉSE

            var AnimOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(200));
            RightCard.BeginAnimation(OpacityProperty, AnimOut);

            var AnimIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(200));
            RightCard.BeginAnimation(OpacityProperty, AnimIn);
           
      

           
            DobasokSzama++;
            
            if (DobasokSzama > 1)
            {
                NoButton.IsEnabled = true;
                YesButton.IsEnabled = true;
                NewButton.IsEnabled = false;
            }


            //if (Dobas == 0)
            //{
            //    Elso++;
            //}
            //One.Content = Elso;
            //if (Dobas == 1)
            //{
            //    Masodik++;
            //}
            //Two.Content = Masodik;
            //if (Dobas == 2)
            //{
            //    Harmadik++;
            //}
            //Three.Content = Harmadik;
        }



        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            YesAnswer();
        }

        private void YesAnswer()
        {
            if (Elozokartya == RightCard.Icon)
            {
                CorrectAnswer();

            }
            else
            {
                IncorrectAnswer();
            }
            NewCardShow();
        }


        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            NoAnswer();

        }

        private void NoAnswer()
        {
            if (Elozokartya == RightCard.Icon)
            {
                IncorrectAnswer();
            }
            else
            {
                CorrectAnswer();
            }
            NewCardShow();
        }

        private  void CorrectAnswer()
        {
            LeftCardPlace.Icon = FontAwesomeIcon.Check;
            LeftCardPlace.Foreground = Brushes.Green;
            //animáció
            EltuntetoAnimacio();

        }

        private void EltuntetoAnimacio()
        {
            var Nimation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            LeftCardPlace.BeginAnimation(OpacityProperty, Nimation);
        }

        private  void IncorrectAnswer()
        {
            LeftCardPlace.Icon = FontAwesomeIcon.Times;
            LeftCardPlace.Foreground = Brushes.Red;
            Debug.WriteLine("A válasz helytelen");
            EltuntetoAnimacio();

        }
        /// <summary>
        /// Billentyű lenyomására történő viselkedés
        /// </summary>
        /// <param name="sender"></param>.
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key);
            if (e.Key==Key.Left && DobasokSzama>1)
            {
                YesAnswer();
            }
            if (e.Key == Key.Right && DobasokSzama > 1)
            {
                NoAnswer();
            }


        }

     
        

      
    }
}
