import { useSelector } from 'react-redux';
import { selectPermissions } from '../../features/auth';
import './PermissionGate.css';

// Returns true if the user holds any of the given permission codes. OR semantics.
export function useHasPermission(codes) {
  const permissions = useSelector(selectPermissions);
  if (!codes || (Array.isArray(codes) && codes.length === 0)) return true;
  const list = Array.isArray(codes) ? codes : [codes];
  return list.some((c) => permissions.includes(c));
}

// Gates its children by permission code.
//   codes: a code or array of codes. Access granted if the user holds any.
//   mode:  'hide' removes the content, 'message' shows an access-denied card.
export default function PermissionGate({ codes, mode = 'hide', children }) {
  const allowed = useHasPermission(codes);
  if (allowed) return children;
  if (mode === 'message') {
    return (
      <div className="ml-perm-denied">
        <i className="bi bi-shield-lock" aria-hidden="true" />
        <div>
          <div className="ml-perm-denied-title">Access denied</div>
          <div className="ml-perm-denied-sub">You do not have permission to view this content.</div>
        </div>
      </div>
    );
  }
  return null;
}
