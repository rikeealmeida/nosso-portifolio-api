FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nosso-portifolio-api.csproj", "./"]
RUN dotnet restore "./nosso-portifolio-api.csproj"
COPY . .
RUN dotnet build "nosso-portifolio-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "nosso-portifolio-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "nosso-portifolio-api.dll"]