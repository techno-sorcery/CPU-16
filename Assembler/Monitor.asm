;ATLAS Machine Code Monitor

;Definitions
	ORG $FFFF
	dw $E000
	org $FD00
.splash
	dw 'ATLAS Machine Code Monitor 16\n(c)2021 ATLAS Digital Systems\, Hayden Buscher\n\n\0'
.prompt
	dw '>> \0'
.hexTable
	dw '0123456789ABCDEF\0'
.asciiTable
	dw '................................'
	dw ' !"#$%&\'()*+\,-./0123456789:;<='
	dw '>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\'
	dw ']^_`abcdefghijklmnopqrstuvwxyz{|'
	dw '}~..............................'
	dw '................................'
	dw '................................'
	dw '................................'
	dw '...\0'
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
.init
	ORG $E000
	;Init stack & key buffer
	LDS #$C000
	MOV #keyStart,wrPos
	MOV #keyStart,rdPos
	MOV #srKeyStore,1
	;Generate splash screen
	LNK D7,#0
	PSH #splash
	JSR srStrTermWord
	ULNK D7
	;Init status reg
	MOV #%0111111100000000,D0
	LDT D0
	;Display prompt
	LNK D7,#0
	PSH #prompt
	JSR srStrTermWord
	ULNK D7
	;Read from key buffer
.getInput
	CMP wrPos,rdPos
	BIE getInput
	JSR srKeyRead
	MOV D0,devTerm
	JMP getInput
	
;	MOV #$FD00,D5
;	MOV #$FFFF,D6
;	INC D6
;	JSR mDump

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	mDump
;	Dumps memory from p1-p2 to terminal
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
	MOV -1(D7),D0
.LOC_StrTermWordX
	MOV (D0)+,devTerm
	CMP #0,(D0)
	BNE LOC_StrTermWordX
	RTS
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srKeyStore
;	Stores key input to the keybuffer
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srKeyStore
    MOV wrPos,D0
    MOV devKey,(D0)
    INC D0
    CMP #keyEnd,D0
    BNE LOC_KeyStore_End
    MOV #keyStart,D0
.LOC_KeyStore_End
    MOV D0,wrPos
    RTS
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srKeyRead
;	Stores character from key buffer to register D6
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srKeyRead
	MOV rdPos,D1
	MOV (D1),D0
	INC D1
	CMP #keyEnd,D1
	BNE LOC_KeyRead_End
	MOV #keyStart,D1
.LOC_KeyRead_End
	MOV D1,rdPos
	RTS
	
	