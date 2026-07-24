using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher
{
    internal class Platform_Car_Converter
    {

        public static Int32 Pos;


        public static Int32 Find_Game_Pos(byte[] Data, bool Xbox)
        {
            const UInt32 Length = 0x656D6147;
            for (int i = 0x0; i < Data.Length - 4; i += 4)
            {
                if (Length == Helper_Functions.ReadInt32(Data, i, Xbox))
                {
                    return i;
                }
            }
            return 0x7FFFFFFF;
        }
        public static Int32 Find_Car_Strct_Pos(byte[] Data, bool Xbox)
        {
            const UInt32 Length = 0x00023FA4;
            for (int i = 0x0; i < Data.Length - 4; i += 4)
            {
                if (Length == Helper_Functions.ReadInt32(Data, i, Xbox))
                {
                    return i;
                }
            }
            return 0x7FFFFFFF;
        }


        public static void Copy_Vehicles(byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));

            Save_Game_Structure.Car[] Car = new Save_Game_Structure.Car[200];
            for (int p = 0, count = 0xC; p < 200; p++, count += 0x14)
            {
                Helper_Functions.WriteUInt32(Data, Pos + count, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 4, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 4, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 8, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 8, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0xC, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xC, Xbox_1), Xbox);
                Data[Pos + count + 0x10] = Data_1[Pos_1 + count + 0x10];
                Data[Pos + count + 0x11] = Data_1[Pos_1 + count + 0x11];
                if (Xbox == true)
                {
                    Helper_Functions.WriteUInt16(Data, Pos + count + 0x12, 0xAAAA, Xbox);
                }
                else
                {
                    Helper_Functions.WriteUInt16(Data, Pos + count + 0x12, 0x0000, Xbox);
                }
            }
        }


        public static void Copy_Custimizations(byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));
            Pos += 0xFAC;
            Pos_1 += 0xFAC;
            byte[] Custom_1;
            for (int p = 0, count = 0x0; p < 75; p++, count += 0x470)
            {
                Helper_Functions.WriteUInt16(Data, Pos + count, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 4, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 4, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x8, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x8, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0xC, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xC, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x10, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x10, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x14, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x14, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x18, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x18, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x1C, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x1C, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x20, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x20, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x24, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x24, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x28, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x28, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x2C, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x2C, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x30, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x30, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x34, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x34, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x38, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x38, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x3C, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x3C, Xbox_1), Xbox);
                if (Xbox == true)
                {
                    Array.Fill(Data, (byte)0xAA, (Pos + count + 0x40), 0x1C);
                }
                else
                {
                    Array.Fill(Data, (byte)0x00, (Pos + count + 0x40), 0x1C);
                }
                Array.Fill(Data, (byte)0x00, (Pos + count + 0x5C), 0x58);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0xB4, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xB4, Xbox_1), Xbox);
                Data[Pos + count + 0xB8] = Data_1[Pos_1 + count + 0xB8];
                if (Xbox == true)
                {
                    Array.Fill(Data, (byte)0xAA, (Pos + count + 0xB9), 0x3);
                }
                else
                {
                    Array.Fill(Data, (byte)0x00, (Pos + count + 0xB9), 0x3);
                }
                if (Xbox == true && Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xBC, Xbox_1) == 0x00000000)
                {
                    Array.Fill(Data, (byte)0xAA, (Pos + count + 0xBC), 0x4);
                }
                else if (Xbox != true && Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xBC, Xbox_1) == 0xAAAAAAAA)
                {
                    Array.Fill(Data, (byte)0x00, (Pos + count + 0xBC), 0x4);
                }
                else
                {
                    Helper_Functions.WriteUInt32(Data, Pos + count + 0xBC, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xBC, Xbox_1), Xbox);
                }
                Helper_Functions.WriteUInt16(Data, Pos + count + 0xC0, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0xC0, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0xC2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0xC2, Xbox_1), Xbox);
                Data[Pos + count + 0xC4] = Data_1[Pos_1 + count + 0xC4];
                Data[Pos + count + 0xC5] = Data_1[Pos_1 + count + 0xC5];
                Helper_Functions.WriteUInt16(Data, Pos + count + 0xC6, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0xC6, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0xC8, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0xC8, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0xCA, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0xCA, Xbox_1), Xbox);

                int counter = 0xCC;
                for (int r = 0; r < 9; r++)
                {
                    for (int i = 0; i < 11; i++, counter += 4)
                    {

                        Helper_Functions.WriteUInt32(Data, Pos + count + counter, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + counter, Xbox_1), Xbox);
                    }
                }

                Array.Fill(Data, (byte)0x00, (Pos + count + 0x258), 0x210);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0x468, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0x468, Xbox_1), Xbox);
                //filler
                Data[Pos + count + 0x46C] = 0x00;
                if (Xbox == true)
                {

                    Array.Fill(Data, (byte)0xAA, (Pos + count + 0x46D), 0x3);
                }
                else
                {
                    Array.Fill(Data, (byte)0x00, (Pos + count + 0x46D), 0x3);
                }

            }
        }

        public static void Copy_Convert_Garage(byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));
            Pos += 0x15C7C;
            Pos_1 += 0x15C7C;
            for (int p = 0, count = 0x0; p < 0x208; p += 34, count += 0x34)
            {
                Data[Pos + count] = Data_1[Pos_1 + count + 0x0];
                if (Xbox == true)
                {
                    Data[Pos + count + 0x1] = 0xAA;
                }
                else
                {
                    Data[Pos + count + 0x1] = 0x00;
                }
                Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x2];
                Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x3];
                Data[Pos + count + 0x4] = Data_1[Pos_1 + count + 0x4];
                Data[Pos + count + 0x5] = Data_1[Pos_1 + count + 0x5];
                if (Xbox == true)
                {
                    Data[Pos + count + 0x6] = 0xAA;
                    Data[Pos + count + 0x7] = 0xAA;
                }
                else
                {
                    Data[Pos + count + 0x6] = 0x00;
                    Data[Pos + count + 0x7] = 0x00;
                }
                Helper_Functions.WriteUInt32(Data, Pos + count + 8, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 8, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, Pos + count + 0xC, Helper_Functions.ReadUInt32(Data_1, Pos_1 + count + 0xC, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x10, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x10, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x12, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x12, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x14, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x14, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x16, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x16, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x18, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x18, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x1A, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x1A, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x1C, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x1C, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x1E, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x1E, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x20, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x20, Xbox_1), Xbox);
                Array.Fill(Data, (byte)0x00, Pos + count + 0x22, 0x12);
            }
        }


        public static void Covert_Parts_List(byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));
            Pos += 0x15E84;
            Pos_1 += 0x15E84;

            //0x9470;
            for (int p = 0, count = 0x0; p < 0x4A38; p += 2, count += 0x4)
            {
                if (Xbox != Xbox_1)
                {
                    if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0xFFFF) && (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0x7FFF && Xbox_1 == true))
                    {
                        if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) & 0x8000) == 0x8000)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) ^ 0x8000), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) * 2) + 1), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, (ushort)Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                        }
                        else
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) * 2) + 1), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) * 2) + 1), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, (ushort)Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                        }
                    }

                    else if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0xFFFF) && (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0xFFFE && Xbox_1 == false))
                    {

                        if ((Data_1[Pos_1 + count] & 0x01) == 0x01)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) - 1) / 2) | 0x8000), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                        }
                        else if ((Data_1[Pos_1 + count] & 0x01) == 0x00)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) / 2), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                        }
                    }
                    else if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0xFFFE || (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0xFFFF || Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0x7FFF || Xbox_1 == true && Xbox == false))
                    {
                        if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0xFFFF)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, 0xFFFF, Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, 0xFFFF, Xbox);
                        }
                        else if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0x7FFF)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, 0xFFFE, Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, 0xFFFF, Xbox);
                        }
                        else if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0xFFFE)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, 0x7FFF, Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, 0xFFFF, Xbox);
                        }
                    }
                }
                else
                {
                    Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1), Xbox);
                    Helper_Functions.WriteUInt16(Data, Pos + count + 2, (ushort)Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                }

            }
        }

        public static void Copy_Convert_Parts_List(byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));
            Pos += 0x15E84;
            Pos_1 += 0x15E84;

            //0x9470;
            for (int p = 0, count = 0x0; p < 0x4A38; p+=2, count += 0x4)
            {
                if (Xbox == true)
                {
                    if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0xFFFE && Xbox_1 == false)
                    {
                        if ((Data_1[Pos_1 + count] & 0x01) == 0x01)
                            {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) - 1) / 2) | 0x8000), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                        }
                        else if ((Data_1[Pos_1 + count] & 0x01) != 0x01)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) / 2), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                        }
                    }
                    else if (Xbox_1 == true && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) == 0xFFFE)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count, 0xFFFF, Xbox);
                        Helper_Functions.WriteUInt16(Data, Pos + count + 2, 0xFFFF, Xbox);
                    }
                    else if (Xbox_1 == true && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0xFFFE)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count, (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1)), Xbox);
                        Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                    }
                    

                    
                }
                else
                {
                    if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0xFFFF && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) != 0x7FFF && Xbox_1 == true)
                    {
                        if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) & 0x8000) == 0x8000)
                        {
                            //Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) , Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) ^ 0x8000) * 2) + 1), Xbox);
                        }
                        else
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1) * 2), Xbox);
                        }

                            Helper_Functions.WriteUInt16(Data, Pos + count + 2, (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1)), Xbox);
                    }
                    else if (Xbox_1 == false)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count, (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1)), Xbox);
                        Helper_Functions.WriteUInt16(Data, Pos + count + 2, (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1)), Xbox);
                    }
                    else
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count, 0xFFFE, Xbox);
                        Helper_Functions.WriteUInt16(Data, Pos + count + 2, 0xFFFF, Xbox);
                    }

                }
            }
        }


        /*public static void Convert_Vinyl(ref byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));
            Pos += 0x1F2F4;
            Pos_1 += 0x1F2F4;
            for (int p = 0, count = 0x0; p < 0x2BC; p++, count += 0x1C)
            {
                //Helper_Functions.WriteUInt16(Data, Pos + count, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1), Xbox);
                //Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x2, Xbox_1), Xbox);
                //Helper_Functions.WriteUInt16(Data, Pos + count + 4, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x4, Xbox_1), Xbox);
                if (Xbox != Xbox_1)
                {
                    Data[Pos + count + 0x1] = Data_1[Pos_1 + count + 0x0];
                    Data[Pos + count + 0x0] = Data_1[Pos_1 + count + 0x1];
                    Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x2];
                    Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x3];
                }
                else
                {
                    Data[Pos + count + 0x0] = Data_1[Pos_1 + count + 0x0];
                    Data[Pos + count + 0x1] = Data_1[Pos_1 + count + 0x1];
                    Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x2];
                    Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x3];
                }
                Data[Pos + count + 0x4] = Data_1[Pos_1 + count + 0x4];
                Data[Pos + count + 0x5] = Data_1[Pos_1 + count + 0x5];
                Data[Pos + count + 0x6] = Data_1[Pos_1 + count + 0x6];
                Data[Pos + count + 0x7] = Data_1[Pos_1 + count + 0x7];
                // Helper_Functions.WriteUInt16(Data, Pos + count + 0x6, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x6, Xbox_1), Xbox);
                if (Xbox != Xbox_1)
                {

                    if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) != 0x7FFF || Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) != 0xFFFE)
                    {
                        if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) & 0x8000) == 0x8000 && Xbox_1)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) ^ 0x8000) * 2) | 1), Xbox);
                        }
                        else if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) & 0x8000) == 0 && Xbox_1)
                            {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) * 2) | 1), Xbox);
                        }
                        else if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) & 0x0001) == 0 && Xbox_1)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) / 2), Xbox);
                        }
                        else if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) & 0x0001) == 0x0001 && Xbox_1)
                        {

                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) ^ 1) / 2) | 0x8000), Xbox);
                        }

                    }
                    else if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) == 0xFFFE)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, 0x7FFF, Xbox);
                    }
                    else if (Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) == 0x7FFF)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, 0xFFFE, Xbox);
                    }
                }
                else
                {
                    Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1), Xbox);

                }

                Helper_Functions.WriteUInt16(Data, Pos + count + 0x0a, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x0a, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x0c, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x0c, Xbox_1), Xbox);
                Data[Pos + count + 0x0E] = Data_1[Pos_1 + count + 0x0E];
                Data[Pos + count + 0x0F] = Data_1[Pos_1 + count + 0x0F];

                Helper_Functions.WriteUInt16(Data, Pos + count + 0x10, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x10, Xbox_1), Xbox);
                Data[Pos + count + 0x12] = Data_1[Pos_1 + count + 0x12];
                Data[Pos + count + 0x13] = Data_1[Pos_1 + count + 0x13];
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x14, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x14, Xbox_1), Xbox);
                Data[Pos + count + 0x16] = Data_1[Pos_1 + count + 0x16];
                Data[Pos + count + 0x17] = Data_1[Pos_1 + count + 0x17];
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x18, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x18, Xbox_1), Xbox);
                Data[Pos + count + 0x1A] = Data_1[Pos_1 + count + 0x1A];
                Data[Pos + count + 0x1B] = Data_1[Pos_1 + count + 0x1B];
            }
            
        }
        
       
        
        
            /*else
            {
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) * 2), Xbox);
            } */


        public static void Copy_Convert_Vinyls(ref byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = Find_Car_Strct_Pos(Data, Xbox);
            int Pos_1 = Find_Car_Strct_Pos(Data_1, Xbox_1);

            Pos += 0x1F2F4;
            Pos_1 += 0x1F2F4;

            for (int p = 0, count = 0x0; p < 0x2BC; p++, count += 0x1C)
            {
                // --- Offsets 0x00 - 0x03 ---
                if (Xbox != Xbox_1)
                {
                    Data[Pos + count + 0x1] = Data_1[Pos_1 + count + 0x0];
                    Data[Pos + count + 0x0] = Data_1[Pos_1 + count + 0x1];
                    Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x2];
                    Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x3];
                }
                else
                {
                    Data[Pos + count + 0x0] = Data_1[Pos_1 + count + 0x0];
                    Data[Pos + count + 0x1] = Data_1[Pos_1 + count + 0x1];
                    Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x2];
                    Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x3];
                }

                // --- Offsets 0x04 - 0x07 ---
                Data[Pos + count + 0x04] = Data_1[Pos_1 + count + 0x04];
                Data[Pos + count + 0x05] = Data_1[Pos_1 + count + 0x05];
                Data[Pos + count + 0x06] = Data_1[Pos_1 + count + 0x06];
                Data[Pos + count + 0x07] = Data_1[Pos_1 + count + 0x07];

                // --- Offset 0x08: 2-byte Vinyl ID & Toggle Conversion ---
                if (Xbox != Xbox_1)
                {
                    // Endian-safe read into local variable
                    ushort sourceId = Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1);

                    if (Xbox == true) // Converting from PC to Xbox 360
                    {
                        if (sourceId == 0xFFFE)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, 0x7FFF, Xbox);
                        }
                        else if ((sourceId & 0x01) == 0x01) // PC uses lowest bit
                        {
                            ushort converted = (ushort)(((sourceId ^ 1) / 2) | 0x8000);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, converted, Xbox);
                        }
                        else
                        {
                            ushort converted = (ushort)(sourceId / 2);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, converted, Xbox);
                        }
                    }
                    else // Converting from Xbox 360 to PC
                    {
                        if (sourceId == 0x7FFF)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, 0xFFFE, Xbox);
                        }
                        else if ((sourceId & 0x8000) == 0x8000) // Xbox 360 uses highest bit
                        {
                            ushort converted = (ushort)(((sourceId ^ 0x8000) * 2) + 1);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, converted, Xbox);
                        }
                        else
                        {
                            ushort converted = (ushort)(sourceId * 2);
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, converted, Xbox);
                        }
                    }
                }
                else
                {
                    // Same platform, direct copy via Helper
                    Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1), Xbox);
                }

                // --- Offsets 0x0A - 0x1B ---
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x0a, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x0a, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x0c, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x0c, Xbox_1), Xbox);

                Data[Pos + count + 0x0E] = Data_1[Pos_1 + count + 0x0E];
                Data[Pos + count + 0x0F] = Data_1[Pos_1 + count + 0x0F];

                Helper_Functions.WriteUInt16(Data, Pos + count + 0x10, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x10, Xbox_1), Xbox);

                Data[Pos + count + 0x12] = Data_1[Pos_1 + count + 0x12];
                Data[Pos + count + 0x13] = Data_1[Pos_1 + count + 0x13];

                Helper_Functions.WriteUInt16(Data, Pos + count + 0x14, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x14, Xbox_1), Xbox);

                Data[Pos + count + 0x16] = Data_1[Pos_1 + count + 0x16];
                Data[Pos + count + 0x17] = Data_1[Pos_1 + count + 0x17];

                Helper_Functions.WriteUInt16(Data, Pos + count + 0x18, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x18, Xbox_1), Xbox);

                Data[Pos + count + 0x1A] = Data_1[Pos_1 + count + 0x1A];
                Data[Pos + count + 0x1B] = Data_1[Pos_1 + count + 0x1B];
            }
        }


        /*public static void Copy_Convert_Vinyls(ref byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            int Pos = (Find_Car_Strct_Pos(Data, Xbox));
            int Pos_1 = (Find_Car_Strct_Pos(Data_1, Xbox_1));
            Pos += 0x1F2F4;
            Pos_1 += 0x1F2F4;
            for (int p = 0, count = 0x0; p < 0x2BC; p++, count += 0x1C)
            {
                //Helper_Functions.WriteUInt16(Data, Pos + count, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count, Xbox_1), Xbox);
                //Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x2, Xbox_1), Xbox);
                //Helper_Functions.WriteUInt16(Data, Pos + count + 4, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x4, Xbox_1), Xbox);
                if (Xbox != Xbox_1)
                {
                    Data[Pos + count + 0x1] = Data_1[Pos_1 + count + 0x0];
                    Data[Pos + count + 0x0] = Data_1[Pos_1 + count + 0x1];
                    Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x2];
                    Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x3];
                }
                else
                {
                    Data[Pos + count + 0x0] = Data_1[Pos_1 + count + 0x0];
                    Data[Pos + count + 0x1] = Data_1[Pos_1 + count + 0x1];
                    Data[Pos + count + 0x2] = Data_1[Pos_1 + count + 0x2];
                    Data[Pos + count + 0x3] = Data_1[Pos_1 + count + 0x3];
                }
                Data[Pos + count + 0x4] = Data_1[Pos_1 + count + 0x4];
                Data[Pos + count + 0x5] = Data_1[Pos_1 + count + 0x5];
                Data[Pos + count + 0x6] = Data_1[Pos_1 + count + 0x6];
                Data[Pos + count + 0x7] = Data_1[Pos_1 + count + 0x7];
                // Helper_Functions.WriteUInt16(Data, Pos + count + 0x6, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x6, Xbox_1), Xbox);
                if (Xbox != Xbox_1)
                {
                    if (Xbox == false && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) != 0x7FFF)
                    {

                        if ((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) & 0x8000) == 0x8000)
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) ^ 0x8000) * 2) + 1), Xbox);
                        }
                        else
                        {
                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) * 2), Xbox);
                        }

                    }

                    else if (Xbox == false && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) == 0x7FFF)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, 0xFFFE, Xbox);
                    }
                     if (Xbox == true && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) != 0xFFFE)
                    {
                        if ((Data[Pos + count + 0x8] & 0x01) == 0x01)
                        {

                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(((Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) ^ 1) / 2) | 0x8000), Xbox);

                        }
                        else if ((Data[Pos + count + 0x8] & 0x01) == 0x00)
                        {

                            Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, (ushort)(Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1) / 2), Xbox);

                        }

                    }
                    else if (Xbox == true && Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 8, Xbox_1) == 0xFFFE)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, 0x7FFF, Xbox);
                    }
                }
                else
                {
                    Helper_Functions.WriteUInt16(Data, Pos + count + 0x8, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x8, Xbox_1), Xbox);

                }

                Helper_Functions.WriteUInt16(Data, Pos + count + 0x0a, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x0a, Xbox_1), Xbox);
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x0c, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x0c, Xbox_1), Xbox);
                Data[Pos + count + 0x0E] = Data_1[Pos_1 + count + 0x0E];
                Data[Pos + count + 0x0F] = Data_1[Pos_1 + count + 0x0F];
                
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x10, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x10, Xbox_1), Xbox);
                Data[Pos + count + 0x12] = Data_1[Pos_1 + count + 0x12];
                Data[Pos + count + 0x13] = Data_1[Pos_1 + count + 0x13];
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x14, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x14, Xbox_1), Xbox);
                Data[Pos + count + 0x16] = Data_1[Pos_1 + count + 0x16];
                Data[Pos + count + 0x17] = Data_1[Pos_1 + count + 0x17];
                Helper_Functions.WriteUInt16(Data, Pos + count + 0x18, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x18, Xbox_1), Xbox);
                Data[Pos + count + 0x1A] = Data_1[Pos_1 + count + 0x1A];
                Data[Pos + count + 0x1B] = Data_1[Pos_1 + count + 0x1B];
                //Helper_Functions.WriteUInt16(Data, Pos + count + 0x1C, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 0x1C, Xbox_1), Xbox);





            }
        } */
        public static Int32 Read_Car_Table_Legnth(byte[] Plateform_Data_1, byte[] Plateform_Data_2, bool Xbox)
        {
            
            Pos = Find_Car_Strct_Pos(Plateform_Data_1, Xbox);
            if (Pos != 0x7FFFFFFF)
            {

                bool Xbox_360 = Save_Form.Xbox_360;
                if (Save_Form.Xbox_360)
                {
                    if (Helper_Functions.ReadInt32(Plateform_Data_1, Pos, Xbox_360) == (Helper_Functions.ReadInt32(Plateform_Data_2, Pos + 0x30, Xbox_360)))
                    {

                    }
                }
                else
                {
                    if (Helper_Functions.ReadInt32(Plateform_Data_1, Pos, Xbox_360) == (Helper_Functions.ReadInt32(Plateform_Data_2, Pos - 0x30, Xbox_360)))
                    {

                    }
                }
                return 0;
            }
            return 0;
        }
    }
}
