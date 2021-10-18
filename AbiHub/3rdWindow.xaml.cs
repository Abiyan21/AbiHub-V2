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
        public _3rdWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\abiya\Desktop\AbiHub-47feee68a569fbca29dbe8955c141fccaa8a9571\AbiHub\login.txt";

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

    }
}
