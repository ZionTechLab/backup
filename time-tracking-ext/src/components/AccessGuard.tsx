import React, { useEffect, useState } from 'react';
import { isUserInGroup } from '../services/GroupMembershipService';

interface Props {
  groupName: string;
  children: React.ReactNode;
}

export function AccessGuard({ groupName, children }: Props) {
  const [state, setState] = useState<'loading' | 'allowed' | 'denied'>('loading');

  useEffect(() => {
    isUserInGroup(groupName)
      .then(allowed => setState(allowed ? 'allowed' : 'denied'))
      .catch(() => setState('denied'));
  }, [groupName]);

  if (state === 'loading') {
    return <div className="access-guard-loading">Checking permissions…</div>;
  }

  if (state === 'denied') {
    return (
      <div className="access-guard-denied">
        <span className="access-guard-denied__icon">🔒</span>
        <p>You don't have permission to view this page.</p>
        <p className="access-guard-denied__hint">
          Contact your administrator to be added to the <strong>{groupName}</strong> group.
        </p>
      </div>
    );
  }

  return <>{children}</>;
}
