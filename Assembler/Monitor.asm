;ATLAS Machine Code Monitor

;Definitions
	org $FEEE
.splash
	dw 'ATLAS Machine Code Monitor 16\n(c)2021 ATLAS Digital Systems\, Hayden Buscher\n\0'
.hexTable
	dw '0123456789ABCDEF'
	org $C000
.devTerm
	
	ORG $E000
;	MOV #splash,D0
;.write 
;	MOV (D0)+,devTerm
;	CMP #0,(D0)
;	BNE write
	MOV #$E000,D7
	JMP address
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	
;	Convert binary word to ascii hex, and output to terminal	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.address
	MOV D7,D6
	SWP D6
	RSH D6
	RSH D6
	RSH D6
	RSH D6
	AND #%1111,D6
	MOV hexTable(D6),devTerm
	MOV D7,D6
	SWP D6
	AND #%1111,D6
	MOV hexTable(D6),devTerm
	MOV D7,D6
	RSH D6
	RSH D6
	RSH D6
	RSH D6
	AND #%1111,D6
	MOV hexTable(D6),devTerm
	MOV D7,D6
	AND #%1111,D6
	MOV hexTable(D6),devTerm
	MOV #'\n',devTerm
	INC D7
	CMP #$FFFF,D7
	BNE address
	HLT
	
	ORG $FFFF
	dw $E000