Public Structure LineF
    Implements IEquatable(Of LineF)
    Private Const Threshold As Single = 0.01F

    Sub New(start As Point2DF, finish As Point2DF)
        If start = finish Then
            Throw New ArgumentException("The starting and ending points of a line must be different.")
        End If

        Me.Start = start
        Me.Finish = finish
        IsHorizontal = Math.Abs(start.Y - finish.Y) < Threshold
        IsVertical = Math.Abs(start.X - finish.X) < Threshold
        Length = start.Distance(finish)
    End Sub

    Public ReadOnly Property Start As Point2DF

    Public ReadOnly Property Finish As Point2DF

    Public ReadOnly Length As Double

    Public ReadOnly Property IsHorizontal As Boolean

    Public ReadOnly Property IsVertical As Boolean

    Public Function Contains(point As Point2DF) As Boolean
        Dim startToPoint As Double = Start.Distance(point)
        Dim pointToFinish As Double = point.Distance(Finish)

        Return Math.Abs(Length - (startToPoint + pointToFinish)) < Threshold
    End Function

    Public Function Intersects(other As LineF) As Boolean
        Throw New NotImplementedException
    End Function

    Public Overrides Overloads Function Equals(obj As Object) As Boolean
        Return obj IsNot Nothing AndAlso TypeOf obj Is Point2DF AndAlso Equals(DirectCast(obj, LineF))
    End Function

    Public Overloads Function Equals(other As LineF) As Boolean Implements IEquatable(Of LineF).Equals
        Return Start = other.Start AndAlso Finish = other.Finish
    End Function
End Structure