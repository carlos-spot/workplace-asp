
Partial Class EditInsertDelete_DataModificationEvents
    Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		    MustProvideUnitPriceMessage.Visible = False
		End Sub
		
		Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
		    If e.NewValues("UnitPrice") IsNot Nothing Then
		        e.NewValues("UnitPrice") = Decimal.Parse(e.NewValues("UnitPrice").ToString(), System.Globalization.NumberStyles.Currency)
		    Else
		        ' Show the Label
		        MustProvideUnitPriceMessage.Visible = True
		
		        ' Cancel the update
		        e.Cancel = True
		    End If
		End Sub
		
		Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
		    e.InputParameters("CategoryID") = 1
		    e.InputParameters("SupplierID") = 1
		End Sub
End Class
