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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            btn_RollDice.IsEnabled = true;
            startGame.IsEnabled = false;
            theGame = new Game();
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

        private void CheckRoll()
        {
            if (theGame.CheckRoll())
            {
                btn_RollDice.IsEnabled = true;

            }
        }


    }
}
