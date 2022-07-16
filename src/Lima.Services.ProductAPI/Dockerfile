#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Lima.Services.ProductAPI/Lima.Services.ProductAPI.csproj", "src/Lima.Services.ProductAPI/"]
RUN dotnet restore "src/Lima.Services.ProductAPI/Lima.Services.ProductAPI.csproj"
COPY . .
WORKDIR "/src/src/Lima.Services.ProductAPI"
RUN dotnet build "Lima.Services.ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lima.Services.ProductAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lima.Services.ProductAPI.dll"]