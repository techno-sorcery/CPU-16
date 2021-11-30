;ATLAS Machine Code Monitor

;Definitions
	ORG $FFFF
	dw $E000

	ORG $E000
	LDS #6
	MOV #6,D0
.main
	JSR increment
	JMP main
	
.increment
	INC D0
	RTS