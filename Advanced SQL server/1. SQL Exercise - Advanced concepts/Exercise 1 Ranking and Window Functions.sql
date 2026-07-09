CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO Products VALUES
(1,'Laptop A','Electronics',80000),
(2,'Laptop B','Electronics',80000),
(3,'Laptop C','Electronics',75000),
(4,'Laptop D','Electronics',70000),

(5,'Sofa A','Furniture',50000),
(6,'Sofa B','Furniture',50000),
(7,'Sofa C','Furniture',45000),
(8,'Sofa D','Furniture',40000);
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;
WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS rn,
        RANK()       OVER (PARTITION BY Category ORDER BY Price DESC) AS rk,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS drk
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE rn <= 3
ORDER BY Category, Price DESC;