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

def labelParse(arg):
    arg = arg.strip()
    #print(arg)
    if arg[0] == '.':
        return 1
    elif arg[0] != '#':
        instParse(arg)

def instParse(arg):
    arg = arg.replace(',', ' ')
    arg = arg.split()
    print(arg)

    byteCount = 0
    opcode = 0

    if arg[0].upper() == 'MOV':
        opcode = "01"
        byteCount = byteCount+1
        
        #if arg[2].upper()[0] == 'D':
         #   opcode = opcode + "0"
        if arg[2].upper()[0] == '$' and 1==0:
            print("lol")
        
    

with open("input.asm") as f:
    for line in f:
        print(labelParse(line))
