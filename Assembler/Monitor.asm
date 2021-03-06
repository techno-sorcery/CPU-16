;ATLAS Machine Code Monitor

;Definitions
	ORG $FFFF
	dw $E000
	org $FD00
.splash
	dw 'ATLAS Machine Code Monitor 16\n(c)2021 ATLAS Digital Systems\, Hayden Buscher\n\n\0'
.prompt
	dw '>> \0'
.syntaxError
	dw 'Syntax error\n\0'
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
	org $C000
.devKey
	org $01FE
.wrPos
	org $01FF
.rdPos
	org $0200
.keyStart
	org $02FF
.keyEnd
	org $0300
.cmdBuffer
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	init
;	Program initialization
;	Parameters:
;		None
;	Modifies: SP, $1, STAT 
;	LNK Offset: 0
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ORG $E000
.init
	;Init stack & vectors
	MOV #$C000,SP
	MOV #srKeyStore,1
	;Generate splash screen
	PSH #splash
	JSR srStrTermWord
	ADD #1,SP
	;Initialize status register
	ORT #%1111111100000000
.main
	MOV #'>',devTerm
	JSR getInput
	LNK D7,#0
	PSH #keyStart
	JSR srStringParse
	ULNK D7
	LNK D7,#0
	PSH #syntaxError
	JSR srStrTermWord
	ULNK D7
	JMP main
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	getInput
;	Read & handle input from key buffer
;	Parameters:
;		None
;	Modifies: D0, D1, wrPos, rdPos, (wrPos)
;	LNK Offset: 0
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.getInput
	;Initialize key buffer and cursor position
	MOV #0,D1
	MOV #keyStart,wrPos
	MOV #keyStart,rdPos
.LOC_getInput_readKey
	;Read from key buffer
	CMP wrPos,rdPos
	BIE LOC_getInput_readKey
	PSH D1
	JSR srKeyRead
	POP D1
	;Check if control char
	CMP #31,D0
	BIC LOC_getInput_noCTRL
	;Check if enter
	CMP #10,D0
	BIE LOC_getInput_enter
	;Check if backspace
	CMP #8,D0
	BNE LOC_getInput_readKey
	;Check if null
	CMP #0,D1
	BNE LOC_getInput_decCursor
	JMP LOC_getInput_readKey
.LOC_getInput_decCursor
	DEC D1
	MOV #8,devTerm
	JMP LOC_getInput_readKey
.LOC_getInput_noCTRL
	MOV D0,devTerm
	INC D1
	JMP LOC_getInput_readKey
.LOC_getInput_enter
	ANT #%100000000000000
	MOV D0,devTerm
	MOV rdPos,D0
	DEC D0
	MOV #0,(D0)
	RTS
	

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	mDump
;	Dumps memory from p1-p2 to terminal
;	Parameters:
;		
;	Modifies:
;	LNK Offset: 0
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
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
; 	Parameters: 
;		
;	Modifies:
;	LNK Offset: 0
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
;	Parameters:
;		
;	Modifies: 
;	LNK Offset: 0
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
;	Parameters: 
;		-1(BP): String start address
;	Modifies: D0, devTerm
;	LNK Offset: 0
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srStrTermWord
	POP D0
.LOC_StrTermWordX
	MOV (D0)+,devTerm
	CMP #0,(D0)
	BNE LOC_StrTermWordX
	RTS
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srKeyStore
;	Stores key input to the keybuffer
;	Parameters:
;		None
;	Modifies: D0, wrPos, (wrPos)
;	LNK Offset: 0
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
;	Stores character from key buffer to register D0
;	Parameters:
;		None
;	Modifies: D0, D1, rdPos
;	LNK Offset: 0
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srKeyRead
	ANT #%100000000000000
	MOV rdPos,D1
	MOV (D1),D0
	INC D1
	CMP #keyEnd,D1
	BNE LOC_KeyRead_End
	MOV #keyStart,D1
.LOC_KeyRead_End
	MOV D1,rdPos
	RTS
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srStringParse
;	Parses string, accounting for control characters
;	Parameters:
;		-1(BP): String start address
;	Modifies: D0, D1, (-1(BP))
;	LNK Offset: 0
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srStringParse
	PSH D2
	;Read
	MOV -1(D7),D0
	;Write
	MOV -1(D7),D1
.LOC_StringParse_X
	MOV (D0),D2
	CMP #31,D2
	BIC LOC_StringParse_write
	CMP #0,D2
	BIE LOC_StringParse_exit
	CMP #8,D2
	BIE LOC_StringParse_bkSpace
	JMP LOC_StringParse_exit
.LOC_StringParse_write
	MOV D2,(D1)+
.LOC_StringParse_incRead
	INC D0
	JMP LOC_StringParse_X
.LOC_StringParse_exit
	MOV #0,(D1)
	POP D2
	RTS
.LOC_StringParse_bkSpace
	CMP -1(D7),D1
	BIE LOC_StringParse_incRead
	DEC D1
	JMP LOC_StringParse_incRead
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;	srStringSplit
;	Program initialization
;	Parameters:
;		-1(BP): String start address
;		-2(BP): Separator character
;		-3(BP): String index number
;	Modifies: SP, $1, STAT 
;	LNK Offset: -1
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
.srStringSplit
	PSH D2
	;String address
	MOV -1(D7),D0
	PSH D0
	;Index number
	MOV #0,D1
.LOC_StringSplit_X
	MOV (D0),D2
	CMP -2(D7),D2
	BNE LOC_StringSplit_inc
	CMP -3(D7),D1
	BIE LOC_StringSplit_exit
	
.LOC_StringSplit_inc

.LOC_StringSplit_exit
	POP D0