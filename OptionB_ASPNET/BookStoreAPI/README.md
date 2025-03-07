# BookStore API

## Overview
The BookStore API is a RESTful web service that provides CRUD operations for managing a collection of books. It allows users to create, read, update, and delete book entries in a bookstore.

## Features
- **CRUD Operations**: Create, Read, Update, and Delete books.
- **Data Model**: Represents books with properties such as Id, Title, Author, Genre, and Price.
- **Dependency Injection**: Utilizes interfaces for service abstraction and easier testing.

## Project Structure
```
BookStoreAPI
├── src
│   ├── BookStoreAPI
│   │   ├── Controllers
│   │   │   └── BooksController.cs
│   │   ├── Models
│   │   │   └── Book.cs
│   │   ├── Services
│   │   │   └── BookService.cs
│   │   ├── Interfaces
│   │   │   └── IBookService.cs
│   │   ├── Program.cs
│   │   └── Startup.cs
├── tests
│   ├── BookStoreAPI.Tests
│   │   ├── Controllers
│   │   │   └── BooksControllerTests.cs
│   │   ├── Services
│   │   │   └── BookServiceTests.cs
│   │   ├── Models
│   │   │   └── BookTests.cs
│   │   ├── Moq
│   │   │   └── MockBookService.cs
│   │   └── TestHelpers
│   │       └── TestHelper.cs
├── BookStoreAPI.sln
└── .editorconfig
```

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd BookStoreAPI
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run --project src/BookStoreAPI/BookStoreAPI.csproj
   ```

## API Usage
### Endpoints
- **GET /api/books**: Retrieve all books.
- **GET /api/books/{id}**: Retrieve a book by its ID.
- **POST /api/books**: Create a new book.
- **PUT /api/books/{id}**: Update an existing book.
- **DELETE /api/books/{id}**: Delete a book by its ID.

## Testing
To run the unit tests, navigate to the tests directory and execute:
```
dotnet test
```

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.