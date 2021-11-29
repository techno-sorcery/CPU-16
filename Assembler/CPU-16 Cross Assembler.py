##########################################
#      ATLAS CPU-16 CROSS-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2021       #
##########################################

import re
import sys
import os

opcodes1 = {  'JMP':'002', 'JSR':'003', 'LDS':'034', 'STS':'035', 'SWP':'036',
              'NOT':'150', 'NEG':'151', 'NEX':'152', 'LSH':'153', 'RSH':'154',
              'INC':'155', 'DEC':'156', 'SEX':'157'  }
opcodes2 = {  'MOV':'01', 'EXG':'02', 'ADD':'03', 'ADC':'04', 'SUB':'06',
              'SBB':'07', 'AND':'10', 'OR':'11',  'XOR':'12', 'CMP':'13'  }
opcodesB = {  'BIN':'004000', 'BIE':'004100', 'BIV':'004200', 'BIC':'004300', 'BNN':'004400',
              'BNE':'004500', 'BNV':'004600', 'BNC':'004700', 'BGE':'005000', 'BGT':'005100',
              'BLE':'005200', 'BLT':'005300'  }
opcodesI = {  'RST':'000000', 'HLT':'000100'  }
ctrlChar = {  '0':'0',  'a':'7',  'b':'8',  't':'9',  'n':'10',
              'v':'11', 'f':'12', 'r':'13', 'e':'27', '\\':'92',
              ',':'44', '\'':'39'  }

path = sys.argv[1]
#path = 'Hello.asm'
labels = {}
words = {}
lineNum = 1
posCounter = 0

adsReg = re.compile(r'^(D|d)(?P<register>[0-7]+)\Z')
adsDir = re.compile(r'\A(?P<address>([0-9]+|\$[0-9A-f]+|%[0-1]+|[A-z]{1}[A-z0-9]+))\Z')
adsRel = re.compile (r'\A(?P<address>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+))\(PC\)\Z')
adsInd = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\Z')
adsIndOff = re.compile(r'\A(?P<address>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+))\((D|d)(?P<register>[0-7])\)\Z')
adsIndInc = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\+\Z')
adsIndDec = re.compile(r'^-\((D|d)(?P<register>[0-7]+)\)\Z')
adsImm = re.compile(r'^#(?P<immediate>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+|\'[\\]?[ -~]{1}\'))\Z')
adsOrg = re.compile(r'^\$(?P<address>[0-9A-Fa-f]+)\Z')
spComma = re.compile(r'[\\]{0},')
defImm = re.compile(r'\A(?P<immediate>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+|\'[\\]?[ -~]{1}\'))\Z')
defStr = re.compile(r'^\'([ -~]+)\'\Z')

if path.rsplit('.',1)[1].upper() != 'ASM':
    print('Invalid file extension .',path.rsplit('.',1)[1],sep='')
    wait = input('Press enter to exit')
    exit()


#Parse addressing modes
def modeParse(arg):
    #Register   [reg]
    if adsReg.match(arg):
        return [0,0,adsReg.match(arg).group('register'),0]
    #Direct     $m
    elif adsDir.match(arg):
        return [1,1,0,numParse(adsDir.match(arg).group('address'),0)]
    #Relative   $m(PC)
    elif  adsRel.match(arg):
        return [2,1,0,numParse(adsRel.match(arg).group('address'),1)]
    #Register indirect (reg)
    elif adsInd.match(arg):
        return [3,0,adsInd.match(arg).group('register'),0]
    #Register indirect offset   $m(reg)
    elif adsIndOff.match(arg):
        return [4,1,adsIndOff.match(arg).group('register'),numParse(adsIndOff.match(arg).group('address'),0)]
    #Register indirect post inc (reg)+
    elif adsIndInc.match(arg):
        return [5,0,adsIndInc.match(arg).group('register'),0]
    #Register indirect pre dec  -(reg)
    elif adsIndDec.match(arg):
        return [6,0,adsIndDec.match(arg).group('register'),0]
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
            #MOV, EXG, ADD, ADC, SUB, SBB, AND, OR, XOR, CMP
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
            #JMP, JSR, LDS, STS, SWP, NOT, NEG, NEX, LSH, RSH, INC, DEC, SEX
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
                words[posCounter] = hex(int(opcodesB[line[0].upper()],8))
                words[posCounter+1] = numParse(line[1],1)
                posCounter = posCounter + 2
            #RST, HLT
            elif line[0].upper() in opcodesI:
                words[posCounter] = hex(int(opcodesI[line[0].upper()],8))
                posCounter = posCounter + 1
            #Directives
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
            if words[line][0] == '@':
                words[line] = tohex(labels[words[line].split('@',1)[1]]-line,16)
            elif words[line] in labels:
                words[line] = hex(labels[words[line]])
            else:
                print('Undefined label \'',words[line],'\'',sep='')
                wait = input('Press enter to exit')
                exit()
        f.write(str(words[line]))
        f.write('\n')
        #print(words[line])
    else:
        multiplier = multiplier + 1
f.close()
wait = input('Press enter to exit')
exit()
