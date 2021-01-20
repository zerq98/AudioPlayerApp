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
    public class OwnWaveform
    {
        public BitmapImage DrawWaveform(List<byte> wave)
        {
            Color areaColor = Color.FromArgb(12,255,0);
            Color edgeColor = Color.FromArgb(255, 0, 0);
            Color backGroundColor = Color.FromArgb(118, 118, 118);
            Rectangle bounds = Rectangle.FromLTRB(0, 0, 850, 300);
            float width = bounds.Width;
            float height = bounds.Height;
            Bitmap bmp = new Bitmap(800,300);

            using(Graphics g = Graphics.FromImage(bmp))
            {
                Pen edgePen = new Pen(edgeColor);
                edgePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                edgePen.Width = 1;
                Brush areaBrush = new SolidBrush(areaColor);

                List<Point> points = new List<Point>();

                foreach(var bt in wave)
                {
                    points.Add(new Point(bt));
                }

                g.FillClosedCurve(areaBrush, points.ToArray());
                g.DrawClosedCurve(edgePen, points.ToArray(),0.1f,FillMode.Winding);
            }

            return BitmapConverter.ConvertToBitmapImage(bmp);
        }
    }
}
