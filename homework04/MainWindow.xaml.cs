using System.Windows;
using System.Windows.Controls;

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
            uxZipCode.MaxLength = 5;
        }

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxZipCode.Text.Length >= 5)
            {
                uxSubmitZipCodeBt.IsEnabled = true;
            }
        }

        private void uxSubmitZipCodeBt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zip Code: " + uxZipCode.Text);
            uxZipCode.Clear();
            uxSubmitZipCodeBt.IsEnabled = false;
        }
    }
}
