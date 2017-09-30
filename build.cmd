@Echo -----------------------------------
@Echo Building inshapardaz desktop client
@Echo -----------------------------------
@pushd src
@pushd api
@pushd api
@Echo ====== Building local api packages ======
@dotnet restore
@Echo ====== Publishing api for windows ======
@dotnet publish --configuration release -r win10-x64 --output ../bin/dist/win
@Echo ====== Publishing api for macos ======
@dotnet publish --configuration release -r osx.10.11-x64 --output ../bin/dist/osx
@Echo ====== Finish building local api packages ======

@popd
@popd
@pushd app
@Echo ====== Restore node packages ======
@call npm install
@Echo ====== Building SPA ======
@call webpack -p --config ./config/webpack.prod.js -p
@Echo ====== Packaging application ======
@call npm run dist 
@popd
@popd
@popd

@Echo Finished building inshapardaz desktop client
@Echo -----------------------------------