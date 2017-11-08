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
using System.Windows.Shapes;

namespace CrapsWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CenterWindow1OnScreen();
            btn_SubmitBank.IsEnabled = false;
        }

        private void CenterWindow1OnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btn_SubmitBank_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PlayerBank(Convert.ToInt32(bankText1.Text));
            this.Close();
        }
        

        private void bankText1_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Convert.ToInt32(bankText1.Text);
                btn_SubmitBank.IsEnabled = true;
                btn_SubmitBank.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow, "Bank amount must be whole numbers only.\n\nExample: 1000", "Banking Error");
                this.Focus();
                bankText1.Text = "10";
                bankText1.Focus();
            }
        }
    }
}
