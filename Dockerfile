FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BornToCode_API/BornToCode_API.csproj", "BornToCode_API/"]
RUN dotnet restore "BornToCode_API/BornToCode_API.csproj"
COPY . .
WORKDIR "/src/BornToCode_API"
RUN dotnet build "BornToCode_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BornToCode_API.csproj" -c Release -o /app/publish

# Build js app
FROM node AS node-builder
WORKDIR /node
COPY ./BornToCode_Frontend /node
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node-builder /node/dist ./dist
ENTRYPOINT ["dotnet", "BornToCode_API.dll"]
