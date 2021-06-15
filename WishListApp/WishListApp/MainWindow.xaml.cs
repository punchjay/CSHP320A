using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WishListApp.Models;

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
            WishList = WishListRepository.WishListRepository.GetAll();

            UxWishListList.ItemsSource = WishList
                .Select(t => WishListModel.ToModel(t))
                .ToList();

            UxStatus.Text = $"You currently have {WishList.Count} items in your Wish List";
        }

        private void UxFileChange_Click(object sender, RoutedEventArgs e)
        {
            WishListWindow window = new()
            {
                WishList = selectedWishList.Clone()
            };

            if (window.ShowDialog() == true)
            {
                WishListRepository.WishListRepository.Update(window.WishList.ToRepositoryModel());
                LoadWishLists();
            }
        }

        private void UxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            UxFileChange.IsEnabled = selectedWishList != null;
            UxContextFileChange.IsEnabled = UxFileChange.IsEnabled;
        }

        private void UxFileNew_Click(object sender, RoutedEventArgs e)
        {
            WishListWindow window = new();

            if (window.ShowDialog() == true)
            {
                WishListModel uiWishListModel = window.WishList;
                WishListRepository.WishListModel repositoryWishListModel = uiWishListModel.ToRepositoryModel();

                WishListRepository.WishListRepository.Add(repositoryWishListModel);
                LoadWishLists();
            }
        }

        // Important Method: detect if selection has been made
        private void UxWishListList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedWishList = (WishListModel)UxWishListList.SelectedValue;
            UxContextFileDelete.IsEnabled = selectedWishList != null;
        }

        private void UxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            WishListRepository.WishListRepository.Remove(selectedWishList.Id);
            selectedWishList = null;
            LoadWishLists();
        }

        private void UxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            UxFileDelete.IsEnabled = selectedWishList != null;
        }

        private void UxFileQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void UxWishListList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UxFileChange_Click(sender, null);
        }

        private void UxSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regexNums = new("[^0-9]+");
            string searchBox = UxSearchBox.Text;
            bool isRegexMatch = regexNums.IsMatch(searchBox);

            if (!isRegexMatch && searchBox.Length == 4)
            {
                WishList = WishListRepository.WishListRepository.GetAll();

                IEnumerable<WishListRepository.WishListModel> SkuSearch =
                    from w in WishList
                    where w.Sku == UxSearchBox.Text
                    select w;

                UxWishListList.ItemsSource = SkuSearch
                    .Select(t => WishListModel.ToModel(t))
                    .ToList();
            }
            else
            {
                LoadWishLists();
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                UxWishListList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
            {
                newDir = ListSortDirection.Descending;
            }

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            UxWishListList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

    }
}
