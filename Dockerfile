FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8020
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TovutiAPI.csproj", "."]
RUN dotnet restore "./TovutiAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TovutiAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TovutiAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TovutiAPI.dll", "--environment=Production"]