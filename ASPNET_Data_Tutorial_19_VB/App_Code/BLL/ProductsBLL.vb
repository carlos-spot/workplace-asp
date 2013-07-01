Imports NorthwindTableAdapters

<System.ComponentModel.DataObject()> _
Public Class ProductsBLL

    Private _productsAdapter As ProductsTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As ProductsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New ProductsTableAdapter()
            End If

            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProducts() As Northwind.ProductsDataTable
        Return Adapter.GetProducts()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductByProductID(ByVal productID As Integer) As Northwind.ProductsDataTable
        Return Adapter.GetProductByProductID(productID)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsByCategoryID(ByVal categoryID As Integer) As Northwind.ProductsDataTable
        If categoryID < 0 Then
            Return GetProducts()
        Else
            Return Adapter.GetProductsByCategoryID(categoryID)
        End If
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsBySupplierID(ByVal supplierID As Integer) As Northwind.ProductsDataTable
        Return Adapter.GetProductsBySupplierID(supplierID)
    End Function


    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddProduct(ByVal productName As String, ByVal supplierID As Nullable(Of Integer), ByVal categoryID As Nullable(Of Integer), _
                                    ByVal quantityPerUnit As String, ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
                                    ByVal unitsOnOrder As Nullable(Of Short), ByVal reorderLevel As Nullable(Of Short), _
                                    ByVal discontinued As Boolean) As Boolean
        ' Create a new ProductRow instance
        Dim products As New Northwind.ProductsDataTable()
        Dim product As Northwind.ProductsRow = products.NewProductsRow()

        product.ProductName = productName
        If Not supplierID.HasValue Then product.SetSupplierIDNull() Else product.SupplierID = supplierID.Value
        If Not categoryID.HasValue Then product.SetCategoryIDNull() Else product.CategoryID = categoryID.Value
        If quantityPerUnit Is Nothing Then product.SetQuantityPerUnitNull() Else product.QuantityPerUnit = quantityPerUnit
        If Not unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = unitPrice.Value
        If Not unitsInStock.HasValue Then product.SetUnitsInStockNull() Else product.UnitsInStock = unitsInStock.Value
        If Not unitsOnOrder.HasValue Then product.SetUnitsOnOrderNull() Else product.UnitsOnOrder = unitsOnOrder.Value
        If Not reorderLevel.HasValue Then product.SetReorderLevelNull() Else product.ReorderLevel = reorderLevel.Value
        product.Discontinued = discontinued

        ' Add the new product
        products.AddProductsRow(product)
        Dim rowsAffected As Integer = Adapter.Update(products)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function

#Region "UpdateProduct Overloads"
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProduct(ByVal productName As String, ByVal supplierID As Nullable(Of Integer), ByVal categoryID As Nullable(Of Integer), _
                                    ByVal quantityPerUnit As String, ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
                                    ByVal unitsOnOrder As Nullable(Of Short), ByVal reorderLevel As Nullable(Of Short), _
                                    ByVal discontinued As Boolean, ByVal productID As Integer) As Boolean
        Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)

        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If

        Dim product As Northwind.ProductsRow = products(0)

        ' Business rule check - cannot discontinue a product that's supplied by only
        ' one supplier
        If discontinued Then
            ' Get the products we buy from this supplier
            Dim productsBySupplier As Northwind.ProductsDataTable = Adapter.GetProductsBySupplierID(product.SupplierID)

            If productsBySupplier.Count = 1 Then
                ' this is the only product we buy from this supplier
                Throw New ApplicationException("You cannot mark a product as discontinued if its the only product purchased from a supplier")
            End If
        End If

        product.ProductName = productName
        If Not supplierID.HasValue Then product.SetSupplierIDNull() Else product.SupplierID = supplierID.Value
        If Not categoryID.HasValue Then product.SetCategoryIDNull() Else product.CategoryID = categoryID.Value
        If quantityPerUnit Is Nothing Then product.SetQuantityPerUnitNull() Else product.QuantityPerUnit = quantityPerUnit
        If Not unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = unitPrice.Value
        If Not unitsInStock.HasValue Then product.SetUnitsInStockNull() Else product.UnitsInStock = unitsInStock.Value
        If Not unitsOnOrder.HasValue Then product.SetUnitsOnOrderNull() Else product.UnitsOnOrder = unitsOnOrder.Value
        If Not reorderLevel.HasValue Then product.SetReorderLevelNull() Else product.ReorderLevel = reorderLevel.Value
        product.Discontinued = discontinued

        ' Update the product record
        Dim rowsAffected As Integer = Adapter.Update(product)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)> _
    Public Function UpdateProduct(ByVal productName As String, ByVal unitPrice As Nullable(Of Decimal), ByVal productID As Integer) As Boolean
        Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)

        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If

        Dim product As Northwind.ProductsRow = products(0)

        product.ProductName = productName
        If Not unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = unitPrice.Value

        ' Update the product record
        Dim rowsAffected As Integer = Adapter.Update(product)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateProduct(ByVal productName As String, ByVal unitPrice As Nullable(Of Decimal), ByVal unitsInStock As Nullable(Of Short), _
                                   ByVal productID As Integer) As Boolean
        Dim products As Northwind.ProductsDataTable = Adapter.GetProductByProductID(productID)

        If products.Count = 0 Then
            ' no matching record found, return false
            Return False
        End If

        Dim product As Northwind.ProductsRow = products(0)

        ' Make sure the price hasn't more than doubled
        If unitPrice.HasValue AndAlso Not product.IsUnitPriceNull() Then
            If unitPrice > product.UnitPrice * 2 Then
                Throw New ApplicationException("When updating a product's price, the new price cannot exceed twice the original price.")
            End If
        End If

        product.ProductName = productName
        If Not unitPrice.HasValue Then product.SetUnitPriceNull() Else product.UnitPrice = unitPrice.Value
        If Not unitsInStock.HasValue Then product.SetUnitsInStockNull() Else product.UnitsInStock = unitsInStock.Value

        ' Update the product record
        Dim rowsAffected As Integer = Adapter.Update(product)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
#End Region

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteProduct(ByVal productID As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(productID)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

End Class