using EA_MD5_hasher;
using System;

public class Xbox_360_Con_Handler
{

    public static byte[] Xbox_360_Save_Extractor(byte[] Xbox_360_Save_Data, ref byte[] Save_Data)
    {
        if (Xbox_360_Save_Data.Length > 0x0004602C)
        {
            Save_Data = new byte[0x0004602C];
            Buffer.BlockCopy(Xbox_360_Save_Data, 0xD000, Save_Data, 0, Save_Data.Length);
            return Save_Data;
        }
        else if (Xbox_360_Save_Data.Length == 0x0004602C)
        {
            Save_Data = new byte[0x0004602C];
            Save_Data = (byte[])Xbox_360_Save_Data.Clone();
            return Save_Data;
        }
        else if (Xbox_360_Save_Data.Length == 0x40000)
        {
            Save_Data = new byte[0x40000];
            Save_Data = (byte[])Xbox_360_Save_Data.Clone();
            return Save_Data;
        }
        return null;
    }
    public static byte[] Merge_Back_Into_Xbox360_Save(ref byte[] Save_File, byte[] Save_Data)
    {
        if (Save_File.Length > 0x0004602C)
        {
            //Save_Data = new byte[0x0004602C];
            Buffer.BlockCopy(Save_Data, 0x0, Save_File, 0xD000, Save_Data.Length);
            Xbox360_Resigner.Rehash(ref Save_File);
            return Save_File;
        }
        else
        {
            return Save_Data;
        }
    }
    
}

