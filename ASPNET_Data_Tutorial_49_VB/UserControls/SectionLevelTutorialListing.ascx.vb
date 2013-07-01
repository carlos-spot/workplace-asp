Partial Class UserControls_SectionLevelTutorialListing
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If SiteMap.CurrentNode is not Nothing, 
        ' bind CurrentNode's ChildNodes to the GridView
        If SiteMap.CurrentNode IsNot Nothing Then
            TutorialList.DataSource = SiteMap.CurrentNode.ChildNodes
            TutorialList.DataBind()
        End If
    End Sub
End Class
