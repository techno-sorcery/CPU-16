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
            // long TEST_TEST       = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;

            long SP_ST      = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0001;
            long PC_ST      = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0010;
            long OP1_ST     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0011;
            long OP2_ST     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0100;
            long IR_ST      = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0101;
            long MDR_ST     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0110;
            long MEM_ST     = 0b00_000_0_00_0_0_0_01_00_0_000_00_0_0000_000_0000_000_0000_0111;
            long REG_ST     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_1000;
            long LMAR_ST    = 0b01_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_1000;
            long MAR_ST     = 0b10_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_1000;

            long F_DOUT     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0001_0000;
            long SP_DOUT    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0010_0000;
            long PC_DOUT    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0011_0000;
            long ALU_RSH    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0101_0000;
            long ALU_SEX    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0110_0000;
            long ALU_SWP    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0111_0000;
            long WRD_DOUT   = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_1000_0000;
            long MDR_DOUT   = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_1001_0000;
            long MEM_DOUT   = 0b00_000_0_00_0_0_0_11_00_0_000_00_0_0000_000_0000_000_1010_0000;
            long REG_DOUT   = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_1011_0000;

            long SP_AOUT    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_001_0000_0000;
            long PC_AOUT    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_010_0000_0000;
            long MAR_AOUT   = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_011_0000_0000;


            long NZ_FST     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0001_000_0000_0000;
            long V_FST      = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0010_000_0000_0000;
            long C_FST      = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0011_000_0000_0000;
            long NZVC_FST   = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0100_000_0000_0000;
            long IRQ_FST    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0101_000_0000_0000;


            long N_COND     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_001_0000_000_0000_0000;
            long Z_COND     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_010_0000_000_0000_0000;
            long V_COND     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_011_0000_000_0000_0000;
            long C_COND     = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_100_0000_000_0000_0000;


            long ALU_ADD    = 0b00_000_0_00_0_0_0_00_00_0_000_10_0_1001_000_0000_000_0100_0000;
            long ALU_ADC    = 0b00_000_0_00_0_0_0_00_00_0_000_01_0_1001_000_0000_000_0100_0000;
            long ALU_SUB    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0110_000_0000_000_0100_0000;
            long ALU_SBB    = 0b00_000_0_00_0_0_0_00_00_0_000_01_0_0110_000_0000_000_0100_0000;
            long ALU_AND    = 0b00_000_0_00_0_0_0_00_00_0_000_00_1_1011_000_0000_000_0100_0000;
            long ALU_OR     = 0b00_000_0_00_0_0_0_00_00_0_000_00_1_1110_000_0000_000_0100_0000;
            long ALU_XOR    = 0b00_000_0_00_0_0_0_00_00_0_000_00_1_0110_000_0000_000_0100_0000;
            long ALU_NOT    = 0b00_000_0_00_0_0_0_00_00_0_000_00_1_0000_000_0000_000_0100_0000;
            long ALU_LSH    = 0b00_000_0_00_0_0_0_00_00_0_000_10_0_1100_000_0000_000_0100_0000;
            long ALU_INC    = 0b00_000_0_00_0_0_0_00_00_0_000_10_0_1111_000_0000_000_0100_0000;
            long ALU_DEC    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0100_0000;


            long SEQ_INC    = 0b00_000_0_00_0_0_0_00_00_0_001_00_0_0000_000_0000_000_0000_0000;
            long SEQ_RS0    = 0b00_000_0_00_0_0_0_00_00_0_010_00_0_0000_000_0000_000_0000_0000;
            long SEQ_RS1    = 0b00_000_0_00_0_0_0_00_00_0_110_00_0_0000_000_0000_000_0000_0000;


            long PC_INC     = 0b00_000_0_00_0_0_0_00_00_1_000_00_0_0000_000_0000_000_0000_0000;

            long SP_INC     = 0b00_000_0_00_0_0_0_00_01_0_000_00_0_0000_000_0000_000_0000_0000;
            long SP_DEC     = 0b00_000_0_00_0_0_0_00_11_0_000_00_0_0000_000_0000_000_0000_0000;

            long COND_NEG   = 0b00_000_0_00_0_0_1_00_00_0_000_00_0_0000_000_0000_000_0000_0000;

            long F_DIN      = 0b00_000_0_00_0_1_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;

            long IRQ_EN     = 0b00_000_0_00_1_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;

            long REG_DIR    = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;
            long REG_SEL2   = 0b00_000_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;

            long TMP_CLR    = 0b00_000_1_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;

            long HLT_ACK    = 0b00_001_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;
            long IRQ_ACK    = 0b00_010_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;
            long RST_ACK    = 0b00_100_0_00_0_0_0_00_00_0_000_00_0_0000_000_0000_000_0000_0000;


            // Write your microcode here
            //  {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

            long[,] TEMPLATE = new long[80, 16] {
                //00c [ctrl]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, IRQ_FST|SP_ST|SEQ_INC, WRD_DOUT|PC_ST|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, RST_ACK|MDR_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 RST
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 HLT
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 CAL
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 RET
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 IRQ

                //01c CLR
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 CLR [reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 CLR $m
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_DOUT|OP2_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|OP1_ST|SEQ_INC, PC_INC|ALU_ADD|MAR_ST|SEQ_INC, MAR_AOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 CLR $m(PC)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_DOUT|MAR_ST|SEQ_INC, MAR_AOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 CLR (reg)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_DOUT|OP2_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP1_ST|SEQ_INC, PC_INC|ALU_ADD|MAR_ST|SEQ_INC, MAR_AOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 CLR $m(reg)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_DOUT|OP1_ST|MAR_ST|SEQ_INC, MAR_AOUT|MEM_ST|SEQ_INC, ALU_INC|REG_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 CLR (reg)+
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_DOUT|OP1_ST|SEQ_INC, ALU_DEC|REG_ST|MAR_ST|SEQ_INC, MAR_AOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 CLR -(reg)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 NOP
                
                //02c JMP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, MDR_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 JMP $m
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_DOUT|OP2_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|OP1_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 JMP $m(PC)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, REG_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 JMP (reg)    
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_DOUT|OP2_ST|SEQ_INC, PC_AOUT|MEM_DOUT|OP1_ST|SEQ_INC, ALU_ADD|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 JMP $m(reg)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, REG_DOUT|OP1_ST|PC_ST|SEQ_INC, ALU_INC|REG_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 JMP (reg)+
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, REG_DOUT|OP1_ST|SEQ_INC, ALU_DEC|REG_ST|SEQ_INC, REG_DOUT|PC_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 JMP -(reg)
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

                //03c JSR
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

                //04c [bra]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

                //05c NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

                //06c NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

                //07c NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP

                //10c MOV [ads],[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|REG_DOUT|MDR_ST|SEQ_INC, MDR_DOUT|REG_SEL2|REG_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV [reg],[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MEM_DOUT|REG_SEL2|REG_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV $m,[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV $m(PC),[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV (reg),[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV $m(reg),[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV (reg)+,[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV -(reg),[reg]
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 MOV #m,[reg]

                //11c MOV [ads],$m
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c0 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c1 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c2 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c3 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c4 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c5 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c6 NOP
                {IRQ_EN|TMP_CLR|PC_AOUT|MEM_DOUT|IR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MDR_ST|SEQ_INC, PC_INC|SEQ_INC, PC_AOUT|MEM_DOUT|MAR_ST|SEQ_INC, PC_INC|MAR_AOUT|MDR_DOUT|MEM_ST|SEQ_RS0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // c7 MOV #m,$m
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
                                File.AppendAllText(PATH, TEMPLATE[8, step].ToString("X") + Environment.NewLine);
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