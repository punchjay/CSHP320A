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
            CheckGameWinner(clickedButton.Content.ToString());
            userTurn += 1;
            if (userTurn > 2) userTurn = 1;
        }

        private void CheckGameWinner(string btnContent)
        {
            foreach (Button btn in uxGrid.Children)
            {
                if ((string)btn.Content == btnContent & (string)btn.Content == btnContent & (string)btn.Content == btnContent)
                {
                    if (btnContent == "O")
                    {
                        uxTurn.Text = "O is the winner!!!";
                    }
                    else if (btnContent == "X")
                    {
                        uxTurn.Text = "X is the winner!!!";
                    }
                }
                else
                {
                    if (btn.IsEnabled == true) return;
                    uxTurn.Text = "Draw, no one is the winner!!!";
                }
            }
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
