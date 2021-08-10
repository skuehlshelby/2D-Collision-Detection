Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Module Extensions

    <Extension>
    Public Sub SetDoubleBuffered(panel As Panel)
        panel.GetType().InvokeMember("DoubleBuffered",
                                     BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty,
                                     Nothing, panel, new Object() {True})
    End Sub

End Module