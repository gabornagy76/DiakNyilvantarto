using System.Collections.ObjectModel;
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

        // Ebben a WPF specifikus gyűjteményben tároljuk a rögzített tanulókat.
        public ObservableCollection<Tanulo> Tanulok { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Hozzunk létre egy üres Tanulok gyűjteményt:
            Tanulok = new ObservableCollection<Tanulo>();
            DataContext = this;

            nevTextBox.Focus();

        }

        // Tanulók hozzáadása gomb klikk esemény
        private void hozzaadasButton_Click(object sender, RoutedEventArgs e)
        {
            // Olvasuk be az adatokat
            string nev = nevTextBox.Text.Trim();
            string eletkorSzoveg = eletkorTextBox.Text.Trim();
            string osztaly = osztalyTextBox.Text.Trim();
            string atlagSzoveg = atlagTextBox.Text.Trim();
            string megjegyzes = megjegyzesTextBox.Text.Trim();


            // Megnézzük, hogy a név tartalmaz-e adatot:
            if (string.IsNullOrWhiteSpace(nev))
            {
                allapotTextBlock.Text = "Hiba: A név megadása kötelező!";
                nevTextBox.Focus();
                return;
            }

            // Az éltkor mező vizsgálata:
            if (string.IsNullOrWhiteSpace(eletkorSzoveg))
            {
                allapotTextBlock.Text = "Hiba: Az életkor megadása kötelező!";
                eletkorTextBox.Focus();
                return;
            }

            // Próbáljuk meg számmá alakítani.

            if (!int.TryParse(eletkorSzoveg, out int eletkor))
            {
                allapotTextBlock.Text = "Hiba: Az életkornak egész számnak kell lennie!";
                eletkorTextBox.Focus();
                eletkorTextBox.SelectAll();
                return;
            }

            // Ellenőrizzük az életkor tartományát:
            if (eletkor < 6 || eletkor >25)
            {
                allapotTextBlock.Text = "Hiba: Az életkornak 6 és 25 év között kell lennie!";
                eletkorTextBox.Focus();
                eletkorTextBox.SelectAll();
                return;
            }

            // Az osztály kitöltésének vizsgálata:

            if (string.IsNullOrWhiteSpace(osztaly))
            {
                allapotTextBlock.Text = "Hiba: Az osztály kitöltése kötelező!";
                eletkorTextBox.Focus();
                return;
            }

            // Az átlag mező vizsgálata:

            if (string.IsNullOrWhiteSpace(atlagSzoveg))
            {
                allapotTextBlock.Text = "Hiba: Az átlag megadása kötelező!";
                eletkorTextBox.Focus();
                return;
            }


            // Próbáljuk meg számmá alakítani az átlagot is:

            if (!double.TryParse(atlagSzoveg, out double atlag))
            {
                allapotTextBlock.Text = "Hiba: Az átlagnak számnak kell lennie!";
                atlagTextBox.Focus();
                atlagTextBox.SelectAll();
                return;
            }

            // Ellenőrizzük az átlag tartományát:
            if (atlag < 1 || atlag > 5)
            {
                allapotTextBlock.Text = "Hiba: Az átlagnak 1 és 5 között kell lennie!";
                atlagTextBox.Focus();
                atlagTextBox.SelectAll();
                return;
            }


            // Hozzunk létre egy új Tanulo objektumot:
            Tanulo ujTanulo = new Tanulo()
            {
                Nev = nev,
                Eletkor = eletkor,
                Osztaly = osztaly,
                Atlag = atlag,
                Megjegyzes = megjegyzes
            };


            Tanulok.Add(ujTanulo);

            /*
            // Összeállítjuk az eddigi adatokból a listaelemet:
            string tanuloAdatok = $"{nev} - {eletkor} év - {osztaly} - átlag: {atlag:F2}";

            // A megjegyzést csak akkor írjuk hozzá, ha kitöltötték:
            if (!string.IsNullOrWhiteSpace(megjegyzes))
            {
                tanuloAdatok += $" - Megjegyzés: {megjegyzes}";
            }

            // Adjuk hozzá az új elemet a ListBox-hoz:
            tanulokListBox.Items.Add(tanuloAdatok);
            */

            // Állapotsor visszajelzés:
            allapotTextBlock.Text = $"A következő tanulót sikeresen hozzáadtuk: {nev}";

            // Kiürítjük a beviteli mezők tartalmát:
            BeviteliMezokTorlese();
        }

        // Mezők törlése gomb klikk esemény
        private void mezokTorleseButton_Click(object sender, RoutedEventArgs e)
        {
            BeviteliMezokTorlese();

            allapotTextBlock.Text = "Állapot: a beviteli mezőket töröltük!";

            nevTextBox.Focus();
        }

        private void BeviteliMezokTorlese()
        {
            // Minden TextBox elem értékét töröljük
            nevTextBox.Clear();
            eletkorTextBox.Clear();
            osztalyTextBox.Clear();
            atlagTextBox.Clear();
            megjegyzesTextBox.Clear();

        }


        private void tanulokListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Megnézzük, hogy a kiválasztott elem Tanulo objektum-e. Ha igen akkor azonnal fel is vesszük egy ideiglenes ilyen változóba (kivalasztottTanulo):
            if (tanulokListBox.SelectedItem is Tanulo kivalsztottTanulo)
            {
                nevTextBox.Text = kivalsztottTanulo.Nev;
                eletkorTextBox.Text = kivalsztottTanulo.Eletkor.ToString();
                osztalyTextBox.Text = kivalsztottTanulo.Osztaly;
                atlagTextBox.Text = kivalsztottTanulo.Atlag.ToString();
                megjegyzesTextBox.Text = kivalsztottTanulo.Megjegyzes;

                allapotTextBlock.Text = $"Kiválasztott tanuló: {kivalsztottTanulo.Nev}";
            }
        }

    }
}