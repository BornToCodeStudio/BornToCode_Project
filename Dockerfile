FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EntityModels.Postgresql/EntityModels.Postgresql.csproj", "EntityModels.Postgresql/"]
COPY ["DataContext.Postgresql/DataContext.Postgresql.csproj", "DataContext.Postgresql/"]
COPY ["BornToCodeWebApp/BornToCodeWebApp.csproj", "BornToCodeWebApp/"]
RUN dotnet restore "BornToCodeWebApp/BornToCodeWebApp.csproj"
COPY . .
WORKDIR "/src/BornToCodeWebApp"
RUN dotnet build "BornToCodeWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BornToCodeWebApp.csproj" -c Release -o /app/publish

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
ENTRYPOINT ["dotnet", "BornToCodeWebApp.dll"]
