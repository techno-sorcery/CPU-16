##########################################
#      ATLAS CPU-16 CROSS-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2021       #
##########################################

import re
import sys
import argparse

opcodes = { 'MOV':'01', 'MOV.H':'02', 'MOV.L':'03', 'EXG':'04', 'ADD':'06', 'ADC':'07',
            'SUB':'10', 'SBB':'11',   'AND':'12',   'OR':'13',  'XOR':'14', 'CMP':'15'  }
labels = {}
lineNum = 1
posCounter = 1

adsImm = re.compile(r'^#(?P<immediate>[0-9A-Fa-f]+)\Z')
adsReg = re.compile(r'^(D|d)(?P<register>[0-7]+)\Z')
adsDir = re.compile(r'^\$(?P<address>[0-9A-Fa-f]+)\Z')
adsRel = re.compile (r'^\$(?P<address>[0-9A-F]+)\(PC\)\Z')
adsInd = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\Z')
adsIndOff = re.compile(r'^\$(?P<address>[0-9A-Fa-f]+)\((D|d)(?P<register>[0-7])\)\Z')
adsIndInc = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\+\Z')
adsIndDec = re.compile(r'^-\((D|d)(?P<register>[0-7]+)\)\Z')
adsOrg = re.compile(r'^\$(?P<address>[0-9A-Fa-f]+)\Z')

file = open("input.asm", "r")
fileParse = file.read()
fileParse = fileParse.strip()
lines = fileParse.splitlines()

#Find labels & corresponding addresses
def labelParse(arg):
    global posCounter
    arg = arg.strip()
    #print(arg)
    if arg[0] == '.':
        print('Label ',arg,' found @ $',hex(posCounter),sep='')
        arg = arg.split('.')
        labels[arg[1]] = posCounter
    elif arg[0] != ';' and arg[0] != '':
        posCounter = posCounter + instParse(arg)[0]
        print(posCounter)

#Parse instructions
def instParse(arg):
    global posCounter
    arg = arg.replace(',', ' ')
    arg = arg.split()
    print(arg)
    opcode = 0
    if arg[0].upper() == 'MOV':
        opcode = "01"
        ads1 = modeParse(arg[1])
        opcode = opcode + str(ads1[0])
        ads2 = modeParse(arg[2])
        if ads2[0] != 7:
            opcode = opcode + str(ads1[0])
            opcode = opcode + str(ads1[2]) + str(ads2[2])
            print(opcode)
            return [1 + ads1[1] + ads2[1], opcode, ads1[3], ads2[3]]
        else:
            print('Invalid addressing mode @ line',lineNum)
            wait = input('')
            exit()
    elif arg[0].upper() == 'ORG':
        if adsOrg.match(arg[1]):
            return [int(adsOrg.match(arg[1]).group('address'),16) - posCounter]
        else:
            print('Invalid addressing mode @ line',lineNum)
            wait = input('')
            exit()  
    else:
        print('Illegal instruction',arg[0],'@ line',lineNum)
        wait = input('')
        exit()
        
#Parse addressing modes
def modeParse(arg):
    if adsReg.match(arg):
        return [0,0,adsReg.match(arg).group('register'),0]
    elif adsDir.match(arg):
        return [1,1,0,adsDir.match(arg).group('address')]
    elif  adsRel.match(arg):
        return [2,1,0,adsRel.match(arg).group('address')]
    elif adsInd.match(arg):
        return [3,0,adsInd.match(arg).group('register'),0]
    elif adsIndOff.match(arg):
        return [4,1,adsIndOff.match(arg).group('register'),adsIndOff.match(arg).group('address')]
    elif adsIndInc.match(arg):
        return [5,0,adsIndInc.match(arg).group('register'),0]
    elif adsIndDec.match(arg):
        return [6,0,adsIndDec.match(arg).group('register'),0]
    elif adsImm.match(arg):
        return [7,1,0,adsImm.match(arg).group('immediate')]
    else:
        print('Invalid addressing mode @ line',lineNum)
        wait = input('')
        exit()
        
#First pass    
with open("input.asm") as f:
    for line in f:
        labelParse(line)
        lineNum = lineNum + 1
print(labels)
