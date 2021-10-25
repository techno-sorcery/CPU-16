import re
import sys
import argparse



symbols = {}

opcodes = {
    'RST':0,
    'HLT':0,
    'CAL':0,
    'JMP':1,
    'JSR':2,
    'BRA':3,
    'LDA':4,
    'LDB':5,
    'LDC':6,
    'LDD':7,
    'LDE':8,
    'LDX':9,
    'LDY':10,
    'LDF':11,
    'LDS':12,
    'STA':13,
    'STB':14,
    'STC':15,
    'STD':16,
    'STE':17,
    'STX':18,
    'STY':19,
    'STF':20,
    'STS':21,
    'STP':22,
}

file = open("input.asm", "r")
fileParse = file.read()
lines = fileParse.splitlines()
print(lines)
length = len(lines)
progCounter = 0;

for x in range(length):
    tempLine = lines[x].split(";",1)
    lines[x] = tempLine[0]
    
    tempLine = re.search("$:", "test: a123 :test")
    if tempLine:
            print("lol")
    
    
print(lines)
print(symbols)
        
