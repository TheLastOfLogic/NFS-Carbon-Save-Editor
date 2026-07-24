using md5_hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    public static class PC_Checksum_Fixer
    {
        public static void Fix_Save_Game_PC_Only(ref byte[] Data, bool Xbox)
        {
            if (Check_PC_Save(Data))
            {
                Xbox = false;
                Get_Registry_Key.SyncPhysicalKeyToVirtualStore(ref Data, Xbox);
                MD5_Prep.Update_Game(ref Data);
                MD5_Prep.Update_Mod_Pow(ref Data, Xbox);
                EA_CRC32.UpdateHashes(Data, Xbox);
            }
            else
            {
                Xbox = true;
                MD5_Prep.Update_Game(ref Data);
                if (Data.Length != 0x40000)
                {
                    EA_CRC32.UpdateHashes(Data, Xbox);
                }
            }

        }

        public static bool Check_PC_Save(byte[] Data)
        {
            for (int i = 0; i < Data.Length - 1; i++)
            {
                if ((Char)Data[i] == 0x32 && (Char)Data[i + 1] == 0x30 && (Char)Data[i + 2] == 0x43 && (Char)Data[i + 3] == 0x4D)
                {

                    return true;
                }
            }
            return false;

        }

        public static void Update_Label(byte[] Data_OG, ref Label Checksum_1, ref Label Checksum_2, ref Label Checksum_3, ref Label License, ref Label MD5, ref Label MD5_Game, bool Xbox)
        {
            try
            {
                byte[] Data = new byte[Data_OG.Length];
                Buffer.BlockCopy(Data_OG, 0, Data, 0, Data.Length);
                if (Data.Length != 0x40000)
                {
                    Fix_Save_Game_PC_Only(ref Data, Xbox);

                    if (Xbox == true)
                    {
                        Checksum_1.Enabled = true;
                        Checksum_2.Enabled = true;
                        Checksum_3.Enabled = true;
                        Checksum_1.Text = Helper_Functions.ReadUInt32(Data_OG, 0x10, Xbox).ToString("X");
                        Checksum_2.Text = Helper_Functions.ReadUInt32(Data_OG, 0x14, Xbox).ToString("X");
                        Checksum_3.Text = Helper_Functions.ReadUInt32(Data_OG, 0x18, Xbox).ToString("X");
                        License.Text = "N/A";
                        License.Enabled = false;
                        MD5.Text = "N/A";
                        MD5.Enabled = false;
                        // Helper_Functions.

                        string MD5_String_Check = "";
                        MD5_Game.Text = "";
                        for (int i = 0; i < 0x10; i++)
                        {
                            MD5_Game.Text += Data_OG[i + 0x3C].ToString("X2");
                            MD5_String_Check += Data[i + 0x3C].ToString("X2");
                        }


                        if (Helper_Functions.ReadUInt32(Data_OG, 0x10, Xbox) != Helper_Functions.ReadUInt32(Data, 0x10, Xbox))
                        {
                            Checksum_1.ForeColor = Color.Red;
                        }
                        else
                        {
                            Checksum_1.ForeColor = Color.Black;
                        }

                        if (Helper_Functions.ReadUInt32(Data_OG, 0x14, Xbox) != Helper_Functions.ReadUInt32(Data, 0x14, Xbox))
                        {
                            Checksum_2.ForeColor = Color.Red;
                        }
                        else
                        {
                            Checksum_2.ForeColor = Color.Black;
                        }

                        if (Helper_Functions.ReadUInt32(Data_OG, 0x18, Xbox) != Helper_Functions.ReadUInt32(Data, 0x18, Xbox))
                        {
                            Checksum_3.ForeColor = Color.Red;
                        }
                        else
                        {
                            Checksum_3.ForeColor = Color.Black;
                        }

                        if (!MD5_Game.Text.Contains(MD5_String_Check))
                        {
                            MD5_Game.ForeColor = Color.Red;
                        }
                        else
                        {
                            MD5_Game.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        License.Enabled = true;
                        MD5.Enabled = true;
                        Checksum_1.Enabled = true;
                        Checksum_2.Enabled = true;
                        Checksum_3.Enabled = true;
                        Checksum_1.Text = Helper_Functions.ReadUInt32(Data_OG, 0x10, Xbox).ToString("X2");
                        Checksum_2.Text = Helper_Functions.ReadUInt32(Data_OG, 0x14, Xbox).ToString("X2");
                        Checksum_3.Text = Helper_Functions.ReadUInt32(Data_OG, 0x18, Xbox).ToString("X2");
                        License.Text = "";
                        MD5.Text = "";
                        MD5_Game.Text = "";
                        string License_C_String = "";
                        string PC_MD5_C_String = "";
                        string MD5_Game_C_String = "";

                        for (int i = 0; i < 0x14; i++)
                        {
                            License.Text += (char)Data_OG[0x3C + i];
                            License_C_String += (char)Data[0x3C + i];
                        }
                        for (int m = 0; m < 0x10; m++)
                        {
                            MD5.Text += Data_OG[0x2C + m].ToString("X2");
                            PC_MD5_C_String += Data[0x2C + m].ToString("X2");
                            MD5_Game.Text += Data_OG[0x6C + m].ToString("X2");
                            MD5_Game_C_String += Data[0x6C + m].ToString("X2");

                        }
                        if (Helper_Functions.ReadUInt32(Data_OG, 0x10, Xbox) != Helper_Functions.ReadUInt32(Data, 0x10, Xbox))
                        {
                            Checksum_1.ForeColor = Color.Red;
                        }
                        else
                        {
                            Checksum_1.ForeColor = Color.Black;
                        }

                        if (Helper_Functions.ReadUInt32(Data_OG, 0x14, Xbox) != Helper_Functions.ReadUInt32(Data, 0x14, Xbox))
                        {
                            Checksum_2.ForeColor = Color.Red;
                        }
                        else
                        {
                            Checksum_2.ForeColor = Color.Black;
                        }

                        if (Helper_Functions.ReadUInt32(Data_OG, 0x18, Xbox) != Helper_Functions.ReadUInt32(Data, 0x18, Xbox))
                        {
                            Checksum_3.ForeColor = Color.Red;
                        }
                        else
                        {
                            Checksum_3.ForeColor = Color.Black;
                        }

                        if (!License.Text.Contains(License_C_String))
                        {
                            License.ForeColor = Color.Red;
                        }
                        else
                        {
                            License.ForeColor = Color.Black;
                        }

                        if (!MD5.Text.Contains(PC_MD5_C_String))
                        {
                            MD5.ForeColor = Color.Red;
                        }
                        else
                        {
                            MD5.ForeColor = Color.Black;
                        }

                        if (!MD5_Game.Text.Contains(MD5_Game_C_String))
                        {
                            MD5_Game.ForeColor = Color.Red;
                        }
                        else
                        {
                            MD5_Game.ForeColor = Color.Black;
                        }


                    }
                }
                else
                {
                    Checksum_1.Text = "N/A";
                    Checksum_1.Enabled = false;
                    Checksum_2.Text = "N/A";
                    Checksum_2.Enabled = false;
                    Checksum_3.Text = "N/A";
                    Checksum_3.Enabled = false;
                    License.Text = "N/A";
                    License.Enabled = false;
                    MD5.Text = "N/A";
                    MD5.Enabled = false;
                    // Helper_Functions.
                   // MD5_Prep.Update_Game(ref Data);
                    string MD5_String_Check = "";
                    MD5_Game.Text = "";
                    for (int i = 0; i < 0x10; i++)
                    {
                        MD5_Game.Text += Data_OG[i + 0x20].ToString("X2");
                        MD5_String_Check += Data[i + 0x20].ToString("X2");
                    }


                    

                    if (!MD5_Game.Text.Contains(MD5_String_Check))
                    {
                        MD5_Game.ForeColor = Color.Red;
                    }
                    else
                    {
                        MD5_Game.ForeColor = Color.Black;
                    }
                
            }

            }
            catch
            {
                MessageBox.Show("Please Make Sure Your Save Is Loaded!");
            }
        }
    }

}
