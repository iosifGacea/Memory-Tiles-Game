using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Documents;

namespace TemaMVP {
    public static class GameView {
        private static Button firstButton = null;
        private static Button secondButton = null;
        private static string pathFirstButton;
        private static string pathSecondButton;

        public static int joc_castigat = 0;
        public static int joc_jucat = 0;
        public static List<Users> users = new List<Users>();
        public static void createGrid(Grid grid, int numRows, int numCols) {
            // Clear any existing buttons from the grid
            grid.Children.Clear();

            // Set up the grid
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < numRows; i++) {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < numCols; i++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public static void saveAndExit(Grid grid, int numRows, int numCols, Users username) {
            GridData g = new GridData();
            g.ButtonStates = new GridData.MatrixElement[numRows, numCols];
            GridData.MatrixElement el;
            for (int i = 0; i < numRows; i++) {
                for (int j = 0; j < numCols; j++) {
                    Button button = grid.Children
                                            .OfType<Button>()
                                            .FirstOrDefault(e => Grid.GetRow(e) == i && Grid.GetColumn(e) == j);
                    if (button.Visibility.Equals(Visibility.Visible)) {
                        el.visibility = true;
                        el.filePath = ((button.Content as Image).Source as BitmapImage).UriSource.OriginalString;
                        g.ButtonStates[i, j] = el;
                    }
                    else {
                        el.visibility = false;
                        el.filePath = "";
                        //el.filePath = ((button.Content as Image).Source as BitmapImage).UriSource.OriginalString;
                        g.ButtonStates[i, j] = el;
                    }
                }
            }
            string directoryPath = @"..\..\SaveJoc";
            string filePath = Path.Combine(directoryPath, username.Username);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            //File.Create(filePath);

            using (StreamWriter fileStream = File.CreateText(filePath)) {
                fileStream.Dispose();
                DataSerialization.BinarySerialization(g, filePath);
            }
        }
        public static List<Users> Clasament() {
            List<Users> list = new List<Users>();
            list=users.OrderByDescending(x => x.joc_castigat).ToList();
            return list;
        }
        public static void UpdateTxtFile(Users user) {
            users=Clasament();
            File.WriteAllText(@"../../Imagini/username.txt", string.Join(Environment.NewLine, users.Select(u => u.Username + " " + u.ImagePath + " " + u.joc_castigat + " " + u.joc_jucat)));
        }
    }
}