# CPU-8
The CPU-8, from Atlas Digital Industries, is an 8-bit CISC minicomputer based around the 74LS181 ALU.

Four general-purpose 8-bit registers are provided to the programmer, including the accumulator. Two of the registers, B and C, can be used as a 16-bit pair in a limited number of 
operations. Two 16-bit index registers are also provided, along with an 8-bit stack pointer. There are also two 16-bit temporary registers, which are only used by microinstructions.

The instruction set supports a multitude of addressing modes, including register, immediate, direct, direct relative, indirect, indexed relative direct, and indexed relative
indirect. Offsets for relative addressing modes are encoded as a signed 8-bit integer, allowing for values from -128 to 127.

Up to 64K of memory can be accessed by the computer at once, though it can access a multitude of different memory devices through a bank switching scheme. Requested wait states are
supported, allowing the computer to be clocked at a higher speed than its memory.

The instruction set includes a variety of different conditional branching instructions, all making use of direct relative addressing. They test for the six flag values: negative,
zero, overflow, carry, IX zero, and IY zero.

Two maskable interrupts (IRJ and IRK) are available, along with two non-maskable ones (RESET and NMI), direct memory access (used by the front panel), software breakpoints, and
a HALT state. In addition, DMA, RESET, NMI, IRJ, IRK, and HALT can all be invoked by peripheral devices.

Although I'm a believer in the RISC way of doing things, I wanted to make a microcoded CISC architecture this time around primarily because that's what pretty much all "old-school" computers were, and because I wanted machine code programming to be easy (maybe I'll make a RISC machine next time around...). The control signals for things like register loads and bus outputs are all encoded and demultiplexed. Although this somewhat slows things down (more gates and such), it reduces the number of microcode EPROMS needed down to six. 

A two-phase clock is used in order to avoid clock skew. The microcode flip-flops are loaded on the first phase, and all other synchronous chips are clocked on the second. A limited fetch-cycle overlap pipeline is supported, but its not yet used on any instructions.

![cpu8_arch](https://user-images.githubusercontent.com/83188735/120168086-57b94b00-c1b3-11eb-84ce-eec87e9da384.png)


# Construction

A variety of 74LS series TTL chips will be used, including the 74LS181, 74LS151, 74LS173, 74LS245, 74LS169, 74LS08, 74LS00, 74LS373, 74LS74, 74LS32, 74LS283, and 74LS04.

The computer will be built onto 8 to 10 18x25cm perfboards, which will be plugged into a custom backplane with two 2x40-pin connectors per card.

The case will probably be custom built. If thermals end up being an issue, I'll probably put the CPU backplane and cards in the it and chuck in a couple fans. Otherwise, I'd like for everything to sit on top of the case.


# Simulator

I've developed a simulation of the CPU-8 in H. Neemann's excellent logical simulator, Digital. It has helped me develop microcode, test new concepts, and fix issues while waiting to gradually purchase the parts that I need. You can download it from this repo, and try it out for yourself. It's able to run at a cool ~500kHz on my i7 8700k PC, which I believe is the upper limit of Digital's speed.

![simulator](https://user-images.githubusercontent.com/83188735/120168736-0e1d3000-c1b4-11eb-9012-773b9390b32b.PNG)


# Microassembler

I made a quick-and-dirty microassembler in C#. All that it does is generate a hex file from instruction, interrupt, and conditional tables. It's not very fast and could, without a doubt, be improved. However, I don't really feel like messing with it since it works just fine, and I'd rather use my time to work on writing microinstructions.

![microcode](https://user-images.githubusercontent.com/83188735/120169750-1f1a7100-c1b5-11eb-83d4-35332b8ff821.PNG)


# Assembler

I've already started thinking about how I'm going to make an assembler, but I still have a bit of reading to do on the subject.
