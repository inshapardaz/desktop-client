cd src
cd api
cd api
dotnet restore
dotnet publish --configuration release --self-contained -r win-x86 --output ../bin/dist/win
cd ..
cd ..
cd app
@IF NOT "%APPVEYOR_BUILD_VERSION%"=="" npm version %APPVEYOR_BUILD_VERSION% -m 'v%APPVEYOR_BUILD_VERSION
call npm install 
call npm run electron:windows