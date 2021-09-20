Imports System.Diagnostics.Contracts

Public Structure Bounds
    Implements IEquatable(Of Bounds)

    Sub New(bottomLeft As Point, topRight As Point)
        Me.BottomLeft = bottomLeft
        Me.TopRight = topRight
    End Sub

    Public ReadOnly Property BottomLeft As Point

    Public ReadOnly Property TopRight As Point

    <Pure>
    Public Function TopLeft() As Point
        Return New Point(BottomLeft.X, TopRight.Y)
    End Function

    <Pure>
    Public Function BottomRight() As Point
        Return New Point(TopRight.X, BottomLeft.Y)
    End Function

    <Pure>
    Public Function Width() As Single
        Return TopRight.X - BottomLeft.X
    End Function

    <Pure>
    Public Function Height() As Single
        Return TopRight.Y - BottomLeft.Y
    End Function

    <Pure>
    Public Function Area() As Double
        Return Width() * Height()
    End Function

    <Pure>
    Public Function Contains(point As Point) As Boolean
        Return BottomLeft.X <= point.X AndAlso TopRight.Y >= point.Y AndAlso TopRight.X >= point.X AndAlso BottomLeft.Y <= point.Y
    End Function

    <Pure>
    Public Function Contains(bounds As Bounds) As Boolean
        Return BottomLeft.X <= bounds.BottomLeft.X AndAlso BottomLeft.Y <= bounds.BottomLeft.Y AndAlso bounds.TopRight.X <= TopRight.X AndAlso bounds.TopRight.Y <= TopRight.Y
    End Function

    <Pure>
    Public Function Intersects(other As Bounds) As Boolean
        If TopRight.Y < other.BottomLeft.Y Then
            Return False
        ElseIf BottomLeft.X > other.TopRight.X Then
            Return False
        ElseIf other.BottomLeft.X > TopRight.X Then
            Return False
        ElseIf other.TopRight.Y < BottomLeft.Y Then
            Return False
        Else
            Return True
        End If
    End Function

    <Pure>
    Public Function Intersect(other As Bounds) As Bounds
        If Intersects(other) Then
            Return New Bounds(BottomLeft.Max(other.BottomLeft), TopRight.Min(other.TopRight))
        Else
            Return New Bounds()
        End If
    End Function

    <Pure>
    Public Function Union(other As Bounds) As Bounds
        Return New Bounds(BottomLeft.Min(other.BottomLeft), TopRight.Max(other.TopRight))
    End Function

    Public Shared Function Union(boxes As IEnumerable(Of Bounds)) As Bounds
        Dim maxX As Single = Single.NegativeInfinity
        Dim maxY As Single = Single.NegativeInfinity
        Dim minX As Single = Single.PositiveInfinity
        Dim minY As Single = Single.PositiveInfinity

        Dim boxEnumerator As IEnumerator(Of Bounds) = boxes.GetEnumerator()

        If Not boxEnumerator.MoveNext() Then
            Return New Bounds()
        Else
            Do
                Dim current As Bounds = boxEnumerator.Current

                If maxX < current.TopRight.X Then maxX = current.TopRight.X
                If maxY < current.TopRight.Y Then maxY = current.TopRight.Y
                If current.BottomLeft.X < minX Then minX = current.BottomLeft.X
                If current.BottomLeft.Y < minY Then minY = current.BottomLeft.Y
            Loop While boxEnumerator.MoveNext()
        End If

        Return New Bounds((minX, minY), (maxX, maxY))
    End Function

    Public Function LongestAxis() As Axis
        Return If(Width() > Height(), Axis.Horizontal, Axis.Vertical)
    End Function

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Bounds AndAlso Equals(DirectCast(obj, Bounds))
    End Function

    Public Overloads Function Equals(other As Bounds) As Boolean Implements IEquatable(Of Bounds).Equals
        Return BottomLeft = other.BottomLeft AndAlso TopRight = other.TopRight
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (BottomLeft, TopRight).GetHashCode()
    End Function

    Public Shared Property WorldCoordinateTransform As Func(Of Bounds, Bounds) = AddressOf DefaultCoordinateTransform

    Private Shared Function DefaultCoordinateTransform(bounds As Bounds) As Bounds
        Return bounds
    End Function

End Structure