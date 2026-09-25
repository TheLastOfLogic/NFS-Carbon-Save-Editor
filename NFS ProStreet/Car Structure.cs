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
}
