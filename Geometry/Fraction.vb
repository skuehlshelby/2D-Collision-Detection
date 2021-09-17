Public Structure Fraction
    Implements IEquatable(Of Fraction)

    Sub New(numerator As Single, denominator As Single)
        If numerator < 0 AndAlso denominator < 0 Then
            Me.Numerator = Math.Abs(numerator)
            Me.Denominator = Math.Abs(denominator)
        Else
            Me.Numerator = numerator
            Me.Denominator = denominator
        End If
    End Sub

    Public ReadOnly Property Numerator As Single

    Public ReadOnly Property Denominator As Single

    Public Function Reciprocal() As Fraction
        Return New Fraction(Denominator, Numerator)
    End Function

    Public Function ToDouble() As Double
        Return Numerator / Denominator
    End Function

    Public Function ToSingle() As Single
        Return Numerator / Denominator
    End Function

    Public Overrides Function ToString() As String
        Return $"{Math.Round(Numerator, 2)}/{Math.Round(Denominator, 2)}"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Fraction AndAlso Equals(DirectCast(obj, Fraction))
    End Function

    Public Overloads Function Equals(other As Fraction) As Boolean Implements IEquatable(Of Fraction).Equals
        Return Math.Abs(other.Numerator - Numerator) < 0.01 AndAlso Math.Abs(other.Denominator - Denominator) < 0.01
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (Numerator, Denominator).GetHashCode()
    End Function

    Public Shared Operator -(fraction As Fraction) As Fraction
        Return New Fraction(fraction.Numerator, -fraction.Denominator)
    End Operator

    Public Shared Operator *(left As Fraction, right As Single) As Fraction
        Return New Fraction(left.Numerator * right, left.Denominator)
    End Operator

    Public Shared Narrowing Operator CType(fraction As Fraction) As Double
        Return fraction.ToDouble()
    End Operator

    Public Shared Narrowing Operator CType(fraction As Fraction) As Single
        Return fraction.Numerator / fraction.Denominator
    End Operator
End Structure