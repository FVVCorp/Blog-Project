# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
# WORKDIR /src
# COPY ["UsersAPI.csproj", "WebAPI/UsersAPI/"]
# # COPY ["Application/Application.csproj", "Application/"]
# # COPY ["Infrastructure/Persistence.csproj", "Infrastructure/Persistence/"]
# # COPY ["Domain/Domain/Domain.csproj", "Domain/"]
# RUN dotnet restore "WebAPI/UsersAPI/UsersAPI.csproj"
# COPY . .
# WORKDIR "/src/WebAPI/UsersAPI"
# RUN dotnet build "UsersAPI.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "UsersAPI.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "UsersAPI.dll"]

# Authogenerated script 
# ----------------------------------------------------------
# Manually written script

# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# # ENV ASPNETCORE_URLS=https://*:5001
# # ENV ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword"
# # ENV ASPNETCORE_Kestrel__Certificates__Default__Path="%USERPROFILE%\.aspnet\https\usersapi.pfx"

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# WORKDIR /src
# COPY . .
# WORKDIR "/src/WebAPI/UsersAPI/"
# RUN dotnet build "UsersAPI.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "UsersAPI.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "UsersAPI.dll"]