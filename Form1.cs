using md5_hash;
using System.Diagnostics.Metrics;
using System.IO;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static string File_Path;

        public static uint RotateLeft(uint value, int shift)
        {
            // Ensure that the shift amount is within the range of 0-31 for a 32-bit integer
            shift &= 31;

            // Perform the rotate left operation
            return (value << shift) | (value >> (32 - shift));
        }

        public static uint RotateRight(uint value, int shift)
        {
            // Ensure that the shift amount is within the range of 0-31 for a 32-bit integer
            shift &= 31;

            // Perform the rotate right operation
            return (value >> shift) | (value << (32 - shift));
        }

        public static byte[] Find_Game;
        public static byte[] UnChanged_File;
        private void button1_Click(object sender, EventArgs e)
        {
            File_Path = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Find_Game, ref Save_Form.Xbox_360, File_Path);
            UnChanged_File = File.ReadAllBytes(File_Path);
            Find_Game = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(UnChanged_File, ref Find_Game);
            //Save_Game_Structure.Clear_All_Car_Data(Find_Game, 0xC + Platform_Car_Converter.Find_Car_Strct_Pos(Find_Game, Save_Form.Xbox_360), Save_Form.Xbox_360);
            MD5_Prep.Update_Game(ref Find_Game);
            EA_CRC32.UpdateHashes(Find_Game, Save_Form.Xbox_360);
            int bob = Platform_Car_Converter.Find_Car_Strct_Pos(Find_Game, Save_Form.Xbox_360);
            Platform_Car_Converter.Read_Car_Table_Legnth(Find_Game, Find_Game, Save_Form.Xbox_360);
            Save_Game_Structure.Fill_Customization_Slot(Find_Game, Platform_Car_Converter.Find_Car_Strct_Pos(Find_Game, Save_Form.Xbox_360), Save_Form.Xbox_360);
            Xbox_360_Con_Handler.Merge_Back_Into_Xbox360_Save(ref UnChanged_File, Find_Game);
            File.WriteAllBytes(File_Path, Find_Game);
        }





        private void button2_Click(object sender, EventArgs e)
        {

            byte[] temp;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {


                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    /*//MessageBox.Show(Helper_Functions.Hash("r8").ToString("X2"));
                    // Get the File_Pathof specified file

                    // Example: logic to check for the v1.4 executable
                    // Read input file
                    File_Path = ofd.FileName;
                    //byte[] temp;
                    byte[] temp2 = new byte[JDLZ_Removing_Globals.Input.Length + 3];
                    temp2 = File.ReadAllBytes(File_Path);
                    JDLZ.Input = new byte[temp2.Length + 3];
                    Buffer.BlockCopy(temp2, 0, JDLZ.Input, 0, temp2.Length);
                    //JDLZ.Input = File.ReadAllBytes(path);
                    uint bob = JDLZ.Compresser((uint)temp2.Length);
                    MessageBox.Show(bob.ToString("X2"));
                    temp = new byte[bob];
                    Buffer.BlockCopy(JDLZ.Output, 0, temp, 0, (int)temp.Length);
                    File.WriteAllBytes(Path.Combine(File_Path + "3"), temp);*/
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string file_path;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                //ofd.InitialDirectory = "c:\\"; // Set default folder
                //ofd.Filter = "NFS Carbon Executable (NFSC.exe)|NFSC.exe|All files (*.*)|*.*";
                //ofd.FilterIndex = 1;
                // ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Get the File_Pathof specified file
                    File_Path = ofd.FileName;
                    //Get_Registry_Key.SyncPhysicalKeyToVirtualStore();
                    // Example: logic to check for the v1.4 executable

                    Find_Game = File.ReadAllBytes(File_Path);
                    Call_2cfe60.Call_02D3F20(Find_Game, true);
                    Call_2cfe60.Call_02D3F20(Find_Game, false);
                    /*Helper_Functions.UIntToBytes(Find_Game, 0x2C, A);
                    Helper_Functions.UIntToBytes(Find_Game, 0x30, B);
                    Helper_Functions.UIntToBytes(Find_Game, 0x34, C);
                    Helper_Functions.UIntToBytes(Find_Game, 0x38, D); */
                    //EA_CRC32.EA_CRC32_1();
                    //EA_CRC32.UpdateHashes(Find_Game);
                    //getHash(data);
                    File.WriteAllBytes(File_Path, Find_Game);
                    //Save_Form sf = new Save_Form();
                    //sf.Show();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] temp = new byte[0];
            string money = "";
            string Alias = "";
            File_Path = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref temp, ref Save_Form.Xbox_360, File_Path);
          
            _22114455_Builder.Compare_Decompressed_Data(temp, Save_Form.Xbox_360);
            byte[] tester = new byte[Helper_Functions.ReadInt32(temp, 0x20, Save_Form.Xbox_360) + 0x2C];
            tester = _22114455_Builder.Read_22114455_Container(temp, tester, Save_Form.Xbox_360);
            Array.Resize(ref tester, _22114455_Builder.Compare_Decompressed_Data(temp, Save_Form.Xbox_360));
           
            Array.Resize(ref tester, temp.Length - (Helper_Functions.ReadInt32(temp, 0x20, Save_Form.Xbox_360) + 0x2C));
            //Profile_Editor PE = new Profile_Editor(ref temp,ref tester, ref UnChanged_File, ref File_Path);
            //PE.Show();
            //Save_Game_Structure.Find_Crew_Members(ref temp, Save_Form.Xbox_360, 4);
            File.WriteAllBytes(Path.Combine(File_Path + " tester"), tester);
            //Save_Game_Structure.Unlock_Entire_Map(ref temp, Save_Form.Xbox_360);
            //File.WriteAllBytes(Path.Combine(File_Explorer.Open_File_Read_Data+ "check AAA data"), temp);
            temp = _22114455_Builder.Write_22114455_Container(ref temp, tester, true, Save_Form.Xbox_360);
            Helper_Functions.Grab_Position_Anchor_For_Car_Structure(temp, Save_Form.Xbox_360);
            //byte custom_Slot = 0xFF;
            //custom_Slot = Save_Game_Structure.Find_Custimization_Slot(ref temp, Platform_Car_Converter.Find_Car_Strct_Pos(temp, Save_Form.Xbox_360) + 0xFAC, 2, Save_Form.Xbox_360);
            //MessageBox.Show(Save_Game_Structure.Find_Empty_Car_Slot(ref temp, Platform_Car_Converter.Find_Car_Strct_Pos(temp, Save_Form.Xbox_360), custom_Slot, Save_Form.Xbox_360).ToString("X2"));
            PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref temp, Save_Form.Xbox_360);
            EA_CRC32.UpdateHashes(temp, Save_Form.Xbox_360);
            Xbox_360_Con_Handler.Merge_Back_Into_Xbox360_Save(ref UnChanged_File, temp);
            
            //File.WriteAllBytes(File_Path, UnChanged_File);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] Input = null;
            byte[] Output;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {


                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //this currently finds and writes 22114455 data and doesn't make it to compressor before the file is changed.
                    File_Path = ofd.FileName;
                    Input = File.ReadAllBytes(File_Path);
                }
            }
            
            Output = JDLZ_Removing_Globals.Compresser(Input, Save_Form.Xbox_360);
            File.WriteAllBytes(File_Path + " Compressed", Output);
        }

        private void JDLZ_Decompressor_Click(object sender, EventArgs e)
        {
            byte[] Input = null;
            byte[] Output;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //this currently finds and writes 22114455 data and doesn't make it to compressor before the file is changed.
                    File_Path = ofd.FileName;
                    Input = File.ReadAllBytes(File_Path);
                    Xbox360_Resigner.Rehash(ref Input);
                }
            }
            Save_Form.Xbox_360 = true;
            Output = JDLZ_Removing_Globals.decompress(Input, Save_Form.Xbox_360);
            if (Output != null)
            {
                File.WriteAllBytes(File_Path + " decompressed", Output);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            File_Path = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Find_Game, ref Save_Form.Xbox_360, File_Path);
            //Get_Registry_Key.SyncPhysicalKeyToVirtualStore(Find_Game);
            // Example: logic to check for the v1.4 executable
            Find_Game = File.ReadAllBytes(File_Path);
            //Save_Game_Structure.Clear_All_Car_Data(Find_Game);
            //Get_Registry_Key.SyncPhysicalKeyToVirtualStore(ref Find_Game);
            //MD5_Prep.Update_Game(ref Find_Game);
            //MD5_Prep.Update_Mod_Pow(ref Find_Game);
            if (Helper_Functions.ReadUInt16(Find_Game, 0x26AEC, Save_Form.Xbox_360) > 0x8000)
            {
                //comboBox1.SelectedIndex = (Helper_Functions.ReadUInt16(Find_Game, 0x26AEC, Save_Form.Xbox_360) - 0x8000) ;
            }
            else
            {
                //comboBox1.SelectedIndex = Helper_Functions.ReadUInt16(Find_Game, 0x26AEC, Save_Form.Xbox_360);
            }
            PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref Find_Game, Save_Form.Xbox_360);
            EA_CRC32.UpdateHashes(Find_Game, Save_Form.Xbox_360);
            File.WriteAllBytes(File_Path, Find_Game);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //trade vehicles
            string money = "";
            string Alias = "";
            
            string File_Path_1 = Extract_File_Data.Text;
            string File_Path_2 = Write_File_Data.Text;
           
            bool Xbox_1 = checkBox1.Checked;
            bool Xbox = checkBox2.Checked;

            byte[] Data_1 = File.ReadAllBytes(File_Path_1);
            byte[] Data = File.ReadAllBytes(File_Path_2);
            byte[] Xbox_360_Container = File.ReadAllBytes(File_Path_2);
            //File_Path_1 = File_Explorer.Open_File_Read_Data(ref Data, ref Xbox);
            //File_Path_2 = File_Explorer.Open_File_Read_Data(ref Data_1, ref Xbox_1);
            //MessageBox.Show(Save_Game_Structure.Find_Empty_Car_Slot(ref Data, Platform_Car_Converter.Find_Car_Strct_Pos(Data, Save_Form.Xbox_360), 05, Save_Form.Xbox_360).ToString("X2"));
            try
            {
                Data_1 = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(Data_1, ref Data_1);
                Data = Xbox_360_Con_Handler.Xbox_360_Save_Extractor(Data, ref Data);
                //Save_Game_Structure.Carrer_Converter(ref Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Vehicles(Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Custimizations(Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Convert_Garage(Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Convert_Parts_List( Data, Data_1, Xbox, Xbox_1);
                Platform_Car_Converter.Copy_Convert_Vinyls(ref Data, Data_1, Xbox, Xbox_1);
                Rebuild_11224455.Container_Converter(Data, Data_1, Xbox, Xbox_1);
                _22114455_Builder.Compare_Decompressed_Data(Data_1, Xbox_1);
                byte[] tester = new byte[Helper_Functions.ReadInt32(Data_1, 0x20, Xbox) + 0x2C];
                tester = _22114455_Builder.Read_22114455_Container(Data_1, tester, Xbox_1);
                
                //File.WriteAllBytes(Path.Combine(File_Path + " tester before"), tester);
                //File.WriteAllBytes(Path.Combine(File_Path + " tester before"), tester);
                //Read_Data_Table.Breaking_Down_Data(ref tester, null, null, null, Save_Form.Xbox_360);
                //Read_Data_Table.Breaking_Down_Data(ref tester, ref money, ref Alias, null, Xbox);
                Array.Resize(ref tester, Data.Length - (Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C));
                Data = _22114455_Builder.Write_22114455_Container(ref Data, tester, true, Xbox);
                PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref Data, Xbox);
                EA_CRC32.UpdateHashes(Data, Xbox);
                //Xbox_360_Con_Handler.Merge_Back_Into_Xbox360_Save(ref UnChanged_File, Data);
                // File.WriteAllBytes(File_Path, UnChanged_File);
                //PC_Checksum_Fixer.Fix_Save_Game_PC_Only(ref Data, Xbox);

                //957703527: remove this label and its contents for xbox 360 compatablitiy, or add it to the xbox 360 for compatiblity 
                //EA_CRC32.UpdateHashes(Data, Save_Form.Xbox_360);
                Data = Xbox_360_Con_Handler.Merge_Back_Into_Xbox360_Save(ref Xbox_360_Container, Data);
                File.WriteAllBytes(File_Path_2, Data);
            }
            catch
            {
                MessageBox.Show("No File Path Found!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            bool Xbox = false;
            byte[] Data = new byte[1];
            byte[] Data2 = new byte[1];
            //File_Path = File_Explorer.Open_File_Read_Data(ref Data, ref Xbox);
            // Data2 = Huff_Decoder.Unpack_Huff_Data(Data, (int)0x0, Xbox);
        }



        private void button8_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(File_Path))
            {
                Xbox_360_Con_Handler.Xbox_360_Save_Extractor(UnChanged_File, ref Find_Game);
                File.WriteAllBytes(File_Path, Find_Game);
            }
        }

        private void Grab_File_Path_1_Click(object sender, EventArgs e)
        {
            bool Xbox = false;
            Extract_File_Data.Text = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Find_Game, ref Xbox, Extract_File_Data.Text);
            checkBox1.Checked = Xbox;
            checkBox1.Enabled = false;
        }

        private void Grab_File_Path_2_Click(object sender, EventArgs e)
        {
            bool Xbox = false;
            Write_File_Data.Text = File_Explorer.Open_File_Read_Data(ref UnChanged_File, ref Find_Game, ref Xbox, Write_File_Data.Text);
            checkBox2.Checked = Xbox;
            checkBox2.Enabled = false;
        }


        // at BC is where the crew member array is BC 3 something 3 and all names need to be set for it to work
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BC
        //Green Guy
        //PC Save at 0x530 A3 3B 69 40 00 00 00 00 60 00 00 00 chaging the number 0x60 from whatever it is to 0x60 will unlock boss race. could be a 0x4

        //Wolf
        //Xbox 360 0x590 00 00 00 00 A9 38 29 79 00 00 00 00 04 00 00 00
        //0x5C0 00 00 00 00 79 29 38 A9 00 00 00 00 04 chnage the 04 to 0x60 to unlock wolf race

        //Xbox 360 Muscle Race War
        //0x5C0 04 00 00 00 27 18 20 28 00 00 00 00 04 00 00 00 the last number 4 is the trigger
        //Muscle Race War
        //0x5F0  04 00 00 00 28 20 18 27 00 00 00 00 60 00 00 00 that 0x60 is a 4 change to 0x60 for race wars


        //Xbox 360 Angies Race Unlocked
        //0x7A0 00 00 00 00 27 18 20 28 00 00 00 00 04 00 00 00
        //Angies Race Unlocked
        //0x7D0 00 00 00 00 28 20 18 27 00 00 00 00 60



        //0x4C4 Crew Member Set. Set Id to Crew Member
        //0x4BC BC 01 09 00 //01 crew members set, while one is how many you have available
        //characters/neville (hash == B00F935C)
        //characters/sal (hash == 3F3E465C)
        //characters/nikki (Hash == C9191F86)
        //characters/colin (Hash == A05C48E1)
        //characters/samson (Hahs == A58A7D2C)
        //characters/yumi (Hash == 014F80C4)
    }
}



