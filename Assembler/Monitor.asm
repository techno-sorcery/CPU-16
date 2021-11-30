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
	org $C001
.devKey
	org $01FE
.wrPos
	org $01FF
.rdPos
	org $0200
.keyStart
	org $02FF
.keyEnd
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	init
;	Program initialization
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ORG $E000			
	MOV #keyStart,wrPos
	MOV #keyStart,rdPos
;	MOV #srKeyStore,1
;	LDS #$BFFF
;	MOV #%0111111100000000,D7
;	LDT D7
;	MOV #splash,D7
;	JSR srStrTermWord
	MOV #'>',devTerm
.getInput
	CMP wrPos,rdPos
	BIE getInput
;	JSR srKeyRead
	MOV D7,devTerm
	JMP getInput
	
;	MOV #$FD00,D5
;	MOV #$FFFF,D6
;	INC D6
;	JSR mDump

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	mDump
;	Dumps memory from (D5)-(D6) to terminal
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ORG $F000
.mDump
	PSH D4
	PSH D7
.LOC_mDump_Y
	MOV #0,D4
	MOV D5,D7
	JSR srBinHexTerm
	MOV #':',devTerm
	MOV #' ',devTerm
	PSH D5
.LOC_mDump_X
	MOV (D5),D7
	JSR srBinHexTerm
	MOV #' ',devTerm
	INC D4
	INC D5 
	CMP #8,D4
	BNE LOC_mDump_X
	MOV #' ',devTerm
	POP D5
	MOV #0,D4
.LOC_mDump_Z
	MOV (D5),D7
	JSR srBinAsciiTerm
	MOV #' ',devTerm
	INC D4
	INC D5
	CMP #8,D4
	BNE LOC_mDump_Z
	MOV #'\n',devTerm
	CMP D5,D6
	BNE LOC_mDump_Y
	POP D4
	POP D7
	HLT
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srBinHexTerm
;	Convert binary word (D7) to ascii hex, and output to terminal	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
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

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srBinAsciiTerm
;	Convert binary word (D7) to ascii, and output to terminal	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
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

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srStrTermWord
;	Output ascii-encoded string @ (D7) to terminal
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srStrTermWord
	PSH D7
.LOC_StrTermWordX
	MOV (D7)+,devTerm
	CMP #0,(D7)
	BNE LOC_StrTermWordX
	POP D7
	RTS
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srKeyStore
;	Stores key input to the keybuffer
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srKeyStore
	PSH D7
	MOV wrPos,D7
	MOV devKey,(D7)
	INC D7
	CMP #keyEnd,D7
	BNE LOC_KeyStore_End
	MOV #0,D7
.LOC_KeyStore_End
	MOV D7,wrPos
	POP D7
	RTS
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srKeyRead
;	Stores character from key buffer to register D6
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srKeyRead
	PSH D7
	MOV rdPos,D7
	MOV (D7),D6
	INC D7
	CMP #keyEnd,D7
	BNE LOC_KeyRead_End
	MOV #0,D7
.LOC_KeyRead_End
	MOV D7,rdPos
	POP D7
	RTS
	
	