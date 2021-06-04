using System;
using System.IO;
using System.Text;

namespace ATLAS_MICRO_ASSEMBLER_8
{
    class Program
    {
        static void Main(string[] args)
        {
            // ATLAS CPU-8 MICRO-ASSEMBLER
            // WRITTEN BY HAYDEN B. - 2021

            // Define microcode file
            string PATH = @"C:\Users\Hayden\Documents\ATLAS CPU 8\Microassembly\MICROCODE.hex";

            if (!File.Exists(PATH))
            {
                // Create a file to write to.
                File.WriteAllText(PATH, "v2.0 raw" + Environment.NewLine);
            }

            // Define mnemonics
            // long A_ST     = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;

            long A_ST           = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001000;
            long B_ST           = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001001;
            long C_ST           = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001010;
            long D_ST           = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001011;
            long IR_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001100;
            long PC_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001101;
            long PCH_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001110;
            long PCL_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_001111;
            long SP_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010000;
            long IX_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010001;
            long IXH_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010010;
            long IXL_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010011;
            long IY_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010100;
            long IYH_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010101;
            long IYL_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010110;            
            long REL_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_010111;
            long MARH_ST        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100000;
            long MARL_ST        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100001;
            long SUM_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100010;
            long MEM_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100011;
            long TMEM_ST        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100100;
            long ADD_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100101;
            long MDR_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_100110;

            long A_DOUT         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001000_000000;
            long B_DOUT         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001001_000000;
            long C_DOUT         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001010_000000;
            long D_DOUT         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001011_000000;
            long F_DOUT         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001100_000000;
            long PCH_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001101_000000;
            long PCL_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001110_000000;
            long SP_DOUT        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_001111_000000;
            long IXH_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010000_000000;
            long IXL_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010001_000000;
            long IYH_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010010_000000;
            long IYL_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010011_000000;           
            long SUM_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010100_000000;
            long MEM_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010101_000000;
            long BYTE_DOUT      = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010110_000000;
            long RST_VOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_010111_000000;
            long NMI_VOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_100000_000000;
            long BRK_VOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_100001_000000;
            long IRJ_VOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_100010_000000;
            long IRK_VOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_100011_000000;
            long BIT_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_100100_000000;
            long MDR_DOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_100101_000000;

            long BC_AOUT        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_001_000000_000000;
            long PC_AOUT        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_010_000000_000000;
            long SP_AOUT        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_011_000000_000000;
            long IX_AOUT        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_100_000000_000000;
            long IY_AOUT        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_101_000000_000000;
            long MAR_AOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_110_000000_000000;
            long ADD_AOUT       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_111_000000_000000;

            long COND_N         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_001_000_000000_000000;
            long COND_Z         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_010_000_000000_000000;
            long COND_V         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_011_000_000000_000000;
            long COND_C         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_100_000_000000_000000;
            long COND_X         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_101_000_000000_000000;
            long COND_Y         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_110_000_000000_000000;

            long FNZ_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01000_000_000_000000_000000;
            long FV_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01001_000_000_000000_000000;
            long FC_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01010_000_000_000000_000000;
            long FNZVC_ST       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01011_000_000_000000_000000;
            long FX_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01100_000_000_000000_000000;
            long FY_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01101_000_000_000000_000000;
            long F_ST           = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01110_000_000_000000_000000;
            long FJ_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_01111_000_000_000000_000000;
            long FK_ST          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_10000_000_000_000000_000000;
            long FJK_ST         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_10001_000_000_000000_000000;

            long A_CLR          = 0b000_00_000_0_0_0_00_0_0_00_0_0000_001_00000_000_000_000000_000000;
            long IX_CLR         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_010_00000_000_000_000000_000000;
            long IY_CLR         = 0b000_00_000_0_0_0_00_0_0_00_0_0000_011_00000_000_000_000000_000000;
            long ALL_CLR        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_100_00000_000_000_000000_000000;
            long IRK_CLR        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_101_00000_000_000_000000_000000;
            long IRJ_CLR        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_110_00000_000_000_000000_000000;
            long TEMP_CLR       = 0b000_00_000_0_0_0_00_0_0_00_0_0000_111_00000_000_000_000000_000000;

            long ALU_ADD        = 0b000_00_000_0_0_0_00_0_0_10_0_1001_000_00000_000_000_000000_000000;
            long ALU_ADC        = 0b000_00_000_0_0_0_00_0_0_01_0_1001_000_00000_000_000_000000_000000;
            long ALU_SUB        = 0b000_00_000_0_0_0_00_0_0_00_0_0110_000_00000_000_000_000000_000000;
            long ALU_SBB        = 0b000_00_000_0_0_0_00_0_0_01_0_0110_000_00000_000_000_000000_000000;
            long ALU_SFT        = 0b000_00_000_0_0_0_00_0_0_10_0_1100_000_00000_000_000_000000_000000;
            long ALU_ROT        = 0b000_00_000_0_0_0_00_0_1_10_0_1100_000_00000_000_000_000000_000000;
            long ALU_INC        = 0b000_00_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;
            long ALU_DEC        = 0b000_00_000_0_0_0_00_0_0_10_0_1111_000_00000_000_000_000000_000000;
            long ALU_NOA        = 0b000_00_000_0_0_0_00_0_0_00_1_0000_000_00000_000_000_000000_000000;
            long ALU_NOB        = 0b000_00_000_0_0_0_00_0_0_00_1_0101_000_00000_000_000_000000_000000;
            long ALU_AND        = 0b000_00_000_0_0_0_00_0_0_00_1_1011_000_00000_000_000_000000_000000;
            long ALU_OR         = 0b000_00_000_0_0_0_00_0_0_00_1_1110_000_00000_000_000_000000_000000;
            long ALU_XOR        = 0b000_00_000_0_0_0_00_0_0_00_1_0110_000_00000_000_000_000000_000000;

            long COND_NEG       = 0b000_00_000_0_0_0_00_1_0_00_0_0000_000_00000_000_000_000000_000000;

            long SP_INC         = 0b000_00_000_0_0_0_10_0_0_00_0_0000_000_00000_000_000_000000_000000;
            long SP_DEC         = 0b000_00_000_0_0_0_11_0_0_00_0_0000_000_00000_000_000_000000_000000;

            long PC_INC         = 0b000_00_000_0_0_1_00_0_0_00_0_0000_000_00000_000_000_000000_000000;

            long REG_AIN        = 0b000_00_000_0_1_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;
            long F_DIN          = 0b000_00_000_1_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;

            long SEQ_INC        = 0b000_00_001_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;
            long SEQ_RS0        = 0b000_00_010_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;
            long SEQ_RS1        = 0b000_00_110_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;

            long IRQ_EN         = 0b000_01_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;
            long DMA_ACK        = 0b000_10_000_0_0_0_00_0_0_00_0_0000_000_00000_000_000_000000_000000;


            // Write your microcode here
            // {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00 TEST

            long[,] TEMPLATE = new long[256, 32] {
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, ALL_CLR|RST_VOUT|REG_AIN|PC_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MARH_ST|SEQ_INC, PC_INC|BYTE_DOUT|FJK_ST|SP_ST|SEQ_INC, PC_AOUT|SP_INC|MEM_DOUT|MARL_ST|SEQ_INC, ALU_SUB|FNZVC_ST|MAR_AOUT|REG_AIN|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00 RST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, F_DOUT|TMEM_ST|PC_INC|SEQ_INC, BYTE_DOUT|FJK_ST|SP_AOUT|MEM_ST|SEQ_INC, PCH_DOUT|TMEM_ST|SP_INC|SEQ_INC, SP_AOUT|MEM_ST|SEQ_INC, PCL_DOUT|TMEM_ST|SP_INC|SEQ_INC, SP_AOUT|MEM_ST|SEQ_INC, SP_INC|BRK_VOUT|REG_AIN|PC_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MARH_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MARL_ST|SEQ_INC, MAR_AOUT|REG_AIN|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01 BRK
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02 NMI
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03 IRJ
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04 IRK
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05 HALT
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06 JMP BC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07 JMP (BC)
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08 JMP IX
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09 JMP IY
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A JMP $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B JMP ($m)
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C JMP $+m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30 MOV A, B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31 MOV A, C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32 MOV A, D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33 MOV A, F
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34 MOV A, F2
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35 MOV A, PCH
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|PCL_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36 MOV A, PCL
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SP_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37 MOV A, SP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|IXH_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38 MOV A, IXH
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|IXL_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39 MOV A, IXL
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|IYH_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A MOV A, IYH
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|IYL_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B MOV A, IYL
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C MOV B, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|C_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D MOV B, C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|D_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E MOV B, D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|C_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F MOV C, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|B_DOUT|C_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 40 MOV C, B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|D_DOUT|C_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 41 MOV C, D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|D_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 42 MOV D, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|B_DOUT|D_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 43 MOV D, B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|C_DOUT|D_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 44 MOV D, C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|IXH_DOUT|B_ST|SEQ_INC, IXL_DOUT|C_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 45 MOV BC, IX
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|IYH_DOUT|B_ST|SEQ_INC, IYL_DOUT|C_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 46 MOV BC, IY
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|PCH_DOUT|B_ST|SEQ_INC, PCL_DOUT|C_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 47 MOV BC, PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|SP_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 48 MOV SP, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|F_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 49 MOV F, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|IXH_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4A MOV IXH, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|IXL_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4B MOV IXL, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|IYH_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4C MOV IYH, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|IYL_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4D MOV IYL, A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|B_DOUT|IXH_ST|SEQ_INC, C_DOUT|IXL_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4E MOV IX, BC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|PCH_DOUT|IXH_ST|SEQ_INC, PCL_DOUT|IXL_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4F MOV IX, PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|B_DOUT|IYH_ST|SEQ_INC, C_DOUT|IYL_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 50 MOV IY, BC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|PCH_DOUT|IYH_ST|SEQ_INC, PCL_DOUT|IYL_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 51 MOV IY, PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|A_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 52 LD A, m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MARH_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MARL_ST|SEQ_INC, PC_INC|MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 53 LD A, $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MARH_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MARL_ST|SEQ_INC, PC_AOUT|BIT_DOUT|ADD_ST|SEQ_INC, MAR_AOUT|REG_AIN|PC_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MARH_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MARL_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST, ADD_AOUT|REG_AIN|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 54 LD A, ($m)
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|IX_AOUT|ADD_ST|SEQ_INC, ADD_AOUT|REG_AIN|IX_ST|SEQ_INC, IX_AOUT|MEM_DOUT|A_ST|FX_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 55 LD A, $x+m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|IY_AOUT|ADD_ST|SEQ_INC, ADD_AOUT|REG_AIN|IY_ST|SEQ_INC, IX_AOUT|MEM_DOUT|A_ST|FY_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 56 LD A, $y+m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 57 LD A, ($x+m)
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 58 LD A, ($y+m)
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 59 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 60 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 61 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 62 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 63 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 64 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 65 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 66 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 67 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 68 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 69 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 70 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 71 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 72 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 73 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 74 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 75 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 76 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 77 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 78 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 79 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 80 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 81 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 82 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 83 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 84 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 85 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 86 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 87 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 88 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 89 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 90 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 91 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 92 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 93 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 94 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 95 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 96 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 97 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 98 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 99 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // AB NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|ALU_INC|FNZVC_ST|SUM_ST|SEQ_INC, SUM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F1 INC A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // FE NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}  // FF NOP
            };

            // Interrupts

            int IRQ_DMA     = 0b000001;
            int IRQ_RESET   = 0b000011;
            int IRQ_NMI     = 0b000111;
            int IRQ_IRJ     = 0b001111;
            int IRQ_IRK     = 0b011111;
            int IRQ_HALT    = 0b111111;

            long[] INTERRUPT_TABLE = new long[256] {
                IRQ_DMA, IRQ_RESET, 0, 0, 0, 0, 0, 0, 0, 0, IRQ_HALT, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            int[] BRANCH_TABLE = new int[256] {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            int[] BRANCH = new int[32]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            Console.WriteLine("ATLAS MICRO-ASSEMBLER 8 - FOR USE WITH THE CPU-8 MINIPROCESSING SYSTEM\n");      

            long[] TEMPLATE_HALT = new long[32];

            int instruction = 0;

            while (instruction < 2)
            {
            
                int cond = 0;

                while (cond < 2)
                {

                    int imode = 0;

                    while (imode < 64)
                    {

                        int step = 0;

                        while (step < 32)
                        {

                            if (BRANCH_TABLE[instruction] == 1 && cond == 1)
                            {
                                Console.WriteLine(BRANCH[step].ToString("X"));
                                File.AppendAllText(PATH, BRANCH[step].ToString("X") + Environment.NewLine);
                            }
                            else
                            {

                                if ((imode & INTERRUPT_TABLE[instruction]) != 0)
                                {
                                    if ((imode & 0b000001) != 0)
                                    {

                                        if ((INTERRUPT_TABLE[instruction] & 0b000001) != 0)
                                        {
                                            Console.WriteLine((IRQ_EN|DMA_ACK).ToString("X"));
                                            File.AppendAllText(PATH, (IRQ_EN | DMA_ACK).ToString("X") + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                        }
                                        
                                    }
                                    else if ((imode & 0b000010) != 0)
                                    {
                                        
                                        if ((INTERRUPT_TABLE[instruction] & 0b000010) != 0)
                                        {
                                            Console.WriteLine(TEMPLATE[0, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[0, step].ToString("X") + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                        }
                                    }
                                    else if ((imode & 0b000100) != 0)
                                    {
                                        if ((INTERRUPT_TABLE[instruction] & 0b000100) != 0)
                                        {
                                            Console.WriteLine(TEMPLATE[2, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[2, step].ToString("X") + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                        }                                        
                                    }
                                    else if ((imode & 0b001000) != 0)
                                    {
                                        if ((INTERRUPT_TABLE[instruction] & 0b001000) != 0)
                                        {
                                            Console.WriteLine(TEMPLATE[3, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[3, step].ToString("X") + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                        }                                        
                                    }
                                    else if ((imode & 0b010000) != 0)
                                    {
                                        if ((INTERRUPT_TABLE[instruction] & 0b010000) != 0)
                                        {
                                            Console.WriteLine(TEMPLATE[4, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[4, step].ToString("X") + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                        }                                        
                                    }
                                    else if ((imode & 0b100000) != 0)
                                    {
                                        if ((INTERRUPT_TABLE[instruction] & 0b100000) != 0)
                                        {
                                            Console.WriteLine(TEMPLATE[5, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[0, step].ToString("X") + Environment.NewLine);
                                        }
                                        else
                                        {
                                            Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                            File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                        }                                        
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                    File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                }

                            }

                            step++;
                        }

                        imode++;
                    }

                    cond++;
                }

                instruction++;
            }
        }
    }
}
