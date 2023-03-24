/* Создание Таблиц */
CREATE TABLE Products(
id INT PRIMARY KEY IDENTITY, 
name VARCHAR(255) NOT NULL);

CREATE TABLE Categories(
id INT PRIMARY KEY IDENTITY,
name VARCHAR(255) NOT NULL);

CREATE TABLE ProductsCatalog(
product_id INT NOT NULL,
category_id INT,
FOREIGN KEY(product_id) REFERENCES Products(id) ON DELETE CASCADE,
FOREIGN KEY(category_id) REFERENCES Categories(id));

/* Наполнение данными */
INSERT INTO Products VALUES('Кросовки'), ('Штаны'), ('Хлеб'), ('Лампа');
INSERT INTO Categories VALUES('Спорт'), ('Еда');
INSERT INTO ProductsCatalog VALUES(1, 1), (2, 1), (3, 2), (4, NULL);

/* Запрос к таблицам */
SELECT p.name AS Product, c.name AS Category FROM Products AS p
LEFT JOIN ProductsCatalog AS pc ON p.id = pc.product_id
LEFT JOIN Categories AS c ON c.id = pc.category_id
ORDER BY Product;