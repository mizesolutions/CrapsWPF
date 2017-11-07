using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrapsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game theGame;

        public MainWindow()
        {
            InitializeComponent();
        }

#region CommandBindings

        void Start_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = startGame.IsEnabled;
        }

        void Start_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Start_Click(sender, e);
        }

        void Reset_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = resetGame.IsEnabled;
        }

        void Reset_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Reset_Click(sender, e);
        }

        void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = exitGame.IsEnabled;
        }

        void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Exit_Click(sender, e);
        }

        void About_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = about.IsEnabled;
        }

        void About_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //About_Click(sender, e);
        }

        void Rules_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = rules.IsEnabled;
        }

        void Rules_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Rules_Click(sender, e);
        }

        void Roll_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = btn_RollDice.IsEnabled;
        }

        void Roll_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Roll_Click(sender, e);
        }

        void PlayAgain_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = btn_PlayAgain.IsEnabled;
        }

        void PlayAgain_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PlayAgain_Click(sender, e);
        }

#endregion

#region ClickMethods

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            btn_RollDice.IsEnabled = true;
            btn_PlayAgain.IsEnabled = false;
            startGame.IsEnabled = false;
            resetGame.IsEnabled = true;
            gameWinner.Content = "";
            playerText1.Text = "";
            houseText1.Text = "";
            theGame = new Game();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            Start_Click(sender, e);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            btn_RollDice.IsEnabled = false;
            theGame.RollDice();
            die1Text.Text = "" + theGame.GetDiceValue(1);
            die2Text.Text = "" + theGame.GetDiceValue(2);
            dieTotal.Text = "" + theGame.DiceTotal;
            this.CheckRoll();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            theGame.ResetRollPoint();
            btn_PlayAgain.IsEnabled = false;
            btn_RollDice.IsEnabled = true;
            gameWinner.Content = "";
        }

        #endregion

#region HelperMethods

        private void ClearTextBoxes()
        {
            die1Text.Text = "";
            die2Text.Text = "";
            dieTotal.Text = "";
            pointText.Text = "";
        }

        private void CheckRoll()
        {
            if (theGame.CheckRoll())
            {
                btn_RollDice.IsEnabled = true;
                pointText.Text = "" + theGame.RollPoint();
            }
            else
            {
                DisplayWin();
                playerText1.Text = theGame.GetPoints(0);
                houseText1.Text = theGame.GetPoints(1);
                btn_PlayAgain.IsEnabled = true;

            }
        }

        private void DisplayWin()
        {
            if(theGame.CheckWin())
            {
                gameWinner.Content = "Winner!";
            }
            else
            {
                gameWinner.Content = "Loser!";
            }
        }
#endregion

    }

}
