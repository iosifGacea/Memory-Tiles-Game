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
using static TemaMVP.GridData;
using Path = System.IO.Path;

namespace TemaMVP {
    /// <summary>
    /// Interaction logic for Resume.xaml
    /// </summary>
    public partial class Resume : Window {
        
        private int numRows;
        private int numCols;
        private List<string> selectedImages;
        Users username;

        public Resume(Users username) {
            InitializeComponent();
            this.username = username;
            DisplayMatrix();
        }

        private void DisplayMatrix() {
            // Deserialize the matrix data from the file
            GridData matrix;
            string directoryPath = @"..\..\SaveJoc";
            string filePath=Path.Combine(directoryPath, username.Username);
            matrix = (GridData)DataSerialization.BinaryDeserialization(filePath);
            MatrixElement[,] m = matrix.ButtonStates;

            selectedImages = matrix.ButtonStates.Cast<GridData.MatrixElement>()
                                   .Select(me => me.filePath)
                                   .Where(fp => !string.IsNullOrEmpty(fp))
                                   .ToList();

            numRows = m.GetLength(0);
            numCols = m.GetLength(1);
            GameView.createGrid(matrixGrid, numRows, numCols);

            for (int row = 0; row < numRows; row++) {
                for (int col = 0; col < numCols; col++) {
                    Button button = new Button();
                    button.Background = Brushes.White;
                    button.Click += Button_Click;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    matrixGrid.Children.Add(button);


                    if (m[row, col].visibility.Equals(true)) {
                        BitmapImage randomImage = new BitmapImage(new Uri(m[row, col].filePath, UriKind.RelativeOrAbsolute));
                        Image image = new Image();
                        image.Source = randomImage;
                        image.Visibility = Visibility.Hidden;
                        button.Content = image;
                    }
                    else {
                        button.Visibility = Visibility.Collapsed;
                    }

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
                // This is the first button clicked
                firstButton = button;
                (firstButton.Content as Image).Visibility = Visibility.Visible;
                pathFirstButton = ((button.Content as Image).Source as BitmapImage).UriSource.OriginalString;
                //disable it

            }
            else {
                // This is the second button clicked
                secondButton = button;
                (secondButton.Content as Image).Visibility = Visibility.Visible;
                pathSecondButton = ((button.Content as Image).Source as BitmapImage).UriSource.OriginalString;

                if (pathFirstButton.Equals(pathSecondButton)) {
                    // The two buttons have the same image content, disable them
                    await Task.Delay(500);
                    firstButton.IsEnabled = false;
                    firstButton.Visibility = Visibility.Collapsed;
                    secondButton.IsEnabled = false;
                    secondButton.Visibility = Visibility.Collapsed;
                    selectedImages.RemoveAll(img => img == pathSecondButton);
                }
                else {
                    // The two buttons have different image content, hide the images
                    await Task.Delay(500);
                    (firstButton.Content as Image).Visibility = Visibility.Hidden;
                    (secondButton.Content as Image).Visibility = Visibility.Hidden;
                }
                firstButton = null;
                secondButton = null;
                if (selectedImages.Count.Equals(0)) {
                    Users userToIncrement = GameView.users.FirstOrDefault(u => u.Username == username.Username);
                    userToIncrement.joc_jucat++;
                    GameView.joc_castigat++;

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
            this.Close();
        }
    }
}
