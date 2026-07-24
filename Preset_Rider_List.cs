using EA_MD5_hasher;
using EA_MD5_hasher.NFS_Carbon;
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

public static class Preset_Riders_List
{
    public static string[] Starter_Cars = new string[]
    {
        "RX-8",
        "CAMARO",
        "BRERA"
    };

    public static string[] presetRideNames = new string[]
{
    "ANGIE",
    "ANGIE_CASINO",
    "BMWM3GTRE46_CROSSCHASE",
    "CARRERA_GRNP7",
    "CE_240SX",
    "CE_350Z",
    "CE_CARRERA_GT",
    "CE_CHALLENGER",
    "CE_CHARGER",
    "CE_GT500",
    "CE_IMPREZA",
    "CE_MURCIELAGO",
    "CE_SKYLINE",
    "CE_SL65",
    "CHEVELLE_2",
    "COLIN",
    "COROLLA_2",
    "CROSS",
    "CS_300C",
    "CS_350Z",
    "CS_BRERA",
    "CS_CAMARO",
    "CS_CAYMANS",
    "CS_CHALLENGERN",
    "CS_CHARGER06",
    "CS_CHARGER69",
    "CS_CLIO",
    "CS_CORVETTEZ06",
    "CS_CUDA",
    "CS_DB9",
    "CS_ECLIPSEGT",
    "CS_GALLARDO",
    "CS_IMPREZAWRXSTI",
    "CS_JAGUARXK",
    "CS_LANCEREVO9",
    "CS_MAZDASPEED3",
    "CS_MUSTANGGT",
    "CS_MUSTANGSHLBYO",
    "CS_RX7",
    "CS_RX8",
    "CS_SKYLINE",
    "CS_SL65",
    "CS_SLR",
    "CS_SUPRA",
    "CS_VIPER",
    "DARIUS",
    "ECLIPSE_2",
    "EUROPA_2",
    "EXOTIC_2",
    "GTO_2",
    "IS300_2",
    "KENJI",
    "KENJI_CASINO",
    "M3GTRCAREERSTART",
    "MR2_2",
    "MUSCLE_2",
    "NIKKI",
    "REVVED",
    "ROADRUNNER_2",
    "SAMSON",
    "T1_COLIN",
    "T1_EXOTIC_NEVILLE",
    "T1_EXOTIC_SAL",
    "T1_MUSCLE_NEVILLE",
    "T1_MUSCLE_SAL",
    "T1_NIKKI",
    "T1_SAMSON",
    "T1_TUNER_NEVILLE",
    "T1_TUNER_SAL",
    "T1_YUMI",
    "T2_EXOTIC_NEVILLE",
    "T2_EXOTIC_SAL",
    "T2_MUSCLE_NEVILLE",
    "T2_MUSCLE_SAL",
    "T2_NIKKI",
    "T2_TUNER_NEVILLE",
    "T2_TUNER_SAL",
    "T3_COLIN",
    "T3_EXOTIC_NEVILLE",
    "T3_EXOTIC_SAL",
    "T3_MUSCLE_NEVILLE",
    "T3_MUSCLE_SAL",
    "T3_SAMSON",
    "T3_TUNER_NEVILLE",
    "T3_TUNER_SAL",
    "T3_YUMI",
    "TUNER_2",
    "WOLF",
    "WOLF_CASINO",
    "YUMI",
    "DEMO_VID_CARRERA",
    "DEMO_VID_GALLARDO",
    "DEMO_VID_CHALLENGER",
    "DEMO_VID_DB9",
    "DEMO_VID_LANCER",
    "DSL_CHALLENGER",
    "DSL_EVO",
    "DSL_EVO2",
    "DSL_GALLARDO",
    "LE_SAMURAI",
    "FOOTMAN",
    "M3GTR_2",
    "USER_EXOTIC",
    "USER_TUNER",
    "USER_MUSCLE",
    "RIVAL_CREW01",
    "RIVAL_CREW02",
    "RIVAL_CREW05",
    "RIVAL_CREW04",
    "CREW_SCORPIOS_BOSS_T3",
    "HERO",
    "PRESELL_RX7",
    "CS_CORVETTEZ06_2",
    "CE_CUDA",
    "M3GTR"
};

