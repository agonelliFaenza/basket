Module Module1
    Public Function BCDconvert(s As String) As Byte
        Dim temp, temp1, temp2 As Byte
        Dim s1, s2 As String
        s1 = Right(s, 1)
        s2 = Left(s, 1)
        temp1 = Val(s1)
        temp2 = Val(s2)
        temp = temp1 + (temp2 * 16)


        BCDconvert = temp
    End Function
End Module
