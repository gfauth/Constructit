FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ControleCondominal/ControleCondominal.csproj", "ControleCondominal/"]
RUN dotnet restore "ControleCondominal/ControleCondominal.csproj"
COPY . .
WORKDIR "/src/ControleCondominal"
RUN dotnet build "ControleCondominal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControleCondominal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControleCondominal.dll"]