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
using System.Windows.Shapes;

namespace TemaMVP
{
    /// <summary>
    /// Interaction logic for AlegereDimensiune.xaml
    /// </summary>
    public partial class AlegereDimensiune : Window
    {
        Users username;
        public AlegereDimensiune(Users username) {
            InitializeComponent();
            this.username = username;
        }

        private void Play_Click(object sender, RoutedEventArgs e) {
            int numRows = int.Parse((RowComboBox.SelectedItem as ComboBoxItem).Content.ToString());
            int numCols = int.Parse((ColumnComboBox.SelectedItem as ComboBoxItem).Content.ToString());

            // Check if dimensions make an even number of cells
            if ((numRows * numCols) % 2 != 0) {
                MessageBox.Show("Please select dimensions that make an even number of cells.");
                return;
            }
            var mw = new Matrice(numRows, numCols, username);
            mw.Show();
            this.Close();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e) {
            sign_in signInWindow = new sign_in();
            signInWindow.Show();
            this.Close();
        }

        private void Click_Statistica(object sender, RoutedEventArgs e) {
            Statistica statistica = new Statistica(username);
            statistica.Show();
            this.Close();
        }
    }
}
