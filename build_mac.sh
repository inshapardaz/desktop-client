cd src
cd api
cd api
dotnet restore
dotnet publish --configuration release --self-contained -r osx-x64 --output ../bin/dist/osx
cd ..
cd ..
cd app
npm version %TRAVIS_BUILD_NUMBER% -m 'v%TRAVIS_BUILD_NUMBER'
npm install
npm run electron:mac