using System.Text.RegularExpressions;
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
            uxZipCode.MaxLength = 10;
        }

        public bool IsZipCode(string zipCode)
        {
            string pattern = @"^\d{5}(\-\d{4})?$";
            //var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
            Regex regex = new Regex(pattern);
            bool m = regex.IsMatch(zipCode);
            MessageBox.Show(m.ToString());
            return regex.IsMatch(zipCode);
        }

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxZipCode.Text.Length >= 5)
            {
                uxSubmitZipCodeBt.IsEnabled = true;
                IsZipCode(uxZipCode.Text.ToString());
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
