using AudioPlayerApp.AudioFeatures;
using LiveCharts;
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
        private AudioData audioData;

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
            VolumeChart.Width = ChartsPanel.ActualWidth / 2;
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
                audioData = new AudioData(name);
                InitializeCharts();
                LoadWave(name);
                player.Open(new Uri(name));
                player.MediaOpened += Player_MediaOpened;
                timer.Start();
                player.Play();
                player.MediaEnded += Player_MediaEnded;
                isPlaying = true;
            }
        }

        private void Player_MediaOpened(object sender, EventArgs e)
        {
            Duration duration = player.NaturalDuration;
            if (duration.HasTimeSpan)
            {
                DurationSlider.Maximum = duration.TimeSpan.TotalSeconds;
                maxTime = duration.TimeSpan.ToString(@"mm\:ss");
                PlayPauseImg.Source = new BitmapImage(new Uri("pack://application:,,,/Graphics/pause.png"));
                player.MediaOpened -= Player_MediaOpened;
            }
            else
            {
                MessageBox.Show("There was an error during song loading !!");
                player.Close();
            }
        }

        private void Player_MediaEnded(object sender, EventArgs e)
        {
            isPlaying = false;
            PlayPauseImg.Source = new BitmapImage(new Uri("pack://application:,,,/Graphics/play.png"));
            player.Close();
            timer.Stop();
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

        private void MainScreen_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            VolumeChart.Width = ChartsPanel.Width / 2;
        }

        private void InitializeCharts()
        {
            var result = audioData.GetAverageVolume();

            LeftChannel.Values = new ChartValues<double>(result);
        }
    }
}
