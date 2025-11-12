# pruebatecnica_csharp

- Packetes necesarios para a instalar:
Microsoft.EntityFrameworkCore             8.0.8
Microsoft.EntityFrameworkCore.SqlServer   8.0.8
Microsoft.EntityFrameworkCore.Tools       8.0.8

Para la base de datos se uso SQL Server local, la conexion a la base de datos se configura en el archivo appsettings.json y modificar el nombre del 'server'

- comandos para la creacion de la base de datos y las tablas necesarios:
dotnet ef migrations add InitialCreate
dotnet ef database update

- si se tienen problemas con los anteriores comandos ejecutar el siguiente y ejecutar nuevamente los anteriores:
dotnet tool install --global dotnet-ef

- Para probar el funcionamiento de la API, ubicarse en la carpeta TodoApi y ejecutar el comando:
dotnet run

- Para probar los endpoints usar postman o cualquier otro parecido:
get
http://localhost:5289/api/Tasks

post 
http://localhost:5289/api/Tasks

PUT /api/tasks/{id}/complete
http://localhost:5289/api/Tasks/{id}/complete

delete
http://localhost:5289/api/Tasks/{id}