file = open('Instructions.csv')
for x in range(195):
    instruction = file.readline()
    print(f"'{instruction.strip()}':{x},")
