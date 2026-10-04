using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            byte[] Save_Game = new byte[0];
            byte[] Data = new byte[0];
            byte[] Hash_Buffer = new byte[0x10];
            byte[] Save_Hash_Buffer = new byte[0x10];

            bool Xbox = true;
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set initial directory and title
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Title = "Select File";

                // Filter for OFD files, XML, or All Files

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the chosen file path
                    path = openFileDialog.FileName;

                    // Example: Load or process the file
                    Data = File.ReadAllBytes(path);
                }
            }
            Hash_Buffer = NFS_ProStreet_MD5.Xbox_360_Mod_Pow_test(ref Data, true);
            label4.Text = Data_Base.Compare_Hashes(Hash_Buffer, Data);
            label3.Text = Data_Base.Grab_Save_Version(Data);
        }

        private void Grab_Car_Model_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
