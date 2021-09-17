Imports System.Diagnostics.Contracts

Public Structure Rectangle
    Implements IEquatable(Of Rectangle)

    Sub New(topLeft As Point, bottomRight As Point)
        Me.TopLeft = topLeft
        Me.BottomRight = bottomRight
    End Sub

    Public ReadOnly TopLeft As Point

    Public ReadOnly BottomRight As Point

    <Pure>
    Public Function TopRight() As Point
        Return TopLeft.Max(BottomRight)
    End Function

    <Pure>
    Public Function BottomLeft() As Point
        Return TopLeft.Min(BottomRight)
    End Function

    <Pure>
    Public Function Width() As Single
        Return BottomRight.X - TopLeft.X
    End Function

    <Pure>
    Public Function Height() As Single
        Return TopLeft.Y - BottomRight.Y
    End Function

    <Pure>
    Public Function Area() As Double
        Return Width() * Height()
    End Function

    <Pure>
    Public Function Contains(point As Point) As Boolean
        Return TopLeft.X <= point.X AndAlso TopLeft.Y >= point.Y AndAlso BottomRight.X >= point.X AndAlso BottomRight.Y <= point.Y
    End Function

    <Pure>
    Public Function Intersects(other As Rectangle) As Boolean
        If TopLeft.Y < other.BottomRight.Y Then
            Return False
        ElseIf TopLeft.X > other.BottomRight.X Then
            Return False
        ElseIf other.TopLeft.X > BottomRight.X Then
            Return False
        ElseIf other.TopLeft.Y < BottomRight.Y Then
            Return False
        Else
            Return True
        End If
    End Function

    <Pure>
    Public Function Intersect(other As Rectangle) As Rectangle
        If Intersects(other) Then
            Return _
                New Rectangle(New Point(TopLeft.Max(other.TopLeft).X, TopLeft.Min(other.TopLeft).Y),
                          New Point(BottomRight.Min(other.BottomRight).X, BottomRight.Max(other.BottomRight).Y))
        Else
            Return New Rectangle()
        End If
    End Function

    <Pure>
    Public Function Union(other As Rectangle) As Rectangle
        Return New Rectangle(New Point(
                                Math.Min(TopLeft.X, other.TopLeft.X), 
                                Math.Max(TopLeft.Y, other.TopLeft.Y)),
                       New Point(
                               Math.Max(BottomRight.X, other.BottomRight.X), 
                               Math.Min(BottomRight.Y, other.BottomRight.Y)))
    End Function

    Public Shared Function Union(boxes As IEnumerable(Of Rectangle)) As Rectangle
        Dim maxX As Single = Single.NegativeInfinity
        Dim minX As Single = Single.PositiveInfinity
        Dim maxY As Single = Single.NegativeInfinity
        Dim minY As Single = Single.PositiveInfinity

        Dim boxEnumerator As IEnumerator(Of Rectangle) = boxes.GetEnumerator()

        If Not boxEnumerator.MoveNext() Then
            Return New Rectangle()
        Else
            Do
                Dim current As Rectangle = boxEnumerator.Current

                If maxX < current.BottomRight.X Then maxX = current.BottomRight.X
                If minX > current.TopLeft.X Then minX = current.TopLeft.X
                If maxY < current.TopLeft.Y Then maxY = current.TopLeft.Y
                If minY > current.BottomRight.Y Then minY = current.BottomRight.Y
            Loop While boxEnumerator.MoveNext()
        End If

        Return New Rectangle((minX, maxY), (maxX, minY))
    End Function

    Public Function LongestAxis() As Axis
        Return If(Width() > Height(), Axis.Horizontal, Axis.Vertical)
    End Function

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Rectangle AndAlso Equals(DirectCast(obj, Rectangle))
    End Function

    Public Overloads Function Equals(other As Rectangle) As Boolean Implements IEquatable(Of Rectangle).Equals
        Return TopLeft = other.TopLeft AndAlso BottomRight = other.BottomRight
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (TopLeft, BottomRight).GetHashCode()
    End Function

End Structure