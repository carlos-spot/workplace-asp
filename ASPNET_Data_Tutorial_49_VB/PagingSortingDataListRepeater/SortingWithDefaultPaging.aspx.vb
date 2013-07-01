
Partial Class PagingSortingDataListRepeater_SortingWithDefaultPaging
    Inherits System.Web.UI.Page

#Region "Event Handlers for Paging Interface"
    Protected Sub FirstPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstPage.Click
        ' Send the user to the first page
        RedirectUser(0)
    End Sub

    Protected Sub PrevPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrevPage.Click
        ' Send the user to the previous page
        RedirectUser(PageIndex - 1)
    End Sub

    Protected Sub NextPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NextPage.Click
        ' Send the user to the next page
        RedirectUser(PageIndex + 1)
    End Sub

    Protected Sub LastPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LastPage.Click
        ' Send the user to the last page
        RedirectUser(PageCount - 1)
    End Sub
#End Region


#Region "Event Handlers for Sorting Interface"
    Protected Sub SortByProductName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortByProductName.Click
        'Sort by ProductName
        RedirectUser(0, "ProductName")
    End Sub

    Protected Sub SortByCategoryName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortByCategoryName.Click
        'Sort by CategoryName
        RedirectUser(0, "CategoryName")
    End Sub

    Protected Sub SortBySupplierName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortBySupplierName.Click
        'Sort by SupplierName
        RedirectUser(0, "SupplierName")
    End Sub
#End Region


    Private Sub RedirectUser(ByVal sendUserToPageIndex As Integer)
        ' Use the SortExpression property to get the sort expression from the querystring
        RedirectUser(sendUserToPageIndex, SortExpression)
    End Sub

    Private Sub RedirectUser(ByVal sendUserToPageIndex As Integer, ByVal sendUserSortingBy As String)
        ' Send the user to the requested page with the requested sort expression
        Response.Redirect(String.Format("SortingWithDefaultPaging.aspx?pageIndex={0}&pageSize={1}&sortExpression={2}", sendUserToPageIndex, PageSize, sendUserSortingBy))
    End Sub

    Protected Sub ProductsDefaultPagingDataSource_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ProductsDefaultPagingDataSource.Selected
        ' Reference the PagedDataSource bound to the DataList
        Dim pagedData As PagedDataSource = CType(e.ReturnValue, PagedDataSource)

        ' Remember the total number of records being paged through across postbacks
        TotalRowCount = pagedData.DataSourceCount

        ' Configure the paging interface based on the data in the PagedDataSource
        FirstPage.Enabled = Not pagedData.IsFirstPage
        PrevPage.Enabled = Not pagedData.IsFirstPage
        NextPage.Enabled = Not pagedData.IsLastPage
        LastPage.Enabled = Not pagedData.IsLastPage

        ' Display the current page being viewed...
        CurrentPageNumber.Text = String.Format("You are viewing page {0} of {1}...", PageIndex + 1, PageCount)
    End Sub


#Region "Page-Level, Paging-Related properties"
    Private Property TotalRowCount() As Integer
        Get
            Dim o As Object = ViewState("TotalRowCount")
            If (o Is Nothing) Then
                Return -1
            Else
                Return Convert.ToInt32(o)
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState("TotalRowCount") = Value
        End Set
    End Property

    Private ReadOnly Property PageCount() As Integer
        Get
            If TotalRowCount <= 0 OrElse PageSize <= 0 Then
                Return 1
            Else
                Return ((TotalRowCount + PageSize) - 1) / PageSize
            End If
        End Get
    End Property

    Private ReadOnly Property PageIndex() As Integer
        Get
            If (Not String.IsNullOrEmpty(Request.QueryString("pageIndex"))) Then
                Return Convert.ToInt32(Request.QueryString("pageIndex"))
            Else
                Return 0
            End If
        End Get
    End Property

    Private ReadOnly Property PageSize() As Integer
        Get
            If (Not String.IsNullOrEmpty(Request.QueryString("pageSize"))) Then
                Return Convert.ToInt32(Request.QueryString("pageSize"))
            Else
                Return 4
            End If
        End Get
    End Property

    Private ReadOnly Property SortExpression() As String
        Get
            If Not String.IsNullOrEmpty(Request.QueryString("sortExpression")) Then
                Return Request.QueryString("sortExpression")
            Else
                Return "ProductName"
            End If
        End Get
    End Property
#End Region
End Class
