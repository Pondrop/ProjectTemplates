#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PROJECT_NAME.Api/PROJECT_NAME.Api.csproj", "src/PROJECT_NAME.Api/"]
COPY ["src/PROJECT_NAME.Application/PROJECT_NAME.Application.csproj", "src/PROJECT_NAME.Application/"]
COPY ["src/PROJECT_NAME.Domain/PROJECT_NAME.Domain.csproj", "src/PROJECT_NAME.Domain/"]
COPY ["src/PROJECT_NAME.Infrastructure/PROJECT_NAME.Infrastructure.csproj", "src/PROJECT_NAME.Infrastructure/"]
RUN dotnet restore "src/PROJECT_NAME.Api/PROJECT_NAME.Api.csproj"
COPY . .
WORKDIR "/src/src/PROJECT_NAME.Api"
RUN dotnet build "PROJECT_NAME.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PROJECT_NAME.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PROJECT_NAME.Api.dll"]