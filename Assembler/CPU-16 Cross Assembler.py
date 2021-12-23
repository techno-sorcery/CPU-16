##########################################
#      ATLAS CPU-16 CROSS-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2021       #
##########################################

import re
import sys
import os

opcodes1 = {  'JMP':'003', 'JSR':'004', 'NOT':'130', 'LSH':'131', 'RSH':'132', 'INC':'133',
              'DEC':'134', 'SEX':'135', 'POP':'015'  }
opcodes2 = {  'MOV':'01', 'ADD':'02', 'ADC':'03', 'SUB':'04', 'SBB':'05', 'AND':'06',
              'OR':'07',  'XOR':'10', 'CMP':'11'  }
opcodesB = {  'BIN':'005000', 'BIE':'005100', 'BIV':'005200', 'BIC':'005300', 'BNN':'005400', 'BNE':'005500',
              'BNV':'005600', 'BNC':'005700', 'BGE':'006000', 'BGT':'006100', 'BLE':'006200', 'BLT':'006300'  }
opcodesI = {  'RST':'000000', 'HLT':'000100', 'RTS':'000700'  }
opcodesF = {  'LDF':'00230',  'LDT':'00270', 'STC':'00100', 'ULNK':'00170', 'SWP':'00140', 'EXG':'00150'  }
opcodesL = {  'LNK':'00160', }
opcodesX = {  'ANF':'002000', 'ORF':'002100', 'XOF':'002200', 'ANT':'002400', 'ORT':'002500',
              'XOT':'002600'  }
ctrlChar = {  '0':'0',  'a':'7',  'b':'8',  't':'9',  'n':'10',
              'v':'11', 'f':'12', 'r':'13', 'e':'27', '\\':'92',
              ',':'44', '\'':'39'  }

#path = sys.argv[1]
path = 'Hello.asm'
labels = {}
words = {}
lineNum = 1
posCounter = 0

adsReg = re.compile(r'\A(?P<register>([Dd][0-7])|[Ss][Pp])\Z')
adsDir = re.compile(r'\A(?P<address>([0-9]+|\$[0-9A-f]+|%[0-1]+|[A-z]{1}[A-z0-9]*))\Z')
adsRel = re.compile (r'\A(?P<address>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]*))\(PC\)\Z')
adsInd = re.compile (r'^\((?P<register>([Dd][0-7]|[Ss][Pp]))\)\Z')
adsIndOff = re.compile(r'\A(?P<address>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]*))\((?P<register>([Dd][0-7]|[Ss][Pp]))\)\Z')
adsIndInc = re.compile (r'^\((?P<register>([Dd][0-7]|[Ss][Pp]))\)\+\Z')
adsIndDec = re.compile(r'^-\((?P<register>([Dd][0-7]|[Ss][Pp]))\)\Z')
adsImm = re.compile(r'^#(?P<immediate>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]*|\'[\\]?[ -~]{1}\'))\Z')
adsOrg = re.compile(r'^\$(?P<address>[0-9A-Fa-f]+)\Z')
spComma = re.compile(r'[\\]{0},')
defImm = re.compile(r'\A(?P<immediate>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]*|\'[\\]?[ -~]{1}\'))\Z')
defStr = re.compile(r'^\'([ -~]+)\'\Z')

if path.rsplit('.',1)[1].upper() != 'ASM':
    print('Invalid file extension .',path.rsplit('.',1)[1],sep='')
    wait = input('Press enter to exit')
    exit()


#Parse addressing modes
def modeParse(arg):
    #Register   [reg]
    if adsReg.match(arg):
        if adsReg.match(arg).group('register').upper() == 'SP':
            return [0,0,7,0]
        else:
            return [0,0,adsReg.match(arg).group('register')[1],0]
    #Direct     $m
    elif adsDir.match(arg):
        return [1,1,0,numParse(adsDir.match(arg).group('address'),0)]
    #Relative   $m(PC)
    elif  adsRel.match(arg):
        return [2,1,0,numParse(adsRel.match(arg).group('address'),1)]
    #Register indirect (reg)
    elif adsInd.match(arg):
        if adsInd.match(arg).group('register').upper() == 'SP':
            return [3,0,7,0]
        else:
            return [3,0,adsInd.match(arg).group('register')[1],0]
    #Register indirect offset   $m(reg)
    elif adsIndOff.match(arg):
        if adsIndOff.match(arg).group('register').upper() == 'SP':
            return [4,1,7,numParse(adsIndOff.match(arg).group('address'),0)]
        else:
            return [4,1,adsIndOff.match(arg).group('register')[1],numParse(adsIndOff.match(arg).group('address'),0)]
    #Register indirect post inc (reg)+
    elif adsIndInc.match(arg):
        if adsIndInc.match(arg).group('register').upper() == 'SP':
            return [5,0,7,0]
        else:
            return [5,0,adsIndInc.match(arg).group('register')[1],0]
    #Register indirect pre dec  -(reg)
    elif adsIndDec.match(arg):
        if adsIndDec.match(arg).group('register').upper() == 'SP':
            return [6,0,7,0]
        else:
            return [6,0,adsIndDec.match(arg).group('register')[1],0]
    #Immediate #m
    elif adsImm.match(arg):
        return [7,1,0,numParse(adsImm.match(arg).group('immediate'),0)]
    else:
        print('Invalid addressing mode @ line #',lineNum,sep='')
        wait = input('Press enter to exit')
        exit()

