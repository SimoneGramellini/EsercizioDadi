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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace esercizioLancioDadi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            int sorteggiato = 0;
            Sorteggio(sorteggiato);
        }

        private async void Sorteggio(int sorteggiato)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    sorteggiato = random.Next(1, 6);
                    Thread.Sleep(250);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblDado.Content = sorteggiato;
                    }));

                }
            });
        }
        
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ExecuteLongOpSincrono();

            //MessageBox.Show("Operazione sincrona completata");
        }
        */

        private void ExecuteLongOpSincrono() //non utilizzato
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }

        private async void ExecuteLongOpAsincrono() //non utilizzato
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                }
                MessageBox.Show("Operazione asincrona completata");
            });
        }

        private void btn_estrai_Click(object sender, RoutedEventArgs e) //non utilizzato
        {
            ExecuteLongOpAsincrono();
        }

        private void btnPrendiValore_Click(object sender, RoutedEventArgs e)
        {
            lblValoreEstratto.Content = lblDado.Content;
            lstCronologiaValoriEstratti.Items.Add(lblValoreEstratto.Content);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lstCronologiaValoriEstratti.Items.Clear();
            lblValoreEstratto.Content = "";
        }
    }
}
