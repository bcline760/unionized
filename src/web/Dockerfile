FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["web/Unionized.Web.csproj", "web/"]
RUN dotnet restore "web/Unionized.Web.csproj"
COPY . .
WORKDIR "/src/web"
RUN dotnet build "Unionized.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unionized.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unionized.Web.dll"]