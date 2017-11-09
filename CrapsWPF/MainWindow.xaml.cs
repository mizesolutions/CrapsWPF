﻿using System;
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
            startGame.Focus();
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

        void Shortcuts_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void Shortcuts_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Shortcuts_Click(sender, e);
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
                theGame.WagerOn = true;
                playerBet.IsEnabled = true;
                playerBet.Focus();
                btn_SubmitWager.IsEnabled = false;
            }
            else
            {
                btn_RollDice.IsEnabled = true;
                theGame.WagerOn = false;
            }
                
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            theGame = new Game();
            Start_Click(sender, e);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Message.Exit_Message();
            
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Message.About_Message(entryAssemblyInfo);
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            Message.Rules_Message();
        }

        private void Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            Message.Shortcuts_Message();
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
            if (Convert.ToInt32(theGame.GetBank(0)) <= 0)
            {
                theGame.SetHouseBank();
            }
            ClearTextBoxes();
            theGame.ResetRollPoint();
            btn_PlayAgain.IsEnabled = false;
            gameWinner.Content = "";
            if (Convert.ToInt32(theGame.GetBank(1)) <= 0 && theGame.WagerOn)
            {
                if (MessageBox.Show(Application.Current.MainWindow, "You have run out of money.\nYou can keep playing with out money, but you won't be able to wager.\n\nWould you like to add money to your bank?", "Out Of Money", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
                {
                    SetPlayerBank();
                    playerText2.Text = theGame.GetBank(1);
                    houseText2.Text = theGame.GetBank(0);
                    playerBet.Text = "10";
                    playerBet.IsEnabled = true;
                    btn_SubmitWager.IsEnabled = true;
                }
                else
                {
                    theGame.WagerOn = false;
                    playerBet.IsEnabled = false;
                    btn_SubmitWager.IsEnabled = false;
                    theGame.Bet = 0;
                    btn_RollDice.IsEnabled = true;
                }
            }
            else if(theGame.WagerOn)
            {
                playerBet.Text = "10";
                playerBet.IsEnabled = true;
                btn_SubmitWager.IsEnabled = true;
            }
            else
            {
                playerBet.Text = "10";
                playerBet.IsEnabled = false;
                playerBet.IsEnabled = false;
                btn_SubmitWager.IsEnabled = false;
                btn_RollDice.IsEnabled = true;
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
