# Employee Background Verification & Recruitment System

An enterprise full-stack web application designed to streamline candidate onboarding, document verification, and status tracking workflows.

## Tech Stack
- **Backend:** C#, ASP.NET Core 8 Web API, Entity Framework Core, SQL Server / MySQL
- **Frontend:** Angular 17+, TypeScript, Reactive Forms, RxJS, Bootstrap / CSS3
- **Tools & Testing:** Git, Postman, xUnit / Moq

## Project Structure
```text
├── database/
│   └── schema.sql
├── src/
│   ├── BackgroundVerification.API/
│   │   ├── Controllers/
│   │   ├── Models/
│   │   ├── Data/
│   │   ├── Services/
│   │   └── Program.cs
│   └── client-app/
│       ├── src/app/
│       │   ├── models/
│       │   ├── services/
│       │   └── components/
│       └── angular.json
├── tests/
│   ├── VerificationControllerTests.cs
│   └── Postman_Collection.json
└── README.md
```

## Running the Application

### Prerequisites
- .NET 8 SDK
- Node.js (v18+) & Angular CLI (`npm i -g @angular/cli`)
- SQL Server or MySQL Server

### Database Setup
Execute `database/schema.sql` on your database server to create tables, indexes, and sample seed data.

### Backend Setup
1. Update Connection String in `src/BackgroundVerification.API/appsettings.json`.
2. Run:
   ```bash
   cd src/BackgroundVerification.API
   dotnet restore
   dotnet run
   ```
3. Access Swagger UI at `https://localhost:5001/swagger`.

### Frontend Setup
1. Navigate to client app and install dependencies:
   ```bash
   cd src/client-app
   npm install
   ng serve -o
   ```
2. Open application in browser at `http://localhost:4200`.