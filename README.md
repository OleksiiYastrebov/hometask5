# Project Setup and Run Instructions

1. **Change the connection string**  
   Update the connection string in `appsettings.json` with your connection string.

2. **Apply migrations**  
   Run command to migrate:  
   ```bash
   dotnet ef database update
   
3. **Db will be seeded each run for testing purposes.**
   Comment lines 12 and 13 in Program.cs if you don`t want it.
