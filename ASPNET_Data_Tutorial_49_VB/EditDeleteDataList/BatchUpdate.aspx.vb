
Partial Class EditDeleteDataList_BatchUpdate
    Inherits System.Web.UI.Page

    Protected Sub UpdateAll1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateAll1.Click
        UpdateAllSupplierAddresses()
    End Sub

    Protected Sub UpdateAll2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateAll2.Click
        UpdateAllSupplierAddresses()
    End Sub

Private Sub UpdateAllSupplierAddresses()
    ' Create an instance of the SuppliersBLL class
    Dim suppliersAPI As New SuppliersBLL()

    ' Iterate through the DataList's items
    For Each item As DataListItem In Suppliers.Items
        ' Get the supplierID from the DataKeys collection
        Dim supplierID As Integer = Convert.ToInt32(Suppliers.DataKeys(item.ItemIndex))

        ' Read in the user-entered values
        Dim address As TextBox = CType(item.FindControl("Address"), TextBox)
        Dim city As TextBox = CType(item.FindControl("City"), TextBox)
        Dim country As TextBox = CType(item.FindControl("Country"), TextBox)

        Dim addressValue As String = Nothing, cityValue As String = Nothing, countryValue As String = Nothing
        If address.Text.Trim().Length > 0 Then
            addressValue = address.Text.Trim()
        End If
        If city.Text.Trim().Length > 0 Then
            cityValue = city.Text.Trim()
        End If
        If country.Text.Trim().Length > 0 Then
            countryValue = country.Text.Trim()
        End If

        ' Call the SuppliersBLL class's UpdateSupplierAddress method
        suppliersAPI.UpdateSupplierAddress(supplierID, addressValue, cityValue, countryValue)
    Next
End Sub
End Class
