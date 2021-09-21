Public MustInherit Class Axis
    Implements IEquatable(Of Axis)

    Private Sub New(value As Integer, name As String)
        Me.Value = value
        Me.Name = name
    End Sub

    Public ReadOnly Property Value As Integer

    Private ReadOnly Property Name As String

    Public MustOverride Function Opposite() As Axis

    Public MustOverride Function SelectAxis(point As Point) As Single

    Public MustOverride Function SelectAxis(vector As Vector) As Single

    Public MustOverride Function SelectAxis(bounds As Bounds) As Single

    Public Overrides Function ToString() As String
        Return Name
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Axis))
    End Function

    Public Overloads Function Equals(other As Axis) As Boolean Implements IEquatable(Of Axis).Equals
        Return other IsNot Nothing AndAlso Value = other.Value
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Value
    End Function

    Public Shared Function Values() As IEnumerable(Of Axis)
        Return New Axis(){Horizontal, Vertical}
    End Function

    Private Class HorizontalAxis
        Inherits Axis

        Public Sub New()
            MyBase.New(0, NameOf(Horizontal))
        End Sub

        Public Overrides Function Opposite() As Axis
            Return Vertical
        End Function

        Public Overrides Function SelectAxis(point As Point) As Single
            Return point.X
        End Function

        Public Overrides Function SelectAxis(vector As Vector) As Single
            Return vector.X
        End Function

        Public Overrides Function SelectAxis(bounds As Bounds) As Single
            Return bounds.Width()
        End Function
    End Class

    Private Class VerticalAxis
        Inherits Axis

        Public Sub New()
            MyBase.New(1, NameOf(Vertical))
        End Sub

        Public Overrides Function Opposite() As Axis
            Return Horizontal
        End Function

        Public Overrides Function SelectAxis(point As Point) As Single
            Return point.Y
        End Function

        Public Overrides Function SelectAxis(vector As Vector) As Single
            Return vector.Y
        End Function

        Public Overrides Function SelectAxis(bounds As Bounds) As Single
            Return bounds.Height()
        End Function
    End Class

    Public Shared ReadOnly Property Horizontal As Axis = New HorizontalAxis()

    Public Shared ReadOnly Property Vertical As Axis = New VerticalAxis()


    Public Shared Operator =(left As Axis, right As Axis) As Boolean
        Return left IsNot Nothing AndAlso left.Equals(right)
    End Operator

    Public Shared Operator <>(left As Axis, right As Axis) As Boolean
        Return left Is Nothing OrElse Not left.Equals(right)
    End Operator

End Class