using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    public static class Huffer
    {
       
            public static UInt32 Neg(UInt32 R1, UInt32 R2)
            {
                return R1 = (uint)(-(int)R2);

            }

            public static uint Rotlwi(uint value, int shift)
            {
                // Normalize shift to stay within 0-31 bounds
                shift &= 31;

                if (shift == 0) return value;

                // Shift left, and OR it with the bits that wrapped around to the right
                return (value << shift) | (value >> (32 - shift));
            }

            public static uint ReadUInt32(byte[] data, int offset, bool isBigEndian)
            {
                uint value = BitConverter.ToUInt32(data, offset);

                // If Xbox 360, swap the bytes so the PC can read it properly
                if (isBigEndian)
                {
                    value = (value & 0x000000FFU) << 24 |
                            (value & 0x0000FF00U) << 8 |
                            (value & 0x00FF0000U) >> 8 |
                            (value & 0xFF000000U) >> 24;
                }
                return value;
            }
            public static uint WriteUInt32(byte[] data, int offset, uint value, bool isBigEndian)
            {
                // If it's Xbox 360, flip the value before converting to bytes
                if (isBigEndian)
                {
                    value = (value & 0x000000FFU) << 24 |
                            (value & 0x0000FF00U) << 8 |
                            (value & 0x00FF0000U) >> 8 |
                            (value & 0xFF000000U) >> 24;
                }

                // Convert the (possibly flipped) value into bytes
                byte[] bytes = BitConverter.GetBytes(value);

                // Write it into the target array at the correct offset
                Buffer.BlockCopy(bytes, 0, data, offset, 4);
                return value;
            }


        public static byte[] Huff_Decoder(byte[] Compressed_Data, int Decompressed_Length) //int Compressed_Data_Length, int Decompressed_Data_Length)
            {
                UInt32 R1 = 0x00000000;
                UInt32 R2 = 0x20000000;
                UInt32 R3 = 0x00000000;
                UInt32 R4 = 0xB39A6B18;
                UInt32 R5 = 0x10; //both R11 and R5 Start Out the Same
                UInt32 R6 = 0x00000000;
                UInt32 R7 = 0xB39AFB1A;
                UInt32 R8 = 0xB39B0000;
                UInt32 R9 = 0x000004E5;
                UInt32 R10 = 0x46465548;
                UInt32 R11 = 0x10; //HUFF Base 0xB399EB40;
                UInt32 R12 = 0x82462CD4;
                UInt32 R13 = 0x80242000;
                UInt32 R14 = 0x00000000;
                UInt32 R15 = 0x00000000;
                UInt32 R16 = 0x00000000;
                UInt32 R17 = 0x00000000;
                UInt32 R18 = 0x00000001;
                UInt32 R19 = 0x00000000;
                UInt32 R20 = 0x82B8B108;
                UInt32 R21 = 0x00000000; //B39A6B18
                UInt32 R22 = 0xB39B0000;
                UInt32 R23 = 0x00000000;
                UInt32 R24 = 0x82B8B10C;
                UInt32 R25 = 0xB399EB18;
                UInt32 R26 = 0x46465548;
                UInt32 R27 = 0x504D4F43;
                UInt32 R28 = 0x5A4C444A;
                UInt32 R29 = 0xAAD45210;
                UInt32 R30 = 0x57574152;
                UInt32 R31 = 0x0; //start of data
                byte[] cache = new byte[0x600];
                byte[] Decompressed_Data = new byte[Decompressed_Length];
                uint R9_Compare;




                //824606FC cmplwi cr6,r11,0 //r11 is pointed to the buffer where HUFF Starts (Data) Header is already read
                //82460700  beq cr6,824614A0
                //82460704  lis r9,-32058; 82C6h pointer to block in xex file
                //82460708  li r10,-16; 0FFF0h
                R10 = 0xFFFFFFF0;

                //82460728  lbz r9,0(r11) R11 points tojust after the 
                R9 = (byte)Compressed_Data[R11]; //R11 Base? Starts of HUFF //grab compressed data
                R5 = R11 + 2; //8246072C addi r5,r11,2 //Set up r5 to point to Byte 2 (r11 + 2)
                R7 = (byte)Compressed_Data[R11 + 1]; //82460730  lbz r7,1(r11) red one byte into payload
                R8 = Neg(R8, R10); //82460734  neg r8, r10 //
                R11 = Rotlwi(R9, 8); //82460738  rotlwi r11, r9,8
                R10 += 0x10; //8246073C addi r10,r10,16; 10h
                R23 = R11 | R7; //82460740  or r23, r11, r7
                R9 = R23 << (int)R8; //82460744  slw r9, r23, r8
                R11 = (uint)((int)R10 + -16); //82460748  addi r11, r10,-16; 0FFF0h
                R8 = R9 >> 0x10; //8246074C srwi r8,r9,16
                R10 = R9 << 0x10; //82460750  slwi r10, r9,16
                R10 = (byte)Compressed_Data[R5]; //8246075C lbz r10,0(r5)
                R9 = R23 << 8; //82460760  slwi r9, r23,8
                R7 = (byte)Compressed_Data[R5 + 1];// 82460764  lbz r7,1(r5)
                R3 = Neg(R3, R11); //82460768  neg r3, r11
                R10 = R9 | R10; // 8246076C or r10,r9,r10
                R5 += 2; //82460770  addi r5, r5,2
                R10 <<= 8; //82460774  slwi r10, r10,8
                R11 += 0x10; //82460778  addi r11, r11,16; 10h
                R23 = R10 | R7; //8246077C or r23,r10,r7
                R10 = R23 << (int)R3;// 82460780  slw r10, r23, r3
                R9 = R8 & 0x00008000; //82460784  rlwinm r9, r8,0,16,16
                R9 = R8 & 0x00000100; //8246078C rlwinm r9,r8,0,23,23
                                      //82460788  cmplwi cr6, r9,0

                goto _8246081C;//82460790  beq cr6,8246081C auto jmp here
            _8246081C:
                {
                    //jmp;
                }
                if (R9 == 0)
                //8246081C cmplwi cr6,r9,0
                //82460820  beq cr6,82460894 jmp to here
                {
                    goto _82460894;
                }

            _82460894:
                {
                    //jmp
                }
                R7 = R10 >> 24; ///this will be sued as a counter for building the table
                R11 -= 8; //82460898  addi r11, r11,-8; 0FFF8h //The engine updates r11 to -8. This acts as a running tally, letting the engine know it just "consumed" 8 bits out of the bit reservoir.
                R10 <<= 8; //8246089C slwi r10,r10,8 //It then shifts r10 left by 8 bits to discard those consumed bits and bring the next batch of stream bits to the front.

                R17 = R8 & 0xFFFFFFFF; //824608A4 rlwinm r17,r8,0,24,22
                if ((int)R11 >= 0)
                //824608A0 cmpwi cr6,r11,0
                //824608A8 bge cr6,824608D4
                {
                    goto _824608D4;
                }
                /*Live Data Trace at 824608E41. The 2-Byte File Refill (824608AC to 824608CC)Because r11 dropped below zero previously, 
                 * the engine read the next two bytes out of your file to patch the bit reservoir back up:r5 = 00000000B399EB46: 
                 * Your file pointer advanced by another 2 bytes ($0\text{x}B399EB44 \rightarrow 0\text{x}B399EB46$). 
                 * It has now processed a total of 6 bytes of payload data since skipping the main 16-byte header.r23 = 000000000080003B: This is your newly updated reservoir.
                 * The engine took the remaining bits from earlier, read the next two bytes from your file (00 3B), and merged them cleanly into the bottom half of r23.2. Slicing Out the Counter Parameter
        Look at what happened immediately after the refill:

        Plaintext
        824608D4  addi r11,r11,-16      ; Adjust bit tracking tally
        824608D8  slwi r9,r10,16        ; Shift remaining stream data left
        824608E0  srwi r8,r10,16        ; Shift right to isolate our new variable value -> r8
        Look at the result inside register r8:

        r8 = 0000000000008000

        The engine just successfully isolated a 16-bit metadata token from the file: 0x8000.

        In the EA Huffman dictionary layout, this parameter is a primary loop-bounding constraint. It dictates either the total number of nested branches 
                in the dynamic lookup tree, or the absolute bit-mask length required to read the compressed symbol array.
                The Core Init Phase (Where you are right now): It reads the first few bytes (30 FB 00 80 00 3B), configures the bit reservoir, chooses the dynamic tree variant path, and extracts the loop bounding values (like the 0x8000 counter in r8).The Table Allocation Phase (Coming up next): 
                It will enter a loop that takes those extracted values and starts writing node mappings into that $0\text{x}460$ (1,120 byte) stack frame workbench we saw 
                allocated at the very beginning.The Main Decompression Loop: Once that table is built, the execution jumps forward to a completely separate, tight loop deeper 
                in the function. That loop stays active until the entire output file is written, completely bypassing these initialization blocks.



                */

                R10 = (byte)Compressed_Data[R5]; //824608AC lbz r10,0(r5)
                R9 = R23 << 8; //824608B0 slwi r9,r23,8
                R8 = (byte)Compressed_Data[R5 + 1]; //824608B4 lbz r8,1(r5)
                R3 = Neg(R3, R11); //824608B8 neg r3,r11
                R10 |= R9; //824608BC or r10,r9,r10
                R5 += 2; //824608C0 addi r5,r5,2
                R10 <<= 8; //824608C4 slwi r10,r10,8
                R11 += 0x10; //824608C8 addi r11,r11,16; 10h
                R23 = R10 |= R8; //824608CC or r23,r10,r8
                R10 = R23 << (int)R3; //824608D0  slw r10, r23, r3
            _824608D4:
                {
                    //jmp
                }
                R11 -= 0x10; //824608D4  addi r11, r11,-16; 0FFF0h
                R9 = R10 << 0x10; // 824608D8  slwi r9, r10,16

                R8 = R10 >> 0x10; //824608E0  srwi r8, r10,16
                if ((int)R11 >= 0)
                //824608DC cmpwi cr6,r11,0
                //824608E4  bge cr6,82460910
                {
                    goto _82460910;
                }


                /*This is the absolute finale of the initialization phase. The engine just stitched together the final pieces of information it needs, 
                 * combined them into an overarching structural map key, and is about to jump straight into building the loop table.
                Live Data Trace: Finalizing the Map
        1. The 2-Byte Refill (824608E8 to 8246090C)
        Your bit tracking dropped again, so the engine fetched the next 2 bytes from your payload:

        r5 = 00000000B399EB48: The pointer advanced another 2 bytes. We have now officially consumed 8 bytes of data since the HUFF header.

        r23 = 00000000003B9A25: Look at the new bytes added to the bottom of the reservoir: 9A 25.

        2. Merging the Parameters (82460910 to 82460914)
        Plaintext
        82460910  slwi r10,r7,16        ; r10 = r7 << 16
        82460914  or r3,r10,r8          ; r3 = r10 | r8
        Look at register r3 right now in your dump:

        r3 = 0000000000008000

        The engine took your previous variable (0x8000) and merged it with r7. This register acts as a master layout configuration value.

        3. Extracting the Node Counter (8246091C)
        Plaintext
        8246091C  srwi r8,r9,24         ; Shift r9 right by 24 -> store in r8
        Look at register r8 in your dump:

        r8 = 000000000000003B

        This is a massive discovery. By shifting the newly updated stream register, the engine just pulled out the byte 0x3B (which is 59 in decimal).

        In an EA dynamic Huffman tree, this value represents the exact number of nodes/leaves in the tree dictionary that your specific file contains.
                What Happens at the Branch (82460928)?
    The code checks if the bit tally (r10) is greater than or equal to zero:

    r10 = 0000000000000000

    Because r10 is exactly 0, the condition bge (Branch if Greater than or Equal) evaluates to false.

    The Verdict: The Initialization Phase is Complete
    The engine takes the jump to 82460954


                 * */
                R10 = (byte)Compressed_Data[R5];               //824608E8  lbz r10,0(r5) 
                R9 = R23 << 8;                             // 824608EC  slwi r9,r23,8 
                R3 = (byte)Compressed_Data[R5 + 1];            // 824608F0  lbz r3,1(r5) 
                R31 = Neg(R31, R11);                           // 824608F4  neg r31,r11 
                R10 = R9 | R10;                                // 824608F8  or r10,r9,r10 
                R5 += 2;                                       // 824608FC  addi r5,r5,2 
                R10 <<= 8;                                     // 82460900  slwi r10,r10,8 
                R11 += 0x10;                                   // 82460904  addi r11,r11,16    ; 10h 
                R23 = R10 | R3;                                // 82460908  or r23,r10,r3
                R9 = R23 << (int)R31;                          //8246090C  slw r9,r23,r31
            _82460910:
                {
                    //jmp
                }
                R10 = R7 << 16;                                // 82460910  slwi r10,r7,16 
                R3 = R10 | R8;                                 // 82460914  or r3,r10,r8 
                R10 = R11 - 8;                                 // 82460918  addi r10,r11,-8    ; 0FFF8h 
                R8 = R9 >> 24;                                 // 8246091C  srwi r8,r9,24 
                R11 = R9 << 8;                                 // 82460920  slwi r11,r9,8
                if ((int)R10 >= 0)
                //82460924  cmpwi cr6, r10,0
                //82460928  bge cr6,82460954
                {
                    goto _82460954;
                }
            _82460954:
                {
                    //jmp
                }
                /*
                 ou’ve landed right on 82460954. This block is incredibly exciting because it is the exact moment the engine transitions from reading parameters to initializing the 
                tree generation loops.

    It is cleaning out local registers and calculating base memory offsets to start writing data into that 1,120-byte (0x460) stack workbench we found earlier.

    Let's break down exactly what the CPU is doing to set up this loop.

    The Register Clearing and Loop Setup
    Before this block runs, r16 is 0, and r8 holds your total node counter (0x3B / 59 nodes)
                The Register Clearing and Loop Setup
    Before this block runs, r16 is 0, and r8 holds your total node counter (0x3B / 59 nodes).

    Plaintext
    82460954  li r20,1              ; r20 = 1 (A loop incrementer or status flag)
    82460958  clrlwi r18,r8,24      ; Clear left word immediate: r18 = r8 & 0xFF
    clrlwi r18, r8, 24 keeps only the lowest 8 bits of r8. Since r8 is 0x3B, r18 becomes exactly 0x3B (59). This explicitly saves your node loop limit into r18.

    Plaintext
    8246095C  mr r29,r16            ; r29 = r16 (0)
    82460960  mr r30,r20            ; r30 = r20 (1)
    82460964  mr r8,r16             ; r8  = r16 (0)
    82460968  mr r7,r16             ; r7  = r16 (0)
    The engine is bulk-clearing working index registers (r29, r8, r7) to zero so it can safely use them as array element offsets.

                Setting Up the Stack Allocation PointerThis is where the engine connects to your stack workspace:Plaintext8246096C  slwi r31,r8,1         ; r31 = r8 << 1 (0 << 1 = 0)
    82460970  addi r9,r1,340        ; r9 = r1 + 0x154 (Base stack address)
    r1 is your stack pointer (0x7009EFE0).addi r9, r1, 340 sets r9 to point exactly to offset 0x154 relative to your stack base:$$0x7009EFE0 + 0x154 = 0x7009F134
                $$This calculated location in r9 is where the very first node configuration value of the Huffman tree is going to be saved.Plaintext82460974  subf r8,r29,r31       ; 
                r8 = r31 - r29 (0 - 0 = 0)
    8246097C  stwx r8,r7,r9         ; Store Word Indexed: Write r8 (0) to address [r7 + r9]
    stwx writes a 0 directly into your newly calculated stack array slot at 0x7009F134. 
                This effectively zeroes out the root/first element of the decode lookup table to ensure there is no old memory garbage remaining.Checking the Bit Reservoir StatusPlaintext82460978  cmpwi cr6,r11,0       ; Is r11 >= 0?
    82460980  bge cr6,824609C4      ; Branch if Greater Than or Equal


    Let's look at your live bit reservoir tracking variable from the dump:r11 = 000000009A250000 Because the highest bit is not set, this represents a large positive value in 32-bit register space. Therefore, the condition bge (Branch if Greater Than or Equal to 0) evaluates to false.
                The Verdict: Taking the Jump to 824609C4The
                engine takes this jump and leaps over the intermediate refill code directly to 824609C4.This tells us that the bit reservoir is currently fully packed with enough bits (9A25...) to 
                process the very first elements of the loop without needing to fetch additional bytes from the file layout right this second. It's skipping a refill block because 
                it's already running "hot" with data.

                .*/


                R20 = 1; //82460954  li r20,1 
                R18 = (byte)R8; //82460958  clrlwi r18,r8,24 
                R29 = R16; //8246095C mr r29,r16
                R30 = R20; //82460960  mr r30,r20
                R8 = R16; //82460964  mr r8,r16 
                R7 = R16; //82460968  mr r7,r16 

                /*
                 * 
                 * Live Data Verification at 82460980Look at how cleanly everything fell into place:r18 = 000000000000003B: 
                 * There is your loop bound counter cleanly isolated! It is exactly 59 (0x3B) nodes.r9 = 000000007009F134: This is the stack workbench address we calculated. 
                 * The CPU successfully calculated your absolute local table offset:$$0x7009EFE0 \text{ (Base } r1) + 0x154 = 0x7009F134$$r20 = 0000000000000001: 
                 * Successfully loaded with a constant 1 for index counting.r8 = 0000000000000000: Set to 0 by the mr r8, r16 instruction.r29 and r31: Both flattened cleanly to 0.
                 * Because stwx r8, r7, r9 has already executed right before this breakpoint, the CPU has officially cleared out the first slot of your table at memory address 0x7009F134.
                 * */

                do
                {
                    R31 = R8 << 1; //8246096C  slwi r31,r8,1 
                    R9 = R1 + 0x154; //82460970  addi r9, r1,340; 154h
                    R8 = R31 - R29; //82460974  subf r8,r29,r31 
                    WriteUInt32(cache, (int)(R7 + R9), R8, false); ////8246097C  stwx r8,r7,r9 //buffer of some kind

                    if ((int)R11 >= 0)
                    //82460978  cmpwi cr6,r11,0 we end here 82460980  bge cr6,824609C4 
                    {
                        goto _824609C4;
                    }
                    R10 -= 3; //82460984  addi r10, r10,-3; 0FFFDh
                    R9 = R11 >> 29; //82460988  srwi r9, r11,29
                    R11 <<= 3; //8246098C slwi r11,r11,3
                    if ((int)R10 >= 0) //82460990  cmpwi cr6, r10,0
                                       //82460994  bge cr6,82460B84
                    {
                        goto _82460B84;
                    }
                    R11 = Compressed_Data[R5];// 82460998  lbz r11,0(r5)
                    R8 = R23 << 8; //8246099C slwi r8,r23,8
                    R6 = Compressed_Data[R5 + 1]; //824609A0 lbz r6,1(r5)
                    R28 = Neg(R28, R10); //824609A4 neg r28,r10
                    R11 |= R8; //824609A8 or r11,r8,r11
                    R5 += 2; //824609AC addi r5,r5,2
                    R11 <<= 8; //824609B0 slwi r11,r11,8
                    R10 += 0x10; //824609B4 addi r10,r10,16; 10h
                    R23 = R11 | R6; //824609B8 or r23,r11,r6
                    R11 = R23 << (int)R28; //

                    goto _82460B84; //824609C0 b 82460B84 */

                _824609C4:
                    {
                        //jmp
                    }
                    R9 = R11 & 0xFFFF0000; //824609C4  clrrwi r9,r11,16
                    R9_Compare = R9;
                    R9 = 2; //824609CC li r9,2
                    if (R9_Compare == 0) //824609C8 cmplwi cr6,r9,0
                                         //824609D0  beq cr6,82460A40
                    {
                        goto _82460A40;

                    }
                    do
                    {

                        /*
                        Here is the mechanical process happening on the CPU:

    slw r11, r11, 1 pushes the highest bit of r11 out of the register and into the ether, shifting the next bit into the most significant position (the sign bit).

    addi r9, r9, 1 increments r9 by 1. Register r9 is acting as our accumulator/counter, tracking how many times this loop executes. (Remember, it started at a constant 2 on the line just before this block).

    cmpwi cr6, r11, 0 checks if the newly shifted r11 is greater than or equal to zero. In binary math, a 32-bit register is positive (>= 0) as long as its highest bit is 0. It only becomes negative (< 0) when the highest bit is 1.

    bge cr6, 824609D4 means: "As long as the highest bit we just shifted into place is a 0, keep looping and keep incrementing r9."

    The very instant a 1 bit hits that top slot, r11 becomes negative, the bge condition fails, and the loop breaks. */

                        R11 <<= 1; // 824609D4  slwi r11, r11,1
                        R9 += 1; //824609D8  addi r9, r9,1
                                 //824609DC cmpwi cr6,r11,0
                                 //824609E0  bge cr6,824609D4
                    }
                    while ((int)R11 >= 0);
                    R10 -= R9; //824609E4  subf r10, r9, r10
                    R11 <<= 1; //824609E8  slwi r11, r11,1
                    R10 += 1;
                    if (R19 == 0) //824609F0  cmpwi cr6, r19,0
                                  //824609F4  beq cr6,82460A0C
                    {
                        goto _82460A0C;
                    }
                    R8 = R11;
                    R6 = 0x20 - R19; //824609FC subfic r6,r19,32; 20h
                    R11 <<= (int)R19; // 82460A00 slw r11,r11,r19
                    R10 -= R19; //82460A04 subf r10,r19,r10
                    R6 = R8 >> (int)R6; //82460A08 srw r6,r8,r6


                _82460A0C:
                    {
                        //jmp
                    }

                    if ((int)R10 >= 0)
                    // 82460A0C cmpwi cr6,r10,0
                    //82460A10 bge cr6,82460A88
                    {
                        goto _82460A88;
                    }
                    R11 = Compressed_Data[R5]; //82460A14 lbz r11,0(r5)
                    R8 = R23 << 8; //82460A18 slwi r8,r23,8
                    R28 = Compressed_Data[R5 + 1]; //82460A1C lbz r28,1(r5)
                    R27 = Neg(R27, R10); //82460A20 neg r27,r10
                    R11 |= R8; //82460A24 or r11,r8,r11
                    R5 += 2; //82460A28 addi r5,r5,2
                    R11 <<= 8; //82460A2C slwi r11,r11,8
                    R10 += 0x10; // 82460A30 addi r10,r10,16; 10h
                    R23 = R11 | R28; //82460A34 or r23,r11,r28
                    R11 = R23 << (int)R27; //82460A38 slw r11,r23,r27
                    goto _82460A88; //82460A3C b 82460A88
                _82460A40:
                    {
                        //jmp
                    }
                    do
                    {
                        R10 -= 1; //82460A40 addi r10,r10,-1; 0FFFFh
                        R6 = R11 >> 31; // 82460A44  srwi r6,r11,31
                        R9 += 1; //82460A48  addi r9,r9,1 
                        R11 <<= 1; //82460A4C  slwi r11,r11,1 
                        if ((int)R10 >= 0)
                        //82460A50  cmpwi cr6,r10,0 
                        //82460A54 bge cr6,82460A80

                        {
                            goto _82460A80;
                        }
                        R11 = Compressed_Data[R5]; //82460A58  lbz r11,0(r5) 
                        R8 = R23 << 8; // 82460A5C  slwi r8,r23,8 
                        R28 = Compressed_Data[R5 + 1]; //82460A60  lbz r28,1(r5) 
                        R27 = Neg(R27, R10); //82460A64  neg r27,r10 
                        R11 |= R8; //82460A68  or r11,r8,r11
                        R5 += 2; //82460A6C  addi r5,r5,2
                        R11 <<= 8; //82460A70  slwi r11,r11,8 
                        R10 += 0x10; //82460A74  addi r10,r10,16		; 10h 
                        R23 = R11 | R28; //82460A78  or r23,r11,r28
                        R11 = R23 << (int)R27; //82460A7C  slw r11,r23,r27

                    _82460A80:
                        {
                            //jmp
                        }
                        //82460A80  cmpwi cr6,r6,0 
                        //82460A84 beq cr6,82460A40
                    }
                    while (R6 == 0);

                _82460A88:
                    {
                        //jmp
                    }
                    if ((int)R9 <= 0x10) //82460A88 cmpwi cr6,r9,16; 10h
                                         //82460A8C ble cr6,82460B30
                    {
                        goto _82460B30;
                    }



                    //Still Unsed by Game
                    R8 = R9 - 16; //82460A90 addic. r8,r9,-16; 0FFF0h
                    if (R8 == 0)
                    //82460A94 beq 82460AB0
                    {
                        goto _82460AB0;
                    }
                    R8 = 0x30 - R9; //82460A98 subfic r8,r9,48; 30h
                    R28 = R9 - 0x10; //82460A9C addi r28,r9,-16; 0FFF0h
                    R10 -= R9; //82460AA0 subf r10,r9,r10
                    R10 += 0x10; //82460AA4 addi r10,r10,16; 10h
                    R6 = R11 >> (int)R8; // 82460AA8 srw r6,r11,r8
                    R11 <<= (int)R28; //82460AAC slw r11,r11,r28
                    if ((int)R10 >= 0)
                    //82460AB0 cmpwi cr6,r10,0
                    //82460AB4 bge cr6,82460AE0
                    {
                        goto _82460AE0;
                    }
                _82460AB0:
                    {
                        //jmp
                    }
                    R11 = Compressed_Data[R5]; //82460AB8 lbz r11,0(r5)
                    R8 = R23 << 8; //82460ABC slwi r8,r23,8
                    R28 = Compressed_Data[R5 + 1]; //82460AC0 lbz r28,1(r5)
                    R27 = Neg(R27, R10); // 82460AC4 neg r27,r10
                    R11 |= R8; //82460AC8 or r11,r8,r11
                    R5 += 2; //82460ACC addi r5,r5,2
                    R11 <<= 8; //82460AD0 slwi r11,r11,8
                    R10 += 0x10; //82460AD4 addi r10,r10,16; 10h
                    R23 = R11 | R28; // 82460AD8 or r23,r11,r28
                    R11 = R23 << (int)R27; //82460ADC slw r11,r23,r27
                _82460AE0:
                    {
                        //jmp
                    }
                    R10 -= 0x10; //82460AE0 addi r10,r10,-16; 0FFF0h
                    R8 = R11 >> 16; //82460AE4 srwi r8,r11,16
                    R11 <<= 16; //82460AE8 slwi r11,r11,16
                    if ((int)R10 >= 0)
                    //82460AEC cmpwi cr6,r10,0
                    //82460AF0 bge cr6,82460B1C
                    {
                        goto _82460B1C;
                    }
                    R11 = Compressed_Data[R5]; //82460AF4 lbz r11,0(r5)
                    R28 = R23 << 8; //82460AF8 slwi r28,r23,8
                    R27 = Compressed_Data[R5 + 1]; //82460AFC lbz r27,1(r5)
                    R26 = Neg(R26, R10);//82460B00 neg r26,r10
                    R11 |= R28; // 82460B04 or r11,r28,r11
                    R5 += 2; // 82460B08 addi r5,r5,2
                    R11 <<= 8; //82460B0C slwi r11,r11,8
                    R10 += 0x10; //82460B10 addi r10,r10,16; 10h
                    R23 = R11 |= R27; // 82460B14 or r23,r11,r27
                    R11 = R23 << (int)R26; //82460B18 slw r11,r23,r26
                _82460B1C:
                    {
                        //jmp
                    }
                    R6 <<= 16; //82460B1C slwi r6,r6,16
                    R9 = R20 << (int)R9; // 82460B20 slw r9,r20,r9
                    R8 |= R6; //82460B24 or r8,r6,r8
                    R9 += R8; // 82460B28 add r9,r8,r9
                    goto _82460B84; //82460B2C b 82460B84




                _82460B30:
                    {
                        //jmp
                    }
                    if ((int)R9 == 0) //82460B30 //cmpwi cr6,r9,0

                    //82460B34 beq cr6,82460B4C
                    {
                        goto _82460B4C;
                    }
                    R8 = R11; //82460B38 mr r8,r11
                    R6 = 32 - R9; //82460B3C subfic r6,r9,32; 20h
                    R11 <<= (int)R9; // 82460B40 slw r11,r11,r9
                    R10 -= R9; //82460B44 subf r10,r9,r10
                    R6 = R8 >> (int)R6; //82460B48 srw r6,r8,r6

                _82460B4C:
                    {
                        //jmp
                    }
                    if ((int)R10 >= 0)
                    //82460B4C  cmpwi cr6,r10,0 
                    //82460B50 bge cr6,82460B7C
                    {
                        goto _82460B7C;
                    }
                    R11 = (byte)Compressed_Data[R5];// 82460B54 lbz r11,0(r5)
                    R8 = R23 << 8; //82460B58 slwi r8,r23,8
                    R28 = (byte)Compressed_Data[R5 + 1]; //82460B5C lbz r28,1(r5)
                    R27 = Neg(R27, R10); //82460B60 neg r27,r10
                    R11 |= R8; //82460B64 or r11,r8,r11
                    R5 += 2; //82460B68 addi r5,r5,2
                    R11 <<= 8; //82460B6C slwi r11,r11,8
                    R10 += 0x10; //82460B70 addi r10,r10,16; 10h
                    R23 = R11 | R28; //82460B74 or r23,r11,r28
                    R11 = R23 << (int)R27; //82460B78 slw r11,r23,r27
                _82460B7C:
                    {
                        //jmp
                    }
                    R9 = R20 << (int)R9; //82460B7C  slw r9,r20,r9 
                    R9 += R6; //82460B80  add r9,r9,r6 
                _82460B84:
                    {
                        //jmp
                    }
                    R6 = (uint)((int)R9 - 4); //82460B84  addi r6,r9,-4		; 0FFFCh 
                    R28 = R1 + 0x194; // 82460B88  addi r28,r1,404		; 194h 
                    R29 += R6; //82460B8C  add r29,r29,r6 
                    R8 = R31 + R6; //82460B90  add r8,r31,r6 
                    R9 = R16; //82460B94  mr r9,r16 
                    WriteUInt32(cache, (int)(R7 + R28), R6, false); //82460B9C stwx r6,r7,r28

                    if (R6 == 0)
                    {
                        goto _82460BB0;
                    }
                    //82460B98  cmpwi cr6,r6,0
                    // 82460BA0 beq cr6,82460BB0

                    R9 = 0x10 - R30; //82460BA4 subfic r9,r30,16; 10h
                    R9 = R8 << (int)R9; //82460BA8 slw r9,r8,r9
                    R9 = R9 & 0x0000FFFF; //82460BAC clrlwi r9,r9,16
                _82460BB0:
                    {
                        //jmp
                    }

                    R31 = R1 + 0x14; //82460BB0  addi r31,r1,20		; 14h 
                    R30 += 1; //82460BB4  addi r30,r30,1 


                    WriteUInt32(cache, (int)(R7 + R31), R9, false);//82460BBC  stwx r9,r7,r31 
                    R7 += 4;//82460BC0  addi r7,r7,4
                    /*
                     * this is the ending sequence for this
    82460BB8 cmpwi cr6,r6,0
    82460BC4  beq cr6,8246096C 
    82460BC8  cmplwi cr6,r9,0 
    82460BCC  bne cr6,8246096C  */
                }
                while (((int)R6 == 0) || (R9 != 0));

                R9 = R30 << 2; //82460BD0  slwi r9,r30,2 
                R8 = R1 + 0x10; //82460BD4  addi r8,r1,16		; 10h 

                R7 = 0xFFFFFFFF; //82460BD8  li r7,-1		; 0FFFFh 
                R6 = R9 + R8; //82460BDC  add r6,r9,r8 
                R22 = R30 - 1; //82460BE0  addi r22,r30,-1		; 0FFFFh
                R8 = 0x10; //82460BE4  li r8,16		; 10h 
                R9 = R1 + 0x58; //82460BE8  addi r9,r1,88		; 58h 
                WriteUInt32(cache, (int)(R6 - 4), R7, false); ////82460BEC  stw r7,-4(r6) 


                do
                {
                    R8 -= 1; //82460BF0  addi r8,r8,-1		; 0FFFFh 

                    WriteUInt32(cache, (int)(R9 - 8), R16, false); //82460BF4 stw r16,-8(r9)
                    WriteUInt32(cache, (int)(R9 - 4), R16, false);  // 82460BF8 stw r16,-4(r9)
                    WriteUInt32(cache, (int)(R9), R16, false);  //82460BFC stw r16,0(r9)
                    WriteUInt32(cache, (int)(R9 + 4), R16, false); // 82460C04 stw r16,4(r9)
                    R9 += 0x10; ////82460C08 addi r9,r9,16; 10h
                                //82460C00 cmpwi cr6,r8,0
                                //82460C0C bne cr6,82460BF0
                } while ((int)R8 != 0);
                /*
                The Next Assembly Code Block
    Now that stack memory is prepped, the decoder transitions directly into setting up pointers for parsing the actual table entries:

    Plaintext
    82460C10  cmpwi   cr6, r22, 0      ; Compare r22 (8) against 0
    82460C14  blt     cr6, 82460C44    ; If r22 < 0, skip this whole initialization setup
    82460C18  slwi    r9, r22, 2       ; r9 = r22 << 2 (Convert count to byte offset)
    82460C1C  addi    r8, r1, 16       ; r8 = Pointer to the base of your delta table
    82460C20  addi    r7, r1, 88       ; r7 = Pointer to the cleared stack buffer base
    82460C24  add     r6, r9, r8       ; r6 = specific target slot pointer within the tab*/

                R31 = R16; //82460C10 mr r31,r16

                if ((int)R29 <= 0)
                //82460C14 cmpwi cr6,r29,0
                //82460C18 ble cr6,82460E7C
                {
                    goto _82460E7C;
                }
                R6 = 0xFF; //82460C1C li r6,255; 0FFh
                do
                {
                    R7 = R16; //82460C20  mr r7,r16 
                    if ((int)R11 >= 0) // 82460C24 cmpwi cr6,r11,0
                                       //82460C28 bge cr6,82460C6C
                    {
                        goto _82460C6C;
                    }
                    R10 -= 3; //82460C2C addi r10,r10,-3; 0FFFDh
                    R9 = R11 >> 29; //82460C30 srwi r9,r11,29
                    R11 <<= 3; //82460C34 slwi r11,r11,3
                    if ((int)R10 >= 0) //82460C38 cmpwi cr6,r10,0
                                       //82460C3C bge cr6,82460E2C
                    {
                        goto _82460E2C;
                    }
                    R11 = (byte)Compressed_Data[R5]; //82460C40 lbz r11,0(r5)
                    R8 = R23 << 8; //82460C44 slwi r8,r23,8
                    R7 = (byte)Compressed_Data[R5 + 1]; //82460C48 lbz r7,1(r5)
                    R30 = Neg(R30, R10); //82460C4C neg r30,r10
                    R11 |= R8; //82460C50 or r11,r8,r11
                    R5 += 2; //82460C54 addi r5,r5,2
                    R11 <<= 0x8; // 82460C58 slwi r11,r11,8
                    R10 += 0x10; //82460C5C addi r10,r10,16; 10h
                    R23 = R11 | R7; //82460C60 or r23,r11,r7
                    R11 = R23 << (int)R30; //82460C64 slw r11,r23,r30


                    goto _82460E2C;

                _82460C6C:
                    {
                        //jmp
                    }
                    R9 = R11 & 0xFFFF0000; //82460C6C clrrwi r9,r11,16
                    R9_Compare = R9;
                    R9 = 2; //82460C74 li r9,2
                    if (R9_Compare == 0) //82460C70 cmplwi cr6,r9,0
                                         // 82460C78 beq cr6,82460CE8
                    {
                        goto _82460CE8;
                    }
                    do
                    {
                        R11 <<= 1; //82460C7C slwi r11,r11,1
                        R9 += 1; //82460C80 addi r9,r9,1

                    } while ((int)R11 >= 0);
                    //82460C84 cmpwi cr6,r11,0
                    //82460C88 bge cr6,82460C7C
                    R10 -= R9; //82460C8C subf r10,r9,r10
                    R11 <<= 1; //82460C90 slwi r11,r11,1
                    R10 += 1; //82460C94 addi r10,r10,1





                    //(Game Doesn't Check this)
                    if (R19 == 0)
                    //82460C98 cmpwi cr6,r19,0
                    //82460C9C beq cr6,82460CB4
                    {
                        goto _82460CB4;
                    }

                    R8 = R11;// 82460CA0 mr r8,r11
                    R7 = 32 - R19; // 82460CA4 subfic r7,r19,32; 20h
                    R11 <<= (int)R19; //82460CA8 slw r11,r11,r19
                    R10 -= R19;// 82460CAC subf r10,r19,r10
                    R7 = R8 >> (int)R7; //82460CB0 srw r7,r8,r7 

                _82460CB4:
                    {

                    }
                    if ((int)R10 >= 0)
                    // 82460CB4 cmpwi cr6,r10,0
                    //82460CB8 bge cr6,82460D30
                    {
                        //jmps to nothing
                        goto _82460D30;
                    }
                    R11 = (byte)Compressed_Data[R5]; //82460CBC lbz r11,0(r5)
                    R8 = R23 << 8; //82460CC0 slwi r8,r23,8
                    R30 = (byte)Compressed_Data[R5 + 1]; //82460CC4 lbz r30,1(r5)
                    R28 = Neg(R28, R10); //82460CC8 neg r28,r10
                    R11 |= R8; //82460CCC or r11,r8,r11
                    R5 += 2; //82460CD0 addi r5,r5,2
                    R11 <<= 8; //82460CD4 slwi r11,r11,8
                    R10 += 0x10; //82460CD8 addi r10,r10,16; 10h
                    R23 = R11 | R30; //82460CDC or r23,r11,r30
                    R11 = R23 << (int)R28; //82460CE0 slw r11,r23,r28

                    //82460CE4 b 82460D30
                    goto _82460D30;

                _82460CE8:
                    {
                        //jmp
                    }
                    //Game does read this
                    R10 -= 1; //82460CE8 addi r10,r10,-1; 0FFFFh
                    R7 = R11 >> 31; //82460CEC srwi r7,r11,31
                    R9 += 1; //82460CF0 addi r9,r9,1
                    R11 <<= 1; //82460CF4 slwi r11,r11,1

                    if ((int)R10 >= 0)
                    //82460CF8 cmpwi cr6,r10,0
                    //82460CFC bge cr6,82460D28
                    {
                        goto _82460D28;
                    }



                    R11 = Compressed_Data[R5]; //82460D00  lbz r11,0(r5)
                    R8 = R23 << 8; // 82460D04  slwi r8, r23,8
                    R30 = Compressed_Data[R5 + 1]; //82460D08  lbz r30,1(r5)
                    R28 = Neg(R28, R10); //82460D0C neg r28,r10
                    R11 |= R8; //82460D10  or r11, r8, r11
                    R5 += 2; //82460D14  addi r5, r5,2
                    R11 <<= 8; //82460D18  slwi r11, r11,8
                    R10 += 0x10; // 82460D1C addi r10,r10,16; 10h
                    R23 = R11 | R30; // 82460D20  or r23, r11, r30
                    R11 = R23 << (int)R28; //82460D24  slw r11, r23, r28

                _82460D28:
                    {
                        //jmp
                    }
                    if (R7 == 0)
                    //82460D28  cmpwi cr6, r7,0
                    //82460D2C beq cr6,82460CE8
                    {
                        goto _82460CE8;
                    }



                _82460D30:
                    {
                        //jmp
                    }
                    if ((int)R9 <= 0x10)
                    //82460D30  cmpwi cr6, r9,16; 10h
                    //82460D34  ble cr6,82460DD8
                    {
                        goto _82460DD8;
                    }
                    R8 = R9 - 0x10; // 82460D38  addic.r8,r9,-16; 0FFF0h //82460D3C beq 82460D58
                    if (R8 == 0)
                    {
                        goto _82460D58;
                    }
                    R8 = 0x30 - R9; //82460D40  subfic r8, r9,48; 30h
                    R30 = R9 - 0x10; // 82460D44  addi r30, r9,-16; 0FFF0h
                    R10 -= R9; // 82460D48  subf r10, r9, r10
                    R10 += 0x10; //82460D4C addi r10,r10,16; 10h
                    R7 = R11 >> (int)R8; // 82460D50  srw r7, r11, r8
                    R11 <<= (int)R30; //82460D54  slw r11, r11, r30
                _82460D58:
                    {
                        //jmp
                    }
                    if ((int)R10 >= 0)
                    // 82460D58  cmpwi cr6, r10,0
                    // 82460D5C bge cr6,82460D88

                    {
                        goto _82460D88;
                    }
                    R11 = Compressed_Data[R5]; //82460D60  lbz r11,0(r5)
                    R8 = R23 << 8; //82460D64  slwi r8, r23,8
                    R30 = Compressed_Data[R5 + 1]; //82460D68  lbz r30,1(r5)
                    R28 = Neg(R28, R10); //82460D6C neg r28,r10
                    R11 |= R8; //82460D70  or r11, r8, r11
                    R5 += 2; //82460D74  addi r5, r5,2
                    R11 <<= 8; // 82460D78  slwi r11, r11,8
                    R10 += 0x10; //82460D7C addi r10,r10,16; 10h
                    R23 = R11 | R30; //82460D80  or r23, r11, r30
                    R11 = R23 << (int)R28; //82460D84  slw r11, r23, r28
                _82460D88:
                    {
                        //jmp
                    }
                    R10 -= 0x10; //82460D88  addi r10, r10,-16; 0FFF0h
                    R8 = R11 >> 16; // 82460D8C srwi r8,r11,16
                    R11 <<= 16; //82460D90  slwi r11, r11,16
                    if ((int)R10 >= 0)
                    //82460D94  cmpwi cr6, r10,0
                    // 82460D98  bge cr6,82460DC4
                    {
                        goto _82460DC4;
                    }
                    R11 = Compressed_Data[R5]; //82460D9C lbz r11,0(r5)
                    R30 = R23 << 8; //82460DA0 slwi r30,r23,8
                    R28 = Compressed_Data[R5 + 1]; // 82460DA4 lbz r28,1(r5)
                    R27 = Neg(R27, R10); // 82460DA8 neg r27,r10
                    R11 |= R30; //82460DAC or r11,r30,r11
                    R5 += 2; //82460DB0 addi r5,r5,2
                    R11 <<= 8; // 82460DB4 slwi r11,r11,8
                    R10 += 0x10; // 82460DB8 addi r10,r10,16; 10h
                    R23 = R11 | R28; //82460DBC or r23,r11,r28
                    R11 = R23 << (int)R27; // 82460DC0 slw r11,r23,r27
                _82460DC4:
                    {
                        //jmp
                    }
                    R7 <<= 16; //82460DC4 slwi r7,r7,16
                    R9 = R20 << (int)R9; // 82460DC8 slw r9,r20,r9
                    R8 |= R7; //82460DCC or r8,r7,r8
                    R9 += R8; //82460DD0 add r9,r8,r9
                    goto _82460E2C; //82460DD4 b 82460E2C 

                _82460DD8:
                    {
                        //jmp
                    }
                    if ((int)R9 == 0)
                    //82460DD8 cmpwi cr6,r9,0
                    //82460DDC beq cr6,82460DF4
                    {
                        goto _82460DF4;
                    }
                    R8 = R11; // 82460DE0 mr r8,r11
                    R7 = 0x20 - R9;//82460DE4 subfic r7,r9,32; 20h
                    R11 <<= (int)R9; //82460DE8 slw r11,r11,r9
                    R10 -= R9; //82460DEC subf r10,r9,r10
                    R7 = R8 >> (int)R7; //82460DF0 srw r7,r8,r7

                _82460DF4:
                    {
                        //jmp
                    }
                    if ((int)R10 >= 0)
                    // 82460DF4 cmpwi cr6,r10,0
                    //82460DF8 bge cr6,82460E24
                    {
                        goto _82460E24;
                    }
                    R11 = (byte)Compressed_Data[R5]; //82460DFC lbz r11,0(r5)
                    R8 = R23 << 8; // 82460E00  slwi r8, r23,8
                    R30 = (byte)Compressed_Data[R5 + 1]; //82460E04  lbz r30,1(r5)
                    R28 = Neg(R28, R10); //82460E08  neg r28, r10
                    R11 |= R8; //82460E0C or r11,r8,r11
                    R5 += 2; //82460E10  addi r5, r5,2
                    R11 <<= 8; //82460E14  slwi r11, r11,8
                    R10 += 0x10; //82460E18  addi r10, r10,16; 10h
                    R23 = R11 | R30; //82460E1C or r23,r11,r30
                    R11 = R23 << (int)R28; //82460E20  slw r11, r23, r28

                _82460E24:
                    {
                        //jmp
                    }
                    R9 = R20 << (int)R9; //82460E24  slw r9, r20, r9
                    R9 += R7; //82460E28  add r9, r9, r7
                _82460E2C:
                    {
                        //jmp;
                    }
                    R9 -= 4; //82460E2C addi r9,r9,-4; 0FFFCh
                    R8 = R9 + 1; // 82460E30  addi r8, r9,1


                    /*
                    The Byte Scanner Loop
                    */
                    do
                    {
                        R9 = R6 + 1; //82460E34  addi r9, r6,1
                        R7 = R1 + 0x50; //82460E38  addi r7, r1,80; 50h
                        R9 &= 0x000000FF; //82460E3C clrlwi r9,r9,24
                        R6 = R9; //82460E40  mr r6, r9
                        R7 = cache[R6 + R7]; //82460E44  lbzx r7, r6, r7
                        if (R7 != 0)//82460E48  cmplwi cr6, r7,0
                                    //82460E4C bne cr6,82460E54
                        {
                            goto _82460E54;
                        }
                        R8 -= 1; //82460E50  addi r8, r8,-1; 0FFFFh

                    _82460E54:
                        {
                            //jmp
                        }
                    }

                    //82460E54  cmpwi cr6, r8,0
                    //82460E58  bne cr6,82460E34
                    while (R8 != 0);
                    R8 = R1 + 0x2D0; // 82460E5C addi r8,r1,720; 2D0h
                    R6 = R9 & 0x000000FF; //82460E60  clrlwi r6, r9,24
                    R7 = R1 + 0x50; //82460E64  addi r7, r1,80; 50h
                    cache[R31 + R8] = (byte)R9;         //82460E68  stbx r9, r31, r8
                    R31 += 1;// 82460E6C addi r31,r31,1
                    cache[R6 + R7] = (byte)R20;       //82460E70  stbx r20, r6, r7
                }
                //82460E74  cmpw cr6, r31, r29
                //82460E78  blt cr6,82460C20
                while ((int)R31 < R29);
            _82460E7C:
                {
                    //jmp
                }
                R9 = 0x40400000; //82460E7C  lis r9,16448		; 4040h 
                R7 = 0x10; //82460E80  li r7,16		; 10h
                R8 = R1 + 0x1D8; //82460E84  addi r8, r1,472; 1D8h
                R9 |= 0x4040; //82460E88  ori r9,r9,16448		; 4040h 
                do
                {
                    R7 -= 1; //82460E8C  addi r7,r7,-1		; 0FFFFh 
                    WriteUInt32(cache, (int)(R8 - 8), R9, false);  //82460E90  stw r9,-8(r8)
                    WriteUInt32(cache, (int)(R8 - 4), R9, false); //82460E94  stw r9,-4(r8)
                    WriteUInt32(cache, (int)(R8), R9, false);  //82460E98  stw r9,0(r8)
                    WriteUInt32(cache, (int)(R8 + 4), R9, false); //82460EA0 stw r9,4(r8)
                    R8 += 0x10; //82460EA4  addi r8,r8,16		; 10h 
                                //82460E9C cmpwi cr6,r7,0
                                //82460EA8 bne cr6,82460E8C
                }
                while (R7 != 0);


                R29 = R1 + 0x2D0; //82460EAC  addi r29,r1,720		; 2D0h 
                R28 = R1 + 0x50; //82460EB0  addi r28,r1,80		; 50h 
                R27 = R1 + 0x1D0; //82460EB4  addi r27,r1,464		; 1D0h 
                R30 = R20; // 82460EB8  mr r30,r20 

                /*We are leaving the initialization block behind and stepping straight into the next
                 * major phase of the decompression routine. This block sets up base pointers to three separate tables/arrays 
                 * on the stack frame that were either populated during the previous loops or initialized by that 0x40404040 block fill.*/

                if ((int)R22 < 1)
                //82460EBC  cmpwi cr6,r22,1 
                //82460EC0 blt cr6,82460F74
                {
                    goto _82460F74;
                }
                R25 = 7; // 82460EC4  li r25,7 
                R24 = R1 + 0x194; //82460EC8  addi r24,r1,404		; 194h 

                do
                {
                    //this might need to be flipped?
                    R31 = ReadUInt32(cache, (int)R24, false); //82460ECC  lwz r31,0(r24) 
                    if ((int)R25 <= -1)
                    //82460ED0  cmpwi cr6, r25,65535; 0FFFFh
                    //82460ED4  ble cr6,82460F74 
                    {
                        goto _82460F74;
                    }
                    R6 = R20 << (int)R25; //82460EDC  slw r6,r20,r25 
                    if (R31 == 0)
                    //82460ED8  cmpwi cr6,r31,0 
                    //82460EE0 beq cr6,82460F60
                    {
                        goto _82460F60;
                    }
                    R26 = R18 & 0x000000FF; //82460EE4  clrlwi r26,r18,24 

                _82460EE8:
                    {
                        //jmp
                    }
                    R7 = cache[R29]; //82460EE8 lbz r7,0(r29)
                    R31 -= 1; // 82460EEC  addi r31,r31,-1		; 0FFFFh 
                    R29 += 1; //82460EF0  addi r29,r29,1 
                    R9 = R30; //82460EF4  mr r9,r30 
                    if ((int)R7 != R26)
                    //82460EF8  cmpw cr6,r7,r26 
                    //82460EFC bne cr6,82460F08
                    {
                        goto _82460F08;
                    }
                    R15 = R30;// 82460F00  mr r15, r30
                    R9 = 0x60;// 82460F04  li r9,96; 60h
                _82460F08:
                    if ((int)R6 <= 0)
                    //82460F08  cmpwi cr6,r6,0 
                    //82460F0C ble cr6,82460F58
                    {
                        goto _82460F58;
                    }
                    R8 = R9 & 0x000000FF; //82460F10  clrlwi r8,r9,24
                    R9 = R27; //82460F14  mr r9,r27 
                    if (R6 == 0)
                    {
                        goto _82460F30;
                    }
                    //82460F18  cmplwi cr6, r6,0
                    //82460F1C beq cr6,82460F30
                    uint mtctr = R6; // 82460F20  mtctr r6
                    do
                    {
                        cache[R9] = (byte)R8; //82460F24  stb r8,0(r9)
                        R9 += 1;// 82460F28  addi r9, r9,1

                    } while (--mtctr != 0); //82460F2C bdnz 82460F24

                _82460F30:
                    {
                        //jmp
                    }
                    R8 = R7 & 0x000000FF; //82460F30  clrlwi r8, r7,24
                    R9 = R28; //82460F34  mr r9, r28
                    if (R6 == 0)
                    //82460F38  cmplwi cr6, r6,0
                    // 82460F3C beq cr6,82460F50
                    {
                        goto _82460F50;
                    }
                    mtctr = R6;
                    do
                    {
                        //82460F44  stb r8,0(r9)
                        cache[R9] = (byte)R8;
                        R9 += 1; //82460F48  addi r9, r9,1

                    } while (--mtctr != 0); //82460F4C bdnz 82460F44

                _82460F50:
                    {
                        //jmp
                    }
                    R28 += R6; //82460F50  add r28, r6, r28
                    R27 += R6; //82460F54  add r27, r6, r27





                _82460F58:
                    {
                        //jmp
                    }

                    if ((int)R31 != 0)
                    //82460F58  cmpwi cr6, r31,0
                    //82460F5C bne cr6,82460EE8
                    {
                        goto _82460EE8;
                    }



                _82460F60:
                    {
                        //jmp
                    }
                    R30 += 1; // 82460F60  addi r30, r30,1
                    R24 += 4; //82460F64  addi r24, r24,4
                    R25 -= 1; //82460F68  addi r25, r25,-1; 0FFFFh


                    //82460F6C cmpw cr6,r30,r22
                    //82460F70  ble cr6,82460ECC
                }
                while ((int)R30 <= (int)R22);


            _82460F74:
                {
                    //kmp
                }
                R8 = R11 >> 24; //82460F74  srwi r8,r11,24 
                R9 = R1 + 0x1D0; //82460F78  addi r9,r1,464		; 1D0h 
                R9 = cache[R8 + R9];//82460F7C lbzx r9,r8,r9
                R10 -= R9; //82460F80  subf r10,r9,r10 
                if ((int)R10 < 0)
                //82460F84  cmpwi cr6,r10,0 
                // 82460F88  blt cr6,8246103C
                {
                    goto _8246103C;
                }
                do
                {
                    R11 <<= (int)R9; //82460F8C slw r11,r11,r9
                    R9 = R1 + 0x50; //82460F90  addi r9, r1,80; 50h
                    R7 = R1 + 0x1D0; //82460F94  addi r7, r1,464; 1D0h
                    R9 = cache[R8 + R9];//82460F98  lbzx r9, r8, r9
                    R8 = R11 >> 24; //82460F9C srwi r8,r11,24


                    Decompressed_Data[R21] = (byte)R9;             // 82460FA0 stb r9,0(r21)
                    R21 += 1; // 82460FA4 addi r21,r21,1
                    R9 = cache[R8 + R7]; // Load byte //82460FA8 lbzx r9,r8,r7
                    R10 -= R9; //82460FAC subf r10,r9,r10
                    if ((int)R10 < 0)
                    {
                        goto _8246103C;
                    }
                    //82460FB0 cmpwi cr6,r10,0
                    //82460FB4 blt cr6,8246103C

                    R11 <<= (int)R9; //82460FB8 slw r11,r11,r9
                    R9 = R1 + 0x50; //82460FBC addi r9,r1,80; 50h
                    R7 = R1 + 0x1D0; //82460FC0 addi r7,r1,464; 1D0h
                    R9 = cache[R8 + R9];// load byte //82460FC4 lbzx r9,r8,r9
                    R8 = R11 >> 24; //82460FC8 srwi r8,r11,24
                    Decompressed_Data[R21] = (byte)R9; //82460FCC stb r9,0(r21)


                    R21 += 1; // 82460FD0 addi r21,r21,1
                    R9 = cache[R8 + R7]; //load byte //82460FD4 lbzx r9,r8,r7
                    R10 -= R9; // 82460FD8 subf r10,r9,r10
                    if ((int)R10 < 0)
                    {
                        goto _8246103C;
                    }
                    //82460FDC cmpwi cr6,r10,0
                    //82460FE0 blt cr6,8246103C

                    R11 <<= (int)R9; //82460FE4 slw r11,r11,r9
                    R9 = R1 + 0x50; //82460FE8 addi r9,r1,80; 50h
                    R7 = R1 + 0x1D0; // 82460FEC addi r7,r1,464; 1D0h
                    R9 = cache[R8 + R9]; // 82460FF0 lbzx r9,r8,r9
                    R8 = R11 >> 24; //82460FF4 srwi r8,r11,24

                    Decompressed_Data[R21] = (byte)R9; //set byte//82460FF8 stb r9,0(r21)
                    R21 += 1; //82460FFC addi r21,r21,1
                    R9 = cache[R8 + R7];// Load byte //82461000  lbzx r9, r8, r7
                    R10 -= R9;//82461004  subf r10, r9, r10

                    if ((int)R10 < 0)
                    {
                        goto _8246103C;
                    }
                    //82461008  cmpwi cr6, r10,0
                    //8246100C blt cr6,8246103C

                    R11 <<= (int)R9; //82461010  slw r11, r11, r9
                    R9 = R1 + 0x50; //82461014  addi r9, r1,80; 50h
                    R7 = R1 + 0x1D0; //82461018  addi r7, r1,464; 1D0h
                    R9 = cache[R8 + R9];// load byte //8246101C lbzx r9,r8,r9
                    R8 = R11 >> 24; //82461020  srwi r8, r11,24
                    Decompressed_Data[R21] = (byte)R9;// write byte // 82461024  stb r9,0(r21)
                    R21 += 1; //82461028  addi r21, r21,1
                    R9 = cache[R7 + R8];// Load byte //8246102C lbzx r9,r8,r7
                    R10 -= R9; //82461030  subf r10, r9, r10
                               // 82461034  cmpwi cr6, r10,0
                               //82461038  bge cr6,82460F8C
                }
                while ((int)R10 >= 0);




            _8246103C:
                {

                }
                R10 += 0x10; //8246103C addi r10,r10,16; 10h
                if ((int)R10 < 0)
                //82461040  cmpwi cr6, r10,0
                //82461044  blt cr6,82461084
                {
                    goto _82461084;
                }
                R11 >>= 24; //82461048  srwi r11, r11,24
                R9 = R1 + 0x50; //8246104C addi r9,r1,80; 50h
                R8 = R23 << 8; //82461050  slwi r8, r23,8
                R7 = 0x10 - R10; //82461054  subfic r7, r10,16; 10h
                R11 = cache[R11 + R9];  //82461058  lbzx r11, r11, r9
                Decompressed_Data[R21] = (byte)R11;// write byte //8246105C stb r11,0(r21)
                R21 += 1; //82461060  addi r21, r21,1
                R11 = (byte)Compressed_Data[R5]; //82461064  lbz r11,0(r5)
                R9 = (byte)Compressed_Data[R5 + 1]; //82461068  lbz r9,1(r5)

                R5 += 2; //8246106C addi r5,r5,2
                R11 |= R8; //82461070  or r11, r8, r11
                R11 <<= 8; //82461074  slwi r11, r11,8
                R23 = R11 | R9; //82461078  or r23, r11, r9
                R11 = R23 << (int)R7; //8246107C slw r11,r23,r7
                goto _82460F74; //82461080  b 82460F74



            _82461084:
                {
                    //jmp
                }
                R10 += R9; //82461084  add r10, r9, r10
                R7 = R10 - 16; // 8246108C addi r7,r10,-16; 0FFF0h
                if ((int)R9 == 0x60)
                //82461088  cmpwi cr6, r9,96; 60h
                //82461090  beq cr6,824610B8
                {
                    goto _824610B8;
                }
                R8 = R11 >> 16; // 82461094  srwi r8, r11,16
                R10 = 0x8; //82461098  li r10,8
                R9 = R1 + 0x30; // 8246109C addi r9,r1,48; 30h
                do
                {
                    R9 += 4; //824610A0 addi r9,r9,4
                    R10 += 1; //824610A4 addi r10,r10,1

                    R6 = ReadUInt32(cache, (int)R9, false);// oad word //824610A8 lwz r6,0(r9)
                }
                // 824610AC cmplw cr6,r8,r6
                // 824610B0 bge cr6,824610A0
                while (R8 >= R6);
                goto _824610BC; //824610B4 b 824610BC






            _824610B8:
                {
                    //jmp
                }
                R10 = R15; // 824610B8 mr r10,r15
            _824610BC:
                {
                    //jmp
                }
                R9 = R11; // 824610BC mr r9,r11
                R6 = 0x20 - R10; //824610C0 subfic r6,r10,32; 20h
                R31 = R10 << 2; //824610C4 slwi r31,r10,2
                R30 = R1 + 0x150; //824610C8 addi r30,r1,336; 150h
                R11 <<= (int)R10; //824610CC slw r11,r11,r10
                R10 = R7 = R10; //824610D0  subf r10, r10, r7
                R29 = R1 + 0x2D0; //824610D4  addi r29, r1,720; 2D0h
                R8 = R18 & 0x000000FF; //824610D8  clrlwi r8, r18,24
                R7 = ReadUInt32(cache, (int)(R31 + R30), false); //load bytes //824610DC lwzx r7,r31,r30
                R9 >>= (int)R6; //824610E0  srw r9, r9, r6
                R9 -= R7; //824610E4  subf r9, r7, r9
                R9 = cache[R9 + R29]; //824610E8  lbzx r9, r9, r29
                R7 = R9; //824610EC mr r7,r9
                if (R7 == R8)
                //824610F0  cmplw cr6, r7, r8
                //824610F4  beq cr6,8246110C
                {
                    goto _8246110C;
                }
            _824610F8:
                {
                    //jmp
                }
                if ((int)R10 < 0)
                //824610F8  cmpwi cr6, r10,0
                //824610FC blt cr6,82461114
                {
                    goto _82461114;
                }

                Decompressed_Data[R21] = (byte)R9; //write byte //82461100  stb r9,0(r21)
                R21 += 1; //82461104  addi r21, r21,1
                goto _82460F74; //82461108  b 82460F74

            _8246110C:
                {
                    //jmp
                }
                if ((int)R10 >= 0)
                // 8246110C cmpwi cr6,r10,0
                // 82461110  bge cr6,8246113C
                {
                    goto _8246113C;
                }
            _82461114:
                {
                    //jmp
                }
                R11 = (byte)Compressed_Data[R5]; //82461114  lbz r11,0(r5)
                R6 = R23 << 8; //82461118  slwi r6, r23,8
                R31 = (byte)Compressed_Data[R5 + 1]; //8246111C lbz r31,1(r5)
                R30 = Neg(R30, R10); //82461120  neg r30, r10
                R11 |= R6; //82461124  or r11, r6, r11
                R5 += 2; // 82461128  addi r5, r5,2
                R11 <<= 8; // 8246112C slwi r11,r11,8
                R10 += 0x10; //82461130  addi r10, r10,16; 10h
                R23 = R11 | R31; //82461134  or r23, r11, r31
                R11 = R23 << (int)R30; // 82461138  slw r11, r23, r30

            _8246113C:
                {
                    //jmp
                }
                if (R7 == R8)
                //8246113C cmplw cr6,r7,r8
                //  beq cr6,82461150
                {
                    goto _82461150;
                }
                Decompressed_Data[R21] = (byte)R9; //Write byte //82461144  stb r9,0(r21)
                R21 += 1; // 82461148  addi r21, r21,1
                goto _82460F74; //8246114C b 82460F74


            _82461150:
                {
                    //jmp
                }
                R7 = R16; // 82461150  mr r7, r16
                R6 = R21; //82461154  mr r6, r21
                if ((int)R11 >= 0)
                // 82461158  cmpwi cr6, r11,0
                //8246115C bge cr6,824611A0
                {
                    goto _824611A0;
                }
                R10 -= 3; // 82461160  addi r10, r10,-3; 0FFFDh
                R9 = R11 >> 29; //82461164  srwi r9, r11,29
                R11 <<= 3; //82461168  slwi r11, r11,3
                if ((int)R10 >= 0)
                //8246116C cmpwi cr6,r10,0
                //82461170  bge cr6,82461360
                {
                    goto _82461360;
                }
                R11 = (byte)Compressed_Data[R5]; //82461174  lbz r11,0(r5)
                R8 = R23 << 8; //82461178  slwi r8, r23,8
                R7 = (byte)Compressed_Data[R5 + 1]; // 8246117C lbz r7,1(r5)
                R31 = Neg(R31, R10); //82461180  neg r31, r10
                R11 |= R8; //82461184  or r11, r8, r11
                R5 += 2; //82461188  addi r5, r5,2
                R11 <<= 8; //8246118C slwi r11,r11,8
                R10 += 0x10; // 82461190  addi r10, r10,16; 10h
                R23 = R11 | R7; //82461194  or r23, r11, r7
                R11 = R23 << (int)R31; //82461198  slw r11, r23, r31

                goto _82461360;//8246119C b 82461360


            _824611A0:
                {
                    //jmp
                }
                R9 = R11 & 0xFFFF0000; //824611A0 clrrwi r9,r11,16
                R9_Compare = R9;
                R9 = 2; // 824611A8 li r9,2
                if (R9_Compare == 0)
                //824611A4 cmplwi cr6,r9,0
                //824611AC beq cr6,8246121C
                {
                    goto _8246121C;
                }
                do
                {
                    R11 <<= 1; //824611B0 slwi r11,r11,1
                    R9 += 1; //824611B4 addi r9,r9,1
                } while ((int)R11 >= 0); //824611B8 cmpwi cr6,r11,0
                                         //824611BC bge cr6,824611B0
                R10 -= R9; //824611C0 subf r10,r9,r10
                R11 <<= 1; //824611C4 slwi r11,r11,1
                R10 += 1; //824611C8 addi r10,r10,1
                if (R19 == 0)
                //824611CC cmpwi cr6,r19,0
                //824611D0  beq cr6,824611E8
                {
                    goto _824611E8;
                }
                R8 = R11; //824611D4  mr r8, r11
                R7 = 0x20 - R19; //824611D8  subfic r7, r19,32; 20h
                R11 <<= (int)R19; // 824611DC slw r11,r11,r19
                R10 -= R19; //824611E0  subf r10, r19, r10
                R7 = R8 >> (int)R7; //824611E4  srw r7, r8, r7

            _824611E8:
                {
                    //jmp
                }
                if ((int)R10 >= 0)
                //824611E8  cmpwi cr6, r10,0
                //824611EC bge cr6,82461264
                {
                    goto _82461264;
                }
                R11 = (byte)Compressed_Data[R5]; //824611F0  lbz r11,0(r5)
                R8 = R23 << 8; //824611F4  slwi r8, r23,8
                R31 = (byte)Compressed_Data[R5 + 1]; //824611F8  lbz r31,1(r5)
                R30 = Neg(R30, R10); //824611FC neg r30,r10
                R11 |= R8; //82461200  or r11, r8, r11
                R5 += 2; //82461204  addi r5, r5,2
                R11 <<= 8; //82461208  slwi r11, r11,8
            _8246120C:
                {
                    //jmp
                }
                R10 += 0x10; //8246120C addi r10,r10,16; 10h
                R23 = R11 | R31; //82461210  or r23, r11, r31
                R11 = R23 << (int)R30; //82461214  slw r11, r23, r30
                goto _82461264; //82461218  b 82461264
            _8246121C:
                {
                    //jmp
                }
                do
                {

                    R10 -= 1; // 8246121C addi r10,r10,-1; 0FFFFh
                    R7 = R11 >> 31; //82461220  srwi r7, r11,31
                    R9 += 1; //82461224  addi r9, r9,1
                    R11 <<= 1; //82461228  slwi r11, r11,1
                    if ((int)R10 >= 0)
                    //8246122C cmpwi cr6,r10,0
                    //82461230  bge cr6,8246125C
                    {
                        goto _8246125C;
                    }
                    R11 = (byte)Compressed_Data[R5]; //82461234  lbz r11,0(r5)
                    R8 = R23 << 8; //82461238  slwi r8, r23,8
                    R31 = (byte)Compressed_Data[R5 + 1]; //8246123C lbz r31,1(r5)
                    R30 = Neg(R30, R10); //82461240  neg r30, r10
                    R11 |= R8; //82461244  or r11, r8, r11
                    R5 += 2; //82461248  addi r5, r5,2
                    R11 <<= 8; //8246124C slwi r11,r11,8
                    R10 += 0x10; //82461250  addi r10, r10,16; 10h
                    R23 = R11 | R31; //82461254  or r23, r11, r31
                    R11 = R23 << (int)R30; //82461258  slw r11, r23, r30
                _8246125C:
                    {
                        //jmp
                    }
                    //8246125C cmpwi cr6,r7,0
                    // 82461260  beq cr6,8246121C
                }
                while (R7 == 0);

            _82461264:
                {
                    //jmp;
                }
                if (R9 <= 0x10)
                //82461264  cmpwi cr6, r9,16; 10h
                //82461268  ble cr6,8246130C
                {
                    goto _8246130C;
                }
                R8 = R9 - 16; // 8246126C addic. r8,r9,-16; 0FFF0h
                if (R8 == 0x0)
                //82461270  beq 8246128C
                {
                    goto _8246120C;
                }
                R8 = 0x30 - R9; //82461274  subfic r8, r9,48; 30h
                R31 = R9 - 16; //82461278  addi r31, r9,-16; 0FFF0h
                R10 -= R9; // 8246127C subf r10,r9,r10
                R10 += 0x10;//82461280  addi r10, r10,16; 10h
                R7 = R11 >> (int)R8;//82461284  srw r7, r11, r8
                R11 <<= (int)R31; //82461288  slw r11, r11, r31

                if ((int)R10 >= 0)
                //8246128C cmpwi cr6,r10,0
                //82461290  bge cr6,824612BC
                {
                    goto _824612BC;
                }
                R11 = Compressed_Data[R5]; // 82461294  lbz r11,0(r5)

                R8 = R23 << 8; //82461298  slwi r8, r23,8
                R31 = Compressed_Data[R5 + 1]; //8246129C lbz r31,1(r5)
                R30 = Neg(R30, R10); //824612A0 neg r30,r10
                R11 |= R8; //824612A4 or r11,r8,r11

                R5 += 2; //824612A8 addi r5,r5,2
                R11 <<= 8; //824612AC slwi r11,r11,8
                R10 += 0x10; //824612B0 addi r10,r10,16; 10h
                R23 = R11 |= R31; // 824612B4 or r23,r11,r31
                R11 = R23 << (int)R30; //824612B8 slw r11,r23,r30

            _824612BC:
                {

                }
                R10 -= 0x10; //824612BC addi r10,r10,-16; 0FFF0h
                R8 = R11 >> 16; // 824612C0 srwi r8,r11,16
                R11 <<= 16; //824612C4 slwi r11,r11,16

                if ((int)R10 >= 0)
                //824612C8 cmpwi cr6,r10,0
                //824612CC bge cr6,824612F8
                {
                    goto _824612F8;
                }
                R11 = Compressed_Data[R5];//824612D0  lbz r11,0(r5)
                R31 = R23 << 8; //  824612D4  slwi r31, r23,8
                R30 = Compressed_Data[R5 + 1]; //824612D8  lbz r30,1(r5)
                R29 = Neg(R29, R10); //824612DC neg r29,r10
                R11 |= R31; //824612E0  or r11, r31, r11
                R5 += 2; //824612E4  addi r5, r5,2
                R11 <<= 8; // 824612E8  slwi r11, r11,8
                R10 += 0x10; //824612EC addi r10,r10,16; 10h
                R23 = R11 | R30; //824612F0  or r23, r11, r30
                R11 = R23 << (int)R29; //824612F4  slw r11, r23, r29
            _824612F8:
                {
                    //jmp
                }
                R7 <<= 16; //824612F8  slwi r7, r7,16
                R9 = R20 << (int)R9; // 824612FC slw r9,r20,r9
                R8 |= R7; //82461300  or r8, r7, r8
                R9 += R8; // 82461304  add r9, r8, r9
                goto _82461360; //82461308  b 82461360



            _8246130C:
                {
                    //jmp
                }
                if (R9 == 0)
                //8246130C cmpwi cr6,r9,0
                //82461310  beq cr6,82461328
                {
                    goto _82461328;
                }
                R8 = R11;//82461314  mr r8, r11
                R7 = 0x20 - R9; //82461318  subfic r7, r9,32; 20h
                R11 <<= (int)R9; //8246131C slw r11,r11,r9
                R10 -= R9; //82461320  subf r10, r9, r10
                R7 = R8 >> (int)R7; // 82461324  srw r7, r8, r7
            _82461328:
                {
                    //jmp
                }
                if ((int)R10 >= 0)
                //82461328  cmpwi cr6, r10,0
                //8246132C bge cr6,82461358
                {
                    goto _82461358;
                }
                R11 = Compressed_Data[R5]; // 82461330  lbz r11,0(r5)
                R8 = R23 << 8; //82461334  slwi r8, r23,8
                R31 = Compressed_Data[R5 + 1]; //82461338  lbz r31,1(r5)
                R30 = Neg(R30, R10); //8246133C neg r30,r10
                R11 |= R8; // 82461340  or r11, r8, r11
                R5 += 2; //82461344  addi r5, r5,2
                R11 <<= 8; //82461348  slwi r11, r11,8
                R10 += 0x10; //8246134C addi r10,r10,16; 10h
                R23 = R11 | R31; //82461350  or r23, r11, r31
                R11 = R23 << (int)R30; //82461354  slw r11, r23, r30
            _82461358:
                {
                    //jmp
                }
                R9 = R20 << (int)R9; //82461358  slw r9, r20, r9
                R9 += R7; //8246135C add r9,r9,r7

            _82461360:
                {
                    //jmp
                }
                R9 -= 4; //82461360  addi r9, r9,-4; 0FFFCh
                if (R9 == 0)
                // 82461364  cmpwi cr6, r9,0
                //82461368  beq cr6,8246138C
                {
                    goto _8246138C;
                }
                R8 = Decompressed_Data[R21 - 1]; // load byte //8246136C lbz r8,-1(r21)
                R9 += R21; //82461370  add r9, r9, r21
                return Decompressed_Data;
                do
                {
                    cache[R6] = (byte)R8; //82461374  stb r8,0(r6)
                    R6 += 1; //82461378  addi r6, r6,1
                }
                //8246137C cmplw cr6,r6,r9
                //82461380  blt cr6,82461374
                while (R6 < R9);
                R21 = R6; //82461384  mr r21, r6
                goto _82460F74; //82461388  b 82460F74
            _8246138C:
                {
                    //jmp
                }
                R10 -= 1; // 8246138C addi r10,r10,-1; 0FFFFh
                R9 = R11 >> 31; //82461390  srwi r9, r11,31
                R11 <<= 1; //82461394  slwi r11, r11,1
                if ((int)R10 >= 0)
                //82461398  cmpwi cr6, r10,0
                //8246139C bge cr6,824613C8
                {
                    goto _824613C8;
                }
                R11 = Compressed_Data[R5]; //824613A0 lbz r11,0(r5)
                R8 = R23 << 8; //824613A4 slwi r8,r23,8
                R7 = Compressed_Data[R5 + 1]; //824613A8 lbz r7,1(r5)
                R6 = Neg(R6, R10); //824613AC neg r6,r10

                R11 |= R8; //824613B0 or r11,r8,r11
                R5 += 2; //824613B4 addi r5,r5,2
                R11 <<= 8; //824613B8 slwi r11,r11,8
                R10 += 0x10; // 824613BC addi r10,r10,16; 10h
                R23 = R11 | R7; //824613C0 or r23,r11,r7
                R11 = R23 << (int)R6; //824613C4 slw r11,r23,r6
            _824613C8:
                {
                    //jmp
                }
                if (R9 != 0)
                //824613C8 cmplwi cr6,r9,0
                //824613CC bne cr6,82461418
                {
                    goto _82461418;
                }
                R10 -= 8; //824613D0  addi r10, r10,-8; 0FFF8h
                R9 = R11 >> 24; //824613D4  srwi r9, r11,24
                R11 <<= 8; // 824613D8  slwi r11, r11,8
                if ((int)R10 >= 0)
                //824613DC cmpwi cr6,r10,0
                //824613E0  bge cr6,8246140C
                {
                    goto _8246140C;
                }
                R11 = Compressed_Data[R5]; //824613E4  lbz r11,0(r5)
                R8 = R23 << 8; //824613E8  slwi r8, r23,8
                R7 = Compressed_Data[R5 + 1]; // 824613EC lbz r7,1(r5)
                R6 = Neg(R6, R10); //824613F0  neg r6, r10
                R11 |= R8; //824613F4  or r11, r8, r11
                R8 += 2; //824613F8  addi r5, r5,2
                R11 <<= 8; // 824613FC slwi r11,r11,8
                R10 += 0x10; //82461400  addi r10, r10,16; 10h
                R23 = R11 | R7; //82461404  or r23, r11, r7
                R11 = R23 << (int)R6; //82461408  slw r11, r23, r6
            _8246140C:
                {
                    //jmp
                }
                Decompressed_Data[R21] = (byte)R9; //8246140C stb r9,0(r21)
                R21 += 1; //82461410  addi r21, r21,1
                goto _82460F74; //82461414  b 82460F74
            _82461418:
                {
                    //jmp
                }
                if (R17 == 0x32FB)
                //82461418  cmplwi cr6, r17,13051; 32FBh
                //8246141C beq cr6,82461474
                {
                    goto _82461474;
                }
                else if (R17 == 0xB2FB)
                //82461420  cmplwi cr6, r17,45819; 0B2FBh
                //82461424  beq cr6,82461474
                {
                    goto _82461474;
                }
                else if (R17 == 0x34FB)
                //82461428  cmplwi cr6, r17,13563; 34FBh
                //8246142C beq cr6,82461438
                {
                    goto _82461438;
                }
                else if (R17 != 0xB4FB)
                // 82461430  cmplwi cr6, r17,46331; 0B4FBh
                //82461434  bne cr6,824614A0
                {
                    goto _824614A0;
                }
            _82461438:
                {
                    //jmp
                }
                R8 = R3 + R4; //82461438  add r8, r3, r4
                R10 = R16; //8246143C mr r10,r16
                R9 = R16; //82461440  mr r9, r16
                R11 = R4; //82461444  mr r11, r4
                if (R4 >= R8)
                //82461448  cmplw cr6, r4, r8
                //8246144C bge cr6,824614A0
                {
                    goto _824614A0;
                }
                do
                {


                    R7 = cache[R11]; // load_byte //82461450  lbz r7,0(r11)
                    R10 += R7;//82461454  add r10, r7, r10
                    R9 += R10; //82461458  add r9, r9, r10
                    cache[R11] = (byte)R9; //8246145C stb r9,0(r11)
                    R11 += 1; //82461460  addi r11, r11,1
                }
                //82461464  cmplw cr6, r11, r8
                //82461468  blt cr6,82461450
                while (R11 < R8);
                R1 += 0x460; //8246146C addi r1,r1,1120; 460h

            //82461470  b 8279C1C4
            _82461474:
                {
                    //jmp
                }
                R9 = R3 + R4; //82461474  add r9, r3, r4
                R10 = R16; // 82461478  mr r10, r16
                R11 = R4; //8246147C mr r11,r4
                if (R4 >= R9)
                //  82461480  cmplw cr6, r4, r9
                //82461484  bge cr6,824614A0
                {
                    goto _824614A0;
                }
                do
                {


                    R8 = cache[R11]; //82461488  lbz r8,0(r11)

                    R10 += R8; //8246148C add r10,r8,r10

                    cache[R11] = (byte)R10; //82461490  stb r10,0(r11)
                    R11 += 1; //82461494  addi r11, r11,1



                    //82461498  cmplw cr6, r11, r9
                    //8246149C blt cr6,82461488
                }
                while (R11 < R9);
            _824614A0:
                {
                    //jmp
                }
                R1 += 0x460; //824614A0 addi r1,r1,1120; 460h

                // 824614A4 b 8279C1C4
                R11 = R3; //824614A8 mr r11,r3
                R3 = R4; //824614AC mr r3,r4
                R4 = R11; //824614B0 mr r4,r11
                return null;
                // 824614B4 b 824606D0
            }
        }
    }






