FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.6-buster-slim-arm32v7 AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
COPY api/Unionized.Api.csproj api/
COPY contract/Unionized.Contract.csproj contract/
COPY core/Unionized.csproj core/
COPY model/api/Unionized.Model.API.csproj model/api/
COPY model/database/Unionized.Model.Database.csproj model/database/
COPY service/Unionized.Service.csproj service/
COPY ["web/Unionized.Web.csproj", "web/"]
RUN dotnet restore "web/Unionized.Web.csproj"
COPY . . 
WORKDIR /src/web
RUN dotnet build "Unionized.Web.csproj" -c Release -o /app/build -r linux-arm

FROM build as publish
RUN dotnet publish "Unionized.Web.csproj" -c Release -o /app/publish -r linux-arm

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unionized.Web.dll"]