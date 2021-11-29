;CPU-16 "Hello, world!" demo
	ORG $F000
.hello 
	dw 'Hello\, world!\nI am an ATLAS CPU-16 computer!\nI was designed and progrmmed by Hayden B.'
	dw 'This program was written in the custom CPU-16 cross-assembler.\n\nI am somewhat based off the mc68000 CPU\, having been designed around'
	dw '8 equally-powerful data registers\, and a very orthagonal CISC instruction set.'
	dw 'Alright\, time to go. I was nice meeting you!' 

	ORG $E000
	MOV #hello,D0
.write 
	MOV (D0)+,$C000
	CMP #0,(D0)
	BNE write
	HLT
	
	ORG $FFFD
	MOV $F,$E000