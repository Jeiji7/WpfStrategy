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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        //public Player player;
        public MainMenu()
        {
            InitializeComponent();

        }

        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.LoadPlayer());
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text != "" && ClassPlayerCB.Text != "")
            {
                Player player = new Player(NameTB.Text, ClassPlayerCB.Text, 0);
                CRUD.CreateUser(player);
                MessageBox.Show("Kaif");
                NavigationService.Navigate(new Pages.LocationGame(player));
            }
            else
            {
                NameTB.Text = "";
                ClassPlayerCB.Text = "";
                MessageBox.Show("Вы не заполнили важные данные!!!");
            }
        }
    }
}
