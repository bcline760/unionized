#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.6-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["api/Unionized.Api.csproj", "api/"]
COPY ["core/Unionized.csproj", "core/"]
COPY ["service/Unionized.Service.csproj", "service/"]
COPY ["model/api/Unionized.Model.API.csproj", "model/api/"]
COPY ["contract/Unionized.Contract.csproj", "contract/"]
COPY ["model/database/Unionized.Model.Database.csproj", "model/database/"]
RUN dotnet restore "api/Unionized.Api.csproj"
COPY . .
WORKDIR "/src/api"
RUN dotnet build "Unionized.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unionized.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unionized.Api.dll"]