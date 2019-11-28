FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-arm32v7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster-arm32v7 AS build
WORKDIR /src
COPY ["api/Unionized.Api.csproj", "api/"]
COPY ["core/Unionized.csproj", "core/"]
COPY ["service/Unionized.Service.csproj", "service/"]
COPY ["model/openhab/Unionized.Model.OpenHab.csproj", "model/openhab/"]
COPY ["model/database/Unionized.Model.Database.csproj", "model/database/"]
COPY ["contract/Unionized.Contract.csproj", "contract/"]
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