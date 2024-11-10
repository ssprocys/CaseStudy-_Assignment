CREATE Database Ecommerce
use Ecommerce

create table customers(
customer_id int Primary Key,
name varchar(50),
email varchar(50),
password varchar(20))

create table products( 
product_id int Primary Key,
name varchar(50),
price decimal,
description varchar,
stockQuantity int)

create table cart(
cart_id int Primary Key,
customer_id int Foreign Key REFERENCES customers(customer_id),
product_id int Foreign Key REFERENCES products(product_id),
quantity int)

create table orders(
order_id int Primary Key,
customer_id int Foreign Key REFERENCES customers(customer_id),
order_date date,
total_price decimal,
shipping_address varchar(80))

create table order_items(
order_item_id int Primary Key,
order_id int Foreign Key REFERENCES orders(order_id),
product_id int Foreign Key REFERENCES products(product_id),
quantity int)
