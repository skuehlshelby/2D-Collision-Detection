Public Structure Box2DF
    Implements IEquatable(Of Box2DF)

    Sub New(topLeft As Point2DF, bottomRight As Point2DF)
        Me.TopLeft = topLeft
        Me.BottomRight = bottomRight
    End Sub

    Public ReadOnly TopLeft As Point2DF

    Public ReadOnly BottomRight As Point2DF

    Public Function Width() As Single
        Return BottomRight.X - TopLeft.X
    End Function

    Public Function Height() As Single
        Return TopLeft.Y - BottomRight.Y
    End Function

    Public Function Top() As LineF
        Return New LineF(TopLeft,  New Point2DF(BottomRight.X, TopLeft.Y))
    End Function

    Public Function Bottom() As LineF
        Return New LineF(New Point2DF(TopLeft.X, BottomRight.Y), BottomRight)
    End Function

    Public Function Left() As LineF
        Throw New NotImplementedException
    End Function

    Public Function Right() As LineF
        Throw New NotImplementedException
    End Function

    Public Function Contains(point As Point2DF) As Boolean
        Return TopLeft.X <= point.X AndAlso TopLeft.Y >= point.Y AndAlso BottomRight.X >= point.X AndAlso BottomRight.Y <= point.Y
    End Function

    Public Function Union(other As Box2DF) As Box2DF
        Return New Box2DF(New Point2DF(
                                Math.Min(TopLeft.X, other.TopLeft.X), 
                                Math.Max(TopLeft.Y, other.TopLeft.Y)),
                       New Point2DF(
                               Math.Max(BottomRight.X, other.BottomRight.X), 
                               Math.Min(BottomRight.Y, other.BottomRight.Y)))
    End Function

    Public Function Union(others As IEnumerable(Of Box2DF)) As Box2DF
        Return others.Aggregate(Me, Function(a, b) a.Union(b))
    End Function

    Public Function LongestAxis() As Axis
        Return If(Width() > Height(), Axis.Horizontal, Axis.Vertical)
    End Function

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Box2DF AndAlso Equals(DirectCast(obj, Box2DF))
    End Function

    Public Overloads Function Equals(other As Box2DF) As Boolean Implements IEquatable(Of Box2DF).Equals
        Return TopLeft = other.TopLeft AndAlso BottomRight = other.BottomRight
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (TopLeft, BottomRight).GetHashCode()
    End Function

End Structure