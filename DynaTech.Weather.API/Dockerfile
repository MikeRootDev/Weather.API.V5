#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DynaTech.Weather.API/DynaTech.Weather.API.csproj", "DynaTech.Weather.API/"]
RUN dotnet restore "DynaTech.Weather.API/DynaTech.Weather.API.csproj"
COPY . .
WORKDIR "/src/DynaTech.Weather.API"
RUN dotnet build "DynaTech.Weather.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DynaTech.Weather.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DynaTech.Weather.API.dll"]