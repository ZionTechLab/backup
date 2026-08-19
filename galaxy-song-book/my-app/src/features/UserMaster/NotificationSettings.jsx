import { useState } from 'react';
import MessageBoxService from '../../services/MessageBoxService';

function NotificationSettings() {
  const [notifications, setNotifications] = useState({
    newAssignment: true,
    approvalRequests: true,
    tbdResolution: true,
    weeklyDigest: false,
    mobilePush: false,
    desktopNotifications: true,
  });

  const handleToggle = (key) => {
    setNotifications((prev) => {
      const updated = { ...prev, [key]: !prev[key] };
      MessageBoxService.show({
        message: `Notification preference updated`,
        type: 'success',
      });
      return updated;
    });
  };

  const notificationOptions = [
    {
      key: 'newAssignment',
      title: 'New Assignment',
      description: 'When you are assigned a new activity',
    },
    {
      key: 'approvalRequests',
      title: 'Approval Requests',
      description: 'When an item needs your approval',
    },
    {
      key: 'tbdResolution',
      title: 'TBD Resolution',
      description: 'When TBD activities are resolved',
    },
    {
      key: 'weeklyDigest',
      title: 'Weekly Digest',
      description: 'Summary of weekly activities',
    },
    {
      key: 'mobilePush',
      title: 'Mobile Push',
      description: 'Push notifications to mobile app',
    },
    {
      key: 'desktopNotifications',
      title: 'Desktop Notifications',
      description: 'Browser notifications',
    },
  ];

  return (
    <div className="container-fluid p-4">
      <h4 className="mb-4">Notifications</h4>
      <p className="text-muted mb-4">Configure how and when you receive alerts</p>

      <div className="row g-4">
        <div className="col-12">
          <div className="card">
            <div className="card-body">
              <div className="space-y-2">
                {notificationOptions.map((option) => (
                  <div
                    key={option.key}
                    className="d-flex justify-content-between align-items-center p-3 border rounded"
                  >
                    <div>
                      <div className="fw-semibold">{option.title}</div>
                      <div className="text-muted small">{option.description}</div>
                    </div>
                    <div className="form-check form-switch ms-3 flex-shrink-0">
                      <input
                        className="form-check-input"
                        type="checkbox"
                        id={`notif-${option.key}`}
                        checked={notifications[option.key]}
                        onChange={() => handleToggle(option.key)}
                        style={{ cursor: 'pointer', width: '3em', height: '1.5em' }}
                      />
                    </div>
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default NotificationSettings;
