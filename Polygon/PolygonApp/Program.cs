var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Добавляем контроллеры
builder.Services.AddControllers();

// Другие сервисы, например, базы данных, авторизация и т.д.
// ...

var app = builder.Build();

// Подключаем CORS
app.UseCors("AllowAllOrigins");

// Подключаем маршрутизацию и контроллеры
app.UseRouting();

// Пример других middlewares, если они есть
// app.UseAuthentication();
// app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();