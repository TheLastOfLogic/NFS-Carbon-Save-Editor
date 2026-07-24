using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher
{
    internal class _22114455_Builder
    {
        public static byte[] Complete_Decompressed_Data;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct _22114455_Reader
        {
            public UInt32 Magic_22114455;             // 22 11 44 55
            public Int32 DecompressedSize;  // The size after extraction
            public Int32 Size_Of_Container;    // The size of the raw JDLZ data + 22114455 Header
            public Int32 Position;              // read jdlz 3 at 0, then jdlz 1 at 0x8000 after jdlz decompressed data, and then go to jdlz 2 where after adding 0x8000*2 from both jdlz data, read here
            public Int32 PrevTotalSize;     // Current Position.
            public UInt32 Padding;           // Alignment padding (00 00 00 00)
            public UInt32 JDLZ__HUFF_Magic;  //JDLZ_Huff_Magic
            public UInt32 Version;           //Version
            public Int32 Decompressed_Length; //Decompressed Length
            public Int32 Compressed_Length; //Compressed Length With Header JDLZ only, HUFF looks to be just Data Length.
            public byte[] Data;
            public byte[] File_Extraction;
            public byte[] Uncompressed_Data;
            public byte[] Complete_Decompressed_Data;
        }
        public struct Container_22114455
        {
            public UInt32 Magic;
            public Int32 Decompressed_Size;
            public Int32 Container_Length;
            public Int32 Position_Of_Decompressed_Entry; //if we refer to Position as 0 for file one with 0x8000 in length, and position 0x8000 for second file with 0x8000 in length, and dynamic Position for 3rd file
            public Int32 Previous_Container_Lengths; //if there are 3 containers, add the previous container length to this value of all of the previous containers before this. like 0 for file 1, container 1 length goes here, container 3 will have container 1 and 2 length added here
            public Int32 Padding; //literally 0
        }


        public struct JDLZ_HUFF_Structure
        {
            public UInt32 Magic;
            public UInt32 Version;
            public UInt32 Decompressed_Size;
            public UInt32 Compressed_Size;
            public byte[] Compressed_Data;
        }

       // public 
        

        public static int Compare_Decompressed_Data(byte[] Data, bool Xbox)
        {
            Int32 Container_Start_Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
            Int32 Total_Decompressed_Length = Data.Length - Container_Start_Pos;
            Int32 Current_Decompressed_Length = 0;
            try
            {
                
                do
                {
                    if (Helper_Functions.ReadUInt32(Data, Container_Start_Pos, Xbox) == 0x55441122)
                    {
                        Current_Decompressed_Length +=  Helper_Functions.ReadInt32(Data, Container_Start_Pos + 4, Xbox);
                        Container_Start_Pos += Helper_Functions.ReadInt32(Data, Container_Start_Pos + 8, Xbox);
                        
                    }
                }
                while ((Total_Decompressed_Length > Current_Decompressed_Length));
                return Current_Decompressed_Length;
            }
            catch
            {
                MessageBox.Show("Unable to find Data, Has this File Been Tampered With? Contact Dev for help.");
                return Current_Decompressed_Length;
            }
           
        }

        public static byte[] Read_22114455_Container(byte[] Data, byte[] Decompressed_Data_Block, bool Xbox)
        {
            Container_22114455 C_22114455 = new Container_22114455();
            JDLZ_HUFF_Structure JDLZ_HUFF = new JDLZ_HUFF_Structure();
            
                JDLZ_HUFF.Magic = 0x5A4C444A;
                C_22114455.Magic = 0x55441122;
                JDLZ_HUFF.Version = 0x00001002;
            
            Int32 Decompression_Length_Total = 0;
            Int32 Container_Start_Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
            Decompressed_Data_Block = new byte[Compare_Decompressed_Data(Data, Xbox)];
            if (C_22114455.Magic == Helper_Functions.ReadUInt32(Data,Container_Start_Pos, Xbox))
            {
                
                do
                {                    
                    C_22114455.Decompressed_Size = Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x4, Xbox);
                    C_22114455.Container_Length = Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x8, Xbox);
                    C_22114455.Position_Of_Decompressed_Entry = Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0xC, Xbox);
                    byte[] Temp_Decompressed_Compressed_File = new byte[C_22114455.Container_Length - 0x18];
                    Buffer.BlockCopy(Data, Container_Start_Pos + 0x18, Temp_Decompressed_Compressed_File, 0, Temp_Decompressed_Compressed_File.Length);
                    if (Helper_Functions.ReadUInt32(Temp_Decompressed_Compressed_File,0,Xbox) == 0x46465548)
                    {
                        /*Helper_Functions.WriteUInt32(Temp_Decompressed_Compressed_File, 0, 0x46465548, false);
                        Helper_Functions.WriteUInt32(Temp_Decompressed_Compressed_File, 8, Helper_Functions.ReadUInt32(Temp_Decompressed_Compressed_File, 0x8, true), false);
                        Helper_Functions.WriteUInt32(Temp_Decompressed_Compressed_File, 0xC, Helper_Functions.ReadUInt32(Temp_Decompressed_Compressed_File, 0xc, true), false); */

                        Temp_Decompressed_Compressed_File = Huffer.Huff_Decoder(Temp_Decompressed_Compressed_File);
                       
                        //Huff_Decoder.Unpack_Huff_Data(Temp_Decompressed_Compressed_File, 0, Xbox);
                        
                    }
                    else 
                    {
                        Temp_Decompressed_Compressed_File = JDLZ_Removing_Globals.decompress(Temp_Decompressed_Compressed_File, Xbox);
                    }
                        
                    Buffer.BlockCopy(Temp_Decompressed_Compressed_File, 0, Decompressed_Data_Block, C_22114455.Position_Of_Decompressed_Entry, C_22114455.Decompressed_Size);
                    Decompression_Length_Total += Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x4, Xbox);
                    Container_Start_Pos += C_22114455.Container_Length;
                }
                while (Decompressed_Data_Block.Length != Decompression_Length_Total);
                return Decompressed_Data_Block;
            }



                return Decompressed_Data_Block;
        }

        public static byte[] Write_22114455_Container(ref byte[] Data, byte[] Decompressed_Data, bool OEM, bool Xbox)
        {
            
            Container_22114455 C_22114455 = new Container_22114455();
            JDLZ_HUFF_Structure JDLZ_HUFF = new JDLZ_HUFF_Structure();
            
                JDLZ_HUFF.Magic = 0x5A4C444A;
                C_22114455.Magic = 0x55441122;
                JDLZ_HUFF.Version = 0x00001002;

            Int32 Container_Start_Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
                
            if ( OEM == false) //Compare_Decompressed_Data(Data) == Decompressed_Data.Length &&
            {
                JDLZ_HUFF.Compressed_Data = JDLZ_Removing_Globals.Compresser(Decompressed_Data, Xbox);
                C_22114455.Decompressed_Size = Decompressed_Data.Length;
                C_22114455.Container_Length = JDLZ_HUFF.Compressed_Data.Length + 0x18; //0x10 for the header, and 0x18 for 22114455 header
                C_22114455.Position_Of_Decompressed_Entry = 0;
                C_22114455.Previous_Container_Lengths = 0;
                C_22114455.Padding = 0;
                Helper_Functions.WriteUInt32(Data, Container_Start_Pos, C_22114455.Magic, Xbox);
                Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x4, C_22114455.Decompressed_Size, Xbox);
                Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x8, C_22114455.Container_Length, Xbox);
                Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0xC, C_22114455.Position_Of_Decompressed_Entry, Xbox);
                Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x10, C_22114455.Previous_Container_Lengths, Xbox);
                Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x14, C_22114455.Padding, Xbox);
                Buffer.BlockCopy(JDLZ_HUFF.Compressed_Data, 0, Data, Container_Start_Pos + 0x18, JDLZ_HUFF.Compressed_Data.Length);
                Array.Fill(Data, (byte)0, Container_Start_Pos + C_22114455.Container_Length, Data.Length - (Container_Start_Pos + C_22114455.Container_Length));
            }
            else //if (Compare_Decompressed_Data(Data) == Decompressed_Data.Length && OEM == true)
            {     
                C_22114455.Padding = 0;
                byte[] Decompress_Compressed_Data;
                Int32 Processed_Length = 0;

                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                C_22114455.Decompressed_Size = 0x8000;
                                C_22114455.Position_Of_Decompressed_Entry = 0x8000;
                                break;
                            }
                        case 1:
                            {
                                C_22114455.Decompressed_Size = Decompressed_Data.Length - 0x10000;
                                C_22114455.Position_Of_Decompressed_Entry = 0x10000;
                                break;
                            }
                        case 2:
                            {
                                C_22114455.Decompressed_Size = 0x8000;
                                C_22114455.Position_Of_Decompressed_Entry = 0x0;
                                break;
                            }
                    }

                            Decompress_Compressed_Data = new byte[C_22114455.Decompressed_Size];
                            Buffer.BlockCopy(Decompressed_Data, C_22114455.Position_Of_Decompressed_Entry, Decompress_Compressed_Data, 0, C_22114455.Decompressed_Size);
                            File.WriteAllBytes(Form1.File_Path + "12345", Decompress_Compressed_Data);
                            JDLZ_HUFF.Compressed_Data = JDLZ_Removing_Globals.Compresser(Decompress_Compressed_Data, Xbox);
                            C_22114455.Container_Length = (((JDLZ_HUFF.Compressed_Data.Length + 3) & ~3) + 0x18); //0x10 for the header, and 0x18 for 22114455 header
                            C_22114455.Previous_Container_Lengths = Processed_Length;
                            Processed_Length += C_22114455.Container_Length;
                            Helper_Functions.WriteUInt32(Data, Container_Start_Pos, C_22114455.Magic, Xbox);
                            Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x4, C_22114455.Decompressed_Size, Xbox);
                            Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x8, C_22114455.Container_Length, Xbox);
                            Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0xC, C_22114455.Position_Of_Decompressed_Entry, Xbox);
                            Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x10, C_22114455.Previous_Container_Lengths, Xbox);
                            Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x14, C_22114455.Padding, Xbox);
                            Buffer.BlockCopy(JDLZ_HUFF.Compressed_Data, 0, Data, Container_Start_Pos + 0x18, JDLZ_HUFF.Compressed_Data.Length);
                            Container_Start_Pos += C_22114455.Container_Length;
                    
                }
            }
            /* else
             {
                 MessageBox.Show("Unable to Make Changes to Save. Contact Dev");
             } */
            return Data;
        }
        
    }
}
