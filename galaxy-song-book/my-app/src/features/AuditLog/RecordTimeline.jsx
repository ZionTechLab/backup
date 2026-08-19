import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import MeridianPage from "../Meridian/MeridianPage";
import { IdCell } from "../../components/DataTable/IdCell";
import AuditLogService from "./service";
import { formatDateTime } from "../../helpers/transformDateFields";
import "./audit-log.css";

const TYPE_META = {
  E: { label: "Update",       color: "#6ea8fe" },
  D: { label: "Delete",       color: "#f85149" },
  I: { label: "Create",       color: "#d2a8ff" },
  L: { label: "Login",        color: "#3fb950" },
  O: { label: "Logout",       color: "#8a90a2" },
  R: { label: "Refresh",      color: "#56d4dd" },
  F: { label: "Login failed", color: "#f0883e" },
};
const typeMeta = (t) => TYPE_META[t] ?? { label: t, color: "#6ea8fe" };

function parseSnap(s) {
  try { return JSON.parse(s) ?? {}; } catch { return {}; }
}

function fmt(v) {
  if (v === null || v === undefined || v === "") return "—";
  return typeof v === "object" ? JSON.stringify(v) : String(v);
}

// Fields that differ between two snapshots.
function diffFields(before, after) {
  const keys = new Set([...Object.keys(before || {}), ...Object.keys(after || {})]);
  const out = [];
  for (const k of keys) {
    if (JSON.stringify(before?.[k]) !== JSON.stringify(after?.[k])) {
      out.push({ field: k, before: before?.[k], after: after?.[k] });
    }
  }
  return out;
}

export default function RecordTimeline() {
  const { tableName, recordId } = useParams();
  const [entries, setEntries] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    (async () => {
      setLoading(true);
      const res = await AuditLogService.getRecord({ tableName, recordId });
      setEntries(res.success ? (res.data ?? []) : []);
      setLoading(false);
    })();
  }, [tableName, recordId]);

  const isAuth = tableName === "auth";

  // entries come oldest-first. The "after" of event i is the before-image of
  // event i+1; the newest event has no captured after (live row not in audit).
  const events = entries.map((e, i) => {
    const before = parseSnap(e.snapshot);
    const after = i + 1 < entries.length ? parseSnap(entries[i + 1].snapshot) : null;
    return { ...e, before, changes: after ? diffFields(before, after) : null };
  });
  const newestFirst = [...events].reverse();

  return (
    <MeridianPage title="Record History" backTo="/audit-log">
      <div className="al-tl-head">
        <span className="al-tl-entity">{tableName}</span>
        {!isAuth && <IdCell id={recordId} full />}
        {isAuth && <span className="dt-id-text">{recordId}</span>}
        <span className="al-tl-count">{entries.length} event{entries.length === 1 ? "" : "s"}</span>
      </div>

      {loading ? (
        <div className="al-card-empty">Loading…</div>
      ) : !events.length ? (
        <div className="al-card-empty">No history for this record</div>
      ) : (
        <div className="al-timeline">
          {newestFirst.map((ev) => {
            const m = typeMeta(ev.changeType);
            return (
              <div key={ev.historyId} className="al-tl-item">
                <span className="al-tl-dot" style={{ background: m.color }} />
                <div className="al-tl-body">
                  <div className="al-tl-meta">
                    <span className="al-badge" style={{ background: m.color + "22", color: m.color }}>{m.label}</span>
                    <span className="al-tl-when">{formatDateTime(Number(ev.changedAt))}</span>
                    <span className="al-tl-who">{ev.fullName || "Unknown"}</span>
                  </div>

                  {isAuth ? (
                    <div className="al-tl-fields">
                      {Object.entries(ev.before).map(([k, v]) => (
                        <div key={k} className="al-tl-row">
                          <span className="al-tl-field">{k}</span>
                          <span className="al-tl-val">{fmt(v)}</span>
                        </div>
                      ))}
                    </div>
                  ) : ev.changes ? (
                    ev.changes.length ? (
                      <div className="al-tl-fields">
                        {ev.changes.map((c) => (
                          <div key={c.field} className="al-tl-row">
                            <span className="al-tl-field">{c.field}</span>
                            <span className="al-tl-before">{fmt(c.before)}</span>
                            <span className="al-tl-arrow">→</span>
                            <span className="al-tl-after">{fmt(c.after)}</span>
                          </div>
                        ))}
                      </div>
                    ) : (
                      <div className="al-tl-note">No field changes recorded</div>
                    )
                  ) : (
                    <div className="al-tl-note">Latest change · values before this change shown below</div>
                  )}

                  {!isAuth && !ev.changes && (
                    <div className="al-tl-fields">
                      {Object.entries(ev.before).map(([k, v]) => (
                        <div key={k} className="al-tl-row">
                          <span className="al-tl-field">{k}</span>
                          <span className="al-tl-val">{fmt(v)}</span>
                        </div>
                      ))}
                    </div>
                  )}
                </div>
              </div>
            );
          })}
        </div>
      )}
    </MeridianPage>
  );
}
