cd src
cd api
cd api
dotnet restore
dotnet publish --configuration release --self-contained -r linux-x64 --output ../bin/dist/linux64
cd ..
cd ..
cd app
sudo apt install icnsutils
@IF NOT "%APPVEYOR_BUILD_VERSION%"=="" then npm version %APPVEYOR_BUILD_VERSION% -m 'v%APPVEYOR_BUILD_VERSION%'
call npm install
call npm run electron:linux