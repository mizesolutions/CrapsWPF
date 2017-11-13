using System.Windows.Input;

namespace CrapsWPF
{
    static class Commands
    {
        public static readonly RoutedCommand Start = new RoutedCommand();
        public static readonly RoutedCommand Reset = new RoutedCommand();
        public static readonly RoutedCommand Exit = new RoutedCommand();
        public static readonly RoutedCommand About = new RoutedCommand();
        public static readonly RoutedCommand Rules = new RoutedCommand();
        public static readonly RoutedCommand Shortcuts = new RoutedCommand();
        public static readonly RoutedCommand Roll = new RoutedCommand();
        public static readonly RoutedCommand PlayAgain = new RoutedCommand();
        public static readonly RoutedCommand SubmitWager = new RoutedCommand();
    }

}
