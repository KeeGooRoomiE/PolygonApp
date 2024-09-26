# Используйте официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем остальные файлы и выполняем сборку
COPY . ./
RUN dotnet publish -c Release -o out

# Используем официальный образ .NET Runtime для выполнения приложения
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Указываем порт, который будет использовать приложение
EXPOSE 80

# Задаем команду запуска
ENTRYPOINT ["dotnet", "PolygonApp.dll"]