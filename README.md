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

Although microcode is mostly an obsolete relic of old, I decided to use it as I wanted to have experience with writing a microassembler. In a tradeoff between speed and space/complexity,
the decoder uses several demultiplexers and only six microcode EPROMS.

A two-phase clock is used in order to avoid clock skew. The microcode flip-flops are loaded on the first phase, and all other synchronous chips are clocked on the second. A limited
fetch-cycle overlap pipeline is supported, although it is not yet used on any instructions.
