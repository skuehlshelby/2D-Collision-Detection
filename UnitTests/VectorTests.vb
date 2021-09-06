Imports System.Numerics
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class VectorTests

    <TestMethod()>
    Public Sub TestMethod()
        Dim v1 As Vector2 = Vector2.Zero
        Dim v2 As Vector2 = New Vector2(1.0, 0.0)

        Console.WriteLine($"v1 + v2 = {v1 + v2}")
        Console.WriteLine($"v1 - v2 = {v1 - v2}")
        Console.WriteLine($"v1 * v2 = {v1 * v2}")
        Console.WriteLine($"v1 / v2 = {v1 / v2}")
        Console.WriteLine($"-v2 = {-v2}")
    End Sub

End Class