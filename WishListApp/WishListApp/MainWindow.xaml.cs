using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WishListApp.Models;
using System.Collections.Generic;

namespace WishListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol;
        private SortAdorner listViewSortAdorner;
        private WishListModel selectedWishList;
        private List<WishListRepository.WishListModel> WishList;
        public MainWindow()
        {
            InitializeComponent();
            LoadWishLists();
        }

        private void LoadWishLists()
        {
            WishList = App.WishListRepository.GetAll();

            uxWishListList.ItemsSource = WishList
                .Select(t => WishListModel.ToModel(t))
                .ToList();

            uxStatus.Text = $"You currently have {WishList.Count()} items in your Wish List";
        }

        // add this method for doing updates
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new WishListWindow();
            // Exercise 2 for update - fix this to call on Clone()
            window.WishList = selectedWishList.Clone();

            if (window.ShowDialog() == true)
            {
                App.WishListRepository.Update(window.WishList.ToRepositoryModel());
                LoadWishLists();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedWishList != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new WishListWindow();

            if (window.ShowDialog() == true)
            {
                var uiWishListModel = window.WishList;
                var repositoryWishListModel = uiWishListModel.ToRepositoryModel();

                App.WishListRepository.Add(repositoryWishListModel);

                LoadWishLists();
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxWishListList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxWishListList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        // Important Method: detect if selection has been made
        private void uxWishListList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedWishList = (WishListModel)uxWishListList.SelectedValue;

            // Exercise 1 under Delete - fix the context menu
            uxContextFileDelete.IsEnabled = (selectedWishList != null);
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.WishListRepository.Remove(selectedWishList.Id);
            selectedWishList = null;
            LoadWishLists();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedWishList != null);
        }

        private void uxFileQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void uxWishListList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // call on this FileChange Click function with two null parameters
            uxFileChange_Click(sender, null);
        }

        private void uxSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regexNums = new("[^0-9]+");
            string searchBox = uxSearchBox.Text;
            bool isRegexMatch = regexNums.IsMatch(searchBox);

            if (!isRegexMatch && searchBox.Length == 4)
            {
                WishList = App.WishListRepository.GetAll();

                IEnumerable<WishListRepository.WishListModel> SkuSearch =
                    from w in WishList
                    where w.Sku == uxSearchBox.Text
                    select w;

                uxWishListList.ItemsSource = SkuSearch
                    .Select(t => WishListModel.ToModel(t))
                    .ToList();
            }
            else
            {
                LoadWishLists();
            }
        }

    }
}
