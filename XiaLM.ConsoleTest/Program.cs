using Microsoft.VisualBasic;
using System;
using System.Text;
//using XiaLM.ConsoleTest.Dynamic;
//using XiaLM.Weather.source;

namespace XiaLM.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("控制台程序已启动，输入Q/q退出程序！");
            string txt = string.Empty;
            while (!(txt = Console.ReadLine()).ToUpper().Equals("Q"))
            {
                //if (txt.ToUpper().Equals("A"))
                //{
                //    WeatherHelper weatherHelper = new WeatherHelper("yzwniowtxrdeejan");
                //    //var info = weatherHelper.GetWeather("武汉");
                //    var info = weatherHelper.GetWeather("霍尔果斯");
                //}
                //if (txt.ToUpper().Equals("T"))
                //{
                //    new Tdynamic().Test();
                //}

                if (txt.ToUpper().Equals("A"))
                {
                    string wybs = "201809021120302344546545645";

                    //2112 - 03 - 02 34:45:46
                    wybs.Substring(8, 4);
                    var sj = Strings.Mid(wybs, 8, 4) + "-" + Strings.Mid(wybs, 12, 2) + "-" + Strings.Mid(wybs, 14, 2) + " " + Strings.Mid(wybs, 16, 2) + ":" + Strings.Mid(wybs, 18, 2) + ":" + Strings.Mid(wybs, 20, 2);

                    string data = Strings.StrConv(wybs, VbStrConv.Wide, 0); //"２０１８０９０２１１２０３０２３４４５４６５４５６４５"

                    var lll = ToSBC(wybs);

                    short value = (short)Strings.Asc('A');  //65
                    string hexOutput = Conversion.Hex(value);   //"41"

                    short a = (short)'A';
                    string b = string.Format("{0:X}", a);

                }


            }
        }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToSBC(String input)
        {
            // 半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
    }
}
