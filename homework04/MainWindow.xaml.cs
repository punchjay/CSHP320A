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
            string usPattern = @"^\d{5}(\-\d{4})?$";
            string caPattern = @"^[A-Z]\d[A-Z]( )?\d[A-Z]\d$/i";

            Regex usRegex = new Regex(usPattern);
            Regex caRegex = new Regex(caPattern);

            bool usZipCode = usRegex.IsMatch(zipCode);
            bool caZipCode = caRegex.IsMatch(zipCode);
            bool isZipCodeMatch = usZipCode || caZipCode;

            if (isZipCodeMatch)
            {
                MessageBox.Show(usZipCode.ToString());
                uxSubmitZipCodeBt.IsEnabled = true;
            }
            else
            {
                uxSubmitZipCodeBt.IsEnabled = false;
            }
            return isZipCodeMatch;
        }

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsZipCode(uxZipCode.Text.ToString());
        }

        private void uxSubmitZipCodeBt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zip Code: " + uxZipCode.Text);
            uxZipCode.Clear();
            uxSubmitZipCodeBt.IsEnabled = false;
        }
    }
}
