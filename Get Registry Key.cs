using Microsoft.Win32;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    internal class Get_Registry_Key
    {

        public static string CRC32_Hash_To_String(byte[] Data, byte Hash_Index)
        {
            int Pos = 0;
            int Pos_End = 0;
            string Hash = "";
            switch (Hash_Index)
            {
                case 0:
                    {
                        Pos = 0x10;
                        Pos_End = 0x13;
                        break;
                    }
                case 1:
                    {
                        Pos = 0x14;
                        Pos_End = 0x17;
                        break;
                    }
                case 2:
                    {
                        Pos = 0x18;
                        Pos_End = 0x1B;
                        break;
                    }
            }
            for (int i = Pos; i <= Pos_End; i++)
            {
                Hash += Data[i].ToString("X");
            }
            return Hash;
        }
        public static string SyncPhysicalKeyToVirtualStore(ref byte[] PC_Save_Data, bool Xbox)
        {
            
                // 1. The Physical "L" Path (System-wide 32-bit node)
                string systemPath = @"SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed Carbon\ergc";

                // 2. The Virtual "X" Path (Your specific user's redirected hive)
                // We use Registry.CurrentUser because the OS maps your SID here automatically
                string vStorePath = @"Software\Classes\VirtualStore\MACHINE\SOFTWARE\WOW6432Node\Electronic Arts\Electronic Arts\Need for Speed Carbon\ergc";

                try
                {
                    // STEP A: Get the Admin/Physical Key (The "L")
                    string adminKey = "";
                    using (var hklm32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                    {
                        using (var key = hklm32.OpenSubKey(systemPath))
                        {
                            adminKey = key?.GetValue("")?.ToString();
                        }
                    }

                    if (string.IsNullOrEmpty(adminKey))
                    {
                        MessageBox.Show("Could not find the Physical (L) key to copy.");
                        return "";
                    }

                    // STEP B: Write it to the Virtual Store (The "X")
                    // No Admin rights needed for this part!
                    using (RegistryKey vKey = Registry.CurrentUser.CreateSubKey(vStorePath))
                    {
                        if (vKey != null)
                        {
                            vKey.SetValue("", adminKey);
                            //byte[] bob = BitConverter.GetBytes(adminKey);
                            MessageBox.Show("Successfully moved L-Key " + " " + adminKey + "to the Virtual Store.");
                            Buffer.BlockCopy(Encoding.ASCII.GetBytes(adminKey), 0, PC_Save_Data, MD5_Prep.Find_Mod_Pow_Magic(PC_Save_Data, Xbox) + 0x10, Encoding.ASCII.GetBytes(adminKey).Length);
                            return adminKey;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sync failed");
                    return "";
                }
                return "Failed to Go Through Channels";
            
        }

        public static string Get_PC_Save_Key(byte[] PC_Save_Data)
        {
            if (PC_Save_Data[0] == 0x32 && PC_Save_Data[1] == 0x30 && PC_Save_Data[2] == 0x43 && PC_Save_Data[3] == 0x4D)
            {
                string Save_License = "";
                byte[] temp = new byte[0x14];
                Buffer.BlockCopy(PC_Save_Data, 0x3C, temp, 0, 0x14);
                for (int i = 0; i < temp.Length; i++)
                {
                    Save_License += (char)temp[i];
                }
                return Save_License;
            }
            else
            {
                MessageBox.Show("Not a PC Save");
                return "N/A";
            }
            return "N/A";
        }


        /*public static Color Compare_PC_MD5(byte[] PC_Save_Data)
        {
            if (PC_Save_Data[0] == 0x32 && PC_Save_Data[1] == 0x30 && PC_Save_Data[2] == 0x43 && PC_Save_Data[3] == 0x4D)
            {
                TextBox txt = new TextBox();
                string MD5_Value = "";
                for (int i = 0x2C; i < 0x3C; i++)
                {
                    MD5_Value += PC_Save_Data[i].ToString("X");
                }
               /* if (Fix_Get_Key(txt, PC_Save_Data) == MD5_Value)
                {
                    return Color.Black;
                }
                else
                {
                    return Color.Red;
                } 
            }
            else
            {
                return Color.Black;
            }
        } */
        public static string Fix_Get_Key( byte[] PC_Save_Data, byte[]messageBytes)
        {
            
                byte[] pcExponent = new byte[] 
                {
                    0xE1, 0xD0, 0xBD, 0x60, 0x53, 0xD2, 0x29, 0xD1, 0x8B, 0x4F, 0x6F, 0x67, 0x6E, 0x8A, 0x20, 0x45,
                    0xB8, 0x52, 0x51, 0x06, 0xAA, 0x9D, 0x21, 0xAA, 0xA0, 0xE2, 0x5C, 0x90, 0xAE, 0xA2, 0x99, 0xE9,
                    0xDC, 0x37, 0xFF, 0xBF, 0x7F, 0xCE, 0x5E, 0x13, 0xBF, 0x1E, 0x4D, 0xED, 0xC2, 0x4E, 0x4D, 0x8C,
                    0xA8, 0x70, 0x6D, 0x0C, 0x1F, 0xD7, 0x49, 0xB1, 0xF2, 0x75, 0xE5, 0x89, 0x55, 0x28, 0x29, 0x28

                };

               /* messageBytes = new byte[] 
                {
                    //this is actually dynamic
                    /*0x70, 0xF4, 0xED, 0x89, 0x6C, 0xB9, 0x9F, 0x43, 0x55, 0x12, 0x04, 0x97, 0x64, 0x0F, 0x65, 0x96,
                    0xDE, 0x98, 0xD0, 0xFA, 0x58, 0x5F, 0x4E, 0x50, 0xC7, 0xC4, 0x6B, 0xE9, 0x44, 0x21, 0xBE, 0xF5,
                    0x4B, 0xBD, 0xE5, 0x81, 0x61, 0xD0, 0x0F, 0x8A, 0x7F, 0xDA, 0x59, 0x09, 0x55, 0x59, 0x63, 0x5A,
                    0x53, 0x79, 0x07, 0xB2, 0x46, 0x74, 0x04, 0xAA, 0x9A, 0x4D, 0xC2, 0xD4, 0xB8, 0x0D, 0x6B, 0xFD
                }; */

                byte[] pcModulus = new byte[] 
                {
                    0x0D, 0x96, 0x0B, 0x86, 0xE5, 0xAB, 0x50, 0x4A, 0x7E, 0x6B, 0x40, 0xD4, 0xE4, 0x4B, 0x28, 0x87,
                    0xB9, 0xC0, 0xDE, 0xC6, 0x94, 0xDF, 0x8D, 0x9B, 0x96, 0x0E, 0xA2, 0xA0, 0xA0, 0x4E, 0xF3, 0x07,
                    0xE8, 0x1D, 0xC8, 0x47, 0xBC, 0x28, 0x13, 0x69, 0xCF, 0x82, 0xFE, 0x83, 0x29, 0xE7, 0x98, 0xFC,
                    0x57, 0x5E, 0x36, 0xAA, 0x8A, 0xE0, 0x8F, 0x47, 0x99, 0xD0, 0x03, 0x34, 0xBB, 0x0E, 0x62, 0xEF
                };


                //Exponent
                BigInteger m = new BigInteger(messageBytes, isUnsigned: true, isBigEndian: false);
                BigInteger n = new BigInteger(pcModulus, isUnsigned: true, isBigEndian: false);
                BigInteger d = new BigInteger(pcExponent, isUnsigned: true, isBigEndian: false);

            // Run the math
            Buffer.BlockCopy(BigInteger.ModPow(m, d, n).ToByteArray(isUnsigned: false, isBigEndian: false), 0, PC_Save_Data, 0x2C, 0x10);

            MessageBox.Show(BitConverter.ToString(BigInteger.ModPow(m, d, n).ToByteArray(isUnsigned: false, isBigEndian: false)));
            //MessageBox.Show(result.ToString("X"));
            //Buffer.BlockCopy(result.ToByteArray(isUnsigned: false, isBigEndian: false),0,PC_Save_Data,0x2C,0x20);

            // 2. Ensure it is exactly 64 bytes (Padding if the result is smaller)


            return "";
                //MessageBox.Show(hexOutput);
            }
            
        }
    }
    