using System;
using System.Windows;

namespace CrapsWPF
{
    static class Message
    {
        public static void Exit_Message()
        {
            if (MessageBox.Show(Application.Current.MainWindow, "Are you sure you want to exit the game?", "Exit Game", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        public static void About_Message(AssemblyInfo entryAssemblyInfo)
        {
            MessageBox.Show(Application.Current.MainWindow, entryAssemblyInfo.Company + "\n" +
                                                            entryAssemblyInfo.Product + "\n" +
                                                            entryAssemblyInfo.Copyright + "\n" +
                                                            entryAssemblyInfo.Description + "\n" +
                                                            "Version: " + entryAssemblyInfo.Version + "\n" +
                                                            "64 bit/ 32 bit prefered", "About CrapsWPF");
        }

        public static void Rules_Message()
        {
            MessageBox.Show(Application.Current.MainWindow, "To begin a game, click Game, then Start. Or press Ctrl+S\n\nA player rolls two dice where each die has six faces in the usual way (values 1 through 6). " +
                                                "After the dice have come to rest the sum of the two upward faces is calculated.\n\n" +
                                                "- The first roll:\n" +
                                                "      If the sum is 7 or 11 on the first throw the player wins.\n" +
                                                "      If the sum is 2, 3 or 12 the player loses, that is the house wins.\n" +
                                                "      If the sum is 4, 5, 6, 8, 9, or 10, that sum becomes the player's \"point\".\n\n" +
                                                "- Continue given the player's point:\n" +
                                                "      Now the player must roll the \"point\" total before rolling a 7 in order to win.\n" +
                                                "      If a 7 is rolled before rolling the point, the player loses.", "Rules of the Game");
        }

        public static void Shortcuts_Message()
        {
            MessageBox.Show(Application.Current.MainWindow, "Keybaord Shortcuts:\n\n" +
                                                            "About\t\t: Ctrl+A \n" +
                                                            "Bet\t\t: Ctrl+B \n" +
                                                            "Exit\t\t: Ctrl+E \n" +
                                                            "Keyboard Shortcuts : Ctrl+K \n" +
                                                            "Play Again\t: Ctrl+P \n" +
                                                            "Reset Game\t : Ctrl+T \n" +
                                                            "Roll Dice\t\t: Ctrl+R \n" +
                                                            "Rules of Craps\t: Ctrl+L \n" +
                                                            "Srat Game\t\t: Ctrl+S \n", "Keyboard Commands");
        }

    }
}
