## Текст задачи

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

## Решение задачи
Допустим имеются следующие таблицы:
* Products(id, name)
* Categories(id, name)
* ProductsCatalog(product_id, category_id)

*ProductsCatalog* является связующей таблицей, т.к. в данном случае связь *многие-ко-многим*

Запрос создания таблиц:
```
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
```

Запрос заполнения таблиц:
```
INSERT INTO Products VALUES('Кросовки'), ('Штаны'), ('Хлеб'), ('Лампа');
INSERT INTO Categories VALUES('Спорт'), ('Еда');
INSERT INTO ProductsCatalog VALUES(1, 1), (2, 1), (3, 2), (4, NULL);
```

Запрос для получения данных выглядит так:
```
SELECT p.name AS Product, c.name AS Category FROM Products AS p
LEFT JOIN ProductsCatalog AS pc ON p.id = pc.product_id
LEFT JOIN Categories AS c ON c.id = pc.category_id
ORDER BY Product;
```

Пример вывода запроса:
| Product | Category |
| :-------: | :--------: |
| Кросовки  |	Спорт      |
| Лампа     |	NULL       |
| Хлеб      |	Еда        |
| Штаны     |	Спорт      |
