using System;
using System.Windows;
using System.Windows.Input;
using System.Reflection;

namespace CrapsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game theGame;
        private Window1 subForm;
        private AssemblyInfo entryAssemblyInfo;

        public MainWindow()
        {
            InitializeComponent();
            CenterMainWindowOnScreen();
            theGame = new Game();
            entryAssemblyInfo = new AssemblyInfo(Assembly.GetEntryAssembly());
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
            e.CanExecute = true;
        }

        void About_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            About_Click(sender, e);
        }

        void Rules_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void Rules_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Rules_Click(sender, e);
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

        void SubmitWager_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = btn_PlayAgain.IsEnabled;
        }

        void SubmitWager_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Submit_Click(sender, e);
        }

        #endregion

#region ClickMethods

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            SetPlayerBank();
            btn_PlayAgain.IsEnabled = false;
            startGame.IsEnabled = false;
            resetGame.IsEnabled = true;
            gameWinner.Content = "";
            playerText1.Text = "";
            houseText1.Text = "";
            playerText2.Text = theGame.GetBank(1);
            houseText2.Text = theGame.GetBank(0);
            if (Convert.ToInt32(theGame.GetBank(1)) > 0)
            {
                playerBet.IsEnabled = true;
                playerBet.Focus();
                btn_SubmitWager.IsEnabled = false;
            }
            else
                btn_RollDice.IsEnabled = true;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            theGame = new Game();
            Start_Click(sender, e);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(Application.Current.MainWindow, "Are you sure you want to exit the game?", "Exit Game", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.MainWindow, entryAssemblyInfo.Company + "\n" +
                                                            entryAssemblyInfo.Product + "\n" +
                                                            entryAssemblyInfo.Copyright + "\n" +
                                                            entryAssemblyInfo.Description + "\n" +
                                                            "Version: " + entryAssemblyInfo.Version + "\n", "About CrapsWPF");
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.MainWindow, "A player rolls two dice where each die has six faces in the usual way (values 1 through 6). " +
                                                            "After the dice have come to rest the sum of the two upward faces is calculated.\n\n" +
                                                            "- The first roll:\n" +
                                                            "      If the sum is 7 or 11 on the first throw the player wins.\n" +
                                                            "      If the sum is 2, 3 or 12 the player loses, that is the house wins.\n" +
                                                            "      If the sum is 4, 5, 6, 8, 9, or 10, that sum becomes the player's \"point\".\n\n" +
                                                            "- Continue given the player's point:\n" +
                                                            "      Now the player must roll the \"point\" total before rolling a 7 in order to win.\n" +
                                                            "      If a 7 is rolled before rolling the point, the player loses.", "Rules of the Game");
        }

        private void playerBet_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(playerBet.Text);

                if (Convert.ToInt32(theGame.GetBank(1)) >= Convert.ToInt32(playerBet.Text))
                {
                    btn_SubmitWager.IsEnabled = true;
                    btn_SubmitWager.Focus();
                }
                else
                {
                    MessageBox.Show(Application.Current.MainWindow, "Player cannot wager more than what they have in their bank.\nPlease enter a new wager.", "Wager Error");
                    playerBet.Text = theGame.GetBank(1);
                    playerBet.Focus();
                }
                    
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow, "Player wager must be whole numbers only.\n\nExample: 1000", "Wager Error");
                playerBet.Text = "10";
                playerBet.Focus();
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            theGame.Bet = Convert.ToInt32(playerBet.Text);
            btn_RollDice.IsEnabled = true;
            btn_RollDice.Focus();
            btn_SubmitWager.IsEnabled = false;
            playerBet.IsEnabled = false;
            
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            btn_RollDice.IsEnabled = false;
            theGame.RollDice();
            die1Text.Text = theGame.GetDiceValue(1);
            die2Text.Text = theGame.GetDiceValue(2);
            dieTotal.Text = theGame.DiceTotal.ToString();
            this.CheckRoll();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            theGame.ResetRollPoint();
            btn_PlayAgain.IsEnabled = false;
            gameWinner.Content = "";
            if (Convert.ToInt32(theGame.GetBank(1)) <= 0)
            {
                if (MessageBox.Show(Application.Current.MainWindow, "You have run out of money. You can keep playing with out money, but you won't be able to wager.\n Would you like to add money to your banK?", "Out Of Money", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
                {
                    SetPlayerBank();
                    playerBet.Text = "10";
                    playerBet.IsEnabled = true;
                    btn_SubmitWager.IsEnabled = true;
                }
                else
                {
                    playerBet.IsEnabled = true;
                    btn_SubmitWager.IsEnabled = true;
                    theGame.Bet = 0;
                }
            }
            else
            {
                playerBet.Text = "10";
                playerBet.IsEnabled = true;
                btn_SubmitWager.IsEnabled = true;
            }
                
        }

#endregion

#region HelperMethods

        private void SetPlayerBank()
        {

            subForm = new Window1();
            subForm.ShowDialog();
        }

        public void PlayerBank(int bank)
        {
            theGame.InitBank(bank);
        }

        private void ClearTextBoxes()
        {
            die1Text.Text = "";
            die2Text.Text = "";
            dieTotal.Text = "";
            pointText.Text = "";
            playerBet.Text = "10";
        }

        private void CheckRoll()
        {
            if (theGame.CheckRoll())
            {
                btn_RollDice.IsEnabled = true;
                pointText.Text = theGame.RollPoint().ToString();
            }
            else
            {
                DisplayWin();
                playerText1.Text = theGame.GetPoints(0);
                houseText1.Text = theGame.GetPoints(1);
                playerText2.Text = theGame.GetBank(1);
                houseText2.Text = theGame.GetBank(0);
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

        private void CenterMainWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }


        #endregion


    }

}
