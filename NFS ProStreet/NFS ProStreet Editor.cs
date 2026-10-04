using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher.NFS_ProStreet
{
    public partial class NFS_ProStreet_Editor : Form
    {
        public NFS_ProStreet_Editor()
        {
            InitializeComponent();
        }



        private void UpdateComboBoxCategory(string category)
        {
            Grab_Racers_Combo_Box.BeginUpdate(); // Prevents flickering while updating items
            Grab_Racers_Combo_Box.Items.Clear();

            switch (category)
            {
                case "Base Opp":
                    Grab_Racers_Combo_Box.Items.AddRange(Car_Presets.Racers.Where(r => r.Tag.StartsWith("RACERNAME_")).Select(r => r.Name).ToArray());
                    break;

                case "Booster Opp":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("BOOST_RACERNAME_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Elite Opp":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("ELITENAME_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "DDay Opp":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("DDAY_OPP_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Drag Entourage":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("DRAG_ENTOURAGE_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Drift Entourage":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("DRIFT_ENTOURAGE_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Grip Entourage":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("GRIP_ENTOURAGE_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Speed Entourage":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("SC_ENTOURAGE_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Shadow Entourage":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.StartsWith("SHOWDOWN_ENTOURAGE_"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "Kings":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Where(r => r.Tag.EndsWith("King"))
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;

                case "All":
                    Grab_Racers_Combo_Box.Items.AddRange(
                        Car_Presets.Racers
                            .Select(r => r.Name)
                            .ToArray()
                    );
                    break;
            }
            if (radioButton2.Enabled == false)
            {
                var BoosterRacerNames = Car_Presets.Racers
                .Where(r => r.Tag != null && r.Tag.StartsWith("BOOST_RACERNAME_"))
                .Select(r => r.Name)
                .ToList();

                foreach (var name in BoosterRacerNames)
                {
                    Grab_Racers_Combo_Box.Items.Remove(name);
                }
            }
            Grab_Racers_Combo_Box.EndUpdate();

            // Automatically select the first item if the list isn't empty
            if (Grab_Racers_Combo_Box.Items.Count > 0)
            {
                Grab_Racers_Combo_Box.SelectedIndex = 0;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rb = sender as RadioButton;

            // CheckedChanged fires twice (once for uncheck, once for check).
            // Only execute when a radio button becomes checked.
            if (rb != null && rb.Checked)
            {
                UpdateComboBoxCategory(rb.Text);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Driver Label: " + Car_Presets.Racers.FirstOrDefault(r => r.Name == Grab_Racers_Combo_Box.SelectedItem.ToString())?.Tag;
            if (Grab_Racers_Combo_Box.SelectedItem != null)
            {
                string selectedItem = Grab_Racers_Combo_Box.SelectedItem.ToString();

                // Find racer by Tag or Name
                var racer = Car_Presets.Racers.FirstOrDefault(r => r.Tag == selectedItem || r.Name == selectedItem);

                if (racer != null)
                {
                    Grab_Car_Model_ComboBox.Items.Clear();

                    // Check if the racer has no assigned races or resolved car models
                    if (racer.AssignedRaces.Length == 0 || racer.CarModel.Length == 0)
                    {
                        // Set message on label
                        label1.Text = "There is no cars for this racer";

                        // Optional: Add a disabled/placeholder item or leave blank
                        Grab_Car_Model_ComboBox.Items.Add("No Races Found");
                        Grab_Car_Model_ComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        // Populate ComboBox with valid car models
                        Grab_Car_Model_ComboBox.Items.AddRange(racer.CarModel);
                        Grab_Car_Model_ComboBox.SelectedIndex = 0;

                        // Update label with assigned cars
                        label1.Text = "Car Model: " + string.Join(", ", racer.CarModel);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Data_Base.Save_Game = new byte[0];
                byte[] Hash_Buffer = new byte[0x10];
                byte[] Save_Hash_Buffer = new byte[0x10];
                byte Version_Number;

                bool Xbox = true;
                
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Set initial directory and title
                    openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    openFileDialog.Title = "Select File";

                    // Filter for OFD files, XML, or All Files

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the chosen file path
                        Data_Base.path = openFileDialog.FileName;

                        // Example: Load or process the file
                        Data_Base.Save_Game = File.ReadAllBytes(Data_Base.path);
                        if (Data_Base.Save_Game.Length == 0x000B6838)
                            MD5_Prep.Update_Game_PS(ref Data_Base.Save_Game);
                    }
                }
                radioButton1.Checked = true;
                Hash_Buffer = NFS_ProStreet_MD5.Xbox_360_Mod_Pow_test(ref Data_Base.Save_Game, true);
                label4.Text = Data_Base.Compare_Hashes(Hash_Buffer, Data_Base.Save_Game);
                label3.Text = Data_Base.Grab_Save_Version(Data_Base.Save_Game, ref Data_Base.Save_Version);
                switch (Data_Base.Save_Version)
                {
                    case 1:
                        {
                            radioButton12.Checked = true;
                            radioButton2.Enabled = false;
                            break;
                        }
                    case 3:
                        {
                            radioButton13.Checked = true;
                            radioButton2.Enabled = false;
                            break;
                        }
                    case 7:
                        {
                            radioButton14.Checked = true;
                            radioButton2.Enabled = true;
                            break;
                        }


                }

            }
            catch
            {
                radioButton1.Checked = true;
                label4.Text = "Checksum Unknown!";
                label3.Text = "Version Unknown!";
                radioButton2.Enabled = false;

                MessageBox.Show("Unable To Process Further");
            }
        }

        private void Grab_Car_Model_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pos = 0;
            uint[] Car_Hashs = new uint[400];
            Car_Hashs = Data_Base.Grab_Random_Cars(Car_Presets.All_Presets);
            Data_Base.Save_Game = Car_Structure.Write_400_Randoms(Data_Base.Save_Game, Car_Hashs, pos);
            //Car_Structure.Find_Car_Structure(Data_Base.Save_Game, pos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Buffer.BlockCopy(NFS_ProStreet_MD5.Xbox_360_Mod_Pow_test(ref Data_Base.Save_Game, true), 0, Data_Base.Save_Game, 0x38, 0x10);
            File.WriteAllBytes(Data_Base.path, Data_Base.Save_Game);
        }
    }
}
