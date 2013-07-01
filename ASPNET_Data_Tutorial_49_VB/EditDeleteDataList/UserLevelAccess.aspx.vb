
Partial Class EditDeleteDataList_UserLevelAccess
    Inherits System.Web.UI.Page

    Protected Sub LoggedOnAs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoggedOnAs.SelectedIndexChanged
        ' Make sure editing is disabled and rebind the data to the DataList
        Employees.EditItemIndex = -1
        Employees.DataBind()
    End Sub

#Region "Updating-Related Event Handlers"
    Protected Sub Employees_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Employees.EditCommand
        'Set the EditItemIndex to the index of the item whose Edit button was clicked
        Employees.EditItemIndex = e.Item.ItemIndex
        Employees.DataBind()
    End Sub

    Protected Sub Employees_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Employees.CancelCommand
        'Return the DataList to its pre-editing state
        Employees.EditItemIndex = -1
        Employees.DataBind()
    End Sub

    Protected Sub Employees_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Employees.UpdateCommand
        ' Display a client-side messagebox explaining that the updating capabilities are not yet implemented
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "NotYetImplemented", "alert('Update capabilities are not yet implemented and are left as an exercise to the reader - that\'s you!');", True)

        ' Return the DataList to its pre-editing state
        Employees.EditItemIndex = -1
        Employees.DataBind()
    End Sub
#End Region


    ' A page-level variable holding information about the currently "logged on" user
    Dim currentlyLoggedOnUser As Northwind.EmployeesRow = Nothing

    Protected Sub Employees_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles Employees.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            ' Determine the Manager of the Employee record being bound to this DataListItem
            Dim employee As Northwind.EmployeesRow = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, Northwind.EmployeesRow)

            ' Read in the information for the currently "logged on" user, if needed
            If currentlyLoggedOnUser Is Nothing AndAlso Convert.ToInt32(LoggedOnAs.SelectedValue) > 0 Then
                Dim employeeAPI As New EmployeesBLL()
                currentlyLoggedOnUser = employeeAPI.GetEmployeeByEmployeeID(Convert.ToInt32(LoggedOnAs.SelectedValue))(0)
            End If


            ' See if this user has access to edit the employee
            Dim canEditEmployee As Boolean = False

            If currentlyLoggedOnUser IsNot Nothing Then
                ' We've got an authenticated user... see if they have no manager...
                If currentlyLoggedOnUser.IsReportsToNull() Then
                    canEditEmployee = True
                Else
                    ' ok, this person has a manager... see if they are editing themselves
                    If currentlyLoggedOnUser.EmployeeID = employee.EmployeeID Then
                        canEditEmployee = True
                        ' see if this person manages the employee
                    ElseIf Not employee.IsReportsToNull() AndAlso employee.ReportsTo = currentlyLoggedOnUser.EmployeeID Then
                        canEditEmployee = True
                    End If
                End If
            End If


            ' Referrence the Edit button and set its Visible property accordingly
            Dim editButton As Button = CType(e.Item.FindControl("EditButton"), Button)
            editButton.Visible = canEditEmployee
        End If
    End Sub
End Class
