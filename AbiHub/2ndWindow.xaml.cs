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

namespace AbiHub
{
    /// <summary>
    /// Interaction logic for _2ndWindow.xaml
    /// </summary>
    public partial class _2ndWindow : Window
    {
        #region Methoden
        public _2ndWindow()
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
        /// Button Click / Minimized den Fenster, falls es gedrückt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Button Click / Schliesst den Fenster, falls es gedrückt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Button Click / Öffnet den Login Fenster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow wind1 = new MainWindow();
            this.Close();
            wind1.Show();
        }
        #endregion
    }
}
