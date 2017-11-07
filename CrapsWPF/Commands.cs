using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrapsWPF
{
    static class Commands
    {
        public static readonly RoutedCommand Start = new RoutedCommand();
        public static readonly RoutedCommand Reset = new RoutedCommand();
        public static readonly RoutedCommand Exit = new RoutedCommand();
        public static readonly RoutedCommand About = new RoutedCommand();
        public static readonly RoutedCommand Roll = new RoutedCommand();
        public static readonly RoutedCommand PlayAgain = new RoutedCommand();
    }

}
