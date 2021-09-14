#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 5001
EXPOSE 5000
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["API/02.Services/AbnAnalytics/Abn.Analytics.Endpoint/Abn.Analytics.Endpoint.csproj", "API/02.Services/AbnAnalytics/Abn.Analytics.Endpoint/"]
COPY ["API/01.Framework/Abn.Framework.Core/Abn.Framework.Core.csproj", "API/01.Framework/Abn.Framework.Core/"]
COPY ["API/02.Services/AbnAnalytics/Abn.Analytics.Application/Abn.Analytics.Application.csproj", "API/02.Services/AbnAnalytics/Abn.Analytics.Application/"]
COPY ["API/02.Services/AbnAnalytics/Abn.Analytics.ApplicationContract/Abn.Analytics.ApplicationContract.csproj", "API/02.Services/AbnAnalytics/Abn.Analytics.ApplicationContract/"]
COPY ["API/02.Services/AbnAnalytics/Abn.Analytics.Data/Abn.Analytics.Data.csproj", "API/02.Services/AbnAnalytics/Abn.Analytics.Data/"]
COPY ["API/02.Services/AbnAnalytics/Abn.Analytics.Domain/Abn.Analytics.Domain.csproj", "API/02.Services/AbnAnalytics/Abn.Analytics.Domain/"]
 
 
 
 
RUN dotnet restore "API/02.Services/AbnAnalytics/Abn.Analytics.Endpoint/Abn.Analytics.Endpoint.csproj"
COPY . .
WORKDIR "/src/API/02.Services/AbnAnalytics/Abn.Analytics.Endpoint"
RUN dotnet build "Abn.Analytics.Endpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Abn.Analytics.Endpoint.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Abn.Analytics.Endpoint.dll"]