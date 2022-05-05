CREATE VIEW [dbo].[ProductDetailView]
AS
SELECT        dbo.Products.Name AS [Product Name], dbo.Categories.CategoryName AS [Category Name], dbo.Products.UnitPrice AS [Unit Price], dbo.Products.UnitsInStock AS [Stock Amounts], 
                         dbo.Products.Description AS [Product Description]
FROM            dbo.Categories INNER JOIN
                         dbo.Products ON dbo.Categories.CategoryId = dbo.Products.CategoryId