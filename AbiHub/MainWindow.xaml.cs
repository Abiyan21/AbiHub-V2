using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AbiHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variablen / Listen
        /// <summary>
        /// Liste
        /// </summary>
        List<string> benutzer = new List<string>();
        List<string> passwortL = new List<string>();
        #endregion

        #region Methoden
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DragMove Funktion / erlaubt den Benutzer den Fenster zu bewegen
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

        /// <summary>
        /// Button Click / Öffnet das Register Fenster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _3rdWindow wind3 = new _3rdWindow();
            this.Close();
            wind3.Show();
        }

        /// <summary>
        /// Button Click / Benutzer Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "login.txt";

            StreamReader sr = new StreamReader(path);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                
                string[] komponente = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                benutzer.Add(komponente[0]);
                passwortL.Add(komponente[1]);
                
            }

            bool benutzernameverify = false;
            bool passwordverify = false;

            if (benutzer.Contains(Benutzername.Text))
            {
                benutzernameverify = true;
            }
            if (passwortL.Contains(Password.Password))
            {
                passwordverify = true;
            }
            

            if (benutzernameverify == true && passwordverify == true)
            {
                _2ndWindow wind2 = new _2ndWindow();
                this.Close();
                wind2.Show();
            }
            else if (benutzernameverify == false || passwordverify == false)
            {
                MessageBox.Show("Fehler: Benutzername oder Passwort ist falsch.");
            }
            sr.Close();
        }

        /// <summary>
        /// GotFocus Funktion / Löscht den Text innerhalb des Benutzername Feldes, falls es fokusiert wird (Benutzer clickt darauf)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Benutzer_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= Benutzer_GotFocus;
        }

        /// <summary>
        /// GotFocus Funktion / Löscht den Text innerhalb des Passwort Feldes, falls es fokusiert wird (Benutzer clickt darauf)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Password = string.Empty;
            pb.GotFocus -= Password_GotFocus;
        }

        /// <summary>
        /// LostFocus Funktion / Fügt den standart Text wiederrein im Benutzername Feld, falls es entfokusiert wird (Benutzer clickt weg)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Benutzer_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == string.Empty)
            {
                tb.Text = "Benutzername";
                tb.GotFocus += Benutzer_GotFocus;
            }
        }

        /// <summary>
        /// LostFocus Funktion / Fügt den standart Text wiederrein im Passwort Feld, falls es entfokusiert wird (Benutzer clickt weg)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            if (pb.Password == string.Empty)
            {
                pb.Password = "Password";
                pb.GotFocus += Password_GotFocus;
            }
        }

        /// <summary>
        /// Button Click / Minimized den Fenster, falls es gedrückt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Button Click / Schliesst den Fenster, falls es gedrückt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
