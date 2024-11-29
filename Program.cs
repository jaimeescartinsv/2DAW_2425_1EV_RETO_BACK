var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel para escuchar en todas las interfaces
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Puerto HTTP
    options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // Puerto HTTPS
});

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Los controladores se registran automáticamente
builder.Services.AddScoped<TicketsController>();
builder.Services.AddScoped<SalasController>();

// Configurar autorización
builder.Services.AddAuthorization();

// Habilitar Swagger para la documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Configuración adicional para entornos de producción
    app.UseExceptionHandler("/error"); // Manejo de errores centralizado
    app.UseHsts(); // Seguridad adicional con Strict-Transport-Security
}

// Habilitar CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();