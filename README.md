# RecipeVault

RecipeVault is a .NET MAUI mobile application for discovering recipes, saving favourites, planning meals by date, and managing a shopping list. The app was built as a full-stack mobile coursework project to demonstrate strong MVVM architecture, local persistence, cloud integration, and external API consumption.

## Background and Motivation

Many recipe apps are good at discovery but weak at planning. This project was motivated by a practical student workflow: find a recipe quickly, save it, schedule it into a weekly plan, then convert decisions into a shopping checklist.

RecipeVault focuses on this end-to-end flow:

1. Discover recipes from a public API.
2. Save preferred recipes for quick access.
3. Plan meals by date and meal type.
4. Track grocery items and completion state.
5. Keep critical user data available both locally and in cloud-backed storage.

## Core Features

- Firebase Authentication (register, login, token refresh)
- Recipe browsing via TheMealDB
- Recipe details with ingredients and instructions
- Favourites management
- Meal planner by date and meal type
- Shopping list with check/uncheck, swipe delete, clear checked
- Profile dashboard with usage stats
- Flyout navigation across main app sections

## Architecture

The solution follows MVVM with clear separation of responsibilities:

- Models: app entities and API DTOs
- Views: XAML pages and custom controls
- ViewModels: state + commands with CommunityToolkit.Mvvm
- Services: API clients, Firebase auth/cloud, SQLite access
- Interfaces: contracts for dependency inversion
- Converters: reusable UI value transformations

Implemented design patterns include:

- Dependency Injection / IoC
- Repository (local database service)
- Singleton (service lifetimes)
- Strategy-style service abstractions via interfaces
- Facade-like coordination in view models over multiple services

## Data and Integrations

- Local database: SQLite (offline-first persistence)
- Cloud: Firebase Authentication + Firestore REST API
- External API: TheMealDB

The recipe API layer implements 4 endpoints:

1. Search by name
2. Lookup by recipe ID
3. List categories
4. Filter by category

## Tech Stack

- .NET 8 / .NET MAUI
- C#
- CommunityToolkit.Mvvm
- sqlite-net-pcl
- SQLitePCLRaw.bundle_green
- Newtonsoft.Json

## Project Structure

- Models
- Interfaces
- Services
- ViewModels
- Views
- Controls
- Converters

## Setup

1. Open the project folder in Visual Studio 2022 or VS Code with .NET MAUI tooling.
2. Restore dependencies.
3. Configure Firebase values in Services/FirebaseConfig.cs:
   - WebApiKey
   - ProjectId
4. Build and run on your target (Windows, Android, iOS).

## Build Command (Windows Target)

```powershell
dotnet build -f net8.0-windows10.0.19041.0
```

## Current Status

- Project builds successfully on Windows target.
- Main navigation, API integration, authentication, SQLite, and Firestore flows are wired.
- Ready for credential configuration and end-to-end device testing.

## Future Improvements

- Secure secret handling (user-secrets / environment config)
- Better offline conflict resolution for cloud sync
- Search caching and pagination
- Unit tests for service and view model layers
- UI accessibility and localization enhancements
