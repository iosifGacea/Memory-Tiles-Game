using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TemaMVP {
    /// <summary>
    /// Interaction logic for Matrice.xaml
    /// </summary>
    public partial class Matrice : Window {

        private List<string> _imagePaths;
        private List<BitmapImage> selectedImages;
        int numRows;
        int numCols;
        Users username;
        public Matrice(int numRows, int numCols, Users username) {

            InitializeComponent();
            this.numRows = numRows;
            this.numCols = numCols;
            this.username = username;
            nume_user.Text= username.Username;
            SelectRandomImages((numRows * numCols) / 2);
            DisplayMatrix(numRows, numCols);
        }

        private void SelectRandomImages(int nButtons) {
            _imagePaths = Directory.GetFiles(@"../../Imagini/animale", "*.png").ToList();
            selectedImages = new List<BitmapImage>();
            List<BitmapImage> nonDuplicatedSelectedImages = new List<BitmapImage>();
            Random random = new Random();
            List<string> distinctRandomPaths = _imagePaths
                .OrderBy(x => random.Next())
                .Distinct()
                .Take(nButtons)
                .ToList();
            _imagePaths.Clear();
            foreach (string distinctRandomPath in distinctRandomPaths) {
                _imagePaths.Add(distinctRandomPath);
                _imagePaths.Add(distinctRandomPath);
            }

            foreach (string path in distinctRandomPaths) {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                bitmapImage.EndInit();
                nonDuplicatedSelectedImages.Add(bitmapImage);
            }


            foreach (BitmapImage bitmapImage in nonDuplicatedSelectedImages) {
                selectedImages.Add(bitmapImage);
            }
            foreach (BitmapImage bitmapImage in nonDuplicatedSelectedImages) {
                selectedImages.Add(bitmapImage);
            }

        }
        private void DisplayMatrix(int numRows, int numCols) {

            matrixGrid.Children.Clear();

            matrixGrid.RowDefinitions.Clear();
            matrixGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < numRows; i++) {
                matrixGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < numCols; i++) {
                matrixGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < numRows; row++) {
                for (int col = 0; col < numCols; col++) {
                    Button button = new Button();
                    button.Background = Brushes.White;
                    button.Click += Button_Click;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    matrixGrid.Children.Add(button);

                    BitmapImage randomImage = GetRandomImage();
                    Image image = new Image();
                    image.Source = randomImage;
                    image.Visibility = Visibility.Hidden;
                    button.Content = image;

                }
            }
        }


        private Button firstButton = null;
        private Button secondButton = null;
        private string pathFirstButton;
        private string pathSecondButton;

        private async void Button_Click(object sender, RoutedEventArgs e) {

            Button button = (Button)sender;

            if (firstButton == null) {
                firstButton = button;
                (firstButton.Content as Image).Visibility = Visibility.Visible;
                pathFirstButton = ((button.Content as Image).Source as BitmapImage).UriSource.OriginalString;

            }
            else {
                secondButton = button;
                (secondButton.Content as Image).Visibility = Visibility.Visible;
                pathSecondButton = ((button.Content as Image).Source as BitmapImage).UriSource.OriginalString;

                if (pathFirstButton.Equals(pathSecondButton)) {
                    await Task.Delay(500);
                    firstButton.IsEnabled = false;
                    firstButton.Visibility = Visibility.Collapsed;
                    secondButton.IsEnabled = false;
                    secondButton.Visibility = Visibility.Collapsed;
                    selectedImages.RemoveAll(img => img.UriSource.OriginalString == pathSecondButton);
                }
                else {
                    await Task.Delay(500);
                    (firstButton.Content as Image).Visibility = Visibility.Hidden;
                    (secondButton.Content as Image).Visibility = Visibility.Hidden;
                }
                firstButton = null;
                secondButton = null;

                
                if (selectedImages.Count.Equals(0)) {
                    Users userToIncrement = GameView.users.FirstOrDefault(u => u.Username == username.Username);
                    userToIncrement.joc_jucat++;
                    GameView.joc_castigat ++;

                    if (GameView.joc_castigat == 3) {
                        GameView.joc_castigat = 0;
                        MessageBox.Show("You won!");
                        userToIncrement.joc_castigat++;
                    }
                    GameView.UpdateTxtFile(userToIncrement);

                    AlegereDimensiune window = new AlegereDimensiune(username);
                    window.Show();
                    this.Close();
                    return;
                }
            }
        }


        private BitmapImage GetRandomImage() {
            Random random = new Random();
            int randomIndex = random.Next(0, _imagePaths.Count - 1);
            string randomPath = _imagePaths[randomIndex];

            _imagePaths.Remove(randomPath);

            return new BitmapImage(new Uri(randomPath, UriKind.RelativeOrAbsolute));
        }

        private void Back(object sender, RoutedEventArgs e) {
            ChooseGame game = new ChooseGame(username);
            game.Show();
            this.Close();
        }

        private void Exit_(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Save_(object sender, RoutedEventArgs e) {
            GameView.saveAndExit(matrixGrid, numRows, numCols, username);
            MessageBox.Show("Your game was saved with success!");
        }

        private void Statistica_(object sender, RoutedEventArgs e) {
            Statistica statistica = new Statistica(username);
            statistica.Show();
            this.Close();
        }
    }
}
