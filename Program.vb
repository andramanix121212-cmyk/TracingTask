Module Module1
    Sub Main()
        ' Memory array (addresses 0�99) 
        Dim Memory(99) As Integer

        ' Program Instructions (addresses 0�5) 
        ' Opcodes: 1 = LOAD, 2 = ADD, 3 = STORE, 4 = JUMP, 0 = HALT
        Memory(0) = 191   ' LOAD value at address 98 
        Memory(1) = 291   ' ADD value at address 91
        Memory(2) = 398   ' STORE result in address 98 
        Memory(3) = 400   ' JUMP to address 0 (loop) 
        Memory(4) = 0     ' HALT 

        ' Data values stored in high memory (addresses 90+) 
        Memory(91) = 5
        Memory(98) = 0    ' Storage location 

        ' Registers 
        Dim PC As Integer = 0
        Dim MAR As Integer = 0
        Dim MDR As Integer = 0
        Dim CIR As Integer = 0
        Dim ACC As Integer = 0

        Console.WriteLine("Tracing program...")
        Console.WriteLine("PC | MAR | MDR | CIR | ACC")

        Dim running As Boolean = True
        Dim stepCount As Integer = 0

        While running And stepCount < 10   ' limit to 10 steps for tracing 
            stepCount += 1

            ' FETCH 
            MAR = PC
            MDR = Memory(MAR)
            CIR = MDR
            PC += 1   ' increment PC 

            ' DECODE 
            Dim opcode As Integer = CIR \ 100
            Dim operand As Integer = CIR Mod 100

            ' EXECUTE 
            Select Case opcode
                Case 1 ' LOAD 
                    ACC = Memory(operand)
                Case 2 ' ADD 
                    ACC += Memory(operand)
                Case 3 ' STORE 
                    Memory(operand) = ACC
                Case 4 ' JUMP 
                    PC = operand
                Case 0 ' HALT 
                    running = False
            End Select

            ' OUTPUT REGISTERS FOR TRACING 
            Console.WriteLine($"{PC}  | {MAR}   | {MDR}   | {CIR}   | {ACC}")

        End While
        Console.WriteLine("Total:" & Memory(98))
        Console.WriteLine("Program finished.")
        Console.ReadLine()
    End Sub
End Module