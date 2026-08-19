import '../styles.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import * as SDK from 'azure-devops-extension-sdk';
import { UserUtilizationReport } from '../components/user-utilization-report/UserUtilizationReport';

SDK.init();

SDK.ready().then(() => {
  const root = createRoot(document.getElementById('root')!);
  root.render(<UserUtilizationReport />);
  SDK.notifyLoadSucceeded();
});
