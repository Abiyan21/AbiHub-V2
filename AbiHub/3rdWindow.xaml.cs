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
using System.Windows.Shapes;

namespace AbiHub
{
    /// <summary>
    /// Interaction logic for _3rdWindow.xaml
    /// </summary>
    public partial class _3rdWindow : Window
    {
        #region Methoden
        public _3rdWindow()
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
        /// Button Click / erstellt den Benutzer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "login.txt";

            if (File.Exists(path) == false)
            {
                File.Create(path);
            }

            if (File.Exists(path) == true) 
            {

                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);


                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(Benutzername.Text + " " + Password.Password);
                sw.Close();
                fs.Close();

                // File.WriteAllText(path, Benutzername.Text + " " + Password.Password);

                MessageBox.Show("Benutzer erstellt.");

                MainWindow wind1 = new MainWindow();
                this.Close();
                wind1.Show();
            }
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
