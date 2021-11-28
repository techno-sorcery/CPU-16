;CPU-16 "Hello, world!" demo
	ORG $FEEE
	dw $4F,%111,44,'a'

	ORG $E000
	MOV #$FEEE,D0
.write 
	MOV (D0)+,$C000
	CMP #0,(D0)
	BNE write
	HLT
	
	ORG $FFFD
	MOV $F,$E000