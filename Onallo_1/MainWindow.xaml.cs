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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
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
            DobasokSzama++;
            RightCard.Icon = Kartyak[Dobas];
            if (DobasokSzama>1)
            {
                NoButton.IsEnabled = true;
                YesButton.IsEnabled = true;
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
    }
}
