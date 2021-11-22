;Hello, this is a comment!
	ORG $E000
.test
	MOV #44,d0
	MOV $123,d2
	MOV $95(PC),d5
	ORG $1
.start MOV $8,$5
	MOV (d4),(D6)+
	MOV $2(d3),d7
	MOV d3,$FF42
	