FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Order.API/Order.API.csproj", "Order.API/"]
COPY ["OrderInfrastructure/OrderInfrastructure.csproj", "OrderInfrastructure/"]
COPY ["Order.ApplicationCore/Order.ApplicationCore.csproj", "Order.ApplicationCore/"]
RUN dotnet restore "Order.API/Order.API.csproj"
COPY . .
WORKDIR "/src/Order.API"
RUN dotnet build "Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString="Server=tcp:orderdbserv.database.windows.net,1433;Initial Catalog=Order_History;Persist Security Info=False;User ID=orderdb;Password=BigStrongPass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENTRYPOINT ["dotnet", "Order.API.dll"]
