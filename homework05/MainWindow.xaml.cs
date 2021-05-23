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
            if ((btn01.Content == btnClicked.Content & btn02.Content == btnClicked.Content & btn03.Content == btnClicked.Content)
                || (btn01.Content == btnClicked.Content & btn04.Content == btnClicked.Content & btn07.Content == btnClicked.Content)
                || (btn01.Content == btnClicked.Content & btn05.Content == btnClicked.Content & btn09.Content == btnClicked.Content)
                || (btn02.Content == btnClicked.Content & btn05.Content == btnClicked.Content & btn08.Content == btnClicked.Content)
                || (btn03.Content == btnClicked.Content & btn06.Content == btnClicked.Content & btn09.Content == btnClicked.Content)
                || (btn04.Content == btnClicked.Content & btn05.Content == btnClicked.Content & btn06.Content == btnClicked.Content)
                || (btn07.Content == btnClicked.Content & btn08.Content == btnClicked.Content & btn09.Content == btnClicked.Content)
                || (btn03.Content == btnClicked.Content & btn05.Content == btnClicked.Content & btn07.Content == btnClicked.Content))
            {
                if ((string)btnClicked.Content == "O") uxTurn.Text = "O is the winner!!!";
                else if ((string)btnClicked.Content == "X") uxTurn.Text = "X is the winner!!!";
                foreach (Button btn in uxGrid.Children) btn.IsEnabled = false;
            }
            else
            {
                foreach (Button btn in uxGrid.Children) if (btn.IsEnabled == true) return;
                uxTurn.Text = "Draw, no one is the winner!!!";
            }
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
