# Food Delivery User Management API

A .NET 8 Web API for managing users in a food delivery system with JWT authentication, Entity Framework Core, and comprehensive user management features.

## Features

- JWT Bearer Authentication
- User Profile Management
- Address Management
- Order History
- Favorite Restaurants
- User Settings
- File Upload for Profile Images
- Input Validation with FluentValidation
- AutoMapper for DTO mapping
- Exception Handling Middleware
- CORS Support
- Swagger Documentation

## Setup Instructions

1. **Install EF Core Tools** (if not already installed):
   ```bash
   dotnet tool install --global dotnet-ef --version 8.0.0
   ```

2. **Update Database Connection String** in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Your SQL Server connection string here"
   }
   ```

3. **Create Database Migration**:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

4. **Update Database**:
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**:
   ```bash
   dotnet run
   ```

## API Endpoints

### User Management
- `GET /api/user/profile` - Get user profile
- `PUT /api/user/profile` - Update user profile
- `POST /api/user/profile/image` - Upload profile image
- `PUT /api/user/change-password` - Change password

### Address Management
- `GET /api/user/address` - Get user addresses
- `POST /api/user/address` - Add new address
- `PUT /api/user/address/{id}` - Update address
- `DELETE /api/user/address/{id}` - Delete address

### Order History
- `GET /api/user/order` - Get user orders (with pagination)
- `GET /api/user/order/{id}` - Get specific order

### Favorites
- `GET /api/user/favorite` - Get favorite restaurants
- `POST /api/user/favorite` - Add favorite restaurant
- `DELETE /api/user/favorite/{restaurantId}` - Remove favorite

### Settings
- `GET /api/user/settings` - Get user settings
- `PUT /api/user/settings` - Update user settings

## Authentication

All endpoints require JWT Bearer token authentication. Include the token in the Authorization header:
```
Authorization: Bearer <your-jwt-token>
```

## Project Structure

```
├── Controllers/          # API Controllers
├── Data/                # Entity Framework DbContext
├── DTOs/                # Data Transfer Objects
├── Mappings/            # AutoMapper Profiles
├── Middleware/          # Custom Middleware
├── Models/              # Entity Models
├── Services/            # Business Logic Services
├── Validators/          # FluentValidation Validators
└── wwwroot/uploads/     # File Upload Directory
```

## Technologies Used

- .NET 8
- Entity Framework Core 8.0
- SQL Server
- JWT Authentication
- AutoMapper
- FluentValidation
- BCrypt for password hashing
- Swagger/OpenAPI