Imports System.Text
Imports Geometry
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> 
Public Class Point2DFTests

    <TestMethod()> 
    Public Sub DistanceTest()
        Dim point As Point2DF = (3.0F, 4.0F)
        Dim otherPoint As Point2DF = (0.0F, 0.0F)

        Assert.AreEqual(5.0F, point.Distance(otherPoint), 0.01F)
    End Sub

End Class