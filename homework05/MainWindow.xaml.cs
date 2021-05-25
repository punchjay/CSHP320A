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
        int[,] Board = new int[3, 3];
        readonly string startTx = "To begin Tic-Tac-Toe, X goes first, then O.";
        readonly string turnTx = "'s turn.";
        readonly string resultTx = "is the winner!!!";
        readonly string drawTx = "Draw, no one";

        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = startTx;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedBtn = sender as Button;
            var cordsTag = clickedBtn.Tag.ToString().Split(",");
            var xValue = int.Parse(cordsTag[0]);
            var yValue = int.Parse(cordsTag[1]);
            var positionBtn = new Position() { X = xValue, Y = yValue };
            if (userTurn == 1)
            {
                clickedBtn.Content = "O";
                uxTurn.Text = $"X{turnTx}";
            }
            else
            {
                clickedBtn.Content = "X";
                uxTurn.Text = $"O{turnTx}";
            }
            clickedBtn.IsEnabled = false;
            CheckGameResult(clickedBtn, positionBtn);
            userTurn += 1;
            if (userTurn > 1) userTurn = 0;
        }

        private void CheckGameResult(Button btnClicked, Position btnPosition)
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
                if ((string)btnClicked.Content == "O") uxTurn.Text = $"O {resultTx}";
                else if ((string)btnClicked.Content == "X") uxTurn.Text = $"X {resultTx}";
                foreach (Button btn in uxGrid.Children) btn.IsEnabled = false;
            }
            else
            {
                foreach (Button btn in uxGrid.Children) if (btn.IsEnabled == true) return;
                uxTurn.Text = $"{drawTx} {resultTx}";
            }
        }

        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private void UxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in uxGrid.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
                userTurn = 0;
                uxTurn.Text = startTx;
            }
        }

        private void UxExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
