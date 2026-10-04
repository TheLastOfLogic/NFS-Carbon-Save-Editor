using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher.NFS_ProStreet
{
    internal class Car_Structure
    {
        //410 car slots available
        //this is the start of the car slots find (0x00090688) add 0xC to the Address to Start Pulling Cars
        public static int Find_Car_Structure(byte[] Data, int Pos)
        {
            if (Data_Base.Save_Version < 3)
            {
                Pos = 0x13A00;
            }
            else
            {
                Pos = 0x17F00;
            }

            while (Helper_Functions.ReadUInt32(Data, Pos, true) != 0x00090688)
            {
                Pos += 0x4;
            }

            return Pos += 0xC;
        }

        public static byte[] Write_400_Randoms(byte[] Data, uint[] Hashes, int Pos)
        {
            byte[] Data_new = new byte[Data.Length];
            Array.Copy(Data, Data_new, Data.Length);

            Pos = Find_Car_Structure(Data_new, Pos);
            for (int i = 0; i < Hashes.Length; i++)
            {
                Helper_Functions.WriteUInt32(Data_new, Pos + 0xC, Hashes[i], true);
                Data_new[Pos + 0x14] |= 0x1; 
                Pos += 0x18;
            }
            return Data_new;
        }
        public static void grab_all_cars_from_Save(byte[] Data, int Pos_1)
        {
            int Pos = 0;
            Pos = Find_Car_Structure(Data, Pos);
            List<VehicleEntry> carList = new List<VehicleEntry>();

            // Example loop count: Adjust condition based on total car count or end-marker mask
            int carCount = 410;

            for (int i = 0; i < carCount; i++)
            {
                VehicleEntry ve = new VehicleEntry();

                // Populate fields from byte buffer using offset shifts (0x18 = 24 bytes per struct)
                ve.Position = Helper_Functions.ReadUInt32(Data, Pos + 0x00, true);
                ve.CarEmblem = Helper_Functions.ReadUInt32(Data, Pos + 0x04, true);
                ve.PVehicle = Helper_Functions.ReadUInt32(Data, Pos + 0x08, true);
                ve.PresetCar = Helper_Functions.ReadUInt32(Data, Pos + 0x0C, true);
                ve.Flag1 = Helper_Functions.ReadUInt16(Data, Pos + 0x10, true);
                ve.Flag2 = Helper_Functions.ReadUInt16(Data, Pos + 0x12, true);
                ve.Flag3 = Helper_Functions.ReadUInt16(Data, Pos + 0x14, true);
                ve.FlagAAAA = Helper_Functions.ReadUInt16(Data, Pos + 0x16, true);

                carList.Add(ve);

                // Move to the next 24-byte (0x18) vehicle block
                Pos += 0x18;
            }

            // If you specifically need a fixed array:
            VehicleEntry[] carArray = carList.ToArray();
        }
    }
        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct VehicleEntry
        {
            [FieldOffset(0x00)] public uint Position;      // 4 bytes: Position / Index
            [FieldOffset(0x04)] public uint CarEmblem;     // 4 bytes: Emblem ID / Pointer
            [FieldOffset(0x08)] public uint PVehicle;      // 4 bytes: Pointer to Vehicle
            [FieldOffset(0x0C)] public uint PresetCar;     // 4 bytes: Preset Model ID
            [FieldOffset(0x10)] public ushort Flag1;       // 2 bytes: Status Flag 1
            [FieldOffset(0x12)] public ushort Flag2;       // 2 bytes: Status Flag 2
            [FieldOffset(0x14)] public ushort Flag3;       // 2 bytes: Status Flag 3
            [FieldOffset(0x16)] public ushort FlagAAAA;    // 2 bytes: Value / Mask (AAAA)
        }
    }

