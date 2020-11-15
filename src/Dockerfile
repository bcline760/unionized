#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG dbConnectStr
ARG dbName
ARG haApiKey
ARG haEndpoint
ARG ldapServer
ARG svcAccountUser
ARG svcAccountPassword

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.403-buster AS build
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
RUN dotnet build "Unionized.Api.csproj" --nologo -v q -c Release

FROM build AS publish
RUN dotnet publish "Unionized.Api.csproj" --nologo -v q -c Release --no-build -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.6-buster-slim-arm32v7 AS runtime
WORKDIR /app
EXPOSE 5001

FROM runtime AS final
WORKDIR /app
ENV DB_CONNECT_STR=${dbConnectStr}
ENV DB_NAME=${dbName}
ENV HA_API_KEY=${haApiKey}
ENV HA_ENDPOINT=${haEndpoint}
ENV LDAP_SERVER=${ldapServer}
ENV SVC_ACCOUNT_PASSWORD=${svcAccountPassword}
ENV SVC_ACCOUNT_USER=${svcAccountUser}
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unionized.Api.dll"]