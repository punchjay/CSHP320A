using System.Windows;
using System.Windows.Controls;

namespace homework05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int userTurn;

        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "To begin Tic-Tac-Toe, X goes first, then O.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (userTurn == 1)
            {
                clickedButton.Content = "O";
                uxTurn.Text = "X's turn.";
            }
            else
            {
                clickedButton.Content = "X";
                uxTurn.Text = "O's turn.";
            }
            clickedButton.IsEnabled = false;
            //win(clickedButton.Content.ToString());
            userTurn += 1;
            if (userTurn > 2) userTurn = 1;
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in uxGrid.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
                uxTurn.Text = "To begin Tic-Tac-Toe, X goes first, then O.";
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
