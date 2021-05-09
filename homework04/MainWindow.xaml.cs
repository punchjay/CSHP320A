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

namespace homework04
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

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            uxSubmitZipCodeBt.IsEnabled = true;
        }

        private void uxSubmitZipCodeBt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zip Code: " + uxZipCode.Text);
            uxZipCode.Clear();
            uxSubmitZipCodeBt.IsEnabled = false;
        }
    }
}
