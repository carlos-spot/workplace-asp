
Partial Class CustomFormatting_DetailsViewTemplateField
    Inherits System.Web.UI.Page

    Protected Function DisplayDiscontinuedAsYESorNO(ByVal discontinued As Boolean) As String
        If discontinued Then
            Return "YES"
        Else
            Return "NO"
        End If
    End Function
End Class
