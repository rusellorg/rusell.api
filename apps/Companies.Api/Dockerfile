FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apps/Companies.Api/Companies.Api.csproj", "Companies.Api/"]
RUN dotnet restore "apps/Companies.Api/Companies.Api.csproj"
COPY . .
WORKDIR "/src/Companies.Api"
RUN dotnet build "Companies.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Companies.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Companies.Api.dll"]
