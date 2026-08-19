import '../styles.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import * as SDK from 'azure-devops-extension-sdk';
import { Settings } from '../components/Settings';
import { AccessGuard } from '../components/AccessGuard';

SDK.init();

SDK.ready().then(() => {
  const root = createRoot(document.getElementById('root')!);
  root.render(
    <AccessGuard groupName="tt-pm">
      <Settings />
    </AccessGuard>
  );
  SDK.notifyLoadSucceeded();
});
