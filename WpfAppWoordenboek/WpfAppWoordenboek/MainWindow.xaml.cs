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
using System.IO;
using ClassLib;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;

namespace WpfAppWoordenboek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowWordsInListBox();
        }

        private void ShowWordsInListBox()
        {
            wordsListBox.Items.Clear();

            foreach (KeyValuePair<string, string> kvp in WoordenboekData.Dictionary)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = $"{kvp.Key} - {kvp.Value}";
                wordsListBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content.ToString() == "Toevoegen")
            {
                if (!String.IsNullOrEmpty(englishTextBox.Text) 
                    && !String.IsNullOrEmpty(dutchTextBox.Text) 
                    && !WoordenboekData.Dictionary.ContainsKey(englishTextBox.Text))
                {
                    WoordenboekData.AddWord(englishTextBox.Text, dutchTextBox.Text);
                    ShowWordsInListBox();
                }
                else if (WoordenboekData.Dictionary.ContainsKey(englishTextBox.Text))
                {
                    MessageBox.Show("Can't have the same key twice!");
                }

            }
            else if (button.Content.ToString() == "Verwijderen")
            {
                ListBoxItem selectedItem = wordsListBox.SelectedItem as ListBoxItem;

                if (selectedItem != null)
                {
                    string selectedContent = selectedItem.Content.ToString();
                    string englishWord = selectedContent.Substring(0, selectedContent.IndexOf(" -"));
                    wordsListBox.Items.Remove(selectedItem);
                    WoordenboekData.DeleteWord(englishWord);

                    ShowWordsInListBox();
                }
            }
        }

        private void sluitenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void zoekenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowsZoeken window = new WindowsZoeken(this);
            window.ShowDialog();
        }

        private void infoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowsOver window = new WindowsOver(this);
            window.ShowDialog();
        }
    }
}
