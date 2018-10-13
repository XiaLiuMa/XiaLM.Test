using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaudioTest.Control
{
    /// <summary>
    /// 采样通道
    /// </summary>
    public class SampleChannel : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private readonly VolumeSampleProvider volumeProvider;
        private readonly MeteringSampleProvider preVolumeMeter;

        public WaveFormat WaveFormat => waveFormat;

        

        public int Read(float[] buffer, int offset, int count)
        {
            return volumeProvider.Read(buffer, offset, count);
        }





        public event EventHandler<StreamVolumeEventArgs> PreVolumeMeter
        {
            add { preVolumeMeter.StreamVolume += value; }
            remove { preVolumeMeter.StreamVolume -= value; }
        }
    }
}
