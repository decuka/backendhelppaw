#!/bin/bash
echo "Applying EF Core migrations..."

dotnet ef database update --project /app/HelPaw.csproj --startup-project /app/HelPaw.csproj

echo "Starting application..."
dotnet /app/publish/HelPaw.dll
