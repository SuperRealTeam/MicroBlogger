# Stage 1: Build the API Application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/MicroBlogger.Api/MicroBlogger.Api.csproj", "src/MicroBlogger.Api/"]
COPY ["src/MicroBlogger.Application/MicroBlogger.Application.csproj", "src/MicroBlogger.Application/"]
COPY ["src/MicroBlogger.Domain/MicroBlogger.Domain.csproj", "src/MicroBlogger.Domain/"]
COPY ["src/MicroBlogger.Infrastructure/MicroBlogger.Infrastructure.csproj", "src/MicroBlogger.Infrastructure/"]
COPY ["src/MicroBlogger.ServiceDefaults/MicroBlogger.ServiceDefaults.csproj", "src/MicroBlogger.ServiceDefaults/"]
COPY ["src/Migrators/Migrators.MSSQL/Migrators.MSSQL.csproj", "src/Migrators/Migrators.MSSQL/"]
COPY ["src/Migrators/Migrators.PostgreSQL/Migrators.PostgreSQL.csproj", "src/Migrators/Migrators.PostgreSQL/"]
COPY ["src/Migrators/Migrators.SQLite/Migrators.SQLite.csproj", "src/Migrators/Migrators.SQLite/"]

RUN dotnet restore "src/MicroBlogger.Api/MicroBlogger.Api.csproj"

COPY . .
WORKDIR /src/src/MicroBlogger.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build /app/publish .

# Install OpenSSL
RUN apt-get update && apt-get install -y openssl

# Generate a self-signed certificate
RUN mkdir -p /app/https && \
    openssl req -x509 -newkey rsa:4096 -sha256 -days 3650 -nodes \
    -keyout /app/https/private.key -out /app/https/certificate.crt \
    -subj "/C=US/ST=State/L=City/O=Organization/CN=localhost" && \
    openssl pkcs12 -export -out /app/https/aspnetapp.pfx \
    -inkey /app/https/private.key -in /app/https/certificate.crt \
    -password pass:CREDENTIAL_PLACEHOLDER


# Setup environment variables for the application to find the certificate
ENV ASPNETCORE_URLS=http://+:80;https://+:443
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="CREDENTIAL_PLACEHOLDER"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/https/aspnetapp.pfx"


# Expose ports
EXPOSE 80 443

# Set the environment variable for ASP.NET Core to use Production settings
ENV ASPNETCORE_ENVIRONMENT=Development

# Start the application
ENTRYPOINT ["dotnet", "MicroBlogger.Api.dll"]
