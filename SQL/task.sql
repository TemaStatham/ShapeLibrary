CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

CREATE TABLE ProductCategories (
    ProductId INT,
    CategoryId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO Products (Name) VALUES ('Product1');
INSERT INTO Products (Name) VALUES ('Product2');
INSERT INTO Products (Name) VALUES ('Product3');

INSERT INTO Categories (Name) VALUES ('Category1');
INSERT INTO Categories (Name) VALUES ('Category2');

INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (1, 1);
INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (1, 2);
INSERT INTO ProductCategories (ProductId, CategoryId) VALUES (3, 1);

SELECT 
    p.Name AS ProductName,
    c.Name AS CategoryName
FROM 
    Products p
LEFT JOIN 
    ProductCategories pc ON p.Id = pc.ProductId
LEFT JOIN 
    Categories c ON pc.CategoryId = c.Id;
