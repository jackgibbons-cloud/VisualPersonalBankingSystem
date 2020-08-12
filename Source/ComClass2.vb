<ComClass(ComClass2.ClassId, ComClass2.InterfaceId, ComClass2.EventsId)> _
Public Class ComClass2

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "ee04521b-a0e3-41ab-bab1-3e6a68a8305b"
    Public Const InterfaceId As String = "9a64c106-3eee-4fd4-b968-b787a0531f8b"
    Public Const EventsId As String = "aaf79a29-c3f3-4d7f-bad2-a4cc5731c4a9"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

End Class


