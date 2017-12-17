import { Injectable } from '@angular/core';

// If you import a module but never use any of the imported values other than as TypeScript types,
// the resulting javascript file will look as if you never imported the module at all.
import { ipcRenderer, shell } from 'electron';
import * as childProcess from 'child_process';
import { win32 } from 'path';

@Injectable()
export class ElectronService {

  ipcRenderer: typeof ipcRenderer;
  childProcess: typeof childProcess;
  shell: typeof shell;

  constructor() {
    // Conditional imports
    if (this.isElectron()) {
      this.ipcRenderer = window.require('electron').ipcRenderer;
      this.childProcess = window.require('child_process');
      this.shell = window.require('electron').shell;
    }
  }

  isElectron = () => {
    return window && window.process && window.process.type;
  }

}
