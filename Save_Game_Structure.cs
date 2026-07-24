using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    internal class Save_Game_Structure
    {


        public void Game_Block()
        {

        }
        public static void Preset_Cars()
        {
            //darious supra color  blue 1C 6D 1C 47 00 05
            /*
             * Xbox 360 Darius Supra Parts
            00 00 9D 1C 00 01 9D 1D 00 02 9D 23 00 03 9D 24 00 04 9D 25 00 05 9D 26 00 06 9D 27 00 07 9D 28 00 08 9D 2A 00 09 9D 2B 00 0A 9D 2C 00 0B 9D 2F 00 0C 9D 31 00 0D 9D 32 00 0E 9D 33 00 0F 9D 34 00 10 9D 35 00 11 9D 36 00 12 9D 38 00 13 9D 39 00 14 9D 3A 00 15 9D 3D 00 16 9D 3F 00 17 9D 40 00 18 9D 41 00 1B BD 0C 00 25 C2 DA 00 2C 9D 44 00 1C 9D 45 00 1D 9D 5A 00 1E 9D 6F 00 1F 9D 84 00 20 9D 99 00 21 9D AE 00 26 9D C4 00 24 9D CF FF FF 9D D8 00 29 9D E3 00 23 9D EB 00 27 BC 5A 00 2A 9D F2 00 19 9E 11 00 1A 9E 1F 00 2B 9E 26 00 2D CC 1B 00 28 BB 1A 00 2E 9E 2E 00 2F 9E 2F 00 30 9E 30 00 31 9C 15 00 32 9C 46 00 33 1C 4D 00 34 9C A7 00 35 A6 64 00 22 FF FF
            */

        }
        public static string[] Crew_Members = { "characters/neville", "characters/sal", "characters/nikki", "characters/colin", "characters/samson", "characters/yumi" };


        //at the beging of the same from start to the end of car structure we can find the actual car structure labeled here at 0x20 onn xbox 360

        //Fun Fact the length of this structure can be found at literally 0x30 at the begining of the file right after 0xAAAAAAAA like every other structure from here out
        public struct Game_Career_Data
        {

        }
        //fun fact right before we start the structure, we can read 0x1004F to see this specific structure is B4 which is 0xB40 or B4 * 0x10

        public struct Race_ID_Scoring
        {
            public UInt32 Race_ID;
            public UInt32 Status_Flags;
            public UInt32 Score_1;
            public UInt32 Score_2;
        }

        //Fun Fact Car Stucture has a literal Length found at //0x10B94 which is 4 bytes in length and it starts the strucutre at  on 0x10BA0
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x14)]
        public struct Car
        {
            public UInt32 ID;
            public UInt32 Front_End_Car_ID;
            public UInt32 Car_Model;
            public UInt32 Flags; //eg flag 1 0x4 on pc is my cars 2 is career mode needs to be set in garage as well, 1 is shop
            //flag 2 set to 1 makes price of car $0 i think flag 3 is tuner,muscle,exodic, bonus or custom flag 4 is unknown
            public byte Customization_Slot_Number;
            public byte Career_Slot;
            public UInt16 filler; //AAAA on xbox 360 //PC 0000
        }

        //each fo these are 0x470 in length total length is 14CD0 0x470*0x4B


        //fun fact, you can take pc part id/ 2 and you should get the Xbox 360 id
        //so its pc value (pc_v - 1) / 2 = xbox 360 part id


        public struct Custimization_1
        {
            public UInt16 Parts_ID_Pointer;     //Custimization 2 link id is the first 2 FFFF of this seqeance like 0102FFFF for the exampble. used like (0201*4)+Base_Address
            public UInt16 Vinyl_Pointer;        //set this to point to Vinyl Slot for this car. // lets say 0x0005 slot which is 0x1C * 5. 00 is slot number 1
            public UInt32 Tires_Upgrade; //0x04
            public UInt32 Tires_Slider; //0x08                       sliders work like this centre is == 0 left is 1,4,0x10 vs right side is 2,8,0x20. if it only has 1 slot its either 0x15 or 0x2A (Tires Drift or Grip)
            public UInt32 Brakes_Upgrade; //0x0C
            public UInt32 Brakes_Slider; //0x10
            public UInt32 Suspention_Upgrade; //after position 0x14
            public UInt32 Suspention_Slider; //0x18
            public UInt32 Transmission_Upgrade; //after position 0x1C
            public UInt32 Transmission_Slider; //0x20
            public UInt32 Engine_Upgrade; //0x24 After Position
            public UInt32 Engine_Slider; //0x28
            public UInt32 Turbo_Supercharger_Upgrade; //0x2C
            public UInt32 Turbo_Sliders; //0x30
            public UInt32 Nos_Upgrade; //0x34
            public UInt32 Nos_Slider; //0x38
            public UInt32 Parts_Purchased; //0x3C
            public byte[] AA; //AA over 0x1C Length
            public byte[] Zeors; //0x59 in length. starts right after AA
            public UInt32 Car_Slot_ID;
            public byte[] AA_3; //0xAA 3 pairs
            public UInt32 Unknown;
            public UInt16 Paint_1;
            public UInt16 Paint_2;
            public UInt16 Paint_3;
            public UInt16 Wheel_Paint_1;
            public UInt16 Wheel_Paint_2;
            public UInt16 Zero;
            public float[] Front_End_Auto_Sculpt; //0x2C nine slots or 0x2C 4*9 == 0x2C
            public float[] Read_End_Auto_Sculpt; //0x2C
            public float[] Side_Scirt; //0x2C
            public float[] Wheels_Auto_sculpt; // 0x2C
            public float[] Hood_Auto_Sculpt; //0x2C
            public float[] Spoiler_AS; //0x2C
            public float[] Roof_Scoop_AS; //0x2C
            public float[] Roof_Chop; //0x2C
            public float[] Exhaust_Tips_AS; //2C
            public byte[] padding; //0x210 fill with 00's
            public float Ride_Height; //only 4 bytes
            public UInt32 Filler; //00AAAAAA


        }

        //each slot is 0x34 there are 0xC slots available
        public struct Garage_Slots
        {
            byte Career_Car_ID;
            byte Zero;
            byte Max_Strikes;
            byte Strikes_On;
            UInt32 Filler; //0x00000000
            float Heat_Level;
            UInt64 AA; //there will be 0xAAAAAAAAAAAAAAAA
            byte[] Fill; //Fill in With 0's 0X20 Length
        }
        //also known as custisation
        public static UInt16[] Parts_Section = new UInt16[0x4A38];


        //visuals 0x1C each in Length with a total of 0x4C90
        public struct Vinyl_Slots
        {
            UInt64 Move_Scale_Rotate_Scale; //Leave at 0
            UInt16 Vinyl_ID;
            UInt16 Next_Link; //0xFFFF if only using one
            UInt16 Fill_1; //0x7FFF
            UInt16 Fill_2; //0000
            UInt16 Stroke_1;
            UInt16 Stroke_2;
            UInt16 Inner_Shadow_1;
            UInt16 Inner_Shadow_2;
            UInt16 Inner_Glow_1;
            UInt16 Inner_Glow_2;
        }
        //leaving 0x2C left of all zeros exept the last 3 bytes on Xbox 360 being 0xAAAAAA



        

        //0x26a18 or 0x26A48
        public static void Part_Chain_Reader(byte[] Data, int Base_Address,ushort currentLink)
        {
            
            int count = 0x15E54;
            UInt16 Part_ID;

            // 1. Calculate the actual memory address: (Link * 4) + Base
            int currentAddress = (currentLink * 4) + Base_Address;

            // 2. Read the Next Link (which is at Address + 2)
            // We use our Big Endian helper here
            ushort nextLink = Helper_Functions.ReadUInt16(Data, currentAddress + 2, Save_Form.Xbox_360);
            Custimization_1 c = new Custimization_1();
            //UInt16 Part_ID = Helper_Functions.ReadUInt16(Data, currentAddress, Save_Form.Xbox_360);
            while (nextLink != 0xFFFF)
            {
                // Move to the next link's address
                currentAddress = (nextLink * 4) + Base_Address;

                // Read the link for the next iteration
                nextLink = Helper_Functions.ReadUInt16(Data, currentAddress + 2, Save_Form.Xbox_360);

                count++;

                // Safety break for infinite loops
                if (count > 1000) break;
            }

            //MessageBox.Show("Chain Length: " + count.ToString("X2"));
        }

        public static Car[] Get_Part_Chain_From_Car(byte[] Data, int Pos, bool BE)
        {
            //0x10BA0
            Car[] car = new Car[200];
            for (int Count = 0, i = 0; i < 200; i++, Count += 0x14)
            {
                car[i].ID = Helper_Functions.ReadUInt32(Data, Pos + Count, Save_Form.Xbox_360);
                car[i].Front_End_Car_ID = Helper_Functions.ReadUInt32(Data, Pos + Count + 4, Save_Form.Xbox_360);
                car[i].Car_Model = Helper_Functions.ReadUInt32(Data, Pos + Count + 8, Save_Form.Xbox_360);
                car[i].Flags = Helper_Functions.ReadUInt32(Data, Pos + Count + 0xC, Save_Form.Xbox_360);
                car[i].Customization_Slot_Number = Data[Pos + Count + 0x10];
                car[i].Career_Slot = Data[Pos + Count + 0x11];
                if (BE == true)
                {
                    car[i].filler = 0xAAAA;
                }
                else
                {
                    car[i].filler = 0x0000;
                }
                
            }
            return car;

        }

        public static void Fill_Customization_Slot(byte[] Data, int Pos, bool Xbox)
        {
            Car[] cars = Get_Part_Chain_From_Car(Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data,Xbox), Xbox);
            Custimization_1[] custom1 = new Custimization_1[75];
            Pos += 0xFA0;
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].ID != 0xFFFFFFFF && cars[i].Customization_Slot_Number != 0xFF)
                {

                    //custom1[p].Parts_ID_Pointer = Helper_Functions.ReadUInt16(Data, Base_Address + cars[i].Customization_Slot_Number, Save_Form.Xbox_360);
                    Part_Chain_Reader(Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data,Save_Form.Xbox_360), Helper_Functions.ReadUInt16(Data, Pos + (cars[i].Customization_Slot_Number * 0x470), Save_Form.Xbox_360));

                }
            }
        }

        public static void Insert_Racer(ref byte[] Data, Int32 Slot_Car_ID,Int32 Pos, byte Type, byte Area, byte Custumization_Link, byte C_Garage, string Car_Vault, bool Xbox)
        {
           Helper_Functions.WriteUInt32(Data, Pos, (UInt32)Slot_Car_ID, Xbox);
           Helper_Functions.WriteUInt32(Data, Pos + 4, Helper_Functions.VLT_Hash(Car_Vault), Xbox);
           Helper_Functions.WriteUInt32(Data, Pos + 8, Helper_Functions.VLT_Hash(Car_Vault), Xbox);

            //so this section is 2 bytes each not 4 individual bytes
            
            Data[Pos + 0x10] = Custumization_Link;
            Data[Pos + 0x11] = C_Garage;
            if (Xbox)
            {
                Helper_Functions.WriteUInt16(Data, Pos + 0xC, (ushort)(0x0000 | Type), Xbox);
                // Data[Pos + 0XC] = 0; //leave at zero
                //Data[Pos + 0xD] = 0xF; //type of car, mainly used for career mode. tuner, muscle, exotic
                Helper_Functions.WriteUInt16(Data, Pos + 0xE, (ushort)(0x0000 | Area), Xbox);
               /* Data[Pos + 0xE] = 0x0; //Free Car if toggled to 1?
                Data[Pos + 0xF] = Area; // Shop, Career (Not Garage Yet), My Cars, Bonus Cars, and so on 0x80 is Crew Member */
                Helper_Functions.WriteUInt16(Data, Pos + 0x12, 0xAAAA, Xbox);
            }
            else
            {
                Helper_Functions.WriteUInt16(Data, Pos + 0xC, (ushort)(0x0000 | Area), Xbox);
                //Data[Pos + 0XC] = 0; //leave at zero
                //Data[Pos + 0xD] = 0xF; //type of car, mainly used for career mode. tuner, muscle, exotic
                Helper_Functions.WriteUInt16(Data, Pos + 0xE, (ushort)(0x0000 | Type), Xbox);
                //Data[Pos + 0xE] = 0x0; //Free Car if toggled to 1?
                //Data[Pos + 0xF] = Area; // Shop, Career (Not Garage Yet), My Cars, Bonus Cars, and so on 0x80 is Crew Member
                Helper_Functions.WriteUInt16(Data, Pos + 0x12, 0x0000, Xbox);
            }

                

            //Custimize Slot Number, Garage Slot Number, and Null Terminator 0xAAAA OR 0x0000 for vanilla PC, Nothing Changed. Currently with changed Game is 0xEEEE
        }

        public static byte Find_Custimization_Slot(ref byte[] Data, Int32 Base_Pos, Byte Preset_Index, bool Xbox)
        {
            for (int p = 0, count = 0x0; p < 74; p++, count += 0x470)
            {
                if (Helper_Functions.ReadUInt32(Data, (Base_Pos + count), Save_Form.Xbox_360) == 0xFFFFFFFF)
                {
                    switch (Preset_Index)
                    {
                        case 0:
                            {
                               
                                for (int i = 0; i < Preset_Car_Parts.Red_Kenji_Stats_Custimization_Slot.Length - 1; i++)
                                {
                                    Data[Base_Pos + count+i] = Preset_Car_Parts.Red_Kenji_Stats_Custimization_Slot[i];
                                }
                                Helper_Functions.WriteUInt16(Data, Base_Pos + count+2, Find_Vinyl_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Xbox), Preset_Car_Parts.Red_Kenji), Save_Form.Xbox_360);
                                Data[Base_Pos + count + 0xB8] = (byte)p;
                                Helper_Functions.WriteUInt16(Data,Base_Pos + count, Find_Part_Chain_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Xbox) + 0x15E84, Preset_Car_Parts.Red_Kenji_Parts_List),Save_Form.Xbox_360);
                                break;
                            }
                        case 1:
                            {
                                for (int i = 0; i < Preset_Car_Parts.Red_Wolf_Stats_Custimization_Slot.Length - 1; i++)
                                {
                                    Data[Base_Pos + count + i] = Preset_Car_Parts.Red_Wolf_Stats_Custimization_Slot[i];
                                }
                                Helper_Functions.WriteUInt16(Data, Base_Pos + count + 2, Find_Vinyl_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Xbox), Preset_Car_Parts.Red_Wolf), Save_Form.Xbox_360);
                                Data[Base_Pos + count + 0xB8] = (byte)p;
                                Helper_Functions.WriteUInt16(Data, Base_Pos + count, Find_Part_Chain_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Xbox) + 0x15E84, Preset_Car_Parts.Red_Wolf_Parts_List), Save_Form.Xbox_360);
                                break;
                            }
                        case 2:
                            {
                                for (int i = 0; i < Preset_Car_Parts.Red_Angie_Stats_Custimization_Slot.Length - 1; i++)
                                {
                                    Data[Base_Pos + count + i] = Preset_Car_Parts.Red_Angie_Stats_Custimization_Slot[i];
                                }
                                Helper_Functions.WriteUInt16(Data, Base_Pos + count + 2, Find_Vinyl_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Xbox), Preset_Car_Parts.Red_Angie), Save_Form.Xbox_360);
                                Data[Base_Pos + count + 0xB8] = (byte)p;
                                Helper_Functions.WriteUInt16(Data, Base_Pos + count, Find_Part_Chain_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Xbox) + 0x15E84, Preset_Car_Parts.Red_Angie_Parts_List), Save_Form.Xbox_360);
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        case 4:
                            {
                                break;
                            }
                        case 5:
                            {
                                break;
                            }
                        case 6:
                            {
                                break;
                            }
                        case 7:
                            {
                                break;
                            }
                        case 8:
                            {
                                break;
                            }
                        case 9:
                            {
                                break;
                            }
                        case 10:
                            {
                                break;
                            }
                    
                    }
                    MessageBox.Show(p.ToString());
                    //so for this function, we are going to be literally taking the Custimization from memory and coping it here (which is already predetermaned for the preset)
                    //except for the first 4 bytes as its part link, and vinyl link
                    //Insert_Racer(ref Data, Base_Pos + count, 4);
                    return (byte)p;
                }
                
            }
            return 0xFF;
        }

        private static UInt16 Find_Empty_Part_Position(byte[] Data, int Base_Pos)
        {
            for (ushort i = 0; i < 0x9470; i += 4)
            {
                if (Helper_Functions.ReadUInt16(Data, i + Base_Pos + 0x15E84, Save_Form.Xbox_360) == 0x7FFF || Helper_Functions.ReadUInt16(Data, i + Base_Pos + 0x15E84, Save_Form.Xbox_360) == 0xFFFF)
                {
                    return (ushort)(i);
                }
                else if (Helper_Functions.ReadUInt16(Data, i + Base_Pos, Save_Form.Xbox_360) == 0xFEFF)
                {
                    return (ushort)(i);
                }
            }
            return 0;
        }


       
        public static UInt16 Find_Part_Chain_Slot(ref byte[] Data, int Base_Pos, ushort[] Preset_Car_Parts)
        {
            //0x9470/4 = 0x251C
            ushort Slot_Part_Position;
            ushort Pos = 0;
            //we have to grab the address here, and put into our customization slot.
            Pos = Find_Empty_Part_Position(Data, Base_Pos);
            Slot_Part_Position = Pos;
            for (ushort i = 0; i < Preset_Car_Parts.Length - 2; i++)
            {
                    Helper_Functions.WriteUInt16(Data, Pos + Base_Pos, Preset_Car_Parts[i], Save_Form.Xbox_360);
                    Helper_Functions.WriteUInt16(Data, Pos + Base_Pos + 2, (ushort)(Pos/4+1), Save_Form.Xbox_360);
                    Pos = Find_Empty_Part_Position(Data, Base_Pos);               
            }
            Helper_Functions.WriteUInt16(Data, Pos + Base_Pos, Preset_Car_Parts[Preset_Car_Parts.Length-1], Save_Form.Xbox_360);
            return (ushort)(Slot_Part_Position / 4);
        }


        public static void Carrer_Converter(ref byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {

            int Pos = MD5_Prep.Find_Game(Data);
            for (int i = Pos; i < Pos + 0x1F0; i += 0x10)
            {
                if (Helper_Functions.ReadUInt32(Data, i, Xbox) == 0x033FA23A)
                {
                    Pos = i;
                    break;
                }
            }
            int Pos_1 = MD5_Prep.Find_Game(Data_1);
            for (int i = Pos_1; i < Pos_1 + 0x1F0; i += 0x10)
            {
                if (Helper_Functions.ReadUInt32(Data_1, i, Xbox_1) == 0x033FA23A)
                {
                    Pos_1 = i;
                    break;
                }
            }
            for (int i = Pos, i_1 = Pos_1; i < Pos + 0x1F0; i += 4)
            {
                Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
            }
            Pos += 0x1F4 + 0x3C;
            Pos_1 += 0x1F4 + 0x3C;
            Helper_Functions.WriteUInt32(Data, Pos, Helper_Functions.ReadUInt32(Data_1, Pos_1, Xbox_1), Xbox);
            Pos += 4;
            Pos_1 += 4;
            for (int i = Pos; i < Pos + 0x50; i += 2)
            {
                Helper_Functions.WriteUInt16(Data, i, Helper_Functions.ReadUInt16(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
            }
            Pos += 0x50;
            Pos_1 += 0x50;
            for (int i = Pos; i < Pos + 0x20; i += 4)
            {
                Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
            }
            Pos += 0x20;
            Pos_1 += 0x20;
            Data[Pos + 0xC] = Data_1[Pos_1 + 0xC];
            Data[Pos + 0xD] = Data_1[Pos_1 + 0xD];
            Data[Pos + 0xE] = Data_1[Pos_1 + 0xE];
            Data[Pos + 0xF] = Data_1[Pos_1 + 0xF];
            Pos += 0x10;
            Pos_1 += 0x10;
            Data[Pos] = Data_1[Pos_1];
            Data[Pos + 0x1] = Data_1[Pos_1 + 0x1];
            Data[Pos + 0x2] = Data_1[Pos_1 + 0x2];
            Data[Pos + 0x3] = Data_1[Pos_1 + 0x3];
            Helper_Functions.WriteUInt32(Data, Pos + 4, Helper_Functions.ReadUInt32(Data_1, Pos_1 + 4, Xbox_1), Xbox);
            Helper_Functions.WriteUInt32(Data, Pos + 8, Helper_Functions.ReadUInt32(Data_1, Pos_1 + 8, Xbox_1), Xbox);
            Helper_Functions.WriteUInt32(Data, Pos + 0xC, Helper_Functions.ReadUInt32(Data_1, Pos_1 + 0xC, Xbox_1), Xbox);
            Pos += 0x10;
            Pos_1 += 0x10;
            for (int i = Pos; i < Pos + 0x378; i += 0xC)
            {
                Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 4, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 4, Xbox_1), Xbox);
                Data[i + 8] = Data_1[(i - Pos) + Pos_1 + 8];
            }
            Pos += 0x37C;
            Pos_1 += 0x37C;
            for (int i = Pos; i < Pos + 0x170; i += 0x10)
            {
                Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 4, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 4, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 8, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 8, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 0xC, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 0xC, Xbox_1), Xbox);
            }
            Pos += 0x160;
            Pos_1 += 0x160;
            for (int i = Pos; i < Pos + 0x50; i += 0x14)
            {
                Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 4, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 4, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 8, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 8, Xbox_1), Xbox);
                Helper_Functions.WriteUInt32(Data, i + 0xC, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1 + 0xC, Xbox_1), Xbox);
                Data[i + 0xD] = Data_1[(i - Pos) + Pos_1 + 0xD];
                Data[i + 0xE] = Data_1[(i - Pos) + Pos_1 + 0xE];
                Data[i + 0xF] = Data_1[(i - Pos) + Pos_1 + 0xF];
                Data[i + 0x10] = Data_1[(i - Pos) + Pos_1 + 0x10];
            }
            Pos += 0x50;
            Pos_1 += 0x50;
            for (int i = Pos; i < Pos + 0x78; i+=4)
            {
                Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
            }
            Pos = MD5_Prep.Find_Game(Data);
            Pos_1 = MD5_Prep.Find_Game(Data_1);
            Pos += 0x10004;
            Pos_1 += 0x10004;
            uint count;
            count = Helper_Functions.ReadUInt32(Data, Pos, Xbox);
            count *= 0x10;
            for (int i = Pos; i < Pos + count + 4; i += 4)
            {
                if (Helper_Functions.ReadUInt32(Data_1, i + 4, Xbox_1) != 0x00023FA4 && Helper_Functions.ReadUInt32(Data, i + 4, Xbox) != 0x00023FA4)
                {
                    Helper_Functions.WriteUInt32(Data, i, Helper_Functions.ReadUInt32(Data_1, (i - Pos) + Pos_1, Xbox_1), Xbox);
                }
                else
                {
                    break;
                }
            }
        

        }

        public static void Unlock_Entire_Map(ref byte[] Data, bool Xbox)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            bool Get_out = false;
            while ((Data[Pos] != 0xBC) || (Data[Pos + 2] != 0x09))
            {
                Pos += 0x10;
                if (Pos > 0x10000)
                {
                    Get_out = true;
                    break;
                }
            }
            Data[Pos + 6] |= 8; //unlock upper areaa without races
            if (Get_out == false)
            {
                Pos += 0x10;
                byte Max_length = 0x49;
                byte Count = 0;
                Pos += 0x10;
                for (int i = 0; Count < Max_length; i += 0xC)
                {
                    Data[Pos + 0x8 + i] = 0x60;
                    Count++;
                }
            }
            Pos = MD5_Prep.Find_Game(Data);
            Pos += 0x9B8;

            Helper_Functions.WriteUInt32(Data, Pos, 0xC49D46EF, Xbox);

        }

        public static void Unlock_Mazda_Dealership(ref byte[] Data, bool Xbox)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0x033FA23A)
            {
                Pos += 0x10;
            }
            Pos += 0x7F8;

            Helper_Functions.WriteUInt32(Data, Pos-8, 0xC49D46EF, Xbox); //Kenji WareHouse
            Helper_Functions.WriteUInt32(Data, Pos-4, 0xC49D46EF, Xbox); //Kenji Carlot
            Helper_Functions.WriteUInt32(Data, Pos, 0xC49D46EF, Xbox); //Mazda Dealership
           Helper_Functions.WriteUInt32(Data, Pos+4, 0xC49D46EF, Xbox); //Mazda WareHouse // Doesn't exist
            //Helper_Functions.WriteUInt32(Data, Pos + 8, 0xC49D46EF, Xbox); //Angie WareHouse
            Helper_Functions.WriteUInt32(Data, Pos + 0xC, 0xC49D46EF, Xbox); //Angie Carlot
            Helper_Functions.WriteUInt32(Data, Pos + 0x10, 0xC49D46EF, Xbox); //Wolf WareHouse
            Helper_Functions.WriteUInt32(Data, Pos + 0x14, 0xC49D46EF, Xbox); //Wolf Car Lot

        }

        

        public static byte Find_Crew_Members(ref byte[] Data, bool Xbox, byte Member)
        {
            //Current Function, Grab Count
            int Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0x033FA23A)
            {
                Pos += 0x10;
            }
            Pos += 0x2B1;
            byte Part_of_Crew = Data[Pos];
            byte Show_Memebers = Data[Pos + 2];
            Pos += 0x55F;
            byte Count = 0;
           for (int i = Pos; i < Pos + 0x48; i += 4)
            {
                if (Helper_Functions.ReadUInt32(Data, i, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[Member]))
                {
                    if (Part_of_Crew > ((i - Pos) - (Count * 4)) / 4)
                    {
                        return 2;
                    }
                    else if (Part_of_Crew + Show_Memebers > ((i - Pos) - (Count * 4)) / 4)
                    {
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show(Helper_Functions.VLT_Hash(Crew_Members[Member]).ToString("X2"));
                        return 0;
                    }

                    break;
                }
                else if (Helper_Functions.ReadUInt32(Data, i, Xbox) == 0x0)
                {
                    Count++;
                }
            }
            return 0;

        }

        public static bool Get_Active_Crew_Member(ref byte[] Data, RadioButton nev, RadioButton sal, RadioButton nikki, RadioButton colin, RadioButton samsong, RadioButton yumi, bool Xbox)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0x033FA23A)
            {
                Pos += 0x10;
            }
            Pos += 0x2B8;
            

            if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[0]))
            {
                return nev.Checked = true;
            }
            else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[1]))
            {
                return sal.Checked = true;
            }
            else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[2]))
            {
                return nikki.Checked = true;
            }
            else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[3]))
            {
                return colin.Checked = true;
            }
            else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[4]))
            {
                return samsong.Checked = true;
            }
            else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[5]))
            {
                return yumi.Checked = true;
            }
            else
            {
                return nev.Checked = true;
            }
        }

        public static void Write_Active_Crew_Member(ref byte[] Data, byte index, bool Xbox_360)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox_360) != 0x033FA23A)
            {
                Pos += 0x10;
            }
            Pos += 0x2B8;
            Helper_Functions.WriteUInt32(Data, Pos, Helper_Functions.VLT_Hash(Crew_Members[index]), Xbox_360);
        }

        public static void Rebuild_Crew(ref byte[] Data, int Index_1, int Index_2, int Index_3, int Index_4, int Index_5, int Index_6, bool Xbox)
        {


            int Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0x033FA23A)
            {
                Pos += 0x10;
            }
            Pos += 0x810;

            List<uint> Show_Crew = new List<uint>();
            List<uint> Crew_Signed = new List<uint>();
            
            if (Index_1 == 2)
            {
                Crew_Signed.Add(Helper_Functions.VLT_Hash(Crew_Members[0]));
            }
            else if (Index_1 == 1) 
            {
                Show_Crew.Add(Helper_Functions.VLT_Hash(Crew_Members[0]));
            }
            else
            {
                Show_Crew.Add(0x0);
            }

            if (Index_2 == 2)
            {
                Crew_Signed.Add(Helper_Functions.VLT_Hash(Crew_Members[1]));
            }
            else if (Index_2 == 1)
            {
                Show_Crew.Add(Helper_Functions.VLT_Hash(Crew_Members[1]));
            }
            else
            {
                Show_Crew.Add(0x0);
            }

            if (Index_3 == 2)
            {
                Crew_Signed.Add(Helper_Functions.VLT_Hash(Crew_Members[2]));
            }
            else if (Index_3 == 1)
            {
                Show_Crew.Add(Helper_Functions.VLT_Hash(Crew_Members[2]));
            }
            else
            {
                Show_Crew.Add(0x0);
            }

            if (Index_4 == 2)
            {
                Crew_Signed.Add(Helper_Functions.VLT_Hash(Crew_Members[3]));
            }
            else if (Index_4 == 1)
            {
                Show_Crew.Add(Helper_Functions.VLT_Hash(Crew_Members[3]));
            }
            else
            {
                Show_Crew.Add(0x0);
            }
            if (Index_5 == 2)
            {
                Crew_Signed.Add(Helper_Functions.VLT_Hash(Crew_Members[4]));
            }
            else if (Index_5 == 1)
            {
                Show_Crew.Add(Helper_Functions.VLT_Hash(Crew_Members[4]));
            }
            else
            {
                Show_Crew.Add(0x0);
            }
            if (Index_6 == 2)
            {
                Crew_Signed.Add(Helper_Functions.VLT_Hash(Crew_Members[5]));
            }
            else if (Index_6 == 1)
            {
                Show_Crew.Add(Helper_Functions.VLT_Hash(Crew_Members[5]));
            }
            else
            {
                Show_Crew.Add(0x0);
            }

            Pos = MD5_Prep.Find_Game(Data);
            while (Helper_Functions.ReadUInt32(Data,Pos,Xbox) != 0x033FA23A)
            {
                Pos += 0x10;
            }
            Pos += 0x2b1;
            Data[Pos] = (byte)Crew_Signed.Count;
            Data[Pos + 2] = (byte)Show_Crew.Count;
            Pos += 0x55F;
            while (Crew_Signed.Count < 4)
            {
                Crew_Signed.Insert(Crew_Signed.Count, 0x00000000);
            }
            
            for (int i = 0; i < 0x11; i++)
            {
                
                    if (Crew_Signed.Count > 0)
                    {
                        Helper_Functions.WriteUInt32(Data, (i * 4) + Pos, Crew_Signed[0], Xbox);
                        Crew_Signed.RemoveAt(0);
                    }
               
                    else if (Show_Crew.Count > 0)
                    {
                    Helper_Functions.WriteUInt32(Data, (i * 4) + Pos, Show_Crew[0], Xbox);
                    Show_Crew.RemoveAt(0);
                     }
                    else
                    {
                    Helper_Functions.WriteUInt32(Data, (i * 4) + Pos, 0, Xbox);
                    }

                
            }




        }

        public static void Write_Crew_Members(ref byte[] Data, bool Xbox)
        {
            int Pos = MD5_Prep.Find_Game(Data);
            Pos += 0x9D0;
            byte Count = 0;
            
            for (int c = 0; c < 6; c++)
            {
                bool New = true;
                for (int i = Pos; i < Pos + 0x48; i += 4)
                {

                    if (Helper_Functions.ReadUInt32(Data, i, Xbox) == Helper_Functions.VLT_Hash(Crew_Members[c]))
                    {
                        New = false;
                        break;
                        
                    }
                
                }
                if (New == true)
                {
                    for (int t = Pos; t < Pos + 0x48; t += 4)
                    {
                        if (Helper_Functions.ReadUInt32(Data, t, Xbox) == 0)
                        {
                            Helper_Functions.WriteUInt32(Data, Pos, Helper_Functions.VLT_Hash(Crew_Members[c]), Xbox);
                            Data[Pos] += 1;
                            break;
                        }
                    }
                   
                }
               
            }
                       
            
        }



        
        
        public static Int32 Find_Empty_Car_Slot(ref byte[] Data, Int32 Base_Pos, byte Custom_Slot, bool Xbox)
        {
            for (int p = 0, count = 0xC; p < 199; p++, count += 0x14)
            {
                if (Helper_Functions.ReadUInt32(Data, (Base_Pos + count),Save_Form.Xbox_360) == 0xFFFFFFFF)
                {
                    
                    Byte Garage = 0xFF;
                    //Custimization  = (Byte)Find_Custimization_Slot(ref Data, 0x11B40, 0);
                    Insert_Racer(ref Data, p,Base_Pos + count, 0xF, 1, 0xFF, Garage, "240sx",Xbox);
                    return Base_Pos + count;
                }
                
            }
            return 0;
        }

        public static UInt16 Find_Vinyl_Slot(ref byte[] Data, Int32 Base_Position,  UInt16 Vinyl_ID)
        {
            for (int p = 0, count = 0x1F2F4; p < 0x2BC; p++, count += 0x1C)
            {
                if (Helper_Functions.ReadUInt16(Data, Base_Position + count + 0x8,Save_Form.Xbox_360) == 0x7FFF)
                {
                    Helper_Functions.WriteUInt16(Data, Base_Position + count + 0x8, Vinyl_ID, Save_Form.Xbox_360);
                    return (ushort)p;
                }
            }

            return 0xFFFF;
        }
        


        public static void Clear_All_Car_Data(ref byte[] Data,  bool BE)
        {
            int Pos = 0xC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, BE);
            for (int i = 0; i < 5; i++)
            {
                switch(i)
                    { 
                    case 0:
                        {
                            byte[] car;
                            for (int p = 0, count = 0x0; p < 199; p++, count += 0x14)
                            {
                                if (BE == true)
                                {
                                    if (p == 0)
                                    {
                                        car = new byte[] { 0x56, 0x6A, 0xFF, 0xA7, 0x87, 0x74, 0x32, 0x2C, 0x87, 0x74, 0x32, 0x2C, 0x00, 0x0F, 0x00, 0x10, 0xFF, 0xFF, 0xAA, 0xAA };
                                    }
                                    else
                                    {
                                        car = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xAA, 0xAA };
                                    }
                                }
                                else
                                {
                                    if (p == 0)
                                    {
                                        car = new byte[] { 0xA7, 0xFF, 0x6A, 0x56, 0x2C, 0x32, 0x74, 0x87, 0x5D, 0x29, 0xCF, 0x87, 0x10, 0x00, 0x0F, 0x00, 0xFF, 0xFF, 0x00, 0x00 };
                                    }
                                    else
                                    {
                                        car = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00 };

                                    }

                                }
                                    Buffer.BlockCopy(car, 0, Data, Pos + count, car.Length);
                            }
                            break;
                        }
                    case 1:
                        {
                            Pos += 0xFA0;
                            byte[] Custom_1;
                            for (int p = 0, count = 0x0; p < 74; p++, count += 0x470)
                            {

                                if (BE == true)
                                {
                                    Custom_1 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0x7F, 0xFF, 0x7F, 0xFF, 0x00, 0x00, 0x7F, 0xFF, 0x7F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xAA, 0xAA, 0xAA };
                                }
                                else
                                {
                                    Custom_1 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x7F, 0xFF, 0x7F, 0x00, 0x00, 0xFF, 0x7F, 0xFF, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                                }
                                Buffer.BlockCopy(Custom_1, 0, Data, Pos + count, Custom_1.Length);
                            }
                            break;
                        }
                    case 2:
                        {
                            Pos += 0x14CD0;
                            byte[] car;
                            for (int p = 0, count = 0x0; p < 10; p++, count += 0x34)
                            {
                                if (BE == true)
                                {
                                    car = new byte[] { 0xFF, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                                }
                                else
                                {
                                    car = new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                                }
                                Buffer.BlockCopy(car, 0, Data, Pos + count, car.Length);
                            }
                            break;
                        }
                    case 3:
                        {
                            Pos += 0x208;
                            byte[] car;
                            for (int p = 0, count = 0x0; p < 0x9470; p+=4, count+=4)
                            {
                                if (BE == true)
                                {
                                    car = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
                                }
                                else
                                {
                                    car = new byte[] { 0xFE, 0xFF, 0xFF, 0xFF };
                                }
                                    Buffer.BlockCopy(car, 0, Data, Pos + count, car.Length);
                            }
                            break;
                        }
                    case 4:
                        {
                            Pos += 0x9470;
                            
                                byte[] vinyl;
                            for (int p = 0, count = 0x0; p < 700; p++, count += 0x1C)
                            {

                                if (BE == true)
                                {
                                    vinyl = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0x00, 0x00, 0x7F, 0xFF, 0x00, 0x00, 0x7F, 0xFF, 0x00, 0x00, 0x7F, 0xFF, 0x00, 0x00 };
                                }
                                else
                                {
                                    vinyl = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0x00, 0x00, 0xFF, 0x7F, 0x00, 0x00, 0xFF, 0x7F, 0x00, 0x00, 0xFF, 0x7F, 0x00, 0x00 };
                                }
                                    Buffer.BlockCopy(vinyl, 0, Data, Pos + count, vinyl.Length);
                            }
                            break;
                        }
                }
            }
        }
    }
}