dotnet publish UpdateVersionInfo.csproj -r win-x64 -p:PublishSingleFile=true --self-contained true
dotnet publish UpdateVersionInfo.csproj -r win-arm64 -p:PublishSingleFile=true --self-contained true
dotnet publish UpdateVersionInfo.csproj -r osx-x64 -p:PublishSingleFile=true --self-contained true
dotnet publish UpdateVersionInfo.csproj -r osx-arm64 -p:PublishSingleFile=true --self-contained true
