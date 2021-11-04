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
            // long TEST_TEST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000__00000_00000;

            long A_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00001;
            long B_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00010;
            long C_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00011;
            long D_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00100;
            long E_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00101;
            long X_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00110;
            long Y_ST       =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00111;

            long SP_ST      =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01000;
            long PC_ST      =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01001;
            long OP1_ST     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01010;
            long OP2_ST     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01011;
            long IR_ST      =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01100;
            long LMAR_ST    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01101;
            long MAR_ST     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01110;

            long MDR_ST     =0b0_10_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_01111;

            long MEM_ST     =0b0_10_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_10000;            


            long A_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00001_00000;
            long B_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00010_00000;
            long C_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00011_00000;
            long D_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00100_00000;
            long E_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00101_00000;
            long X_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00110_00000;
            long Y_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00111_00000;

            long F_DOUT     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01000_00000;
            long SP_DOUT    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01001_00000;
            long PC_DOUT    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01010_00000;
            long SUM_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01011_00000;
            long LSH_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01100_00000;
            long RSH_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01101_00000;
            long SEX_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01110_00000;
            
            long MEM_DOUT   =0b0_11_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01111_00000;

            long WRD_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_10000_00000;

            long MDR_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_10001_00000;

            long OP1_DOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_1111_000_0000_000_01011_00000;


            long SP_AOUT    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_001_00000_00000;
            long PC_AOUT    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_010_00000_00000;
            long MAR_AOUT   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_011_00000_00000;


            long NZ_FST     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0001_000_00000_00000;
            long V_FST      =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0010_000_00000_00000;
            long C_FST      =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0011_000_00000_00000;
            long NZVC_FST   =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0100_000_00000_00000;
            long IRQ_FST    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0101_000_00000_00000;


            long N_COND     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_001_0000_000_00000_00000;
            long Z_COND     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_010_0000_000_00000_00000;
            long V_COND     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_011_0000_000_00000_00000;
            long C_COND     =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_100_0000_000_00000_00000;


            long ALU_ADD    =0b0_00_00_000_0_000_0_0_00_0_10_0_1001_000_0000_000_01011_00000;
            long ALU_ADC    =0b0_00_00_000_0_000_0_0_00_0_01_0_1001_000_0000_000_01011_00000;
            long ALU_SUB    =0b0_00_00_000_0_000_0_0_00_0_00_0_0110_000_0000_000_01011_00000;
            long ALU_SBB    =0b0_00_00_000_0_000_0_0_00_0_01_0_0110_000_0000_000_01011_00000;
            long ALU_AND    =0b0_00_00_000_0_000_0_0_00_0_00_1_1011_000_0000_000_01011_00000;
            long ALU_OR     =0b0_00_00_000_0_000_0_0_00_0_00_1_1110_000_0000_000_01011_00000;
            long ALU_XOR    =0b0_00_00_000_0_000_0_0_00_0_00_1_0110_000_0000_000_01011_00000;
            long ALU_NOT    =0b0_00_00_000_0_000_0_0_00_0_00_1_0000_000_0000_000_01011_00000;
            long ALU_LSH    =0b0_00_00_000_0_000_0_0_00_0_10_0_1100_000_0000_000_01011_00000;
            long ALU_INC    =0b0_00_00_000_0_000_0_0_00_0_10_0_1111_000_0000_000_01011_00000;
            long ALU_DEC    =0b0_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_01011_00000;


            long COND_NEG   =0b0_00_00_000_0_000_0_0_00_1_00_0_0000_000_0000_000_00000_00000;

            long SP_INC     =0b0_00_00_000_0_000_0_0_10_0_00_0_0000_000_0000_000_00000_00000;
            long SP_DEC     =0b0_00_00_000_0_000_0_0_11_0_00_0_0000_000_0000_000_00000_00000;

            long PC_INC     =0b0_00_00_000_0_000_0_1_00_0_00_0_0000_000_0000_000_00000_00000;

            long F_DIN      =0b0_00_00_000_0_000_1_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long SEQ_INC    =0b0_00_00_000_0_001_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long SEQ_RS0    =0b0_00_00_000_0_010_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long SEQ_RS1    =0b0_00_00_000_0_110_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long TEMP_CLR   =0b0_00_00_000_1_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long IRQ_EN     =0b0_00_00_001_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long DMA_ACK    =0b0_00_00_010_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long IRQ_ACK    =0b0_00_00_100_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long RST_ACK    =0b1_00_00_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;

            long X_INC      =0b0_00_01_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long X_DEC      =0b0_00_01_000_0_000_0_0_01_0_00_0_0000_000_0000_000_00000_00000;

            long Y_INC      =0b0_00_10_000_0_000_0_0_00_0_00_0_0000_000_0000_000_00000_00000;
            long Y_DEC      =0b0_00_10_000_0_000_0_0_01_0_00_0_0000_000_0000_000_00000_00000;


            // Write your microcode here
            //  {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x0 NOP

            long[,] TEMPLATE = new long[80, 16] {
                //00x CTRL
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, IRQ_FST|SP_ST|SEQ_INC, WRD_DOUT|PC_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, RST_ACK|MDR_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x0 RST
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x1 HLT
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|LMAR_ST|SEQ_INC, PC_INC|SEQ_INC, SP_AOUT|PC_DOUT|MEM_ST|SEQ_INC, SP_INC|MAR_AOUT|MEM_DOUT|PC_ST|SEQ_INC, F_DOUT|SP_AOUT|MEM_ST|SEQ_INC, SP_INC|IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_RS1, 0, 0, 0, 0, 0, 0, 0, 0}, // x2 CAL
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x3 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x4 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x5 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x6 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x7 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x8 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x9 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xA NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xB NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xC NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xD NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xE NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|X_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xF NOP

                //01x JMP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x0 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, MDR_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x1 JMP $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_DOUT|OP1_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x2 JMP $m+PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, A_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x3 JMP $m+A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, B_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x4 JMP $m+B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, C_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x5 JMP $m+C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, D_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x6 JMP $m+D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, E_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x7 JMP $m+E
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, X_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x8 JMP $m+X
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, Y_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x9 JMP $m+Y
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xA NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xB NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xC NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xD NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xE NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, SP_DEC|SEQ_INC, SP_AOUT|MEM_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xF JMP --[$SP]

                //02x JSR
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x0 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x1 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x2 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x3 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x4 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x5 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x6 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x7 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x8 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x9 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xA NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xB NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xC NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xD NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xE NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xF NOP

                //03x BRA
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x0 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x1 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x2 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x3 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x4 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x5 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x6 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x7 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x8 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x9 NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xA NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xB NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xC NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xD NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xE NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xF NOP

                //04x LDA
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|A_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x0 LDA m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x1 LDA $m
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_DOUT|OP1_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, PC_INC|ALU_ADD|MAR_ST|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x2 LDA $m+PC
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, A_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x3 LDA $m+A
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, B_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x4 LDA $m+B
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, C_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|A_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x5 LDA $m+C
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, D_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x6 LDA $m+D
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, E_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x7 LDA $m+E
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, X_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x8 LDA $m+X
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, Y_DOUT|OP1_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP2_ST|SEQ_INC, ALU_ADD|MAR_ST|PC_INC|SEQ_INC, MAR_AOUT|MEM_DOUT|B_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // x9 LDA $m+Y
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xA NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xB NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xC NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|A_DOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xD NOP
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xE LDA [$SP]++
                {IRQ_EN|TEMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // xF LDA --[$SP]             
            };

            // Interrupts

            long[] INTERRUPT_TABLE = new long[80] {
                1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            };

            int instruction = 0;

            while (instruction < 80)
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
                                File.AppendAllText(PATH, TEMPLATE[15, step].ToString("X") + Environment.NewLine);
                            }
                            else
                            {
                                File.AppendAllText(PATH, (IRQ_EN | DMA_ACK).ToString("X") + Environment.NewLine);
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