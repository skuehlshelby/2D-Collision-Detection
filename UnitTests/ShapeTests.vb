Imports System.Drawing
Imports System.Text
Imports Geometry
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> 
Public Class ShapeTests

    <TestMethod()> 
    Public Sub CircleContainsPoint()
        Dim point As Geometry.Point = (0.0F, 0.0F)
        Dim circle As IShape = New Circle(6.0F, Color.CornflowerBlue, (5.0F, 2.0F), Vector.Zero)

        Assert.IsTrue(circle.Contains(point))
    End Sub

    <TestMethod()> 
    Public Sub CircleDoesNotContainPoint()
        Dim point As Geometry.Point = (1.0F, 1.0F)
        Dim circle As IShape = New Circle(2.0F, Color.CornflowerBlue, (3.0F, 2.0F), Vector.Zero)

        Assert.IsFalse(circle.Contains(point))
    End Sub

    <TestMethod()> 
    Public Sub CirclesIntersect()
        Dim circle1 As IShape = New Circle(2.0F, Color.CornflowerBlue, (1.0F, 1.0F), Vector.Zero)
        Dim circle2 As IShape = New Circle(2.0F, Color.CornflowerBlue, (3.0F, 2.0F), Vector.Zero)

        Dim translationFromCircle1ToCircle2 As Vector = circle1.Center - circle2.Center
        Dim translationFromCircle2ToCircle1 As Vector = circle2.Center - circle1.Center

        Assert.AreEqual(New Vector(2.0F, 1.0F), translationFromCircle1ToCircle2)
        Assert.AreEqual(New Vector(-2.0F, -1.0F), translationFromCircle2ToCircle1)

        Dim vectorWithMagnitudeEqualToCircle1RadiusPointingTowardCenterOfCircle2 As Vector = translationFromCircle1ToCircle2.ToUnitVec() * 2.0F
        Dim vectorWithMagnitudeEqualToCircle2RadiusPointingTowardCenterOfCircle1 As Vector = translationFromCircle2ToCircle1.ToUnitVec() * 2.0F

        Assert.AreEqual(2.0, vectorWithMagnitudeEqualToCircle1RadiusPointingTowardCenterOfCircle2.Magnitude(), 0.01)
        Assert.AreEqual(2.0, vectorWithMagnitudeEqualToCircle2RadiusPointingTowardCenterOfCircle1.Magnitude(), 0.01)

        Dim pointFromCircle1ClosestToCenterOfCircle2 As Geometry.Point = circle1.Center + vectorWithMagnitudeEqualToCircle1RadiusPointingTowardCenterOfCircle2
        Dim pointFromCircle2ClosestToCenterOfCircle1 As Geometry.Point = circle2.Center + vectorWithMagnitudeEqualToCircle2RadiusPointingTowardCenterOfCircle1

        Assert.IsTrue(circle1.Contains(pointFromCircle2ClosestToCenterOfCircle1))
        Assert.IsTrue(circle2.Contains(pointFromCircle1ClosestToCenterOfCircle2))
        Assert.IsTrue(circle1.Contains(circle2.PointClosestTo(circle1.Center)))
        Assert.IsTrue(circle2.Contains(circle1.PointClosestTo(circle2.Center)))
    End Sub

    <TestMethod()> 
    Public Sub CirclesDoNotIntersect()
        Dim circle1 As IShape = New Circle(2.0F, Color.CornflowerBlue, (3.0F, 2.0F), Vector.Zero)
        Dim circle2 As IShape = New Circle(2.0F, Color.CornflowerBlue, (-1.1F, 2.0F), Vector.Zero)

        Assert.IsFalse(circle1.Contains(circle2.PointClosestTo(circle1.Center)))
    End Sub

    <TestMethod()> 
    Public Sub BoundsIntersect()
        Dim circle1 As IShape = New Circle(38.0F, Color.CornflowerBlue, (268.33F, 132.17F), New Vector(-10.0F, 13.0F))
        Dim circle2 As IShape = New Circle(19.0F, Color.CornflowerBlue, (293.0F, 98.0F), New Vector(-39.0F, 19.0F))

        Assert.IsTrue(circle1.Bounds().Intersects(circle2.Bounds()))
    End Sub

    <TestMethod()> 
    Public Sub RectangleConversionIsCorrect()
        Dim circle1 As IShape = New Circle(38.0F, Color.CornflowerBlue, (268.33F, 132.17F), New Vector(-10.0F, 13.0F))
        Dim circle1Bounds As Geometry.Rectangle = circle1.Bounds()
        Dim drawingRect As RectangleF = New RectangleF(circle1Bounds.TopLeft.X, circle1Bounds.TopLeft.Y, circle1Bounds.Width(), circle1Bounds.Height())

        Assert.AreEqual(circle1Bounds.Area(), drawingRect.Width * drawingRect.Height, 0.01)
        Assert.AreEqual(circle1Bounds.Width(), drawingRect.Width, 0.01)
        Assert.AreEqual(circle1Bounds.Height(), drawingRect.Height, 0.01)
        Assert.AreEqual(circle1Bounds.TopLeft.X, drawingRect.X, 0.01)
        Assert.AreEqual(circle1Bounds.TopLeft.Y, drawingRect.Y, 0.01)
    End Sub
End Class