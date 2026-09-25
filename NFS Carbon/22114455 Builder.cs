using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


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


        /*public static int Compare_D_Data(byte[] Data, bool Xbox)
        {
            Int32 Container_Start_Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
            byte count = 0;
            while (count < 2)
            {
                if (Helper_Functions.ReadUInt32(Data, Container_Start_Pos, Xbox) == 0x55441122)
                {
                    count++;
                    if (Helper_Functions.ReadInt32(Data, Container_Start_Pos + 4, Xbox) != Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x22, Xbox))
                    {
                        Helper_Functions.WriteInt32(Data, Container_Start_Pos + 4, Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x22, Xbox), Xbox);
                    }
                    Container_Start_Pos += Helper_Functions.ReadInt32(Data, Container_Start_Pos + 8, Xbox);
                    
                }
            } 
        } */




        public static string[] labels = new string[]
{
    "224118897:",
    "224118898:",
    "224118899:",
    "224118900:",
    "224118901:",
    "224118902:",
    "224118903:",
    "224118904:",
    "224118905:",
    "224118906:",
    "273712384:",
    "475001806:",
    "475001807:",
    "475001808:",
    "475001809:",
    "475001810:",
    "475001811:",
    "475001812:",
    "475001813:",
    "475001814:",
    "475001815:",
    "734155592:",
    "831388323:",
    "841929775:",
    "908757055:",
    "908757056:",
    "908757057:",
    "908757058:",
    "908757059:",
    "908757060:",
    "957703527:",
    "1423222527:",
    "1423222528:",
    "1423222529:",
    "1423222530:",
    "1423222531:",
    "1423222532:",
    "1423222533:",
    "1423222534:",
    "1423222535:",
    "1423222536:",
    "1463053520:",
    "1463053521:",
    "1463053522:",
    "1463053523:",
    "1463053524:",
    "1463053525:",
    "1463053526:",
    "1825086551:",
    "1880893935:",
    "1880893936:",
    "1880893937:",
    "1880893938:",
    "1880893939:",
    "1880893940:",
    "1880893941:",
    "1880893942:",
    "1880893943:",
    "1880893944:",
    "1880893968:",
    "1880893969:",
    "1880893970:",
    "1880893971:",
    "1880893972:",
    "1880893973:",
    "1880893974:",
    "1880893975:",
    "1880893976:",
    "1880893977:",
    "1880894001:",
    "1880894002:",
    "1880894003:",
    "1880894004:",
    "1880894005:",
    "1880894006:",
    "1880894007:",
    "1880894008:",
    "1880894009:",
    "1880894010:",
    "1880894034:",
    "1880894035:",
    "1880894036:",
    "1880894037:",
    "1880894038:",
    "1880894039:",
    "1880894040:",
    "1880894041:",
    "1880894042:",
    "1880894043:",
    "1880894067:",
    "1880894068:",
    "1880894069:",
    "1880894070:",
    "1880894071:",
    "1880894072:",
    "1880894073:",
    "1880894074:",
    "1880894075:",
    "1880894076:",
    "1880894100:",
    "1880894101:",
    "1880894102:",
    "1880894103:",
    "1880894104:",
    "1880894105:",
    "1880894106:",
    "1880894107:",
    "1880894108:",
    "1880894109:",
    "1880894133:",
    "1880894134:",
    "1880894135:",
    "1880894136:",
    "1880894137:",
    "1880894138:",
    "1880894139:",
    "1880894140:",
    "1880894141:",
    "1880894142:",
    "1880894166:",
    "1880894167:",
    "1880894168:",
    "1880894169:",
    "1880894170:",
    "1880894171:",
    "1880894172:",
    "1880894173:",
    "1880894174:",
    "1880894175:",
    "1880894199:",
    "1880894200:",
    "1880894201:",
    "1880894202:",
    "1880894203:",
    "1880894204:",
    "1880894205:",
    "1880894206:",
    "1880894207:",
    "1880894208:",
    "1880894232:",
    "1880894233:",
    "1880894234:",
    "1880894235:",
    "1880894236:",
    "1880894237:",
    "1880894238:",
    "1880894239:",
    "1880894240:",
    "1880894241:",
    "2141660592:",
    "2141660593:",
    "2141660594:",
    "2141660595:",
    "2141660596:",
    "2141660597:",
    "2141660598:",
    "2141660599:",
    "2141660600:",
    "2141660601:",
    "2141660625:",
    "2141660626:",
    "2155005931:",
    "2155005932:",
    "2155005933:",
    "2155005934:",
    "2155005935:",
    "2155005936:",
    "2268361667:",
    "2287685084:",
    "2340227757:",
    "2340227758:",
    "2353671616:",
    "2628986562:",
    "2675110292:",
    "2759083341:",
    "2790157791:",
    "2790157792:",
    "2790157793:",
    "2790157794:",
    "2790157795:",
    "2790157796:",
    "2790157797:",
    "2790157798:",
    "2790157799:",
    "2790157800:",
    "2790157824:",
    "2790157825:",
    "2790157826:",
    "2790157827:",
    "2790157828:",
    "2790157829:",
    "2790157830:",
    "2790157831:",
    "2790157832:",
    "2790157833:",
    "2790157857:",
    "2790157858:",
    "2790157859:",
    "2790157860:",
    "2790157861:",
    "2790157862:",
    "2790157863:",
    "2790157864:",
    "2790157865:",
    "2790157866:",
    "2790157890:",
    "2790157891:",
    "2790157892:",
    "2790157893:",
    "2790157894:",
    "2790157895:",
    "2790157896:",
    "2790157897:",
    "2790157898:",
    "2790157899:",
    "2790157923:",
    "2790157924:",
    "2790157925:",
    "2790157926:",
    "2790157927:",
    "2790157928:",
    "2790157929:",
    "2790157930:",
    "2790157931:",
    "2790157932:",
    "2790157956:",
    "2790157957:",
    "2790157958:",
    "2790157959:",
    "2790157960:",
    "2790157961:",
    "2790157962:",
    "2790157963:",
    "2790157964:",
    "2790157965:",
    "2790157989:",
    "2790157990:",
    "2790157991:",
    "2790157992:",
    "2790157993:",
    "2790157994:",
    "2790157995:",
    "2790157996:",
    "2790157997:",
    "2790157998:",
    "2790158022:",
    "2790158023:",
    "2790158024:",
    "2790158025:",
    "2790158026:",
    "2790158027:",
    "2790158028:",
    "2790158029:",
    "2790158030:",
    "2790158031:",
    "2790158055:",
    "2790158056:",
    "2790158057:",
    "2790158058:",
    "2790158059:",
    "2790158060:",
    "2790158061:",
    "2790158062:",
    "2790158063:",
    "2790158064:",
    "3061804230:",
    "3100956386:",
    "3100956387:",
    "3100956388:",
    "3100956389:",
    "3100956390:",
    "3100956391:",
    "3100956392:",
    "3100956393:",
    "3100956394:",
    "3100956395:",
    "3100956419:",
    "3111547832:",
    "3111547833:",
    "3111547834:",
    "3111547835:",
    "3111547836:",
    "3111547837:",
    "3111547838:",
    "3111547839:",
    "3111547840:",
    "3111547841:",
    "3287042375:",
    "3349505431:",
    "3349505432:",
    "3349505433:",
    "3349505434:",
    "3349505435:",
    "3349505436:",
    "3349505437:",
    "3349505438:",
    "3349505439:",
    "3349505440:",
    "3349505464:",
    "3349505465:",
    "3349505466:",
    "3349505467:",
    "3349505468:",
    "3349505469:",
    "3349505470:",
    "3349505471:",
    "3349505472:",
    "3349505473:",
    "3349505497:",
    "3349505498:",
    "3349505499:",
    "3349505500:",
    "3349505501:",
    "3349505502:",
    "3349505503:",
    "3349505504:",
    "3349505505:",
    "3349505506:",
    "3349505530:",
    "3349505531:",
    "3349505532:",
    "3349505533:",
    "3349505534:",
    "3391526480:",
    "3620598476:",
    "3620598477:",
    "3620598478:",
    "3620598479:",
    "3620598480:",
    "3620598481:",
    "3723220158:",
    "3723220159:",
    "3723220160:",
    "3723220161:",
    "3723220162:",
    "3723220163:",
    "3723220164:",
    "3893412391:",
    "3893412392:",
    "3893412393:",
    "3893412394:",
    "3893412395:",
    "3893412396:",
    "3893412397:",
    "3893412398:",
    "3893412399:",
    "3893412400:",
    "3896830729:",
    "3896830730:",
    "3896830731:",
    "3896830732:",
    "3897002937:",
    "3897002938:",
    "3897002939:",
    "3897002940:",
    "3897002941:",
    "3897002942:",
    "3897002943:",
    "3897002944:",
    "3897002945:",
    "3897002946:",
    "3928557400:",
    "3928557401:",
    "3928557402:",
    "3928557403:",
    "3969414527:",
    "3969414528:",
    "3969414529:",
    "3969414530:",
    "3969414531:",
    "3969414532:",
    "3969414533:",
    "3969414534:",
    "3969414535:",
    "3969414536:",
    "4016670512:",
    "4016670513:",
    "4016670514:",
    "4016670515:",
    "4016670516:",
    "4016670517:",
    "4016670518:",
    "4016670519:",
    "4016670520:",
    "4016670521:",
    "4047045418:",
    "4047045419:",
    "4047045420:",
    "4047045421:",
    "4047045422:",
    "4047045423:",
    "4047045424:",
    "4047045425:",
    "4047045426:",
    "4047045427:",
    "4047045451:",
    "4047045452:",
    "4047045453:",
    "4047045454:",
    "4047045455:",
    "4047045456:",
    "4047045457:",
    "4047045458:",
    "4047045459:",
    "4047045460:",
    "4047045484:",
    "4047045485:",
    "4047045486:",
    "4047045487:",
    "4047045488:",
    "4047045489:",
    "4047045490:",
    "4047045491:",
    "4047045492:",
    "4047045493:",
    "4116984261:",
    "4192354862:",
    "4192354863:",
    "4192354864:",
    "4192354865:",
    "4192354866:",
    "4192354867:",
    "4192354868:",
    "4192354869:",
    "4192354870:",
    "4192354871:",
    "4266316934:",
    "4266316935:",
    "4266316936:",
    "4266316937:",
    "4266316938:",
    "4266316939:",
    "4266316940:",
    "4266316941:",
    "4266316942:",
    "4266316943:",
};


       
public static byte[] ReRead_Data_Table(byte[] Data, bool Xbox)
        {
            byte[] Data_Table = null;
            if (Validate_Save(Data, Xbox) == true)
            {
                int Console = 1;
                if (Data.Length == 0x40000)
                {
                    Console = 2;
                }

                int Pos = 0;
                int Complete_Decompressed_Length = 0;

                if (Console == 1)
                {
                    Data_Table = new byte[Data.Length - (Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C)];
                    Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
                }
                else if (Console == 2)
                {
                    Data_Table = new byte[0x034B28];
                    Pos = 0x034B28;
                    Xbox = true;
                }

                for (int i = Pos; i < Data.Length;)
                {
                    if (Helper_Functions.ReadUInt32(Data, i, Xbox) == 0x55441122)
                    {
                        int decompressedSize = Helper_Functions.ReadInt32(Data, i + 4, Xbox);
                        int containerLength = Helper_Functions.ReadInt32(Data, i + 8, Xbox);
                        int targetOffset = Helper_Functions.ReadInt32(Data, i + 0xC, Xbox);

                        byte[] temp = new byte[containerLength - 0x18];
                        Buffer.BlockCopy(Data, i + 0x18, temp, 0, temp.Length);

                        uint compMagic = Helper_Functions.ReadUInt32(Data, i + 0x18, Xbox);

                        if (compMagic == 0x46465548) // HUFF
                        {
                            Array.Resize(ref temp, temp.Length + 0x8);
                            //byte[] decompressedBytes = Huffer.Huff_Decoder(temp,Helper_Functions.ReadInt32(temp,8,Xbox);
                            Buffer.BlockCopy(Huffer.Huff_Decoder(temp, Helper_Functions.ReadInt32(temp, 8, Xbox)), 0, Data_Table, targetOffset, decompressedSize);
                        }
                        else if (compMagic == 0x5A4C444A) // JDLZ
                        {
                            byte[] decompressedBytes = JDLZ_Removing_Globals.decompress(temp, Xbox);

                            // 1. Safety check: make sure we don't ask for more bytes than the decompressor actually spit out
                            int copyLength = Math.Min(decompressedBytes.Length, decompressedSize);

                            // 2. Safety check: make sure we don't copy past the end of the pre-allocated Data_Table
                            if (targetOffset + copyLength > Data_Table.Length)
                            {
                                copyLength = Data_Table.Length - targetOffset;
                            }

                            if (copyLength > 0)
                            {
                                Buffer.BlockCopy(decompressedBytes, 0, Data_Table, targetOffset, copyLength);
                            }
                        }

                        Complete_Decompressed_Length += decompressedSize;
                        i += containerLength; // Advance sequentially

                        if (i >= Data.Length || Helper_Functions.ReadUInt32(Data, i, Xbox) != 0x55441122)
                        {
                            return Data_Table;
                        }
                    }
                    else
                    {
                        i += 4;
                    }
                }
            }
            return Data_Table;
        }





        //Lets Create a function to check all labels.
        //And One To Make Sure Compression Makes Sense the Containers
        public static bool Validate_Save(byte[] Data, bool Xbox)
        {
            int Console = 1;
            int Pos = 0;

            if (Data.Length == 0x40000)
            {
                Console = 2;
                Pos = 0x034B28;
                Xbox = true;
            }
            if (Console == 1)
            {
                Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
            }

            int Start_Pos = Pos;
            int Complete_Decompressed_Length = 0;

            try
            {
                for (int i = Pos; i < Data.Length;)
                {
                    uint magic = Helper_Functions.ReadUInt32(Data, i, Xbox);

                    if (magic == 0x55441122)
                    {
                        int decompressedSize = Helper_Functions.ReadInt32(Data, i + 4, Xbox);
                        int containerLength = Helper_Functions.ReadInt32(Data, i + 8, Xbox);

                        if (decompressedSize != Helper_Functions.ReadInt32(Data, i + 0x20, Xbox))
                        {
                            Helper_Functions.WriteInt32(Data, i + 4, Helper_Functions.ReadInt32(Data, i + 0x20, Xbox), Xbox);
                        }

                        Complete_Decompressed_Length += decompressedSize;
                        i += containerLength; // Advance linearly!

                        // Safe early exit check if we run out of valid blocks
                        if (i >= Data.Length || Helper_Functions.ReadUInt32(Data, i, Xbox) != 0x55441122)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        i += 4; // Scan out alignment padding if necessary
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static byte[] ReWrite_Data_Table(ref byte[] Data, byte[] Data_Table, bool Xbox)
        {
            Container_22114455 C_22114455 = new Container_22114455();
            JDLZ_HUFF_Structure JDLZ_HUFF = new JDLZ_HUFF_Structure();

            JDLZ_HUFF.Magic = 0x5A4C444A; // JDLZ
            C_22114455.Magic = 0x55441122;

            if (Validate_Save(Data, Xbox) == true)
            {
                int Console = 1;
                if (Data.Length == 0x40000)
                {
                    Console = 2;
                    Xbox = true; // Enforce Big Endian writing layout on PS3
                }

                int Pos = 0;
                if (Console == 1)
                {
                    Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
                }
                else if (Console == 2)
                {
                    Pos = 0x034B28;
                }

                int Container_Start_Pos = Pos;
                int Processed_Length = 0;
                int Current_Decompressed_Offset = 0;

                // Loop dynamically over all bytes in Data_Table using blocks of 0x8000
                int totalBytesToWrite = Data_Table.Length;

                while (Current_Decompressed_Offset < totalBytesToWrite)
                {
                    // Determine size of current slice
                    int bytesToProcess = Math.Min(0x8000, totalBytesToWrite - Current_Decompressed_Offset);
                    byte[] buffer = new byte[bytesToProcess];
                    Buffer.BlockCopy(Data_Table, Current_Decompressed_Offset, buffer, 0, bytesToProcess);

                    // Compress payload
                    JDLZ_HUFF.Compressed_Data = JDLZ_Removing_Globals.Compresser(buffer, Xbox);

                    // Populate structural container info dynamically
                    C_22114455.Decompressed_Size = bytesToProcess;
                    C_22114455.Container_Length = (((JDLZ_HUFF.Compressed_Data.Length + 3) & ~3) + 0x18);
                    C_22114455.Position_Of_Decompressed_Entry = Current_Decompressed_Offset;
                    C_22114455.Previous_Container_Lengths = Processed_Length;

                    // Commit structured headers directly back into binary
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos, C_22114455.Magic, Xbox);
                    Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x4, C_22114455.Decompressed_Size, Xbox);
                    Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x8, C_22114455.Container_Length, Xbox);
                    Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0xC, C_22114455.Position_Of_Decompressed_Entry, Xbox);
                    Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x10, C_22114455.Previous_Container_Lengths, Xbox);
                    Helper_Functions.WriteInt32(Data, Container_Start_Pos + 0x14, 0, Xbox); // Zero Padding

                    // Inject the raw block content payloads
                    Buffer.BlockCopy(JDLZ_HUFF.Compressed_Data, 0, Data, Container_Start_Pos + 0x18, JDLZ_HUFF.Compressed_Data.Length);

                    // Shift pointers forward safely for subsequent blocks
                    Processed_Length += C_22114455.Container_Length;
                    Container_Start_Pos += C_22114455.Container_Length;
                    Current_Decompressed_Offset += bytesToProcess;
                }
                if (Console == 2)
                {
                    Array.Resize(ref Data, 0x40000);
                }
                else
                {
                    Array.Resize(ref Data, Helper_Functions.ReadInt32(Data, 4, Xbox));
                }
                return Data_Table;
            }

            MessageBox.Show("Failed To Write Data Table");
            return Data_Table;
        }


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
                        if (Helper_Functions.ReadInt32(Data, Container_Start_Pos + 4, Xbox) != Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x20, Xbox))
                        {
                            Helper_Functions.WriteInt32(Data, Container_Start_Pos + 4, Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x20, Xbox), Xbox);
                        }
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

                        Temp_Decompressed_Compressed_File = Huffer.Huff_Decoder(Temp_Decompressed_Compressed_File, Helper_Functions.ReadInt32(Temp_Decompressed_Compressed_File, 8, Xbox));
                       
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
                            //File.WriteAllBytes(Form1.File_Path + "12345", Decompress_Compressed_Data);
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
