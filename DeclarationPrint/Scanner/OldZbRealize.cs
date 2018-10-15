//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace DeclarationPrint.Scanner
//{
//    public partial class OldZbRealize
//    {

//        /// ZBCRH -> 
//        /// Error generating expression: 值不能为空。
//        ///参数名: node
//        public const string ZBCRH = "";

//        /// ZBCR_VERSION -> "1.2.0"
//        public const string ZBCR_VERSION = "1.2.0";

//        /// ZBCR_API -> 
//        /// Error generating expression: 值不能为空。
//        ///参数名: node
//        public const string ZBCR_API = "";

//        /// ZBCR_FALL -> 0
//        public const int ZBCR_FALL = 0;

//        /// ZBCR_SUCCESS -> 1
//        public const int ZBCR_SUCCESS = 1;

//        /// ZBCR_WRITE_ERROR -> -1
//        public const int ZBCR_WRITE_ERROR = -1;

//        /// ZBCR_READ_TIMEOUT -> -2
//        public const int ZBCR_READ_TIMEOUT = -2;

//        /// ZBCR_READ_ERROR -> -3
//        public const int ZBCR_READ_ERROR = -3;

//        /// ZBCR_INIT_FAIL -> -4
//        public const int ZBCR_INIT_FAIL = -4;

//        /// ZBCR_DEVICE_NOT_FOUND -> -5
//        public const int ZBCR_DEVICE_NOT_FOUND = -5;

//        /// ZBCR_DEVICE_BUSY -> -6
//        public const int ZBCR_DEVICE_BUSY = -6;

//        /// ZBCR_ILLEGAL_REPLY -> -7
//        public const int ZBCR_ILLEGAL_REPLY = -7;

//        /// ZBCR_DEVICE_IO_FAILED -> -8
//        public const int ZBCR_DEVICE_IO_FAILED = -8;
//    }

//    public partial class OldZbRealize
//    {
//        private const string pathStr = "OldZBCR.dll";
//        /// Return Type: ZBCR_STATUS->int
//        ///pParam: void*
//        ///pfnReadData: CALL_BACK_DATA
//        ///userdata: unsigned int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_Open", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_Open(System.IntPtr pParam, CALL_BACK_DATA pfnReadData, uint userdata);


//        /// Return Type: ZBCR_STATUS->int
//        ///portNo: unsigned short
//        ///baudrate: unsigned int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_EasyOpen", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_EasyOpen(ushort portNo, uint baudrate);


//        /// Return Type: void
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_Close", CallingConvention = CallingConvention.Cdecl)]
//        public static extern void ZBCR_Close();


//        /// Return Type: void
//        ///ver_str: char*
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_GetApiVersion", CallingConvention = CallingConvention.Cdecl)]
//        public static extern void ZBCR_GetApiVersion(System.IntPtr ver_str);


//        /// Return Type: ZBCR_STATUS->int
//        ///nTimeOutSecond: unsigned short
//        ///pOutputBuffer: unsigned char*
//        ///nSizeOfOutputBuffer: unsigned int
//        ///pnBytesReturned: unsigned int*
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_ReadDecode", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_ReadDecode(ushort nTimeOutSecond, System.IntPtr pOutputBuffer, uint nSizeOfOutputBuffer, ref uint pnBytesReturned);


//        /// Return Type: ZBCR_STATUS->int
//        ///pInputBuffer: unsigned char*
//        ///nBytesInInputBuffer: unsigned int
//        ///pOutputBuffer: unsigned char*
//        ///nSizeOfOutputBuffer: unsigned int
//        ///pnBytesReturned: unsigned int*
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_SetupRead", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_SetupRead(System.IntPtr pInputBuffer, uint nBytesInInputBuffer, System.IntPtr pOutputBuffer, uint nSizeOfOutputBuffer, ref uint pnBytesReturned);


//        /// Return Type: ZBCR_STATUS->int
//        ///pInputBuffer: unsigned char*
//        ///nBytesInInputBuffer: unsigned int
//        ///pOutputBuffer: unsigned char*
//        ///nSizeOfOutputBuffer: unsigned int
//        ///pnBytesReturned: unsigned int*
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_SetupWrite", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_SetupWrite(System.IntPtr pInputBuffer, uint nBytesInInputBuffer, System.IntPtr pOutputBuffer, uint nSizeOfOutputBuffer, ref uint pnBytesReturned);


//        /// Return Type: ZBCR_STATUS->int
//        ///pInputBuffer: unsigned char*
//        ///nBytesInInputBuffer: unsigned int
//        ///pOutputBuffer: unsigned char*
//        ///nSizeOfOutputBuffer: unsigned int
//        ///pnBytesReturned: unsigned int*
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_ControlCmd", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_ControlCmd(System.IntPtr pInputBuffer, uint nBytesInInputBuffer, System.IntPtr pOutputBuffer, uint nSizeOfOutputBuffer, ref uint pnBytesReturned);


