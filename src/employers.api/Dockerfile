FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/employers.api/employers.api.csproj", "src/employers.api/"]
COPY ["src/employers.infrastructure/employers.infrastructure.csproj", "src/employers.infrastructure/"]
COPY ["src/employers.application/employers.application.csproj", "src/employers.application/"]
COPY ["src/employers.domain/employers.domain.csproj", "src/employers.domain/"]
RUN dotnet restore "src/employers.api/employers.api.csproj"
COPY . .
WORKDIR "/src/src/employers.api"
RUN dotnet build "employers.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "employers.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "employers.api.dll"]
