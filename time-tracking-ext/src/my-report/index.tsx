import '../styles.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import * as SDK from 'azure-devops-extension-sdk';
import { MyReport } from '../components/my-report/MyReport';

SDK.init();

SDK.ready().then(() => {
  const root = createRoot(document.getElementById('root')!);
  root.render(<MyReport />);
  SDK.notifyLoadSucceeded();
});
