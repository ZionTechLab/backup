import '../styles.css';
import React, { useState } from 'react';
import { createRoot } from 'react-dom/client';
import * as SDK from 'azure-devops-extension-sdk';
import { IWorkItemLoadedArgs, IWorkItemChangedArgs } from 'azure-devops-extension-api/WorkItemTracking';
import { TimeTracker } from '../components/TimeTracker';
import { UserRef } from '../models/TimeEntry';

interface AppState {
  workItemId: number;
  isNew: boolean;
  currentUser: UserRef;
}

let setAppState: ((s: AppState) => void) | null = null;
let reloadEntries: (() => void) | null = null;

function App() {
  const [state, setState] = useState<AppState | null>(null);
  const [reload, setReload] = useState(0);

  React.useEffect(() => {
    setAppState = (s: AppState) => setState(s);
    reloadEntries = () => setReload(n => n + 1);
    return () => {
      setAppState = null;
      reloadEntries = null;
    };
  }, []);

  if (!state) {
    return <div className="tt-root loading-state">Initialising…</div>;
  }

  return (
    <TimeTracker
      key={`${state.workItemId}-${reload}`}
      workItemId={state.workItemId}
      isNew={state.isNew}
      currentUser={state.currentUser}
    />
  );
}

SDK.init();

const root = createRoot(document.getElementById('root')!);
root.render(<App />);

SDK.ready().then(async () => {
  const sdkUser = SDK.getUser();
  const currentUser: UserRef = {
    id: sdkUser.id,
    displayName: sdkUser.displayName,
  };

  SDK.register(SDK.getContributionId(), {
    onLoaded: async (args: IWorkItemLoadedArgs) => {
      if (setAppState) {
        setAppState({ workItemId: args.id, isNew: args.isNew, currentUser });
      }
    },
    onSaved: async (_args: IWorkItemChangedArgs) => {
      if (reloadEntries) reloadEntries();
    },
    onRefreshed: async (_args: IWorkItemChangedArgs) => {
      if (reloadEntries) reloadEntries();
    },
    onReset: async () => {},
    onFieldChanged: async () => {},
  });

  SDK.notifyLoadSucceeded();
});
