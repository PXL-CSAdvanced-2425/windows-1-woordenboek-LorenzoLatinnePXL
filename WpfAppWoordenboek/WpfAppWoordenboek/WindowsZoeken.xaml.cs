using ClassLib;
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

namespace WpfAppWoordenboek
{
    /// <summary>
    /// Interaction logic for WindowsZoeken.xaml
    /// </summary>
    public partial class WindowsZoeken : Window
    {
        List<string> englishWords = Wachtwoorden.Dictionary.Keys.ToList();
        Random rnd = new Random();

        public WindowsZoeken(MainWindow window)
        {
            InitializeComponent();
        }

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            englishTextBox.Text = englishWords[rnd.Next(0, englishWords.Count)];

            //int randomNumber = rnd.Next(0, Wachtwoorden.Dictionary.Keys.Count);
            //string wordToGuess = "";
            //int counter = 0;

            //foreach (string englishWord in Wachtwoorden.Dictionary.Keys)
            //{
            //    if (counter == randomNumber)
            //    {
            //        wordToGuess = englishWord;
            //        break;
            //    }
            //    counter++;
            //}
            //englishTextBox.Text = wordToGuess;
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(englishTextBox.Text) && !String.IsNullOrEmpty(dutchTextBox.Text))
            {
                if (Wachtwoorden.Dictionary[englishTextBox.Text] == dutchTextBox.Text)
                {
                    MessageBox.Show("Correct geraden!", "Correct!", MessageBoxButton.OK, MessageBoxImage.Information);
                    dutchTextBox.Clear();
                    searchButton_Click(null, null);
                }
                else
                {
                    MessageBox.Show($"Dit is niet correct geraden! Het juiste woord was: {Wachtwoorden.Dictionary[englishTextBox.Text].ToUpper()}", "Wrong!", MessageBoxButton.OK, MessageBoxImage.Error);
                    dutchTextBox.Clear();
                }
            }
        }
    }
}
