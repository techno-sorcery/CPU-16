##########################################
#      ATLAS CPU-16 CROSS-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2021       #
##########################################

import re
import sys
import os

opcodes = { 'MOV':'01', 'MOV.H':'02', 'MOV.L':'03', 'EXG':'04', 'ADD':'06', 'ADC':'07',
            'SUB':'10', 'SBB':'11',   'AND':'12',   'OR':'13',  'XOR':'14', 'CMP':'15'  }
labels = {}
words = {}
lineNum = 1
posCounter = 1

adsReg = re.compile(r'^(D|d)(?P<register>[0-7]+)\Z')
adsDir = re.compile(r'\A(?P<address>([0-9]+|\$[0-9A-f]+|%[0-1]+|[A-z]{1}[A-z0-9]+))\Z')
adsRel = re.compile (r'\A(?P<address>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+))\(PC\)\Z')
adsInd = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\Z')
adsIndOff = re.compile(r'\A(?P<address>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+))\((D|d)(?P<register>[0-7])\)\Z')
adsIndInc = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\+\Z')
adsIndDec = re.compile(r'^-\((D|d)(?P<register>[0-7]+)\)\Z')
adsImm = re.compile(r'^#(?P<immediate>(-?[0-9]+|\$-?[0-9A-f]+|%-?[0-1]+|[A-z]{1}[A-z0-9]+|\'[ -~]{1}\'))\Z')
adsOrg = re.compile(r'^\$(?P<address>[0-9A-Fa-f]+)\Z')
        
#Parse addressing modes
def modeParse(arg):
    if adsReg.match(arg):
        return [0,0,adsReg.match(arg).group('register'),0]
    elif adsDir.match(arg):
        return [1,1,0,numParse(adsDir.match(arg).group('address'))]
    elif  adsRel.match(arg):
        return [2,1,0,numParse(adsRel.match(arg).group('address'))]
    elif adsInd.match(arg):
        return [3,0,adsInd.match(arg).group('register'),0]
    elif adsIndOff.match(arg):
        return [4,1,adsIndOff.match(arg).group('register'),numParse(adsIndOff.match(arg).group('address'))]
    elif adsIndInc.match(arg):
        return [5,0,adsIndInc.match(arg).group('register'),0]
    elif adsIndDec.match(arg):
        return [6,0,adsIndDec.match(arg).group('register'),0]
    elif adsImm.match(arg):
        return [7,1,0,numParse(adsImm.match(arg).group('immediate'))]
    else:
        print('Invalid addressing mode @ line',lineNum)
        wait = input('')
        exit()

#Parse immediates & addresses
def numParse(arg):
    if arg[0] == '$':
        return tohex(int(arg.split('$')[1],16),16)
    elif arg[0] == '%':
        return tohex(int(arg.split('%')[1],2),16)
    elif arg[0] == '\'':
        return hex(ord(arg.split('\'')[1]))
    else:
        if arg.lstrip('-').isdigit() == True:
            return tohex(int(arg),16)
        else:
            return arg

#Convert negative to two's compliment hex
def tohex(val, nbits):
  return hex((val + (1 << nbits)) % (1 << nbits))

#First pass - Find labels & parse instructions   
with open("input.asm") as f:
    for line in f:
        line = line.strip()
        if line != '' and line[0] == '.':
            line = line.split('.')[1]
            labels[line.split(' ')[0]] = posCounter
            print('Label ',line.split(' ')[0],' found @ $',hex(posCounter),sep='')
            line = line.split(' ', 1)
            if len(line) > 1:
                line = line[1]
            else:
                line = ''
        if line != '' and line[0] != ';':
            #Parse instructions
            line = line.strip()
            line = line.replace(',', ' ')
            line = line.split()
            print(line)
            opcode = 0
            if line[0].upper() == 'MOV':
                opcode = "01"
                ads1 = modeParse(line[1])
                if ads1[1] == 1:
                    words[posCounter+1] = ads1[3] 
                opcode = opcode + str(ads1[0])
                ads2 = modeParse(line[2])
                if ads2[1] == 1:
                    words[posCounter+2] = ads2[3]
                if ads2[0] != 7:
                    opcode = opcode + str(ads1[0])
                    opcode = opcode + str(ads1[2]) + str(ads2[2])
                    print(opcode)
                    words[posCounter] = hex(int(opcode,8))
                    posCounter = posCounter + (1 + ads1[1] + ads2[1])
                else:
                    print('Invalid addressing mode @ line',lineNum)
                    wait = input('')
                    exit()
            elif line[0].upper() == 'ORG':
                if adsOrg.match(line[1]):
                    posCounter = int(adsOrg.match(line[1]).group('address'),16)
                    print()
                else:
                    print('Invalid addressing mode @ line',lineNum)
                    wait = input('')
                    exit()  
            else:
                print('Illegal instruction',arg[0],'@ line',lineNum)
                wait = input('')
                exit()
            
        lineNum = lineNum + 1
    print(labels)
    print(words)
print()
        
#Create output hex file
if os.path.exists("output.hex"):
  os.remove("output.hex")
f = open('output.hex','x')
f.write('v2.0 raw\n')

#Second pass - Fill in labels, write to hex file
posCounter = 1
lineNum = 1
multiplier = 0
for line in range(1,max(map(int,words))+1):
    if line in words:
        if multiplier > 0:
            f.write(str(multiplier + 1))
            f.write('*0')
            f.write('\n')
            multiplier = 0
        if words[line][0] == '0':
            words[line] = words[line].split('x')[1]
        else:
            if words[line] in labels:
                words[line] = labels[words[line]]
            else:
                print('Undefined label',words[line])
                wait = input('')
                exit()
        f.write(str(words[line]))
        f.write('\n')
        print(words[line])
    else:
        multiplier = multiplier + 1
f.close()
