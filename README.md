**Loan API — ASP.NET Core 8.0**
A secure, JWT-authenticated REST API for managing loan applications and user accounts.
Supports registration, authentication, loan creation, retrieval, updates, deletions, and administrative actions.

**Features**

User Authentication

Registration: create a new user

Login: authenticate and receive a JWT token

GetUserById: fetch user profile

BlockUser: admin-only operation to disable a user

**Loan Management**

ApplyForLoan: users apply for new loans

DisplayLoans: list loans belonging to the authenticated user (or all loans if admin)

UpdateLoan: update an existing loan

DeleteLoan: delete/cancel a loan

**Security**

JWT Bearer Authentication

Role-based access (User, Admin)

Strong password hashing

**Technologies Used**
Component Technology
Backend ASP.NET Core 8 Web API
Auth JWT Bearer Tokens
ORM Entity Framework Core
Database SQL Server / SQLite
Logging Serilog (file + console)
Documentation Swagger / OpenAPI

**Project Structure**

Loan_API/
│
├── Controllers/
│ ├── AuthController.cs
│ ├── LoanController.cs
│ └── UserController.cs
├── Services/
│ ├── AuthService.cs
│ ├── LoanService.cs
│ └── UserService.cs
├── Models/
│ ├── User.cs
│ └── Loan.cs
│
├── DTO/
│ ├── UserLoginDto.cs
│ ├── UserDto.cs
│ └── LoanDto.cs
│
└── Data/
├── ApplicationDbContextFactory.cs
└── ApplicationDbContext.cs

**Authentication Flow**

User registers; password is hashed and saved.

User logs in; system validates credentials.

API returns a JWT token.

Token is sent in every request via the Authorization header: "Bearer <token>".

Authorized endpoints require valid token and role.

API Endpoints Overview

**User Methods**

_Registration_
POST /api/auth/register
Creates a new user account. Validates input, hashes the password, stores user in the database, and returns success.

_Login_
POST /api/auth/login
Authenticates a user and returns a JWT token. Checks username and password, generates token with UserId, Email, Role, and returns token and user details.

_GetUserByID_
GET /api/auth/{id} (Authorization: User/Admin)
Fetches a single user's info. Returns user details excluding password.

_BlockUser_
PUT /api/auth/block/{id} (Authorization: Admin)
Blocks a user. Sets IsBlocked = true to prevent login. Admin-only operation.

**Loan Methods**

_ApplyForLoan_
POST /api/loan/apply (Authorization: User)
Creates a new loan request for the logged-in user. Saves loan with LoanType, Amount, Currency, PeriodMonths, Status = Processing, linked to UserId. Returns the created loan.

_DisplayLoans_
GET /api/loan/getloans (Authorization: User/Admin)
Returns loans for the current user. Admins see all loans. Reads UserId and Role from JWT, applies filtering accordingly.

_UpdateLoan_
PUT /api/loan/update/{id} (Authorization: Admin)
Updates an existing loan. Admin modifies fields like status or amount. Saves changes to the database.

_DeleteLoan_
DELETE /api/loan/delete/{id} (Authorization: Admin)
Deletes a loan from the system. Admin-only operation.

**Database Model Summary**

_User_
Id
FirstName
LastName
Email
PasswordHash
Role
IsBlocked

_Loan_
Id
LoanType
Amount
Currency
PeriodMonths
Status
UserId

**Logging**

_The project uses Serilog to log:_
Requests
Errors
Loan operations
Login attempts
Admin actions

Logs are stored in /logs directory.
