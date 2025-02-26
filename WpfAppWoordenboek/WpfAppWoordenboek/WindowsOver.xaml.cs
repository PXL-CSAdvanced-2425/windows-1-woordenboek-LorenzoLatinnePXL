using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for WindowsOver.xaml
    /// </summary>
    public partial class WindowsOver : Window
    {
        public WindowsOver(MainWindow window)
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            productNameLabel.Content += $"{fvi.ProductName}";
            versionLabel.Content += $"{fvi.ProductVersion}";
            companyNameLabel.Content += $"{fvi.CompanyName}";
            copyrightLabel.Content += $"{fvi.LegalCopyright}";
            descriptionLabel.Content += $"{fvi.Comments}";
        }
    }
}
