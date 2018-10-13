using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using XiaLM.Tool450.source.common;

namespace AudioTest.TechnicalSupport
{
    /// <summary>
    /// Naudio音频处理类
    /// </summary>
    public class Naudio
    {
        public event Action<bool> WaveOutPlayStopped = (b) => { };
        public bool autoRecord { get; set; } = false; //自动录音
        public WaveIn waveIn { get; set; }  //音频录入类
        public WaveOut waveOut { get; set; }    //音频输出类
        public WaveFileWriter wfw { get; set; }    //音频文件写入类
        public string tempWavFile { get; set; }    //临时wav文件
        private CancellationTokenSource rTokenS = new CancellationTokenSource();
        private CancellationToken rToken;
        private CancellationTokenSource pTokenS = new CancellationTokenSource();
        private CancellationToken pToken;
        private BlockingCollection<string> audioBlocking = new BlockingCollection<string>();
        private static readonly object lockObj = new object();
        private static Naudio naudio;
        public Naudio()
        {
            tempWavFile = AppDomain.CurrentDomain.BaseDirectory + @"\Temp\temp.wav";
            waveIn = new WaveIn();
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.RecordingStopped += WaveIn_RecordingStopped;
            WaveOutPlayStopped += WaveOut_PlayStopped;
            waveOut = new WaveOut();

            rToken = rTokenS.Token;
            pToken = pTokenS.Token;
        }

        public static Naudio GetInstance()
        {
            if (naudio == null)
            {
                lock (lockObj)
                {
                    if (naudio == null)
                    {
                        naudio = new Naudio();
                    }
                }
            }
            return naudio;
        }

        /// <summary>
        /// 开始录音
        /// </summary>
        public void StartRecord()
        {
            StopPlay();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (!File.Exists(tempWavFile)) File.Create(tempWavFile).Close();  //注意要关闭，否则会报被占用
                    waveIn.WaveFormat = new WaveFormat(16000, 16, 1);   //16KHz,16bit,Mono的录音格式
                    wfw = new WaveFileWriter(tempWavFile, waveIn.WaveFormat);
                    string SessionId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    waveIn.StartRecording();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    waveIn.StopRecording();
                    audioBlocking.TryAdd(SessionId);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(ex);
                }
            }, rToken);
        }

        /// <summary>
        /// 录音数据可用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                if (wfw != null)
                {
                    wfw.Write(e.Buffer, 0, e.BytesRecorded);
                    wfw.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 停止录音
        /// </summary>
        public void StopRecord()
        {
            waveIn.StopRecording();
        }

        /// <summary>
        /// 录音结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            wfw.Close();
            //if (autoRecord)
            //{
            //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
            //    StartPlay();
            //}
        }

        /// <summary>
        /// 播放录音文件
        /// </summary>
        public void StartPlay()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var wfr = new WaveFileReader(tempWavFile))
                    using (WaveStream wavStream = WaveFormatConversionStream.CreatePcmStream(wfr))
                    using (var baStream = new BlockAlignReductionStream(wavStream))
                    using (waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(baStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(0.1));
                        }
                        WaveOut_PlayStopped(true);
                    }
                }
                catch (Exception ex)
                {

                }
            }, pToken);
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void StopPlay()
        {
            waveOut.Stop();
            WaveOut_PlayStopped(false);
        }

        /// <summary>
        /// 播放停止事件
        /// </summary>
        /// <param name="autoStop"></param>
        private void WaveOut_PlayStopped(bool autoStop)
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            StartRecord();
        }

        /// <summary>
        /// 自动录音自动播放
        /// </summary>
        public void AutoAudio()
        {
            autoRecord = true;
            StartRecord();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    foreach (var item in audioBlocking.GetConsumingEnumerable())
                    {
                        if (item != null)
                        {
                            StartPlay();
                        }
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });
        }

























        /// <summary>
        /// 将文字通过语音播放出来
        /// </summary>
        /// <param name="txt"></param>
        public void PlayText(string txt)
        {
            waveIn.StopRecording();
            Task.Factory.StartNew(() =>
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    //var bytes = XunFeiApi.GetInstance().XunFeiTTS(txt);
                    //PlayAsBytes(bytes);
                    //PlayEnd();
                }
            });
        }

        /// <summary>
        /// 根据字节数组播放
        /// </summary>
        /// <param name="bytes">要播放的字节数组</param>
        public void PlayAsBytes(byte[] bytes)
        {
            waveIn.StopRecording();
            using (var wfr = new WaveFileReader(new MemoryStream(bytes)))
            using (WaveStream wavStream = WaveFormatConversionStream.CreatePcmStream(wfr))
            using (var baStream = new BlockAlignReductionStream(wavStream))
            using (waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
            {
                waveOut.Init(baStream);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// 根据文件播放
        /// </summary>
        /// <param name="fPath">要播放的文件路径</param>
        public void PlayAsPath(string fPath)
        {
            try
            {
                waveIn.StopRecording();
                using (var wfr = new WaveFileReader(fPath))
                using (WaveStream wavStream = WaveFormatConversionStream.CreatePcmStream(wfr))
                using (var baStream = new BlockAlignReductionStream(wavStream))
                using (waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(baStream);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
