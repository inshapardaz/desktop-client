const electron = require('electron')
// Module to control application life.
const app = electron.app
// Module to create native browser window.
const BrowserWindow = electron.BrowserWindow

const path = require('path')
const url = require('url')

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mainWindow

function isDebug() {
  if (!process.env.NODE_ENV){
    return false;
  }
  
  var env = process.env.NODE_ENV.trim();
  return env === "dev";
};


require('electron-reload')(path.join(__dirname, 'dist'));

console.log(`========================================`);
console.log(`Inshapardaz version ${app.getVersion()}`);
console.log(`========================================`);
function createWindow() {
  console.log('INFO : Creating window...');

  const PROTOCOL = 'file';

  electron.protocol.interceptFileProtocol(PROTOCOL, (request, callback) => {
      // // Strip protocol
      let url = request.url.substr(PROTOCOL.length + 1);

      if (isDebug()){
        url = path.join(__dirname, 'dist', url);
      }
      else {
        url = path.join(__dirname, url);
      }

      // Replace backslashes by forward slashes (windows)
      // url = url.replace(/\\/g, '/');
      url = path.normalize(url);

      console.log(url);
      callback({path: url});
  });

  // Create the browser window.
  mainWindow = new BrowserWindow({ 
    width: 800, 
    height: 600,
    icon: path.join(__dirname, 'images/favicons/favicon-96x96.png')
  })
  var dist = path.resolve(__dirname);
  console.log('INFO : Window created. Loading main page ...');
  
  setTimeout(() => 
  mainWindow.loadURL(
    url.format({
      pathname: 'index.html',
      protocol: PROTOCOL + ':',
      slashes: true
    })
), 1000);

  if (isDebug()){
    mainWindow.webContents.openDevTools();
  } else {
    mainWindow.setMenu(null);
  }

  mainWindow.on('closed', function () {
    console.log('INFO : Window closing down...');
    mainWindow = null;
  })
}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', startApi)

// Quit when all windows are closed.
app.on('window-all-closed', function () {
  // On OS X it is common for applications and their menu bar
  // to stay active until the user quits explicitly with Cmd + Q
  if (process.platform !== 'darwin') {
    console.log('INFO : All windows closed. Shutting down ...');
    app.quit()
  }
})

app.on('activate', function () {
  // On OS X it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (mainWindow === null) {
    createWindow()
  }
})
// In this file you can include the rest of your app's specific main process
// code. You can also put them in separate files and require them here.


const os = require('os');
var apiProcess = null;

function startApi() {
  if (isDebug()){
    console.log(`DEBUG : Running in debug mode. Start apis manually.`);
    if (mainWindow == null) {
      createWindow();
    }

    return;
  }

  var proc = require('child_process').spawn;
  //  run server
  var apipath = path.join(__dirname, '..\\api\\bin\\dist\\win\\Inshapardaz.Desktop.API.exe')
  if (os.platform() === 'darwin') {
    apipath = path.join(__dirname, '..//api//bin//dist//osx//Inshapardaz.Desktop.API')
  }
  console.log(`INFO : API Starting from path ${apipath}`);
  apiProcess = proc(apipath)

  apiProcess.stdout.on('data', (data) => {
    writeLog(`API: ${data}`);
    if (mainWindow == null) {
      createWindow();
    }
  });
}

//Kill process when electron exits
process.on('exit', function () {
  writeLog('INFO : exit');
  if (apiProcess != null){
    apiProcess.kill();
  }
});

function writeLog(msg) {
  console.log(msg);
}