dotnet publish UpdateVersionInfo.csprj -r win-x64 -p:PublishSingleFile=true --self-contained true
dotnet publish UpdateVersionInfo.sln -r win-arm64 -p:PublishSingleFile=true --self-contained true
dotnet publish UpdateVersionInfo.sln -r osx-x64 -p:PublishSingleFile=true --self-contained true
dotnet publish UpdateVersionInfo.sln -r osx-arm64 -p:PublishSingleFile=true --self-contained true
