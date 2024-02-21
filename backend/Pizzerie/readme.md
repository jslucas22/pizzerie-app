# Checkout Backend

### Make sure Docker is running and you .net 6 installed

## Steps to run in development mode (db running in Docker, application running local)
### 1. Start the database server, and create table.
```bash
make run-db
```

### 2. Start the application
```bash
make run-dev
```

## 3. Endpoints + use cases
#### Get ALL employee Checkpads

How to request it:
Method: **GET**
Endpoint: `/api/employeeCheckpad`

Response
 ```json
[
    {
        "id": "6f9d6e47-9f76-4da4-a2d6-a77f6852def2",
        "employee_name": "Mike Johnson",
        "client_name": "Customer Three",
        "order_status": "A preparar",
        "products": [
            {
                "id": "cd722e2a-1c2f-47f7-a2fb-9990f2bdc42b",
                "description": "Garlic Knots",
                "category": "Appetizer",
                "price": 5.99
            }
        ],
        "creation_date": "2024-02-21T12:54:07.977579Z",
        "last_change_date": "2024-02-21T12:54:07.977579Z"
    }
```

#### Get employee checkpad by employee ID

How to Request it:
Method: **GET**
Endpoint: `/api/employeeCheckpad/{id_employee}`

Response
 ```json
[
    {
        "id": "6f9d6e47-9f76-4da4-a2d6-a77f6852def2",
        "employee_name": "Mike Johnson",
        "client_name": "Customer Three",
        "order_status": "A preparar",
        "products": [
            {
                "id": "cd722e2a-1c2f-47f7-a2fb-9990f2bdc42b",
                "description": "Garlic Knots",
                "category": "Appetizer",
                "price": 5.99
            }
        ],
        "creation_date": "2024-02-21T12:54:07.977579Z",
        "last_change_date": "2024-02-21T12:54:07.977579Z"
    }
```

#### Create employee checkpad

How to Request it:
Method: **POST**
Endpoint: `/api/employeeCheckpad`
Body: 
```json
{
    "id_employee": "7e36456d-e7c6-4b3d-9357-f70a79a8fc83",
    "client_name": "John Zé",
    "payment_method": "Credit Card",
    "table_number": 1,
    "products": [
        {
            "id": "d702cc6a-6d83-45fc-8b77-544910651bf2",
            "quantity": 12,
            "price": 23.45
        },
        {
            "id": "f43276ed-e9b2-46f5-a4f6-7250ef7fb84b",
            "quantity": 13,
            "price": 24.45
        },
        {
            "id": "cd722e2a-1c2f-47f7-a2fb-9990f2bdc42b",
            "quantity": 14,
            "price": 25.45
        }
    ]
}
```

#### Update employee checkpad
How to Request it:
Method: **PATH**
Endpoint: `/api/employeeCheckpad`
Body: 
```json
{
    "id": "621d77e6-ede4-46ea-84bd-19156d935aea",
    "table_number": 1,
    "client_name": "John Zé",
    "payment_method": "Cash",
    "status": "Confirmed",
    "order_status": 2,
    "note": "Cliente pediu para adicionar mais uma bebida.",
    "products": [
        {
            "id": "d702cc6a-6d83-45fc-8b77-544910651bf2",
            "quantity": 12,
            "price": 23.45
        },
        {
            "id": "f43276ed-e9b2-46f5-a4f6-7250ef7fb84bø",
            "quantity": 1,
            "price": 24.45,
            "remove": false
        }
    ]
}
```

#### Delete employee checkpad
How to request it:
Method: **DELETE**
Endpoint: `/api/employeeCheckpad/{idCheckpad}/{idEmployee}`

Response:
```json
{
    "success": false,
    "message": "Order or Employee not found."
}
```
