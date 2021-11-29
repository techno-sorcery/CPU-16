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
	MOV #$E000,D6
.address
	MOV D6,D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	AND #%1111,D5
	MOV hexTable(D5),devTerm
	MOV D6,D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	AND #%1111,D5
	MOV hexTable(D5),devTerm
	MOV D6,D5
	RSH D5
	RSH D5
	RSH D5
	RSH D5
	AND #%1111,D5
	MOV hexTable(D5),devTerm
	MOV D6,D5
	AND #%1111,D5
	MOV hexTable(D5),devTerm
	MOV #'\n',devTerm
	INC D6
	CMP #$FFFF,D6
	BNE address
	HLT
	
	ORG $FFFF
	dw $E000