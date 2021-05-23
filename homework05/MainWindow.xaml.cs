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
            var clickedBtn = sender as Button;
            if (userTurn == 1)
            {
                clickedBtn.Content = "O";
                uxTurn.Text = "X's turn.";
            }
            else
            {
                clickedBtn.Content = "X";
                uxTurn.Text = "O's turn.";
            }
            clickedBtn.IsEnabled = false;
            CheckGameWinner(clickedBtn);
            userTurn += 1;
            if (userTurn > 1) userTurn = 0;
        }

        private void CheckGameWinner(Button btnClicked)
        {
            if ((Button1.Content == btnClicked.Content & Button2.Content == btnClicked.Content & Button3.Content == btnClicked.Content)
                || (Button1.Content == btnClicked.Content & Button4.Content == btnClicked.Content & Button7.Content == btnClicked.Content)
                || (Button1.Content == btnClicked.Content & Button5.Content == btnClicked.Content & Button9.Content == btnClicked.Content)
                || (Button2.Content == btnClicked.Content & Button5.Content == btnClicked.Content & Button8.Content == btnClicked.Content)
                || (Button3.Content == btnClicked.Content & Button6.Content == btnClicked.Content & Button9.Content == btnClicked.Content)
                || (Button4.Content == btnClicked.Content & Button5.Content == btnClicked.Content & Button6.Content == btnClicked.Content)
                || (Button7.Content == btnClicked.Content & Button8.Content == btnClicked.Content & Button9.Content == btnClicked.Content)
                || (Button3.Content == btnClicked.Content & Button5.Content == btnClicked.Content & Button7.Content == btnClicked.Content))
            {
                if ((string)btnClicked.Content == "O")
                {
                    uxTurn.Text = "O is the winner!!!";
                }
                else if ((string)btnClicked.Content == "X")
                {
                    uxTurn.Text = "X is the winner!!!";
                }
                foreach (Button btn in uxGrid.Children)
                {
                    btn.IsEnabled = false;
                }
            }
            //else
            //{
            //    foreach (Button btn in uxGrid.Children)
            //    {
            //        if (btn.IsEnabled == true) return;
            //        uxTurn.Text = "Draw, no one is the winner!!!";
            //    }
            //}
        }

        private void UxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in uxGrid.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
                userTurn = 0;
                uxTurn.Text = "To begin Tic-Tac-Toe, X goes first, then O.";
            }
        }

        private void UxExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
