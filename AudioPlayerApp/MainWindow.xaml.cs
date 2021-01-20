using AudioPlayerApp.AudioFeatures;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace AudioPlayerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player;
        DispatcherTimer timer;
        private string maxTime;
        private bool isPlaying=false;

        public MainWindow()
        {
            InitializeComponent();
            this.CloseBtn.Click += (s, e) => this.Close();
            this.MinimizeBtn.Click += (s, e) => this.WindowState = WindowState.Minimized;
            player = new MediaPlayer();
            DurationText.Text = "00:00/00:00";
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var actual = player.Position.ToString(@"mm\:ss");
            DurationSlider.Value = player.Position.TotalSeconds;
            DurationText.Text = actual + "/" + maxTime;
        }

        private void LoadWave(string name)
        {
            try
            {
                SpectrumImage.Source = new Waveform().DrawWaveform(name);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong with drawing line!!");
            }
        }

        private void LoadWavBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Audio files (*.wav,*.mp3) | *.wav;*.mp3";
            if (fileDialog.ShowDialog() == true)
            {
                var name = fileDialog.FileName;
                player.Open(new Uri(name));
                Duration duration = player.NaturalDuration;
                if (duration.HasTimeSpan)
                {
                    LoadWave(name);
                    DurationSlider.Maximum = duration.TimeSpan.TotalSeconds;
                    maxTime = duration.TimeSpan.ToString(@"mm\:ss");
                    timer.Start();
                    player.Play();
                    isPlaying = true;
                    PlayPauseImg.Source = new BitmapImage(new Uri("pack://application:,,,/Graphics/pause.png"));
                }
                else
                {
                    MessageBox.Show("There was an error during song loading !!");
                }
            }
        }

        private void DurationSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (isPlaying)
            {
                player.Position = TimeSpan.FromSeconds(DurationSlider.Value);
            }
        }

        private void StepBackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                player.Position -= TimeSpan.FromSeconds(10);
            }
        }

        private void PlayPauseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (player!=null)
            {
                if (isPlaying)
                {
                    player.Pause();
                    PlayPauseImg.Source = new BitmapImage(new Uri("pack://application:,,,/Graphics/play.png"));
                }
                else
                {
                    player.Play();
                    PlayPauseImg.Source = new BitmapImage(new Uri("pack://application:,,,/Graphics/pause.png"));
                }

                isPlaying = !isPlaying;
            }
        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                player.Position += TimeSpan.FromSeconds(10);
            }
        }
    }
}
