USE Northwind
GO

-- 1. List all cities that have both Employees and Customers.

SELECT DISTINCT c.City
FROM Customers c JOIN Employees e ON c.City = e.City

-- 2. List all cities that have Customers but no Employee.

-- a.      Use sub-query

Select distinct city 
from Customers c
where city not in (
    select city 
    From Employees
)


-- b.      Do not use sub-query

SELECT DISTINCT c.City
FROM Employees e RIGHT JOIN Customers c ON c.City = e.City
WHERE e.City IS NULL

-- 3. List all products and their total order quantities throughout all orders

SELECT p.ProductID AS Products, SUM(od.Quantity) AS TotalOrderQuantities
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON o.OrderID = od.OrderID
GROUP BY p.ProductID

-- 4.  List all Customer Cities and total products ordered by that city.

SELECT c.City, ISNULL(COUNT(od.ProductID),0) as [Total Products]
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City

-- 5. List all Customer Cities that have at least two customers.

SELECT c1.City, COUNT(c1.CustomerID) as TotalCustomers
FROM Customers c1 
-- JOIN c2 ON c1.city = c2.city
GROUP BY c1.City
HAVING COUNT(c1.CustomerID) >= 2

-- 6. List all Customer Cities that have ordered at least two different kinds of products.


SELECT c.City, COUNT(DISTINCT od.ProductID) AS [Total Products]
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2

-- 7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.


SELECT c.ContactName, c.City AS [customer city], o.ShipCity AS [ship city]
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName, c.City, o.ShipCity
HAVING c.City <> o.ShipCity

-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

SELECT TOP 5 
    p.ProductID, 
    COUNT(od.OrderID) AS [Total Orders],
    AVG(od.UnitPrice * od.Quantity) AS [Average Price],
    (
      SELECT TOP 1 c.City
      FROM [Order Details] od2
      JOIN Orders o2 ON od2.OrderID = o2.OrderID
      JOIN Customers c ON o2.CustomerID = c.CustomerID
      WHERE od2.ProductID = p.ProductID
      GROUP BY c.City
      ORDER BY SUM(od2.Quantity) DESC
    ) AS [Top City]
FROM Products p 
JOIN [Order Details] od ON p.ProductID = od.ProductID 
GROUP BY p.ProductID
ORDER BY [Total Orders] DESC;


-- 9. List all cities that have never ordered something but we have employees there.

-- a.      Use sub-query

SELECT City
FROM Employees 
WHERE City NOT IN (
    SELECT o.ShipCity
    FROM Orders o
    GROUP BY o.ShipCity
    HAVING Count(o.OrderID) > 0
)

-- b.      Do not use sub-query

SELECT e.City
FROM Employees e LEFT JOIN Orders o ON e.City = o.ShipCity
GROUP BY e.City
HAVING Count(o.OrderID) = 0


--  10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

WITH EmployeeSales AS (
    SELECT TOP 1 e.City AS EmployeeCity, COUNT(o.OrderID) AS TotalOrders
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
    ORDER BY TotalOrders DESC
),
CustomerOrders AS (
    SELECT TOP 1 c.City AS CustomerCity, SUM(od.Quantity) AS TotalQuantity
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY c.City
    ORDER BY TotalQuantity DESC
)
SELECT es.EmployeeCity
FROM EmployeeSales es
INNER JOIN CustomerOrders co ON es.EmployeeCity = co.CustomerCity;
-- 11. How do you remove the duplicates record of a table?

-- We can remove duplicates using the row number and then deleting rows with number greater than 1

