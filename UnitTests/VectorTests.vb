Imports System.Numerics
Imports CollisionDetection.Model

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

    <TestMethod()>
    Public Sub DotProduct()
        Dim v1 As Vector = New Vector(-6.0F, 8.0F)
        Dim v2 As Vector = New Vector(5.0F, 12.0F)

        Assert.AreEqual(66.0F, v1.Dot(v2), 0.01F)
    End Sub


    <TestMethod()>
    Public Sub DotProductOfRightAnglesIsZero()
        Dim v1 As Vector = New Vector(-12.0F, 16.0F)
        Dim v2 As Vector = New Vector(12.0F, 9.0F)

        Assert.AreEqual(0.0F, v1.Dot(v2), 0.01F)
    End Sub

    <TestMethod()>
    Public Sub UnitVectorMagnitudeIsOne()
        Dim v1 As Vector = New Vector(-12.0F, 16.0F)
        Dim v2 As Vector = New Vector(12.0F, 9.0F)

        Assert.AreEqual(1.0F, v1.ToUnitVec().Magnitude(), 0.01F)
        Assert.AreEqual(1.0F, v2.ToUnitVec().Magnitude(), 0.01F)
    End Sub

    <TestMethod()>
    Public Sub SameVectorsAreEqual()
        Dim v1 As Vector = New Vector(-12.0F, 16.0F)
        Dim v2 As Vector = New Vector(-12.0F, 16.0F)

        Assert.AreEqual(v1, v2)
    End Sub

    <TestMethod()>
    Public Sub DistanceBetweenPointsIsSameAsMagnitudeOfVectorBetweenThem()
        Dim p1 As Point = New Point(2.5F, 6.45F)
        Dim p2 As Point = New Point(18.46F, 81.75F)

        Assert.AreEqual(p1.Distance(p2), (p1 - p2).Magnitude(), 0.01)
    End Sub

End Class