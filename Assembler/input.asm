;CPU-16 Typewriter
	ORG $FEEE
.welcome
	dw 'ATLAS CPU-16 Typewriter'

	ORG $E000
	MOV #'e',$c000
.key 
	MOV $C001,$C000
	JMP key
	
	ORG $FFFD
	MOV $F,$E000