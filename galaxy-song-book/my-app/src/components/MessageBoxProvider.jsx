import React, { useEffect, useState } from 'react';
import MessageBoxService from '../services/MessageBoxService';
import './MessageBoxProvider.css';

const MessageBoxContext = React.createContext();

const TYPE_CONFIG = {
  success: { icon: 'bi bi-check-lg',       iconClass: 'ml-msgbox-icon-success', title: 'Success' },
  danger:  { icon: 'bi bi-exclamation-lg',  iconClass: 'ml-msgbox-icon-danger',  title: 'Error'   },
  info:    { icon: 'bi bi-info-lg',         iconClass: 'ml-msgbox-icon-info',    title: 'Info'    },
  warning: { icon: 'bi bi-exclamation-triangle', iconClass: 'ml-msgbox-icon-warning', title: 'Warning' },
};

export function MessageBoxProvider({ children }) {
  const [options, setOptions] = useState(MessageBoxService.options);

  useEffect(() => {
    const unsubscribe = MessageBoxService.subscribe(setOptions);
    return unsubscribe;
  }, []);

  const cfg = TYPE_CONFIG[options.type] ?? TYPE_CONFIG.info;
  const isConfirm = Boolean(options.onConfirm);

  return (
    <MessageBoxContext.Provider value={MessageBoxService}>
      {children}
      {options.show && (
        <>
          <div className="ml-msgbox-backdrop" onClick={() => MessageBoxService.close()} />
          <div className="ml-msgbox-wrap" role="dialog" aria-modal="true">
            <div className="ml-msgbox">
              <div className="ml-msgbox-header">
                <div className={`ml-msgbox-icon ${cfg.iconClass}`}>
                  <i className={cfg.icon} aria-hidden="true" />
                </div>
                <h5 className="ml-msgbox-title">
                  {options.title
                    ? options.title
                    : isConfirm
                      ? (options.type === 'danger' ? 'Are you sure?' : 'Confirm')
                      : cfg.title}
                </h5>
              </div>

              <div className="ml-msgbox-body">
                {options.message}
              </div>

              <div className="ml-msgbox-footer">
                {isConfirm ? (
                  <>
                    <button
                      className="ml-msgbox-btn ml-msgbox-btn-cancel"
                      onClick={() => MessageBoxService.close()}
                    >
                      {options.cancelText || 'Cancel'}
                    </button>
                    <button
                      className={`ml-msgbox-btn ${options.type === 'danger' ? 'ml-msgbox-btn-confirm-danger' : 'ml-msgbox-btn-confirm'}`}
                      onClick={() => MessageBoxService.confirm()}
                    >
                      {options.confirmText || 'Confirm'}
                    </button>
                  </>
                ) : (
                  <button
                    className="ml-msgbox-btn ml-msgbox-btn-confirm"
                    onClick={() => MessageBoxService.close()}
                  >
                    {options.confirmText || 'Okay'}
                  </button>
                )}
              </div>
            </div>
          </div>
        </>
      )}
    </MessageBoxContext.Provider>
  );
}

export default MessageBoxContext;
