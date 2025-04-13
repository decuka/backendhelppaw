FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy only .csproj files to cache restore step
COPY *.csproj ./

RUN dotnet restore

# Copy the rest of the app
COPY . ./

RUN dotnet build -c Release

RUN dotnet publish -c Release -o /app/publish

RUN dotnet tool install --global dotnet-ef

ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy entrypoint script and make it executable
COPY entrypoint.sh /app/publish/entrypoint.sh
RUN chmod +x /app/publish/entrypoint.sh

WORKDIR /app/publish

ENTRYPOINT ["/app/publish/entrypoint.sh"]
