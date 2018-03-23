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


namespace Onallo_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    
    {
        int Elso = 0;
        int Masodik = 0;
        int Harmadik= 0;
        int DobasokSzama = 0;
       
       

        FontAwesomeIcon Elozokartya = FontAwesomeIcon.None;
        

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Menu_Checked(object sender, RoutedEventArgs e)
        {

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
            //Kártyák létrehozása
            var Kartyak = new FontAwesomeIcon[4];
            Kartyak[0] = FontAwesomeIcon.Gift;
            Kartyak[1] = FontAwesomeIcon.Github;
            Kartyak[2] = FontAwesomeIcon.Glass;
            Kartyak[3] = FontAwesomeIcon.Gamepad;

            var DoboKocka = new Random();
            var Dobas = DoboKocka.Next(0, 3);

            Debug.WriteLine(DobasokSzama);
            Elozokartya = RightCard.Icon;
            RightCard.Icon = Kartyak[Dobas];
           
            DobasokSzama++;
            
            if (DobasokSzama > 1)
            {
                NoButton.IsEnabled = true;
                YesButton.IsEnabled = true;
                NewButton.IsEnabled = false;
            }


            if (Dobas == 0)
            {
                Elso++;
            }
            One.Content = Elso;
            if (Dobas == 1)
            {
                Masodik++;
            }
            Two.Content = Masodik;
            if (Dobas == 2)
            {
                Harmadik++;
            }
            Three.Content = Harmadik;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (Elozokartya==RightCard.Icon)
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
            Debug.WriteLine("A válasz helyes");
    
         
       
        }

        private  void IncorrectAnswer()
        {
            LeftCardPlace.Icon = FontAwesomeIcon.CheckCircle;
            Debug.WriteLine("A válasz helytelen");
            
         
        }
    }
}
