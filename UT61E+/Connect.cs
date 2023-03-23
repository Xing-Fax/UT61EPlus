using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UT61E_
{
    internal class Connect
    {
        public const string DLL_NAME = @"library\UT61E+.dll";
        /// <summary>
        /// 初始化连接
        /// </summary>
        [DllImport(DLL_NAME, EntryPoint = "Initial", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Initial();

        /// <summary>
        /// 得到序列号
        /// </summary>
        /// <returns>返回十六进制字符串</returns>
        [DllImport(DLL_NAME, EntryPoint = "Serial", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Serial();

        /// <summary>
        /// 原始字节信息
        /// </summary>
        /// <returns>返回原始合并后字符串</returns>
        [DllImport(DLL_NAME, EntryPoint = "Original", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Original();

        /// <summary>
        /// 返回格式化后字节信息
        /// </summary>
        /// <returns>返回格式化合并后字符串</returns>
        [DllImport(DLL_NAME, EntryPoint = "Format", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Format();

        /// <summary>
        /// 得到最终数据
        /// </summary>
        /// <returns>返回最终数据</returns>
        [DllImport(DLL_NAME, EntryPoint = "Finally", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Finally();

        /// <summary>
        /// 得到全部数据
        /// </summary>
        /// <returns>返回得到全部的数据</returns>
        [DllImport(DLL_NAME, EntryPoint = "GetAll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetAll();

        /// <summary>
        /// 得到指定数据
        /// </summary>
        /// <param name="Name">数据标识</param>
        /// <returns>返回以UTF8编码的字符串</returns>
        public static string GetData(string Name)
        {
            switch (Name)
            {
                case "Initial":
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(Initial())));
                case "Serial":
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(Serial())));
                case "Original":
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(Original())));
                case "Format":
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(Format())));
                case "Finally":
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(Finally())));
                case "GetAll":
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(Marshal.PtrToStringUni(GetAll())));
                default:
                    return Encoding.UTF8.GetString(Encoding.Unicode.GetBytes("Null"));
            }
        }

        /// <summary>
        /// 得到当前模式
        /// </summary>
        /// <param name="Mode">字节位</param>
        /// <returns>返回模式</returns>
        public static string Patterns(string Data)
        {
            switch (Data)
            {
                case "00":
                    return "V AC";
                case "18":
                    return "LPF";
                case "04":
                    return "Hz";
                case "05":
                    return "%";
                case "02":
                    return "V DC";
                case "19":
                    return "DC+AC";
                case "01":
                    return "mV AC";
                case "03":
                    return "mV DC";
                case "06":
                    return "Ohm";
                case "07":
                    return "Continuity";
                case "08":
                    return "Diode";
                case "09":
                    return "Capacity";
                case "12":
                    return "hEF";
                case "0c":
                    return "uA DC";
                case "0d":
                    return "uA AC";
                case "0e":
                    return "mA DC";
                case "0f":
                    return "mA AC";
                case "10":
                    return "A DC";
                case "11":
                    return "A AC";
                case "14":
                    return "NCV";
                default:
                    return "Unknown";
            }
        }
        /// <summary>
        /// 返回当前挡位量程
        /// </summary>
        /// <param name="Mode">模式</param>
        /// <param name="Data">字节位</param>
        /// <returns>返回带单位的量程</returns>
        public static string Scope(string Mode, string Data)
        {
            //直流电压、交流电压、直流加交流、低通滤波
            if (Mode == "V AC" || Mode == "V DC" || Mode == "DC + AC" || Mode == "LPF")
            {
                switch (Data)
                {
                    case "30":
                        return "2 V";
                    case "31":
                        return "22 V";
                    case "32":
                        return "220 V";
                    case "33":
                        return "1000 V";
                    default:
                        return "Unknown";
                }
            }
            //交流毫伏、直流毫伏
            if (Mode == "mV AC" || Mode == "mV DC")
            {
                switch (Data)
                {
                    case "30":
                        return "220 mV";
                    default:
                        return "Unknown";
                }
            }
            //电阻
            if (Mode == "Ohm")
            {
                switch (Data)
                {
                    case "30":
                        return "220 Ω";
                    case "31":
                        return "2 KΩ";
                    case "32":
                        return "22 KΩ";
                    case "33":
                        return "220 KΩ";
                    case "34":
                        return "2 MΩ";
                    case "35":
                        return "22 MΩ";
                    case "36":
                        return "220 MΩ";
                    default:
                        return "Unknown";
                }
            }
            //通断
            if (Mode == "Continuity")
            {
                switch (Data)
                {
                    case "30":
                        return "200 Ω";
                    default:
                        return "Unknown";
                }
            }
            //频率
            if (Mode == "Hz")
            {
                switch (Data)
                {
                    case "30":
                        return "22 Hz";
                    case "31":
                        return "220 Hz";
                    case "32":
                        return "2 KHz";
                    case "33":
                        return "22 KHz";
                    case "34":
                        return "220 KHz";
                    case "35":
                        return "2 MHz";
                    case "36":
                        return "22 MHz";
                    case "37":
                        return "220 MHz";
                    default:
                        return "Unknown";
                }
            }
            //电容
            if (Mode == "Capacity")
            {
                switch (Data)
                {
                    case "30":
                        return "22 nF";
                    case "31":
                        return "220 nF";
                    case "32":
                        return "2 uF";
                    case "33":
                        return "22 uF";
                    case "34":
                        return "220 uF";
                    case "35":
                        return "2 mF";
                    case "36":
                        return "22 mF";
                    case "37":
                        return "220 mF";
                    default:
                        return "Unknown";
                }
            }
            //二极管
            if (Mode == "Diode")
            {
                switch (Data)
                {
                    case "30":
                        return "2 V";
                    default:
                        return "Unknown";
                }
            }
            //交流微安、直流微安
            if (Mode == "uA DC" || Mode == "uA AC")
            {
                switch (Data)
                {
                    case "30":
                        return "220 uA";
                    case "31":
                        return "2200 uF";
                    default:
                        return "Unknown";
                }
            }
            //直流毫安、交流毫伏
            if (Mode == "mA DC" || Mode == "mA AC")
            {
                switch (Data)
                {
                    case "30":
                        return "22 mA";
                    case "31":
                        return "220 mF";
                    default:
                        return "Unknown";
                }
            }
            //直流安培、交流安培
            if (Mode == "A DC" || Mode == "A AC")
            {
                switch (Data)
                {
                    case "31":
                        return "20 A";
                    default:
                        return "Unknown";
                }
            }
            //占空比
            if (Mode == "%")
            {
                switch (Data)
                {
                    case "30":
                        return "100 %";
                    default:
                        return "Unknown";
                }
            }
            //三极管、非接触测量
            if (Mode == "hEF" || Mode == "NCV")
                return "No Scope";
            return "Unknown";
        }

        /// <summary>
        /// 返回测量值的正负
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>返回"+"/"-"</returns>
        public static string Direction(string Data)
        {
            if (Data == "20")
                return "+";
            if (Data == "2d")
                return "-";
            return "Unknown";
        }

        /// <summary>
        /// 返回测量数值
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>返回数值,并去前导0</returns>
        public static string Result(string[] Data)
        {
            string[] Bit = { Data[4], Data[5], Data[6], Data[7], Data[8], Data[9] };
            if (Data[1] == "14")
            {
                string Value = string.Empty;
                for (int i = 0; i <= 5; i++)
                    if (Bit[i] != "20")
                        Value += Bit[i].Substring(Bit[i].Length - 1, 1);
                return Value.Replace("56", "EF").Replace("d","-");
            }
            else
            {
                if (Bit[0] == "2e")
                    return "OL";
                for (int i = 0; i < Bit.Length; i++)
                    if (Bit[i] == "4f" || Bit[i] == "4c")
                        return "OL";
                string Value = string.Empty;
                for (int i = 0; i <= 5; i++)
                    if (Bit[i] != "20")
                        Value += Bit[i].Substring(Bit[i].Length - 1, 1);
                return Value.Replace("e", ".");
            }
        }

        /// <summary>
        /// 返回是否自动量程
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string State(string Data)
        {
            if (Data == "30")
                return "Yes";
            return "No";
        }

        /// <summary>
        /// 返回是否在REL模式
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string Line(string[] Data)
        {
            string[] Bit = { Data[12], Data[13] };
            if (Bit[1] == "34" && Bit[0] == "31")
                return "Yes";
            return "No";

        }

        /// <summary>
        /// 返回是否在最大值状态
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string Biggest(string[] Data)
        {
            string[] Bit = { Data[12], Data[13] };
            if (Bit[1] == "34" && Bit[0] == "38")
                return "Yes";
            return "No";
        }

        /// <summary>
        /// 返回是否在最小值状态
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string Smallest(string[] Data)
        {
            string[] Bit = { Data[12], Data[13] };
            if (Bit[1] == "34" && Bit[0] == "34")
                return "Yes";
            return "No";
        }

        /// <summary>
        /// 返回是否在最大波峰状态
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string MaxCrest(string[] Data)
        {
            string[] Bit = { Data[13], Data[14] };
            if (Bit[0] == "34" && Bit[1] == "34")
                return "Yes";
            return "No";
        }

        /// <summary>
        /// 返回是否在最小波峰状态
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string MinCrest(string[] Data)
        {
            string[] Bit = { Data[13], Data[14] };
            if (Bit[0] == "34" && Bit[1] == "32")
                return "Yes";
            return "No";
        }

        /// <summary>
        /// 返回是否在数据保持模式
        /// </summary>
        /// <param name="Data">字节位</param>
        /// <returns>"是"或"否"</returns>
        public static string Keep(string[] Data)
        {
            string[] Bit = { Data[12], Data[13] };
            if (Bit[0] == "32" && Bit[1] == "30")
                return "Yes";
            return "No";
        }

    }
}