    public static string[] Preset_Car_Names = new string[]
{
    "ANGIE",
    "ANGIE CASINO",
    "BMW M3 GTR E46 CROSSCHASE",
    "CARRERA GRNP7",
    "Collectors Edition 240SX",
    "Collectors Edition350Z",
    "Collectors EditionCARRERA GT",
    "Collectors EditionCHALLENGER",
    "Collectors EditionCHARGER",
    "Collectors EditionGT500",
    "Collectors EditionIMPREZA",
    "Collectors EditionMURCIELAGO",
    "Collectors EditionSKYLINE",
    "Collectors EditionSL65",
    "CHEVELLE Alt",
    "COLIN",
    "COROLLA Alt",
    "CROSS",
    "Challenge Series 300C",
    "Challenge Series 350Z",
    "Challenge Series BRERA",
    "Challenge Series CAMARO",
    "Challenge Series CAYMANS",
    "Challenge Series CHALLENGERN",
    "Challenge Series CHARGER06",
    "Challenge Series CHARGER69",
    "Challenge Series CLIO",
    "Challenge Series CORVETTEZ06",
    "Challenge Series CUDA",
    "Challenge Series DB9",
    "Challenge Series ECLIPSEGT",
    "Challenge Series GALLARDO",
    "Challenge Series IMPREZAWRXSTI",
    "Challenge Series JAGUARXK",
    "Challenge Series LANCEREVO9",
    "Challenge Series MAZDASPEED3",
    "Challenge Series MUSTANGGT",
    "Challenge Series MUSTANGSHLBYO",
    "Challenge Series RX7",
    "Challenge Series RX8",
    "Challenge Series SKYLINE",
    "Challenge Series SL65",
    "Challenge Series SLR",
    "Challenge Series SUPRA",
    "Challenge Series VIPER",
    "DARIUS",
    "ECLIPSE Alt",
    "EUROPA Alt",
    "EXOTIC TEST DRIVER",
    "GTO Alt",
    "IS300 Alt",
    "KENJI",
    "KENJI CASINO",
    "BMW M3 GTR CAREER START",
    "MR2 Alt",
    "MUSCLE TEST DRIVER",
    "NIKKI",
    "REVVED",
    "ROADRUNNER Alt",
    "SAMSON",
    "T1 COLIN",
    "T1 EXOTIC NEVILLE",
    "T1 EXOTIC SAL",
    "T1 MUSCLE NEVILLE",
    "T1 MUSCLE SAL",
    "T1 NIKKI",
    "T1 SAMSON",
    "T1 TUNER NEVILLE",
    "T1 TUNER SAL",
    "T1 YUMI",
    "T2 EXOTIC NEVILLE",
    "T2 EXOTIC SAL",
    "T2 MUSCLE NEVILLE",
    "T2 MUSCLE SAL",
    "T2 NIKKI",
    "T2 TUNER NEVILLE",
    "T2 TUNER SAL",
    "T3 COLIN",
    "T3 EXOTIC NEVILLE",
    "T3 EXOTIC SAL",
    "T3 MUSCLE NEVILLE",
    "T3 MUSCLE SAL",
    "T3 SAMSON",
    "T3 TUNER NEVILLE",
    "T3 TUNER SAL",
    "T3 YUMI",
    "TUNER TEST DRIVE",
    "WOLF",
    "WOLF CASINO",
    "YUMI",
    "DEMO VID CARRERA",
    "DEMO VID GALLARDO",
    "DEMO VID CHALLENGER",
    "DEMO VID DB9",
    "DEMO VID LANCER",
    "DSL CHALLENGER",
    "DSL EVO",
    "DSL EVO Alt",
    "DSL GALLARDO",
    "LE SAMURAI",
    "FOOTMAN",
    "BMW M3GTR Alt",
    "BETA EXOTIC",
    "BETA TUNER",
    "BETA MUSCLE",
    "RIVAL CREW01",
    "RIVAL CREW02",
    "DEMO VID DB9 Alt",
    "RIVAL CREW04",
    "CREW SCORPIOS BOSS T3",
    "HERO",
    "PRESELL RX7",
    "Challenge Series CORVETTEZ06 Alt",
    "Collectors Edition CUDA",
    "M3GTR"
};

    public static uint[] Preset_Ride_Hashes = new uint[presetRideNames.Length];
    public static void Compile_Bin_Hashes(ref uint[] PRH)
    {

        for (int i = 0; i < Preset_Ride_Hashes.Length; i++)
        {
            PRH[i] = Helper_Functions.Bin_Hash(presetRideNames[i]);
        }
    }

