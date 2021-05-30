using System;
using System.Windows;
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

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            WishList = new WishListModel();

            WishList.Brand = uxBrand.Text;
            WishList.Description = uxDescription.Text;
            WishList.Price = decimal.Parse(uxPrice.Text);
            WishList.Sku = int.Parse(uxSku.Text);
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
    }
}

