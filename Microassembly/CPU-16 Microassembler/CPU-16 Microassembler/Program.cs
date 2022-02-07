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
            string PATH = @"/Users/haydenbuscher/Documents/GitHub/CPU-16/Microassembly/MICROCODE.hex";

            File.Delete(PATH);
            File.WriteAllText(PATH, "v2.0 raw" + Environment.NewLine);

            // Define mnemonics
            // long TEST_T  = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0000_0000000000;

            long PC_ST      = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0001_0000000000;
            long OP1_ST     = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0010_0000000000;
            long OP2_ST     = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0011_0000000000;
            long IR_ST      = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0100_0000000000;
            long MDR_ST     = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0101_0000000000;
            long MEM_ST     = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0110_0000000000;
            long REG1_ST    = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_0111_0000000000;
            long REG2_ST    = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_1000_0000000000;
            long SP_ST      = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_1001_0000000000;
            long STAT_ST    = 0b0_000_0_00_0_0_00_0_0000_000_00_0000_1010_0000000000;

            long F_DOUT     = 0b0_000_0_00_0_0_00_0_0000_000_00_0001_0000_0000000000;
            long PC_DOUT    = 0b0_000_0_00_0_0_00_0_0000_000_00_0010_0000_0000000000;
            long SUM_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_0011_0000_0000000000;
            long RSH_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_0100_0000_0000000000;
            long SEX_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_0101_0000_0000000000;
            long SWP_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_0110_0000_0000000000;
            long WRD_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_0111_0000_0000000000;
            long MDR_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_1000_0000_0000000000;
            long MEM_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_00_1001_0000_0000000000;
            long VECT_DOUT  = 0b0_000_0_00_0_0_00_0_0000_000_00_1010_0000_0000000000;
            long REG1_DOUT  = 0b0_000_0_00_0_0_00_0_0000_000_00_1011_0000_0000000000;
            long REG2_DOUT  = 0b0_000_0_00_0_0_00_0_0000_000_00_1100_0000_0000000000;
            long SP_DOUT    = 0b0_000_0_00_0_0_00_0_0000_000_00_1101_0000_0000000000;

            long PC_AOUT    = 0b0_000_0_00_0_0_00_0_0000_000_01_0000_0000_0000000000;
            long MAR_DOUT   = 0b0_000_0_00_0_0_00_0_0000_000_10_0000_0000_0000000000;

            long COND_N     = 0b0_000_0_00_0_0_00_0_0000_001_00_0000_0000_0000000000;
            long COND_Z     = 0b0_000_0_00_0_0_00_0_0000_010_00_0000_0000_0000000000;
            long COND_V     = 0b0_000_0_00_0_0_00_0_0000_011_00_0000_0000_0000000000;
            long COND_C     = 0b0_000_0_00_0_0_00_0_0000_100_00_0000_0000_0000000000;

            long ALU_ADD    = 0b0_000_0_00_0_0_10_0_1001_000_00_0011_0000_0000000000;
            long ALU_ADC    = 0b0_000_0_00_0_0_01_0_1001_000_00_0011_0000_0000000000;
            long ALU_SUB    = 0b0_000_0_00_0_0_00_0_0110_000_00_0011_0000_0000000000;
            long ALU_SBB    = 0b0_000_0_00_0_0_01_0_0110_000_00_0011_0000_0000000000;
            long ALU_AND    = 0b0_000_0_00_0_0_00_1_1011_000_00_0011_0000_0000000000;
            long ALU_OR     = 0b0_000_0_00_0_0_00_1_1110_000_00_0011_0000_0000000000;
            long ALU_XOR    = 0b0_000_0_00_0_0_00_1_0110_000_00_0011_0000_0000000000;
            long ALU_NOT    = 0b0_000_0_00_0_0_00_1_0000_000_00_0011_0000_0000000000;
            long ALU_LSH    = 0b0_000_0_00_0_0_10_0_1100_000_00_0011_0000_0000000000;
            long ALU_RSH    = 0b0_000_0_00_0_0_00_0_0000_000_00_0011_0000_0000000000;
            long ALU_INC    = 0b0_000_0_00_0_0_00_0_0000_000_00_0011_0000_0000000000;
            long ALU_DEC    = 0b0_000_0_00_0_0_10_0_1111_000_00_0011_0000_0000000000;
            long ALU_SEX    = 0b0_000_0_00_0_0_00_0_0000_000_00_0011_0000_0000000000;

            long PC_INC     = 0b0_000_0_00_0_1_00_0_0000_000_00_0000_0000_0000000000;
            long COND_NEG   = 0b0_000_0_00_1_0_00_0_0000_000_00_0000_0000_0000000000;

            long F_ALUIN    = 0b0_000_0_01_0_0_00_0_0000_000_00_0000_0000_0000000000;
            long F_ST       = 0b0_000_0_10_0_0_00_0_0000_000_00_0000_0000_0000000000;

            long MAR_ST     = 0b0_000_1_00_0_0_00_0_0000_000_00_0000_0000_0000000000;

            long MODE_RST   = 0b0_001_0_00_0_0_00_0_0000_000_00_0000_0000_0000000000;
            long MODE_DMA   = 0b0_010_0_00_0_0_00_0_0000_000_00_0000_0000_0000000000;
            long MODE_FLT   = 0b0_011_0_00_0_0_00_0_0000_000_00_0000_0000_0000000000;

            long IRQ_EN     = 0b1_000_0_00_0_0_00_0_0000_000_00_0000_0000_0000000000;

            // Write your microcode here

            long[] MCODE1 = new long[752] {
                0,  //0000 - RST
                0,  //0001 - HLT
                0,  //0002 - CAL q$m
                0,  //0003 - CALV
                0,  //0004 - ILLEGAL
                0,  //0005 - ILLEGAL
                0,  //0006 - ILLEGAL
                0,  //0007 - RST

                0,  //0010 - STC [reg]
                0,  //0011 - ILLEGAL
                0,  //0012 - ILLEGAL
                0,  //0013 - ILLEGAL
                0,  //0014 - SWP [reg]
                0,  //0015 - EXG [reg]
                0,  //0016 - LNK [reg],#m
                0,  //0017 - ULNK [reg]

                0,  //0020 - ANF $m
                0,  //0021 - ORF $m
                0,  //0022 - XOF $m
                0,  //0023 - LDF [reg]
                0,  //0024 - ANT $m
                0,  //0025 - ORT $m
                0,  //0026 - XOT $m
                0,  //0027 - LDT [reg]

                0,  //0030 - ILLEGAL
                0,  //0031 - JMP $m
                0,  //0032 - JMP $m(PC)
                0,  //0033 - JMP (reg)
                0,  //0034 - JMP $m(reg)
                0,  //0035 - JMP (reg)+
                0,  //0036 - JMP (reg)-
                0,  //0037 - ILLEGAL

                0,  //0040 - ILLEGAL
                0,  //0041 - JSR $m
                0,  //0042 - JSR $m(PC)
                0,  //0043 - JSR (reg)
                0,  //0044 - JSR $m(reg)
                0,  //0045 - JSR (reg)+
                0,  //0046 - JSR (reg)-
                0,  //0047 - ILLEGAL

                0,  //0050 - BIN $m(PC) 
                0,  //0051 - BIZ $m(PC)
                0,  //0052 - BIV $m(PC)
                0,  //0053 - BIC $m(PC)
                0,  //0054 - BNN $m(PC)
                0,  //0055 - BNZ $m(PC)
                0,  //0056 - BNV $m(PC)
                0,  //0057 - BNC $m(PC)

                0,  //0060 - ILLEGAL
                0,  //0061 - ILLEGAL
                0,  //0062 - ILLEGAL
                0,  //0063 - ILLEGAL
                0,  //0064 - ILLEGAL
                0,  //0065 - ILLEGAL
                0,  //0066 - ILLEGAL
                0,  //0067 - ILLEGAL

                0,  //0070 - MOVQ q#m,[reg]
                0,  //0071 - MOVQ q#m,$m
                0,  //0072 - MOVQ q#m,$m(PC)
                0,  //0073 - MOVQ q#m,(reg)
                0,  //0074 - MOVQ q#m,$m(reg)
                0,  //0075 - MOVQ q#m,(reg)+
                0,  //0076 - MOVQ q#m,-(reg)
                0,  //0077 - ILLEGAL

                0,  //0100 - MOV [reg],[reg]
                0,  //0101 - MOV [reg],$m
                0,  //0102 - MOV [reg],$m(PC)
                0,  //0103 - MOV [reg],(reg)
                0,  //0104 - MOV [reg],$m(reg)
                0,  //0105 - MOV [reg],(reg)+
                0,  //0106 - MOV [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - MOV $m,[reg]
                0,  //0111 - MOV $m,$m
                0,  //0112 - MOV $m,$m(PC)
                0,  //0113 - MOV $m,(reg)
                0,  //0114 - MOV $m,$m(reg)
                0,  //0115 - MOV $m,(reg)+
                0,  //0116 - MOV $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - MOV $m(PC),[reg]
                0,  //0121 - MOV $m(PC),$m
                0,  //0122 - MOV $m(PC),$m(PC)
                0,  //0123 - MOV $m(PC),(reg)
                0,  //0124 - MOV $m(PC),$m(reg)
                0,  //0125 - MOV $m(PC),(reg)+
                0,  //0126 - MOV $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - MOV (reg),[reg]
                0,  //0131 - MOV (reg),$m
                0,  //0132 - MOV (reg),$m(PC)
                0,  //0133 - MOV (reg),(reg)
                0,  //0134 - MOV (reg),$m(reg)
                0,  //0135 - MOV (reg),(reg)+
                0,  //0136 - MOV (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - MOV $m(reg),[reg]
                0,  //0141 - MOV $m(reg),$m
                0,  //0142 - MOV $m(reg),$m(PC)
                0,  //0143 - MOV $m(reg),(reg)
                0,  //0144 - MOV $m(reg),$m(reg)
                0,  //0145 - MOV $m(reg),(reg)+
                0,  //0146 - MOV $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - MOV (reg)+,[reg]
                0,  //0151 - MOV (reg)+,$m
                0,  //0152 - MOV (reg)+,$m(PC)
                0,  //0153 - MOV (reg)+,(reg)
                0,  //0154 - MOV (reg)+,$m(reg)
                0,  //0155 - MOV (reg)+,(reg)+
                0,  //0156 - MOV (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - MOV -(reg),[reg]
                0,  //0161 - MOV -(reg),$m
                0,  //0162 - MOV -(reg),$m(PC)
                0,  //0163 - MOV -(reg),(reg)
                0,  //0164 - MOV -(reg),$m(reg)
                0,  //0165 - MOV -(reg),(reg)+
                0,  //0166 - MOV -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - MOV #m,[reg]
                0,  //0171 - MOV #m,$m
                0,  //0172 - MOV #m,$m(PC)
                0,  //0173 - MOV #m,(reg)
                0,  //0174 - MOV #m,$m(reg)
                0,  //0175 - MOV #m,(reg)+
                0,  //0176 - MOV #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - ADD [reg],[reg]
                0,  //0101 - ADD [reg],$m
                0,  //0102 - ADD [reg],$m(PC)
                0,  //0103 - ADD [reg],(reg)
                0,  //0104 - ADD [reg],$m(reg)
                0,  //0105 - ADD [reg],(reg)+
                0,  //0106 - ADD [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - ADD $m,[reg]
                0,  //0111 - ADD $m,$m
                0,  //0112 - ADD $m,$m(PC)
                0,  //0113 - ADD $m,(reg)
                0,  //0114 - ADD $m,$m(reg)
                0,  //0115 - ADD $m,(reg)+
                0,  //0116 - ADD $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - ADD $m(PC),[reg]
                0,  //0121 - ADD $m(PC),$m
                0,  //0122 - ADD $m(PC),$m(PC)
                0,  //0123 - ADD $m(PC),(reg)
                0,  //0124 - ADD $m(PC),$m(reg)
                0,  //0125 - ADD $m(PC),(reg)+
                0,  //0126 - ADD $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - ADD (reg),[reg]
                0,  //0131 - ADD (reg),$m
                0,  //0132 - ADD (reg),$m(PC)
                0,  //0133 - ADD (reg),(reg)
                0,  //0134 - ADD (reg),$m(reg)
                0,  //0135 - ADD (reg),(reg)+
                0,  //0136 - ADD (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - ADD $m(reg),[reg]
                0,  //0141 - ADD $m(reg),$m
                0,  //0142 - ADD $m(reg),$m(PC)
                0,  //0143 - ADD $m(reg),(reg)
                0,  //0144 - ADD $m(reg),$m(reg)
                0,  //0145 - ADD $m(reg),(reg)+
                0,  //0146 - ADD $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - ADD (reg)+,[reg]
                0,  //0151 - ADD (reg)+,$m
                0,  //0152 - ADD (reg)+,$m(PC)
                0,  //0153 - ADD (reg)+,(reg)
                0,  //0154 - ADD (reg)+,$m(reg)
                0,  //0155 - ADD (reg)+,(reg)+
                0,  //0156 - ADD (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - ADD -(reg),[reg]
                0,  //0161 - ADD -(reg),$m
                0,  //0162 - ADD -(reg),$m(PC)
                0,  //0163 - ADD -(reg),(reg)
                0,  //0164 - ADD -(reg),$m(reg)
                0,  //0165 - ADD -(reg),(reg)+
                0,  //0166 - ADD -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - ADD #m,[reg]
                0,  //0171 - ADD #m,$m
                0,  //0172 - ADD #m,$m(PC)
                0,  //0173 - ADD #m,(reg)
                0,  //0174 - ADD #m,$m(reg)
                0,  //0175 - ADD #m,(reg)+
                0,  //0176 - ADD #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - ADC [reg],[reg]
                0,  //0101 - ADC [reg],$m
                0,  //0102 - ADC [reg],$m(PC)
                0,  //0103 - ADC [reg],(reg)
                0,  //0104 - ADC [reg],$m(reg)
                0,  //0105 - ADC [reg],(reg)+
                0,  //0106 - ADC [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - ADC $m,[reg]
                0,  //0111 - ADC $m,$m
                0,  //0112 - ADC $m,$m(PC)
                0,  //0113 - ADC $m,(reg)
                0,  //0114 - ADC $m,$m(reg)
                0,  //0115 - ADC $m,(reg)+
                0,  //0116 - ADC $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - ADC $m(PC),[reg]
                0,  //0121 - ADC $m(PC),$m
                0,  //0122 - ADC $m(PC),$m(PC)
                0,  //0123 - ADC $m(PC),(reg)
                0,  //0124 - ADC $m(PC),$m(reg)
                0,  //0125 - ADC $m(PC),(reg)+
                0,  //0126 - ADC $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - ADC (reg),[reg]
                0,  //0131 - ADC (reg),$m
                0,  //0132 - ADC (reg),$m(PC)
                0,  //0133 - ADC (reg),(reg)
                0,  //0134 - ADC (reg),$m(reg)
                0,  //0135 - ADC (reg),(reg)+
                0,  //0136 - ADC (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - ADC $m(reg),[reg]
                0,  //0141 - ADC $m(reg),$m
                0,  //0142 - ADC $m(reg),$m(PC)
                0,  //0143 - ADC $m(reg),(reg)
                0,  //0144 - ADC $m(reg),$m(reg)
                0,  //0145 - ADC $m(reg),(reg)+
                0,  //0146 - ADC $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - ADC (reg)+,[reg]
                0,  //0151 - ADC (reg)+,$m
                0,  //0152 - ADC (reg)+,$m(PC)
                0,  //0153 - ADC (reg)+,(reg)
                0,  //0154 - ADC (reg)+,$m(reg)
                0,  //0155 - ADC (reg)+,(reg)+
                0,  //0156 - ADC (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - ADC -(reg),[reg]
                0,  //0161 - ADC -(reg),$m
                0,  //0162 - ADC -(reg),$m(PC)
                0,  //0163 - ADC -(reg),(reg)
                0,  //0164 - ADC -(reg),$m(reg)
                0,  //0165 - ADC -(reg),(reg)+
                0,  //0166 - ADC -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - ADC #m,[reg]
                0,  //0171 - ADC #m,$m
                0,  //0172 - ADC #m,$m(PC)
                0,  //0173 - ADC #m,(reg)
                0,  //0174 - ADC #m,$m(reg)
                0,  //0175 - ADC #m,(reg)+
                0,  //0176 - ADC #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - SUB [reg],[reg]
                0,  //0101 - SUB [reg],$m
                0,  //0102 - SUB [reg],$m(PC)
                0,  //0103 - SUB [reg],(reg)
                0,  //0104 - SUB [reg],$m(reg)
                0,  //0105 - SUB [reg],(reg)+
                0,  //0106 - SUB [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - SUB $m,[reg]
                0,  //0111 - SUB $m,$m
                0,  //0112 - SUB $m,$m(PC)
                0,  //0113 - SUB $m,(reg)
                0,  //0114 - SUB $m,$m(reg)
                0,  //0115 - SUB $m,(reg)+
                0,  //0116 - SUB $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - SUB $m(PC),[reg]
                0,  //0121 - SUB $m(PC),$m
                0,  //0122 - SUB $m(PC),$m(PC)
                0,  //0123 - SUB $m(PC),(reg)
                0,  //0124 - SUB $m(PC),$m(reg)
                0,  //0125 - SUB $m(PC),(reg)+
                0,  //0126 - SUB $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - SUB (reg),[reg]
                0,  //0131 - SUB (reg),$m
                0,  //0132 - SUB (reg),$m(PC)
                0,  //0133 - SUB (reg),(reg)
                0,  //0134 - SUB (reg),$m(reg)
                0,  //0135 - SUB (reg),(reg)+
                0,  //0136 - SUB (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - SUB $m(reg),[reg]
                0,  //0141 - SUB $m(reg),$m
                0,  //0142 - SUB $m(reg),$m(PC)
                0,  //0143 - SUB $m(reg),(reg)
                0,  //0144 - SUB $m(reg),$m(reg)
                0,  //0145 - SUB $m(reg),(reg)+
                0,  //0146 - SUB $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - SUB (reg)+,[reg]
                0,  //0151 - SUB (reg)+,$m
                0,  //0152 - SUB (reg)+,$m(PC)
                0,  //0153 - SUB (reg)+,(reg)
                0,  //0154 - SUB (reg)+,$m(reg)
                0,  //0155 - SUB (reg)+,(reg)+
                0,  //0156 - SUB (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - SUB -(reg),[reg]
                0,  //0161 - SUB -(reg),$m
                0,  //0162 - SUB -(reg),$m(PC)
                0,  //0163 - SUB -(reg),(reg)
                0,  //0164 - SUB -(reg),$m(reg)
                0,  //0165 - SUB -(reg),(reg)+
                0,  //0166 - SUB -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - SUB #m,[reg]
                0,  //0171 - SUB #m,$m
                0,  //0172 - SUB #m,$m(PC)
                0,  //0173 - SUB #m,(reg)
                0,  //0174 - SUB #m,$m(reg)
                0,  //0175 - SUB #m,(reg)+
                0,  //0176 - SUB #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - SBB [reg],[reg]
                0,  //0101 - SBB [reg],$m
                0,  //0102 - SBB [reg],$m(PC)
                0,  //0103 - SBB [reg],(reg)
                0,  //0104 - SBB [reg],$m(reg)
                0,  //0105 - SBB [reg],(reg)+
                0,  //0106 - SBB [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - SBB $m,[reg]
                0,  //0111 - SBB $m,$m
                0,  //0112 - SBB $m,$m(PC)
                0,  //0113 - SBB $m,(reg)
                0,  //0114 - SBB $m,$m(reg)
                0,  //0115 - SBB $m,(reg)+
                0,  //0116 - SBB $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - SBB $m(PC),[reg]
                0,  //0121 - SBB $m(PC),$m
                0,  //0122 - SBB $m(PC),$m(PC)
                0,  //0123 - SBB $m(PC),(reg)
                0,  //0124 - SBB $m(PC),$m(reg)
                0,  //0125 - SBB $m(PC),(reg)+
                0,  //0126 - SBB $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - SBB (reg),[reg]
                0,  //0131 - SBB (reg),$m
                0,  //0132 - SBB (reg),$m(PC)
                0,  //0133 - SBB (reg),(reg)
                0,  //0134 - SBB (reg),$m(reg)
                0,  //0135 - SBB (reg),(reg)+
                0,  //0136 - SBB (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - SBB $m(reg),[reg]
                0,  //0141 - SBB $m(reg),$m
                0,  //0142 - SBB $m(reg),$m(PC)
                0,  //0143 - SBB $m(reg),(reg)
                0,  //0144 - SBB $m(reg),$m(reg)
                0,  //0145 - SBB $m(reg),(reg)+
                0,  //0146 - SBB $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - SBB (reg)+,[reg]
                0,  //0151 - SBB (reg)+,$m
                0,  //0152 - SBB (reg)+,$m(PC)
                0,  //0153 - SBB (reg)+,(reg)
                0,  //0154 - SBB (reg)+,$m(reg)
                0,  //0155 - SBB (reg)+,(reg)+
                0,  //0156 - SBB (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - SBB -(reg),[reg]
                0,  //0161 - SBB -(reg),$m
                0,  //0162 - SBB -(reg),$m(PC)
                0,  //0163 - SBB -(reg),(reg)
                0,  //0164 - SBB -(reg),$m(reg)
                0,  //0165 - SBB -(reg),(reg)+
                0,  //0166 - SBB -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - SBB #m,[reg]
                0,  //0171 - SBB #m,$m
                0,  //0172 - SBB #m,$m(PC)
                0,  //0173 - SBB #m,(reg)
                0,  //0174 - SBB #m,$m(reg)
                0,  //0175 - SBB #m,(reg)+
                0,  //0176 - SBB #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - AND [reg],[reg]
                0,  //0101 - AND [reg],$m
                0,  //0102 - AND [reg],$m(PC)
                0,  //0103 - AND [reg],(reg)
                0,  //0104 - AND [reg],$m(reg)
                0,  //0105 - AND [reg],(reg)+
                0,  //0106 - AND [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - AND $m,[reg]
                0,  //0111 - AND $m,$m
                0,  //0112 - AND $m,$m(PC)
                0,  //0113 - AND $m,(reg)
                0,  //0114 - AND $m,$m(reg)
                0,  //0115 - AND $m,(reg)+
                0,  //0116 - AND $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - AND $m(PC),[reg]
                0,  //0121 - AND $m(PC),$m
                0,  //0122 - AND $m(PC),$m(PC)
                0,  //0123 - AND $m(PC),(reg)
                0,  //0124 - AND $m(PC),$m(reg)
                0,  //0125 - AND $m(PC),(reg)+
                0,  //0126 - AND $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - AND (reg),[reg]
                0,  //0131 - AND (reg),$m
                0,  //0132 - AND (reg),$m(PC)
                0,  //0133 - AND (reg),(reg)
                0,  //0134 - AND (reg),$m(reg)
                0,  //0135 - AND (reg),(reg)+
                0,  //0136 - AND (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - AND $m(reg),[reg]
                0,  //0141 - AND $m(reg),$m
                0,  //0142 - AND $m(reg),$m(PC)
                0,  //0143 - AND $m(reg),(reg)
                0,  //0144 - AND $m(reg),$m(reg)
                0,  //0145 - AND $m(reg),(reg)+
                0,  //0146 - AND $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - AND (reg)+,[reg]
                0,  //0151 - AND (reg)+,$m
                0,  //0152 - AND (reg)+,$m(PC)
                0,  //0153 - AND (reg)+,(reg)
                0,  //0154 - AND (reg)+,$m(reg)
                0,  //0155 - AND (reg)+,(reg)+
                0,  //0156 - AND (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - AND -(reg),[reg]
                0,  //0161 - AND -(reg),$m
                0,  //0162 - AND -(reg),$m(PC)
                0,  //0163 - AND -(reg),(reg)
                0,  //0164 - AND -(reg),$m(reg)
                0,  //0165 - AND -(reg),(reg)+
                0,  //0166 - AND -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - AND #m,[reg]
                0,  //0171 - AND #m,$m
                0,  //0172 - AND #m,$m(PC)
                0,  //0173 - AND #m,(reg)
                0,  //0174 - AND #m,$m(reg)
                0,  //0175 - AND #m,(reg)+
                0,  //0176 - AND #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - OR [reg],[reg]
                0,  //0101 - OR [reg],$m
                0,  //0102 - OR [reg],$m(PC)
                0,  //0103 - OR [reg],(reg)
                0,  //0104 - OR [reg],$m(reg)
                0,  //0105 - OR [reg],(reg)+
                0,  //0106 - OR [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - OR $m,[reg]
                0,  //0111 - OR $m,$m
                0,  //0112 - OR $m,$m(PC)
                0,  //0113 - OR $m,(reg)
                0,  //0114 - OR $m,$m(reg)
                0,  //0115 - OR $m,(reg)+
                0,  //0116 - OR $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - OR $m(PC),[reg]
                0,  //0121 - OR $m(PC),$m
                0,  //0122 - OR $m(PC),$m(PC)
                0,  //0123 - OR $m(PC),(reg)
                0,  //0124 - OR $m(PC),$m(reg)
                0,  //0125 - OR $m(PC),(reg)+
                0,  //0126 - OR $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - OR (reg),[reg]
                0,  //0131 - OR (reg),$m
                0,  //0132 - OR (reg),$m(PC)
                0,  //0133 - OR (reg),(reg)
                0,  //0134 - OR (reg),$m(reg)
                0,  //0135 - OR (reg),(reg)+
                0,  //0136 - OR (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - OR $m(reg),[reg]
                0,  //0141 - OR $m(reg),$m
                0,  //0142 - OR $m(reg),$m(PC)
                0,  //0143 - OR $m(reg),(reg)
                0,  //0144 - OR $m(reg),$m(reg)
                0,  //0145 - OR $m(reg),(reg)+
                0,  //0146 - OR $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - OR (reg)+,[reg]
                0,  //0151 - OR (reg)+,$m
                0,  //0152 - OR (reg)+,$m(PC)
                0,  //0153 - OR (reg)+,(reg)
                0,  //0154 - OR (reg)+,$m(reg)
                0,  //0155 - OR (reg)+,(reg)+
                0,  //0156 - OR (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - OR -(reg),[reg]
                0,  //0161 - OR -(reg),$m
                0,  //0162 - OR -(reg),$m(PC)
                0,  //0163 - OR -(reg),(reg)
                0,  //0164 - OR -(reg),$m(reg)
                0,  //0165 - OR -(reg),(reg)+
                0,  //0166 - OR -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - OR #m,[reg]
                0,  //0171 - OR #m,$m
                0,  //0172 - OR #m,$m(PC)
                0,  //0173 - OR #m,(reg)
                0,  //0174 - OR #m,$m(reg)
                0,  //0175 - OR #m,(reg)+
                0,  //0176 - OR #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - XOR [reg],[reg]
                0,  //0101 - XOR [reg],$m
                0,  //0102 - XOR [reg],$m(PC)
                0,  //0103 - XOR [reg],(reg)
                0,  //0104 - XOR [reg],$m(reg)
                0,  //0105 - XOR [reg],(reg)+
                0,  //0106 - XOR [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - XOR $m,[reg]
                0,  //0111 - XOR $m,$m
                0,  //0112 - XOR $m,$m(PC)
                0,  //0113 - XOR $m,(reg)
                0,  //0114 - XOR $m,$m(reg)
                0,  //0115 - XOR $m,(reg)+
                0,  //0116 - XOR $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - XOR $m(PC),[reg]
                0,  //0121 - XOR $m(PC),$m
                0,  //0122 - XOR $m(PC),$m(PC)
                0,  //0123 - XOR $m(PC),(reg)
                0,  //0124 - XOR $m(PC),$m(reg)
                0,  //0125 - XOR $m(PC),(reg)+
                0,  //0126 - XOR $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - XOR (reg),[reg]
                0,  //0131 - XOR (reg),$m
                0,  //0132 - XOR (reg),$m(PC)
                0,  //0133 - XOR (reg),(reg)
                0,  //0134 - XOR (reg),$m(reg)
                0,  //0135 - XOR (reg),(reg)+
                0,  //0136 - XOR (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - XOR $m(reg),[reg]
                0,  //0141 - XOR $m(reg),$m
                0,  //0142 - XOR $m(reg),$m(PC)
                0,  //0143 - XOR $m(reg),(reg)
                0,  //0144 - XOR $m(reg),$m(reg)
                0,  //0145 - XOR $m(reg),(reg)+
                0,  //0146 - XOR $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - XOR (reg)+,[reg]
                0,  //0151 - XOR (reg)+,$m
                0,  //0152 - XOR (reg)+,$m(PC)
                0,  //0153 - XOR (reg)+,(reg)
                0,  //0154 - XOR (reg)+,$m(reg)
                0,  //0155 - XOR (reg)+,(reg)+
                0,  //0156 - XOR (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - XOR -(reg),[reg]
                0,  //0161 - XOR -(reg),$m
                0,  //0162 - XOR -(reg),$m(PC)
                0,  //0163 - XOR -(reg),(reg)
                0,  //0164 - XOR -(reg),$m(reg)
                0,  //0165 - XOR -(reg),(reg)+
                0,  //0166 - XOR -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - XOR #m,[reg]
                0,  //0171 - XOR #m,$m
                0,  //0172 - XOR #m,$m(PC)
                0,  //0173 - XOR #m,(reg)
                0,  //0174 - XOR #m,$m(reg)
                0,  //0175 - XOR #m,(reg)+
                0,  //0176 - XOR #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - CMP [reg],[reg]
                0,  //0101 - CMP [reg],$m
                0,  //0102 - CMP [reg],$m(PC)
                0,  //0103 - CMP [reg],(reg)
                0,  //0104 - CMP [reg],$m(reg)
                0,  //0105 - CMP [reg],(reg)+
                0,  //0106 - CMP [reg],-(reg)
                0,  //0107 - ILLEGAL

                0,  //0110 - CMP $m,[reg]
                0,  //0111 - CMP $m,$m
                0,  //0112 - CMP $m,$m(PC)
                0,  //0113 - CMP $m,(reg)
                0,  //0114 - CMP $m,$m(reg)
                0,  //0115 - CMP $m,(reg)+
                0,  //0116 - CMP $m,-(reg)
                0,  //0117 - ILLEGAL

                0,  //0120 - CMP $m(PC),[reg]
                0,  //0121 - CMP $m(PC),$m
                0,  //0122 - CMP $m(PC),$m(PC)
                0,  //0123 - CMP $m(PC),(reg)
                0,  //0124 - CMP $m(PC),$m(reg)
                0,  //0125 - CMP $m(PC),(reg)+
                0,  //0126 - CMP $m(PC),-(reg)
                0,  //0127 - ILLEGAL

                0,  //0130 - CMP (reg),[reg]
                0,  //0131 - CMP (reg),$m
                0,  //0132 - CMP (reg),$m(PC)
                0,  //0133 - CMP (reg),(reg)
                0,  //0134 - CMP (reg),$m(reg)
                0,  //0135 - CMP (reg),(reg)+
                0,  //0136 - CMP (reg),-(reg)
                0,  //0137 - ILLEGAL

                0,  //0140 - CMP $m(reg),[reg]
                0,  //0141 - CMP $m(reg),$m
                0,  //0142 - CMP $m(reg),$m(PC)
                0,  //0143 - CMP $m(reg),(reg)
                0,  //0144 - CMP $m(reg),$m(reg)
                0,  //0145 - CMP $m(reg),(reg)+
                0,  //0146 - CMP $m(reg),-(reg)
                0,  //0147 - ILLEGAL 

                0,  //0150 - CMP (reg)+,[reg]
                0,  //0151 - CMP (reg)+,$m
                0,  //0152 - CMP (reg)+,$m(PC)
                0,  //0153 - CMP (reg)+,(reg)
                0,  //0154 - CMP (reg)+,$m(reg)
                0,  //0155 - CMP (reg)+,(reg)+
                0,  //0156 - CMP (reg)+,-(reg)
                0,  //0157 - ILLEGAL

                0,  //0160 - CMP -(reg),[reg]
                0,  //0161 - CMP -(reg),$m
                0,  //0162 - CMP -(reg),$m(PC)
                0,  //0163 - CMP -(reg),(reg)
                0,  //0164 - CMP -(reg),$m(reg)
                0,  //0165 - CMP -(reg),(reg)+
                0,  //0166 - CMP -(reg),-(reg)
                0,  //0167 - ILLEGAL

                0,  //0170 - CMP #m,[reg]
                0,  //0171 - CMP #m,$m
                0,  //0172 - CMP #m,$m(PC)
                0,  //0173 - CMP #m,(reg)
                0,  //0174 - CMP #m,$m(reg)
                0,  //0175 - CMP #m,(reg)+
                0,  //0176 - CMP #m,-(reg)
                0,  //0177 - ILLEGAL

                0,  //0100 - ADDQ q#m,[reg]
                0,  //0101 - ADDQ q#m,$m
                0,  //0102 - ADDQ q#m,$m(PC)
                0,  //0103 - ADDQ q#m,(reg)
                0,  //0104 - ADDQ q#m,$m(reg)
                0,  //0105 - ADDQ q#m,(reg)+
                0,  //0106 - ADDQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - ADCQ q#m,[reg]
                0,  //0101 - ADCQ q#m,$m
                0,  //0102 - ADCQ q#m,$m(PC)
                0,  //0103 - ADCQ q#m,(reg)
                0,  //0104 - ADCQ q#m,$m(reg)
                0,  //0105 - ADCQ q#m,(reg)+
                0,  //0106 - ADCQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - SUBQ q#m,[reg]
                0,  //0101 - SUBQ q#m,$m
                0,  //0102 - SUBQ q#m,$m(PC)
                0,  //0103 - SUBQ q#m,(reg)
                0,  //0104 - SUBQ q#m,$m(reg)
                0,  //0105 - SUBQ q#m,(reg)+
                0,  //0106 - SUBQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - SBBQ q#m,[reg]
                0,  //0101 - SBBQ q#m,$m
                0,  //0102 - SBBQ q#m,$m(PC)
                0,  //0103 - SBBQ q#m,(reg)
                0,  //0104 - SBBQ q#m,$m(reg)
                0,  //0105 - SBBQ q#m,(reg)+
                0,  //0106 - SBBQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - ANDQ q#m,[reg]
                0,  //0101 - ANDQ q#m,$m
                0,  //0102 - ANDQ q#m,$m(PC)
                0,  //0103 - ANDQ q#m,(reg)
                0,  //0104 - ANDQ q#m,$m(reg)
                0,  //0105 - ANDQ q#m,(reg)+
                0,  //0106 - ANDQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - ORQ q#m,[reg]
                0,  //0101 - ORQ q#m,$m
                0,  //0102 - ORQ q#m,$m(PC)
                0,  //0103 - ORQ q#m,(reg)
                0,  //0104 - ORQ q#m,$m(reg)
                0,  //0105 - ORQ q#m,(reg)+
                0,  //0106 - ORQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - XORQ q#m,[reg]
                0,  //0101 - XORQ q#m,$m
                0,  //0102 - XORQ q#m,$m(PC)
                0,  //0103 - XORQ q#m,(reg)
                0,  //0104 - XORQ q#m,$m(reg)
                0,  //0105 - XORQ q#m,(reg)+
                0,  //0106 - XORQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - CMPQ q#m,[reg]
                0,  //0101 - CMPQ q#m,$m
                0,  //0102 - CMPQ q#m,$m(PC)
                0,  //0103 - CMPQ q#m,(reg)
                0,  //0104 - CMPQ q#m,$m(reg)
                0,  //0105 - CMPQ q#m,(reg)+
                0,  //0106 - CMPQ q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - NOT q#m,[reg]
                0,  //0101 - NOT q#m,$m
                0,  //0102 - NOT q#m,$m(PC)
                0,  //0103 - NOT q#m,(reg)
                0,  //0104 - NOT q#m,$m(reg)
                0,  //0105 - NOT q#m,(reg)+
                0,  //0106 - NOT q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - LSH q#m,[reg]
                0,  //0101 - LSH q#m,$m
                0,  //0102 - LSH q#m,$m(PC)
                0,  //0103 - LSH q#m,(reg)
                0,  //0104 - LSH q#m,$m(reg)
                0,  //0105 - LSH q#m,(reg)+
                0,  //0106 - LSH q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - RSH q#m,[reg]
                0,  //0101 - RSH q#m,$m
                0,  //0102 - RSH q#m,$m(PC)
                0,  //0103 - RSH q#m,(reg)
                0,  //0104 - RSH q#m,$m(reg)
                0,  //0105 - RSH q#m,(reg)+
                0,  //0106 - RSH q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - INC q#m,[reg]
                0,  //0101 - INC q#m,$m
                0,  //0102 - INC q#m,$m(PC)
                0,  //0103 - INC q#m,(reg)
                0,  //0104 - INC q#m,$m(reg)
                0,  //0105 - INC q#m,(reg)+
                0,  //0106 - INC q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - DEC q#m,[reg]
                0,  //0101 - DEC q#m,$m
                0,  //0102 - DEC q#m,$m(PC)
                0,  //0103 - DEC q#m,(reg)
                0,  //0104 - DEC q#m,$m(reg)
                0,  //0105 - DEC q#m,(reg)+
                0,  //0106 - DEC q#m,-(reg)
                0,  //0107 - ILLEGAL

                0,  //0100 - SEX q#m,[reg]
                0,  //0101 - SEX q#m,$m
                0,  //0102 - SEX q#m,$m(PC)
                0,  //0103 - SEX q#m,(reg)
                0,  //0104 - SEX q#m,$m(reg)
                0,  //0105 - SEX q#m,(reg)+
                0,  //0106 - SEX q#m,-(reg)
                0,  //0107 - ILLEGAL
            };

            long[] MCODE1 = new long[1] {
                0, //0000
            };

            for (int step = 0;step < 1024;step++)
            {
                if (step < MCODE1.Length)
                {
                    File.AppendAllText(PATH, MCODE1[step].ToString("X") + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(PATH, 0 + Environment.NewLine);
                }
                Console.WriteLine(step);
                
            }
            for (int step = 0; step < 1024; step++)
            {
                if (step < MCODE2.Length)
                {
                    File.AppendAllText(PATH, MCODE2[step].ToString("X") + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(PATH, 0 + Environment.NewLine);
                }
                Console.WriteLine(step);

            }
        }
    }
}