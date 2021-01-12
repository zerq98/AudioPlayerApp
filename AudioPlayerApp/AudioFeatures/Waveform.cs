using AudioPlayerApp.Converter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AudioPlayerApp.AudioFeatures
{
    public class Waveform
    {
        public BitmapImage DrawWaveform(List<float> wave)
        {
            Color areaColor = Color.FromArgb(12,255,0);
            Color edgeColor = Color.FromArgb(255, 0, 0);
            Color backGroundColor = Color.FromArgb(118, 118, 118);
            int step = 1;
            Rectangle bounds = Rectangle.FromLTRB(0, 0, 850, 300);
            float width = bounds.Width;
            float height = bounds.Height;
            Bitmap bmp = new Bitmap(850,300);

            using(Graphics g = Graphics.FromImage(bmp))
            {
                Pen edgePen = new Pen(edgeColor);
                edgePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                edgePen.Width = 1;
                Brush areaBrush = new SolidBrush(areaColor);
                double overlap = 0.10f;

                float size = wave.Count;
                PointF[] topCurve = new PointF[((int)(width / step))];
                PointF[] bottomCurve = new PointF[((int)(width / step))];
                int index = 0;
                for(float pix=0;pix< width; pix += step)
                {
                    int start = (int)(pix * (size / width));
                    int end = (int)((pix + step) * (size / width));
                    int window = end - start;
                    start -= (int)(overlap * window);
                    end += (int)(overlap * window);
                    if (start < 0)
                        start = 0;
                    if (end > wave.Count)
                        end = wave.Count;

                    float posAvg, negAvg;
                    Averages(wave, start, end, out posAvg, out negAvg);

                    float yMax = height - ((posAvg + 1) * .5f * height);
                    float yMin = height - ((negAvg + 1) * .5f * height);
                    float xPos = pix + bounds.Left;
                    if (index >= topCurve.Length)
                        index = topCurve.Length - 1;
                    topCurve[index] = new PointF(xPos, yMax);
                    bottomCurve[bottomCurve.Length - index - 1] = new PointF(xPos, yMin);
                    index++;
                }

                PointF[] curve = new PointF[topCurve.Length * 2];
                Array.Copy(topCurve, curve, topCurve.Length);
                Array.Copy(bottomCurve, 0, curve, topCurve.Length, bottomCurve.Length);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillClosedCurve(areaBrush, curve, FillMode.Winding, 0.15f);
                g.DrawClosedCurve(edgePen, curve, 0.15f, FillMode.Winding);
            }

            return BitmapConverter.ConvertToBitmapImage(bmp);
        }

        private void Averages(List<float> data, int startIndex, int endIndex, out float posAvg, out float negAvg)
        {
            posAvg = 0.0f;
            negAvg = 0.0f;

            int posCount = 0, negCount = 0;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (data[i] > 0)
                {
                    posCount++;
                    posAvg += data[i];
                }
                else
                {
                    negCount++;
                    negAvg += data[i];
                }
            }

            if (posCount > 0)
                posAvg /= posCount;
            if (negCount > 0)
                negAvg /= negCount;
        }
    }
}
