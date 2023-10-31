# KJBrainDeveloperService

With this free application, you can develop your brain. After registration, you can play six games: memory card, memory sound, what day it is, memory number, math, memory matrix.
This is the application's back-end part.

## Setup Requirements
- You need .NET 6
- Clone the repository.
- Configure the connection string for database.
- kj-brain-developer is the front-end part, so you have to use that, too.

## Appsettings structure
- ApplicationSettings.ClientDomain = your frontend url
- ApplicationSettings.ApplicationName = your app name
- SecuritySettings.TokenKey = required for jwt token generating
- SecuritySettings.TokenExpirationDays = Token expiration days
- LogSettings.LogFilesPath = log file location
- DatabaseSettings.Provider = databes type (PostgreSQL, MSSQL, SQLite)
- DatabaseSettings.ConnectionString = database ConnectionString
- DatabaseSettings.AutoMigrationEnabled = allowed to generate migration update automatically
- EmailSettings = your email settings (sender email)

## Key Features
- code first approach for database
- PostgreSQL, MSSQL, SQLite database choosing
- Repository and unitofwork pattern
- Swagger
- JWT token auth
- Password hash
- Email sending
- Logging
- Unique error message handling
