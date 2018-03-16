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
            Kartyak[0] = FontAwesomeIcon.Gamepad;
            Kartyak[1] = FontAwesomeIcon.Globe;
            Kartyak[2] = FontAwesomeIcon.Glass;
            Kartyak[3] = FontAwesomeIcon.Google;
         

            var kocka = new Random();
            var dobas = kocka.Next(0, 3);
            Debug.WriteLine(dobas);

            RightCard.Icon = Kartyak[dobas];


        }
    }
}
