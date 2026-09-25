using EA_MD5_hasher.NFS_Carbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EA_MD5_hasher
{
    public partial class Profile_Editor : Form
    {

        public static bool Xbox_360;
        public byte[] Unchanged;
        public byte[] Data;
        public byte[] Data_Table;
        private bool updating_NUP = false;
        public static byte[] Find_Game;
        public static byte[] UnChanged_File;
        public static string path = "";
        public static byte[] Populate_Crew_Selected_Cars = new byte[7]; 
        public static string[] Crew_Members = { "Neville", "Sal", "Nikki", "Colin",  "Samson", "Yumi" };
        

        public Profile_Editor()
        {

            InitializeComponent();
            foreach (TabPage tab in tabControl1.TabPages)
            {
                var forceHandleCreation = tab.Handle;
            }
            foreach (Control c in tabControl1.Controls)
            {
                if (c == tabPage1)
                {
                    c.Enabled = true;
                    foreach (Control con in groupBox3.Controls)
                    {
                        if (con == Open_File_Bttn)
                        {
                            con.Enabled = true;
                        }
                        else
                        {
                            con.Enabled = false;
                        }
                    }
                }
                else
                {
                    c.Enabled = false;
                }
            }
            //groupBox3.Enabled = true;
            //Open_File_Bttn.Enabled = true;
            /*ref byte[] _Data, ref byte[] _Data_Table, ref byte[] _Unchanged, ref string File_Path
            Preset_Riders_Combo_Box.BeginUpdate();
            Preset_Riders_Combo_Box.Items.AddRange(Preset_Riders_List.presetRideNames);
            Preset_Riders_Combo_Box.EndUpdate();

            for (byte i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            Neville_CB.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref _Data, Xbox_360, i);
                            break;
                        }
                    case 1:
                        {
                            Sal_CB.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref _Data, Xbox_360, i);
                            break;
                        }
                    case 2:
                        {
                            Niki_CB.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref _Data, Xbox_360, i);
                            break;
                        }
                    case 3:
                        {
                            Colin_CB.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref _Data, Xbox_360, i);
                            break;
                        }
                    case 4:
                        {
                            Samson_CB.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref _Data, Xbox_360, i);
                            break;
                        }
                    case 5:
                        {
                            Yumi_CB.SelectedIndex = Save_Game_Structure.Find_Crew_Members(ref _Data, Xbox_360, i);
                            break;
                        }
                }


            }

            Read_Data_Table.Read_Decompressed_Data(_Data_Table, ref Alias_TB, ref Money_TB, ref Crew_TB, ref Strike_Marker_NUP, ref Get_Out_Of_Jail_Marker_NUP);
            Data = (byte[])_Data.Clone();
            Data_Table = (byte[])_Data_Table.Clone();
            Unchanged = (byte[])_Unchanged.Clone();
            Save_Game_Structure.Get_Active_Crew_Member(ref Data, Nev_RB, Sal_RB, Nikki_RB, Collin_RB, Samson_RB, Yumi_RB, Xbox_360);
            Reading_Car_Data_To_UI.Populate_Garage(Data, Garage_Combo_B, Xbox_360);
            Garage_Combo_B.SelectedIndex = 0;
            Reading_Car_Data_To_UI.Read_Strikes(Data, Strikes_Allowed_NUP, Current_Strikes_NUP, Car_Heat_Level_L, Bounty_L, Times_Evaded_L, Times_Caught_L, Speeding_NUP, Excessive_Speeding_NUP, Reckless_Driving_NUP, Raming_Police_Vehicle_NUP, Hit_N_Run_NUP, Damage_To_Property_NUP, Avoiding_Arrest_NUP, Driving_Off_Road_NUP, Total_Cost_For_Infactions_L, Garage_Combo_B, Xbox_360);
            Car_Lot_Combo_B.BeginUpdate();
            All_Available_Cars_ComboB.BeginUpdate();
            Reading_Car_Data_To_UI.Populate_All_Cars(Data, Xbox_360, Car_Lot_Combo_B, All_Available_Cars_ComboB);
            Car_Lot_Combo_B.EndUpdate();
            All_Available_Cars_ComboB.EndUpdate();
            path = File_Path; */
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Save_To_FIle_Bttn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ULA_CS_CB.Checked)
                {
                    Read_Data_Table.Unlock_All_Challenge_Series(ref Data, Xbox_360);
                }

                /*
                if (Nev_RB.Checked)
                {
                    Save_Game_Structure.Write_Active_Crew_Member(ref Data, 0, Xbox_360);
                }
                else if (Sal_RB.Checked)
                {
                    Save_Game_Structure.Write_Active_Crew_Member(ref Data, 1, Xbox_360);
                }
                else if (Nikki_RB.Checked)
                {
                    Save_Game_Structure.Write_Active_Crew_Member(ref Data, 2, Xbox_360);
                }
                else if (Collin_RB.Checked)
                {
                    Save_Game_Structure.Write_Active_Crew_Member(ref Data, 3, Xbox_360);
                }
                else if (Samson_RB.Checked)
                {
                    Save_Game_Structure.Write_Active_Crew_Member(ref Data, 4, Xbox_360);
                }
                else if (Yumi_RB.Checked)
                {
                    Save_Game_Structure.Write_Active_Crew_Member(ref Data, 5, Xbox_360);
                } */

                Read_Data_Table.Breaking_Down_Data(ref Data_Table, ref Money_TB, ref Alias_TB, ref Crew_TB, Xbox_360, All_Performance_Parts_CB.Checked, All_Visuals_CB.Checked, Reward_Cards_CB.Checked, All_Autoscult_Aftermarket_CB.Checked, Show_All_Crew_Members_CB.Checked, Stock_Cars_CB.Checked, Bonus_Cars_CB.Checked, Custom_Cars_CB.Checked, Police_Cars_CB.Checked, Traffic_Cars_CB.Checked, Hidden_Debug_Car_CB.Checked, Complete_World_Map_CB.Checked, Mazda_Dealership_CB.Checked, Strike_Marker_NUP, Get_Out_Of_Jail_Marker_NUP, Garage_Theme_Combo_B, Skip_Tutorial_Checkbox);


                //if (Show_All_Crew_Members_CB.Checked)
                //{
                // Save_Game_Structure.Write_Crew_Members(ref Data, Xbox_360);
                // Save_Game_Structure.Rebuild_Crew(ref Data, Neville_CB.SelectedIndex, Sal_CB.SelectedIndex, Niki_CB.SelectedIndex, Colin_CB.SelectedIndex, Samson_CB.SelectedIndex, Yumi_CB.SelectedIndex, Xbox_360);
                // }


                if (Complete_World_Map_CB.Checked)
                {
                    Save_Game_Structure.Unlock_Entire_Map(ref Data, Xbox_360);
                }
                if (Mazda_Dealership_CB.Checked)
                {
                    Save_Game_Structure.Unlock_Mazda_Dealership(ref Data, Xbox_360);
                }
                _22114455_Builder.ReWrite_Data_Table(ref Data, Data_Table, Xbox_360);
                //Array.Resize(ref Data_Table, Data.Length - (Helper_Functions.ReadInt32(Data, 0x20, Xbox_360) + 0x2C));
                //Data = _22114455_Builder.Write_22114455_Container(ref Data, Data_Table, true, Xbox_360);
                //byte custom_Slot = 0xFF;
                //custom_Slot = Save_Game_Structure.Find_Custimization_Slot(ref temp, Platform_Car_Converter.Find_Car_Strct_Pos(temp, Xbox_360) + 0xFAC, 2, Xbox_360);
                //MessageBox.Show(Save_Game_Structure.Find_Empty_Car_Slot(ref temp, Platform_Car_Converter.Find_Car_Strct_Pos(temp, Xbox_360), custom_Slot, Xbox_360).ToString("X2"));
                PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref Data, Xbox_360);
                //EA_CRC32.UpdateHashes(Data, Xbox_360);
                UnChanged_File = Xbox_360_Con_Handler.Merge_Back_Into_Xbox360_Save(ref UnChanged_File, Data);

                File.WriteAllBytes(path, UnChanged_File);
            }

            catch (Exception ex)
            {
                // 1. Build a detailed error message
                string errorMessage = $"An unexpected error occurred.\n\n" +
                                      $"Message: {ex.Message}\n\n" +
                                      $"Source: {ex.Source}\n\n" +
                                      $"Stack Trace:\n{ex.StackTrace}";

                // 2. Display it to the user (or allow them to copy it)
                MessageBox.Show(errorMessage, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 3. Optional: Log it to a local text file for them to send to you
                System.IO.File.WriteAllText("crash_log.txt", errorMessage);
                MessageBox.Show("Please Make Sure You Have a File Loaded Before Trying To Save");
            }

        }

        private void Show_All_Crew_Members_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_All_Crew_Members_CB.Checked)
            {
                foreach (ComboBox c in Crew_Member_GB.Controls.OfType<ComboBox>())
                {
                    if (c.SelectedIndex < 2)
                    {
                        c.SelectedIndex = 1;
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Garage_Combo_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            updating_NUP = true;
            Reading_Car_Data_To_UI.Read_Strikes(Data, Strikes_Allowed_NUP, Current_Strikes_NUP, Car_Heat_Level_L, Bounty_L, Times_Evaded_L, Times_Caught_L, Speeding_NUP, Excessive_Speeding_NUP, Reckless_Driving_NUP, Raming_Police_Vehicle_NUP, Hit_N_Run_NUP, Damage_To_Property_NUP, Avoiding_Arrest_NUP, Driving_Off_Road_NUP, Total_Cost_For_Infactions_L, Garage_Combo_B, Xbox_360);
            updating_NUP = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Select_All_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Select_All_CB.Checked)
            {
                foreach (CheckBox c in Unlocks_GB.Controls.OfType<CheckBox>())
                {
                    c.Checked = true;
                }
            }
        }

        private void Strikes_Allowed_NUP_ValueChanged(object sender, EventArgs e)
        {
            if (Current_Strikes_NUP.Value > Strikes_Allowed_NUP.Value)
            {
                Current_Strikes_NUP.Value = Strikes_Allowed_NUP.Value;
            }
            Reading_Car_Data_To_UI.Write_Strikes(ref Data, Strikes_Allowed_NUP, null, Garage_Combo_B, Xbox_360);
        }

        private void Current_Strikes_NUP_ValueChanged(object sender, EventArgs e)
        {
            if (Current_Strikes_NUP.Value > Strikes_Allowed_NUP.Value)
            {
                Current_Strikes_NUP.Value = Strikes_Allowed_NUP.Value;
            }
            Reading_Car_Data_To_UI.Write_Strikes(ref Data, null, Current_Strikes_NUP, Garage_Combo_B, Xbox_360);

        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void Speeding_NUP_ValueChanged_1(object sender, EventArgs e)
        {

            Total_Cost_For_Infactions_L.Text = "Total Cost Of Infractions $" + Reading_Car_Data_To_UI.Read_Infractions(Speeding_NUP, Excessive_Speeding_NUP, Reckless_Driving_NUP, Raming_Police_Vehicle_NUP, Hit_N_Run_NUP, Damage_To_Property_NUP, Avoiding_Arrest_NUP, Driving_Off_Road_NUP).ToString();
            if (updating_NUP) return;
            Reading_Car_Data_To_UI.Write_Infractions(ref Data, Speeding_NUP, Excessive_Speeding_NUP, Reckless_Driving_NUP, Raming_Police_Vehicle_NUP, Hit_N_Run_NUP, Damage_To_Property_NUP, Avoiding_Arrest_NUP, Driving_Off_Road_NUP, Garage_Combo_B, Xbox_360);

        }

        private void Grab_File_Path_1_Click(object sender, EventArgs e)
        {

            bool Xbox = false;
            Extract_File_Data.Text = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Find_Game, ref Xbox, Extract_File_Data.Text);
            checkBox1.Checked = Xbox;
            if (Focus() != true)
            {
                if (!string.IsNullOrWhiteSpace(Extract_File_Data.Text) && File.Exists(Extract_File_Data.Text) && File.Exists(Write_File_Data.Text) && !string.IsNullOrWhiteSpace(Write_File_Data.Text))
                {
                    Convert_Bttn.Enabled = true;
                }
                else
                {
                    Convert_Bttn.Enabled = false; // Keep it disabled if the file disappears
                }
            }
            //checkBox1.Enabled = false;
        }

        private void Grab_File_Path_2_Click(object sender, EventArgs e)
        {

            bool Xbox = false;
            Write_File_Data.Text = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Find_Game, ref Xbox, Write_File_Data.Text);
            checkBox2.Checked = Xbox;
            if (Focus() != true)
            {
                if (!string.IsNullOrWhiteSpace(Extract_File_Data.Text) && File.Exists(Extract_File_Data.Text) && File.Exists(Write_File_Data.Text) && !string.IsNullOrWhiteSpace(Write_File_Data.Text))
                {
                    Convert_Bttn.Enabled = true;
                }
                else
                {
                    Convert_Bttn.Enabled = false; // Keep it disabled if the file disappears
                }
            }
            //checkBox2.Enabled = false;
        }

        private void Convert_Bttn_Click(object sender, EventArgs e)
        {
            string File_Path_1 = Extract_File_Data.Text;
            string File_Path_2 = Write_File_Data.Text;

            bool Xbox_1 = checkBox1.Checked;
            bool Xbox = checkBox2.Checked;

            byte[] Data_1 = File.ReadAllBytes(File_Path_1);
            byte[] C_Data = File.ReadAllBytes(File_Path_2);
            byte[] Xbox_360_Container = File.ReadAllBytes(File_Path_2);
            try
            {
                Data_1 = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(Data_1, ref Data_1);
                C_Data = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(Xbox_360_Container, ref Xbox_360_Container);
                Save_Game_Structure.Carrer_Converter(ref C_Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Vehicles(C_Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Custimizations(C_Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Convert_Garage(C_Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Convert_Parts_List(C_Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Convert_Vinyls(ref C_Data, Data_1, Xbox, Xbox_1);
                Rebuild_11224455.Container_Converter(C_Data, Data_1, Xbox, Xbox_1);
                _22114455_Builder.Validate_Save(C_Data, Xbox);
                _22114455_Builder.ReRead_Data_Table(Data_1, Xbox_1);
                // _22114455_Builder.Compare_Decompressed_Data(Data_1, Xbox_1
                byte[] tester1;
                if (Data_1.Length == 0x40000)
                {
                    tester1 = new byte[0x034B28];
                }
                else
                {
                    tester1 = new byte[Helper_Functions.ReadInt32(Data_1, 0x20, Xbox) + 0x2C];
                }

                tester1 = _22114455_Builder.ReRead_Data_Table(Data_1, Xbox_1);
                Read_Data_Table.Convert_Data_Table_PC_XBOX(ref tester1, Xbox);
                File.WriteAllBytes(Path.Combine(File_Path_2 + " tester before"), tester1);
                //File.WriteAllBytes(Path.Combine(File_Path + " tester before"), tester);
                //Read_Data_Table.Breaking_Down_Data(ref tester1, ref Money_TB, ref Alias_TB, ref Crew_TB, Xbox, All_Performance_Parts_CB.Checked, All_Visuals_CB.Checked, Reward_Cards_CB.Checked, All_Autoscult_Aftermarket_CB.Checked, Show_All_Crew_Members_CB.Checked, Stock_Cars_CB.Checked, Bonus_Cars_CB.Checked, Custom_Cars_CB.Checked, Police_Cars_CB.Checked, Traffic_Cars_CB.Checked, Hidden_Debug_Car_CB.Checked, Complete_World_Map_CB.Checked, Mazda_Dealership_CB.Checked, Strike_Marker_NUP, Get_Out_Of_Jail_Marker_NUP);

                if (C_Data.Length == 0x40000)
                {
                    Array.Resize(ref tester1, Data.Length - 0x034B28);
                    tester1 = _22114455_Builder.ReWrite_Data_Table(ref C_Data, tester1, Xbox);
                    PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref C_Data, Xbox);
                }
                else
                {
                    Array.Resize(ref tester1, Data.Length - (Helper_Functions.ReadInt32(C_Data, 0x20, Xbox) + 0x2C));
                    tester1 = _22114455_Builder.ReWrite_Data_Table(ref C_Data, tester1, Xbox);
                    PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref C_Data, Xbox);
                    EA_CRC32.UpdateHashes(C_Data, Xbox);
                }




                C_Data = Xbox_360_Con_Handler.Merge_Back_Into_Xbox360_Save(ref Xbox_360_Container, C_Data);
                File.WriteAllBytes(File_Path_2, C_Data);
            }
            catch
            {
                MessageBox.Show("No File_PathFound");
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reading_Car_Data_To_UI.Rewards_After_Boss_Battle(ref Data, Xbox_360);
            PC_Checksum_Fixer.Update_Label(Data, ref Header_Data_CRC_Value_L, ref File_Data_CRC_Value_L, ref Header_CRC_Value_L, ref License_ID_Value_L, ref File_MD5_Hash_Value_L, ref Game_MD5_Hash_Value_L, Xbox_360);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == Settings_Tab)
            {
                if (path != "" && Data.Length > 0)
                {
                    PC_Checksum_Fixer.Update_Label(Data, ref Header_Data_CRC_Value_L, ref File_Data_CRC_Value_L, ref Header_CRC_Value_L, ref License_ID_Value_L, ref File_MD5_Hash_Value_L, ref Game_MD5_Hash_Value_L, Xbox_360);
                }
            }
        }

        private void Car_Lot_Combo_B_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Car_To_Car_Lot_Bttn_Click(object sender, EventArgs e)
        {
            Reading_Car_Data_To_UI.Inject_Car(ref Data, Xbox_360, Car_Lot_Combo_B, All_Available_Cars_ComboB);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Preset_Riders_List.Dump_Preset(Data, Xbox_360);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {



                byte csn = 0xFF;
                byte category = 1;
                byte Garage = 0xFF;

                try
                {
                    RadioButton radio = new RadioButton();
                    foreach (Control c in groupBox6.Controls)
                    {

                        switch (c)
                        {
                            case RadioButton rb when rb.Name == "Garage_Radio_Bttn" && rb.Checked:
                                {
                                    category = 2;
                                    radio = rb;
                                    //find Garage Opening???
                                    break;
                                }
                            case RadioButton rb when rb.Name == "My_Cars_Radio_Bttn" && rb.Checked:
                                {
                                    category = 4;
                                    radio = rb;
                                    break;
                                }
                            case RadioButton rb when rb.Name == "Bonus_Radio_Bttn" && rb.Checked:
                                {
                                    category = 8;
                                    //need to make sure bin hash is in the unlocked section
                                    radio = rb;
                                    break;
                                }
                            case RadioButton rb when rb.Name == "Custom_Radio_Bttn" && rb.Checked:
                                {
                                    category = 0x10;
                                    radio = rb;
                                    break;
                                }
                            case null:
                                {
                                    break;
                                }
                        }


                    }


                    Preset_Riders_List.Write_Customization_1(ref Data, Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Riders_Combo_Box.SelectedItem + "_Customization.bin"), Xbox_360, ref csn, Preset_Riders_Combo_Box.SelectedItem.ToString());
                    Preset_Riders_List.Write_Preset_CarSlot(ref Data, Xbox_360, Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Riders_Combo_Box.SelectedItem + "_CarSlot.bin"), 0x8, 0xFF, csn, radio);

                }
                catch
                {
                    MessageBox.Show("Please Select A Preset Before Clicking");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add car");
            }






            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine it to create a target output folder path
            string outputFolder = "";
            if (Xbox_360 == true)
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

            string filePath = Path.Combine(outputFolder, "Kenji Game" + ".bin");
            File.WriteAllBytes(filePath, Data);

            MessageBox.Show(Preset_Riders_List.Get_Custimization_Total(Data, Xbox_360).ToString());
            //add in Vinyl Filler, while using our new Vinyl List to Select Position

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                byte csn = 0xFF;
                byte category = 1;
                byte Garage = 0xFF;

                try
                {
                    RadioButton radio = new RadioButton();
                    foreach (Control c in groupBox6.Controls)
                    {

                        switch (c)
                        {
                            case RadioButton rb when rb.Name == "Garage_Radio_Bttn" && rb.Checked:
                                {
                                    category = 2;
                                    radio = rb;
                                    Garage = Preset_Riders_List.Garage_Space(ref Data, Xbox_360);
                                    break;
                                }
                            case RadioButton rb when rb.Name == "My_Cars_Radio_Bttn" && rb.Checked:
                                {
                                    category = 4;
                                    radio = rb;
                                    break;
                                }
                            case RadioButton rb when rb.Name == "Bonus_Radio_Bttn" && rb.Checked:
                                {
                                    category = 8;
                                    //need to make sure bin hash is in the unlocked section
                                    radio = rb;
                                    break;
                                }
                            case RadioButton rb when rb.Name == "Custom_Radio_Bttn" && rb.Checked:
                                {
                                    category = 0x10;
                                    radio = rb;
                                    break;
                                }
                            case null:
                                {
                                    break;
                                }
                        }


                    }


                    Preset_Riders_List.Write_Customization_1(ref Data, Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Riders_List.presetRideNames[Preset_Riders_Combo_Box.SelectedIndex] + "_Customization.bin"), Xbox_360, ref csn, Preset_Riders_List.presetRideNames[Preset_Riders_Combo_Box.SelectedIndex]);
                    Preset_Riders_List.Write_Preset_CarSlot(ref Data, Xbox_360, Grab_Bytes_From_Internal_File.GetResourceBytes(Preset_Riders_List.presetRideNames[Preset_Riders_Combo_Box.SelectedIndex] + "_CarSlot.bin"), category, Garage, csn, radio);
                    Garage_Combo_B.BeginUpdate();
                    Garage_Combo_B.Items.Clear();
                    Reading_Car_Data_To_UI.Populate_Garage(Data, Garage_Combo_B, Xbox_360);
                    Garage_Combo_B.SelectedIndex = 0;
                    Garage_Combo_B.EndUpdate();
                }
                catch
                {
                    MessageBox.Show("Please Select A Preset Before Clicking");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add car");
            }
        }






        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == Car_Injector_Tab)
            {

            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are You Sure You'd Like To Remove All Cars From Save File?", "Warning! Empty Out All Cars In Save!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Save_Game_Structure.Clear_All_Car_Data(ref Data, Xbox_360);
                    MessageBox.Show("All Cars And Their Data Have Been Removed!");
                    PC_Checksum_Fixer.Update_Label(Data, ref Header_Data_CRC_Value_L, ref File_Data_CRC_Value_L, ref Header_CRC_Value_L, ref License_ID_Value_L, ref File_MD5_Hash_Value_L, ref Game_MD5_Hash_Value_L, Xbox_360);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unabled To Complete Request!");
                }

            }
        }

        private void Fix_Hashes_Bttn_Click(object sender, EventArgs e)
        {
            if (Data.Length != 0x40000)
            {
                PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref Data, Xbox_360);
            }
            PC_Checksum_Fixer.Update_Label(Data, ref Header_Data_CRC_Value_L, ref File_Data_CRC_Value_L, ref Header_CRC_Value_L, ref License_ID_Value_L, ref File_MD5_Hash_Value_L, ref Game_MD5_Hash_Value_L, Xbox_360);
            foreach (Control c in groupBox4.Controls)
            {
                if (c is Label l)
                {
                    // 'l' is your Label variable here
                    l.ForeColor = Color.Black;
                }
            }
        }

        private void Refresh_Save_Bttn_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Refreshing Save Will Undo Any Progress Already Made In The Save Editor. Are You Sure You'd Like To Continue?", "Refresh Save Warning:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.Yes)
            {
                Data = File.ReadAllBytes(path);
                UnChanged_File = File.ReadAllBytes(path);
                Data = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(UnChanged_File, ref Data);
                if (_22114455_Builder.Validate_Save(Data, Xbox_360))
                {
                    Data_Table = _22114455_Builder.ReRead_Data_Table(Data, Xbox_360);
                    // _22114455_Builder.Compare_Decompressed_Data(Data, Xbox_360);
                    //Data_Table = new byte[Helper_Functions.ReadInt32(Data, 0x20, Xbox_360) + 0x2C];
                    // = _22114455_Builder.Read_22114455_Container(Data, Data_Table, Xbox_360);
                    //Array.Resize(ref Data_Table, _22114455_Builder.Compare_Decompressed_Data(Data, Xbox_360));

                    // Array.Resize(ref Data_Table, Data.Length - (Helper_Functions.ReadInt32(Data, 0x20, Xbox_360) + 0x2C));
                    //Profile_Editor PE = new Profile_Editor(ref Data, ref Data_Table, ref UnChanged_File, ref path);
                    //PE.Show();
                    Currently_Select_Car_ComboB.Items.Clear();
                    Currently_Select_Car_ComboB.Items.AddRange(Reading_Car_Data_To_UI.Populate_Master_Car_List(Data, Xbox_360));
                    Reading_Car_Data_To_UI.Profile_Editor_Populate_UI(ref Data, ref Data_Table, ref Unchanged, ref path, ref Preset_Riders_Combo_Box, ref Neville_CB, ref Sal_CB, ref Niki_CB, ref Yumi_CB, ref Colin_CB, ref Samson_CB, ref Alias_TB, ref Crew_TB, ref Money_TB, ref Get_Out_Of_Jail_Marker_NUP, ref Strike_Marker_NUP, ref Nev_RB, ref Sal_RB, ref Nikki_RB, ref Collin_RB, ref Samson_RB, ref Yumi_RB, ref Strikes_Allowed_NUP, ref Current_Strikes_NUP, ref Car_Heat_Level_L, ref Bounty_L, ref Times_Evaded_L, ref Times_Caught_L, ref Speeding_NUP, ref Excessive_Speeding_NUP, ref Reckless_Driving_NUP, ref Raming_Police_Vehicle_NUP, ref Hit_N_Run_NUP, ref Damage_To_Property_NUP, ref Avoiding_Arrest_NUP, ref Driving_Off_Road_NUP, ref Total_Cost_For_Infactions_L, ref Garage_Combo_B, ref Car_Lot_Combo_B, ref All_Available_Cars_ComboB, ref File_Path_TB, ref Garage_Theme_Combo_B, ref Currently_Selected_Car_Combobox, ref Crew_Member_1_Combobox, ref Crew_Member_2_Combobox, ref Crew_Member_3_Combobox, Xbox_360);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_1_Combobox, Crew_Member_1_Label, 0);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_2_Combobox, Crew_Member_2_Label, 1);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_3_Combobox, Crew_Member_3_Label, 2);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Currently_Select_Car_ComboB, null, 3);

                   
                }
            }
        }


        private void Load_New_Save_Bttn_Click(object sender, EventArgs e)
        {
            UnChanged_File = new byte[1];
            path = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Data, ref Xbox_360, path);
            if (path != "")
            {
                foreach (Control c in tabControl1.Controls)
                {
                    if (c == tabPage1)
                    {
                        c.Enabled = true;
                        foreach (Control con in groupBox3.Controls)
                        {

                            con.Enabled = true;
                        }
                    }
                    c.Enabled = true;
                }
                //Data = File.ReadAllBytes(path);
                //UnChanged_File = File.ReadAllBytes(path);
                Data = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(UnChanged_File, ref Data);
                Data_Table = _22114455_Builder.ReRead_Data_Table(Data, Xbox_360);
                if (_22114455_Builder.Validate_Save(Data, Xbox_360) == true)
                {
                    /* _22114455_Builder.Compare_Decompressed_Data(Data, Xbox_360);
                     Data_Table = new byte[Helper_Functions.ReadInt32(Data, 0x20, Xbox_360) + 0x2C];
                     Data_Table = _22114455_Builder.Read_22114455_Container(Data, Data_Table, Xbox_360);

                     Array.Resize(ref Data_Table, _22114455_Builder.Compare_Decompressed_Data(Data, Xbox_360));

                     Array.Resize(ref Data_Table, Data.Length - (Helper_Functions.ReadInt32(Data, 0x20, Xbox_360) + 0x2C));
                     //Profile_Editor PE = new Profile_Editor(ref Data, ref Data_Table, ref UnChanged_File, ref path);
                     //PE.Show(); */
                    Currently_Select_Car_ComboB.Items.Clear();
                    Currently_Select_Car_ComboB.Items.AddRange(Reading_Car_Data_To_UI.Populate_Master_Car_List(Data, Xbox_360));
                    Reading_Car_Data_To_UI.Profile_Editor_Populate_UI(ref Data, ref Data_Table, ref Unchanged, ref path, ref Preset_Riders_Combo_Box, ref Neville_CB, ref Sal_CB, ref Niki_CB, ref Yumi_CB, ref Colin_CB, ref Samson_CB, ref Alias_TB, ref Crew_TB, ref Money_TB, ref Get_Out_Of_Jail_Marker_NUP, ref Strike_Marker_NUP, ref Nev_RB, ref Sal_RB, ref Nikki_RB, ref Collin_RB, ref Samson_RB, ref Yumi_RB, ref Strikes_Allowed_NUP, ref Current_Strikes_NUP, ref Car_Heat_Level_L, ref Bounty_L, ref Times_Evaded_L, ref Times_Caught_L, ref Speeding_NUP, ref Excessive_Speeding_NUP, ref Reckless_Driving_NUP, ref Raming_Police_Vehicle_NUP, ref Hit_N_Run_NUP, ref Damage_To_Property_NUP, ref Avoiding_Arrest_NUP, ref Driving_Off_Road_NUP, ref Total_Cost_For_Infactions_L, ref Garage_Combo_B, ref Car_Lot_Combo_B, ref All_Available_Cars_ComboB, ref File_Path_TB, ref Garage_Theme_Combo_B, ref Currently_Selected_Car_Combobox, ref Crew_Member_1_Combobox, ref Crew_Member_2_Combobox, ref Crew_Member_3_Combobox, Xbox_360);
                    Reading_Car_Data_To_UI.Profile_Editor_Populate_UI(ref Data, ref Data_Table, ref Unchanged, ref path, ref Preset_Riders_Combo_Box, ref Neville_CB, ref Sal_CB, ref Niki_CB, ref Yumi_CB, ref Colin_CB, ref Samson_CB, ref Alias_TB, ref Crew_TB, ref Money_TB, ref Get_Out_Of_Jail_Marker_NUP, ref Strike_Marker_NUP, ref Nev_RB, ref Sal_RB, ref Nikki_RB, ref Collin_RB, ref Samson_RB, ref Yumi_RB, ref Strikes_Allowed_NUP, ref Current_Strikes_NUP, ref Car_Heat_Level_L, ref Bounty_L, ref Times_Evaded_L, ref Times_Caught_L, ref Speeding_NUP, ref Excessive_Speeding_NUP, ref Reckless_Driving_NUP, ref Raming_Police_Vehicle_NUP, ref Hit_N_Run_NUP, ref Damage_To_Property_NUP, ref Avoiding_Arrest_NUP, ref Driving_Off_Road_NUP, ref Total_Cost_For_Infactions_L, ref Garage_Combo_B, ref Car_Lot_Combo_B, ref All_Available_Cars_ComboB, ref File_Path_TB, ref Garage_Theme_Combo_B, ref Currently_Selected_Car_Combobox, ref Crew_Member_1_Combobox, ref Crew_Member_2_Combobox, ref Crew_Member_3_Combobox, Xbox_360);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_1_Combobox, Crew_Member_1_Label, 0);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_2_Combobox, Crew_Member_2_Label, 1);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_3_Combobox, Crew_Member_3_Label, 2);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Currently_Selected_Car_Combobox, null, 3);
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            else
            {
                foreach (Control c in tabControl1.Controls)
                {
                    if (c == tabPage1)
                    {
                        c.Enabled = true;
                        foreach (Control con in groupBox3.Controls)
                        {
                            if (con == Open_File_Bttn)
                            {
                                con.Enabled = true;
                            }
                            else
                            {
                                con.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        c.Enabled = false;
                    }
                }
            }

        }




        private void Open_File_Bttn_Click(object sender, EventArgs e)
        {

            path = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Data, ref Xbox_360, path);
            if (path != "")
            {
                foreach (Control c in tabControl1.Controls)
                {
                    if (c == tabPage1)
                    {
                        c.Enabled = true;
                        foreach (Control con in groupBox3.Controls)
                        {

                            con.Enabled = true;
                        }
                    }
                    c.Enabled = true;

                }
                //Data = File.ReadAllBytes(path);
                //UnChanged_File = File.ReadAllBytes(path);
                Data = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(UnChanged_File, ref Data);

                if (_22114455_Builder.Validate_Save(Data, Xbox_360))
                {
                    Data_Table = _22114455_Builder.ReRead_Data_Table(Data, Xbox_360);
                    Currently_Select_Car_ComboB.Items.Clear();
                    Currently_Select_Car_ComboB.Items.AddRange(Reading_Car_Data_To_UI.Populate_Master_Car_List(Data, Xbox_360));
                    Reading_Car_Data_To_UI.Profile_Editor_Populate_UI(ref Data, ref Data_Table, ref Unchanged, ref path, ref Preset_Riders_Combo_Box, ref Neville_CB, ref Sal_CB, ref Niki_CB, ref Yumi_CB, ref Colin_CB, ref Samson_CB, ref Alias_TB, ref Crew_TB, ref Money_TB, ref Get_Out_Of_Jail_Marker_NUP, ref Strike_Marker_NUP, ref Nev_RB, ref Sal_RB, ref Nikki_RB, ref Collin_RB, ref Samson_RB, ref Yumi_RB, ref Strikes_Allowed_NUP, ref Current_Strikes_NUP, ref Car_Heat_Level_L, ref Bounty_L, ref Times_Evaded_L, ref Times_Caught_L, ref Speeding_NUP, ref Excessive_Speeding_NUP, ref Reckless_Driving_NUP, ref Raming_Police_Vehicle_NUP, ref Hit_N_Run_NUP, ref Damage_To_Property_NUP, ref Avoiding_Arrest_NUP, ref Driving_Off_Road_NUP, ref Total_Cost_For_Infactions_L, ref Garage_Combo_B, ref Car_Lot_Combo_B, ref All_Available_Cars_ComboB, ref File_Path_TB, ref Garage_Theme_Combo_B, ref Currently_Selected_Car_Combobox, ref Crew_Member_1_Combobox, ref Crew_Member_2_Combobox, ref Crew_Member_3_Combobox, Xbox_360);
                    Crew_Member_1_Combobox.Items.Clear();
                    Crew_Member_1_Combobox.Items.AddRange(Reading_Car_Data_To_UI.Master_Car_List);
                    Reading_Car_Data_To_UI.Profile_Editor_Populate_UI(ref Data, ref Data_Table, ref Unchanged, ref path, ref Preset_Riders_Combo_Box, ref Neville_CB, ref Sal_CB, ref Niki_CB, ref Yumi_CB, ref Colin_CB, ref Samson_CB, ref Alias_TB, ref Crew_TB, ref Money_TB, ref Get_Out_Of_Jail_Marker_NUP, ref Strike_Marker_NUP, ref Nev_RB, ref Sal_RB, ref Nikki_RB, ref Collin_RB, ref Samson_RB, ref Yumi_RB, ref Strikes_Allowed_NUP, ref Current_Strikes_NUP, ref Car_Heat_Level_L, ref Bounty_L, ref Times_Evaded_L, ref Times_Caught_L, ref Speeding_NUP, ref Excessive_Speeding_NUP, ref Reckless_Driving_NUP, ref Raming_Police_Vehicle_NUP, ref Hit_N_Run_NUP, ref Damage_To_Property_NUP, ref Avoiding_Arrest_NUP, ref Driving_Off_Road_NUP, ref Total_Cost_For_Infactions_L, ref Garage_Combo_B, ref Car_Lot_Combo_B, ref All_Available_Cars_ComboB, ref File_Path_TB, ref Garage_Theme_Combo_B, ref Currently_Selected_Car_Combobox, ref Crew_Member_1_Combobox, ref Crew_Member_2_Combobox, ref Crew_Member_3_Combobox, Xbox_360);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_1_Combobox, Crew_Member_1_Label, 0);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_2_Combobox, Crew_Member_2_Label, 1);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Crew_Member_3_Combobox, Crew_Member_3_Label, 2);
                    Reading_Car_Data_To_UI.Populate_Selected_Combobox(Data, Xbox_360, Currently_Selected_Car_Combobox, null, 3);
                    

                }
            }
            else
            {
                foreach (Control c in tabControl1.Controls)
                {
                    if (c == tabPage1)
                    {
                        c.Enabled = true;
                        foreach (Control con in groupBox3.Controls)
                        {
                            if (con == Open_File_Bttn)
                            {
                                con.Enabled = true;
                            }
                            else
                            {
                                con.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        private void Preset_Riders_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void JDLZ_Compressor_Bttn_Click(object sender, EventArgs e)
        {
            byte[] Huff = new byte[] { 0x46, 0x46, 0x55, 0x48, 0x01, 0x10, 0x00, 0x00, 0xD8, 0x34, 0x00, 0xD, 0x00, 0x00, 0x00, 0x0C, 0x30, 0xFB, 0x00, 0x34, 0xD8, 0x01, 0xD2, 0x20, 0x03, 0x4D, 0xA6, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Huff = Huffer.Huff_Decoder(Huff, Helper_Functions.ReadInt32(Huff, 8, true));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create the dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the default file name and extension
            saveFileDialog.FileName = "DataTable.dat";
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";

            // Show the dialog and check if the user clicked "Save"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                // Your code to save the DataTable goes here
                File.WriteAllBytes(filePath, Data_Table);
            }
        }

        private void Inject_JDLZ_Bttn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "DataTable.dat";
            ofd.DefaultExt = "dat";
            ofd.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";
            byte[] New_Table;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                // Your code to save the DataTable goes here
                Data_Table = new byte[File.ReadAllBytes(filePath).Length];
                Array.Copy(File.ReadAllBytes(filePath), Data_Table, File.ReadAllBytes(filePath).Length);
               
                //Data_Table = _22114455_Builder.ReRead_Data_Table(Data, Xbox_360);

                Reading_Car_Data_To_UI.Profile_Editor_Populate_UI(ref Data, ref Data_Table, ref Unchanged, ref path, ref Preset_Riders_Combo_Box, ref Neville_CB, ref Sal_CB, ref Niki_CB, ref Yumi_CB, ref Colin_CB, ref Samson_CB, ref Alias_TB, ref Crew_TB, ref Money_TB, ref Get_Out_Of_Jail_Marker_NUP, ref Strike_Marker_NUP, ref Nev_RB, ref Sal_RB, ref Nikki_RB, ref Collin_RB, ref Samson_RB, ref Yumi_RB, ref Strikes_Allowed_NUP, ref Current_Strikes_NUP, ref Car_Heat_Level_L, ref Bounty_L, ref Times_Evaded_L, ref Times_Caught_L, ref Speeding_NUP, ref Excessive_Speeding_NUP, ref Reckless_Driving_NUP, ref Raming_Police_Vehicle_NUP, ref Hit_N_Run_NUP, ref Damage_To_Property_NUP, ref Avoiding_Arrest_NUP, ref Driving_Off_Road_NUP, ref Total_Cost_For_Infactions_L, ref Garage_Combo_B, ref Car_Lot_Combo_B, ref All_Available_Cars_ComboB, ref File_Path_TB, ref Garage_Theme_Combo_B, ref Currently_Selected_Car_Combobox, ref Crew_Member_1_Combobox, ref Crew_Member_2_Combobox, ref Crew_Member_3_Combobox, Xbox_360);
                Crew_Member_1_Combobox.Items.Clear();
                Crew_Member_1_Combobox.Items.AddRange(Reading_Car_Data_To_UI.Master_Car_List);
                Crew_Member_1_Combobox.SelectedIndex = (byte)Populate_Crew_Selected_Cars[0];
                Crew_Member_1_Label.Text = Populate_Crew_Selected_Cars[4].ToString().Replace("characters/", "");
                Crew_Member_2_Combobox.Items.Clear();
                Crew_Member_2_Combobox.Items.AddRange(Reading_Car_Data_To_UI.Master_Car_List);
                Crew_Member_2_Combobox.SelectedIndex = (byte)Populate_Crew_Selected_Cars[1];
                Crew_Member_2_Label.Text = Populate_Crew_Selected_Cars[5].ToString().Replace("characters/", "");
                Crew_Member_3_Combobox.Items.Clear();
                Crew_Member_3_Combobox.Items.AddRange(Reading_Car_Data_To_UI.Master_Car_List);
                Crew_Member_3_Combobox.SelectedIndex = (byte)Populate_Crew_Selected_Cars[2];
                Crew_Member_3_Label.Text = Populate_Crew_Selected_Cars[6].ToString().Replace("characters/","");
                Currently_Selected_Car_Combobox.Items.Clear();
                Currently_Selected_Car_Combobox.Items.AddRange(Reading_Car_Data_To_UI.Master_Car_List);
                Currently_Selected_Car_Combobox.SelectedIndex = (byte)Populate_Crew_Selected_Cars[3];
                //if (JDLZ.Length < Data_Table.Length)
                //{
                //MessageBox.Show("Please Make Sure You've Injected The Proper File");
                //}
            }
        }

        private void Complete_World_Map_CB_CheckedChanged(object sender, EventArgs e)
        {
            // Razer savegame A48 is wolfs carlot unlocked
        }

        private void JDLZ_Decompressor_Bttn_Click(object sender, EventArgs e)
        {
            // Create the dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            byte[] JDLZ_File;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                // Your code to save the DataTable goes here

                byte[] buffer;
                buffer = File.ReadAllBytes(filePath);
                List<byte> file = new List<byte>(buffer);
                int pos = 0;
                /*if (Helper_Functions.ReadUInt32(file.ToArray(),pos, false) == 0x4A444C5A)
                {
                    buffer = Helper_Functions.ReadUInt32(file, pos)
                }
                buffer = new byte[Helper_Functions.ReadUInt32(file.ToArray(), pos + 8, false)];
                JDLZ_File = JDLZ_Removing_Globals.decompress(file, false); */
                //{ string filePath = saveFileDialog.FileName;
                // Your code to save the DataTable goes here
                //File.WriteAllBytes(filePath, JDLZ_File);
                //MessageBox.Show("Please Make Sure You've Injected The Proper File");
                //}
            }

            // Set the default file name and extension


            // Show the dialog and check if the user clicked "Save"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Garage_Theme_Combo_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            Garage_Combo_B.BeginUpdate();
            switch (Garage_Theme_Combo_B.SelectedIndex)
            {
                //Main Menu/My Cars
                case 0:
                    {
                        pictureBox1.Image = Properties.Resources.Main_Menu;
                        break;
                    }
                //Muscle Safe House
                case 1:
                    {
                        pictureBox1.Image = Properties.Resources.Muscle_Garage;
                        break;
                    }
                //Tuner Safe House
                case 2:
                    {
                        pictureBox1.Image = Properties.Resources.Tuner_Garage;
                        break;
                    }
                //Exodic Safe House
                case 3:
                    {
                        pictureBox1.Image = Properties.Resources.Exodic_Garage;
                        break;
                    }
                //Tutorial Safe House
                case 4:
                    {
                        pictureBox1.Image = Properties.Resources.First_WareHouse;
                        break;
                    }

                //Tutorial CarLot
                case 5:
                    {
                        pictureBox1.Image = Properties.Resources.Showroom;
                        break;
                    }

                //Muscle Carlot
                case 6:
                    {
                        pictureBox1.Image = Properties.Resources.Muscle_Carlot;
                        break;
                    }
                //Tuner Carlot
                case 7:
                    {
                        pictureBox1.Image = Properties.Resources.Tuner_CarLot;
                        break;
                    }
                //Exotic Carlot
                case 8:
                    {
                        pictureBox1.Image = Properties.Resources.Exotic_CarLot;
                        break;
                    }

                //Mazda Dealer
                case 9:
                    {
                        pictureBox1.Image = Properties.Resources.Mazda_Dealership;
                        break;
                    }

            }
            Garage_Theme_Combo_B.EndUpdate();
        }

        private void Currently_Select_Car_ComboB_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

        }
    }
}

