#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CashFlow.Jobs/CashFlow.Jobs.csproj", "CashFlow.Jobs/"]
COPY ["CashFlow.Application/CashFlow.Application.csproj", "CashFlow.Application/"]
COPY ["CashFlow.Application.DTO/CashFlow.Application.DTO.csproj", "CashFlow.Application.DTO/"]
COPY ["CashFlow.Domain.Core/CashFlow.Domain.Core.csproj", "CashFlow.Domain.Core/"]
COPY ["CashFlow.Domain/CashFlow.Domain.csproj", "CashFlow.Domain/"]
COPY ["CashFlow.Infrastructure.CrossCutting.Adapter/CashFlow.Infrastructure.CrossCutting.Adapter.csproj", "CashFlow.Infrastructure.CrossCutting.Adapter/"]
COPY ["CashFlow.Infrastructure.CrossCutting.IOC/CashFlow.Infrastructure.CrossCutting.IOC.csproj", "CashFlow.Infrastructure.CrossCutting.IOC/"]
COPY ["CashFlow.Domain.Services/CashFlow.Domain.Services.csproj", "CashFlow.Domain.Services/"]
COPY ["CashFlow.Infrastructure.Repository/CashFlow.Infrastructure.Repository.csproj", "CashFlow.Infrastructure.Repository/"]
COPY ["CashFlow.Infrastructure.Data/CashFlow.Infrastructure.Data.csproj", "CashFlow.Infrastructure.Data/"]
RUN dotnet restore "CashFlow.Jobs/CashFlow.Jobs.csproj"
COPY . .
WORKDIR "/src/CashFlow.Jobs"
RUN dotnet build "CashFlow.Jobs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashFlow.Jobs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashFlow.Jobs.dll"]