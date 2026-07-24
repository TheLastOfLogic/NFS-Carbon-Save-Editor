using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher
{
    internal class Helper_Functions
    {

        
        /*public static UInt16 Part_ID(byte[] Data, int Offset, bool Xbox_360)
        {
            UInt16 Part_ID = Data[Offset];
            if (Xbox_360)
            {
                //Part_ID > 0x8000 Enabled
            }
            else
            {
                //if part is there, its Enabled, not the same
            }
        } */

        public static int Grab_Position_From_Anchor(byte[] Data, bool Xbox)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0x033FA23A)
            {
                Pos += 0x10;
            }

            return Pos;
        }

        public static int Grab_Position_Anchor_For_Car_Structure(byte[] Data, bool Xbox)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            Pos += 0x10000;
            Pos += ReadInt32(Data, Pos, Xbox) * 0x10;
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0x00023FA4)
            {
                Pos += 0x4;
            }

            return Pos;
        }

        public static uint ReadUInt32(byte[] data, int offset, bool isBigEndian)
        {
            uint value = BitConverter.ToUInt32(data, offset);

            // If Xbox 360, swap the bytes so the PC can read it properly
            if (isBigEndian)
            {
                value = (value & 0x000000FFU) << 24 |
                        (value & 0x0000FF00U) << 8 |
                        (value & 0x00FF0000U) >> 8 |
                        (value & 0xFF000000U) >> 24;
            }
            return value;
        }

        public static ushort ReadUInt16(byte[] data, int offset, bool IsBigEndian)
        {
            if (IsBigEndian)
            {
                // Big Endian (Xbox 360): [High Byte][Low Byte]
                return (ushort)((data[offset] << 8) | data[offset + 1]);
            }
            else
            {
                // Little Endian (PC): [Low Byte][High Byte]
                return (ushort)((data[offset + 1] << 8) | data[offset]);
            }
        }

        // And the Int32 version since your struct uses Int32
        public static int ReadInt32(byte[] data, int offset, bool isBigEndian)
        {
            return (int)ReadUInt32(data, offset, isBigEndian);
        }

        public static void WriteUInt16(byte[] data, int offset, ushort value, bool isBigEndian)
        {
            if (isBigEndian)
            {
                // Big Endian: Most Significant Byte first
                data[offset] = (byte)(value >> 8);
                data[offset + 1] = (byte)(value);
            }
            else
            {
                // Little Endian: Least Significant Byte first
                data[offset] = (byte)(value);
                data[offset + 1] = (byte)(value >> 8);
            }
        }

        public static uint WriteUInt32(byte[] data, int offset, uint value, bool isBigEndian)
        {
            // If it's Xbox 360, flip the value before converting to bytes
            if (isBigEndian)
            {
                value = (value & 0x000000FFU) << 24 |
                        (value & 0x0000FF00U) << 8 |
                        (value & 0x00FF0000U) >> 8 |
                        (value & 0xFF000000U) >> 24;
            }

            // Convert the (possibly flipped) value into bytes
            byte[] bytes = BitConverter.GetBytes(value);

            // Write it into the target array at the correct offset
            Buffer.BlockCopy(bytes, 0, data, offset, 4);
            return value;
        }

        public static void WriteInt32(byte[] data, int offset, int value, bool isBigEndian)
        {
            WriteUInt32(data, offset, (uint)value, isBigEndian);
        }
        public static int SwapEndianness(int value)
        {
            uint b1 = ((uint)value >> 24) & 0xff;
            uint b2 = ((uint)value >> 8) & 0xff00;
            uint b3 = ((uint)value << 8) & 0xff0000;
            uint b4 = ((uint)value << 24) & 0xff000000;

            return (int)(b1 | b2 | b3 | b4);
        }

        public static void WriteInt32_No_Endianess(byte[] data, int offset, int value)
        {
            // Convert the (possibly flipped) value into bytes
            byte[] bytes = BitConverter.GetBytes(value);

            // Write it into the target array at the correct offset
            Buffer.BlockCopy(bytes, 0, data, offset, 4);
        }

        public static void Build_Complete_JDLZ_Data_Base(ListView lv, ref byte[] JDLZ_Data)
        {
            if (lv.SelectedItems.Count > 0)
            {
                // 1. Get the selected row
                ListViewItem selectedRow = lv.SelectedItems[0];
                string offset = selectedRow.SubItems[1].Text; // Column 2 (Offset)
                string packed = selectedRow.SubItems[2].Text; // Column 3 (Packed)
                string unpacked = selectedRow.SubItems[3].Text; // Column 4 (Unpacked)
                JDLZ_Data = new byte[int.Parse(unpacked.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber)];
                Buffer.BlockCopy(Form1.Find_Game, int.Parse(offset.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber), JDLZ_Data, 0, int.Parse(unpacked.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber));
            }
        }

        public static void Grabbing_Data(ListView lv, ref byte[] JDLZ_Data)
        {
            if (lv.SelectedItems.Count > 0)
            {
                // 1. Get the selected row
                ListViewItem selectedRow = lv.SelectedItems[0];
                string offset = selectedRow.SubItems[1].Text; // Column 2 (Offset)
                string packed = selectedRow.SubItems[2].Text; // Column 3 (Packed)
                string unpacked = selectedRow.SubItems[3].Text; // Column 4 (Unpacked)
                JDLZ_Data = new byte[int.Parse(unpacked.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber)];
                Buffer.BlockCopy(Form1.Find_Game, int.Parse(offset.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber),JDLZ_Data,0, int.Parse(unpacked.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber));
            }

            //JDLZ_Data = JDLZ.decompress(JDLZ_Data);
        }



        public static void Populate_JDLZ_List(ListView lw)
        {
            int Count = 0;
            int[] Index  = new int[25];
            int[] Unpacked = new int[25];
            int[] Packed = new int[25];
            
            // Ensure the view is correct
            lw.View = View.Details;
            lw.FullRowSelect = true; // Makes it easier to see what you're clicking

            // Clear everything as per your preference
            lw.Items.Clear();
            lw.Columns.Clear();

            // Set the Column Collection
            lw.Columns.Add("#", 25);
            lw.Columns.Add("Offset", 120);
            lw.Columns.Add("Packed Size", 120);
            lw.Columns.Add("Unpacked Size", 120);

            Find_JDLZ(Form1.Find_Game, ref Count, ref Index, ref Unpacked, ref Packed);
            for (int i = 0; i < Count; i++)
            {
               
                lw.Items.Add((i+1).ToString());
                lw.Items[i].SubItems.Add("0x" + Index[i].ToString("X"));
                if (Save_Form.Xbox_360 == true)
                {  
                    lw.Items[i].SubItems.Add("0x" + SwapEndianness(Packed[i]).ToString("X"));
                    lw.Items[i].SubItems.Add("0x" + SwapEndianness(Unpacked[i]).ToString("X"));
                }
                else
                {
                    lw.Items[i].SubItems.Add("0x" + Packed[i].ToString("X"));
                    lw.Items[i].SubItems.Add("0x" + Unpacked[i].ToString("X"));
                }
                }

            }

        public static void Find_JDLZ(byte[] Data,  ref int Count, ref int[] index, ref int[] Unpacked_Length, ref int[] Packed_Length)
        {
            for (int i = index[Count]; i < Data.Length - 4; i++)
            {
                if ((Data[i] == 0x5A) && (Data[i + 1] == 0x4C) && (Data[i + 2] == 0x44) && (Data[i + 3] == 0x4A) || (Data[i] == 0x4A) && (Data[i + 1] == 0x44) && (Data[i + 2] == 0x4C) && (Data[i + 3] == 0x5A))
                {

                    Unpacked_Length[Count] = BitConverter.ToInt32(Data, i + 8);
                    Packed_Length[Count] = BitConverter.ToInt32(Data, i + 0xC);
                    index[Count] = i;
                    Count++;
                }
            }
        }


        public static void UIntToBytes(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value & 0xFF);
            buffer[offset + 1] = (byte)((value >> 8) & 0xFF);
            buffer[offset + 2] = (byte)((value >> 16) & 0xFF);
            buffer[offset + 3] = (byte)((value >> 24) & 0xFF);
        }



        public static Dictionary<uint, string> BinKeys { get; } = new Dictionary<uint, string>();

        public static uint Bin_Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) // check for being null
                return 0;

            var arr = Encoding.ASCII.GetBytes(value);
            var len = 0;
            var result = 0xFFFFFFFF;

            while (len < arr.Length)
            {
                result *= 0x21;
                result += arr[len++];
            }

            // Put into raider keys
            BinKeys[result] = value;
            return result;
        }

        private static void Mix32_1(ref uint a, ref uint b, ref uint c)
        {
            a = c >> 13 ^ (a - b - c);
            b = a << 8 ^ (b - c - a);
            c = b >> 13 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 16 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 3 ^ (a - b - c);
            b = a << 10 ^ (b - c - a);
            c = b >> 15 ^ (c - a - b);
        }
        private static uint Mix32_2(uint a, uint b, uint c)
        {
            a = c >> 13 ^ (a - b - c);
            b = a << 8 ^ (b - c - a);
            c = b >> 13 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 16 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 3 ^ (a - b - c);
            b = a << 10 ^ (b - c - a);
            return b >> 15 ^ (c - a - b);
        }
        private static void Mix64_1(ref ulong a, ref ulong b, ref ulong c)
        {
            a = c >> 43 ^ (a - b - c);
            b = a << 9 ^ (b - c - a);
            c = b >> 8 ^ (c - a - b);
            a = c >> 38 ^ (a - b - c);
            b = a << 23 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 35 ^ (a - b - c);
            b = a << 49 ^ (b - c - a);
            c = b >> 11 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 18 ^ (b - c - a);
            c = b >> 22 ^ (c - a - b);
        }
        private static ulong Mix64_2(ulong a, ulong b, ulong c)
        {
            a = c >> 43 ^ (a - b - c);
            b = a << 9 ^ (b - c - a);
            c = b >> 8 ^ (c - a - b);
            a = c >> 38 ^ (a - b - c);
            b = a << 23 ^ (b - c - a);
            c = b >> 5 ^ (c - a - b);
            a = c >> 35 ^ (a - b - c);
            b = a << 49 ^ (b - c - a);
            c = b >> 11 ^ (c - a - b);
            a = c >> 12 ^ (a - b - c);
            b = a << 18 ^ (b - c - a);
            return b >> 22 ^ (c - a - b);
        }
    

        public static uint VLT_Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;

            var arr = Encoding.ASCII.GetBytes(value);
            var a = 0x9E3779B9;
            var b = 0x9E3779B9;
            var c = 0xABCDEF00;
            var v1 = 0;
            var v2 = arr.Length;

            while (v2 >= 12)
            {
                a += BitConverter.ToUInt32(arr, v1);
                b += BitConverter.ToUInt32(arr, v1 + 4);
                c += BitConverter.ToUInt32(arr, v1 + 8);
                Mix32_1(ref a, ref b, ref c);
                v1 += 12;
                v2 -= 12;
            }

            c += (uint)arr.Length;

            switch (v2)
            {
                case 11:
                    c += (uint)arr[10 + v1] << 24;
                    goto case 10;
                case 10:
                    c += (uint)arr[9 + v1] << 16;
                    goto case 9;
                case 9:
                    c += (uint)arr[8 + v1] << 8;
                    goto case 8;
                case 8:
                    b += (uint)arr[7 + v1] << 24;
                    goto case 7;
                case 7:
                    b += (uint)arr[6 + v1] << 16;
                    goto case 6;
                case 6:
                    b += (uint)arr[5 + v1] << 8;
                    goto case 5;
                case 5:
                    b += arr[4 + v1];
                    goto case 4;
                case 4:
                    a += (uint)arr[3 + v1] << 24;
                    goto case 3;
                case 3:
                    a += (uint)arr[2 + v1] << 16;
                    goto case 2;
                case 2:
                    a += (uint)arr[1 + v1] << 8;
                    goto case 1;
                case 1:
                    a += arr[v1];
                    break;
                default:
                    break;
            }

            return Mix32_2(a, b, c);
        }
    }
}
