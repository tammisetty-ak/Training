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

