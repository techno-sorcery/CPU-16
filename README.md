# CPU-16
NOTE: THIS USED TO BE AN 8-BIT COMPUTER. I HAVE SINCE REVISED THE DESIGN!


My YouTube account is [here](https://www.youtube.com/channel/UC0kihtgYtJHA7ZHQloiz2jA), I'll be regularly posting progress videos to it.

The CPU-16, from Atlas Digital Industries, is a 16-bit CISC minicomputer based around the 74LS181 ALU. The design is somewhat inspired by the Motorola 68000.

Eight general-purpose registers are supplied for the user (D0-D7), which are adressable within the instruction word. Any register can be used with any supported addressing mode. Also provided are a 16-bit stack pointer and a 16-bit program counter.

The instruction set very orthagonal, allowing the user to perform arithmetic operations between any of the general-purpose registers. Multiple addressing modes are supported, including immediate, direct, dirrect + offset, indirect register + offset, post incremented/decremented indirect X/Y + offset, and incremented/decremented stack.

Up to 64K of memory can be accessed by the computer at once, as it has a 16-bit wide address bus. For the sake of simplicity, it will (for now) feature a flat memory map with the first 48k delegated to the RAM, the next 8k delegated to device IO, and the final 8k delegated to ROM

The instruction set includes a variety of different conditional branching instructions, making use of all addressing modes. They test for four flag values: negative, zero, overflow, and carry.

The architecture includes a single internal masked interrupt line and, with additional support hardware, 8 individually maskable interrupts. It also is capable of halting and engaging in DMA.

Although I'm a believer in the RISC way of doing things, I wanted to make a microcoded CISC CPU this time around to make programming easier, and so I could save on RAM space. The control signals for the register loads and bus outputs are encoded and demultiplexed. Although this somewhat slows things down and increases the amount of support logic needed, it reduces the number of microcode EPROMS needed down to only six. 

A two-phase clock is used in order to avoid clock skew. The microcode flip-flops are loaded on the first phase, and all other synchronous chips are clocked on the second. A limited fetch-cycle overlap pipeline is supported on certain instructions.

A paging unit and modifications to add permission levels are in the works. However, they won't be realized until I've finished building the base system

![cpu8 drawio](https://user-images.githubusercontent.com/83188735/142703821-ef99d777-590d-48bb-9fa6-9236f5234404.png)


# Construction

A variety of 74LS series TTL chips will be used, including the 74LS181, 74LS151, 74LS173, 74LS245, 74LS169, 74LS08, 74LS00, 74LS373, 74LS74, 74LS32, 74LS283, and 74LS04.

The computer will be built onto 9 18x25cm perfboards, which will be plugged into a custom backplane with two 2x40-pin connectors per card.

The case will probably be custom built. As of now, I want it to include a front panel and enough room to fit all nine cards and a fan.


# Simulator

I've developed a simulation of the CPU-16 in H. Neemann's excellent logical simulator, Digital. It has helped me develop microcode, test new concepts, and fix issues while waiting to gradually purchase the parts that I need. You can download it from this repo, and try it out for yourself. It's able to run at a cool ~500kHz on my i7 8700k PC, which I believe is the upper limit of Digital's speed.

![cpu16](https://user-images.githubusercontent.com/83188735/124211584-342f3c00-daa2-11eb-92ee-952e7c71888f.PNG)



# Microassembler

I made a quick-and-dirty microassembler in C#. All that it does is generate a hex file from instruction, interrupt, and conditional tables. It's not very fast and could, without a doubt, be improved. However, I don't really feel like messing with it since it works just fine, and I'd rather use my time to work on writing microinstructions.

![microcode](https://user-images.githubusercontent.com/83188735/120169750-1f1a7100-c1b5-11eb-83d4-35332b8ff821.PNG)


# Assembler

I've already started thinking about how I'm going to make an assembler, but I still have a bit of reading to do on the subject.
