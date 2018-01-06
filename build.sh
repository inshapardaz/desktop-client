echo -----------------------------------
echo Building inshapardaz desktop client
echo -----------------------------------
cd ./src/api/API
echo ====== Building local api packages ======
dotnet restore
echo ====== Publishing api for linux ======
dotnet publish --configuration release -r linux-x64 --output ../bin/dist/linux
echo ====== Finish building local api packages ======
cd ./../../app
echo ====== Restore node packages ======
call npm install
echo ====== Building SPA ======
call node_modules/.bin/webpack -p --config ./config/webpack.prod.js -p
echo ====== Packaging application ======
call npm run dist 
cd ../../..
echo Finished building inshapardaz desktop client
echo -----------------------------------