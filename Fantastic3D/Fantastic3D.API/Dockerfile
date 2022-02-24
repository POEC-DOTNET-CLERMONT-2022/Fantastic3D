#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Fantastic3D.API/Fantastic3D.API.csproj", "Fantastic3D.API/"]
COPY ["Fantastic3D.AppModels/Fantastic3D.AppModels.csproj", "Fantastic3D.AppModels/"]
COPY ["Fantastic3D.Dto/Fantastic3D.Dto.csproj", "Fantastic3D.Dto/"]
COPY ["Fantastic3D.DataManager/Fantastic3D.DataManager.csproj", "Fantastic3D.DataManager/"]
COPY ["Persistence/Fantastic3D.Persistence.csproj", "Persistence/"]
RUN dotnet restore "Fantastic3D.API/Fantastic3D.API.csproj"
COPY . .
WORKDIR "/src/Fantastic3D.API"
RUN dotnet build "Fantastic3D.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fantastic3D.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fantastic3D.API.dll"]