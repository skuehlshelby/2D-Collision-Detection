Public Structure Point2D
    Implements IEquatable(Of Point2D)

    Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub

    Public ReadOnly Property X As Integer

    Public ReadOnly Property Y As Integer

    Public Shared Function Max(left As Point2D, right As Point2D) As Point2D
        Return New Point2D(If(left.X < right.X, right.X, left.X), If(left.Y < right.Y, right.Y, left.Y))
    End Function

    Public Shared Function Min(left As Point2D, right As Point2D) As Point2D
        Return New Point2D(If(left.X < right.X, left.X, right.X), If(left.Y < right.Y, left.Y, right.Y))
    End Function

    Public Shared Function Abs(point As Point2D) As Point2D
        Return New Point2D(If(point.X < 0, point.X * -1, point.X), If(point.Y < 0, point.Y * -1, point.Y))
    End Function

    Public Shared Function LinearlyInterpolate(start As Point2D, finish As Point2D, weight As Single) As Point2D
        Return ((1.0 - weight) * start) + (weight * finish)
    End Function

    Public Shared Operator +(left As Point2D, right As Vector2D) As Point2D
        Throw New NotImplementedException()
    End Operator

    Public Shared Operator +(left As Point2D, right As Point2D) As Point2D
        Return New Point2D(left.X + right.X, left.Y + right.Y)
    End Operator

    Public Shared Operator -(left As Point2D, right As Vector2D) As Point2D
        Throw New NotImplementedException()
    End Operator

    Public Shared Operator -(left As Point2D, right As Point2D) As Vector2D
        Throw New NotImplementedException()
    End Operator

    Public Shared Operator *(left As Point2D, right As Single) As Point2D
        Return New Point2D(CInt(left.X * right), CInt(left.Y * right))
    End Operator

    Public Shared Operator *(left As Point2D, right As Double) As Point2D
        Return New Point2D(CInt(left.X * right), CInt(left.Y * right))
    End Operator

    Public Shared Operator *(left As Single, right As Point2D) As Point2D
        Return New Point2D(CInt(left * right.X), CInt(left * right.Y))
    End Operator

    Public Shared Operator *(left As Double, right As Point2D) As Point2D
        Return New Point2D(CInt(left * right.X), CInt(left * right.Y))
    End Operator

    Public Overloads Function Equals(other As Point2D) As Boolean Implements IEquatable(Of Point2D).Equals
        Return other.X = X AndAlso other.Y = Y
    End Function

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Point2D AndAlso Equals(DirectCast(obj, Point2D))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (X, Y).GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return $"({X}, {Y})"
    End Function

End Structure