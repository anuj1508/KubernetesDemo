#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY ["AggregatorService/AggregatorService.csproj", "AggregatorService/"]
#RUN dotnet restore "AggregatorService/AggregatorService.csproj"
#COPY . .
#WORKDIR "/src/AggregatorService"
#RUN dotnet build "AggregatorService.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AggregatorService.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AggregatorService.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env

WORKDIR /app
COPY ["./", "./"]

RUN dotnet restore AggregatorService.csproj

RUN dotnet build AggregatorService.csproj

RUN dotnet publish AggregatorService.csproj -c Release -o publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
WORKDIR /app/publish
EXPOSE 80
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "AggregatorService.dll"]