﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG CERT_PASS
ENV CERT_PASS $CERT_PASS

RUN mkdir https
RUN dotnet dev-certs https -ep ./https/aspnetapp.pfx -p ${CERT_PASS}
RUN dotnet dev-certs https --trust

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Litehome/Litehome.csproj", "Litehome/"]

RUN dotnet restore "Litehome/Litehome.csproj"
COPY . .
WORKDIR "/src/Litehome"
RUN dotnet build "Litehome.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Litehome.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --chmod=0755 --from=build /https/* /https/
COPY --from=publish /app/publish .

RUN mkdir /app/db

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Litehome.dll"]
