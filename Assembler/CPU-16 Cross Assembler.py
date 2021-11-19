##########################################
#      ATLAS CPU-16 CROSS-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2021       #
##########################################

import re
import sys
import argparse

opcodes = { 'MOV':'01', 'MOV.H':'02', 'MOV.L':'03', 'EXG':'04', 'ADD':'06', 'ADC':'07',
            'SUB':'10', 'SBB':'11', 'AND':'12',   'OR':'13',    'XOR':'14', 'CMP':'15'  }
labels = {}
lineNum = 1

adsImm = re.compile(r'^#(?P<immediate>[0-9A-F]+)\Z')
adsReg = re.compile(r'^(D|d)(?P<register>[0-7]+)\Z')
adsDir = re.compile(r'^\$(?P<address>[0-9A-F]+)\Z')
adsRel = re.compile (r'^\$(?P<address>[0-9A-F]+)\(PC\)\Z')
adsInd = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\Z')
adsIndOff = re.compile(r'^\$(?P<address>[0-9A-F]+)\((D|d)(?P<register>[0-7])\)\Z')
adsIndInc = re.compile (r'^\((D|d)(?P<register>[0-7]+)\)\+\Z')
adsIndDec = re.compile(r'^-\((D|d)(?P<register>[0-7]+)\)\Z')

file = open("input.asm", "r")
fileParse = file.read()
fileParse = fileParse.strip()
lines = fileParse.splitlines()
#print(lines)

#Find labels & corresponding addresses
def labelParse(arg):
    arg = arg.strip()
    #print(arg)
    if arg[0] == '.':
        return 1
    elif arg[0] != '#' and arg[0] != '':
        instParse(arg)

#Parse instructions
def instParse(arg):
    arg = arg.replace(',', ' ')
    arg = arg.split()
    print(arg)

    byteCount = 0
    opcode = 0

    if arg[0].upper() == 'MOV':
        opcode = "01"
        byteCount = 1
        m = modeParse(arg[1])
        opcode = opcode + str(m[0])
        reg1 = m[2]
        byteCount = byteCount + m[1]
        m = modeParse(arg[2])
        byteCount = byteCount + m[1]
        if m[0] != 7:
            opcode = opcode + str(m[0])
            opcode = opcode + str(reg1) + str(m[2])
            print(opcode)
            return [opcode]
        else:
            print('Invalid addressing mode on line',lineNum)
            wait = input('')
            exit()
        
        
#Parse addressing modes
def modeParse(arg):
    if adsReg.match(arg):
        return [0,0,adsReg.match(arg).group('register')]
    elif adsDir.match(arg):
        return [1,1,0,adsDir.match(arg).group('address')]
    elif  adsRel.match(arg):
        return [2,1,0,adsRel.match(arg).group('address')]
    elif adsInd.match(arg):
        return [3,0,adsInd.match(arg).group('register')]
    elif adsIndOff.match(arg):
        return [4,1,adsIndOff.match(arg).group('register'),adsIndOff.match(arg).group('address')]
    elif adsIndInc.match(arg):
        return [5,0,adsIndInc.match(arg).group('register')]
    elif adsIndDec.match(arg):
        return [6,0,adsIndDec.match(arg).group('register')]
    elif adsImm.match(arg):
        return [7,1,0,adsImm.match(arg).group('immediate')]
    else:
        print('Invalid addressing mode on line',lineNum)
        wait = input('')
        exit()
        
#First pass    
with open("input.asm") as f:
    for line in f:
        print(labelParse(line))
        lineNum = lineNum + 1
