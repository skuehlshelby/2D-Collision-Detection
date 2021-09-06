Public Structure Vector2DF
    Implements IEquatable(Of Vector2DF)

    Sub New(x As Single, y As Single)
        Me.X = x
        Me.Y = y
        Magnitude = Math.Sqrt((x * x) + (y * y))
    End Sub

    ''' <summary>
    ''' The X component of this vector.
    ''' </summary>
    Public ReadOnly Property X As Single

    ''' <summary>
    ''' The Y component of this vector.
    ''' </summary>
    Public ReadOnly Property Y As Single

    ''' <summary>
    ''' The magnitude of this vector.
    ''' </summary>
    Public ReadOnly Property Magnitude As Double

    Public Function Abs() As Vector2DF
        Return New Vector2DF(If(X < 0, X * -1, X), If(Y < 0, Y * -1, Y))
    End Function

    Public Function Dot(other As Vector2DF) As Single
        Return (X * other.X) + (Y * other.Y)
    End Function

    Public Function AbsDot(other As Vector2DF) As Single
        Return Math.Abs(Dot(other))
    End Function

    Public Function ToUnitVec() As Vector2DF
        Return Me / CSng(Magnitude)
    End Function

    Public Shared Operator +(left As Vector2DF, right As Vector2DF) As Vector2DF
        Return new Vector2DF(left.X + right.X, left.Y + right.Y)
    End Operator

    Public Shared Operator -(left As Vector2DF, right As Vector2DF) As Vector2DF
        Return new Vector2DF(left.X - right.X, left.Y - right.Y)
    End Operator

    Public Shared Operator *(left As Vector2DF, right As Integer) As Vector2DF
        Return New Vector2DF(left.X * right, left.Y * right)
    End Operator

    Public Shared Operator *(left As Vector2DF, right As Single) As Vector2DF
        Return New Vector2DF(left.X * right, left.Y * right)
    End Operator

    Public Shared Operator /(left As Vector2DF, right As Single) As Vector2DF
        Dim inverse As Single = 1.0F / right
        Return New Vector2DF(left.X * inverse, left.Y * inverse)
    End Operator

    Public Shared Operator -(vec As Vector2DF) As Vector2DF
        Return New Vector2DF(-vec.X, -vec.Y)
    End Operator

    Public Shared Property Zero As Vector2DF = New Vector2DF(0.0F, 0.0F)

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Vector2DF AndAlso Equals(DirectCast(obj, Vector2DF))
    End Function

    Public Overloads Function Equals(other As Vector2DF) As Boolean Implements IEquatable(Of Vector2DF).Equals
        Return Math.Abs(X - other.X) < 0.01F AndAlso Math.Abs(Y - other.Y) < 0.01F
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (X, Y).GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return $"<{Math.Round(X, 2)}, {Math.Round(Y, 2)}>"
    End Function
End Structure