#Parse immediates & addresses
def numParse(arg,rel):
    #Hex
    if arg[0] == '$':
        return tohex(int(arg.split('$')[1],16),16)
    #Bin
    elif arg[0] == '%':         
        return tohex(int(arg.split('%')[1],2),16)
    #Char
    elif arg[0] == '\'':
        arg = re.split(r'(?<!\\)\'',arg)
        #Escape character
        if arg[1][0] == '\\':
            if arg[1][1] in ctrlChar:
                return hex(int(ctrlChar[arg[1][1]]))
            else:
                return hex(ord(arg[1][1]))
        else:
            return hex(ord(arg[1]))
    #Label
    else:
        if arg.lstrip('-').isdigit() == True:
            return tohex(int(arg),16)
        else:
            #Relative label
            if rel == 1:
                return '@'+arg
            else:
                return arg

#Convert negative to two's compliment hex
def tohex(val, nbits):
  return hex((val + (1 << nbits)) % (1 << nbits))

#First pass - Find labels & parse instructions   
with open(path) as f:
    for line in f:
        line = line.strip()
        #Find labels
        if line != '' and line[0] == '.':
            line = line.split('.')[1]
            labels[line.split(' ')[0]] = posCounter
            print('Label ',line.split(' ')[0],' found @ $',hex(posCounter),sep='')
            line = line.split(' ', 1)
            if len(line) > 1:
                line = line[1]
            else:
                line = ''
        #Parse instructions
        if line != '' and line[0] != ';':
            tempPos = posCounter
            line = line.strip()
            line = line.split(' ',1)
            print(line)
            opcode = 0
            #MOV, ADD, ADC, SUB, SBB, AND, OR, XOR, CMP
            if line[0].upper() in opcodes2:
                opcode = opcodes2[line[0].upper()]
                line = line[1].rsplit(',',1)
                print(line)
                ads1 = modeParse(line[0])
                if ads1[1] == 1:
                    tempPos = tempPos+1
                    words[tempPos] = ads1[3] 
                opcode = opcode + str(ads1[0])
                ads2 = modeParse(line[1])
                if ads2[1] == 1:
                    tempPos = tempPos+1
                    words[tempPos] = ads2[3]
                if ads2[0] != 7:
                    opcode = opcode + str(ads2[0])
                    opcode = opcode + str(ads1[2]) + str(ads2[2])
                    print(opcode)
                    words[posCounter] = hex(int(opcode,8))
                    posCounter = posCounter + (1 + ads1[1] + ads2[1])
                else:
                    print('Invalid addressing mode @ line #',lineNum,sep='')
                    wait = input('Press enter to exit')
                    exit()
            #JMP, JSR, NOT, LSH, RSH, INC, DEC, SEX
            elif line[0].upper() in opcodes1:
                opcode = opcodes1[line[0].upper()]
                ads1 = modeParse(line[1])
                if ads1[1] == 1:
                    words[posCounter+1] = ads1[3]
                opcode = opcode + str(ads1[0]) + '0' + str(ads1[2])
                print(opcode)
                words[posCounter] = hex(int(opcode,8))
                posCounter = posCounter + 1 + ads1[1]
            #BIN, BIE, BIV, BIC, BNN, BNE, BNV, BNC, BGE, BGT, BLE, BLT
            elif line[0].upper() in opcodesB:
                print(opcodesB[line[0].upper()])
                words[posCounter] = hex(int(opcodesB[line[0].upper()],8))
                words[posCounter+1] = numParse(line[1],1)
                posCounter = posCounter + 2
            #RST, HLT
            elif line[0].upper() in opcodesI:
                words[posCounter] = hex(int(opcodesI[line[0].upper()],8))
                posCounter = posCounter + 1
            #LDF, LDT, STC, ULNK, SWP
            elif line[0].upper() in opcodesF:
                opcode = opcodesF[line[0].upper()]
                if adsReg.match(line[1]):
                    opcode = opcode+adsReg.match(line[1]).group('register')
                    words[posCounter] = hex(int(opcode,8))
                    posCounter = posCounter + 1
                else:
                    print('Invalid addressing mode @ line #',lineNum,sep='')
                    wait = input('Press enter to exit')
                    exit()
            #LNK
            elif line[0].upper() in opcodesL:
                opcode = opcodesL[line[0].upper()]
                line = line[1].rsplit(',',1)
                if adsReg.match(line[0]) and adsImm.match(line[1]):
                    opcode = opcode+adsReg.match(line[0]).group('register')
                    words[posCounter] = hex(int(opcode,8))
                    words[posCounter+1] = numParse(adsImm.match(line[1]).group('immediate'),1)
                    posCounter = posCounter + 2
                else:
                    print('Invalid addressing mode @ line #',lineNum,sep='')
                    wait = input('Press enter to exit')
                    exit()
            #ANF, ORF, XOF, ANT, ORT, XOT
            elif line[0].upper() in opcodesX:
                opcode = opcodesX[line[0].upper()]
                line = line[1].rsplit(',',1)
                if adsImm.match(line[0]):
                    words[posCounter] = hex(int(opcode,8))
                    words[posCounter+1] = numParse(adsImm.match(line[0]).group('immediate'),0)
                    posCounter = posCounter + 2
                else:
                    print('Invalid addressing mode @ line #',lineNum,sep='')
                    wait = input('Press enter to exit')
                    exit()
            #Directives
            #ORG
            elif line[0].upper() == 'ORG':
                if adsOrg.match(line[1]):
                    posCounter = int(adsOrg.match(line[1]).group('address'),16)
                    print()
                else:
                    print('Invalid addressing mode @ line #',lineNum,sep='')
                    wait = input('Press enter to exit')
                    exit()
            #Define constant
            elif line[0].upper() == 'DW':
                line = re.split(r'(?<!\\),',line[1])
                print(line)
                #Parse constants
                for x in range(0, len(line)):
                    if defImm.match(line[x]):
                        print(numParse(line[x],0))
                        words[posCounter] = numParse(line[x],0)
                        posCounter = posCounter + 1
                    #Parse strings
                    elif defStr.match(line[x]):
                        escape = False
                        for y in range(1,len(line[x])-1):
                            if escape == True:
                                if line[x][y] in ctrlChar:
                                    #print(line[x][y]) #ctrlChar[line[x][y]]
                                    words[posCounter] = hex(int(ctrlChar[line[x][y]]))
                                    escape = False
                                    posCounter = posCounter+1
                                else:
                                    print('Invalid ctrl character \'\\',line[x][y],'\' @ line #',lineNum,sep='')
                                    wait = input('Press enter to exit')
                                    exit()
                            elif line[x][y] == '\\':
                                escape = not escape
                            else:
                                words[posCounter] = hex(ord(line[x][y]))
                                #print(line[x][y])
                                posCounter = posCounter+1
                    else:
                        print('Invalid value \'',line[x],'\' @ line #',lineNum,sep='')
                        wait = input('Press enter to exit')
                        exit()
            #Illegal instruction
            else:
                print('Illegal instruction \'',line[0],'\' @ line #',lineNum,sep='')
                wait = input('Press enter to exit')
                exit()
            
        lineNum = lineNum + 1
    print(labels)
    #print(words)
print()
        
#Create output hex file
path = path.rsplit('.',1)[0] + '.hex'
if os.path.exists(path):
  os.remove(path)
f = open(path,'x')
f.write('v2.0 raw\n')

#Second pass - Fill in labels, write to hex file
posCounter = 0
multiplier = 0
for line in range(0,max(map(int,words))+1):
    if line in words:
        #print(words[line])
        #Write 0s
        if multiplier > 0:
            f.write(str(multiplier))
            f.write('*0')
            f.write('\n')
            multiplier = 0
        if words[line][0] == '0':
            words[line] = words[line].split('x')[1]
        #Fill in labels
        else:
            if words[line][0] == '@' and words[line].split('@',1)[1] in labels:
                words[line] = tohex(labels[words[line].split('@',1)[1]]-line,16)
            elif words[line] in labels:
                words[line] = hex(labels[words[line]])
            else:
                print('Undefined label \'',words[line],'\'',sep='')
                wait = input('Press enter to exit')
                exit()
        f.write(str(words[line]))
        f.write('\n')
        
    else:
        multiplier = multiplier + 1
f.close()
wait = input('Press enter to exit')
exit()
