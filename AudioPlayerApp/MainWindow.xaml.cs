using AudioPlayerApp.AudioFeatures;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace AudioPlayerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<float> wave;
        MediaPlayer player;

        public MainWindow()
        {
            InitializeComponent();
            this.CloseBtn.Click += (s, e) => this.Close();
            this.MinimizeBtn.Click += (s, e) => this.WindowState = WindowState.Minimized;
            player = new MediaPlayer();
        }

        private void LoadWave(string name)
        {
            try
            {
                byte[] waveBytes = File.ReadAllBytes(name);
                wave = new List<float>();
                for (int i = 0; i < waveBytes.Length; i++)
                {
                    wave.Add(waveBytes[i]);
                }

                SpectrumImage.Source = new Waveform().DrawWaveform(wave);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong!!");
            }
        }

        private void LoadWavBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wav files (*.wav) | *.wav";
            if (fileDialog.ShowDialog() == true)
            {
                var name = fileDialog.FileName;
                LoadWave(name);
                player.Open(new Uri(name));
                player.Play();
            }
        }
    }
}
