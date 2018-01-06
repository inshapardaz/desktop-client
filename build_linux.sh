cd src
cd api
cd api
dotnet restore
dotnet publish --configuration release --self-contained -r linux-x64 --output ../bin/dist/linux64
cd ..
cd ..
cd app
npm version %APPVEYOR_BUILD_VERSION% -m 'v%APPVEYOR_BUILD_VERSION
npm install
npm run electron:linux