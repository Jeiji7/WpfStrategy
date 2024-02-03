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
using WpfStrategy.Scripts;

namespace WpfStrategy.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoadPlayer.xaml
    /// </summary>
    public partial class LoadPlayer : Page
    {
        public LoadPlayer()
        {
            InitializeComponent();
            PlayerList.ItemsSource = CRUD.AllShowInfo();
        }

        private void RoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CurrentPlayer = (Player)PlayerList.SelectedItem;
            LocationGame editPage = new LocationGame(CurrentPlayer);
            NavigationService.Navigate(editPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }
    }
}