    public static void Write_Preset_CarSlot(ref byte[] Data, bool Xbox, byte[] Car_Slot_Data, byte Category, byte Garage, byte Custimization, RadioButton Selected_Category)
    {
        if (Xbox == true)
        {
            Copy_Vehicles(Car_Slot_Data, Xbox, false);
        }
        int Pos = 0xC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        byte count = 0;
        for (int c = 0; c < 200; c++)
        {
            if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == 0xFFFFFFFF)
            {
                for (int i = 0; i < 0x14; i++)
                {
                    Data[i + Pos] = Car_Slot_Data[i];
                    //need to write the flags for category, Garage, And Custimization
                }
                if (Xbox == false)
                {
                    Data[Pos + 0xC] = Category;
                    Data[Pos + 0xD] = 0;
                    Data[Pos + 0xE] = 0x4;
                    Data[Pos + 0xF] = 0x0;
                }
                else
                {
                    Data[Pos + 0xC] = 0;
                    Data[Pos + 0xD] = 0x4;
                    Data[Pos + 0xE] = 0x0;
                    Data[Pos + 0xF] = Category;
                }
                Data[Pos + 0x10] = Custimization;
                Data[Pos + 0x11] = Garage;
                if (Selected_Category.Name == "My_Cars_Radio_Bttn" || Selected_Category.Name == "Garage_Radio_Bttn")
                {
                    Helper_Functions.WriteUInt32(Data, Pos, (uint)c, Xbox);
                }

                break;
            }
            Pos += 0x14;
        }

    }

    public static byte Get_Custimization_Total(byte[] Data, bool Xbox)
    {
        int Pos = 0xFAC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        byte count = 0;
        for (int c = 0; c < 75; c++)
        {
            if (Helper_Functions.ReadUInt16(Data, Pos, Xbox) == 0xFFFF)
            {
                count++;
            }
            Pos += 0x470;
        }
        if (count < 2)
        {
            MessageBox.Show("No Slots Available");
        }
        else
        {
            MessageBox.Show((count).ToString());
        }
        return (byte)(count);
    }

    public static byte Get_Open_Car_Slot_Total(byte[] Data, bool Xbox)
    {
        int Pos = 0xC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        byte count = 0;
        for (int c = 0; c < 200; c++)
        {
            if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == 0xFFFFFFFF)
            {
                count++;
            }
            Pos += 0x14;
        }
        return count;
    }

    public static int Get_Total_Vinyl_Slots_Used(byte[] Data, bool Xbox, ref List<ushort> Vinyl_Pos_list)
    {
        int Pos = 0xFAC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        int count = 0;

        for (int c = 0; c < 75; c++)
        {

            if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != 0xFFFFFFFF)
            {

                int Base_Vinyl_Pos = (Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox) + 0x1F2F4); // + (Helper_Functions.ReadUInt16(Data, Pos + 2, Xbox) * 0x1C));
                int Vinyl_Pos;

                if (Helper_Functions.ReadUInt16(Data, Pos + 2, Xbox) != 0xFFFF)
                {
                    Vinyl_Pos = Base_Vinyl_Pos + 0x1C * (Helper_Functions.ReadUInt16(Data, Pos + 2, Xbox));
                    Vinyl_Pos_list.Add(Helper_Functions.ReadUInt16(Data, Pos + 2, Xbox));
                    count++;
                    while (Helper_Functions.ReadUInt16(Data, Vinyl_Pos + 0xA, Xbox) != 0xFFFF)
                    {
                        Vinyl_Pos_list.Add(Helper_Functions.ReadUInt16(Data, Vinyl_Pos + 0xA, Xbox));
                        Vinyl_Pos = Base_Vinyl_Pos + 0x1C * (Helper_Functions.ReadUInt16(Data, Vinyl_Pos + 0xA, Xbox));
                        count++;
                    }
                    ushort bob = (ushort)((Vinyl_Pos - Base_Vinyl_Pos) / 0x1C);
                    if (!Vinyl_Pos_list.Contains(bob) && bob != 0xFFFF)
                    {
                        Vinyl_Pos_list.Add(bob);
                        count++;
                    }

                }


            }
            Pos += 0x470;

        }

        return (0x2BC - count); //Vinyls Left
    }

    public static ushort Grab_Vinyl_To_Empty_Slot(ref byte[] Data, bool Xbox, ref List<byte> Vinyl, ref List<ushort> Vinyl_positions_Currently_Used)
    {
        //remeber to write vinyl Pos to the custimization slot which will happen after
        int Pos = 0x1F2F4 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        int Base_Pos = Pos;
        ushort return_value = 0;
        ushort return_address = 0;
        bool bob = false;
        for (ushort i = 0; i < 700;)
        {

            while (Vinyl_positions_Currently_Used.Contains(i) && i < 0x700)
            {
                i++;
            }
            Pos = Base_Pos + 0x1C * i;

            if (bob != true)
            {
                return_address = (ushort)((Pos - Base_Pos) / 0x1C); bob = true;
            }
            if (Vinyl.Count < 0x1D)
            {
                for (int c = 0; c < 0x1C; c++)
                {
                    Data[Pos + c] = Vinyl.ElementAt(0);
                    Vinyl.RemoveAt(0);
                }
                Helper_Functions.WriteUInt16(Data, Pos + 0xA, 0xFFFF, Xbox);
                Vinyl_positions_Currently_Used.Add((ushort)((Pos - Base_Pos) / 0x1C));
                return return_address;
            }
            else
            {
                for (int c = 0; c < 0x1C; c++)
                {
                    Data[Pos + c] = Vinyl.ElementAt(0);
                    Vinyl.RemoveAt(0);
                }


                Vinyl_positions_Currently_Used.Add((ushort)((Pos - Base_Pos) / 0x1C));
                while (Vinyl_positions_Currently_Used.Contains(i) && i < 0x700)
                {
                    i++;
                }
                int Pos_1 = Base_Pos + 0x1C * i;
                Helper_Functions.WriteUInt16(Data, Pos + 0xA, (ushort)((Pos_1 - Base_Pos) / 0x1C), Xbox);
            }

        }
        return 0;
    }




    public static byte Garage_Space(ref byte[] Data, bool Xbox)
    {
        int Pos = Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        Pos += Reading_Car_Data_To_UI.Garage_Start_Pos;
        for (byte i = 0; i < 10; i++)
        {

            if (0xFF == Data[Pos])
            {
                Data[Pos] = i;
                Data[Pos + 2] = 3;
                Data[Pos + 3] = 0;
                Helper_Functions.WriteUInt16(Data, Pos + 4, 0, Xbox);
                Array.Fill(Data, (byte)0, (int)Pos + 0x8, (int)0x2C);
                return i;
            }
            else
            {
                Pos += 0x34;
            }
        }
        MessageBox.Show("It appears your Garage Is Full At This Time");

        return 0xFF;
    }








    public static int Get_Total_Parts_Remaining(byte[] Data, bool Xbox)
    {
        int count = 0;
        byte[] Parts_File = new byte[120];
        int Pos = 0x15E84 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        while (Pos < 0x1F2F4 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox))
        {
            if ((Helper_Functions.ReadUInt16(Data, Pos, Xbox) != 0x7FFF) && (Helper_Functions.ReadUInt16(Data, Pos, Xbox) != 0xFFFF) && (Helper_Functions.ReadUInt16(Data, Pos, Xbox) != 0xFFFE))
            {
                Pos += 4;
            }
            else
            {
                count++;
                Pos += 4;

            }
        }
        return count;

    }

    /*
    public static ushort Build_Parts(ref byte[] Data, byte[] Parts_File, bool Xbox)
    {
        ushort First_Pos = 0xFFFF;
        int count = Get_Total_Parts_Remaining(Data, Xbox);
        if (count > 0)
        {
            if (Xbox == true)
            {
                Copy_Convert_Parts_List(ref Parts_File, Xbox, false);
            }


            int Pos = 0x15E84 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            //First_Pos = (ushort)(((0x1F2F4 - 0x15E84) - (4 * count)) / 4); //use this to backfill the parts Pointer Pos
            ushort Part_Pos = (ushort)0xFFFF;
            int OG_Pos = Pos;
            while (Pos < 0x1F2F4 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox))
            {
                if (count > Parts_File.Length * 2)
                {
                    for (int i = 0; i < Parts_File.Length;)
                    {
                        if ((Helper_Functions.ReadUInt16(Data, Pos, Xbox) != 0x7FFF && Helper_Functions.ReadUInt16(Data, Pos, Xbox) != 0xFFFF && Helper_Functions.ReadUInt16(Data, Pos, Xbox) != 0xFFFE))
                        {
                            Pos += 4;
                        }
                        else
                        {
                            if (First_Pos == 0xFFFF)
                            {
                                First_Pos = (ushort)((Pos - (0x15E84 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox))) / 4);
                                Part_Pos = (ushort)(First_Pos + 1);

                            }

                            Helper_Functions.WriteUInt16(Data, Pos, Helper_Functions.ReadUInt16(Parts_File, i, Xbox), Xbox);
                            Helper_Functions.WriteUInt16(Data, Pos + 2, (ushort)(Part_Pos), Xbox);


                            if (i + 2 < Parts_File.Length)
                            {
                                i += 2;
                                Pos += 4;
                                Part_Pos++;
                            }
                            else
                            {
                                i += 2;

                                Helper_Functions.WriteUInt16(Data, Pos + 2, 0xFFFF, Xbox);
                            }

                        }
                    }

                    // Helper_Functions.WriteUInt16(Data, Pos-2, 0xFFFF, Xbox);
                    break;
                }

            }
        }
        return First_Pos;

    } */

    public static ushort Build_Parts(ref byte[] Data, byte[] Parts_File, bool Xbox)
    {
        ushort First_Pos = 0xFFFF;
        int count = Get_Total_Parts_Remaining(Data, Xbox);

        if (count > 0)
        {
            if (Xbox == true)
            {
                Copy_Convert_Parts_List(ref Parts_File, Xbox, false);
            }

            int basePos = 0x15E84 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            int endPos = 0x1F2F4 + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);

            int Pos = basePos;
            bool isFirstAllocated = false;

            // Loop through your Parts_File IDs (stepping by 2 bytes)
            for (int i = 0; i < Parts_File.Length; i += 2)
            {
                // --- Step 1: Scan forward to find the first/next truly empty slot ---
                // This is the exact same logic your vinyl function uses to skip occupied data
                while (Pos < endPos)
                {
                    ushort currentSlotValue = Helper_Functions.ReadUInt16(Data, Pos, Xbox);
                    if (currentSlotValue == 0x7FFF || currentSlotValue == 0xFFFF || currentSlotValue == 0xFFFE)
                    {
                        break; // Found an empty slot!
                    }
                    Pos += 4; // Skip occupied slot
                }

                // Safety check to ensure we haven't run off the end of the parts block
                if (Pos >= endPos)
                {
                    MessageBox.Show("Ran out of free part slots in the save file.");
                    break;
                }

                // Track the starting index of the chain to return to the customization slot
                ushort currentSlotIndex = (ushort)((Pos - basePos) / 4);
                if (!isFirstAllocated)
                {
                    First_Pos = currentSlotIndex;
                    isFirstAllocated = true;
                }

                // --- Step 2: Write the current Part ID data ---
                ushort partData = Helper_Functions.ReadUInt16(Parts_File, i, Xbox);
                Helper_Functions.WriteUInt16(Data, Pos, partData, Xbox);

                // --- Step 3: Look forward to see if this is the last part ---
                if (i + 2 >= Parts_File.Length)
                {
                    // No more parts left to write, terminate the chain cleanly
                    Helper_Functions.WriteUInt16(Data, Pos + 2, 0xFFFF, Xbox);
                }
                else
                {
                    // There are more parts coming! 
                    // Scan forward to find where the NEXT empty slot will be *before* writing this pointer
                    int nextSearchPos = Pos + 4;
                    while (nextSearchPos < endPos)
                    {
                        ushort nextSlotValue = Helper_Functions.ReadUInt16(Data, nextSearchPos, Xbox);
                        if (nextSlotValue == 0x7FFF || nextSlotValue == 0xFFFF || nextSlotValue == 0xFFFE)
                        {
                            break; // Found the future empty slot position
                        }
                        nextSearchPos += 4;
                    }

                    // Write that future slot's calculated index into our current pointer field
                    ushort nextSlotIndex = (ushort)((nextSearchPos - basePos) / 4);
                    Helper_Functions.WriteUInt16(Data, Pos + 2, nextSlotIndex, Xbox);
                }

                // Move the slot pointer forward by 4 bytes so the next iteration starts scanning after this slot
                Pos += 4;
            }
        }
        return First_Pos;
    }

    public static void Write_Customization_1(ref byte[] Data, byte[] Custimization_Data, bool Xbox, ref byte Custimization_Slot_Number, string Preset_Name)
    {
        if (Xbox == true)
        {
            Copy_Custimizations(ref Custimization_Data, Xbox, false);
        }
        if (Get_Custimization_Total(Data, Xbox) > 1)
        {
            int Pos = 0xFAC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
            while (Pos < 0x15C7C + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox))
            {
                if (Helper_Functions.ReadUInt16(Data, Pos, Xbox) == 0xFFFF)
                {
                    Helper_Functions.WriteUInt16(Data, Pos, Build_Parts(ref Data, Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Name + "_Parts.bin"), Xbox), Xbox);
                    List<ushort> Vinyl_Positions_Used = new List<ushort>();
                    Preset_Riders_List.Get_Total_Vinyl_Slots_Used(Data, Xbox, ref Vinyl_Positions_Used);
                    List<byte> vinyl = new List<byte>();
                    vinyl.AddRange(Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Name + "_Vinyl.bin"));
                    if (Xbox == true)
                    {
                        byte[] temp = Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Name + "_Vinyl.bin");
                        vinyl.Clear();
                        Copy_Convert_Vinyls(ref temp, Xbox, false);
                        vinyl.AddRange(temp);
                    }
                    if (vinyl.Count > 0x1B)
                    {

                        Helper_Functions.WriteUInt16(Data, Pos + 2, Preset_Riders_List.Grab_Vinyl_To_Empty_Slot(ref Data, Xbox, ref vinyl, ref Vinyl_Positions_Used), Xbox);

                    }
                    else
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + 2, 0xFFFF, Xbox);
                    }

                    int counter = 0;
                    Custimization_Data[0xB4] = (byte)((Pos - (0xFAC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox))) / 0x470);
                    Custimization_Slot_Number = Custimization_Data[0xB4];
                    for (int i = Pos + 4; counter < Custimization_Data.Length; i++)
                    {
                        Data[i] = Custimization_Data[counter++];
                    }

                    break;
                }
                else
                {
                    Pos += 0x470;
                }
            }
        }
    }

    public static void Dump_Preset(byte[] Data, bool Xbox)
    {
        string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine it to create a target output folder path
        string outputFolder = "";
        if (Xbox == true)
        {
            outputFolder = Path.Combine(exeDirectory, "Dumps", "Xbox 360");
        }
        else
        {
            outputFolder = Path.Combine(exeDirectory, "Dumps", "PC");
        }

        // Automatically create the directory if it doesn't exist yet
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        Compile_Bin_Hashes(ref Preset_Ride_Hashes);
        int count = 0;
        int Pos = 0xC + Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox);
        byte[] Car_Lot_info = new byte[0x14];
        for (int c = 0; c < 200; c++)
        {
            for (int i = 0; i < Preset_Ride_Hashes.Length; i++)
            {
                if (Helper_Functions.ReadUInt32(Data, Pos, Xbox) == Preset_Ride_Hashes[i])
                {

                    for (int cl = 0; cl < 0x14; cl++)
                    {
                        Car_Lot_info[cl] = Data[Pos + cl];
                    }
                    string filePath = Path.Combine(outputFolder, presetRideNames[i] + "_CarSlot.bin");
                    File.WriteAllBytes(filePath, Car_Lot_info);
                    count++;
                    break;
                }
            }
            Pos += 0x14;
        }
        //MessageBox.Show(count.ToString());
        count = 0;
        for (int c = 0; c < 75; c++)
        {
            for (int i = 0; i < Preset_Ride_Hashes.Length; i++)
            {
                if (Helper_Functions.ReadUInt32(Data, Pos + 0xB4, Xbox) == Preset_Ride_Hashes[i])
                {
                    byte[] Block_Data = new byte[0x46C];
                    Buffer.BlockCopy(Data, Pos + 4, Block_Data, 0, Block_Data.Length);
                    int bob = (0x14CD0 - (Pos - (Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox) + 0xFAC))) + 0x208 + Pos;
                    int Part_Pos = (Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox) + 0x15E84 + (Helper_Functions.ReadUInt16(Data, Pos, Xbox) * 4));
                    //0x9472 part id length
                    List<byte> Parts = new List<byte>();
                    //MessageBox.Show(Helper_Functions.ReadUInt16(Data, Pos, Xbox).ToString("X2"));
                    while (Helper_Functions.ReadUInt16(Data, Part_Pos + 2, Xbox) != 0xFFFF)
                    {
                        Parts.Add(Data[Part_Pos]);
                        Parts.Add(Data[Part_Pos + 1]);
                        //Part_Pos = ((4 * Helper_Functions.ReadUInt16(Data, Part_Pos + 2, Xbox)) + bob);
                        Part_Pos = ((4 * Helper_Functions.ReadUInt16(Data, Part_Pos + 2, Xbox)) + (Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox) + 0x15E84));
                    }
                    Parts.Add(Data[Part_Pos]);
                    Parts.Add(Data[Part_Pos + 1]);
                    //Part_Pos = ((4 * Helper_Functions.ReadUInt16(Data, Part_Pos + 2, Xbox)) + bob);
                    Part_Pos = ((4 * Helper_Functions.ReadUInt16(Data, Part_Pos + 2, Xbox)) + (Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox) + 0x15E84));
                    int Vinyl_Base_Pos = (Helper_Functions.Grab_Position_Anchor_For_Car_Structure(Data, Xbox) + 0x1F2F4);
                    int Vinyl_Pos = Vinyl_Base_Pos;
                    List<byte> Vinyl = new List<byte>();

                    // Handle the initial link from the customization slot
                    ushort initial_link = Helper_Functions.ReadUInt16(Data, Pos + 2, Xbox);
                    if (initial_link != 0xFFFF)
                    {
                        // Jump absolutely from the Base Position
                        Vinyl_Pos = Vinyl_Base_Pos + (0x1C * initial_link);
                        for (int v = 0; v < 0x1C; v++)
                        {
                            Vinyl.Add(Data[Vinyl_Pos + v]);
                        }
                    }

                    // Loop through the rest of the chain
                    ushort next_slot = Helper_Functions.ReadUInt16(Data, Vinyl_Pos + 0xA, Xbox);
                    while (next_slot != 0xFFFF)
                    {
                        // FIX: Calculate the next position using the absolute slot index from Base Position
                        Vinyl_Pos = Vinyl_Base_Pos + (0x1C * next_slot);

                        for (int v = 0; v < 0x1C; v++)
                        {
                            Vinyl.Add(Data[Vinyl_Pos + v]);
                        }

                        // Read the next slot pointer from our newly updated position
                        next_slot = Helper_Functions.ReadUInt16(Data, Vinyl_Pos + 0xA, Xbox);
                    }

                    //MessageBox.Show((Helper_Functions.ReadUInt16(Data, Part_Pos + 2 + Helper_Functions.ReadUInt16(Data, Pos, Xbox), Xbox)).ToString("X2"));

                    exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // Combine it to create a target output folder path
                    outputFolder = "";
                    if (Xbox == true)
                    {
                        outputFolder = Path.Combine(exeDirectory, "Dumps", "Xbox 360");
                    }
                    else
                    {
                        outputFolder = Path.Combine(exeDirectory, "Dumps", "PC");
                    }

                    // Automatically create the directory if it doesn't exist yet
                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }

                    string filePath = Path.Combine(outputFolder, presetRideNames[i] + "_Parts.bin");

                    // Write the block data cleanly

                    File.WriteAllBytes(filePath, Parts.ToArray());

                    filePath = Path.Combine(outputFolder, presetRideNames[i] + "_Vinyl.bin");

                    // Write the block data cleanly

                    File.WriteAllBytes(filePath, Vinyl.ToArray());

                    // Generate the clean, absolute path for the specific car file
                    filePath = Path.Combine(outputFolder, presetRideNames[i] + "_Customization.bin");

                    // Write the block data cleanly
                    File.WriteAllBytes(filePath, Block_Data);

                    //filePath = Path.Combine(outputFolder, presetRideNames[i] + "_CarSlot.bin");
                    //File.WriteAllBytes(filePath,Car_Lot_info);
                    //MessageBox.Show(presetRideNames[i]);
                    break;
                }
            }
            Pos += 0x470;
        }
        //MessageBox.Show(count.ToString());
    }

    public static void Copy_Convert_Parts_List(ref byte[] Data, bool Xbox, bool Xbox_1)
    {

        int Pos = 0x0;

        //0x9470;
        for (int p = 0, count = 0x0; p < Data.Length; p += 2, count += 0x2)
        {
            if (Xbox == true)
            {
                if (Helper_Functions.ReadUInt16(Data, Pos + count, Xbox_1) != 0xFFFE && Xbox_1 == false)
                {
                    if ((Data[Pos + count] & 0x01) == 0x01)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(((Helper_Functions.ReadUInt16(Data, Pos + count, Xbox_1) - 1) / 2) | 0x8000), Xbox);
                        //Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                    }
                    else if ((Data[Pos + count] & 0x01) != 0x01)
                    {
                        Helper_Functions.WriteUInt16(Data, Pos + count, (ushort)(Helper_Functions.ReadUInt16(Data, Pos + count, Xbox_1) / 2), Xbox);
                        //Helper_Functions.WriteUInt16(Data, Pos + count + 2, Helper_Functions.ReadUInt16(Data_1, Pos_1 + count + 2, Xbox_1), Xbox);
                    }
                }

            }

        }
    }

    public static void Copy_Custimizations(ref byte[] Custimization_Car, bool Xbox, bool Xbox_1)
    {

        int Pos = -4;
        byte[] Custom_1;

        //Helper_Functions.WriteUInt16(Custimization_Car, Pos, Helper_Functions.ReadUInt16(Custimization_Car, Pos, Xbox_1), Xbox);
        //Helper_Functions.WriteUInt16(Custimization_Car, Pos + 2, Helper_Functions.ReadUInt16(Custimization_Car, Pos + 2, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 4, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 4, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x8, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x8, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0xC, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0xC, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x10, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x10, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x14, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x14, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x18, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x18, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x1C, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x1C, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x20, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x20, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x24, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x24, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x28, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x28, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x2C, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x2C, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x30, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x30, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x34, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x34, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x38, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x38, Xbox_1), Xbox);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x3C, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x3C, Xbox_1), Xbox);
        if (Xbox == true)
        {
            Array.Fill(Custimization_Car, (byte)0xAA, (Pos + 0x40), 0x1C);
        }

        Array.Fill(Custimization_Car, (byte)0x00, (Pos + 0x5C), 0x58);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0xB4, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0xB4, Xbox_1), Xbox);
        Custimization_Car[Pos + 0xB8] = Custimization_Car[Pos + 0xB8];
        if (Xbox == true)
        {
            Array.Fill(Custimization_Car, (byte)0xAA, (Pos + 0xB9), 0x3);
        }

        if (Xbox == true && Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0xBC, Xbox_1) == 0x00000000)
        {
            Array.Fill(Custimization_Car, (byte)0xAA, (Pos + 0xBC), 0x4);
        }

        else
        {
            Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0xBC, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0xBC, Xbox_1), Xbox);
        }
        Helper_Functions.WriteUInt16(Custimization_Car, Pos + 0xC0, Helper_Functions.ReadUInt16(Custimization_Car, Pos + 0xC0, Xbox_1), Xbox);
        Helper_Functions.WriteUInt16(Custimization_Car, Pos + 0xC2, Helper_Functions.ReadUInt16(Custimization_Car, Pos + 0xC2, Xbox_1), Xbox);
        Custimization_Car[Pos + 0xC4] = Custimization_Car[Pos + 0xC4];
        Custimization_Car[Pos + 0xC5] = Custimization_Car[Pos + 0xC5];
        Helper_Functions.WriteUInt16(Custimization_Car, Pos + 0xC6, Helper_Functions.ReadUInt16(Custimization_Car, Pos + 0xC6, Xbox_1), Xbox);
        Helper_Functions.WriteUInt16(Custimization_Car, Pos + 0xC8, Helper_Functions.ReadUInt16(Custimization_Car, Pos + 0xC8, Xbox_1), Xbox);
        Helper_Functions.WriteUInt16(Custimization_Car, Pos + 0xCA, Helper_Functions.ReadUInt16(Custimization_Car, Pos + 0xCA, Xbox_1), Xbox);

        int counter = 0xCC;
        for (int r = 0; r < 9; r++)
        {
            for (int i = 0; i < 11; i++, counter += 4)
            {

                Helper_Functions.WriteUInt32(Custimization_Car, Pos + counter, Helper_Functions.ReadUInt32(Custimization_Car, Pos + counter, Xbox_1), Xbox);
            }
        }

        Array.Fill(Custimization_Car, (byte)0x00, (Pos + 0x258), 0x210);
        Helper_Functions.WriteUInt32(Custimization_Car, Pos + 0x468, Helper_Functions.ReadUInt32(Custimization_Car, Pos + 0x468, Xbox_1), Xbox);
        //filler
        Custimization_Car[Pos + 0x46C] = 0x00;
        if (Xbox == true)
        {
            Array.Fill(Custimization_Car, (byte)0xAA, (Pos + 0x46D), 0x3);
        }


    }

    public static void Copy_Vehicles(byte[] Car_Slot, bool Xbox, bool Xbox_1)
    {
        int Pos = 0;
        

            Helper_Functions.WriteUInt32(Car_Slot, Pos, Helper_Functions.ReadUInt32(Car_Slot, Pos, Xbox_1), Xbox);
            Helper_Functions.WriteUInt32(Car_Slot, Pos + 4, Helper_Functions.ReadUInt32(Car_Slot, Pos + 4, Xbox_1), Xbox);
            Helper_Functions.WriteUInt32(Car_Slot, Pos + 8, Helper_Functions.ReadUInt32(Car_Slot, Pos + 8, Xbox_1), Xbox);
            Helper_Functions.WriteUInt32(Car_Slot, Pos + 0xC, Helper_Functions.ReadUInt32(Car_Slot, Pos + 0xC, Xbox_1), Xbox);
            Car_Slot[Pos + 0x10] = Car_Slot[Pos + 0x10];
            Car_Slot[Pos + 0x11] = Car_Slot[Pos + 0x11];
            Helper_Functions.WriteUInt16(Car_Slot, Pos + 0x12, 0xAAAA, Xbox);
            
                
            
        
    }

    public static void Copy_Convert_Vinyls(ref byte[] Vinyl_Data, bool Xbox, bool Xbox_1)
    {
        int Pos = 0;
        
        for (int p = 0, count = 0x0; count < (Vinyl_Data.Length); p++, count += 0x1C)
        {
            // --- Offsets 0x00 - 0x03 ---
            byte[] temp = new byte[4];
            if (Xbox != Xbox_1)
            {
                temp[0x0] = Vinyl_Data[Pos + count + 0x0];
                temp[0x1] = Vinyl_Data[Pos + count + 0x1];
                temp[0x2] = Vinyl_Data[Pos + count + 0x2];
                temp[0x3] = Vinyl_Data[Pos + count + 0x3];
                Vinyl_Data[Pos + count + 0x0] = temp[1];
                Vinyl_Data[Pos + count + 0x1] = temp[0];
                Vinyl_Data[Pos + count + 0x3] = temp[2];
                Vinyl_Data[Pos + count + 0x2] = temp[3];
            }
            

            // --- Offsets 0x04 - 0x07 ---
            Vinyl_Data[Pos + count + 0x04] = Vinyl_Data[Pos + count + 0x04];
            Vinyl_Data[Pos + count + 0x05] = Vinyl_Data[Pos + count + 0x05];
            Vinyl_Data[Pos + count + 0x06] = Vinyl_Data[Pos + count + 0x06];
            Vinyl_Data[Pos + count + 0x07] = Vinyl_Data[Pos + count + 0x07];

            // --- Offset 0x08: 2-byte Vinyl ID & Toggle Conversion ---
            if (Xbox != Xbox_1)
            {
                // Endian-safe read into local variable
                ushort sourceId = Helper_Functions.ReadUInt16(Vinyl_Data, Pos + count + 8, Xbox_1);

                if (Xbox == true) // Converting from PC to Xbox 360
                {
                    if (sourceId == 0xFFFE)
                    {
                        Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x8, 0x7FFF, Xbox);
                    }
                    else if ((sourceId & 0x01) == 0x01) // PC uses lowest bit
                    {
                        ushort converted = (ushort)(((sourceId ^ 1) / 2) | 0x8000);
                        Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x8, converted, Xbox);
                    }
                    else
                    {
                        ushort converted = (ushort)(sourceId / 2);
                        Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x8, converted, Xbox);
                    }
                }
                
            }
            
            // --- Offsets 0x0A - 0x1B ---
            Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x0a, Helper_Functions.ReadUInt16(Vinyl_Data, Pos + count + 0x0a, Xbox_1), Xbox);
            Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x0c, Helper_Functions.ReadUInt16(Vinyl_Data, Pos + count + 0x0c, Xbox_1), Xbox);

            Vinyl_Data[Pos + count + 0x0E] = Vinyl_Data[Pos + count + 0x0E];
            Vinyl_Data[Pos + count + 0x0F] = Vinyl_Data[Pos + count + 0x0F];

            Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x10, Helper_Functions.ReadUInt16(Vinyl_Data, Pos + count + 0x10, Xbox_1), Xbox);

            Vinyl_Data[Pos + count + 0x12] = Vinyl_Data[Pos + count + 0x12];
            Vinyl_Data[Pos + count + 0x13] = Vinyl_Data[Pos + count + 0x13];

            Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x14, Helper_Functions.ReadUInt16(Vinyl_Data, Pos + count + 0x14, Xbox_1), Xbox);

            Vinyl_Data[Pos + count + 0x16] = Vinyl_Data[Pos + count + 0x16];
            Vinyl_Data[Pos + count + 0x17] = Vinyl_Data[Pos + count + 0x17];

            Helper_Functions.WriteUInt16(Vinyl_Data, Pos + count + 0x18, Helper_Functions.ReadUInt16(Vinyl_Data, Pos + count + 0x18, Xbox_1), Xbox);

            Vinyl_Data[Pos + count + 0x1A] = Vinyl_Data[Pos + count + 0x1A];
            Vinyl_Data[Pos + count + 0x1B] = Vinyl_Data[Pos + count + 0x1B];
        }
    }
}
    

