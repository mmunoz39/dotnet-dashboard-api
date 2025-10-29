# .NET Dashboard API

This is a simple ASP.NET Core Web API project that provides dashboard metrics. It is intended to be consumed by a frontend (Angular dashboard).

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server (LocalDB or full version)
- Swagger (Swashbuckle)

## Requirements

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download)
- SQL Server
- Visual Studio / Visual Studio Code

## Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/mmunoz39/dotnet-dashboard-api.git
   cd dotnet-dashboard-api
   ```

2. **Configure the database**
   Edit the connection string in `appsettings.json` or `appsettings.Development.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\USERNAME;Database=sSales;Trusted_Connection=True;"
   }
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **View Swagger UI**
   Open your browser at: [http://localhost:5155/swagger](http://localhost:5155/swagger)

## Available Endpoints

| Method | Endpoint                | Description                  |
|--------|-------------------------|------------------------------|
| GET    | `/api/dashboard`        | Returns the latest metrics   |
| GET    | `/api/dashboard/all`    | Returns all metrics records  |

## Notes

- CORS is enabled to allow requests from Angular (http://localhost:4200)
- Swagger UI is available only in Development mode
- Database name: `Sales`, table: `DashboardMetrics`

## License
This project is provided for educational and demonstration purposes.
Feel free to fork, clone or contribute!

## Author
**Marcelo Munoz**  
Data & Software Developer | Saskatoon, SK, Canada
