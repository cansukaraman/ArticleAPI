# ArticleAPI

This project contains APIs using .Net Core and EntityFramework Core.

#Building Sample for DB
.NET Core Article sample using the .NET Core CLI, and installed .net core sdk. 

```
dotnet build
dotnet run
```
Create sql database local server 

```
dotnet ef database update
```

### Endpoint Structure

https://[baseUrl]/api/[controller]/{id}
Ex:
https://[baseUrl]/api/article/3


## Status
```
New = 0,
Active = 1,
Passive = 2,
Deleted = -1
```

