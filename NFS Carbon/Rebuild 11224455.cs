using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    static internal class Rebuild_11224455
    {
        public static void Container_Converter(byte[] Data, byte[] Data_1, bool Xbox, bool Xbox_1)
        {
            Int32 Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
            Int32 Container_Start_Pos = Helper_Functions.ReadInt32(Data, 0x20, Xbox) + 0x2C;
            Int32 Container_Start_Pos_1 = Helper_Functions.ReadInt32(Data_1, 0x20, Xbox_1) + 0x2C;
            if (Data.Length == 0x40000)
            {
                Container_Start_Pos = 0x034B28;
                Pos = Container_Start_Pos;
            }
            if( Data_1.Length == 0x40000)
            {
                Container_Start_Pos_1 = 0x034B28;
                Pos = Container_Start_Pos;
            }

            for (int i = 0; i < 3; i++)
            {
                if ((Helper_Functions.ReadInt32(Data_1, Container_Start_Pos_1, Xbox_1) == 0x55441122) && (Container_Start_Pos < Data.Length && Container_Start_Pos_1 < Data_1.Length))
                {
                    Int32 Container_Previous_8_Pos = Helper_Functions.ReadInt32(Data, Container_Start_Pos + 8, Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1, Xbox_1)), Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 4, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 4, Xbox_1)), Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 8, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 8, Xbox_1)), Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 0xC, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 0xC, Xbox_1)), Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 0x10, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 0x10, Xbox_1)), Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 0x14, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 0x14, Xbox_1)), Xbox);
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 0x18, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 0x18, Xbox_1)), Xbox); //JDLZ
                    Data[Container_Start_Pos + 0x1C] = Data_1[Container_Start_Pos_1 + 0x1C];
                    Data[Container_Start_Pos + 0x1D] = Data_1[Container_Start_Pos_1 + 0x1D];
                    Data[Container_Start_Pos + 0x1E] = Data_1[Container_Start_Pos_1 + 0x1E];
                    Data[Container_Start_Pos + 0x1F] = Data_1[Container_Start_Pos_1 + 0x1F];
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 0x20, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 0x20, Xbox_1)), Xbox); //Decompressed Data
                    Helper_Functions.WriteUInt32(Data, Container_Start_Pos + 0x24, (Helper_Functions.ReadUInt32(Data_1, Container_Start_Pos_1 + 0x24, Xbox_1)), Xbox); //Compressed Data
                    Buffer.BlockCopy(Data_1, Container_Start_Pos_1 + 0x28, Data, Container_Start_Pos + 0x28, (Helper_Functions.ReadInt32(Data_1, Container_Start_Pos_1 + 0x8, Xbox_1)- 0x18));
                    Container_Start_Pos += (Helper_Functions.ReadInt32(Data, Container_Start_Pos + 0x8, Xbox));
                    Container_Start_Pos_1 += (Helper_Functions.ReadInt32(Data_1, Container_Start_Pos_1 + 0x8, Xbox_1));

                }
                else
                {
                    MessageBox.Show("Thats the End");
                    break;
                }
            }
            int Start_Pos = Pos;
            int Last_Pos = Pos;
            do
            {
                if (Helper_Functions.ReadInt32(Data,Pos,Xbox) == 0x55441122)
                {
                    Start_Pos = Pos;
                    Pos += Helper_Functions.ReadInt32(Data,Pos+8,Xbox);
                    Last_Pos = Pos;
                }
                else
                {
                    Pos += 4;
                }
            }
            while (Pos < Data.Length);
            Helper_Functions.WriteUInt32(Data, Start_Pos + 8, (uint)(Helper_Functions.ReadUInt32(Data, Start_Pos + 8, Xbox) + (Data.Length - Last_Pos)), Xbox);

        }
    }
}
