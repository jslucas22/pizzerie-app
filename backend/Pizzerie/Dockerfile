FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pizzerie/Pizzerie.csproj", "Pizzerie/"]
RUN dotnet restore "Pizzerie/Pizzerie.csproj"

COPY . .
WORKDIR "/src/Pizzerie"
RUN dotnet build "Pizzerie.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizzerie.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizzerie.dll"]
