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
            ShowInTaskbar = true;
        }

        public WishListModel WishList { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            WishList = new WishListModel();

            WishList.Brand = uxBrand.Text;
            WishList.Description = uxDescription.Text;
            WishList.Price = decimal.Parse(uxPrice.Text);
            WishList.Sku = uxSku.Text;
            WishList.InStock = bool.Parse(uxInstock.Text);
            WishList.Qty = int.Parse(uxQty.Text);
            WishList.Notes = uxNotes.Text;
            WishList.CreatedDate = DateTime.Now;

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (WishList != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                WishList = new WishListModel();
                WishList.CreatedDate = DateTime.Now;
            }
            uxGrid.DataContext = WishList;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

