using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.FileFormats.Wav;

namespace AudioPlayerApp.AudioFeatures
{
    public class AudioData
    {
        AudioFileType fileType;
        private int bitDepth;
        private int bytes;
        private int[] samples;

        public AudioData(string fileName)
        {
            if (fileName.EndsWith(".mp3",StringComparison.OrdinalIgnoreCase))
            {
                //allFrames = GetRawMp3Frames(fileName);
                GetRawWavFrames(fileName);
                fileType = AudioFileType.Mp3;
            }
            else if (fileName.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
            {
                GetRawWavFrames(fileName);
                fileType = AudioFileType.Wav;
            }
        }

        private byte[] GetRawMp3Frames(string fileName)
        {
            using (MemoryStream output = new MemoryStream())
            {
                Mp3FileReader reader = new Mp3FileReader(fileName);
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    output.Write(frame.RawData, 0, frame.RawData.Length);
                }
                return output.ToArray();
            }
        }

        private void GetRawWavFrames(string fileName)
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open))
                {
                    BinaryReader reader = new BinaryReader(fs);
                    reader.BaseStream.Seek(34, SeekOrigin.Begin);
                    bitDepth = reader.ReadInt16();

                    reader.BaseStream.Seek(4, SeekOrigin.Begin);
                    bytes = reader.ReadInt32();

                    // DATA!
                    var byteArray = reader.ReadBytes(bytes);

                    int bytesForSamp = bitDepth / 8;
                    int nValues = bytes / bytesForSamp;
                    samples = new int[nValues];

                    int lsb, msb, j = 0;
                    for (int i = 0; i < nValues; i++)
                    {
                        lsb = byteArray[j];
                        lsb <<= 24;
                        lsb >>= 24;
                        msb = byteArray[j + 1];
                        msb <<= 24;
                        msb >>= 16;

                        samples[i] = msb | lsb;
                        j = j + 2;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Write("...Failed to load: " + fileName);
            }
        }

        public double[] GetAverageVolume()
        {
            int frameSize = 256;
            int lFrames = samples.Length / frameSize;
            double[] lVolume = new double[lFrames];

            for (int i = 0; i < lFrames; i++)
            {
                double sum = 0;
                for (int j = 0; j < frameSize; j++)
                {
                    sum += Math.Pow(samples[i * frameSize + j],2);
                }
                sum /= frameSize;
                lVolume[i] = Math.Sqrt(sum);
            }

            return lVolume;
        }
    }
}
