Imports System.Reflection

Public Class Axis
    Implements IEquatable(Of Axis)

    Private Sub New(value As Integer, name As String)
        Me.Value = value
        Me.Name = name
    End Sub

    Public ReadOnly Property Value As Integer

    Private ReadOnly Property Name As String

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
        Return _
            GetType(Axis).GetProperties(BindingFlags.Public Or BindingFlags.Static).Select(
                Function(p) DirectCast(p.GetValue(Nothing), Axis))
    End Function

    Public Shared ReadOnly Property Horizontal As Axis = New Axis(0, NameOf(Horizontal))

    Public Shared ReadOnly Property Vertical As Axis = New Axis(1, NameOf(Vertical))

End Class