//        /// Return Type: ZBCR_STATUS->int
//        ///pInputBuffer: unsigned char*
//        ///nBytesInInputBuffer: unsigned int
//        ///pOutputBuffer: unsigned char*
//        ///nSizeOfOutputBuffer: unsigned int
//        ///pnBytesReturned: unsigned int*
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_StatusRead", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_StatusRead(System.IntPtr pInputBuffer, uint nBytesInInputBuffer, System.IntPtr pOutputBuffer, uint nSizeOfOutputBuffer, ref uint pnBytesReturned);


//        /// Return Type: ZBCR_STATUS->int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_StartScan", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_StartScan();


//        /// Return Type: ZBCR_STATUS->int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_StopScan", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_StopScan();


//        /// Return Type: ZBCR_STATUS->int
//        ///setNo: unsigned int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_Led", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_Led(uint setNo);


//        /// Return Type: ZBCR_STATUS->int
//        ///setNo: unsigned int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_LocationLed", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_LocationLed(uint setNo);


//        /// Return Type: ZBCR_STATUS->int
//        ///setNo: unsigned int
//        [System.Runtime.InteropServices.DllImportAttribute(pathStr, EntryPoint = "ZBCR_ScanModel", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int ZBCR_ScanModel(uint setNo);

//    }

//    public partial class NewZbRealize
//    {
//        public delegate void GetQrcode(string qrcode);      //回掉函数委托
//        public static event GetQrcode OnGetQrcode;      //回掉事件
//        static System.Timers.Timer readqr = null;
//        public static bool IsReaded = false;

//        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
//        public struct PortParam
//        {
//            public ushort portNo;
//            public uint baudRate;
//        };

//        /*
//         * 定义DLL接口托管函数
//         */
//        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
//        public delegate void CALL_BACK_DATA(IntPtr dataPtr, uint length, uint userdata);

//        //初始化回调函数，且为静态的，否则系统会回收
//        static CALL_BACK_DATA fd = new CALL_BACK_DATA(ReadData);


//        /// <summary>
//        /// 连接打印机
//        /// </summary>
//        /// <param name="port">端口号</param>
//        /// <param name="baundate">波特率</param>
//        /// <returns></returns>
//        public static bool ConnectQrcode(ushort port, uint baundate)
//        {
//            bool result = false;
//            try
//            {
//                //COM端口初始化
//                PortParam pp = new PortParam();
//                pp.portNo = port;
//                pp.baudRate = baundate;
//                IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(pp));
//                Marshal.StructureToPtr(pp, pnt, true);

//                //连接端口，并传入解码输出回调函数
//                //int res = ZBCR_Open(pnt, fd, 0);
//                int res = ZBCR_Open(IntPtr.Zero, fd, 0);    //201804041121厂家提供的修改，可以自动扫描端口
//                if (res == 1) result = true;
//            }
//            catch (Exception err)
//            {

//            }
//            return result;
//        }

//        /// <summary>
//        /// 解码成功后的数据输出回调函数
//        /// </summary>
//        /// <param name="dataPtr"></param>
//        /// <param name="length"></param>
//        /// <param name="userdata"></param>
//        public static void ReadData(IntPtr dataPtr, uint length, uint userdata)
//        {
//            try
//            {
//                int len = (int)length;
//                byte[] data = new byte[len];
//                Marshal.Copy(dataPtr, data, 0, len);
//                string hex = BitConverter.ToString(data, 0, len);
//                string charstr = System.Text.Encoding.ASCII.GetString(data);
//                OnGetQrcode(charstr);
//            }
//            catch
//            {

//            }
//        }

//        /// <summary>
//        /// 开始扫描
//        /// </summary>
//        /// <returns></returns>
//        public static bool StartScan()
//        {
//            if (ZBCR_StartScan() == 1)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// 停止扫描
//        /// </summary>
//        public static void StopScan()
//        {
//            ZBCR_StopScan();
//        }

//        /// <summary>
//        /// 初始化QR
//        /// </summary>
//        /// <param name="intervalTimes"></param>
//        public static void InitQR(int intervalTimes)
//        {
//            readqr = new System.Timers.Timer();
//            readqr.Interval = intervalTimes;
//            readqr.Elapsed += new System.Timers.ElapsedEventHandler(readqr_Elapsed);
//        }

//        static void readqr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
//        {
//            readqr.Enabled = false;
//            StopScan();
//        }

//        /// <summary>
//        /// 设置感应模式
//        /// </summary>
//        /// <param name="setNo"></param>
//        public static void ScanModel(uint setNo)
//        {
//            ZBCR_ScanModel(setNo);
//        }

//        /// <summary>
//        /// 设置补光灯模式
//        /// </summary>
//        public static void SetLed(uint setNo)
//        {
//            ZBCR_Led(setNo);
//        }

//        /// <summary>
//        /// 设置定位灯模式
//        /// </summary>
//        public static void SetLocationLed(uint setNo)
//        {
//            ZBCR_LocationLed(setNo);
//        }

//    }
//}
