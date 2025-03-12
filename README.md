## Video Game API

A simple ASP.NET Core Web API for managing video games. This project is built using **.NET 9** and Entity Framework Core, with **Scalar** for API documentation.

### Features

- **CRUD Operations**: Create, Read, Update, and Delete video games.
- **Scalar Integration**: Interactive API documentation powered by Scalar.
- **Entity Framework Core**: Uses EF Core for database operations.
- **In-Memory Database**: Data is stored in an in-memory database for simplicity.

### API Endpoints

| Method | Endpoint                         | Description                          |
|--------|----------------------------------|--------------------------------------|
| GET    | `/[controller]/GetAll`           | Get all video games.                 |
| GET    | `/[controller]/GetById/{id}`     | Get a video game by ID.              |
| POST   | `/[controller]/AddVideoGame`     | Create a new video game.             |
| PUT    | `/[controller]/UpdateById/{id}`  | Update an existing video game.       |
| DELETE | `/[controller]/DeleteById/{id}`  | Delete a video game.                 |

---

This is a simple API for testing and learning purposes. Feel free to explore and modify the code!
