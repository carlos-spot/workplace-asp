
Partial Class EditInsertDelete_OptimisticConcurrency
    Inherits System.Web.UI.Page

    Protected Sub ProductsOptimisticConcurrencyDataSource_Deleted(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) Handles ProductsOptimisticConcurrencyDataSource.Deleted
        If e.ReturnValue IsNot Nothing AndAlso TypeOf e.ReturnValue Is Boolean Then
            Dim deleteReturnValue As Boolean = CType(e.ReturnValue, Boolean)

            If deleteReturnValue = False Then
                ' No row was deleted, display the warning message
                DeleteConflictMessage.Visible = True
            End If
        End If
    End Sub

    Protected Sub ProductsGrid_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs) Handles ProductsGrid.RowUpdated
        If e.Exception IsNot Nothing AndAlso e.Exception.InnerException IsNot Nothing Then
            If TypeOf e.Exception.InnerException Is System.Data.DBConcurrencyException Then
                ' Display the warning message and note that the exception has
                ' been handled...
                UpdateConflictMessage.Visible = True
                e.ExceptionHandled = True

                ' OPTIONAL: Rebind the data to the GridView and keep it in edit mode
                'ProductsGrid.DataBind();
                'e.KeepInEditMode = true;
            End If
        End If
    End Sub

    ' OPTIONAL: Display a warning message if the user attempts to update a record that has since been deleted
    '              To use this logic, uncomment the Label control in the markup portion.
    Protected Sub ProductsOptimisticConcurrencyDataSource_Updated(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs) Handles ProductsOptimisticConcurrencyDataSource.Updated
        'If e.ReturnValue IsNot Nothing AndAlso TypeOf e.ReturnValue Is Boolean Then
        '    Dim updateReturnValue As Boolean = CType(e.ReturnValue, Boolean)

        '    If updateReturnValue = False Then
        '        ' No row was updated, display the warning message
        '        UpdateLostMessage.Visible = True
        '    End If
        'End If
    End Sub
End Class
