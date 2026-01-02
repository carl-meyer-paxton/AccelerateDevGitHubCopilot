# Library App

## Description
Library App is a small .NET solution that demonstrates a console application layered on top of an application core and an infrastructure project. It contains a console UI, core domain entities and interfaces, and infrastructure components. The solution is organized for clarity and easy extension.

## Project Structure
- AccelerateDevGitHubCopilot.sln
- src/
    - [Library.Console](src/Library.Console/README.md)
        - [appSettings.json](src/Library.Console/appSettings.json)
        - [CommonActions.cs](src/Library.Console/CommonActions.cs)
        - [ConsoleApp.cs](src/Library.Console/ConsoleApp.cs)
        - [ConsoleState.cs](src/Library.Console/ConsoleState.cs)
        - [Program.cs](src/Library.Console/Program.cs)
    - [Library.ApplicationCore](src/Library.ApplicationCore/Library.ApplicationCore.csproj)
        - [Entities](src/Library.ApplicationCore/Entities)
        - [Enums](src/Library.ApplicationCore/Enums)
        - [Interfaces](src/Library.ApplicationCore/Interfaces)
        - [Services](src/Library.ApplicationCore/Services)
    - [Library.Infrastructure](src/Library.Infrastructure/Library.Infrastructure.csproj)
- tests/
    - [UnitTests](tests/UnitTests)

## Key Classes and Interfaces
- Console entrypoint:
  - [`Library.Console.Program`](src/Library.Console/Program.cs) — application startup and host configuration.
- Console application logic:
  - [`Library.Console.ConsoleApp`](src/Library.Console/ConsoleApp.cs) — main console interaction and command dispatch.
  - [`Library.Console.CommonActions`](src/Library.Console/CommonActions.cs) — reusable console actions and helpers.
  - [`Library.Console.ConsoleState`](src/Library.Console/ConsoleState.cs) — runtime state for the console session.
- Application core:
  - Project: [src/Library.ApplicationCore/Library.ApplicationCore.csproj](src/Library.ApplicationCore/Library.ApplicationCore.csproj)
  - Domain folders: [Entities](src/Library.ApplicationCore/Entities), [Enums](src/Library.ApplicationCore/Enums), [Interfaces](src/Library.ApplicationCore/Interfaces), [Services](src/Library.ApplicationCore/Services)
- Infrastructure:
  - Project: [src/Library.Infrastructure/Library.Infrastructure.csproj](src/Library.Infrastructure/Library.Infrastructure.csproj)

## Usage
1. Restore and build the solution:
```sh
dotnet restore AccelerateDevGitHubCopilot.sln
dotnet build AccelerateDevGitHubCopilot.sln
```
2. Run the console app (from solution root):
```sh
dotnet run --project src/Library.Console/Library.Console.csproj
```
3. Configuration:
- Console settings are in [src/Library.Console/appSettings.json](src/Library.Console/appSettings.json).

## License
This repository does not include a LICENSE file. Add a license of your choice (for example, MIT) in a `LICENSE` file at the repository root to clarify usage terms.