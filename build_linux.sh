cd src
cd api
cd api
dotnet restore
dotnet publish --configuration release --self-contained -r linux-x64 --output ../bin/dist/linux64
cd ..
cd ..
cd app
sudo apt install icnsutils
echo $TRAVIS_BUILD_NUMBER
npm version 1.1.$TRAVIS_BUILD_NUMBER -m 'v1.1.$TRAVIS_BUILD_NUMBER'
npm install
npm run electron:linux