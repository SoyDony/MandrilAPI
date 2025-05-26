var builder = WebApplication.CreateBuilder(args); // Crea un nuevo objeto WebApplicationBuilder que se utiliza para configurar la aplicación web ASP.NET Core.


builder.Services.AddEndpointsApiExplorer();// Agrega servicios para explorar los puntos finales de la API.
builder.Services.AddSwaggerGen();// Agrega servicios para generar documentación de la API con Swagger.
builder.Services.AddControllers();  //para manejar los middlewares de la api.

var app = builder.Build(); // Construye la aplicación web ASP.NET Core.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Si la aplicación está en modo de desarrollo, habilita Swagger y Swagger UI
{
    app.UseSwagger(); // Swagger genera la documentación de la API automáticamente.
    app.UseSwaggerUI(); //estos son todos servicios que voy sumando a mi app. esta es la UI de swagger.
}

app.UseHttpsRedirection();// Habilita la redirección de solicitudes HTTP a HTTPS.
app.MapControllers(); //para manejar los middlewares de la api.

app.Run(); // Inicia la aplicación y comienza a escuchar solicitudes HTTP.
// Este es el punto de entrada de la aplicación ASP.NET Core. Aquí se configura y se inicia la aplicación.


