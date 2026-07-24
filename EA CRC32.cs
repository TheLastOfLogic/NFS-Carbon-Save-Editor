using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    public static class EA_CRC32
    {
        private static readonly uint[] crcTable = new uint[256];

        // Static constructor: Runs once when the class is first accessed
       public static void EA_CRC32_1()
        {
            for (uint i = 0; i < 256; i++)
            {
                uint remainder = i << 24;
                for (uint bit = 0; bit < 8; bit++)
                {
                    remainder = (remainder & 0x80000000u) != 0
                        ? (remainder << 1) ^ 0x04C11DB7u
                        : remainder << 1;
                }
                crcTable[i] = remainder;
            }
        }

        /// <summary>
        /// Processes cs_1, cs_2, and cs_3 directly on the provided buffer.
        /// </summary>
        public static void UpdateHashes(byte[] data, bool Xbox)
        {
            EA_CRC32_1();
            if (data == null || data.Length < 0x1C) return;

            // 1. Determine Endianness (Xbox 360 is typically Big Endian)
            bool isBigEndian = Xbox;

            // 2. Helper to read UInt32 based on endianness (replaces Flip)
            uint GetUInt32(int offset)
            {
                uint val = BitConverter.ToUInt32(data, offset);
                if (isBigEndian != BitConverter.IsLittleEndian) return val; // Already correct
                return ((val & 0xFF000000) >> 24) | ((val & 0x00FF0000) >> 8) |
                       ((val & 0x0000FF00) << 8) | ((val & 0x000000FF) << 24);
            }

            // 3. The Core CRC logic (No allocations)
            uint InternalCompute(int offset, int length)
            {
                if (length < 4) return 0;

                // Initial seed from first 4 bytes
                uint crc = ~((uint)(data[offset + 3] | (data[offset + 2] << 8) | (data[offset + 1] << 16) | (data[offset] << 24)));

                int end = offset + length;
                for (int i = offset + 4; i < end; i++)
                {
                    crc = crcTable[crc >> 24] ^ ((crc << 8) | data[i]);
                }
                return ~crc;
            }

            // 4. Helper to write UInt32 back to buffer
            void WriteHash(uint hash, int offset)
            {
                byte[] bytes = BitConverter.GetBytes(hash);
                if (isBigEndian) Array.Reverse(bytes);
                Buffer.BlockCopy(bytes, 0, data, offset, 4);
            }

            // -------- Process cs_1 --------
            uint len1 = Helper_Functions.ReadUInt32(data,8, Xbox);
            uint hash1 = InternalCompute(0x1C, (int)len1);
            WriteHash(hash1, 0x10);

            // -------- Process cs_2 --------
            uint len2 = GetUInt32(0xC);
            uint hash2 = InternalCompute(0x1C + (int)len1, (int)len2);
            WriteHash(hash2, 0x14);

            // -------- Process cs_3 --------
            uint hash3 = InternalCompute(0, 0x18);
            WriteHash(hash3, 0x18);
        }
    }
}