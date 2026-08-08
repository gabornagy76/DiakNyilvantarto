using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiakNyilvantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hozzaadasButton_Click(object sender, RoutedEventArgs e)
        {
            // Olvasuk be az adatokat
            string nev = nevTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(nev))
            {
                allapotTextBlock.Text = "Hiba: A név megadása kötelező!";
                nevTextBox.Focus();
                return;
            }

            allapotTextBlock.Text = $"A következő tanulót sikeresen hozzáadtuk: {nev}";
        }
    }
}