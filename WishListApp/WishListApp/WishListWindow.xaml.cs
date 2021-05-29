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
            //WishList.Price = uxPrice.Text;
            //WishList.Sku = uxSku.Text;
            //WishList.InStock = uxInstock.Text;
            //WishList.Qty = uxQty.Text;
            WishList.Notes = uxNotes.Text;
            WishList.CreatedDate = DateTime.Now;

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
    }
}

