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

namespace WpfStrategy.Pages
{
    /// <summary>
    /// Логика взаимодействия для LocationGame.xaml
    /// </summary>
    public partial class LocationGame : Page
    {
        public LocationGame(Scripts.Player currentPlayer)
        {
            InitializeComponent();
            NamePlayerTB.Text = currentPlayer.Name;
            ClassPlayerTB.Text = currentPlayer.Class;
            LvlPlayerTB.Text = Convert.ToString(currentPlayer.Lvl);
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.LoadPlayer());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
