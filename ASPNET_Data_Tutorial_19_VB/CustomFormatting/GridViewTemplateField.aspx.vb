
Partial Class CustomFormatting_GridViewTemplateField
    Inherits System.Web.UI.Page

    Protected Function DisplayDaysOnJob(ByVal employee As Northwind.EmployeesRow) As String
        ' Make sure HiredDate is not null... if so, return "Unknown"
        If employee.IsHireDateNull() Then
            Return "Unknown"
        Else
            ' Returns the number of days between the current 
            ' date/time and hiredDate
            Dim ts As TimeSpan = DateTime.Now.Subtract(employee.HireDate)
            Return ts.Days.ToString("#,##0")
        End If
    End Function
End Class
