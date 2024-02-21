CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE
    employees_levels (
        id SERIAL PRIMARY KEY,
        description VARCHAR(20)
    );

CREATE TABLE
    employees (
        id UUID PRIMARY KEY NOT NULL UNIQUE,
        name VARCHAR(255) NOT NULL,
        username VARCHAR(255) NOT NULL UNIQUE,
        password VARCHAR(255) NOT NULL,
        level_id INT REFERENCES employees_levels(id),
        created_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP,
            updated_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP
    );

CREATE TABLE
    products (
        id UUID PRIMARY KEY NOT NULL UNIQUE,
        description TEXT NOT NULL,
        price DECIMAL(10, 2) NOT NULL,
        category VARCHAR(255) NOT NULL,
        created_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP,
            updated_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP
    );

CREATE TABLE
    orders (
        id UUID PRIMARY KEY NOT NULL UNIQUE,
        employee_id UUID REFERENCES employees(id),
        table_number INTEGER NOT NULL,
        customer_name VARCHAR(255) NOT NULL,
        total_value DECIMAL(10, 2) NOT NULL,
        payment_method VARCHAR(50) NOT NULL,
        status VARCHAR(50) NOT NULL,
        note TEXT NULL,
        created_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP,
            updated_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP
    );

CREATE TABLE
     order_status (
        id SMALLINT PRIMARY KEY,
        description VARCHAR(24)
     );


CREATE TABLE
    order_items (
        id uuid PRIMARY KEY NOT NULL UNIQUE,
        order_id uuid REFERENCES orders(id),
        product_id uuid REFERENCES products(id),
        quantity INTEGER NOT NULL,
        id_order_status SMALLINT DEFAULT 1 REFERENCES order_status(id),
        created_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP,
            updated_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP
    );

CREATE TABLE
    settings (
        id SERIAL PRIMARY KEY,
        number_of_tables INTEGER NOT NULL
    );

INSERT INTO employees_levels (description) VALUES
('Chef'),
('Manager'),
('Waiter');

INSERT INTO employees (id, name, username, password, level_id) VALUES 
('7e36456d-e7c6-4b3d-9357-f70a79a8fc83', 'John Doe', 'johndoe', '$2a$11$YjgZJVNn6gJHVC34KsfwguY5D01LlqdNcOpg7AyaGeZC.De07YCom', 3),
('acb363cd-334e-48d8-b445-4a4990089cf7','Jane Smith', 'janesmith', '$2a$11$YjgZJVNn6gJHVC34KsfwguY5D01LlqdNcOpg7AyaGeZC.De07YCom', 2),
('a9a55b19-3184-4228-adbd-52e94e46172d', 'Mike Johnson', 'mikejohnson', '$2a$11$YjgZJVNn6gJHVC34KsfwguY5D01LlqdNcOpg7AyaGeZC.De07YCom', 1);

INSERT INTO products (id, description, price, category) VALUES 
('d702cc6a-6d83-45fc-8b77-544910651bf2', 'Margherita Pizza', 12.99, 'Pizza'),
('f43276ed-e9b2-46f5-a4f6-7250ef7fb84b', 'Pepperoni Pizza', 15.99, 'Pizza'),
('cd722e2a-1c2f-47f7-a2fb-9990f2bdc42b', 'Garlic Knots', 5.99, 'Appetizer');

INSERT INTO order_status (id, description) VALUES 
(1, 'A preparar'),
(2, 'Em preparo'),
(3, 'Pronto para retirar');

INSERT INTO orders (id, employee_id, table_number, customer_name, total_value, payment_method, status) VALUES 
('621d77e6-ede4-46ea-84bd-19156d935aea', '7e36456d-e7c6-4b3d-9357-f70a79a8fc83', 1, 'Customer One', 20.00, 'Cash', 'Open'),
('b5c7d6a0-13b1-42c0-8d79-3ec9a593a5b6', 'acb363cd-334e-48d8-b445-4a4990089cf7', 2, 'Customer Two', 30.00, 'Credit Card', 'Open'),
('6f9d6e47-9f76-4da4-a2d6-a77f6852def2', 'a9a55b19-3184-4228-adbd-52e94e46172d', 3, 'Customer Three', 45.00, 'Debit Card', 'Open');

INSERT INTO order_items (id, order_id, product_id, quantity) VALUES 
('da64f2e0-ec8e-468c-944f-47069a86506b', '621d77e6-ede4-46ea-84bd-19156d935aea', 'd702cc6a-6d83-45fc-8b77-544910651bf2', 2),
('117eba25-6e07-4b0d-b6ed-bf1987ecb6e5', 'b5c7d6a0-13b1-42c0-8d79-3ec9a593a5b6', 'f43276ed-e9b2-46f5-a4f6-7250ef7fb84b', 1),
('81962e9b-2c12-407e-8975-59423cf9bdf1', '6f9d6e47-9f76-4da4-a2d6-a77f6852def2', 'cd722e2a-1c2f-47f7-a2fb-9990f2bdc42b', 4);

INSERT INTO settings (number_of_tables) VALUES 
(10),
(15),
(20);
