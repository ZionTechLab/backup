import { useEffect, useState, useMemo, useCallback } from 'react';
import { useDispatch } from 'react-redux';
import MeridianPage from '../Meridian/MeridianPage';
import PermissionGate from '../../components/PermissionGate';
import MessageBoxService from '../../services/MessageBoxService';
import { reloadInitData } from '../auth';
import ApiService from './service';
import MenuEditorModal from './MenuEditorModal';
import './MenuArrange.css';

const BLANK = { id: null, parentId: 0, route: '', displayName: '', icon: 'bi bi-dot', isGroup: false, isActive: true };

export default function MenuArrange() {
  const dispatch = useDispatch();
  const [items, setItems] = useState([]);
  const [roles, setRoles] = useState([]);
  const [grants, setGrants] = useState({});      // id -> Set(roleId)
  const [dirty, setDirty] = useState(false);
  const [dragId, setDragId] = useState(null);
  const [editor, setEditor] = useState(null);    // the item being created/edited
  const [loading, setLoading] = useState(true);

  const load = useCallback(async () => {
    setLoading(true);
    const { success, data } = await ApiService.getAll();
    if (success) {
      setItems((data.menus || []).map((m) => ({ ...m, isGroup: !!m.isGroup, isActive: !!m.isActive })));
      setRoles(data.roles || []);
      const g = {};
      (data.grants || []).forEach((row) => { (g[row.id] = g[row.id] || new Set()).add(row.roleId); });
      setGrants(g);
    }
    setDirty(false);
    setLoading(false);
  }, []);

  useEffect(() => { load(); }, [load]);

  // Children of a parent, ordered.
  const childrenOf = useMemo(() => {
    const map = {};
    for (const it of items) (map[it.parentId] = map[it.parentId] || []).push(it);
    for (const k of Object.keys(map)) map[k].sort((a, b) => (a.order ?? 0) - (b.order ?? 0));
    return map;
  }, [items]);

  // Renumber every sibling group 1..n after a structural change.
  const renumber = (list) => {
    const byParent = {};
    for (const it of list) (byParent[it.parentId] = byParent[it.parentId] || []).push(it);
    for (const k of Object.keys(byParent)) {
      byParent[k].sort((a, b) => (a.order ?? 0) - (b.order ?? 0));
      byParent[k].forEach((it, i) => { it.order = i + 1; });
    }
    return [...list];
  };

  const isDescendant = (candidateId, ofId) => {
    // Is candidateId inside the subtree rooted at ofId?
    let stack = [ofId];
    while (stack.length) {
      const cur = stack.pop();
      const kids = childrenOf[cur] || [];
      for (const k of kids) {
        if (k.id === candidateId) return true;
        stack.push(k.id);
      }
    }
    return false;
  };

  // Move `dragId` to sit right after `targetId` under `parentId`. If targetId
  // is null, drop at the end of parentId's children.
  const moveItem = (id, parentId, targetId) => {
    if (id === parentId) return;
    if (isDescendant(parentId, id)) {
      MessageBoxService.show({ message: 'Cannot move a menu into its own child.', type: 'danger' });
      return;
    }
    setItems((prev) => {
      const next = prev.map((it) => ({ ...it }));
      const moved = next.find((it) => it.id === id);
      if (!moved) return prev;
      moved.parentId = parentId;
      // Give it an order just after the target within the new parent.
      const siblings = next.filter((it) => it.parentId === parentId && it.id !== id).sort((a, b) => a.order - b.order);
      let insertAfter = targetId != null ? siblings.findIndex((s) => s.id === targetId) : siblings.length - 1;
      moved.order = (insertAfter >= 0 ? (siblings[insertAfter].order ?? 0) : 0) + 0.5;
      return renumber(next);
    });
    setDirty(true);
  };

  const bump = (id, dir) => {
    setItems((prev) => {
      const next = prev.map((it) => ({ ...it }));
      const me = next.find((it) => it.id === id);
      const sibs = next.filter((it) => it.parentId === me.parentId).sort((a, b) => a.order - b.order);
      const i = sibs.findIndex((s) => s.id === id);
      const j = dir === 'up' ? i - 1 : i + 1;
      if (j < 0 || j >= sibs.length) return prev;
      const a = sibs[i].order; sibs[i].order = sibs[j].order; sibs[j].order = a;
      return renumber(next);
    });
    setDirty(true);
  };

  const saveArrangement = async () => {
    const payload = items.map((it) => ({ id: it.id, parentId: it.parentId, order: it.order }));
    const { success } = await ApiService.arrange(payload);
    if (success) {
      setDirty(false);
      dispatch(reloadInitData());
      MessageBoxService.show({ message: 'Menu arrangement saved.', type: 'success' });
    }
  };

  const saveItem = async () => {
    if (!editor.displayName.trim() || !editor.route.trim() || !editor.icon.trim()) {
      MessageBoxService.show({ message: 'Name, route and icon are required.', type: 'danger' });
      return;
    }
    const { success } = await ApiService.save({
      id: editor.id, parentId: Number(editor.parentId), route: editor.route.trim(),
      displayName: editor.displayName.trim(), icon: editor.icon.trim(),
      isGroup: !!editor.isGroup, isActive: !!editor.isActive,
    });
    if (success) {
      setEditor(null);
      await load();
      dispatch(reloadInitData());
      MessageBoxService.show({ message: 'Menu item saved.', type: 'success' });
    }
  };

  const toggleGrant = async (id, roleId) => {
    const set = new Set(grants[id] || []);
    if (set.has(roleId)) set.delete(roleId); else set.add(roleId);
    setGrants((g) => ({ ...g, [id]: set }));
    const { success } = await ApiService.setGrants(id, [...set]);
    if (!success) load();
  };

  const parentOptions = useMemo(
    () => [{ id: 0, label: '(Top level)' }].concat(items.filter((i) => i.isGroup).map((i) => ({ id: i.id, label: i.displayName }))),
    [items]
  );

  const renderRow = (item, depth) => {
    const kids = childrenOf[item.id] || [];
    return (
      <div key={item.id}>
        <div
          className={`ml-menu-row${dragId === item.id ? ' is-dragging' : ''}`}
          style={{ paddingLeft: 8 + depth * 22 }}
          draggable
          onDragStart={() => setDragId(item.id)}
          onDragEnd={() => setDragId(null)}
          onDragOver={(e) => e.preventDefault()}
          onDrop={(e) => { e.preventDefault(); e.stopPropagation(); if (dragId && dragId !== item.id) moveItem(dragId, item.parentId, item.id); }}
        >
          <i className="bi bi-grip-vertical ml-menu-grip" aria-hidden="true" />
          <i className={`${item.icon} ml-menu-icon`} aria-hidden="true" />
          <span className="ml-menu-name">{item.displayName}</span>
          {item.isGroup && <span className="ml-badge ml-badge-locked">Group</span>}
          {!item.isActive && <span className="ml-badge ml-badge-void">Off</span>}
          <span className="ml-menu-route">{item.route}</span>

          <span className="ml-menu-roles">
            {roles.map((r) => {
              const on = (grants[item.id] || new Set()).has(r.id);
              return (
                <button key={r.id} type="button"
                  className={`ml-menu-role${on ? ' on' : ''}`}
                  title={`${on ? 'Hide from' : 'Show to'} ${r.roleName}`}
                  onClick={() => toggleGrant(item.id, r.id)}>
                  {r.roleName.slice(0, 3)}
                </button>
              );
            })}
          </span>

          <span className="ml-menu-actions">
            <button type="button" className="btn btn-sm btn-borderless" title="Move up" aria-label="Move up" onClick={() => bump(item.id, 'up')}><i className="bi bi-arrow-up" /></button>
            <button type="button" className="btn btn-sm btn-borderless" title="Move down" aria-label="Move down" onClick={() => bump(item.id, 'down')}><i className="bi bi-arrow-down" /></button>
            <button type="button" className="btn btn-sm btn-borderless" title="Edit" aria-label="Edit" onClick={() => setEditor({ ...item })}><i className="bi bi-pencil" /></button>
            {item.isGroup && (
              <button type="button" className="btn btn-sm btn-borderless" title="Add item here" aria-label="Add item here"
                onClick={() => setEditor({ ...BLANK, parentId: item.id })}><i className="bi bi-plus-lg" /></button>
            )}
          </span>
        </div>
        {kids.map((k) => renderRow(k, depth + 1))}
      </div>
    );
  };

  const roots = childrenOf[0] || [];

  return (
    <MeridianPage title="Menu Arrangement" cardClass="ml-form-card"
      actions={
        <>
          <button type="button" className="ml-btn-ghost ml-fab-1" onClick={() => setEditor({ ...BLANK })}>
            <i className="bi bi-plus-lg" aria-hidden="true" /> New Item
          </button>
          <button type="button" className="ml-btn-action ml-fab" onClick={saveArrangement} disabled={!dirty}>
            <i className="bi bi-check-lg" aria-hidden="true" /> Save Arrangement
          </button>
        </>
      }
    >
      <PermissionGate codes="menu-manage" mode="message">
        {dirty && <div className="alert alert-warning py-2">Unsaved arrangement changes. Click Save Arrangement.</div>}
        <div className="ml-menu-tree"
          onDragOver={(e) => e.preventDefault()}
          onDrop={(e) => { e.preventDefault(); if (dragId) moveItem(dragId, 0, null); }}>
          {loading ? <div className="text-muted p-3">Loading...</div> : roots.map((r) => renderRow(r, 0))}
        </div>

        {editor && (
          <MenuEditorModal
            editor={editor}
            setEditor={setEditor}
            parentOptions={parentOptions}
            onSave={saveItem}
          />
        )}
      </PermissionGate>
    </MeridianPage>
  );
}
