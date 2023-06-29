-- Utilisation de noms et valeurs explicite pour faciliter la vérification des résultats

--		    --
-- PRODUCTS --
--		    --

INSERT INTO products_categories (name, description) VALUES
('Catégorie #1', 'Description de la catégorie #1'),
('Catégorie #2', 'Description de la catégorie #2'),
('Catégorie #3', 'Description de la catégorie #3');

SELECT * FROM products_categories;

-- Produit #1 avec 1 variantes
-- Produit #2 avec 2 variantes
-- Produit #3 avec 3 variantes
INSERT INTO products (category_id, name, description, price, image) VALUES
(3, 'Produit #1', 'Description du produit #1 Catégorie #3', 10.99, 'image_1.jpg'),
(2, 'Produit #2', 'Description du produit #2 Catégorie #2', 15.99, 'image_2.jpg'),
(1, 'Produit #3', 'Description du produit #3 Catégorie #1', 19.99, 'image_3.jpg');

SELECT * FROM products;

-- Affiche le nom des produits et de leurs catégories
SELECT product.name AS product_name, category.name AS category_name
	FROM products product
	INNER JOIN categories category ON product.category_id = category.id;

-- Bonus création d'une vue
CREATE VIEW ShowProductsAndCategoriesNames AS
	SELECT product.name AS product_name, category.name AS category_name
	FROM products product
	INNER JOIN products_categories category ON product.category_id = category.id;

SELECT * FROM ShowProductsAndCategoriesNames;

INSERT INTO products_variants (product_id, name, description, price, image) VALUES
(1, 'Variante #1 du produit #1', 'Description de la variante #1 du produit #1', 9.99, 'image_1_variant_1.jpg'),
(2, 'Variante #1 du produit #2', 'Description de la variante #1 du produit #2', 14.99, 'image_2_variant_1.jpg'),
(2, 'Variante #2 du produit #2', 'Description de la variante #2 du produit #2', NULL, 'image_2_variant_2.jpg'),
(3, 'Variante #1 du produit #3', NULL, 18.99, 'image_3_variant_1.jpg'),
(3, 'Variante #2 du produit #3', NULL, 19.99, 'image_3_variant_2.jpg'),
(3, 'Variante #3 du produit #3', NULL, 20.99, 'image_3_variant_3.jpg');

-- Affiche les infos de nos produits (id, nom, id catégorie, nom catégorie, variant(s) ...)
SELECT p.id AS product_id, p.name AS product_name, pc.name AS category_name, pv.name AS variant_name
FROM products p
INNER JOIN products_categories pc ON p.category_id = pc.id
LEFT JOIN products_variants pv ON p.id = pv.product_id;

SELECT p.id || '_' || p.name AS product_id_name, p.name AS product_name, pc.name AS category_name, pv.name AS variant_name
FROM products p
INNER JOIN products_categories pc ON p.category_id = pc.id
LEFT JOIN products_variants pv ON p.id = pv.product_id;

--		   --
-- CLIENTS --
--		   --

INSERT INTO clients_addresses (address, city, zip_code, country) VALUES
('33 Rue de Lille', 'Lille', '59000', 'France'),
('22 Rue de Paris', 'Paris', '75000', 'France'),
('11 Rue de Marseille', 'Marseille', '13000', 'France');

INSERT INTO clients (last_name, first_name, email, password, address_id) VALUES
('Simplon', 'Csharp', 'simplon@chsarp.fr', 'mot_de_passe', 1),
('Juin', 'Jeudi', 'juin@jeudi.fr', 'mot_de_passe', 2),
('Midi', 'Onze', 'midi@onze.fr', 'mot_de_passe', 3);