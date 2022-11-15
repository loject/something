DROP TABLE categories_products;
DROP TABLE categories;
DROP TABLE products;
CREATE TABLE [dbo].[categories](id int PRIMARY KEY,name varchar(200));
CREATE TABLE [dbo].[products](id int PRIMARY KEY, name varchar(200));
CREATE TABLE [dbo].[categories_products]
(
  product int, 
  category int,
  FOREIGN KEY (product)
        REFERENCES products(id),
  FOREIGN KEY (category)
        REFERENCES categories(id)
);
INSERT INTO categories VALUEs (1, 'cat1'), (2, 'cat2'), (3, 'cat2');
INSERT INTO products VALUEs (1, 'product1'), (2, 'product2'), (3, 'product3');
INSERT INTO categories_products VALUEs(1, 1), (2, 1), (2, 2);

SELECT products.id, products.name, categories.id, categories.name
FROM products
LEFT JOIN categories_products ON categories_products.product = products.id 
LEFT JOIN categories ON categories_products.category = categories.id;

