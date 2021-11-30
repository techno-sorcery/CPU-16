;ATLAS Machine Code Monitor

;Definitions
	ORG $FFFF
	dw $E000
	org $FD00
.splash
	dw 'ATLAS Machine Code Monitor 16\n(c)2021 ATLAS Digital Systems\, Hayden Buscher\n\n\0'
.hexTable
	dw '0123456789ABCDEF'
.asciiTable
	dw '................................'
	dw ' !"#$%&\'()*+\,-./0123456789:;<='
	dw '>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\'
	dw ']^_`abcdefghijklmnopqrstuvwxyz{|'
	dw '}~..............................'
	dw '................................'
	dw '................................'
	dw '................................'
	dw '...'
	org $C000
.devTerm
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	init
;	Program initialization
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ORG $E000
	LDS #$BFFF
	MOV #splash,D7
	JSR srStrTerm
	MOV #$FD00,D5
	MOV #$FFFF,D6
	INC D6
	JSR mDump

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	mDump
;	Dumps memory from (D5)-(D6) to terminal
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.mDump
	PSH D4
	PSH D7
.mDumpY
	MOV #0,D4
	MOV D5,D7
	JSR srBinHexTerm
	MOV #':',devTerm
	MOV #' ',devTerm
	PSH D5
.mDumpX
	MOV (D5),D7
	JSR srBinHexTerm
	MOV #' ',devTerm
	INC D4
	INC D5 
	CMP #8,D4
	BNE mDumpX
	MOV #' ',devTerm
	POP D5
	MOV #0,D4
.mDumpZ
	MOV (D5),D7
	JSR srBinAsciiTerm
	INC D4
	INC D5
	CMP #8,D4
	BNE mDumpZ
	MOV #'\n',devTerm
	CMP D5,D6
	BNE mDumpY
	POP D4
	POP D7
	HLT
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srBinHexTerm
;	Convert binary word (D7) to ascii hex, and output to terminal	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ORG $F000
.srBinHexTerm
	PSH D6
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
	POP D6
	RTS

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srBinAsciiTerm
;	Convert binary word (D7) to ascii, and output to terminal	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srBinAsciiTerm
	PSH D6
	MOV D7,D6
	SWP D6
	AND #%11111111,D6
	MOV asciiTable(D6),devTerm
	MOV D7,D6
	AND #%11111111,D6
	MOV asciiTable(D6),devTerm
	POP D6
	RTS

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srStrTerm
;	Output ascii-encoded string @ (D7) to terminal
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srStrTerm
	PSH D7
.srStrTermX
	MOV (D7)+,devTerm
	CMP #0,(D7)
	BNE srStrTermX
	POP D7
	RTS