CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE
    employees_levels (
        id SERIAL PRIMARY KEY,
        description VARCHAR(20)
    );

CREATE TABLE
    employees (
        id SERIAL PRIMARY KEY,
        uuid UUID DEFAULT uuid_generate_v4(),
        name VARCHAR(255) NOT NULL,
        username VARCHAR(255) NOT NULL UNIQUE,
        password VARCHAR(255) NOT NULL,
        level_id INT REFERENCES employees(id),
        created_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP,
            updated_at TIMESTAMP
        WITH
            TIME ZONE DEFAULT CURRENT_TIMESTAMP
    );

CREATE TABLE
    products (
        id SERIAL PRIMARY KEY,
        uuid UUID DEFAULT uuid_generate_v4(),
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
        id SERIAL PRIMARY KEY,
        uuid UUID DEFAULT uuid_generate_v4(),
        employee_id INTEGER REFERENCES employees(id),
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
    order_items (
        id SERIAL PRIMARY KEY,
        order_id INTEGER REFERENCES orders(id),
        product_id INTEGER REFERENCES products(id),
        quantity INTEGER NOT NULL,
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

INSERT INTO employees (name, username, password, level_id) VALUES 
('John Doe', 'johndoe', '$2a$11$YjgZJVNn6gJHVC34KsfwguY5D01LlqdNcOpg7AyaGeZC.De07YCom', 3),
('Jane Smith', 'janesmith', '$2a$11$YjgZJVNn6gJHVC34KsfwguY5D01LlqdNcOpg7AyaGeZC.De07YCom', 2),
('Mike Johnson', 'mikejohnson', '$2a$11$YjgZJVNn6gJHVC34KsfwguY5D01LlqdNcOpg7AyaGeZC.De07YCom', 1);

INSERT INTO products (description, price, category) VALUES 
('Margherita Pizza', 12.99, 'Pizza'),
('Pepperoni Pizza', 15.99, 'Pizza'),
('Garlic Knots', 5.99, 'Appetizer');

INSERT INTO orders (employee_id, table_number, customer_name, total_value, payment_method, status) VALUES 
(1, 1, 'Customer One', 20.00, 'Cash', 'Open'),
(2, 2, 'Customer Two', 30.00, 'Credit Card', 'Open'),
(3, 3, 'Customer Three', 45.00, 'Debit Card', 'Open');

INSERT INTO order_items (order_id, product_id, quantity) VALUES 
(1, 1, 2),
(2, 2, 1),
(3, 3, 4);

INSERT INTO settings (number_of_tables) VALUES 
(10),
(15),
(20);
