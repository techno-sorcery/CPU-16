;Hello, this is a comment!
	ORG $E000
	MOV #2,d0
	MOV $123,d2
	MOV $95(PC),d5
	ORG $1
.start
	MOV (d4),(D6)+
	MOV $4F(d3),d7
	MOV d3,$FF42