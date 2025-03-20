USE AdventureWorks2019
GO

-- 1. How many products can you find in the Production.Product table?

SELECT COUNT(ProductID) as TotalNumOfProducts
FROM Production.Product

-- 2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(ProductID) AS ProductsInSubCategory
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

-- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.

-- ProductSubcategoryID CountedProducts

-- -------------------- ---------------

SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID
HAVING ProductSubcategoryID IS NOT NULL

-- 4. How many products that do not have a product subcategory.

SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID
HAVING ProductSubcategoryID IS NULL

-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.


-- USING JOIN

SELECT p.ProductID, ISNULL(SUM(pi.Quantity), 0) as TheSUM
FROM Production.Product p LEFT JOIN Production.ProductInventory pi ON p.ProductID = pi.ProductID
GROUP BY p.ProductID

-- USING CO-RELATED SUBQUERY

SELECT p.ProductID, (SELECT ISNULL(SUM(pi.Quantity), 0) FROM Production.ProductInventory pi WHERE pi.ProductID = p.ProductID GROUP BY pi.ProductID) AS TheSUM
FROM Production.Product p

-- 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

-- USING CTE AND HAVING 

WITH CTE
AS 
(SELECT pi.ProductID, pi.LocationID, SUM(pi.Quantity) AS TheSum
FROM Production.ProductInventory pi
GROUP BY pi.ProductID, pi.LocationID
HAVING pi.LocationID = 40)

SELECT ProductID, LocationID, TheSum
FROM CTE
WHERE TheSum < 100

--USING Derived Table

SELECT dt.ProductID, dt.TheSum
FROM (SELECT pi.ProductID, SUM(pi.Quantity) AS TheSum
FROM Production.ProductInventory pi
WHERE pi.LocationID = 40
GROUP BY pi.ProductID
) dt
WHERE dt.TheSum < 100

-- 7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

SELECT dt.Shelf, dt.ProductID, dt.TheSum
FROM (SELECT pi.Shelf, pi.ProductID, SUM(pi.Quantity) AS TheSum
FROM Production.ProductInventory pi
WHERE pi.LocationID = 40
GROUP BY pi.ProductID, pi.Shelf
) dt
WHERE dt.TheSum < 100


-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.


-- WITH WHERE CLAUSE
SELECT ProductID, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID

-- WITH HAVING CLAUSE

SELECT ProductID, LocationId, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, LocationId
Having LocationID = 10

-- 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

    -- ProductID   Shelf      TheAvg

    -- ----------- ---------- -----------


SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf

-- 10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

    -- ProductID   Shelf      TheAvg

    -- ----------- ---------- -----------

SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf
HAVING Shelf <> 'N/A'

-- 11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

    -- Color                        Class              TheCount          AvgPrice

    -- -------------- - -----    -----------            ---------------------

-- Filtering after aggregating
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
GROUP BY Color, Class
HAVING COLOR IS NOT NULL AND CLASS IS NOT NULL

-- Filtering before aggregating
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color is NOT NULL AND Class is NOT NULL
GROUP BY Color, Class


-- JOINS

-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

    -- Country                        Province

    -- ---------                          ----------------------

SELECT cr.Name as Country, sp.Name as Province
FROM Person.CountryRegion cr JOIN person.StateProvince sp on cr.CountryRegionCode = sp.CountryRegionCode

-- 13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
 

    -- Country                        Province

    -- ---------                          ----------------------

SELECT cr.Name as Country, sp.Name as Province
FROM Person.CountryRegion cr JOIN person.StateProvince sp on cr.CountryRegionCode = sp.CountryRegionCode
WHERE cr.Name IN ('Germany', 'Canada')



USE Northwind
GO


-- 14.  List all Products that has been sold at least once in last 27 years.

SELECT p.ProductID
FROM Products p LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON o.OrderID = od.OrderID
WHERE o.OrderDate < DATEADD(year, -27, GETDATE())
GROUP BY p.ProductID
ORDER BY p.ProductID

SELECT p.ProductID
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID
WHERE o.OrderDate < DATEADD(year, -27, GETDATE())
GROUP BY p.ProductID
ORDER BY p.ProductID

-- 15. List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 o.ShipPostalCode, count(*) as SoldInLocation
FROM [Order Details] od LEFT JOIN Orders o ON o.OrderID = od.OrderID
GROUP BY o.ShipPostalCode
HAVING o.ShipPostalCode is NOT NULL
ORDER BY SoldInLocation desc


