import { app, BrowserWindow, screen } from 'electron';
import * as path from 'path';
const url = require('url')

const electron = require('electron')

let win, serve;
const args = process.argv.slice(1);
serve = args.some(val => val === '--serve');

if (serve) {
  require('electron-reload')(__dirname, {
  });
}

function createWindow() {
  const electronScreen = screen;
  const size = electronScreen.getPrimaryDisplay().workAreaSize;

  // Create the browser window.
  win = new BrowserWindow({
    x: 0,
    y: 0,
    width: size.width,
    height: size.height,
    icon: path.join(__dirname, 'images/favicons/96x96.png')
  });

  // and load the index.html of the app.
  win.loadURL('file://' + __dirname + '/index.html');

  // Open the DevTools.
  if (serve) {
    win.webContents.openDevTools();
  }

  if (!serve) {
    startApi();
  }

  // Emitted when the window is closed.
  win.on('closed', () => {
    win = null;
  });

  app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') {
      console.log('INFO : All windows closed. Shutting down ...');
      app.quit()
    }
  })
}

try {

  app.on('ready', createWindow);

  app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
      app.quit();
    }
  });

  app.on('activate', () => {
    if (win === null) {
      createWindow();
    }
  });

} catch (e) {
  // Catch Error
  // throw e;
}


const os = require('os');
let apiProcess = null;

function startApi() {
  const proc = require('child_process').spawn;

  //  run server
  console.log(`Running on ${os.platform()}`);
  let apiPath = path.join(__dirname, './../api/Inshapardaz.Desktop.API.exe');
  if (os.platform() === 'darwin') {
    apiPath = path.join(__dirname, './/..//api//Inshapardaz.Desktop.API')
  }
  else if (os.platform() === 'linux'){
    apiPath = path.join(__dirname, './/..//api//Inshapardaz.Desktop.API')
  }

  console.log(`INFO : API Starting from path ${apiPath}`);
  apiProcess = proc(apiPath)

  apiProcess.stdout.on('data', (data) => {
    process.stdout.write(`API: ${data}`);
  });
}


app.on('will-quit', function () {
  writeLog('INFO : exit');
  if (apiProcess != null) {
    apiProcess.kill();
  }
});

// app.on('uncaughtException', function (error) {
//   writeLog(`CRITICAL : ${error}`);
// });

function writeLog(msg) {
  console.log(msg);
}
