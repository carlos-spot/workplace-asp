
Partial Class PagingAndSorting_CustomSortingUI
    Inherits System.Web.UI.Page

    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        ' Only add the sorting UI if the GridView is sorted
        If Not String.IsNullOrEmpty(ProductList.SortExpression) Then
            ' Determine the index and HeaderText of the column that 
            'the data is sorted by
            Dim sortColumnIndex As Integer = -1
            Dim sortColumnHeaderText As String = String.Empty
            For i As Integer = 0 To ProductList.Columns.Count - 1
                If ProductList.Columns(i).SortExpression.CompareTo(ProductList.SortExpression) = 0 Then
                    sortColumnIndex = i
                    sortColumnHeaderText = ProductList.Columns(i).HeaderText
                    Exit For
                End If
            Next


            ' Reference the Table the GridView has been rendered into
            Dim gridTable As Table = CType(ProductList.Controls(0), Table)

            ' Enumerate each TableRow, adding a sorting UI header if
            ' the sorted value has changed
            Dim lastValue As String = String.Empty
            For Each gvr As GridViewRow In ProductList.Rows
                Dim currentValue As String = String.Empty
                If gvr.Cells(sortColumnIndex).Controls.Count > 0 Then
                    If TypeOf gvr.Cells(sortColumnIndex).Controls(0) Is CheckBox Then
                        If CType(gvr.Cells(sortColumnIndex).Controls(0), CheckBox).Checked Then
                            currentValue = "Yes"
                        Else
                            currentValue = "No"
                        End If

                        ' ... Add other checks here if using columns with other
                        '      Web controls in them (Calendars, DropDownLists, etc.) ...
                    End If
                Else
                    currentValue = gvr.Cells(sortColumnIndex).Text
                End If

                If lastValue.CompareTo(currentValue) <> 0 Then
                    ' there's been a change in value in the sorted column
                    Dim rowIndex As Integer = gridTable.Rows.GetRowIndex(gvr)

                    ' Add a new sort header row
                    Dim sortRow As New GridViewRow(rowIndex, rowIndex, DataControlRowType.DataRow, DataControlRowState.Normal)
                    Dim sortCell As New TableCell()
                    sortCell.ColumnSpan = ProductList.Columns.Count
                    sortCell.Text = String.Format("{0}: {1}", sortColumnHeaderText, currentValue)
                    sortCell.CssClass = "SortHeaderRowStyle"

                    ' Add sortCell to sortRow, and sortRow to gridTable
                    sortRow.Cells.Add(sortCell)
                    gridTable.Controls.AddAt(rowIndex, sortRow)

                    ' Update lastValue
                    lastValue = currentValue
                End If
            Next
        End If

        MyBase.Render(writer)
    End Sub
End Class
