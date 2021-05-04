using System.Collections.Generic;
using System.Windows;

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
                new Models.User { Name = "Dave", Password = "1DavePwd" },
                new Models.User { Name = "Steve", Password="2stevePwd" },
                new Models.User { Name="Lisa", Password="3lisaPwd" }
            };

            uxList.ItemsSource = Users;
        }
    }
}
