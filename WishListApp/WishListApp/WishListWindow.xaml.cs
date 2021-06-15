using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WishListApp.Models;

namespace WishListApp
{
    /// <summary>
    /// Interaction logic for WishListWindow.xaml
    /// </summary>
    public partial class WishListWindow : Window
    {
        public WishListWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public WishListModel WishList { get; set; }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void UxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (WishList != null)
            {
                UxSubmit.Content = "Update";
            }
            else
            {
                WishList = new WishListModel
                {
                    CreatedDate = DateTime.Now
                };
            }
            UxGrid.DataContext = WishList;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

