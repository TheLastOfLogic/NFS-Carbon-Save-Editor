using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
   
        public static class JDLZ_Removing_Globals
        {
            /*public static UInt32 EAX = 0;
            public static UInt32 EBX = 0; //pointer to Base Hack_Index
            public static UInt32 ECX = 0x8000; //Length of File
            public static UInt32 EDX = 1; //start of Output file Data
            public static UInt32 EBP = 0; //Start Of Output File (Header) JDLZ
            public static UInt32 ESP = 0; //Stack
            public static UInt32 ESI = 0; //JDLZ.Input Data Start
            public static UInt32 EDI = 0x12; //Two Bytes From Output Data?
            public static UInt32 ESP_4 = 0x810;
            public static UInt32 ESP_8 = 0;
            public static UInt32 ESP_C = 0; // Pointer to Outfile Header
            public static UInt32 ESP_10 = 0x0; //Length
            public static UInt32 ESP_14 = 0;
            public static UInt32 ESP_18 = 0;
            public static UInt32 ESP_1C = 0;
            public static UInt32 ESP_20 = 0x11; //Output Data Starts Here
            public static UInt32 ESP_24 = 0x10; //Output Data starts here header included
            public static UInt32 ESP_28 = 0;
            public static UInt32 ESP_2C = 0;
            public static UInt32 ESP_30 = 0;
            public static UInt32 ESP_34 = 0;
            public static UInt32 ESP_38 = 0xFF00;
            public static UInt32 ESP_3C = 0xFF00;
            public static UInt32 ESP_40 = 0;
            public static UInt32 ESP_44 = 0;
            public static UInt32 ESP_48 = 0;
            public static UInt32 ESP_54 = 0x8000; //Length //also known as param 2
            public static UInt32 ESP_58 = 0x0; //param 3 points to Begining of Output file
            public static UInt32 Push_ESI = 0;
            public static UInt32 Push_EDI = 0;
            public static UInt32 Push_EBX = 0;
            public static UInt32 ECX_8 = 0x810; 
            
            
            public static byte[] Output = new byte[0x81000]; */
            //public static byte[] Hash_Table_Addresses = new byte[0x18000];
            //public static byte[] Hash_Index_Table = new byte[0x8100];

            public static void UInt2bytearray(byte[] buffer, int offset, uint value)
            {
                buffer[offset + 0] = (byte)(value & 0xFF);
                buffer[offset + 1] = (byte)((value >> 8) & 0xFF);
                buffer[offset + 2] = (byte)((value >> 16) & 0xFF);
                buffer[offset + 3] = (byte)((value >> 24) & 0xFF);
            }

            public static void Compresser_Call(ref byte[] Input, ref byte[] Hash_Table_Addresses, ref byte[] Hash_Index_Table, ref UInt32 EAX, ref UInt32 EBX, ref UInt32 ECX, ref UInt32 EDX, ref UInt32 EBP, ref UInt32 ESI, ref UInt32 EDI, ref UInt32 Push_ESI, ref UInt32 Push_EDI, ref UInt32 ESP, ref UInt32 ESP_34, ref UInt32 ECX_8, ref UInt32 Push_EBX)
            {

                //0069c370 56
                Push_ESI = ESI;
                Push_EDI = EDI;
                EDI = ESP_34; //counter
                EAX = EDI;

                int eax = (int)EAX;
                int divisor = (int)ECX_8;

                // cdq
                int edx = (eax < 0) ? -1 : 0;

                // idiv (EDX:EAX is the 64-bit signed dividend)
                long dividend = ((long)edx << 32) | (uint)eax;

                int quotient = (int)(dividend / divisor);
                int remainder = (int)(dividend % divisor);

                EAX = (uint)quotient;
                EDX = (uint)remainder;
                //ESP_C = EDX;
                ESI = 0x0; //points to Base Hash Index Table
                EDX <<= 4;
                EAX = BitConverter.ToUInt32(Hash_Index_Table, (int)(EDX + ESI + 4)); //ESI is = Base. EDI = Position Plus 4 or 1. 1 only for our uint
                EDX += ESI;
                if (EAX == 0)
                {
                    goto LAB_0069c3d9;
                }

                EAX = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 0xC); //i believe this is taking the address from edx+C is point to the 0x10 table
            EAX %= 0x810;   
            if (EAX == 0 || EAX == 0xFFFFFFFF)
                {
                    goto LAB_0069c398;
                }

                //this never gets tocuhed in real x86
                ESI = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 0x8); ////i believe this is taking the address from edx+8 is point to the 0x10 table
                UInt2bytearray(Hash_Index_Table, (int)EAX + 0x8, ESI);

            LAB_0069c398:
                {
                    //jmp
                }
                EAX = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 0x8); ////i believe this is taking the address from edx+8 is point to the 0x10 table
                if (EAX == 0)
                {
                    goto LAB_0069c3a5;
                }

                ESI = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 0xC); ////i believe this is taking the address from edx+C is point to the 0x10 table
                if (0xFFFFFFFF == ESI)
                {
                    ESI = 0;
                }
                if ((EAX / 0x8100) > 0)
                {
                    EAX -= ((EAX / 0x8100) * 0x8100);
                }
                UInt2bytearray(Hash_Index_Table, (int)EAX + 0xC, (uint)ESI);
            //File.WriteAllBytes(Path.Combine(Form1.path + "1"), Hash_Index_Table);

            LAB_0069c3a5:
                {
                    //jmp
                }
                if (BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 4) == 0xFFFFFFFF)
                {
                    ESI = 0;
                }
                else
                {
                    ESI = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 4); //////i believe this is taking the address from edx+4 is point to the 0x10 table
                }
                EAX = Input[ESI + 2];
                EAX <<= 4;

                Push_EBX = EBX;
                EBX = Input[ESI + 1];
                ESI = Input[ESI];
                EAX ^= EBX;
                EAX <<= 4;
                EAX ^= ESI;
                ESI = 0; //[ECX+1] //4 bytes this is a pointer to the base of the hash Table.

                EAX = unchecked((uint)((int)EAX * 0xFFFFFE5F));
                EAX &= 0x1FFF;
                uint temp_eax = EAX;
                EAX = BitConverter.ToUInt32(Hash_Table_Addresses, (int)(ESI + EAX * 4)); //ESI is 0 as this is the base of the hash table
                EBX = Push_EBX;
                if (((EAX >> 4) % 0x810) != (EDX >> 4))
                {
                    goto LAB_0069c3d9;
                }
                ESI = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 0xC);
                UInt2bytearray(Hash_Table_Addresses, (int)temp_eax * 4, ESI);

            LAB_0069c3d9:
                {
                    //jmp
                }
                ESI = ESP_34; //currently points to the most recent place the Input address was. eg the begining or further down the line based on timing

                //ESI++;

                //EDI++;
                if (ESP_34 == 0)
                {
                    UInt2bytearray(Hash_Index_Table, (int)EDX + 4, 0XFFFFFFFF); //seems ESI is just setting the Input position
                    UInt2bytearray(Hash_Index_Table, (int)EDX, 0xFFFFFFFF);
                }
                else
                {
                    UInt2bytearray(Hash_Index_Table, (int)EDX + 4, ESI); //seems ESI is just setting the Input position
                    UInt2bytearray(Hash_Index_Table, (int)EDX, EDI);
                    //File.WriteAllBytes(Path.Combine(Form1.path + "1"), Hash_Index_Table);
                }
                EAX = Input[ESI + 2];
                EDI = Input[ESI + 1];
                ESI = Input[ESI];
                EAX <<= 4;
                EAX ^= EDI;
                EAX <<= 4;
                EAX ^= ESI;
                EAX = unchecked((uint)((int)EAX * 0xFFFFFE5F));
                UInt2bytearray(Hash_Index_Table, (int)EDX + 0x8, 0); //part of the table 0x10 length which are each 4 bytes in length
                ESI = 0x0;//[ECX + 1];// 4 bytes this sets up the Base for Hash_Table Addresses which in our array will be 0
                EAX &= 0x1FFF;
                ESI = BitConverter.ToUInt32(Hash_Table_Addresses, (int)(ESI + EAX * 4));
                UInt2bytearray(Hash_Index_Table, (int)EDX + 0xC, ESI);
                //File.WriteAllBytes(Path.Combine(Form1.path + "1"), Hash_Index_Table);
                ECX = 0x0; //[//ECX + 1]; 4 bytes this sets up the Base for Hash_Table Addresses which in our array will be 0
                uint beta_EDX = EDX;
                //try EDX == 0 or if fails then do if (ESP_34 == 0)
                if (ESP_34 == 0)
                {

                    UInt2bytearray(Hash_Table_Addresses, (int)(ECX + EAX * 4), 0xFFFFFFFF);
                }
                else
                {
                    if ((ESP_34 / 0x810) > 0)
                    {
                        EDX = 0x810 * (ESP_34 / 0x810);
                        EDX <<= 4;
                        EDX += beta_EDX;
                        beta_EDX = EDX;
                    }
                    UInt2bytearray(Hash_Table_Addresses, (int)(ECX + EAX * 4), EDX);
                    if ((EDX / 0x8100) > 0)
                    {

                        EDX -= ((EDX / 0x8100) * 0x8100);
                    }
                }


                EAX = BitConverter.ToUInt32(Hash_Index_Table, (int)(EDX + 0xC));
                EDI = Push_EDI;
                ESI = Push_ESI;
                if (EAX == 0)
                {
                    return;
                }
                else if (EAX == 0xFFFFFFFF)
                {
                    EAX = 0;
                }
                else if ((EAX / 0x8100) > 0)
                {

                    EAX -= ((EAX / 0x8100) * 0x8100);
                }
                //EDX is a problem as it always will be a 0 which is not right.
                EDX = beta_EDX;

                UInt2bytearray(Hash_Index_Table, (int)((EAX) + 8), EDX);


                //byte[] temp = new byte[Hash_Index_Table.Length];
                //Buffer.BlockCopy(Hash_Index_Table, 0, temp, 0, Hash_Index_Table.Length);
                //File.WriteAllBytes(Path.Combine(Form1.path + "5"), JDLZ.Output);
                //File.WriteAllBytes(Path.Combine(Form1.path + "1"), Hash_Index_Table);
                return;


            }

            public static byte[] Compresser(byte[] Input,bool Xbox)
            {
            
            byte[] Output = new byte[Input.Length+0x100];
            UInt32 EAX = 0;
            UInt32 EBX = 0; //pointer to Base Hack_Index
            UInt32 ECX = (uint)Input.Length; //Length of File
            UInt32 EDX = 1; //start of Output file Data
            UInt32 EBP = 0; //Start Of Output File (Header) JDLZ
            UInt32 ESP = 0; //Stack
            UInt32 ESI = 0; //Input Data Start
            UInt32 EDI = 0x12; //Two Bytes From Output Data?
            UInt32 ESP_4 = 0x810;
            UInt32 ESP_8 = 0;
            UInt32 ESP_C = 0; // Pointer to Outfile Header
            UInt32 ESP_10 = 0x0; //Length
            UInt32 ESP_14 = 0;
            UInt32 ESP_18 = 0;
            UInt32 ESP_1C = 0;
            UInt32 ESP_20 = 0x11; //Output Data Starts Here
            UInt32 ESP_24 = 0x10; //Output Data starts here header included
            UInt32 ESP_28 = 0;
            UInt32 ESP_2C = 0;
            UInt32 ESP_30 = 0;
            UInt32 ESP_34 = 0;
            UInt32 ESP_38 = 0xFF00;
            UInt32 ESP_3C = 0xFF00;
            UInt32 ESP_40 = 0;
            UInt32 ESP_44 = 0;
            UInt32 ESP_48 = 0;
            UInt32 ESP_54 = (uint)Input.Length; //Length //also known as param 2
            UInt32 ESP_58 = 0x0; //param 3 points to Begining of Output file
            UInt32 Push_ESI = 0;
            UInt32 Push_EDI = 0;
            UInt32 Push_EBX = 0;
            UInt32 ECX_8 = 0x810;
            byte[] Hash_Table_Addresses = new byte[0x18000];
            byte[] Hash_Index_Table = new byte[0x8100];
            byte[] Length = BitConverter.GetBytes(Input.Length);
            Array.Resize(ref Input, Input.Length + 3);
            if (Xbox == true)
                {//endianess is big
                    Output[0] = 0x5A; //5A 4C 44 4A 02 10 00 00
                    Output[1] = 0x4C;
                    Output[2] = 0x44;
                    Output[3] = 0x4A;
                    Output[8] = Length[3];
                    Output[9] = Length[2];
                    Output[10] = Length[1];
                    Output[11] = Length[0];
                }
                else
                {
                    Output[0] = 0x4A; //5A 4C 44 4A 02 10 00 00
                    Output[1] = 0x44;
                    Output[2] = 0x4C;
                    Output[3] = 0x5A;
                    Output[8] = Length[0];
                    Output[9] = Length[1];
                    Output[10] = Length[2];
                    Output[11] = Length[3];

                }
                Output[4] = 0x02;
                Output[5] = 0x10;
                Output[6] = 0x00;
                Output[7] = 0x00;



                goto LAB_006aa4f0;
            LAB_006aa4e6:
                {
                    //jmp
                }
                ECX = ESP_54; //param2
                EAX ^= EAX;
                ESP = ESP;
            LAB_006aa4f0:
                {
                    //jmp
                }
                ESP_30 = 0x1002; //esp+1C

                if (ECX >= 0x1002)
                {
                    goto LAB_006aa504;
                }
                ESP_30 = ECX; //esp+1C

            LAB_006aa504:
                {
                    //jmp
                }
                ECX = Input[ESI + 2];
                EDX = Input[ESI + 1];
                ECX <<= 4;
                ECX ^= EDX;
                EDX = Input[ESI];
                ECX <<= 4;
                ECX ^= EDX;
                ECX = unchecked((uint)((int)ECX * 0xFFFFFE5F));
                ECX &= 0x1FFF;
                EDX = BitConverter.ToUInt32(Hash_Table_Addresses, (int)(EBX + ECX * 4)); //ebx shoukd be 0 as this is the base
                EBX = 2;
                ESP_28 = EDX; //esp+24
                ESP_2C = EBX; //esp+20
                ESP_1C = EAX; //esp+30
                if (EDX == EAX)
                {
                    goto LAB_006aa677;
                }
            LAB_006aa541:
                {
                    //jmp
                    if (EDX == 0xFFFFFFFF)
                    {
                        EDX = 0;
                    }
                }
                if (EBX >= 0x1002)
                {
                    goto LAB_006aa5dd;
                }
                EAX = ESP_30; //esp+1C
                if ((EDX / 0x8100) > 0)
                {
                    EDX -= ((EDX / 0x8100) * 0x8100);
                }
                if ((BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 4)) == 0xFFFFFFFF)
                {
                    EBP = 0; //EDX is the address placed in the hash table and points to a location on the other table that is 0x10 in entry length
                }
                else
                {
                    EBP = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 4); //EDX is the address placed in the hash table and points to a location on the other table that is 0x10 in entry length

                }
                ECX ^= ECX;
                if (EAX <= 3)
                {
                    goto LAB_006aa584;
                }
                EDX = 3;
                EBP -= ESI;
                EAX = ESI;
                EDX -= ESI;
            LAB_006aa566:
                {
                    //jmp
                }
                EBX = BitConverter.ToUInt32(Input, (int)(EAX + EBP));
                if (EBX != BitConverter.ToUInt32(Input, (int)EAX))
                {
                    goto LAB_006aa57c;
                }
                EAX += 4;
                EBX = EDX + EAX;
                ECX += 4;
                if (EBX < ESP_30) //ESP+1C should be 0x1002
                {
                    goto LAB_006aa566;
                }
            LAB_006aa57c:
                {
                    //jmp
                }
                EBX = ESP_2C; //mov ebx, dword ptr ss:[esp+20]
                EDX = ESP_28; //mov edx, dword ptr ss:[esp+21] has the pointer to point to a pointer address which points to EDX which if you remember points to the 0x10 structure.
            LAB_006aa584:
                {
                    //jmp
                }
                if (ECX >= ESP_30)
                {
                    goto LAB_006aa5a7;
                }
                if (EDX == 0xFFFFFFFF)
                {
                    EDX = 0;
                }
                if ((EDX / 0x8100) > 0)
                {
                    EDX -= ((EDX / 0x8100) * 0x8100);
                }
                if (BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 4) == 0xFFFFFFFF)
                {
                    EBP = 0;
                }
                else
                {
                    EBP = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 4); //this it looks like points to Input address
                }
                EAX = ECX + ESI; //so this is adding a pointer together (Leads to Input bufffer)
                EBP -= ESI;
            LAB_006aa592:
                {
                    //jmp
                }
                EBX = (EBX & 0xFFFFFF00) | Input[EAX + EBP];
                if ((byte)EBX != Input[EAX])
                {
                    goto LAB_006aa5a3;
                }
                EBX = ESP_30; //mov ebx,dword ptr ss: [esp+1C]

                ECX++; //ECX is wrong first its 0x8 when the first hit is 0x4
                EAX++; //EAX is wrong first hit is 0x17 and our first hit is 0x1F
                if (ECX < EBX)
                {
                    goto LAB_006aa592;
                }
            LAB_006aa5a3:
                {
                    //jmp
                }
                EBX = ESP_2C; //mov ebx,dword ptr ss: [esp+20] esp+20 is a pointer, however we may have the value arlready stored in the esp_20
            LAB_006aa5a7:
                {
                    //jmp
                }
                if (ECX <= EBX)
                {
                    goto LAB_006aa5ca;
                }
                if (ECX <= 0x22)
                {
                    goto LAB_006aa5c0;
                }
                EAX = ESP_34; //mov eax,dword ptr ss: [esp+12]
                if ((EDX / 0x8100) > 0)
                {
                    EDX -= ((EDX / 0x8100) * 0x8100);
                }
                if (BitConverter.ToUInt32(Hash_Index_Table, (int)EDX) == 0xFFFFFFFF)
                {
                    EAX -= 0;
                }
                else
                {
                    EAX -= BitConverter.ToUInt32(Hash_Index_Table, (int)EDX); //sub eax, dword ptr ds:[edx] edx is a pointer to the table in 0x10 length so we effectively are taking that value, and subtracting it from EAX
                }

                if (EAX < 0x10)
                {
                    goto LAB_006aa5c0;
                }

                if (EBX > 0x22)
                {
                    goto LAB_006aa5ca;
                }
            LAB_006aa5c0:
                {
                    //jmp
                }
                EBX = ECX;
                ESP_2C = EBX;
                ESP_1C = EDX; //EDX pointer to index of 0x10
            LAB_006aa5ca:
                {
                    //jmp
                }
                if ((EDX / 0x8100) > 0)
                {
                    EDX -= ((EDX / 0x8100) * 0x8100);
                }
                EDX = BitConverter.ToUInt32(Hash_Index_Table, (int)EDX + 0xC); //Pointer to 0x10 Table? //mov edx,dword ptr ds: [edx+C]

                EBP = ESP_58; //param3 //pointer to top of Output file
                ESP_28 = EDX; //store pointer to 0x10 table here
                if (EDX != 0)
                {
                    goto LAB_006aa541;
                }

            LAB_006aa5dd:
                {
                    //jmp
                }
                if (EBX <= 0x2)
                {
                    goto LAB_006aa677;
                }
                ECX = ESP_1C; //pointer to EDX placement of 0x10 index (ECX is Correct) esp+30
                EAX = ESP_34; //esp + 18 //holds upwards counter
            if ((ECX / 0x8100) > 0)
            {
                ECX -= ((ECX / 0x8100) * 0x8100);
            }
            if (BitConverter.ToUInt32(Hash_Index_Table, (int)ECX) == 0xFFFFFFFF)
                {
                    EDX = 0;
                }
                else
                {
                    EDX = BitConverter.ToUInt32(Hash_Index_Table, (int)ECX); // ECX points to 0x10 Table;
                }
                ESP_3C = (ushort)(ESP_3C >> 1); //esp+10
                EAX -= EDX;
                EAX--;
                if (EAX < 0x10)
                {
                    goto LAB_006aa62e;
                }
                if (EBX <= 0x22)
                {
                    goto LAB_006aa607;
                }

                EBX = 0x22;

            LAB_006aa607:
                {
                    //jmp
                }
                EDX = ESP_38; //esp+14
                EDX >>= 1;
                EDX &= 0x7F7F;
                ECX = EAX - 0x10;
                ESP_38 = EDX;
                ECX = (uint)((int)ECX >> 3);
                EDX = (EDX & 0xFFFFFF00) | (byte)EBX;
                ECX = (ECX & 0xFFFFFF00) | (byte)(ECX & 0xE0);
                //ECX &= 0xFFFFFFE0;
                EDX = (EDX & 0xFFFFFF00) | (byte)(EDX - 3);
                ECX = (ECX & 0xFFFFFF00) | (byte)((byte)ECX | (byte)EDX);

                EAX = (EAX & 0xFFFFFF00) | (byte)(EAX - 0x10);
                Output[EDI + 1] = (byte)EAX;
                goto LAB_006aa646;

            LAB_006aa62e:
                {
                    //jmp
                }
                ESP_38 >>= 1;
                ECX = EBX - 3;
                ECX = (uint)((int)ECX >> 4);
                ECX = (ECX & 0xFFFFFF00) | (byte)(ECX & 0xF0);
                EDX = (EDX & 0xFFFFFF00) | (byte)EBX;

                ECX = (ECX & 0xFFFFFF00) | (byte)((byte)ECX | (byte)EAX);
                EDX = (EDX & 0xFFFFFF00) | (byte)(EDX - 3);
                Output[EDI + 1] = (byte)EDX;

            LAB_006aa646:
                {
                    //jmp
                }
                EAX = ESP_54; //Bytes Left Count
                Output[EDI] = (byte)ECX;
                EDI += 2;
                EAX -= EBX;
                ESP_54 = EAX; //bytes Left Count

            LAB_006aa655:
                {
                    //jmp
                }
                EAX = ESP_34; //esp+18 Bytes Processed (going up)
                              //push eax
                              //push esi
                              //ECX += ECX;
                ECX = 0; //pointer to index with 0x10 in length
                if (ESP_34 >= 0x810)
                {
                    //MessageBox.Show(ESP_34.ToString("X2"));
                }
                Compresser_Call(ref Input, ref Hash_Table_Addresses, ref Hash_Index_Table, ref EAX, ref EBX, ref ECX, ref EDX, ref EBP, ref ESI, ref EDI, ref Push_ESI, ref Push_EDI, ref ESP, ref ESP_34, ref ECX_8, ref Push_EBX);

                ECX = ESP_34; //esp+18
                ESI++;
                ECX++;
                EBX--;
                ESP_34 = ECX; //esp+18
                if (EBX != 0)
                {
                    goto LAB_006aa655;
                }
                EBX = ESP_54; //param 2 bytes left to process
                goto LAB_006aa6ae;
            LAB_006aa677:
                {
                    //jmp
                }
                ECX = ESP_34; //esp+18

                //push ecx
                //push esi
                ECX = 0x0; //esp+34 holds pointee to index 0x10 position 0 out of 0x10
                if (ESP_34 >= 0x810)
                {
                    //MessageBox.Show(ESP_34.ToString("X2"));
                }
                Compresser_Call(ref Input, ref Hash_Table_Addresses, ref Hash_Index_Table, ref EAX, ref EBX, ref ECX, ref EDX, ref EBP, ref ESI, ref EDI, ref Push_ESI, ref Push_EDI, ref ESP, ref ESP_34, ref ECX_8, ref Push_EBX);
                EDX = (EDX & 0xFFFFFF00) | (byte)(Input[ESI]);
                EAX = ESP_3C; //esp+10 now isn't just esp+10 as it shifted, and this points to the first bitflag
                ECX = ESP_34; //esp+18 counter?
                EBX = ESP_54; //param2
                EAX >>= 1;
                EDI++;
                Output[EDI - 1] = (byte)EDX;
                EAX &= 0x7F7F;
                ESI++;
                ECX++;
                EBX--;
                ESP_3C = EAX; //esp+10
                ESP_34 = ECX; //esp+18
                ESP_54 = EBX; //param2
            LAB_006aa6ae:
                {
                    //jmp
                }
                EAX = 0x100;
                if (ESP_3C >= (ushort)EAX) //esp+10
                {
                    goto LAB_006aa6d1;
                }

                ECX = (ECX & 0xFFFFFF00) | (ESP_3C & 0XFF); //esp+10
                EDX = ESP_24; //esp+28 pointer to Output
                ESP_24 = EDI; //esp+28 set pointer to esp+28 to point to Output
                Output[EDX] = (byte)ECX;
                ESP_3C = 0xFF00; //esp+10 //bit flag
                EDI++;
            LAB_006aa6d1:
                {
                    //jmp
                }

                if (ESP_38 >= (ushort)EAX) //esp+14
                {
                    goto LAB_006aa6ef;
                }
                EAX = (EAX & 0xFFFFFF00) | (ESP_38 & 0xFF); //esp+14
                ECX = ESP_20; //esp+2C pointer to Output
                ESP_20 = EDI; //esp+2C EDI sets pointer to Output here
                Output[ECX] = (byte)EAX;
                ESP_38 = 0xFF00; //esp+14 //bit flag
                EDI++;

            LAB_006aa6ef:
                {
                    //jmp
                }
                EAX = ESP_18; //esp+34 //upwards counter
                EAX++;
                ESP_18 = EAX; //esp+34
                //if ((EAX & 0x1FFF) != 0)
                //{
                    goto LAB_006aa71a;
                ///}
                EAX = EBX + EBX * 4;
                EAX <<= 1;

               
                ECX = 0x0A;
                ECX -= EAX;


                if (ECX == ESP_14)
                {
                    goto LAB_006aa71a;
                }
                ESP_14 = ECX;

            LAB_006aa71a:
                {
                    //jmp
                }
                

                if ((int)EBX >= 0)
                {
                    EBX = ESP_8; //set base pointer to hash table
                    goto LAB_006aa4e6;
                }
                EBX = ESP_8; //set base pointer to hash table
                ESI = ESP_C;
                ECX = ESP_3C;
                EAX = 0xFF00;


                if ((ECX & EAX) == 0)
                {
                    goto LAB_006aa74b;
                }
                goto LAB_006aa740;


            LAB_006aa740:
                {
                    //jmp
                }
                ESP_3C = (ushort)(ESP_3C >> 1);
                if ((ESP_3C & EAX) != 0)
                {
                    goto LAB_006aa740;
                }

            LAB_006aa74b:
                {
                    //jmp
                }
                ECX = ESP_24;
                EDX = (EDX & 0xFFFFFF00) | (byte)(ESP_3C & 0xFF);

                Output[ECX] = (byte)EDX;


                if ((ESP_38 & EAX) == 0)
                {
                    goto LAB_006aa76b;
                }
                goto LAB_006aa760;

            LAB_006aa760:
                {
                    //jmp
                }
                ESP_38 >>= 1;
                if ((ESP_38 & EAX) != 0)
                {
                    goto LAB_006aa760;
                }

            LAB_006aa76b:
                {
                    //jmp
                }
                EDX = (EDX & 0xFFFFFF00) | (byte)ESP_38;
                EAX = ESP_20;
                Output[EAX] = (byte)EDX;
                EDI -= EBP;
                if (Xbox == true)
                {
                    Output[EBP + 0x0C + 0] = (byte)(EDI >> 24);
                    Output[EBP + 0x0C + 1] = (byte)(EDI >> 16);
                    Output[EBP + 0x0C + 2] = (byte)(EDI >> 8);
                    Output[EBP + 0x0C + 3] = (byte)(EDI);

                }
                else
                {
                    Output[EBP + 0x0C + 0] = (byte)(EDI);
                    Output[EBP + 0x0C + 1] = (byte)(EDI >> 8);
                    Output[EBP + 0x0C + 2] = (byte)(EDI >> 16);
                    Output[EBP + 0x0C + 3] = (byte)(EDI >> 24);
                }
                Array.Resize(ref Output, (int)EDI);
                return Output;

                
            }


        public static byte[] decompress(byte[] input, bool Xbox)
        {
            try 
            {
                int flags1 = 1, flags2 = 1;
                int t, length;
                int inPos = 16, outPos = 0;

                if ((input[0] != 'J' || input[1] != 'D' || input[2] != 'L' || input[3] != 'Z' || input[4] != 0x02) && (input[0] != 'Z' || input[1] != 'L' || input[2] != 'D' || input[3] != 'J' || input[4] != 0x02))
                {
                    throw new InvalidDataException("Input not JDLZ!");
                }



                // TODO: Can we always trust the header's stated length?
                byte[] output;
                if (Xbox != true)
                {
                    output = new byte[(input[11] << 24) + (input[10] << 16) + (input[9] << 8) + input[8]];
                }
                else
                {
                    output = new byte[(input[8] << 24) + (input[9] << 16) + (input[10] << 8) + input[11]];
                }

                while ((inPos < input.Length) && (outPos < output.Length))
                {
                    if (flags1 == 1)
                    {
                        flags1 = input[inPos++] | 0x100;
                    }
                    if (flags2 == 1)
                    {
                        flags2 = input[inPos++] | 0x100;
                    }

                    if ((flags1 & 1) == 1)
                    {
                        if ((flags2 & 1) == 1) // 3 to 4098(?) iterations, backtracks 1 to 16(?) bytes
                        {
                            // length max is 4098(?) (0x1002), assuming input[inPos] and input[inPos + 1] are both 0xFF
                            length = (input[inPos + 1] | ((input[inPos] & 0xF0) << 4)) + 3;
                            // t max is 16(?) (0x10), assuming input[inPos] is 0xFF
                            t = (input[inPos] & 0x0F) + 1;
                        }
                        else // 3(?) to 34(?) iterations, backtracks 17(?) to 2064(?) bytes
                        {
                            // t max is 2064(?) (0x810), assuming input[inPos] and input[inPos + 1] are both 0xFF
                            t = (input[inPos + 1] | ((input[inPos] & 0xE0) << 3)) + 17;
                            // length max is 34(?) (0x22), assuming input[inPos] is 0xFF
                            length = (input[inPos] & 0x1F) + 3;
                        }

                        inPos += 2;

                        for (int i = 0; i < length; ++i)
                        {
                            output[outPos + i] = output[outPos + i - t];
                        }

                        outPos += length;
                        flags2 >>= 1;
                    }
                    else
                    {
                        if (outPos < output.Length)
                        {
                            output[outPos++] = input[inPos++];
                        }
                    }
                    flags1 >>= 1;
                }
                return output;
            }
            catch
            {
                MessageBox.Show("Unabled To Find JDLZ Data");
                return null;
            }
            }



    }
    }
