Module Module1

    Sub Main()

        'quesInput, reads users equation from the console as a string
        'inputArray, quesInput gets broken up into array
        'isNum, bool to check to pop or push to stack
        'calcStack, stack for storing/calulating equation
        'calcInt1, for popped int
        'calcInt2, for Popped int
        'answer, for storing current total
        'i, simple counter
        Dim quesInput As String
        Dim inputArray() As String
        Dim isNum As Boolean
        Dim calcStack As New Stack()
        Dim calcInt1 As Double
        Dim calcInt2 As Double
        Dim answer As Double


        'reads users equation from the console, breaks read string into induvidual terms in array 
        Console.Write("Enter your question (make sure you use spaces!): ")
        quesInput = Console.ReadLine()
        inputArray = Split(quesInput)


        'main calculating algorithm. If rerm is numeric, push to stack, if term is operator, pop apropriate numerics, preform operation, then push back to calcStack. If equation constructed correctly, then the final answer will be only item on stack after loop.
        For Each term As String In inputArray

            'checks if term is numeric, stores as bool in isNum
            isNum = IsNumeric(term)

            'If numeric push to calcStack, if not term is an operator so pop and calculate
            If isNum = True Then

                'push term to calcStack
                calcStack.Push(term)



                'if term is ^ pop 1 then square, push result
            ElseIf term = "^" Then

                calcInt1 = calcStack.Pop()
                answer = calcInt1 * calcInt1
                calcStack.Push(answer)


                'if term is "sqrt" pop 1, squareroot, then push result, returns imaginary numbers as rounded
            ElseIf term = "sqrt" Then

                calcInt1 = calcStack.Pop()
                answer = Math.Sqrt(calcInt1)
                calcStack.Push(answer)

            Else

                'pop 2 numerics from stack
                calcInt1 = calcStack.Pop()
                calcInt2 = calcStack.Pop()

                'select case, to select operation to preform on calcInt1 & 2, if + add, if * multiply, etc. Then push result back to calcStack
                Select Case term

                    Case "*"

                        answer = calcInt1 * calcInt2
                        calcStack.Push(answer)

                    Case "/"

                        answer = calcInt1 / calcInt2
                        calcStack.Push(answer)

                    Case "+"

                        answer = calcInt1 + calcInt2
                        calcStack.Push(answer)

                    Case "-"

                        answer = calcInt1 - calcInt2
                        calcStack.Push(answer)

                End Select

            End If

        Next

        'if equation is constructed correctly, final answer will be all that is left on the stack, print remaining value to console.
        Console.Clear()
        PrintValues(calcStack)

        Console.ReadLine()


    End Sub

    Sub PrintValues(myCollection As IEnumerable)
            Dim obj As [Object]
            For Each obj In myCollection
                Console.Write("    {0}", obj)
            Next obj
            Console.WriteLine()
        End Sub

    End Module
