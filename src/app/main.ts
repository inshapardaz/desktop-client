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

  // const PROTOCOL = 'file';

  // electron.protocol.interceptFileProtocol(PROTOCOL, (request, callback: Function) => {
  //   let reqUrl = request.url.substr(PROTOCOL.length + 1);
  //   reqUrl = path.join(__dirname, reqUrl);

  //   reqUrl = path.normalize(reqUrl);

  //   console.log(reqUrl);
  //   callback({ path: reqUrl });
  // });

  const electronScreen = screen;
  const size = electronScreen.getPrimaryDisplay().workAreaSize;

  // Create the browser window.
  win = new BrowserWindow({
    x: 0,
    y: 0,
    width: size.width,
    height: size.height,
    icon: path.join(__dirname, 'images/favicons/favicon-96x96.png')
  });

  // and load the index.html of the app.
  win.loadURL('file://' + __dirname + '/index.html');

  // setTimeout(() => win.loadURL(
  //   url.format({
  //     pathname: 'index.html',
  //     protocol:  PROTOCOL + ':',
  //     slashes: true
  //   })
  // ), 1000);

  // Open the DevTools.
  if (serve) {
    win.webContents.openDevTools();
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

  // This method will be called when Electron has finished
  // initialization and is ready to create browser windows.
  // Some APIs can only be used after this event occurs.
  app.on('ready', createWindow);

  // Quit when all windows are closed.
  app.on('window-all-closed', () => {
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if (process.platform !== 'darwin') {
      app.quit();
    }
  });

  app.on('activate', () => {
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
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
  let apipath = path.join(__dirname, '..\\api\\bin\\dist\\win\\Inshapardaz.Desktop.API.exe')
  if (os.platform() === 'darwin') {
    apipath = path.join(__dirname, '..//api//bin//dist//osx//Inshapardaz.Desktop.API')
  }
  console.log(`INFO : API Starting from path ${apipath}`);
  apiProcess = proc(apipath)

  apiProcess.stdout.on('data', (data) => {
    writeLog(`API: ${data}`);
    if (win == null) {
      createWindow();
    }
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
