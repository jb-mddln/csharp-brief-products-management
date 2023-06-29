-- postgreSQL pgAdmin4
DROP DATABASE IF EXISTS "online_shop";

-- Créez une base de données nommée "online_shop".
CREATE DATABASE "online_shop" ENCODING "UTF8";

-- Créez nos différentes tables, maintenir l'ordre ici afin d'éviter les échecs de suppression dus aux contraintes de clé étrangère (FK)
DROP TABLE IF EXISTS client_reviews;
DROP TABLE IF EXISTS client_orders;
DROP TABLE IF EXISTS products_variants;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS products_categories;
DROP TABLE IF EXISTS products_promotions;
DROP TABLE IF EXISTS clients;
DROP TABLE IF EXISTS clients_addresses;

-- SERIAL = auto incrémente et notre valeur ne peut-être null (NOT NULL inclus dans SERIAL)
CREATE TABLE products_categories
(
	id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description TEXT
);

-- price précisions de 8 chiffres et 2 décimales après la virgule
CREATE TABLE products
(
	id SERIAL PRIMARY KEY,
	category_id INT NOT NULL,
    name VARCHAR(50) NOT NULL,
    description TEXT,
    price DECIMAL(8,3) NOT NULL,
	image TEXT,
	FOREIGN KEY (category_id) REFERENCES products_categories(id)
);

CREATE TABLE products_variants
(
	id SERIAL PRIMARY KEY,
	product_id INT NOT NULL,
    name VARCHAR(50) NOT NULL,
    description TEXT,
	price DECIMAL(8,3),
	image TEXT,
	FOREIGN KEY (product_id) REFERENCES products(id)
);

CREATE TABLE clients_addresses
(
	id SERIAL PRIMARY KEY,
    address TEXT NOT NULL,
	city VARCHAR(50) NOT NULL,
    zip_code VARCHAR(50) NOT NULL,
    country VARCHAR(50) NOT NULL
);

CREATE TABLE clients
(
	id SERIAL PRIMARY KEY,
    last_name VARCHAR(50) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
	address_id INT NOT NULL,
	FOREIGN KEY (address_id) REFERENCES clients_addresses(id)
);

CREATE TABLE client_reviews
(
	id SERIAL PRIMARY KEY,
	client_id INT NOT NULL,
	product_id INT NOT NULL,
	product_variant_id INT DEFAULT -1,
    comment TEXT NOT NULL,
    rating SMALLINT DEFAULT -1,
	FOREIGN KEY (client_id) REFERENCES clients(id),
	FOREIGN KEY (product_id) REFERENCES products(id)
);

CREATE TABLE client_orders
(
	id SERIAL PRIMARY KEY,
	client_id INT NOT NULL,
	product_id INT NOT NULL,
	product_variant_id INT DEFAULT -1,
	quantity INT NOT NULL DEFAULT 1,
    statut SMALLINT DEFAULT -1,
	FOREIGN KEY (client_id) REFERENCES clients(id),
	FOREIGN KEY (product_id) REFERENCES products(id)
);