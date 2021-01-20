using AudioPlayerApp.Converter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WaveFormRendererLib;

namespace AudioPlayerApp.AudioFeatures
{
    public class Waveform
    {
        public BitmapImage DrawWaveform(string filePath)
        {
            MaxPeakProvider maxPeak = new MaxPeakProvider();
            RmsPeakProvider rmsPeak = new RmsPeakProvider(200);
            SamplingPeakProvider samplingPeak = new SamplingPeakProvider(200);
            AveragePeakProvider averagePeak = new AveragePeakProvider(4);

            StandardWaveFormRendererSettings rendererSettings = new StandardWaveFormRendererSettings();
            rendererSettings.Width = 850;
            rendererSettings.TopHeight = 200;
            rendererSettings.BottomHeight = 100;
            rendererSettings.PixelsPerPeak = 1;

            WaveFormRenderer renderer = new WaveFormRenderer();

            return BitmapConverter.ConvertToBitmapImage(new Bitmap(renderer.Render(filePath, averagePeak, rendererSettings)));
        }
    }
}
