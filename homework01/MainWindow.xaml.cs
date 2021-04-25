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
            uxSubmit.IsEnabled = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting Password: " + uxPassword.Text);
            uxName.Clear();
            uxPassword.Clear();
            uxSubmit.IsEnabled = false;
        }

        private void textBoxHandleChange() {
            if (uxName.Text.Length >= 1 && uxPassword.Text.Length >= 1) uxSubmit.IsEnabled = true;
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxHandleChange();
        }

        private void uxPassword_TextChange(object sender, TextChangedEventArgs e)
        {
            textBoxHandleChange();
        }
    }
}
