# Clone Instagram API :camera:
---
## Software Architecture
- [Clean Architecture](https://www.c-sharpcorner.com/article/introduction-to-clean-architecture-and-implementation-with-asp-net-core/#:~:text=Clean%20Architecture%20is%20a%20software,written%20without%20any%20direct%20dependencies.)
    - WebAPI Layer;
    - Application Layer;
    - Infrastructure Layer;
    - Domain Layer.
## Technologies
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10)
   - Collections;
   - Classes;
   - Interfaces;
   - Async/Await;
   - LINQ.
- [ASP.NET Web API](https://docs.microsoft.com/en-us/aspnet/web-api/) 
  - Dependency Injection;
  - Configuration;
  - Middleware;
  - Custom Exception;
  - Authorization/Authentication.
- [Entity Framework](https://docs.microsoft.com/en-us/ef/ef6/)
- [Fluent API](https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx)
- [AutoMapper](https://docs.automapper.org/en/stable/Getting-started.html)
- [MediatR](https://github.com/jbogard/MediatR)
## Database
- [Microsoft SQL Server](https://docs.microsoft.com/en-us/sql/?view=sql-server-ver16)
---
## Enums
|Name|Values|
|-|-|
|```UserRole```|```ADMIN```<br/>```USER```|
|```UserGender```|```MALE```<br/>```FEMALE```|
## Entities
:heavy_check_mark: **User**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value| 
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```Email```|```string```|:x:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:||
|```FullName```|```string```|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|```Username```|```string```|:x:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:||
|```PasswordHash```|```byte[]```|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|```PasswordSalt```|```byte[]```|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|```Role```|```UserRole```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```USER```|
|```Avatar```|```string```|:x:|:x:|:heavy_check_mark:|:x:|:x:|```null```|
|```WebSite```|```string```|:x:|:x:|:heavy_check_mark:|:x:|:x:|```null```|
|```PhoneNumber```|```string```|:x:|:x:|:heavy_check_mark:|:x:|:x:|```null```|
|```Biography```|```string```|:x:|:x:|:heavy_check_mark:|:x:|:x:|```null```|
|```Gender```|```UserGender```|:x:|:x:|:heavy_check_mark:|:x:|:x:|```null```|
|```IsBanned```|```boolean```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```false```|
|```IsDeactivated```|```boolean```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```false```|
|```CreatedAt```|```DateTimeOffset```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```UtcNow```|
:heavy_check_mark: **Post**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```Content```|```string```|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|```Description```|```string```|:x:|:x:|:heavy_check_mark:|:x:|:x:||
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```CreatedAt```|```DateTimeOffset```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```UtcNow```|
:heavy_check_mark: **Like**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```PostId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
:heavy_check_mark: **Save**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```PostId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
:heavy_check_mark: **Comment**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```Message```|```string```|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```PostId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```CreatedAt```|```DateTimeOffset```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```UtcNow```|
:x: **Follower**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```FollowingUserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
:x: **Room**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```PenPalUserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
:x: **Message**
|Name|Type|Primary Key|Foreign Key|Null|Not Null|Unique|Default Value|
|-|-|-|-|-|-|-|-|-|
|```Id```|```Guid```|:heavy_check_mark:|:x:|:x:|:heavy_check_mark:|:heavy_check_mark:|```NewGuid```|
|```Message```|```string```|:x:|:x:|:x:|:heavy_check_mark:|:x:||
|```UserId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```RoomId```|```Guid```|:x:|:heavy_check_mark:|:heavy_check_mark:|:x:|:x:||
|```CreatedAt```|```DateTimeOffset```|:x:|:x:|:x:|:heavy_check_mark:|:x:|```UtcNow```|