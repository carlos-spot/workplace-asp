Imports NorthwindOptimisticConcurrencyTableAdapters

<System.ComponentModel.DataObject()> _
Public Class ProductsOptimisticConcurrencyBLL
    Private _productsAdapter As ProductsOptimisticConcurrencyTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As ProductsOptimisticConcurrencyTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New ProductsOptimisticConcurrencyTableAdapter()
            End If

            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProducts() As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable
        Return Adapter.GetProducts()
    End Function

#Region "UpdateProduct Overloads"
    Protected Sub AssignAllProductValues(ByVal product As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow, _
                                         ByVal productName As String, ByVal supplierID As Nullable(Of Integer), ByVal categoryID As Nullable(Of Integer), _
                                         ByVal quantityPerUnit As String, ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
                                         ByVal unitsOnOrder As Nullable(Of Short), ByVal reorderLevel As Nullable(Of Short), _
                                         ByVal discontinued As Boolean)
        product.ProductName = productName
        If Not supplierID.HasValue Then product.SetSupplierIDNull() Else product.SupplierID = supplierID.Value
        If Not categoryID.HasValue Then product.SetCategoryIDNull() Else product.CategoryID = categoryID.Value
        If quantityPerUnit Is Nothing Then product.SetQuantityPerUnitNull() Else product.QuantityPerUnit = quantityPerUnit
        If Not unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = unitPrice.Value
        If Not unitsInStock.HasValue Then product.SetUnitsInStockNull() Else product.UnitsInStock = unitsInStock.Value
        If Not unitsOnOrder.HasValue Then product.SetUnitsOnOrderNull() Else product.UnitsOnOrder = unitsOnOrder.Value
        If Not reorderLevel.HasValue Then product.SetReorderLevelNull() Else product.ReorderLevel = reorderLevel.Value
        product.Discontinued = discontinued
    End Sub

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProduct(ByVal productName As String, ByVal supplierID As Nullable(Of Integer), ByVal categoryID As Nullable(Of Integer), _
                                    ByVal quantityPerUnit As String, ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
                                    ByVal unitsOnOrder As Nullable(Of Short), ByVal reorderLevel As Nullable(Of Short), _
                                    ByVal discontinued As Boolean, ByVal productID As Integer, _
 _
                                    ByVal original_productName As String, ByVal original_supplierID As Nullable(Of Integer), ByVal original_categoryID As Nullable(Of Integer), _
                                    ByVal original_quantityPerUnit As String, ByVal original_unitPrice As Nullable(Of Decimal), ByVal original_unitsInStock As Nullable(Of Short), _
                                    ByVal original_unitsOnOrder As Nullable(Of Short), ByVal original_reorderLevel As Nullable(Of Short), _
                                    ByVal original_discontinued As Boolean, ByVal original_productID As Integer) As Boolean
        'STEP 1: Read in the current database product information
        Dim products As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable = Adapter.GetProductByProductID(original_productID)

        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If

        Dim product As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow = products(0)

        'STEP 2: Assign the original values to the product instance
        AssignAllProductValues(product, original_productName, original_supplierID, _
                               original_categoryID, original_quantityPerUnit, original_unitPrice, _
                               original_unitsInStock, original_unitsOnOrder, original_reorderLevel, _
                               original_discontinued)

        'STEP 3: Accept the changes
        product.AcceptChanges()

        'STEP 4: Assign the new values to the product instance
        AssignAllProductValues(product, productName, supplierID, categoryID, quantityPerUnit, unitPrice, _
                               unitsInStock, unitsOnOrder, reorderLevel, discontinued)

        'STEP 5: Update the product record
        Dim rowsAffected As Integer = Adapter.Update(product)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)> _
    Public Function UpdateProduct(ByVal productName As String, ByVal unitPrice As Nullable(Of Decimal), ByVal productID As Integer, _
 _
                                  ByVal original_productName As String, ByVal original_unitPrice As Nullable(Of Decimal), ByVal original_productID As Integer) As Boolean
        Dim products As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable = Adapter.GetProductByProductID(original_productID)

        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If

        Dim product As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow = products(0)

        'Assign the original values to the product instance
        product.ProductName = original_productName
        If Not original_unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = original_unitPrice.Value

        'Accept the changes
        product.AcceptChanges()

        'Assign the new values to the product instance
        product.ProductName = productName
        If Not unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = unitPrice.Value

        ' Update the product record
        Dim rowsAffected As Integer = Adapter.Update(product)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
#End Region

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteProduct(ByVal original_productID As Integer, ByVal original_productName As String, ByVal original_supplierID As Nullable(Of Integer), ByVal original_categoryID As Nullable(Of Integer), _
                                    ByVal original_quantityPerUnit As String, ByVal original_unitPrice As Nullable(Of Decimal), ByVal original_unitsInStock As Nullable(Of Short), _
                                    ByVal original_unitsOnOrder As Nullable(Of Short), ByVal original_reorderLevel As Nullable(Of Short), _
                                    ByVal original_discontinued As Boolean) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(original_productID, _
                                                     original_productName, _
                                                     original_supplierID, _
                                                     original_categoryID, _
                                                     original_quantityPerUnit, _
                                                     original_unitPrice, _
                                                     original_unitsInStock, _
                                                     original_unitsOnOrder, _
                                                     original_reorderLevel, _
                                                     original_discontinued)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, False)> _
    Public Function DeleteProduct(ByVal original_productID As Integer, ByVal original_productName As String, ByVal original_unitPrice As Nullable(Of Decimal)) As Boolean
        ' Read in the current values from the database
        Dim products As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable = Adapter.GetProductByProductID(original_productID)
        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If

        Dim product As NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyRow = products(0)

        Dim current_supplierID As Nullable(Of Integer) = Nothing
        Dim current_categoryID As Nullable(Of Integer) = Nothing
        Dim current_quantityPerUnit As String = Nothing
        Dim current_unitsInStock As Nullable(Of Short) = Nothing
        Dim current_unitsOnOrder As Nullable(Of Short) = Nothing
        Dim current_reorderLevel As Nullable(Of Short) = Nothing
        Dim current_discontinued As Boolean

        If Not product.IsSupplierIDNull() Then current_supplierID = product.SupplierID
        If Not product.IsCategoryIDNull() Then current_categoryID = product.CategoryID
        If Not product.IsQuantityPerUnitNull() Then current_quantityPerUnit = product.QuantityPerUnit
        If Not product.IsUnitsInStockNull() Then current_unitsInStock = product.UnitsInStock
        If Not product.IsUnitsOnOrderNull() Then current_unitsOnOrder = product.UnitsOnOrder
        If Not product.IsReorderLevelNull() Then current_reorderLevel = product.ReorderLevel
        current_discontinued = product.Discontinued


        ' Now, call the Delete method, passing in the original and current values, where appropriate
        Dim rowsAffected As Integer = Adapter.Delete(original_productID, _
                                          original_productName, _
                                          current_supplierID, _
                                          current_categoryID, _
                                          current_quantityPerUnit, _
                                          original_unitPrice, _
                                          current_unitsInStock, _
                                          current_unitsOnOrder, _
                                          current_reorderLevel, _
                                          current_discontinued)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
End Class
