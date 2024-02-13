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

namespace TemaMVP
{
    /// <summary>
    /// Interaction logic for sign_in.xaml
    /// </summary>
    public partial class sign_in : Window
    {
        List<Users> usersList;
        public sign_in()
        {
            InitializeComponent();
            usersList =new List<Users>();
            string[] line = File.ReadAllLines("../../Imagini/username.txt");

            foreach (string line2 in line)
            {
                string[] parts = line2.Split(' ');
                usersList.Add(new Users { Username=parts[0], ImagePath=parts[1], joc_castigat=int.Parse(parts[2]), joc_jucat=int.Parse(parts[3])});
            }
            listBoxSignUp.DataContext = usersList;
            GameView.users = usersList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Close();
            signUp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Button_Click_Play(object sender, RoutedEventArgs e)
        {
            Users selectedUser = (Users)listBoxSignUp.SelectedItem;
            Users username = selectedUser;
            ChooseGame mw = new ChooseGame(username);
            this.Close();
            mw.Show();
        }

        private void listBoxSignUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users selectedUser = (sender as ListBox).SelectedItem as Users;
            if (selectedUser != null)
            {
                imageSignUp.Source = new BitmapImage(new Uri(selectedUser.ImagePath));
                Play.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
           
            Users selectedUser = (Users)listBoxSignUp.SelectedItem;
            if (selectedUser != null)
            {
                usersList.Remove(selectedUser);
                File.WriteAllText("../../Imagini/username.txt", string.Join(Environment.NewLine, usersList.Select(u => u.Username + " " + u.ImagePath+ " "+u.joc_jucat+" "+ u.joc_castigat)));
                listBoxSignUp.SelectedItem = null;
                listBoxSignUp.Items.Refresh();
                imageSignUp.Source = null;
                Play.Visibility = Visibility.Hidden;
            }
        }
    } 
}
