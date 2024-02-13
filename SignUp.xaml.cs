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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private string[] _imagePaths;
        private int _currentImageIndex;
        public SignUp()
        {
            InitializeComponent();
            // Change this path to your own image directory

            _imagePaths = Directory.GetFiles(@"C:\TemaMVP\Imagini\users", "*.png");
            // Set the initial image
            if (_imagePaths.Length > 0)
            {
                SetImage(_imagePaths[0]);
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex < _imagePaths.Length - 1)
            {
                _currentImageIndex++;
                SetImage(_imagePaths[_currentImageIndex]);
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex > 0)
            {
                _currentImageIndex--;
                SetImage(_imagePaths[_currentImageIndex]);
            }
        }

        private void SetImage(string imagePath)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            imageSignUp.Source = bitmap;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sign_in a = new sign_in();
            this.Close();
            a.Show();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sign_in sign_In = new sign_in();
            this.Close();
            sign_In.Show();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

            string inputString = NicknameTextBox.Text;
            string filePath = "C:\\TemaMVP\\Imagini\\username.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(writer.NewLine);
                writer.Write(inputString);
                writer.Write(" ");
                writer.Write(_imagePaths[_currentImageIndex]);
                writer.Write(" 0 0");

            }
            sign_in mw = new sign_in();
            this.Close();
            mw.Show();
        }

    }
    
}
   
