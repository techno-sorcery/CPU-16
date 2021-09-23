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
            string PATH = @"C:\Users\Hayden\Documents\GitHub\CPU-16\Microassembly\MICROCODE.hex";

            if (!File.Exists(PATH))
            {
                // Create a file to write to.
                File.WriteAllText(PATH, "v2.0 raw" + Environment.NewLine);
            }

            // Define mnemonics
            // long A_ST    = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;

            long A_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00001;
            long B_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00010;
            long C_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00011;
            long D_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00100;
            long SP_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00101;
            long PC_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00110;
            long X_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00111;
            long Y_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01000;
            long IR_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01001;
            long REL_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01010;
            long BASE_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01011;
            long SUM_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01100;
            long MAR_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01101;
            long MEM_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01110;
            long TMEM_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01111;
            long MSK_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10000;
            long MARH_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10001;
            long MARL_ST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10010;

            long A_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00001_00000;
            long B_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00010_00000;
            long C_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00011_00000;
            long D_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00100_00000;
            long SP_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00101_00000;
            long PC_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00110_00000;
            long X_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00111_00000;
            long Y_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01000_00000;
            long F_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01001_00000;
            long SUM_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01010_00000;
            long MEM_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01011_00000;
            long LSH_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01100_00000;
            long RSH_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01101_00000;
            long WORD_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01110_00000;
            long BIT_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01111_00000;
            long TMEM_DOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_10000_00000;

            long SP_AOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_001_00000_00000;
            long PC_AOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_010_00000_00000;
            long OFF_AOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_011_00000_00000;
            long MAR_AOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_100_00000_00000;
            long RST_AOUT = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_101_00000_00000;

            long NZ_FST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0001_000_00000_00000;
            long V_FST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0010_000_00000_00000;
            long C_FST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0011_000_00000_00000;
            long NZVC_FST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0100_000_00000_00000;
            long IRQ_FST = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0101_000_00000_00000;

            long N_COND = 0b0_000_0_000_0_0_00_0_00_0_0000_001_0000_000_00000_00000;
            long Z_COND = 0b0_000_0_000_0_0_00_0_00_0_0000_010_0000_000_00000_00000;
            long V_COND = 0b0_000_0_000_0_0_00_0_00_0_0000_011_0000_000_00000_00000;
            long C_COND = 0b0_000_0_000_0_0_00_0_00_0_0000_100_0000_000_00000_00000;

            long ALU_ADD = 0b0_000_0_000_0_0_00_0_10_0_1001_000_0000_000_00000_00000;
            long ALU_ADC = 0b0_000_0_000_0_0_00_0_01_0_1001_000_0000_000_00000_00000;
            long ALU_SUB = 0b0_000_0_000_0_0_00_0_00_0_0110_000_0000_000_00000_00000;
            long ALU_SBB = 0b0_000_0_000_0_0_00_0_01_0_0110_000_0000_000_00000_00000;
            long ALU_AND = 0b0_000_0_000_0_0_00_0_00_1_1011_000_0000_000_00000_00000;
            long ALU_OR = 0b0_000_0_000_0_0_00_0_00_1_1110_000_0000_000_00000_00000;
            long ALU_XOR = 0b0_000_0_000_0_0_00_0_00_1_0110_000_0000_000_00000_00000;
            long ALU_NOTA = 0b0_000_0_000_0_0_00_0_00_1_0000_000_0000_000_00000_00000;
            long ALU_NOTB = 0b0_000_0_000_0_0_00_0_00_1_0101_000_0000_000_00000_00000;
            long ALU_LSH = 0b0_000_0_000_0_0_00_0_10_0_1100_000_0000_000_00000_00000;
            long ALU_INCA = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long ALU_INCB = 0b0_000_0_000_0_0_00_0_00_0_1101_000_0000_000_00000_00000;
            long ALU_DECA = 0b0_000_0_000_0_0_00_0_10_0_1111_000_0000_000_00000_00000;

            long COND_NEG = 0b0_000_0_000_0_0_00_1_00_0_0000_000_0000_000_00000_00000;

            long SP_INC = 0b0_000_0_000_0_0_10_0_00_0_0000_000_0000_000_00000_00000;
            long SP_DEC = 0b0_000_0_000_0_0_11_0_00_0_0000_000_0000_000_00000_00000;

            long PC_INC = 0b0_000_0_000_0_1_00_0_00_0_0000_000_0000_000_00000_00000;

            long F_DIN = 0b0_000_0_000_1_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long SEQ_INC = 0b0_000_0_001_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long SEQ_RS0 = 0b0_000_0_010_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long SEQ_RS1 = 0b0_000_0_110_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long TEMP_CLR = 0b0_000_1_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long IRQ_EN = 0b0_001_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long DMA_ACK = 0b0_010_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;
            long IRQ_ACK = 0b0_000_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;


            // Write your microcode here
            //  {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000 TEST

            long[,] TEMPLATE = new long[1024, 16] {
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, WORD_DOUT|MAR_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|PC_ST|SEQ_INC, SP_ST|IRQ_FST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0000 RST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0001 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0002 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0003 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0004 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0005 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0006 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0007 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0008 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0009 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 000F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0010 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0011 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0012 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0013 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0014 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0015 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0016 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0017 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0018 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0019 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 001F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0020 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0021 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0022 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0023 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0024 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0025 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0026 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0027 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0028 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0029 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 002F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0030 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0031 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0032 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0033 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0034 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0035 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0036 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0037 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0038 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0039 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 003F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0040 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0041 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0042 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0043 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0044 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0045 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0046 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0047 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0048 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0049 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 004F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|A_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0050 LDA m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST|PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0051 LDA $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0052 LDA $m+PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, A_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0053 LDA $m+A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, B_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0054 LDA $m+B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, C_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0055 LDA $m+C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, D_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0056 LDA $m+D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, X_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0057 LDA $m+X
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, Y_DOUT|BASE_ST|SEQ_INC, PC_AOUT|MEM_DOUT|REL_ST|SEQ_INC, PC_INC|OFF_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0058 LDA $m+Y
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0059 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 005F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0060 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0061 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0062 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0063 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0064 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0065 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0066 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0067 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0068 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0069 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 006F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0070 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0071 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0072 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0073 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0074 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0075 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0076 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0077 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0078 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0079 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 007F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0080 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0081 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0082 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0083 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0084 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0085 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0086 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0087 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0088 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0089 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 008F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0090 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0091 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0092 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0093 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0094 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0095 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0096 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0097 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0098 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0099 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 009F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|B_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E1 TRA B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|C_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E2 TRA C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|D_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E3 TRA D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|X_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E4 TRA X
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|Y_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E5 TRA Y
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|F_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00EA TRA F
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SP_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00EB TRA SP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|PC_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00EC TRA PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|A_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F0 TRB A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 00FF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0100 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0101 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0102 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0103 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0104 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0105 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0106 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0107 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0108 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0109 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 010F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0110 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0111 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0112 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0113 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0114 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0115 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0116 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0117 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0118 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0119 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 011F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0120 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0121 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0122 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0123 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0124 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0125 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0126 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0127 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0128 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0129 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 012F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0130 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0131 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0132 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0133 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0134 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0135 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0136 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0137 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0138 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0139 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 013F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0140 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0141 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0142 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0143 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0144 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0145 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0146 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0147 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0148 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0149 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 014F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0150 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0151 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0152 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0153 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0154 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0155 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0156 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0157 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0158 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0159 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 015F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0160 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0161 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0162 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0163 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0164 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0165 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0166 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0167 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0168 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0169 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 016F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0170 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0171 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0172 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0173 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0174 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0175 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0176 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0177 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0178 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0179 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 017F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0180 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0181 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0182 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0183 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0184 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0185 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0186 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0187 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0188 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0189 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 018F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0190 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0191 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0192 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0193 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0194 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0195 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0196 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0197 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0198 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0199 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 019F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 01FF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0200 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0201 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0202 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0203 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0204 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0205 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0206 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0207 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0208 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0209 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 020F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0210 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0211 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0212 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0213 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0214 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0215 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0216 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0217 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0218 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0219 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 021F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0220 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0221 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0222 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0223 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0224 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0225 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0226 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0227 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0228 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0229 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 022F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0230 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0231 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0232 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0233 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0234 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0235 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0236 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0237 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0238 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0239 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 023F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0240 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0241 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0242 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0243 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0244 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0245 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0246 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0247 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0248 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0249 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 024F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0250 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0251 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0252 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0253 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0254 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0255 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0256 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0257 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0258 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0259 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 025F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0260 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0261 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0262 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0263 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0264 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0265 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0266 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0267 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0268 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0269 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 026F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0270 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0271 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0272 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0273 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0274 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0275 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0276 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0277 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0278 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0279 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 027F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0280 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0281 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0282 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0283 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0284 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0285 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0286 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0287 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0288 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0289 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 028F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0290 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0291 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0292 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0293 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0294 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0295 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0296 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0297 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0298 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0299 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 029F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 02FF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0300 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0301 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0302 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0303 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0304 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0305 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0306 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0307 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0308 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0309 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 030F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0310 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0311 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0312 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0313 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0314 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0315 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0316 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0317 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0318 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0319 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 031F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0320 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0321 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0322 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0323 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0324 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0325 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0326 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0327 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0328 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0329 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 032F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0330 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0331 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0332 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0333 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0334 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0335 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0336 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0337 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0338 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0339 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 033F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0340 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0341 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0342 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0343 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0344 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0345 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0346 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0347 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0348 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0349 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 034F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0350 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0351 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0352 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0353 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0354 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0355 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0356 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0357 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0358 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0359 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 035F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0360 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0361 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0362 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0363 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0364 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0365 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0366 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0367 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0368 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0369 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 036F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0370 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0371 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0372 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0373 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0374 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0375 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0376 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0377 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0378 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0379 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 037F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0380 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0381 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0382 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0383 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0384 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0385 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0386 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0387 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0388 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0389 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 038F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0390 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0391 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0392 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0393 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0394 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0395 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0396 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0397 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0398 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0399 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039A TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039B TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039C TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039D TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039E TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 039F TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03A9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03AA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03AB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03AC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03AD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03AE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03AF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03B9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03BA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03BB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03BC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03BD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03BE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03BF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03C9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03CA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03CB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03CC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03CD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03CE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03CF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03D9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03DA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03DB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03DC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03DD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03DE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03DF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03E9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03EA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03EB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03EC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03ED TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03EE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03EF TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F0 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F1 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F2 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F3 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F4 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F5 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F6 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F7 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F8 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03F9 TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03FA TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03FB TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03FC TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03FD TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03FE TEST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 03FF TEST             
            };

            // Interrupts

            int IRQ_DMA = 0b001;
            int IRQ_RST = 0b011;
            int IRQ_IRQ = 0b111;

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

            while (instruction < 256)
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


