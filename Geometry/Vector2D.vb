Public Structure Vector2D

    Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
        Magnitude = Math.Sqrt((x * x) + (y * y))
    End Sub

    ''' <summary>
    ''' The X component of this vector.
    ''' </summary>
    Public ReadOnly Property X As Integer

    ''' <summary>
    ''' The Y component of this vector.
    ''' </summary>
    Public ReadOnly Property Y As Integer

    ''' <summary>
    ''' The magnitude of this vector.
    ''' </summary>
    Public ReadOnly Property Magnitude As Double

    Public Function Abs() As Vector2D
        Return New Vector2D(If(X < 0, X * -1, X), If(Y < 0, Y * -1, Y))
    End Function

    Public Function Dot(other As Vector2D) As Integer
        Return (X * other.X) + (Y * other.Y)
    End Function

    Public Function AbsDot(other As Vector2D) As Integer
        Return Math.Abs(Dot(other))
    End Function

    Public Function Normalize() As Vector2D
        Return Me / Magnitude
    End Function

    Public Shared Operator +(left As Vector2D, right As Vector2D) As Vector2D
        Return new Vector2D(left.X + right.X, left.Y + right.Y)
    End Operator

    Public Shared Operator -(left As Vector2D, right As Vector2D) As Vector2D
        Return new Vector2D(left.X - right.X, left.Y - right.Y)
    End Operator

    Public Shared Operator *(left As Vector2D, right As Integer) As Vector2D
        Return New Vector2D(left.X * right, left.Y * right)
    End Operator

    Public Shared Operator /(left As Vector2D, right As Integer) As Vector2D
        Dim inverse As Single = 1.0F / right
        Return New Vector2D(CInt(left.X * inverse), CInt(left.Y * inverse))
    End Operator

    Public Shared Operator /(left As Vector2D, right As Double) As Vector2D
        Dim inverse As Double = 1.0F / right
        Return New Vector2D(CInt(left.X * inverse), CInt(left.Y * inverse))
    End Operator

    Public Shared Operator -(vec As Vector2D) As Vector2D
        Return New Vector2D(-vec.X, -vec.Y)
    End Operator

End Structure