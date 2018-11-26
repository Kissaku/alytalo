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
using System.Windows.Threading;

namespace Älytalosovellus_AtteNousiainen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Lights valot = new Lights();
        public Sauna sauna = new Sauna();
        public Thermostat thermostat = new Thermostat();
        public DispatcherTimer saunanLampo = new DispatcherTimer();
        public DispatcherTimer saunanViileys = new DispatcherTimer();

        
        public MainWindow()
        {
            InitializeComponent();
            sauna.SaunaLampo = 30;
            saunanLampo.Tick += SaunaLampenee_Tick;
            saunanLampo.Interval = new TimeSpan(0, 0, 1);
            saunanViileys.Tick += SaunaViilenee_Tick;
            saunanViileys.Interval = new TimeSpan(0, 0, 1);
        }
        private void SaunaViilenee_Tick(object sender, EventArgs e)
        {
            if (sauna.SaunaLampo > 30)
            {
                sauna.SaunaLampo = sauna.SaunaLampo - 1;
                LblSaunaLampo.Content = sauna.SaunaLampo;
            }
            else
            {
                saunanViileys.Stop();
            }
        }
        private void SaunaLampenee_Tick(object sender, EventArgs e)
        {
            if (sauna.SaunaLampo < 80)
            {
                sauna.SaunaLampo = sauna.SaunaLampo + 1;
                LblSaunaLampo.Content = sauna.SaunaLampo;
            }
            else
            {
                saunanLampo.Stop();
            }
        }
        public void BtnValoPois_Click(object sender, RoutedEventArgs e)
        {
            valot.Stop();
            SldrValot.Value = 0;
            TxtTeho.Text = valot.Dimmer;
            txtVirta.Text = valot.Switched.ToString();
        }

        public void BtnValoHamara_Click(object sender, RoutedEventArgs e)
        {
            valot.Hamara();
            SldrValot.Value = 33;
            TxtTeho.Text = valot.Dimmer;
            txtVirta.Text = valot.Switched.ToString();
        }

        public void BtnValoPuolivalo_Click(object sender, RoutedEventArgs e)
        {
            valot.Puolivalot();
            SldrValot.Value = 66;
            TxtTeho.Text = valot.Dimmer;
            txtVirta.Text = valot.Switched.ToString();
        }

        public void BtnValoKirkas_Click(object sender, RoutedEventArgs e)
        {
            valot.Kirkas();
            SldrValot.Value = 100;
            TxtTeho.Text = valot.Dimmer;
            txtVirta.Text = valot.Switched.ToString();
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SldrValot_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int dimmer = Convert.ToInt32(e.NewValue);
            
            if (dimmer == 0)
            {
                valot.Stop();
                TxtTeho.Text = valot.Dimmer;
                txtVirta.Text = valot.Switched.ToString();
            }
            if (dimmer >= 1)
            {
                valot.Switched = true;
                TxtTeho.Text = dimmer.ToString();
                txtVirta.Text = valot.Switched.ToString();
            }
            
        }

        private void BtnSaunaPaalle_Click(object sender, RoutedEventArgs e)
        {
            sauna.SaunaOn();
            saunanViileys.Stop();
            saunanLampo.Start();
            TxtBoxSauna.Text = sauna.SaunaText;
        }

        private void BtnSaunaPois_Click(object sender, RoutedEventArgs e)
        {
            sauna.SaunaOff();
            saunanLampo.Stop();
            saunanViileys.Start();
            TxtBoxSauna.Text = sauna.SaunaText;
        }

        private void BtnLampotila_Click(object sender, RoutedEventArgs e)
        {
            thermostat.TemperatureSet = TxtBoxNewTemp.Text;
            thermostat.SetTemperature();
            TxtBoxCurrTemp.Text = thermostat.TemperatureSet;
            TxtBoxNewTemp.Clear();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
