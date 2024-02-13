using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace TemaMVP {
    /// <summary>
    /// Interaction logic for ChooseGame.xaml
    /// </summary>
    public partial class ChooseGame : Window {
        Users username;
        public ChooseGame(Users username) {
            InitializeComponent();
            this.username = username;
        }


        private void Back(object sender, RoutedEventArgs e) {
            sign_in sig=new sign_in();
            sig.Show();
            this.Close();
        }

        private void Resume_Game(object sender, RoutedEventArgs e) {
            string path = "../../SaveJoc/" + username.Username;
            if (!File.Exists(path)) {
                resume.IsEnabled = false;
                return;
            }
            Resume win = new Resume(username);
            win.Show();
            this.Close();
        }

        private void New_Game(object sender, RoutedEventArgs e) {
            AlegereDimensiune win = new AlegereDimensiune(username);
            win.Show();
            this.Close();
        }

        private void Statistica(object sender, RoutedEventArgs e) {
            Statistica statistica = new Statistica(username);
            statistica.Show();
            this.Close();
        }
    }
}


