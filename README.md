# Red, Yellow, Green
This repository contains my sample exercise, as part of the Red, Yellow, Green assignment

- Loosely follows the clean/hexagonal architecture
- SQLite in-memory database handles persistence
- Unit tests omitted in the interest of time

## Requirements
The .NET 7.0.11 (or newer) SDK. Available here: https://dotnet.microsoft.com/en-us/download/dotnet/7.0

## Building and running
From the repository root:
```
dotnet build
dotnet run --project Equipment.Api
```

## Using the application
While the application is running
- Open a browser at http://localhost:5089/LiveView to see live equipment updates from a fake factory
- Open a browser at http://localhost:5089/swagger to test the API endpoints for creating an equipment status entry, or viewing the status history for a piece of equipment.