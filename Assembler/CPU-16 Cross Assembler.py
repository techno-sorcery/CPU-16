##########################################
#      ATLAS CPU-16 CROSS-ASSEMBLER      #
#      WRITTEN BY HAYDEN B. - 2021       #
##########################################

import re
import sys
import argparse

labels = {}

file = open("input.asm", "r")
fileParse = file.read()
fileParse = fileParse.strip()
lines = fileParse.splitlines()
#print(lines)

adsImm = re.compile(r'^#(?P<immediate>[0-9A-F]+)\Z')
adsReg = re.compile(r'^d(?P<register>[0-7]+)\Z')
adsDir = re.compile(r'^\$(?P<address>[0-9A-F]+)\Z')
adsRel = re.compile (r'^\$(?P<address>[0-9A-F]+)\(PC\)\Z')
adsInd = re.compile (r'^\(d(?P<register>[0-7]+)\)\Z')
adsIndOff = re.compile(r'^\$(?P<address>[0-9A-F]+)\((?P<register>d[0-7])\)\Z')
adsIndInc = re.compile (r'^\(d(?P<register>[0-7]+)\)\+\Z')
adsIndDec = re.compile(r'^-\(d(?P<register>[0-7]+)\)\Z')

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
        byteCount = byteCount+1
        m = modeParse(arg[1])
        print(m[0])
        
#Parse addressing modes
def modeParse(arg):
    if adsReg.match(arg):
        return [0,2]
    elif adsDir.match(arg):
        return [1,2]
    elif  adsRel.match(arg):
        return [2,2]
    elif adsInd.match(arg):
        return [3,2]
    elif adsIndOff.match(arg):
        return [4,2]
    elif adsIndInc.match(arg):
        return [5,2]
    elif adsIndDec.match(arg):
        return [6,2]
    elif adsImm.match(arg):
        return [7,2]
        
#First pass    
with open("input.asm") as f:
    for line in f:
        print(labelParse(line))
