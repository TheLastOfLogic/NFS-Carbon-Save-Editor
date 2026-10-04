using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher.NFS_ProStreet
{
    internal class Data_Base
    {
        //version is 1/3/7 (1 basegame) (3 Update) (7 Update W/DLC) //Location at 0x2B File Starting at 0
        public static Byte Save_Version;

        public static bool Currupt;
        public static UInt32 Money;
        public static Byte Totalled_Marker;
        public static Byte Free_Car_Marker;
        public static Byte Fix_Damage_Marker;


        public static byte Offset;


        public static string Grab_Save_Version(byte[] Data, ref byte Version)
        {
            Save_Version = Data[0x2B];
            switch(Save_Version)
            {
                default:
                    {
                       return "Current Version: Base Version";
                    }
                case 3:
                    {
                        return "Current Version: Updated Version";
                    }
                case 7:
                    {
                        return "Current Version: Updated Version With DLC";
                    }
            }
        }

        public static string Compare_Hashes(byte[] buffer, byte[] Data)
        {
            try
            {
                byte[] temp_buffer = new byte[0x10];
                if (Data.Length == 0x505C)
                {
                    Offset = 0x5C;
                }
                else if (Data.Length == 0x0B6838)
                {
                    Offset = 0x38;
                }
                Buffer.BlockCopy(Data, Offset, temp_buffer, 0, 0x10);
                if (buffer.SequenceEqual(temp_buffer))
                {
                    Currupt = false;
                    return "Save Main Checksum Okay!";
                }
                else
                {
                    Currupt = true;
                    return "Saves Broken!";
                }
            }
            catch
            {
                return("Unable to Compare Hashes");
            }
        }


    }
}
