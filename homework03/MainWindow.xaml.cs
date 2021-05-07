using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace homework03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Models.User> Users = new List<Models.User>
            {
                new Models.User { Name = "Steve", Password="2StevePwd" },
                new Models.User { Name = "Dave", Password = "1DavePwd" },
                new Models.User { Name="Lisa", Password="3LisaPwd" }
            };

            uxList.ItemsSource = Users;
        }

        private void uxList_Click(object sender, RoutedEventArgs e)
        {
            CollectionView userView = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            userView.SortDescriptions.Clear();

            var columnHeader = (e.OriginalSource as GridViewColumnHeader).Column.Header.ToString();
            if (columnHeader == "User Name") userView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            if (columnHeader == "User Password") userView.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }
    }
}
