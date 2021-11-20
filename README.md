# CPU-16
MAJOR REVISION - PLEASE READ!

My YouTube account is [here](https://www.youtube.com/channel/UC0kihtgYtJHA7ZHQloiz2jA), I'll be regularly posting progress videos to it.

The CPU-16, from Atlas Digital Industries, is a 16-bit CISC minicomputer based around the 74LS181 ALU. Its custom architecture is somewhat inspired by the Motorola 68000.

Eight general-purpose registers are at the user's disposal (D0-D7). As they are addressed within the instruction word, any data register can be used as an opperand for supported addressing modes. Also provided are a 16-bit stack pointer and a 16-bit program counter.

The instruction set is extremely orthagonal, allowing the user to use any set of addressing modes with (nearly) any instruction. Supported addressing modes include register, direct, program counter relative, register indirect, register indirect + offset, register indirect with post-increment, register indirect with pre-decrement, and immediate. In addition, special "quick" instructions can store an immediate from 0-7 in the instruction word. Because they are only a single word long, these instructions save significant time and memory.

As the computer's address bus is 16-bits wide, it can directly address up to 64K words at once. For the sake of simplicity, it will (for now) feature a flat memory map with the first 48k delegated to the RAM, the next 8k delegated to device IO, and the final 8k delegated to ROM

The instruction set includes a variety of different conditional branching instructions, which make use of the program counter relative addressing mode. They test for each of the arithmetic flags: negative, zero, overflow, and carry.

The architecture includes a single internal masked interrupt line and, with additional support hardware, eight individually maskable interrupts. It can also be halted both internally and externally, allowing for direct memory access.

Although CISC architectures tend to get a bad-rap these days, I felt that a well-designed one would be a perfect fit for the CPU-16. Not only would going with a microcoded CISC architecture increase my instruction density and thus save memory, but it would also let me use a memory word-size of 16-bits (versus the 48-bit microcode width).

A two-phase clock is used in order to avoid clock skew. The microcode flip-flops are loaded on the first phase, and all other synchronous chips are clocked on the second. 

A paging unit and modifications to add permission levels are in the works. However, they won't be realized until I've finished building the base system

![cpu8 drawio](https://user-images.githubusercontent.com/83188735/142703821-ef99d777-590d-48bb-9fa6-9236f5234404.png)


# Construction

A variety of 74LS series TTL chips will be used, including the 74LS181, 74LS151, 74LS173, 74LS245, 74LS169, 74LS08, 74LS00, 74LS373, 74LS74, 74LS32, 74LS283, and 74LS04.

The computer will be built onto 9 18x25cm perfboards, which will be plugged into a custom backplane with two 2x40-pin connectors per card.

The case will probably be custom built. As of now, I want it to include a front panel and enough room to fit all nine cards and a fan.


# Simulator

I've developed a simulation of the CPU-16 in H. Neemann's excellent logical simulator, Digital. It has helped me develop microcode, test new concepts, and fix issues while waiting to gradually purchase the parts that I need. You can download it from this repo, and try it out for yourself. It's able to run at a cool ~500kHz on my i7 8700k PC, which I believe is the upper limit of the simulator's speed.

![cpu16](https://user-images.githubusercontent.com/83188735/124211584-342f3c00-daa2-11eb-92ee-952e7c71888f.PNG)



# Microassembler

I made a quick-and-dirty microassembler in C#. All that it does is generate a hex file from instruction, interrupt, and conditional tables. It's not very fast and could, without a doubt, be improved. However, I don't really feel like messing with it since it works just fine, and I'd rather use my time to work on writing microinstructions.

![microcode](https://user-images.githubusercontent.com/83188735/120169750-1f1a7100-c1b5-11eb-83d4-35332b8ff821.PNG)


# Assembler

An assembler is currently being worked on, though it isn't finished yet.
