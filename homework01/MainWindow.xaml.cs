using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
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

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting Password: " + uxPassword.Text);
            uxName.Clear();
            uxPassword.Clear();
            uxSubmit.IsEnabled = false;
            imgLockOpen.Visibility = Visibility.Collapsed;
        }

        private void TextBoxHandleChange()
        {
            if (uxName.Text.Length >= 1 && uxPassword.Text.Length >= 1)
            {
                uxSubmit.IsEnabled = true;
                imgLockOpen.Visibility = Visibility.Visible;
            }
            else
            {
                uxSubmit.IsEnabled = false;
                imgLockOpen.Visibility = Visibility.Collapsed;
            }
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxHandleChange();
        }

        private void uxPassword_TextChange(object sender, TextChangedEventArgs e)
        {
            TextBoxHandleChange();
        }
    }
}
