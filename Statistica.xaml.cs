using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Statistica.xaml
    /// </summary>
    /// int numRows;
    public partial class Statistica : Window {
      
        public Statistica(Users users) {
           
            InitializeComponent();
            Users userToIncrement = GameView.users.FirstOrDefault(u => u.Username == users.Username);
            string statist=$"{userToIncrement.Username} ai {userToIncrement.joc_jucat.ToString()} jocuri jucate si {userToIncrement.joc_castigat.ToString()} jocuri castigate!";
            stat.Text=statist;
            //ObservableCollection<Users> userCollection = new ObservableCollection<Users>(GameView.users);
            
        }
    }
}
