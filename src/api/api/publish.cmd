dotnet restore
REM publish for windows
dotnet publish -r win10-x64 --output ../bin/dist/win
REM publish for macos
dotnet publish -r osx.10.11-x64 --output ../bin/dist/osx