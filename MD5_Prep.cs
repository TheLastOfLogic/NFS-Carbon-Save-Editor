using EA_MD5_hasher;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MD5_Prep
{
	public static byte[] Update_Game(ref byte[] Data)
	{
		byte[] input = new byte[0xFFF0];
        int Pos = Find_Game(Data);
		Buffer.BlockCopy(Data,Pos,input,0,input.Length);
		input = MD5.Create().ComputeHash(input);
		Buffer.BlockCopy(input, 0, Data, Pos - 0x10, input.Length);
		return input;
	}

    public static byte[] Update_Mod_Pow( ref byte[] Data, bool Xbox)
    {
        byte[] input = new byte[0x45FF0];
        
        Buffer.BlockCopy(Data, Find_Mod_Pow_Magic(Data, Xbox)+0x10, input, 0, input.Length);
        byte[] Message = new byte[0x40];
        Buffer.BlockCopy(MD5.Create().ComputeHash(input), 0, Message, 0, 0x10);
        byte[] buffer = new byte[0x10];
        Buffer.BlockCopy(Message, 0, buffer, 0, buffer.Length);
        for (int i = 0, p = 0x10; i < 3; i++, p += 0x10)
        {
            
            Buffer.BlockCopy(MD5.Create().ComputeHash(buffer), 0, Message, p, 0x10);
            Buffer.BlockCopy(Message, p, buffer, 0, 0x10);
        }
        Get_Registry_Key.Fix_Get_Key(Data, Message);
        return buffer;
    }

    public static Int32 Find_Mod_Pow_Magic(byte[] Data, bool Xbox)
    {
        return Platform_Car_Converter.Find_Game_Pos(Data, Xbox) - 0x50;
        
    }
	

    public static Int32 Find_Game(byte[] Data)
    {
        for (int i = 0; i < Data.Length - 1; i++)
        {
            if ((Char)Data[i] == 'e' && (Char)Data[i + 1] == 'm' && (Char)Data[i + 2] == 'a' && (Char)Data[i + 3] == 'G')
            {
                return i;
            }
            else if ((Char)Data[i] == 'G' && (Char)Data[i + 1] == 'a' && (Char)Data[i + 2] == 'm' && (Char)Data[i + 3] == 'e')
            {
                return i;
            }
        }
        return 0;
    }
}
