using EA_MD5_hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace md5_hash
{
    internal class Call_2cfe60
    {


        public static byte[] Game = new byte[0xFFF0];
        public static byte[] PC = new byte[0x45FF0];
        public static void Call_02D3F20(byte[] Data, bool Game_MD5)
        {
            MD5 md5 = MD5.Create();
            
            UInt32 A = 0x67452301;
            UInt32 B = 0xEFCDAB89;
            UInt32 C = 0x98BADCFE;
            UInt32 D = 0x10325476;
            byte[] input_data = new byte[1];
            Int32 ABCD_Offset = 0;
            
                input_data = new byte[0xFFF0];
                Buffer.BlockCopy(Data, 0x7C, input_data, 00, 0xFFF0);
                byte[] buffer1 = { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0xFF, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00 };
                //Buffer.BlockCopy(buffer1, 0, input_data, 0xFFF0, 0x10);
            //File.WriteAllBytes("C:\\Users\\Logic\\Documents\\NFS Carbon\\ANAME\\ANAME1", input_data);
                buffer1 = md5.ComputeHash(input_data);
            MessageBox.Show(BitConverter.ToString(buffer1));
                ABCD_Offset = 0x6C;
            
            if (Game_MD5 == true && Helper_Functions.ReadUInt32(Data, 0x20, false) == 0x184B0300)
            {
                input_data = new byte[0x10000];
                Buffer.BlockCopy(Data, 0x3C, input_data, 00, 0xFFF0);
                //buffer1 = { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0xFF, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00 };
                Buffer.BlockCopy(buffer1, 0, input_data, 0xFFF0, 0x10);
                MessageBox.Show(md5.ComputeHash(input_data).ToString());
                ABCD_Offset = 0x4C;
            }
            else if (Game_MD5 != true && Helper_Functions.ReadUInt32(Data, 0x20, false) == 0x00034B48)
            {
                input_data = new byte[Data.Length - 0x3c];
                Buffer.BlockCopy(Data, 0x3C, input_data, 00, input_data.Length);
            }
            byte[] MD5_0x80_list = new byte[0x40];
            byte[] buffer = new byte[0x40];
            byte counter = 0;

           // md5.ComputeHash(in)


            for (int i = 0; i < input_data.Length;)
            {
                //side note, all if you want the values to carry over in the function such as uint a, we need to set a = to form1.A and at the end set Form1.A to a, otherwise
                //its almost like a pop where it was only used once

                if ((input_data.Length - i) >= 0x40)
                {
                    Buffer.BlockCopy(input_data, i, buffer, 0, 0x40);
                    Call_2cfe60.ProcessMD5Block(buffer, ref A, ref B, ref C, ref D);
                    i += 0x40;
                }
                else

                //this might be the wrong way to process A,B,C,D
                {//we set the left over bytes to start a 0x10 as 0x0 - 0x0F is the First Hash
                    Byte[] Buffer_0x40 = new byte[0x40];
                    //need to place instructions to add A/B/C/D To The First 0x10 bytes
                    byte[] True_Buffer = new byte[0x4]; //= BitConverter.GetBytes(Form1.A);

                    Buffer.BlockCopy(input_data, i, buffer, 0x0, input_data.Length - i);
                    i = input_data.Length;


                    //0xFFF0 Length * 8 == 0x80FF07
                    byte[] Game_ = { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0xFF, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00 }; //V 1.1 is a 9 not an 7 v 1.0 is 7
                    byte[] PC = { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0xFF, 0x022, 0x00, 0x00, 0x00, 0x00, 0x00 };

                    //won't work as MD5 Flag will have been set, maybe add a second flag for this
                    //store length in R11
                    int length = 0xFFF0;
                    int length_PC = 0x45FF0;
                    bool pc = true;

                    if (pc == false)
                    {
                        Game_[8] = (byte)(length << 3);
                        Game_[9] = (byte)(length >> 5);
                        Game_[0x0A] = (byte)(length >> 13);
                        Game_[0x0B] = (byte)(length >> 21);
                        Game_[0x0C] = (byte)(length >> 28);
                        Buffer.BlockCopy(Game_, 0, buffer, 0x30, 0x10);
                        Call_2cfe60.ProcessMD5Block(buffer, ref A, ref B, ref C, ref D);
                    }
                    else
                    {
                        PC[8] = (byte)(length_PC << 3);
                        PC[9] = (byte)(length_PC >> 5);
                        PC[0x0A] = (byte)(length_PC >> 13);
                        PC[0x0B] = (byte)(length_PC >> 21);
                        PC[0x0C] = (byte)(length_PC >> 28);
                        Buffer.BlockCopy(PC, 0, buffer, 0x30, 0x10);
                        Call_2cfe60.ProcessMD5Block(buffer, ref A, ref B, ref C, ref D);
                    }

                    byte dl;

                    if (Game_MD5 != true)
                    {

                        for (int p = 0; p < 4; p++)
                        {
                            for (int c = 0x0; c < buffer.Length; c++)
                            {
                                buffer[c] = 0;
                            }
                            buffer[0x10] = 0x80;
                            buffer[0x38] = 0x80;
                            //Buffer.BlockCopy(Fluff, 0, buffer, 0x30, 0x10);
                            True_Buffer = BitConverter.GetBytes(A);
                            Buffer.BlockCopy(True_Buffer, 0x0, buffer, 0, 4);
                            //Array.Reverse(True_Buffer);
                            Buffer.BlockCopy(True_Buffer, 0x0, MD5_0x80_list, counter, 4);

                            True_Buffer = BitConverter.GetBytes(B);
                            Buffer.BlockCopy(True_Buffer, 0x0, buffer, 4, 4);
                            //Array.Reverse(True_Buffer);
                            Buffer.BlockCopy(True_Buffer, 0x0, MD5_0x80_list, counter + 0x4, 4);

                            True_Buffer = BitConverter.GetBytes(C);
                            Buffer.BlockCopy(True_Buffer, 0x0, buffer, 8, 4);
                            //Array.Reverse(True_Buffer);
                            Buffer.BlockCopy(True_Buffer, 0x0, MD5_0x80_list, counter + 0x8, 4);

                            True_Buffer = BitConverter.GetBytes(D);
                            Buffer.BlockCopy(True_Buffer, 0x0, buffer, 0xC, 4);
                            //Array.Reverse(True_Buffer);
                            Buffer.BlockCopy(True_Buffer, 0x0, MD5_0x80_list, counter + 0xC, 4);
                            counter += 0x10;


                            A = 0x67452301;
                            B = 0xEFCDAB89;
                            C = 0x98BADCFE;
                            D = 0x10325476;
                            Call_2cfe60.ProcessMD5Block(buffer, ref A, ref B, ref C, ref D);
                        }
                        Get_Registry_Key.Fix_Get_Key(Data, MD5_0x80_list);

                    }
                    else
                    {
                        Helper_Functions.WriteUInt32(Data, ABCD_Offset, A, Save_Form.Xbox_360);
                        Helper_Functions.WriteUInt32(Data, ABCD_Offset + 4, B, Save_Form.Xbox_360);
                        Helper_Functions.WriteUInt32(Data, ABCD_Offset + 8, C, Save_Form.Xbox_360);
                        Helper_Functions.WriteUInt32(Data, ABCD_Offset+ 0xC, D, Save_Form.Xbox_360);
                    }

                }
            }

        }

                    

        public static void ProcessMD5Block(byte[] buffer, ref uint A, ref uint B, ref uint C, ref uint D)
        {
            byte after_buffer_count = 0x10;
            uint[] after_buffer = new uint[0x10];
            uint eax;
            uint ebx;
            uint ecx;
            uint edx;
            uint edi;
            uint esi;
            uint ebp;
            
            for (int p = 0x40; p > 0;)
            {
                edx = buffer[p - 1];
                p--;
                edi = buffer[p - 1];
                p--;
                edx <<= 8;
                edx += edi;
                edi = buffer[p - 1];
                p--;
                edx <<= 8;
                edx += edi;
                edi = buffer[p - 1];
                p--;
                edx <<= 8;
                edx += edi;
                after_buffer_count--;
                after_buffer[after_buffer_count] = edx;
            }
            edx = D;
            esi = C;
            ebp = B;
            ecx = A;
            eax = edx;
            eax ^= esi;
            eax &= ebp;
            eax ^= edx;
            eax += ecx;
            ecx = after_buffer[0];
            eax = eax + ecx - 0x28955B88;
            eax = Form1.RotateLeft(eax, 7);
            eax += ebp;
            ecx = esi;
            ecx ^= ebp;
            ecx &= eax;
            ecx ^= esi;
            ecx += after_buffer[1];
            edx = ecx + edx - 0x173848AA;
            edx = Form1.RotateLeft(edx, 0x0C);
            edx += eax;
            ecx = ebp;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= ebp;
            ecx += after_buffer[2];
            esi = (ecx + esi + 0x242070DB);
            esi = Form1.RotateRight(esi, 0x0F);
            esi += edx;
            ecx = edx;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[3];
            edi = ecx + ebp - 0x3E423112;
            edi = Form1.RotateRight(edi, 0x0A);
            edi += esi;
            ecx = edx;
            ecx ^= esi;
            ecx &= edi;
            ecx ^= edx;
            ecx += after_buffer[4];
            eax = ecx + eax - 0x0A83F051;
            eax = Form1.RotateLeft(eax, 0x07);
            eax += edi;
            ecx = esi;
            ecx ^= edi;
            ecx &= eax;
            ecx ^= esi;
            ecx += after_buffer[5];
            edx = ecx + edx + 0x4787C62A;
            edx = Form1.RotateLeft(edx, 0x0C);
            edx += eax;
            ecx = edi;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= edi;
            ecx += after_buffer[6];
            esi = ecx + esi - 0x57CFB9ED;
            esi = Form1.RotateRight(esi, 0x0F);
            esi += edx;
            ecx = edx;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[7];
            edi = ecx + edi - 0x02B96AFF;

            edi = Form1.RotateRight(edi, 0x0A);
            edi += esi;
            ecx = edx;
            ecx ^= esi;
            ecx &= edi;
            ecx ^= edx;
            ecx += after_buffer[8];
            eax = ecx + eax + 0x698098D8;
            eax = Form1.RotateLeft(eax, 0x07);
            ecx = esi;
            eax += edi;
            ecx ^= edi;
            ecx &= eax;
            ecx ^= esi;
            ecx += after_buffer[9];
            edx = ecx + edx - 0x74BB0851;
            edx = Form1.RotateLeft(edx, 0x0C);
            edx += eax;
            ecx = edi;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= edi;
            ecx += after_buffer[0x0A];
            esi = ecx + esi - 0x0000A44F;
            esi = Form1.RotateRight(esi, 0x0F);
            esi += edx;
            ecx = edx;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[0x0B];
            edi = ecx + edi - 0x76A32842;
            ecx = edx;
            ecx ^= esi;
            edi = Form1.RotateRight(edi, 0x0A);
            edi += esi;
            ecx &= edi;
            ecx ^= edx;
            ecx += after_buffer[0x0C];
            eax = ecx + eax + 0x6B901122;
            eax = Form1.RotateLeft(eax, 0x07);
            eax += edi;
            ecx = esi;
            ecx ^= edi;
            ecx &= eax;
            ecx ^= esi;
            ecx += after_buffer[0x0D];
            ebx = ecx + edx - 0x02678E6D;
            ebx = Form1.RotateLeft(ebx, 0x0C);
            ebx += eax;
            edx = edi;
            edx ^= eax;
            edx &= ebx;
            edx ^= edi;
            edx += after_buffer[0x0E];
            ecx = ebx;
            ecx ^= eax;
            edx = edx + esi - 0x5986BC72;
            edx = Form1.RotateRight(edx, 0x0F);
            edx += ebx;
            ecx &= edx;
            ecx ^= eax;
            ecx += after_buffer[0x0F];
            esi = ecx + edi + 0x49B40821;
            esi = Form1.RotateRight(esi, 0x0A);
            esi += edx;
            ecx = edx;
            ecx ^= esi;
            ecx &= ebx;
            ecx ^= edx;
            ecx += after_buffer[0x01];
            eax = ecx + eax - 0x09E1DA9E;
            eax = Form1.RotateLeft(eax, 05);
            eax += esi;
            ecx = esi;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= esi;
            ecx += after_buffer[0x06];
            edi = ecx + ebx - 0x3FBF4CC0;
            edi = Form1.RotateLeft(edi, 09);
            edi += eax;
            ecx = edi;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[0x0B];
            edx = ecx + edx + 0x265E5A51;
            edx = Form1.RotateLeft(edx, 0x0E);
            edx += edi;
            ecx = edi;
            ecx ^= edx;
            ecx &= eax;
            ecx ^= edi;
            ecx += after_buffer[0x0];
            esi = ecx + esi - 0x16493856;
            esi = Form1.RotateRight(esi, 0x0C);
            esi += edx;
            ecx = edx;
            ecx ^= esi;
            ecx &= edi;
            ecx ^= edx;
            ecx += after_buffer[0x05];
            eax = ecx + eax - 0x29D0EFA3;
            eax = Form1.RotateLeft(eax, 05);
            eax += esi;
            ecx = esi;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= esi;
            ecx += after_buffer[0x0A];
            edi = ecx + edi + 0x02441453;
            edi = Form1.RotateLeft(edi, 09);
            edi += eax;
            ecx = edi;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[0x0F];
            edx = ecx + edx - 0x275E197F;
            edx = Form1.RotateLeft(edx, 0x0E);
            edx += edi;
            ecx = edi;
            ecx ^= edx;
            ecx &= eax;
            ecx ^= edi;
            ecx += after_buffer[0x04];
            esi = ecx + esi - 0x182C0438;
            esi = Form1.RotateRight(esi, 0x0C);
            esi += edx;
            ecx = edx;
            ecx ^= esi;
            ecx &= edi;
            ecx ^= edx;
            ecx += after_buffer[0x09];
            eax = ecx + eax + 0x21E1CDE6;
            eax = Form1.RotateLeft(eax, 05);
            eax += esi;
            ecx = esi;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= esi;
            ecx += after_buffer[0x0E];
            edi = ecx + edi - 0x3CC8F82A;
            edi = Form1.RotateLeft(edi, 09);
            edi += eax;
            ecx = edi;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[0x03];
            edx = ecx + edx - 0x0B2AF279;
            edx = Form1.RotateLeft(edx, 0x0E);
            edx += edi;
            ecx = edi;
            ecx ^= edx;
            ecx &= eax;
            ecx ^= edi;
            ecx += after_buffer[0x08];
            esi = ecx + esi + 0x455A14ED;
            esi = Form1.RotateRight(esi, 0x0C);
            esi += edx;
            ecx = edx;
            ecx ^= esi;
            ecx &= edi;
            ecx ^= edx;
            ecx += after_buffer[0x0D];
            eax = ecx + eax - 0x561C16FB;
            eax = Form1.RotateLeft(eax, 05);
            eax += esi;
            ecx = esi;
            ecx ^= eax;
            ecx &= edx;
            ecx ^= esi;
            ecx += after_buffer[0x2];
            edi = ecx + edi - 0x03105C08;
            edi = Form1.RotateLeft(edi, 09);
            edi += eax;
            ecx = edi;
            ecx ^= eax;
            ecx &= esi;
            ecx ^= eax;
            ecx += after_buffer[0x07];
            ebx = edi;
            ecx = ecx + edx + 0x676F02D9;
            ecx = Form1.RotateLeft(ecx, 0x0E);
            ecx += edi;
            ebx ^= ecx;
            edx = ebx;
            edx &= eax;
            edx ^= edi;
            edx += after_buffer[0x0C];
            edx = edx + esi - 0x72D5B376;
            edx = Form1.RotateRight(edx, 0x0C);
            edx += ecx;
            ebx ^= edx;
            ebx += after_buffer[0x05];
            esi = ecx;
            esi ^= edx;
            eax = ebx + eax - 0x0005C6BE;
            eax = Form1.RotateLeft(eax, 04);
            eax += edx;
            esi ^= eax;
            esi += after_buffer[0x08];
            edi = esi + edi - 0x788E097F;
            edi = Form1.RotateLeft(edi, 0x0B);
            edi += eax;
            esi = edi;
            esi ^= edx;
            esi ^= eax;
            esi += after_buffer[0x0B];
            ecx = esi + ecx + 0x6D9D6122;
            ecx = Form1.RotateLeft(ecx, 0x10);
            ecx += edi;
            esi = edi;
            esi ^= ecx;
            ebx = esi;
            ebx ^= eax;
            ebx += after_buffer[0x0E];
            edx = ebx + edx - 0x021AC7F4;
            edx = Form1.RotateRight(edx, 09);
            edx += ecx;
            esi ^= edx;
            esi += after_buffer[0x1];
            eax = esi + eax - 0x5B4115BC;
            eax = Form1.RotateLeft(eax, 04);
            eax += edx;
            esi = ecx;
            esi ^= edx;
            esi ^= eax;
            esi += after_buffer[0x04];
            esi = esi + edi + 0x4BDECFA9;
            esi = Form1.RotateLeft(esi, 0x0B);
            esi += eax;
            edi = esi;
            edi ^= edx;
            edi ^= eax;
            edi += after_buffer[0x07];
            ecx = edi + ecx - 0x0944B4A0;
            ecx = Form1.RotateLeft(ecx, 0x10);
            ecx += esi;
            edi = esi;
            edi ^= ecx;
            ebx = edi;
            ebx ^= eax;
            ebx += after_buffer[0x0A];
            edx = ebx + edx - 0x41404390;
            edx = Form1.RotateRight(edx, 09);
            edx += ecx;
            edi ^= edx;
            edi += after_buffer[0x0D];
            eax = edi + eax + 0x289B7EC6;
            eax = Form1.RotateLeft(eax, 04);
            edi = ecx;
            eax += edx;
            edi ^= edx;
            edi ^= eax;
            edi += after_buffer[0x0];
            esi = edi + esi - 0x155ED806;
            esi = Form1.RotateLeft(esi, 0x0B);
            esi += eax;
            edi = esi;
            edi ^= edx;
            edi ^= eax;
            edi += after_buffer[0x03];
            ecx = edi + ecx - 0x2B10CF7B;
            ecx = Form1.RotateLeft(ecx, 0x10);
            ecx += esi;
            edi = esi;
            edi ^= ecx;
            ebx = edi;
            ebx ^= eax;
            ebx += after_buffer[0x06];
            edx = ebx + edx + 0x04881D05;
            edx = Form1.RotateRight(edx, 09);
            edx += ecx;
            edi ^= edx;
            edi += after_buffer[0x09];
            eax = edi + eax - 0x262B2FC7;
            edi = ecx;
            edi ^= edx;
            eax = Form1.RotateLeft(eax, 04);
            eax += edx;
            edi ^= eax;
            edi += after_buffer[0x0C];
            esi = edi + esi - 0x1924661B;
            esi = Form1.RotateLeft(esi, 0x0B);
            esi += eax;
            edi = esi;
            edi ^= edx;
            edi ^= eax;
            edi += after_buffer[0x0F];
            edi = edi + ecx + 0x1FA27CF8;
            edi = Form1.RotateLeft(edi, 0x10);
            edi += esi;
            ecx = esi;
            ecx ^= edi;
            ecx ^= eax;
            ecx += after_buffer[0x2];
            edx = ecx + edx - 0x3B53A99B;
            edx = Form1.RotateRight(edx, 09);
            edx += edi;
            ecx = esi;
            ecx = ~ecx;
            ecx |= edx;
            ecx ^= edi;
            ecx += after_buffer[0x0];
            eax = ecx + eax - 0x0BD6DDBC;
            eax = Form1.RotateLeft(eax, 06);
            eax += edx;
            ecx = edi;
            ecx = ~ecx;
            ecx |= eax;
            ecx ^= edx;
            ecx += after_buffer[0x07];
            esi = ecx + esi + 0x432AFF97;
            esi = Form1.RotateLeft(esi, 0x0A);
            esi += eax;
            ecx = edx;
            ecx = ~ecx;
            ecx |= esi;
            ecx ^= eax;
            ecx += after_buffer[0x0E];
            edi = ecx + edi - 0x546BDC59;
            edi = Form1.RotateLeft(edi, 0x0F);
            edi += esi;
            ecx = eax;
            ecx = ~ecx;
            ecx |= edi;
            ecx ^= esi;
            ecx += after_buffer[0x05];
            edx = ecx + edx - 0x036C5FC7;
            edx = Form1.RotateRight(edx, 0x0B);
            ecx = esi;
            edx += edi;
            ecx = ~ecx;
            ecx |= edx;
            ecx ^= edi;
            ecx += after_buffer[0x0C];
            eax = ecx + eax + 0x655B59C3;
            eax = Form1.RotateLeft(eax, 06);
            eax += edx;
            ecx = edi;
            ecx = ~ecx;
            ecx |= eax;
            ecx ^= edx;
            ecx += after_buffer[0x03];
            esi = ecx + esi - 0x70F3336E;
            esi = Form1.RotateLeft(esi, 0x0A);
            esi += eax;
            ecx = edx;
            ecx = ~ecx;
            ecx |= esi;
            ecx ^= eax;
            ecx += after_buffer[0x0A];
            edi = ecx + edi - 0x00100B83;
            edi = Form1.RotateLeft(edi, 0x0F);
            edi += esi;
            ecx = eax;
            ecx = ~ecx;
            ecx |= edi;
            ecx ^= esi;
            ecx += after_buffer[0x1];
            edx = ecx + edx - 0x7A7BA22F;
            edx = Form1.RotateRight(edx, 0x0B);
            edx += edi;
            ecx = esi;
            ecx = ~ecx;
            ecx |= edx;
            ecx ^= edi;
            ecx += after_buffer[0x08];
            eax = ecx + eax + 0x6FA87E4F;
            eax = Form1.RotateLeft(eax, 06);
            eax += edx;
            ecx = edi;
            ecx = ~ecx;
            ecx |= eax;
            ecx ^= edx;
            ecx += after_buffer[0x0F];
            esi = ecx + esi - 0x01D31920;
            esi = Form1.RotateLeft(esi, 0x0A);
            esi += eax;
            ecx = edx;
            ecx = ~ecx;
            ecx |= esi;
            ecx ^= eax;
            ecx += after_buffer[0x06];
            edi = ecx + edi - 0x5CFEBCEC;
            edi = Form1.RotateLeft(edi, 0x0F);
            edi += esi;
            ecx = eax;
            ecx = ~ecx;
            ecx |= edi;
            ecx ^= esi;
            ecx += after_buffer[0x0D];
            edx = ecx + edx + 0x4E0811A1;
            edx = Form1.RotateRight(edx, 0x0B);
            edx += edi;
            ecx = esi;
            ecx = ~ecx;
            ecx |= edx;
            ecx ^= edi;
            ecx += after_buffer[0x04];
            eax = ecx + eax - 0x08AC817E;
            eax = Form1.RotateLeft(eax, 06);
            eax += edx;
            ecx = edi;
            ecx = ~ecx;
            ecx |= eax;
            ecx ^= edx;
            ecx += after_buffer[0x0B];
            esi = ecx + esi - 0x42C50DCB;
            esi = Form1.RotateLeft(esi, 0x0A);
            ecx = edx;
            ecx = ~ecx;
            esi += eax;
            ecx |= esi;
            ecx ^= eax;
            ecx += after_buffer[0x2];
            edi = ecx + edi + 0x2AD7D2BB;
            //mov ecx = [esp+10] // figure this out......
            ebx = A; // i think this is A
            ebx += eax;
            eax = ~eax;
            edi = Form1.RotateLeft(edi, 0x0F);
            edi += esi;
            eax |= edi;
            eax ^= esi;
            eax += after_buffer[0x09];
            A = ebx; //// is this move back into A?????
            edx = eax + edx - 0x14792C6F;
            eax = C; /// is this move into C???????
            edx = Form1.RotateRight(edx, 0x0B);
            eax += edi;
            edx += ebp;
            edx += edi;
            C = eax; /// mov eax into C?
            eax = D; /// move D into eax???
            eax += esi;
            //pop esi
            //pop ebp
            B = edx; // mov edx into B?
            D = eax; // mov eax into D?
                     //pop ebx
                     //  add esp,0x44 ///change address
                     //ret //end
            /*Form1.A = A;
            Form1.B = B;
            Form1.C = C;
            Form1.D = D; */

        }

    }

}
