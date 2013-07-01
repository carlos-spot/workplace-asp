
Partial Class PagingSortingDataListRepeater_SortingWithCustomPaging
    Inherits System.Web.UI.Page

#Region "Event Handlers for Paging Interface"
    Protected Sub FirstPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstPage.Click
        'Return to StartRowIndex of 0 and rebind data
        StartRowIndex = 0
        Products.DataBind()
    End Sub

    Protected Sub PrevPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrevPage.Click
        'Subtract MaximumRows from StartRowIndex and rebind data
        StartRowIndex -= MaximumRows
        Products.DataBind()
    End Sub

    Protected Sub NextPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NextPage.Click
        'Add MaximumRows to StartRowIndex and rebind data
        StartRowIndex += MaximumRows
        Products.DataBind()
    End Sub

    Protected Sub LastPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LastPage.Click
        'Set StartRowIndex = to last page's starting row index and rebind data
        StartRowIndex = ((TotalRowCount - 1) \ MaximumRows) * MaximumRows
        Products.DataBind()
    End Sub
#End Region


#Region "Event Handlers for Sorting Interface"
    Protected Sub SortByProductName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortByProductName.Click
        StartRowIndex = 0
        SortExpression = "ProductName"
        Products.DataBind()
    End Sub

    Protected Sub SortByCategoryName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortByCategoryName.Click
        StartRowIndex = 0
        SortExpression = "CategoryName"
        Products.DataBind()
    End Sub

    Protected Sub SortBySupplierName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortBySupplierName.Click
        StartRowIndex = 0
        SortExpression = "CompanyName"
        Products.DataBind()
    End Sub
#End Region


    Protected Sub ProductsDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ProductsDataSource.Selecting
        e.InputParameters("sortExpression") = SortExpression
        e.InputParameters("startRowIndex") = StartRowIndex
        e.InputParameters("maximumRows") = MaximumRows

        ' Disable the paging interface buttons, if needed
        FirstPage.Enabled = StartRowIndex <> 0
        PrevPage.Enabled = StartRowIndex <> 0

        Dim LastPageStartRowIndex As Integer = ((TotalRowCount - 1) \ MaximumRows) * MaximumRows
        NextPage.Enabled = (StartRowIndex < LastPageStartRowIndex)
        LastPage.Enabled = (StartRowIndex < LastPageStartRowIndex)
    End Sub


#Region "Page-Level, Paging- and Sorting-Related properties"
    Private Property StartRowIndex() As Integer
        Get
            Dim o As Object = ViewState("StartRowIndex")
            If o Is Nothing Then
                Return 0
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("StartRowIndex") = value
        End Set
    End Property

    Private Property MaximumRows() As Integer
        Get
            Dim o As Object = ViewState("MaximumRows")
            If o Is Nothing Then
                Return 5
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("MaximumRows") = value
        End Set
    End Property

    Private ReadOnly Property TotalRowCount() As Integer
        Get
            'Return the value from the TotalNumberOfProducts() method
            Dim productsAPI As New ProductsBLL()
            Return productsAPI.TotalNumberOfProducts()
        End Get
    End Property

    Private Property SortExpression() As String
        Get
            Dim o As Object = ViewState("SortExpression")
            If o Is Nothing Then
                Return "ProductName"
            Else
                Return o.ToString()
            End If
        End Get
        Set(ByVal value As String)
            ViewState("SortExpression") = value
        End Set
    End Property
#End Region
End Class