-- 16. List top 5 locations (Zip Code) where the products sold most in last 27 years.

SELECT TOP 5 o.ShipPostalCode, count(*) as SoldInLocation
FROM [Order Details] od LEFT JOIN Orders o ON o.OrderID = od.OrderID
WHERE o.OrderDate < DATEADD(year, -27, GETDATE())
GROUP BY o.ShipPostalCode
HAVING o.ShipPostalCode is NOT NULL
ORDER BY SoldInLocation desc

-- 17. List all city names and number of customers in that city.

SELECT City, COUNT(CustomerID) AS NumOfCustomers
FROM Customers
GROUP BY City

-- 18. List city names which have more than 2 customers, and number of customers in that city

-- USING Derived Table
SELECT dt.City, dt.NumOfCustomers
FROM (
    SELECT City, COUNT(CustomerID) AS NumOfCustomers
    FROM Customers
    GROUP BY City
    ) dt
where dt.NumOfCustomers > 2

-- USING JOIN
SELECT c1.city, Count(c1.CustomerID) AS NumOfCustomers
FROM Customers c1 INNER JOIN Customers c2 ON c1.CustomerID = c2.CustomerID
GROUP BY c1.City
HAVING Count(c1.CustomerID) > 2

-- 19. List the names of customers who placed orders after 1/1/98 with order date.

SELECT c.ContactName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1/1/98'

-- 20. List the names of all customers with most recent order dates

Select c.ContactName, MAX(o.OrderDate) as MostRecentOrderDate
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

-- 21. Display the names of all customers  along with the  count of products they bought

SELECT c.ContactName, COUNT(p.ProductID) AS ProductsBought
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON od.OrderID = o.OrderID LEFT JOIN Products p ON p.ProductID = od.ProductID
GROUP BY c.ContactName

-- 22. Display the customer ids who bought more than 100 Products with count of products.

SELECT c.CustomerID, COUNT(p.ProductID) AS ProductsBought
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON od.OrderID = o.OrderID LEFT JOIN Products p ON p.ProductID = od.ProductID
GROUP BY c.CustomerID
HAVING COUNT(p.ProductID) > 100

-- 23. List all of the possible ways that suppliers can ship their products. Display the results as below

    -- Supplier Company Name                Shipping Company Name

    -- ---------------------------------            ----------------------------------

SELECT sup.CompanyName AS [Supplier Company Name], ship.CompanyName AS [Shipping Company Name]
FROM Suppliers sup 
JOIN Products p ON sup.SupplierID = p.SupplierID 
JOIN [Order Details] od ON p.ProductID = od.ProductID 
JOIN orders o ON o.OrderID = od.OrderID 
JOIN Shippers ship ON o.ShipVia = ship.ShipperID
GROUP BY sup.CompanyName, ship.CompanyName

-- 24. Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [order details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY o.OrderDate, p.ProductName
Order BY o.OrderDate

-- 25. Displays pairs of employees who have the same job title.

-- USING Derived table

SELECT e1.FirstName AS Employee1, e2.FirstName AS Employee2, e1.Title AS JobTitle
FROM Employees e1 JOIN Employees e2 ON e1.EmployeeID < e2.EmployeeID AND e1.Title = e2.Title

-- 26. Display all the Managers who have more than 2 employees reporting to them.

SELECT managers.EmployeeID AS ManagerID, managers.FirstName + ' ' + managers.LastName AS Manager, COUNT(employee.EmployeeID) AS Reporters
FROM Employees managers JOIN Employees employee ON managers.EmployeeID = employee.ReportsTo
GROUP BY managers.EmployeeID, managers.FirstName, managers.LastName
HAVING COUNT(employee.EmployeeID) > 2

-- 27. Display the customers and suppliers by city. The results should have the following columns

-- City

-- Name

-- Contact Name,

-- Type (Customer or Supplier)

CREATE FUNCTION FindType(@entry VARCHAR(20))
RETURNS VARCHAR(20)
BEGIN
    DECLARE @result VARCHAR(20)

    IF @entry = 'customers' 
        SET @result = 'Customer'
    ELSE 
        SET @result = 'Supplier'

    RETURN @result
END

SELECT City, ContactName, dbo.FindType('customers') AS Type
FROM Customers

UNION ALL

SELECT City, ContactName, dbo.FindType('suppliers') AS Type
FROM Suppliers
