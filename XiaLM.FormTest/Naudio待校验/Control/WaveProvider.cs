using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaudioTest.Control
{
    /// <summary>
    /// Wave操作类提供者
    /// </summary>
    public class WaveProvider
    {
        public WaveIn waveIn;
        private WaveOut waveOut;

        private WaveIn CreateWave()
        {
            IWaveIn newWaveIn;
           
            
            return null;
        }


        private void CreateWaveOut()
        {
            CloseWaveOut();
           
        }

        private void CloseWaveOut()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
            
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }

    }
}
