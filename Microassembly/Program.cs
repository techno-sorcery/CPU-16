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
            // long A_ST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;

            long A_ST       = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00001;
            long B_ST       = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00010;
            long C_ST       = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00011;
            long D_ST       = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00100;
            long SP_ST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00101;
            long PC_ST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00110;
            long IX_ST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00111;
            long IY_ST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01000;
            long IR_ST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01001;
            long REL_ST     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01010;
            long BASE_ST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01011;
            long SUM_ST     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01100;
            long MAR_ST     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01101;
            long MEM_ST     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01110;
            long TMEM_ST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01111;
            long MSK_ST     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10000;
            long MARH_ST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10001;
            long MARL_ST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10010;

            long A_DOUT     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00001_00000;
            long B_DOUT     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00010_00000;
            long C_DOUT     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00011_00000;
            long D_DOUT     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00100_00000;
            long SP_DOUT    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00101_00000;
            long PC_DOUT    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00110_00000;
            long IX_DOUT    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00111_00000;
            long IY_DOUT    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01000_00000;
            long F_DOUT     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01001_00000;
            long SUM_DOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01010_00000;
            long MEM_DOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01011_00000;
            long LSH_DOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01100_00000;
            long RSH_DOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01101_00000;
            long WORD_DOUT  = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01110_00000;
            long BIT_DOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01111_00000;
            long TMEM_DOUT  = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_10000_00000;

            long SP_AOUT    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_001_00000_00000;
            long PC_AOUT    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_010_00000_00000;
            long OFF_AOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_011_00000_00000;
            long MAR_AOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_100_00000_00000;
            long RST_AOUT   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_101_00000_00000;

            long NZ_FST     = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0001_000_00000_00000;
            long V_FST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0010_000_00000_00000;
            long C_FST      = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0011_000_00000_00000;
            long NZVC_FST   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0100_000_00000_00000;
            long IRQ_FST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0101_000_00000_00000;

            long N_COND     = 0b0_000_0_000_0_0_00_0_00_0_0000_001_0000_000_00000_00000;
            long Z_COND     = 0b0_000_0_000_0_0_00_0_00_0_0000_010_0000_000_00000_00000;
            long V_COND     = 0b0_000_0_000_0_0_00_0_00_0_0000_011_0000_000_00000_00000;
            long C_COND     = 0b0_000_0_000_0_0_00_0_00_0_0000_100_0000_000_00000_00000;

            long ALU_ADD    = 0b0_000_0_000_0_0_00_0_10_0_1001_000_0000_000_00000_00000;
            long ALU_ADC    = 0b0_000_0_000_0_0_00_0_01_0_1001_000_0000_000_00000_00000;
            long ALU_SUB    = 0b0_000_0_000_0_0_00_0_00_0_0110_000_0000_000_00000_00000;
            long ALU_SBB    = 0b0_000_0_000_0_0_00_0_01_0_0110_000_0000_000_00000_00000;
            long ALU_AND    = 0b0_000_0_000_0_0_00_0_00_1_1011_000_0000_000_00000_00000;
            long ALU_OR     = 0b0_000_0_000_0_0_00_0_00_1_1110_000_0000_000_00000_00000;
            long ALU_XOR    = 0b0_000_0_000_0_0_00_0_00_1_0110_000_0000_000_00000_00000;
            long ALU_NOTA   = 0b0_000_0_000_0_0_00_0_00_1_0000_000_0000_000_00000_00000;
            long ALU_NOTB   = 0b0_000_0_000_0_0_00_0_00_1_0101_000_0000_000_00000_00000;
            long ALU_LSH    = 0b0_000_0_000_0_0_00_0_10_0_1100_000_0000_000_00000_00000;
            long ALU_INCA   = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long ALU_INCB   = 0b0_000_0_000_0_0_00_0_00_0_1101_000_0000_000_00000_00000;
            long ALU_DECA   = 0b0_000_0_000_0_0_00_0_10_0_1111_000_0000_000_00000_00000;

            long COND_NEG   = 0b0_000_0_000_0_0_00_1_00_0_0000_000_0000_000_00000_00000;

            long SP_INC     = 0b0_000_0_000_0_0_10_0_00_0_0000_000_0000_000_00000_00000;
            long SP_DEC     = 0b0_000_0_000_0_0_11_0_00_0_0000_000_0000_000_00000_00000;

            long PC_INC     = 0b0_000_0_000_0_1_00_0_00_0_0000_000_0000_000_00000_00000;

            long F_DIN      = 0b0_000_0_000_1_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long SEQ_INC    = 0b0_000_0_001_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long SEQ_RS0    = 0b0_000_0_010_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long SEQ_RS1    = 0b0_000_0_110_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long TEMP_CLR   = 0b0_000_1_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long IRQ_EN     = 0b0_001_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long DMA_ACK    = 0b0_010_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;
            long IRQ_ACK    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;


            // Write your microcode here
            //  {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000 TEST

            long[,] TEMPLATE = new long[1024, 16] {
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, WORD_DOUT|F_DIN|NZVC_FST|SEQ_INC, RST_AOUT|MEM_DOUT|PC_ST|SEQ_INC, IRQ_FST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000 RST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, IRQ_FST|PC_INC|SEQ_INC, IRQ_EN, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001 HALT
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, F_DOUT|TMEM_ST|PC_INC|SEQ_INC, SP_AOUT|TMEM_DOUT|MEM_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MARL_ST|SP_INC|SEQ_INC, IRQ_FST|PC_INC|SEQ_INC, PC_DOUT|TMEM_ST|SEQ_INC, SP_AOUT|TMEM_DOUT|MEM_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|PC_ST|SP_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002 CALL $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 040 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 041 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 042 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 043 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 044 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 045 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 046 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 047 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 048 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 049 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 04F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 050 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 051 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 052 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 053 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 054 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 055 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 056 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 057 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 058 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 059 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 05F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 060 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 061 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 062 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 063 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 064 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 065 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 066 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 067 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 068 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 069 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 06F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 070 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 071 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 072 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 073 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 074 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 075 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 076 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 077 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 078 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 079 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 07F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 080 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 081 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 082 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 083 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 084 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 085 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 086 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 087 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 088 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 089 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 08F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 090 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 091 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 092 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 093 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 094 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 095 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 096 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 097 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 098 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 099 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 09F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|A_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C0 LD A, m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C1 LD A, $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|BASE_ST|SEQ_INC, OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C2 LD A, ($m)
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|SEQ_INC, PC_DOUT|BASE_ST|SEQ_INC, OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C3 LD A, $PC+m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|IX_DOUT|BASE_ST|SEQ_INC, OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C4 LD A, $IX+m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0FF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 100 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 101 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 102 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 103 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 104 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 105 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 106 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 107 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 108 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 109 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 110 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 111 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 112 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 113 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 114 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 115 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 116 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 117 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 118 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 119 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 120 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 121 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 122 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 123 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 124 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 125 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 126 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 127 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 128 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 129 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 130 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 131 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 132 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 133 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 134 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 135 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 136 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 137 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 138 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 139 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 140 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 141 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 142 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 143 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 144 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 145 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 146 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 147 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 148 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 149 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 150 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 151 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 152 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 153 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 154 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 155 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 156 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 157 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 158 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 159 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 160 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 161 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 162 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 163 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 164 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 165 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 166 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 167 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 168 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 169 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 170 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 171 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 172 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 173 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 174 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 175 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 176 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 177 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 178 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 179 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 180 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 181 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 182 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 183 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 184 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 185 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 186 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 187 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 188 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 189 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 190 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 191 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 192 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 193 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 194 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 195 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 196 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 197 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 198 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 199 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 19F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1FF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 200 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 201 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 202 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 203 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 204 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 205 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 206 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 207 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 208 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 209 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 210 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 211 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 212 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 213 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 214 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 215 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 216 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 217 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 218 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 219 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 21F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 220 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 221 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 222 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 223 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 224 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 225 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 226 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 227 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 228 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 229 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 22F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 230 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 231 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 232 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 233 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 234 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 235 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 236 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 237 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 238 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 239 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 23F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 240 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 241 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 242 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 243 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 244 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 245 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 246 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 247 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 248 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 249 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 24F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 250 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 251 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 252 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 253 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 254 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 255 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 256 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 257 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 258 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 259 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 25F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 260 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 261 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 262 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 263 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 264 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 265 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 266 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 267 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 268 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 269 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 26F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 270 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 271 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 272 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 273 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 274 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 275 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 276 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 277 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 278 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 279 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 27F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 280 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 281 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 282 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 283 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 284 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 285 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 286 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 287 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 288 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 289 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 28F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 290 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 291 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 292 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 293 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 294 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 295 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 296 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 297 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 298 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 299 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 29F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2FF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 300 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 301 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 302 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 303 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 304 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 305 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 306 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 307 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 308 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 309 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 30F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 310 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 311 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 312 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 313 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 314 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 315 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 316 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 317 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 318 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 319 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 31F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 320 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 321 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 322 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 323 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 324 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 325 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 326 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 327 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 328 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 329 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 32F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 330 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 331 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 332 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 333 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 334 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 335 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 336 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 337 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 338 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 339 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 33F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 340 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 341 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 342 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 343 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 344 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 345 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 346 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 347 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 348 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 349 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 34F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 350 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 351 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 352 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 353 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 354 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 355 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 356 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 357 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 358 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 359 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 35F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 360 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 361 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 362 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 363 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 364 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 365 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 366 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 367 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 368 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 369 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 36F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 370 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 371 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 372 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 373 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 374 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 375 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 376 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 377 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 378 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 379 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 37F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 380 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 381 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 382 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 383 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 384 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 385 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 386 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 387 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 388 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 389 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 38F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 390 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 391 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 392 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 393 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 394 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 395 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 396 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 397 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 398 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 399 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 39F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3FF TEST
             
            };

            // Interrupts

            int IRQ_DMA     = 0b001;
            int IRQ_RST     = 0b011;
            int IRQ_IRQ     = 0b111;

            long[] INTERRUPT_TABLE = new long[1024] {
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ,
                IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ, IRQ_IRQ
            };

            int instruction = 0;

            while (instruction < 1024)
            {
                Console.WriteLine(instruction);
                int imode = 0;
                    
                while (imode < 8)
                {
                        int step = 0;
                    
                        while (step < 16)
                        {
                            if ((imode & INTERRUPT_TABLE[instruction]) != 0)
                            {
                                if ((imode & 0b001) != 0)
                                {

                                    if ((INTERRUPT_TABLE[instruction] & 0b00_0001) != 0)
                                    {
                                        //Console.WriteLine((IRQ_EN | DMA_ACK).ToString("X"));
                                        File.AppendAllText(PATH, (IRQ_EN | DMA_ACK).ToString("X") + Environment.NewLine);
                                    }
                                    else
                                    {
                                       //Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                        File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                    }

                                }
                                else if ((imode & 0b010) != 0)
                                {

                                    if ((INTERRUPT_TABLE[instruction] & 0b00_0010) != 0)
                                    {
                                        //Console.WriteLine(TEMPLATE[0, step].ToString("X"));
                                        File.AppendAllText(PATH, TEMPLATE[0, step].ToString("X") + Environment.NewLine);
                                    }
                                    else
                                    {
                                        //Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                        File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                    }
                                }
                                else if ((imode & 0b100) != 0)
                                {
                                    if ((INTERRUPT_TABLE[instruction] & 0b00_0100) != 0)
                                    {
                                        //Console.WriteLine(TEMPLATE[2, step].ToString("X"));
                                        File.AppendAllText(PATH, TEMPLATE[2, step].ToString("X") + Environment.NewLine);
                                    }
                                    else
                                    {
                                        //Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                        File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                                    }
                                }
                            }
                            else
                            {
                                //Console.WriteLine(TEMPLATE[instruction, step].ToString("X"));
                                File.AppendAllText(PATH, TEMPLATE[instruction, step].ToString("X") + Environment.NewLine);
                            }

                            step++;
                        }

                        imode++;

                }
                instruction++;
            }
        }
    }
}

