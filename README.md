# TV Show Database (MVC Project)
I used SQL Server for the database and Entity Framework Core for the data stuff. Bootstrap is used for styling (kinda default Bootstrap tho lol).

## Features

- Add shows with title, genre, year, rating, and if you recommend it
- See a list of all shows
- Edit existing shows
- Delete shows (working on confirmation messages maybe later)
- Uses a SQL Server database (LocalDB)

## Setup

1. Clone this repo
2. Make sure you have Visual Studio with .NET Core SDK
3. Update the connection string if needed in `ApplicationDbContextFactory.cs`
4. Run the app

```bash
dotnet ef database update
dotnet run
