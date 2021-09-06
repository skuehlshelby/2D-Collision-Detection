Public Structure Point2DF
    Implements IEquatable(Of Point2DF)
    Implements ICloneable

    Sub New(x As Single, y As Single)
        Me.X = x
        Me.Y = y
    End Sub

    Public ReadOnly Property X As Single

    Public ReadOnly Property Y As Single

    Public Function Max() As Single
        Return Math.Max(X, Y)
    End Function

    Public Function Max(other As Point2DF) As Point2DF
        Return New Point2DF(Math.Max(X, other.X), Math.Max(Y, other.Y))
    End Function

    Public Function Min() As Single
        Return Math.Min(X, Y)
    End Function

    Public Function Min(other As Point2DF) As Point2DF
        Return New Point2DF(Math.Min(X, other.X), Math.Min(Y, other.Y))
    End Function

    Public Function Abs() As Point2DF
        Return New Point2DF(Math.Abs(X), Math.Abs(Y))
    End Function

    Public Function Lerp(other As Point2DF, weight As Single) As Point2DF
        Return ((1.0F - weight) * Me) + (weight * other)
    End Function

    Public Function Distance(other As Point2DF) As Double
        Dim xDistance As Single = Math.Abs(X - other.X)
        Dim yDistance As Single = Math.Abs(Y - other.Y)
        Return Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance))
    End Function

    Public Function Above(line As LineF) As Boolean
        Throw New NotImplementedException
    End Function

    Public Function Below(line As LineF) As Boolean
        Throw New NotImplementedException
    End Function

    Public Shared Operator +(left As Point2DF, right As Vector2DF) As Point2DF
        Throw New NotImplementedException()
    End Operator

    Public Shared Operator +(left As Point2DF, right As Point2DF) As Point2DF
        Return New Point2DF(left.X + right.X, left.Y + right.Y)
    End Operator

    Public Shared Operator -(left As Point2DF, right As Vector2DF) As Point2DF
        Throw New NotImplementedException()
    End Operator

    Public Shared Operator -(left As Point2DF, right As Point2DF) As Vector2DF
        Return New Vector2DF(right.X - left.X, right.Y - left.Y)
    End Operator

    Public Shared Operator *(left As Point2DF, right As Single) As Point2DF
        Return New Point2DF(left.X * right, left.Y * right)
    End Operator

    Public Shared Operator *(left As Single, right As Point2DF) As Point2DF
        Return New Point2DF(left * right.X, left * right.Y)
    End Operator

    Public Shared Operator =(left As Point2DF, right As Point2DF) As Boolean
        Return left.Equals(right)
    End Operator

    Public Shared Operator <>(left As Point2DF, right As Point2DF) As Boolean
        Return Not (left = right)
    End Operator

    Public Shared Widening Operator CType(tuple As ValueTuple(Of Single, Single)) As Point2DF
        Return New Point2DF(tuple.Item1, tuple.Item2)
    End Operator

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Point2DF AndAlso Equals(DirectCast(obj, Point2DF))
    End Function

    Public Overloads Function Equals(other As Point2DF) As Boolean Implements IEquatable(Of Point2DF).Equals
        Return Math.Abs(other.X - X) < 0.01 AndAlso Math.Abs(other.Y - Y) < 0.01
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (X, Y).GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return $"({Math.Round(X, 2)}, {Math.Round(Y, 2)})"
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New Point2DF(X, Y)
    End Function

End Structure