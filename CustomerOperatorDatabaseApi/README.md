# Customer Operator Database API

A .NET 10 Razor Pages application for managing customers, operators, and their associated email addresses using SQLite database.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- Git (for cloning the repository)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/NatanProtector/Customer-Operator-Database-Api.git
cd Customer-Operator-Database-Api
```

### 2. Navigate to the Project Directory

```bash
cd CustomerOperatorDatabaseApi
```

### 3. Restore NuGet Packages

```bash
dotnet restore
```

### 4. Apply Database Migrations

This will create the SQLite database and seed it with initial data:

```bash
dotnet ef database update
```

### 5. Build the Project

```bash
dotnet build
```

### 6. Run the Application

```bash
dotnet run
```

The application will start and display the URL (typically `https://localhost:5001` or `http://localhost:5000`). Open this URL in your browser.

## Quick Setup (All-in-One Command)

```bash
dotnet restore && dotnet ef database update && dotnet build && dotnet run
```

## Project Structure

```
CustomerOperatorDatabaseApi/
├── DBContexts/          # Entity Framework database context
├── Entities/            # Data models (Customer, Operator, Email)
├── Migrations/          # EF Core database migrations
├── Pages/               # Razor Pages
├── Views/               # Shared views
├── wwwroot/             # Static files (CSS, JS, images)
└── Program.cs           # Application entry point
```

## Database

The project uses **SQLite** as the database engine. The database file (`.db`) is automatically created in the project directory when you run the migrations. This file is excluded from version control via `.gitignore`, so each developer will have their own local database instance.

### Database Entities

- **Customer**: Customer information
- **Operator**: Operator information
- **Email**: Email addresses associated with customers or operators

## Technologies Used

- .NET 10
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQLite

## Development

### Adding New Migrations

If you make changes to the entity models, create a new migration:

```bash
dotnet ef migrations add YourMigrationName
```

Then apply it to the database:

```bash
dotnet ef database update
```

### Removing the Last Migration

If you need to remove the most recent migration (before applying it):

```bash
dotnet ef migrations remove
```

## Troubleshooting

### Database Already Exists Error

If you encounter errors about the database already existing, you can delete the `.db`, `.db-shm`, and `.db-wal` files and run `dotnet ef database update` again.

### Port Already in Use

If the default port is already in use, you can specify a different port:

```bash
dotnet run --urls "https://localhost:5002;http://localhost:5003"
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

[Add your license information here]
