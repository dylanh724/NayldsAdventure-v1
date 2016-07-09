Public Class Room
    ' Fields
    Private IDString As String
    Private NameString As String
    Private InInventoryBoolean As Boolean

    ' Constructor
    Public Sub New(ByVal _IDString As String,
                   ByVal _NameString As String,
                   ByVal _InInventoryBoolean As Boolean)

        IDString = _IDString
        NameString = _NameString
        InInventoryBoolean = _InInventoryBoolean

    End Sub

    ' Properties
    Public ReadOnly Property ID() As String
        Get
            Return Me.IDString
        End Get

    End Property

    Public Property InInventory() As Boolean
        Get
            Return Me.InInventoryBoolean
        End Get
        Set(value As Boolean)
            Me.InInventoryBoolean = value
        End Set

    End Property

    Public Property Name() As String
        Get
            Return Me.NameString
        End Get
        Set(value As String)
            Me.NameString = value
        End Set

    End Property

    ' Events
    Public Overrides Function ToString() As String
        Return IDString & "," &
            InInventoryBoolean & "," &
            NameString
    End Function

End Class
