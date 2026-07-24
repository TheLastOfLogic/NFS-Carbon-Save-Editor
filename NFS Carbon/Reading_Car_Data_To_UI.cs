using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher.NFS_Carbon
{
    internal class Reading_Car_Data_To_UI
    {

        //find and populate positions of each Car Section
        //Eg Cars //0x10
        //Part Section 0x2F848 not real values
        public static int Car_Index_Start_Pos = 0xC;
        public static int Customization_1_Pos = 0xFAC; // CISP already included into this
        public static int Garage_Start_Pos = 0x15C7C; //Pos + Garage_Start_Pos
        public static int Parts_List_Start_Pos = 0x15E84;
        public static int Vinyl_Start_Pos = 0x1F2F4;
        public static int Weird_2C_Section = 0x23F84;


        public static void Populate_Garage(byte[] Data, ComboBox Current_Car_Garage, bool Xbox)
        {
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            Pos += Car_Index_Start_Pos;
            Current_Car_Garage.Items.Clear();
            if (Current_Car_Garage.Items.Count == 0)
            {
                for (int t = 0; t < 10; t++)
                {
                    Current_Car_Garage.Items.Add("-Empty-");
                }
            }
            Current_Car_Garage.BeginUpdate();
            for (int i = 0; i < 200; i++)
            {
                if (Data[Pos + 0x11] != 0xFF && Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0xFFFFFFFF)
                {
                    for (int c = 0; c < Read_Data_Table.carUnlocks.Length-1; c++) 
                    {
                        if (Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox) == Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[c]))
                        {
                            int slot = Current_Car_Garage.Items.IndexOf("-Empty-");
                            Current_Car_Garage.Items[(int)Data[Pos + 0x11]] = Read_Data_Table.carRealNames[c];
                            break;
                        }
                    }
                }
                Current_Car_Garage.EndUpdate();
                Pos += 0x14;
            }
            if (Current_Car_Garage.Items.Count == 0)
            {
                Current_Car_Garage.Items.Add("-Empty-");
            }
            
        }
        public static void Read_Strikes(byte[] Data, NumericUpDown Strikes_Allowed, NumericUpDown Current_Strikes, Label Heat, Label Bounty, Label Times_Escaped, Label Times_Caught, NumericUpDown Speeding, NumericUpDown Excessive_Speeding, NumericUpDown Reckless_Driving, NumericUpDown Ramming_Police_Vehicle, NumericUpDown Hit_N_Run, NumericUpDown Damage_To_Property, NumericUpDown Avoiding_Arrest, NumericUpDown Drive_Off_Road, Label Total_Cost_Infractions, ComboBox Garage, bool Xbox)
        {
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);

            try
            {
                if (Garage.SelectedItem != "-Empty-")
                {
                    if (Garage.SelectedIndex != 0)
                    {
                        Pos += Garage_Start_Pos + (Garage.SelectedIndex * 0x34);
                    }
                    else
                    {
                        Pos += Garage_Start_Pos;
                    }
                    if (Data[Pos + Garage_Start_Pos] != 0xFF)
                    {
                        Strikes_Allowed.Value = Data[Pos + 2];
                        Current_Strikes.Value = Data[Pos + 3];
                        Heat.Text = "Heat Level: " + ((BitConverter.UInt32BitsToSingle(Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox))).ToString());
                        Bounty.Text = "Current Bounty: $" + (Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox)).ToString();
                        Times_Escaped.Text = "Times Escaped: " + Helper_Functions.ReadUInt16(Data, Pos + 0x10, Xbox).ToString();
                        Times_Caught.Text = "Times Caught: " + Helper_Functions.ReadUInt16(Data, Pos + 0x12, Xbox).ToString();
                        Speeding.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x14, Xbox);
                        Excessive_Speeding.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x16, Xbox);
                        Reckless_Driving.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x18, Xbox);
                        Ramming_Police_Vehicle.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x1A, Xbox);
                        Hit_N_Run.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x1C, Xbox);
                        Damage_To_Property.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x1E, Xbox);
                        Avoiding_Arrest.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x20, Xbox);
                        Drive_Off_Road.Value = Helper_Functions.ReadUInt16(Data, Pos + 0x22, Xbox);
                        Total_Cost_Infractions.Text = "Total Cost Of Infractions $" + Read_Infractions(Speeding, Excessive_Speeding, Reckless_Driving, Ramming_Police_Vehicle, Hit_N_Run, Damage_To_Property, Avoiding_Arrest, Drive_Off_Road);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed To Optain Car Data");
            }
        }
        public static void Write_Strikes(ref byte[] Data, NumericUpDown Strikes_Allowed, NumericUpDown Current_Strikes,  ComboBox Garage, bool Xbox)
        {
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            if (Garage.SelectedItem != "-Empty-")
            {
                if (Garage.SelectedIndex != 0)
                {
                    Pos += Garage_Start_Pos + (Garage.SelectedIndex * 0x34);
                }
                else
                {
                    Pos += Garage_Start_Pos;
                }
                if (Data[Pos + Garage_Start_Pos] != 0xFF)
                {
                    if (Strikes_Allowed != null)
                    {
                        Data[Pos + 2] = (byte)Strikes_Allowed.Value;
                    }
                    if (Current_Strikes != null)
                    {
                        Data[Pos + 3] = (byte)Current_Strikes.Value;
                    }
                }
            }

        }

        public static Int32 Read_Infractions(NumericUpDown NUP_1, NumericUpDown NUP_2, NumericUpDown NUP_3, NumericUpDown NUP_4, NumericUpDown NUP_5, NumericUpDown NUP_6, NumericUpDown NUP_7, NumericUpDown NUP_8)
        {            
            NumericUpDown[] NUP = {NUP_1,NUP_2,NUP_3,NUP_4,NUP_5,NUP_6,NUP_7,NUP_8};
            int[] multipliers = { 150, 350, 1000, 350, 300, 100, 300, 75 };

            int total = 0;
            for (int i = 0; i < NUP.Length; i++)
            {
                total += ((int)NUP[i].Value * multipliers[i]);
            }
       
            return total;
            
        }

        public static void Write_Infractions(ref byte[] Data, NumericUpDown NUP_1, NumericUpDown NUP_2, NumericUpDown NUP_3, NumericUpDown NUP_4, NumericUpDown NUP_5, NumericUpDown NUP_6, NumericUpDown NUP_7, NumericUpDown NUP_8, ComboBox Garage, bool Xbox)
        {
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            if (Garage.SelectedIndex != 0)
            {
                Pos += Garage_Start_Pos + (Garage.SelectedIndex * 0x34);
            }
            else
            {
                Pos += Garage_Start_Pos;
            }
            Pos += 0x14;
            NumericUpDown[] NUP = { NUP_1, NUP_2, NUP_3, NUP_4, NUP_5, NUP_6, NUP_7, NUP_8 };
            byte counter = 0;
            for (int i = Pos; i < Pos + 0x10; i += 2)
            {
                Helper_Functions.WriteUInt16(Data, i, (ushort)NUP[counter++].Value, Xbox);
            }
        }

        public static void Rewards_After_Boss_Battle(ref byte[] Data, bool Xbox)
        {
            int Pos = Helper_Functions.Grab_Position_From_Anchor(Data, Xbox);

            //Kenji
            if (Data[Pos + 0x4F4] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x4EC, Xbox) == 0x40693BA3)
            {
                Data[Pos + 0x4F4] = 0x60; //Race Wars Unlocked
            }
            if (Data[Pos + 0x2FC] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x2F4, Xbox) == 0x40693BA3)
            {
                Data[Pos + 0x2FC] = 0x60; //Race Wars Unlocked
            }
            if (Data[Pos + 0x428] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x420, Xbox) == 0x40693BA3)
            {
                Data[Pos + 0x428] = 0x60; //Race Wars Unlocked
            }


            //Wolf
            if (Data[Pos + 0x3E0] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x3D8, Xbox) == 0xA9382979)
            {
                Data[Pos + 0x3E0] = 0x60; //Boss Unlocked
            }
            if (Data[Pos + 0x308] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x300, Xbox) == 0xA9382979)
            {
                Data[Pos + 0x308] = 0x60; //Race Wars Unlocked
            }
            if (Data[Pos + 0x314] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x30C, Xbox) == 0xA9382979)
            {
                Data[Pos + 0x314] = 0x60; //Race Wars Unlocked
            }

            //Angie
            if (Data[Pos + 0x5F0] == 4 && Helper_Functions.ReadUInt32(Data,Pos + 0x5E8, Xbox) == 0x27182028)
            {
                Data[Pos + 0x5F0] = 0x60; //Boss unLocked
            }
            if (Data[Pos + 0x3BC] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x3B4, Xbox) == 0x27182028)
            {
                Data[Pos + 0x3BC] = 0x60; //Race Wars unLocked
            }
            if (Data[Pos + 0x410] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x408, Xbox) == 0x27182028)
            {
                Data[Pos + 0x410] = 0x60; //Race Wars unLocked
            }

            //Darius
            if (Data[Pos + 0x7C0] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x7B8, Xbox) == 0x10A2F397)
            {
                Data[Pos + 0x7C0] = 0x60; //Race Wars unLocked
            }
            if (Data[Pos + 0x7FC] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x7F4, Xbox) == 0x10A2F397)
            {
                Data[Pos + 0x7FC] = 0x60; //Race Wars unLocked
            }
            if (Data[Pos + 0x608] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x600, Xbox) == 0x10A2F397)
            {
                Data[Pos + 0x608] = 0x60; //Race Wars unLocked
            }
            if (Data[Pos + 0x614] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x60C, Xbox) == 0x10A2F397)
            {
                Data[Pos + 0x614] = 0x60; //Race Wars unLocked
            }
            if (Data[Pos + 0x62C] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x624, Xbox) == 0x10A2F397)
            {
                Data[Pos + 0x62C] = 0x60; //Race Wars unLocked
            }
            if (Data[Pos + 0x638] == 4 && Helper_Functions.ReadUInt32(Data, Pos + 0x630, Xbox) == 0x10A2F397)
            {
                Data[Pos + 0x638] = 0x60; //Race Wars unLocked
            }
            //2.duel Muscle //Reward Cards
            //3.duel Exotic //Reward Cards
            //4.duel Tuner //Reward Cards
            //5.duel Darious //Unlock R8
            Pos = MD5_Prep.Find_Game(Data);
            Pos += 0x10000;
            string[] Boss_Races = new string[]
            {
                "2.duel","3.duel","4.duel", "5.duel"
            };
            int length = 0x10 * Helper_Functions.ReadInt32(Data, Pos, Xbox);
            Pos += 4;
            
            for (int c = 0; c < 4; c++)
            {
                for (int i = Pos; i < Pos + length; i += 0x10)
                {
                    if (Helper_Functions.VLT_Hash(Boss_Races[c]) == Helper_Functions.ReadUInt32(Data, i, Xbox) && ((Helper_Functions.ReadUInt32(Data, i + 4, Xbox) & 0x2u) == 0x2u))
                    {
                        Helper_Functions.WriteUInt32(Data, i + 4, (Helper_Functions.ReadUInt32(Data, i + 4, Xbox) & ~0x2u), Xbox);
                        break;
                    }
                }
            }

        }

        public static void Populate_All_Cars(byte[] Data, bool Xbox, ComboBox Car_Lot, ComboBox Car_List)
        {
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            Pos += 0xC;
            Car_Lot.BeginUpdate();
            for (int i = 0; i < 200; i++)
            {
                if ((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 1u) == 0x1u && Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0xFFFFFFFF)
                {
                    for (int c = 0; c < Read_Data_Table.carUnlocks.Length - 1; c++)
                    {
                        if (Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox) == Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[c]))
                        {
                            Car_Lot.Items.Add(Read_Data_Table.carUnlocks[c] + " (Carlot)");
                            break;
                        }
                    }

                }
                else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == 0xFFFFFFFF)
                {
                    Car_Lot.Items.Add("-Empty-");
                }
                else if ((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 2u) == 0x2u)
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if (Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[p]) == Helper_Functions.ReadUInt32(Data, Pos+8, Xbox))
                        {
                            if (Data[Pos + 0x11] == 0xFF)
                            {
                                Car_Lot.Items.Add(Read_Data_Table.carUnlocks[p] + " (Career(Stock))");
                            }
                            else
                            {
                                Car_Lot.Items.Add(Read_Data_Table.carUnlocks[p] + " (Career(Custom))");
                            }
                                break;
                        }
                    }
                   
                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 4u) == 0x4u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if (Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[p]) == Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox)) 
                        {
                            Car_Lot.Items.Add(Read_Data_Table.carUnlocks[p] + " (My Cars)");
                            break;
                        }
                    }
                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 8u) == 0x8u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if ((int)(Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p])) == (Helper_Functions.ReadInt32(Data, Pos, Xbox)))
                        {
                            
                            Car_Lot.Items.Add(Read_Data_Table.carUnlocks[p] + " (Bonus)");
                            break;
                        }
                        //MessageBox.Show((Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p]).ToString("X2") + " " + (Helper_Functions.ReadUInt32(Data, 0, Xbox)).ToString("X2")));
                    }

                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 0x10u) == 0x10u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if ((int)(Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p])) == Helper_Functions.ReadUInt32(Data, Pos, Xbox)) 
                        {
                            Car_Lot.Items.Add(Read_Data_Table.carUnlocks[p] + " (Custom)");
                            break;
                        }
                    }
                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 0x80u) == 0x80u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if ((int)(Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p])) == Helper_Functions.ReadUInt32(Data, Pos, Xbox))
                        {
                            Car_Lot.Items.Add(Read_Data_Table.carUnlocks[p] + " (Crew)");
                            break;
                        }
                    }
                }
                Pos += 0x14;

            }
            Car_Lot.EndUpdate();
            Car_List.Items.AddRange(Read_Data_Table.pvehicle_List_names);
            Car_List.SelectedIndex = 0;
            Car_Lot.SelectedItem = "-Empty-";
        }

        public static void Inject_Car(ref byte[] Data, bool Xbox, ComboBox Car_Lot, ComboBox Car_List)
        {
            string[] FrontEnd = new string[] { "brera","db9","a3_20t","r8","tt","m3_gtre46","xk","ccx","gallardo","murcielago","murcielago_lp640","elise","europa","slr","clk500","sl65","zonda","911turbo","997s","997tt","carrera_gt","caymans","gt3rs","clio","monaro","gti","r32","g35","is300","mazdaspeed3","rx7","rx8","eclipse99","eclipsegt","lancerevo9","240sx","350z","skyline","imprezzawrx","corolla","mr2","supra","camaro","camaro_concept","chevelle","300c","corvette_car","corvettec6r","z06","challengern","charger06","viper","challenger71","charger69","fordgt","mustanggt","mustangshlbyn","mustangshlbyo","cuda","roadrunner","gto","gt500_07","gt500_67" };
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            Pos += 0xC;
            if (Car_Lot.SelectedItem != "-Empty-")
            {
                MessageBox.Show("It Must Be An Empty Space To Add a New Car");
            }
            else
            {
                if (Car_Lot.SelectedIndex != 0)
                {
                    Car_Lot.Items.Insert(Car_Lot.SelectedIndex, Car_List.SelectedItem);
                    Car_Lot.Items.RemoveAt(Car_Lot.SelectedIndex + 1);
                    Car_Lot.SelectedItem = Car_List.SelectedItem;
                    //Car_Lot.SelectedIndex
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex * 0x14, (uint)Car_Lot.SelectedIndex, Xbox);
                    for (int i = 0; i < FrontEnd.Length; i++)
                    {
                        if ((Read_Data_Table.pvehicle[Car_List.SelectedIndex]) == FrontEnd[i])
                        {
                            Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex * 0x14 + 4, Helper_Functions.VLT_Hash(FrontEnd[i]), Xbox);
                            break;
                        }
                    }
                    
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex * 0x14 + 8, Helper_Functions.VLT_Hash(Read_Data_Table.pvehicle[Car_List.SelectedIndex]), Xbox);
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex * 0x14 + 0xC, 0x000F0001, Xbox);
                    Helper_Functions.WriteUInt16(Data, Pos + Car_Lot.SelectedIndex * 0x14 + 0x10, 0xFFFF, Xbox);
                }
                else
                {
                    Car_Lot.Items.Insert(Car_Lot.SelectedIndex, Car_List.SelectedItem);
                    Car_Lot.Items.RemoveAt(Car_Lot.SelectedIndex + 1);
                    Car_Lot.SelectedItem = Car_List.SelectedItem;
                    Helper_Functions.WriteUInt32(Data, Pos, (uint)Car_Lot.SelectedIndex, Xbox);
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex, (uint)Car_Lot.SelectedIndex, Xbox);
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex + 4, 0, Xbox);
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex + 8, Helper_Functions.VLT_Hash(Read_Data_Table.pvehicle[Car_List.SelectedIndex]), Xbox);
                    Helper_Functions.WriteUInt32(Data, Pos + Car_Lot.SelectedIndex + 0xC, 0x000F0001, Xbox);
                    Helper_Functions.WriteUInt16(Data, Pos + Car_Lot.SelectedIndex + 0x10, 0xFFFF, Xbox);

                }
            }
        }

        public static byte[] Check_Selected_Cars(byte[] Data, bool Xbox, int Crew_1,int Crew_2,int Crew_3, int Current_Selected_Car, byte Crew_1_C, byte Crew_2_C, byte Crew_3_C, ref byte[] Crew_Cars)
        {
            Populate_Master_Car_List(Data, Xbox);
            
            for (byte i = 0; i < 6; i++)
            {
                //Helper_Functions.SwapEndianness()
                if (Crew_1 != 0)
                {
                    if (Helper_Functions.VLT_Hash(Save_Game_Structure.Crew_Members[i]) == (uint)Crew_1)
                    {
                        Crew_Cars[0] = Crew_1_C;
                        Crew_Cars[4] = i;
                    }
                }
                if (Crew_2 != 0)
                {
                    if (Helper_Functions.VLT_Hash(Save_Game_Structure.Crew_Members[i]) == (uint)Crew_2)
                    {
                        Crew_Cars[1] = Crew_2_C;
                        Crew_Cars[5] = i;
                    }
                }
                if (Crew_3 != 0)
                {
                    if (Helper_Functions.VLT_Hash(Save_Game_Structure.Crew_Members[i]) == (uint)Crew_3)
                    {
                        Crew_Cars[2] = Crew_3_C;
                        Crew_Cars[6] = i;
                    }
                }
            }
            if (Current_Selected_Car < 0)
            {
                Current_Selected_Car = 0;
            }
            Crew_Cars[3] = (byte)Current_Selected_Car;
            return Crew_Cars;
        }


        public static string[] Master_Car_List = new string[200];
        



        public static string[] Populate_Master_Car_List(byte[] Data,  bool Xbox)
        {
            Array.Fill(Master_Car_List, "-Empty-");
            int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            Pos += 0xC;
            
            for (int i = 0; i < 200; i++)
            {
                if ((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 1u) == 0x1u && Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0xFFFFFFFF)
                {
                    for (int c = 0; c < Read_Data_Table.carUnlocks.Length - 1; c++)
                    {
                        if (Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox) == Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[c]))
                        {
                            Master_Car_List[i] = (Read_Data_Table.carUnlocks[c] + " (Career(Stock))");
                            break;
                        }
                    }

                }
                else if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == 0xFFFFFFFF)
                {
                    Master_Car_List[i] = "-Empty-";
                }
                else if ((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 2u) == 0x2u)
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if (Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[p]) == Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox))
                        {
                            if (Data[Pos + 0x11] == 0xFF)
                            {
                                Master_Car_List[i] = (Read_Data_Table.carUnlocks[p] + " (Career(Stock))");
                            }
                            else
                            {
                                Master_Car_List[i] = (Read_Data_Table.carUnlocks[p] + " (Career(Custom))");
                            }
                            break;
                        }
                    }

                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 4u) == 0x4u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if (Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[p]) == Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox))
                        {
                            Master_Car_List[i] = (Read_Data_Table.carUnlocks[p] + " (My Cars)");
                            break;
                        }
                    }
                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 8u) == 0x8u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if ((int)(Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p])) == (Helper_Functions.ReadInt32(Data, Pos, Xbox)))
                        {

                            Master_Car_List[i] = (Read_Data_Table.carUnlocks[p] + " (Bonus)");
                            break;
                        }
                        //MessageBox.Show((Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p]).ToString("X2") + " " + (Helper_Functions.ReadUInt32(Data, 0, Xbox)).ToString("X2")));
                    }

                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 0x10u) == 0x10u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if ((int)(Helper_Functions.Bin_Hash(Read_Data_Table.carUnlocks[p])) == Helper_Functions.ReadUInt32(Data, Pos, Xbox))
                        {
                            Master_Car_List[i] = (Read_Data_Table.carUnlocks[p] + " (Custom)");
                            break;
                        }
                    }
                }
                else if (((Helper_Functions.ReadUInt32(Data, Pos + 0xC, Xbox) & 0x80u) == 0x80u))
                {
                    for (int p = 0; p < Read_Data_Table.carUnlocks.Length; p++)
                    {
                        if (Helper_Functions.VLT_Hash(Read_Data_Table.carUnlocks[p]) == Helper_Functions.ReadUInt32(Data, Pos + 8, Xbox))
                        {
                            Master_Car_List[i] = (Read_Data_Table.carUnlocks[p] + " (Crew)");
                            break;
                        }
                    }
                }
                Pos += 0x14;

            }
            return Master_Car_List;
            
        }

        public static void Populate_Selected_Combobox(byte[] Data, bool Xbox, ComboBox Selected_CB, Label Name, byte index)
        {
            Selected_CB.Items.Clear();
            Populate_Master_Car_List(Data, Xbox);
            Selected_CB.Items.AddRange(Master_Car_List);
            Selected_CB.SelectedIndex = Profile_Editor.Populate_Crew_Selected_Cars[index];
            if (index < 3)
            {
                Name.Text = Profile_Editor.Crew_Members[Profile_Editor.Populate_Crew_Selected_Cars[index + 4]];
            }
        }

        public static void Profile_Editor_Populate_UI(ref byte[] Data, ref byte[] Data_Table, ref byte[] Unchanged, ref string File_Path, ref ComboBox psr_combo_b, ref ComboBox Nevile, ref ComboBox Sal, ref ComboBox Nikki, ref ComboBox Yumi, ref ComboBox Collin, ref ComboBox Samson, ref TextBox Alias_Name, ref TextBox Crew_Name, ref TextBox Money, ref NumericUpDown GOOJ, ref NumericUpDown Strike_Markers, ref RadioButton Nev_RB, ref RadioButton Sal_RB, ref RadioButton Nikki_RB, ref RadioButton Collin_RB, ref RadioButton Samson_RB, ref RadioButton Yumi_RB, ref NumericUpDown Strikes_Allowed_NUP, ref NumericUpDown Current_Strikes, ref Label Heat, ref Label Bounty, ref Label Times_Escaped, ref Label Times_Caught, ref NumericUpDown Speeding, ref NumericUpDown Excessive_Speeding, ref NumericUpDown Reckless_Driving, ref NumericUpDown Ramming_Police_Vehicle,ref NumericUpDown Hit_N_Run, ref NumericUpDown Damage_To_Property, ref NumericUpDown Avoiding_Arrest, ref NumericUpDown Drive_Off_Road, ref Label Total_Cost_Infractions, ref ComboBox Garage, ref ComboBox Car_Lot_Combo_B, ref ComboBox All_Available_Cars_ComboB, ref TextBox File_Path_String,ref ComboBox Garage_Theme, ref ComboBox Selected_Car, ref ComboBox Crew_1_Car, ref ComboBox Crew_2_Car, ref ComboBox Crew_3_Car, bool Xbox)
        {
            int Crew_1_Name = 0;
            int Crew_2_Name = 0;
            int Crew_3_Name = 0;
            int Selected_Car_Slot = 0;
            byte Crew_1_Slot = 0;
            byte Crew_2_Slot = 0;
            byte Crew_3_Slot = 0;
            psr_combo_b.BeginUpdate();
            psr_combo_b.Items.Clear();
            psr_combo_b.Items.AddRange(Preset_Riders_List.Preset_Car_Names);
            psr_combo_b.EndUpdate();


            for (byte i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            Nevile.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref Data, Xbox, i);
                            break;
                        }
                    case 1:
                        {
                            Sal.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref Data, Xbox, i);
                            break;
                        }
                    case 2:
                        {
                            Nikki.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref Data, Xbox, i);
                            break;
                        }
                    case 3:
                        {
                            Collin.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref Data, Xbox, i);
                            break;
                        }
                    case 4:
                        {
                            Samson.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref Data, Xbox, i);
                            break;
                        }
                    case 5:
                        {
                            Yumi.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref Data, Xbox, i);
                            break;
                        }
                }


            }

            Read_Data_Table.Read_Decompressed_Data(Data_Table, ref Alias_Name, ref Money, ref Crew_Name, ref Strike_Markers, ref GOOJ, ref Garage_Theme,ref Selected_Car_Slot,ref Crew_1_Name,ref Crew_1_Slot, ref Crew_2_Name, ref Crew_2_Slot, ref Crew_3_Name, ref Crew_3_Slot);
            Check_Selected_Cars(Data, Xbox, Crew_1_Name,Crew_2_Name,Crew_3_Name,Selected_Car_Slot,Crew_1_Slot,Crew_2_Slot,Crew_3_Slot, ref Profile_Editor.Populate_Crew_Selected_Cars);



            Save_Game_Structure.Get_Active_Crew_Member(ref Data, Nev_RB, Sal_RB, Nikki_RB, Collin_RB, Samson_RB, Yumi_RB, Xbox);
            Garage.BeginUpdate();
            Garage.Items.Clear();
            Reading_Car_Data_To_UI.Populate_Garage(Data, Garage, Xbox);
            Garage.SelectedIndex = 0;
            Garage.EndUpdate();
            Reading_Car_Data_To_UI.Read_Strikes(Data, Strikes_Allowed_NUP, Current_Strikes, Heat, Bounty, Times_Escaped, Times_Caught, Speeding, Excessive_Speeding, Reckless_Driving, Ramming_Police_Vehicle, Hit_N_Run, Damage_To_Property, Avoiding_Arrest, Drive_Off_Road, Total_Cost_Infractions, Garage, Xbox);
            Car_Lot_Combo_B.BeginUpdate();
            Car_Lot_Combo_B.Items.Clear();
            All_Available_Cars_ComboB.BeginUpdate();
            All_Available_Cars_ComboB.Items.Clear();
            Reading_Car_Data_To_UI.Populate_All_Cars(Data, Xbox, Car_Lot_Combo_B, All_Available_Cars_ComboB);
            Car_Lot_Combo_B.EndUpdate();
            All_Available_Cars_ComboB.EndUpdate();
            File_Path_String.Text = File_Path;
        }

        
    }
}
