using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    public static class File_Explorer
    {
       // public static string path;

        public static string Open_File_Read_Data(ref byte[] Save_File, ref byte[] Data, ref bool Xbox, string path)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    Save_File = File.ReadAllBytes(path);
                    Xbox_360_Con_Handler.Xbox_360_Save_Extractor(Save_File, ref Data);
                    if (BitConverter.ToUInt32(Data, 0) == 0x3230434D)
                    {
                        Xbox = true;

                    }
                    else if (BitConverter.ToUInt32(Data, 0) == 0x4D433032)
                    {

                        Xbox = false;
                    }
                    else if(Data.Length == 0x40000)
                    {
                        Xbox = true;
                    }
                        return path;

                }
                else
                {
                    return path = "";
                }
            }
           
        }
    }
}
