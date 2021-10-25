import re
import sys
import optparse

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
    'SDE':17,
    'STX':18,
    'STY':19,
    'STF':20,
    'STP':21,
    'MVD':22,
    'MVR':23,
    'MVA':24,
    'MVB':25,
    'MVC':26,
    'MVD':27,
    'MVE':28,
    'MVX':29,
    'MVY':30,
    'MVXI':31,
    'MVYI':32,
    'MVXD':33,
    'MVYD':34,
    'MVSI':35,
    'MVSD':36,
}   
    
    
