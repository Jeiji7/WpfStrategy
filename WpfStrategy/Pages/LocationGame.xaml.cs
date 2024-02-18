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
using System.Xml.Linq;
using WpfStrategy.Scripts;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using static MongoDB.Libmongocrypt.CryptContext;
using static System.Net.Mime.MediaTypeNames;

namespace WpfStrategy.Pages
{
    public partial class LocationGame : Page
    {
        public Player player;
        public LocationGame(Scripts.Player currentPlayer)
        {
            InitializeComponent();
            

            player = currentPlayer;
            if (player.Imagers == 0)
            {
                ImagePlayer.Source = new BitmapImage(new Uri("/Images/Warrior.png", UriKind.Relative));
            }
            else if (player.Imagers == 1)
            {
                ImagePlayer.Source = new BitmapImage(new Uri("/Images/Rogue.png", UriKind.Relative));
            }
            else if (player.Imagers == 2)
            {
                ImagePlayer.Source = new BitmapImage(new Uri("/Images/Wizard.png", UriKind.Relative));
            }
            NamePlayerTB.Text = currentPlayer.Name;
            ClassPlayerTB.Text = currentPlayer.Class;
            HealthTB.Text = Convert.ToString(Math.Round(currentPlayer.classification.Health, 2));
            ManaTB.Text = Convert.ToString(Math.Round(currentPlayer.classification.Mana, 2));
            DamageTB.Text = Convert.ToString(Math.Round(currentPlayer.classification.Damage, 2));
            ArmorTB.Text = Convert.ToString(Math.Round(currentPlayer.classification.Armor, 2));
            MagicDamageTB.Text = Convert.ToString(Math.Round(currentPlayer.classification.MagicDamage, 2));
            MagicArmorTB.Text = Convert.ToString(Math.Round(currentPlayer.classification.MagicDefense, 2));
            LvlPlayerTB.Text = Convert.ToString(currentPlayer.Lvl);
            StrTB.Text = Convert.ToString(Math.Round(player.classification.Strength, 2));
            DexTB.Text = Convert.ToString(Math.Round(player.classification.Dexterity, 2));
            IntTB.Text = Convert.ToString(Math.Round(player.classification.Inteligence, 2));
            VitTB.Text = Convert.ToString(Math.Round(player.classification.Vitality, 2));
            LvlPlTB.Text = Convert.ToString(currentPlayer.Lvl);
            LvlPointTB.Text = Convert.ToString(player.LvlPoints);
            CountyPointTB.Text = player.CountyPoint.ToString();
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.LoadPlayer());
        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            if (player.Lvl < 50)
            {
                player.LvlPoints = player.LvlPoints + (player.Lvl * 1000);
                player.Lvl += 1;
                player.CountyPoint += 5;
                player.MaxCountyPoint += 5;
                CountyPointTB.Text = player.CountyPoint.ToString();
                LvlPlTB.Text = player.Lvl.ToString();
                CRUD.UpdatePlayerState(player);
                NavigationService.Navigate(new Pages.LocationGame(player));
            }
            else
                MessageBox.Show("Ваш уровень и правда очень высок");

        }
        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            if (player.Lvl > 1)
            {
                player.LvlPoints -= ((player.Lvl - 1) * 1000);
                player.Lvl -= 1;
                player.CountyPoint -= 5;
                player.MaxCountyPoint -= 5;
                CountyPointTB.Text = player.CountyPoint.ToString();
                LvlPlTB.Text = player.Lvl.ToString();
                CRUD.UpdatePlayerState(player);
                NavigationService.Navigate(new Pages.LocationGame(player));

            }
            else
                MessageBox.Show("Самый минемальный уровень");
        }


        private void Button_Click_One(object sender, RoutedEventArgs e)
        {
            if (player.Lvl < 50)
            {
                player.LvlPoints += 500;
                if (player.LvlPoints == (1000 * player.Lvl) + App.Point)
                {
                    App.Point += player.Lvl * 1000;
                    player.Lvl += 1;
                    player.CountyPoint += 5;
                    player.MaxCountyPoint += 5;
                    CountyPointTB.Text = player.CountyPoint.ToString();
                    LvlPlTB.Text = player.Lvl.ToString();
                }
                CRUD.UpdatePlayerState(player);
                NavigationService.Navigate(new Pages.LocationGame(player));
            }
        }

        private void Button_Click_Ten(object sender, RoutedEventArgs e)
        {
            if (player.Lvl < 50)
            {
                player.LvlPoints += 1000;
                if (player.LvlPoints == (1000 * player.Lvl) + App.Point)
                {
                    App.Point += player.Lvl * 1000;
                    player.Lvl += 1;
                    player.CountyPoint += 5;
                    player.MaxCountyPoint += 5;
                    CountyPointTB.Text = player.CountyPoint.ToString();
                    LvlPlTB.Text = player.Lvl.ToString();
                }
                CRUD.UpdatePlayerState(player);
                NavigationService.Navigate(new Pages.LocationGame(player));
            }
        }

        private void Button_Click_Plus_Points(object sender, RoutedEventArgs e)
        {
            Button clickedBut = sender as Button;
            if (player.CountyPoint > 0)
            {
                if (clickedBut.Name == "StrPointPlus")
                {
                    player.classification.Strength += 1;
                    player.CountyPoint -= 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }
                else if (clickedBut.Name == "DexPointPlus")
                {
                    player.classification.Dexterity += 1;
                    player.CountyPoint -= 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }
                else if (clickedBut.Name == "IntPointPlus")
                {
                    player.classification.Inteligence += 1;
                    player.CountyPoint -= 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }
                else
                {
                    player.classification.Vitality += 1;
                    player.CountyPoint -= 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }

            }
        }
        private void Button_Click_Minus_Points(object sender, RoutedEventArgs e)
        {
            Button clickedBut = sender as Button;
            if (player.CountyPoint < player.MaxCountyPoint)
            {
                if (clickedBut.Name == "StrPointMinus" && player.classification.Strength >1)
                {
                    player.classification.Strength -= 1;
                    player.CountyPoint += 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }
                else if (clickedBut.Name == "DexPointMinus" && player.classification.Dexterity > 1)
                {
                    player.classification.Dexterity -= 1;
                    player.CountyPoint += 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }
                else if (clickedBut.Name == "IntPointMinus" && player.classification.Inteligence > 1)
                {
                    player.classification.Inteligence -= 1;
                    player.CountyPoint += 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }
                else if(clickedBut.Name == "VitPointMinus" && player.classification.Vitality > 1)
                {
                    player.classification.Vitality -= 1;
                    player.CountyPoint += 1;
                    NavigationService.Navigate(new Pages.LocationGame(player));
                }

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(WeaponCB.SelectedIndex == 0)
            {
                player.weapons = new CommonArm(1, "one-handed", "Wand", 1, player.classification.Damage + 5, player.classification.Mana + 20, player.classification.Inteligence + 8, player.classification.CritShance * 0.05, player.classification.CritDamage * 3);
                CRUD.UpdatePlayerState(player);
            }
            else if(WeaponCB.SelectedIndex == 1)
            {
                player.weapons = new RareArm(2, "one-handed", "Wand-rare", 1, player.classification.Damage + 5, player.classification.Mana + 20, player.classification.Inteligence + 8+15, player.classification.CritShance * 0.05, player.classification.CritDamage * 3, player.classification.Armor + 2);
                CRUD.UpdatePlayerState(player);
            }
            else if (WeaponCB.SelectedIndex == 2)
            {
                player.weapons = new LegendaryArm(3, "one-handed", "Wand-legendary", 1, player.classification.Damage + 5 + 8, player.classification.Mana + 20, player.classification.Inteligence + 8 + 15, player.classification.CritShance * 0.05, player.classification.CritDamage * 3, player.classification.Armor + 2+2, player.classification.Health + 15);
                CRUD.UpdatePlayerState(player);
            }
        }
    }
}
