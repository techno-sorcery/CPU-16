;ATLAS Machine Code Monitor

;Definitions
org $FEEE
.splash
	dw 'ATLAS Machine Code Monitor 16\n(c)2021 ATLAS Digital Systems\, Hayden Buscher\n\0'
.hexTable
	dw 0,1,2,3,4,5,6,7,8,9,$A,$B,$C,$D,$E
	
	ORG $E000
	MOV #splash,D0
.write 
	MOV (D0)+,$C000
	CMP #0,(D0)
	BNE write
	HLT
	
	ORG $FFFF
	dw $E000