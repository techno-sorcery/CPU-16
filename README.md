# CPU-16
NOTE: THIS USED TO BE AN 8-BIT COMPUTER. I HAVE SINCE REVISED THE DESIGN!


My YouTube account is [here](https://www.youtube.com/channel/UC0kihtgYtJHA7ZHQloiz2jA), I'll be regularly posting progress videos to it.

The CPU-16, from Atlas Digital Industries, is an 16-bit CISC minicomputer based around the 74LS181 ALU.

Four general-purpose registers are provided to the programmer, including the accumulator. Two index registers are also provided, along with a 16-bit stack pointerstack pointer. 

The instruction set supports a multitude of addressing modes including immediate, direct, indirect, relative, direct indexed relative, and indirect indexed relative. Fast relative addressing is enabled through the inclusion of a memory address adder, separate to the main ALU.

Up to 64K of memory can be accessed by the computer at once, as it has a 16-bit wide address bus. For the sake of simplicity, it will (for now) feature a flat memory map with the first 48k delegated to the RAM, the next 8k delegated to device IO, and the final 8k delegated to ROM

The instruction set includes a variety of different conditional branching instructions, all making use of relative addressing. They test for four flag values: negative, zero, overflow, and carry.

The architecture includes a single internal masked interrupt line and, with additional support hardware, 16 individually maskable interrupts. It also is capable of halting and engaging in DMA.

Although I'm a believer in the RISC way of doing things, I wanted to make a microcoded CISC CPU this time around to make programming easier, and so I could save on RAM space. The control signals for the register loads and bus outputs are encoded and demultiplexed. Although this somewhat slows things down and increases the amount of support logic needed, it reduces the number of microcode EPROMS needed down to only six. 

A two-phase clock is used in order to avoid clock skew. The microcode flip-flops are loaded on the first phase, and all other synchronous chips are clocked on the second. A limited fetch-cycle overlap pipeline is supported, but its not yet used on any instructions.

![cpu8](https://user-images.githubusercontent.com/83188735/124211509-0e099c00-daa2-11eb-8a8b-396c0b3bc76e.png)


# Construction

A variety of 74LS series TTL chips will be used, including the 74LS181, 74LS151, 74LS173, 74LS245, 74LS169, 74LS08, 74LS00, 74LS373, 74LS74, 74LS32, 74LS283, and 74LS04.

The computer will be built onto 9 18x25cm perfboards, which will be plugged into a custom backplane with two 2x40-pin connectors per card.

The case will probably be custom built. If thermals end up being an issue, I'll probably put the CPU backplane and cards in the it and chuck in a couple fans. Otherwise, I'd like for everything to sit on top of the case.


# Simulator

I've developed a simulation of the CPU-16 in H. Neemann's excellent logical simulator, Digital. It has helped me develop microcode, test new concepts, and fix issues while waiting to gradually purchase the parts that I need. You can download it from this repo, and try it out for yourself. It's able to run at a cool ~500kHz on my i7 8700k PC, which I believe is the upper limit of Digital's speed.

![cpu16](https://user-images.githubusercontent.com/83188735/124211584-342f3c00-daa2-11eb-92ee-952e7c71888f.PNG)



# Microassembler

I made a quick-and-dirty microassembler in C#. All that it does is generate a hex file from instruction, interrupt, and conditional tables. It's not very fast and could, without a doubt, be improved. However, I don't really feel like messing with it since it works just fine, and I'd rather use my time to work on writing microinstructions.

![microcode](https://user-images.githubusercontent.com/83188735/120169750-1f1a7100-c1b5-11eb-83d4-35332b8ff821.PNG)


# Assembler

I've already started thinking about how I'm going to make an assembler, but I still have a bit of reading to do on the subject.
