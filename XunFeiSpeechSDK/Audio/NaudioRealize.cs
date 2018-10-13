using NAudio.Wave;

namespace XunFeiSpeechSDK.Audio
{
    public class NaudioRealize
    {
        private WaveCallbackInfo wavInCallBack;

        public void Test()
        {
            WaveIn waveIn = new WaveIn(WaveCallbackInfo.FunctionCallback());
            IWaveIn waveIn1 = new WaveInEvent();
        }
    }
}
