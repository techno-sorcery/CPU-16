##########################################
#      ATLAS CPU-16 MICRO-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2022       #
##########################################

import re
import sys
import os

mcode = {
    'PC_ST'     :'0b000000000000000000000000000010000000000',
    'OP1_ST'    :'0b000000000000000000000000000100000000000',
    'OP2_ST'    :'0b000000000000000000000000000110000000000',
    'IR_ST'     :'0b000000000000000000000000001000000000000',
    'MDR_ST'    :'0b000000000000000000000000001010000000000',
    'MEM_ST'    :'0b000000000000000000000000001100000000000',
    'REG1_ST'   :'0b000000000000000000000000001110000000000',
    'REG2_ST'   :'0b000000000000000000000000010000000000000',
    'SP_ST'     :'0b000000000000000000000000010010000000000',
    'STAT_ST'   :'0b000000000000000000000000010100000000000',

    'F_DOUT'    :'0b000000000000000000000000100000000000000',
    'PC_DOUT'   :'0b000000000000000000000001000000000000000',
    'SWP_DOUT'  :'0b000000000000000000000011000000000000000',
    'WRD_DOUT'  :'0b000000000000000000000011100000000000000',
    'MDR_DOUT'  :'0b000000000000000000000100000000000000000',
    'MEM_DOUT'  :'0b000000000000000000000100100000000000000',
    'VECT_DOUT' :'0b000000000000000000000101000000000000000',
    'REG1_DOUT' :'0b000000000000000000000101100000000000000',
    'REG2_DOUT' :'0b000000000000000000000110000000000000000',
    'SP_DOUT'   :'0b000000000000000000000110100000000000000',

    'PC_AOUT'   :'0b000000000000000000001000000000000000000',
    'MAR_AOUT'  :'0b000000000000000000010000000000000000000',
    
    'COND_N'    :'0b000000000000000000100000000000000000000',
    'COND_Z'    :'0b000000000000000001000000000000000000000',
    'COND_V'    :'0b000000000000000001100000000000000000000',
    'COND_C'    :'0b000000000000000010000000000000000000000',

    'ALU_ADD'   :'0b000000000100100100000001100000000000000',
    'ALU_ADC'   :'0b000000000010100100000001100000000000000',
    'ALU_SUB'   :'0b000000000000011000000001100000000000000',
    'ALU_SBB'   :'0b000000000010011000000001100000000000000',
    'ALU_AND'   :'0b000000000001101100000001100000000000000',
    'ALU_OR'    :'0b000000000001111000000001100000000000000',
    'ALU_XOR'   :'0b000000000001011000000001100000000000000',
    'ALU_NOT'   :'0b000000000001000000000001100000000000000',
    'ALU_LSH'   :'0b000000000100110000000001100000000000000',
    'ALU_RSH'   :'0b000000000000000000000010000000000000000',
    'ALU_INC'   :'0b000000000000000000000001100000000000000',
    'ALU_DEC'   :'0b000000000100111100000001100000000000000',
    'ALU_SEX'   :'0b000000000000000000000010100000000000000',
    
    'PC_INC'    :'0b000000001000000000000000000000000000000',
    'COND_NEG'  :'0b000000010000000000000000000000000000000',

    'F_ALUIN'   :'0b000000100000000000000000000000000000000',
    'F_ST'      :'0b000001000000000000000000000000000000000',

    'MAR_ST'    :'0b000010000000000000000000000000000000000',

    'MODE_RST'  :'0b000100000000000000000000000000000000000',
    'MODE_DMA'  :'0b001000000000000000000000000000000000000',
    'MODE_FLT'  :'0b001100000000000000000000000000000000000',
    'MODE_FETCH':'0b010000000000000000000000000000000000000',

    'IRQ_EN'    :'0b100000000000000000000000000000000000000'
    }


#path = sys.argv[1]
path = 'mcode.asm'
labels = {}
words = {}
labels2 = {}
lineNum = 0

if path.rsplit('.',1)[1].upper() != 'ASM':
    print('Invalid file extension .',path.rsplit('.',1)[1],sep='')
    wait = input('Press enter to exit')
    exit()

#First pass - Find labels & parse instructions   
with open(path) as f:
    for line in f:
        line = line.strip()
        #Find labels
        if line != '' and line[0] == '.':
            line = line.split('.')[1]
            labels[line.split(' ')[0]] = lineNum
            print('Label ',line.split(' ')[0],' found @ $',hex(lineNum),sep='')
            line = line.split(' ', 1)
            if len(line) > 1:
                line = line[1]
            else:
                line = ''
        else:
            line = line.replace(',',' ')
            line = line.split()
            #print(line)
            currentLine = 0;
            instruction = False
            label = ''
            for word in line:
                if word in mcode:
                    currentLine = int(mcode[word],2)|currentLine
                    instruction = True
                elif word[0] == '$':
                    word = word.split('$')
                    lineNum = int(word[1],16)
                elif word[0] == ';':
                    break
                else:
                    if word[0] == '+':
                        word = word.split('+')
                        if currentLine >= 1024:
                            word[1] = int(word[1]) - 1024
                        currentLine = (int(lineNum)+(int(word[1])))|currentLine
                    else:
                        label = word
            if instruction == True or label != '':
                words[lineNum] = currentLine
                if label != '':
                    labels2[lineNum] = label
                lineNum = lineNum + 1
    #print()
    #print(labels)
    #print()
    #print(words)
    #print()
    #print (labels2)
print()

#Create output hex file
path = path.rsplit('.',1)[0] + '.hex'
if os.path.exists(path):
  os.remove(path)
f = open(path,'x')
f.write('v2.0 raw\n')

#Second pass - Fill in labels, write to hex file
for line in range(0,2048):
    currentLine = 0
    if line in words:
        #if words[line][0] == '@':
        #    words[line] = (words[line].split('@'))[1]
        #    if currentLine:
        if line in labels2:
            #print(labels[labels2[line]])
            if int(labels[labels2[line]]) >= 1024:
                words[line] = words[line]|labels[labels2[line]]-1024
            else:    
                words[line] = words[line]|labels[labels2[line]]
        currentLine = words[line]
    f.write(hex(currentLine))
    f.write('\n')
f.close()
wait = input('Press enter to exit')
exit()
