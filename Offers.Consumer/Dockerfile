#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Offers.Consumer/Offers.Consumer.csproj", "Offers.Consumer/"]
RUN dotnet restore "Offers.Consumer/Offers.Consumer.csproj"
COPY . .
WORKDIR "/src/Offers.Consumer"
RUN dotnet build "Offers.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Offers.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Offers.Consumer.dll"]