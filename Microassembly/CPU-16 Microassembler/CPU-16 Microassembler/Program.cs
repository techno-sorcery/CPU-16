using System;
using System.IO;
using System.Text;

namespace ATLAS_MICRO_ASSEMBLER_8
{
    class Program
    {
        static void Main(string[] args)
        {
            // ATLAS CPU-16 MICRO-ASSEMBLER
            // WRITTEN BY HAYDEN B. - 2021

            // Define microcode file
            string PATH = @"C:\Users\Hayden\Documents\GitHub\CPU-16\Microassembly\MICROCODE.hex";

            File.Delete(PATH);
            File.WriteAllText(PATH, "v2.0 raw" + Environment.NewLine);

            // Define mnemonics
            // long TEST_TEST       = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;

            long SP_ST      = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0001;
            long PC_ST      = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0010;
            long OP1_ST     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0011;
            long OP2_ST     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0100;
            long IR_ST      = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0101;
            long MDR_ST     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0110;
            long MEM_ST     = 0b00_0_000_0_00_0_0_0_01_00_0_000_00_0_0000_000_000_0000_0111;
            long REG_ST     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_1000;
            long MAR_ST     = 0b00_1_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;
            long F_ST       = 0b01_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;
            long STAT_ST    = 0b10_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;            

            long F_DOUT     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0001_0000;
            long SP_DOUT    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0010_0000;
            long PC_DOUT    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0011_0000;
            long SUM_DOUT   = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0100_0000;
            long SWP_DOUT   = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0111_0000;
            long WRD_DOUT   = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_1000_0000;
            long MDR_DOUT   = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_1001_0000;
            long MEM_DOUT   = 0b00_0_000_0_00_0_0_0_11_00_0_000_00_0_0000_000_000_1010_0000;
            long REG_DOUT   = 0b00_0_000_0_01_0_0_0_00_00_0_000_00_0_0000_000_000_1011_0000;
            long VECT_DOUT  = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_1100_0000;

            long SP_AOUT    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_001_0000_0000;
            long PC_AOUT    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_010_0000_0000;
            long MAR_AOUT   = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_011_0000_0000;

            long COND_N     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_001_000_0000_0000;
            long COND_Z     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_010_000_0000_0000;
            long COND_V     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_011_000_0000_0000;
            long COND_C     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_100_000_0000_0000;

            long ALU_ADD    = 0b00_0_000_0_00_0_0_0_00_00_0_000_10_0_1001_000_000_0100_0000;
            long ALU_ADC    = 0b00_0_000_0_00_0_0_0_00_00_0_000_01_0_1001_000_000_0100_0000;
            long ALU_SUB    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0110_000_000_0100_0000;
            long ALU_SBB    = 0b00_0_000_0_00_0_0_0_00_00_0_000_01_0_0110_000_000_0100_0000;
            long ALU_AND    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_1_1011_000_000_0100_0000;
            long ALU_OR     = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_1_1110_000_000_0100_0000;
            long ALU_XOR    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_1_0110_000_000_0100_0000;
            long ALU_NOT    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_1_0000_000_000_0100_0000;
            long ALU_LSH    = 0b00_0_000_0_00_0_0_0_00_00_0_000_10_0_1100_000_000_0100_0000;
            long ALU_RSH    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0101_0000;
            long ALU_INC    = 0b00_0_000_0_00_0_0_0_00_00_0_000_10_0_1111_000_000_0100_0000;
            long ALU_DEC    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0100_0000;
            long ALU_SEX    = 0b00_0_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0110_0000;

            long SEQ_INC    = 0b00_0_000_0_00_0_0_0_00_00_0_001_00_0_0000_000_000_0000_0000;
            long SEQ_RS0    = 0b00_0_000_0_00_0_0_0_00_00_0_010_00_0_0000_000_000_0000_0000;
            long SEQ_RS1    = 0b00_0_000_0_00_0_0_0_00_00_0_110_00_0_0000_000_000_0000_0000;

            long PC_INC     = 0b00_0_000_0_00_0_0_0_00_00_1_000_00_0_0000_000_000_0000_0000;

            long SP_INC     = 0b00_0_000_0_00_0_0_0_00_01_0_000_00_0_0000_000_000_0000_0000;
            long SP_DEC     = 0b00_0_000_0_00_0_0_0_00_11_0_000_00_0_0000_000_000_0000_0000;

            long COND_NEG   = 0b00_0_000_0_00_0_0_1_00_00_0_000_00_0_0000_000_000_0000_0000;

            long F_DIN      = 0b00_0_000_0_00_0_1_0_00_00_0_000_00_0_0000_000_000_0000_0000;

            long IRQ_EN     = 0b00_0_000_0_00_1_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;

            long REG_SEL2   = 0b00_0_000_0_10_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;

            long TMP_CLR    = 0b00_0_000_1_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;

            long HLT_ACK    = 0b00_0_001_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;
            long IRQ_ACK    = 0b00_0_010_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;
            long RST_ACK    = 0b00_0_100_0_00_0_0_0_00_00_0_000_00_0_0000_000_000_0000_0000;

            // Write your microcode here
            //  {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

            long[,] TEMPLATE = new long[128, 16] {
                //000c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, F_ST|STAT_ST|SEQ_INC, WRD_DOUT|MAR_ST|SEQ_INC, RST_ACK|MAR_AOUT|MEM_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //001c [ctrl2]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //002c JMP [ads]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, MDR_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 JMP $m
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //003c JSR [ads]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //004c [bra]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 BIZ $m(PC)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //005c [braq]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //006c NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //007c NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //010c MOV [reg],[ads]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //011c MOV $m,[ads]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MDR_DOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 MOV $m,$m
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //012c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //013c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //014c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //015c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //016c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP

                //017c MOV #m,[ads]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|REG_SEL2|REG_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV #m,[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MDR_DOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 MOV #m,$m
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP
            };

            // Interrupts

            long[] INTERRUPT = new long[16]
            {
                IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, SP_DEC|VECT_DOUT|MAR_ST|SEQ_INC, SP_AOUT|PC_DOUT|MEM_ST|SEQ_INC, SP_DEC|MAR_AOUT|MEM_DOUT|PC_ST|SEQ_INC, F_DOUT|SP_AOUT|MEM_ST|SEQ_INC, STAT_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            long[] INTERRUPT_TABLE = new long[128] {
                1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            };

            int instruction = 0;

            while (instruction < 128)
            {
                Console.WriteLine(instruction);
                int imode = 0;

                while (imode < 4)
                {
                    int step = 0;

                    while (step < 16)
                    {
                        if (imode!= 0)
                        {
                            if (imode == 2 && INTERRUPT_TABLE[instruction] == 1)
                            {
                                File.AppendAllText(PATH, INTERRUPT[step].ToString("X") + Environment.NewLine);
                            }
                            else
                            {
                                File.AppendAllText(PATH, (IRQ_EN | HLT_ACK).ToString("X") + Environment.NewLine);
                            }
                        }
                        else
                        {
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