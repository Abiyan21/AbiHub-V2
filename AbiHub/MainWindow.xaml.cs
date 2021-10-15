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
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> benutzer = new List<string>();
        List<string> passwortL = new List<string>();



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("login.txt");
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
            
        }


        public void Benutzer_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= Benutzer_GotFocus;
        }

        public void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Password = string.Empty;
            pb.GotFocus -= Password_GotFocus;
        }

        public void Benutzer_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == string.Empty)
            {
                tb.Text = "Benutzername";
                tb.GotFocus += Benutzer_GotFocus;
            }
        }

        public void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            if (pb.Password == string.Empty)
            {
                pb.Password = "Password";
                pb.GotFocus += Password_GotFocus;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void reader(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("login.txt");
            string line = "";
            while((line = sr.ReadLine()) != null)
            {
                MessageBox.Show(line);
                /*
                string[] komponente = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                benutzer.Add(komponente[0]);
                passwortL.Add(komponente[1]);
                */
            }
        }
    }
}
