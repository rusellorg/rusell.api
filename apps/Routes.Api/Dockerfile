FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apps/Routes.Api/Routes.Api.csproj", "Routes.Api/"]
RUN dotnet restore "apps/Routes.Api/Routes.Api.csproj"
COPY . .
WORKDIR "/src/Routes.Api"
RUN dotnet build "Routes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Routes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Routes.Api.dll"]
