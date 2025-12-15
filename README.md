<<<<<<< HEAD
# React + TypeScript + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) (or [oxc](https://oxc.rs) when used in [rolldown-vite](https://vite.dev/guide/rolldown)) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## React Compiler

The React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).

## Expanding the ESLint configuration

If you are developing a production application, we recommend updating the configuration to enable type-aware lint rules:

```js
export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...

      // Remove tseslint.configs.recommended and replace with this
      tseslint.configs.recommendedTypeChecked,
      // Alternatively, use this for stricter rules
      tseslint.configs.strictTypeChecked,
      // Optionally, add this for stylistic rules
      tseslint.configs.stylisticTypeChecked,

      // Other configs...
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```

You can also install [eslint-plugin-react-x](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-x) and [eslint-plugin-react-dom](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-dom) for React-specific lint rules:

```js
// eslint.config.js
import reactX from 'eslint-plugin-react-x'
import reactDom from 'eslint-plugin-react-dom'

export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...
      // Enable lint rules for React
      reactX.configs['recommended-typescript'],
      // Enable lint rules for React DOM
      reactDom.configs.recommended,
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```
=======
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
>>>>>>> ce514bae217358c2a0d7efcd544c341a8e542d63
