import { useEffect, useMemo, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  ResponsiveContainer, AreaChart, Area, CartesianGrid, XAxis, YAxis, Tooltip,
  PieChart, Pie, Cell, Legend, BarChart, Bar,
} from "recharts";
import { DataTable } from "../../components/DataTable/DataTable";
import MeridianPage from "../Meridian/MeridianPage";
import AuditLogService from "./service";
import { todayISO, formatDateTime } from "../../helpers/transformDateFields";
import DateInput from "../../components/DateInput/index.jsx";
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

const AXIS = "#8a90a2";
const GRID = "#2a2d3a";

const iso = (d) => todayISO(d);
function defaultFilters() {
  const to = new Date();
  const from = new Date();
  from.setDate(from.getDate() - 30);
  return { dateFrom: iso(from), dateTo: iso(to), tableName: "", changeType: "" };
}

function Card({ title, children, empty }) {
  return (
    <div className="al-card">
      <p className="al-card-title">{title}</p>
      {empty ? <div className="al-card-empty">No data</div> : children}
    </div>
  );
}

export default function AuditLog() {
  const navigate = useNavigate();
  const [filters, setFilters] = useState(defaultFilters);
  const [summary, setSummary] = useState(null);
  const [feed, setFeed] = useState([]);
  const [loading, setLoading] = useState(true);

  const load = async (f) => {
    setLoading(true);
    const params = { dateFrom: f.dateFrom, dateTo: f.dateTo };
    if (f.tableName) params.tableName = f.tableName;
    if (f.changeType) params.changeType = f.changeType;
    const [s, a] = await Promise.all([
      AuditLogService.getSummary(params),
      AuditLogService.getAll({ ...params, pageSize: 100 }),
    ]);
    setSummary(s.success ? s.data : null);
    setFeed(a.success ? (a.data?.rows ?? []) : []);
    setLoading(false);
  };

  useEffect(() => { load(filters); /* eslint-disable-next-line */ }, []);

  const setField = (k, v) => setFilters((prev) => ({ ...prev, [k]: v }));
  const apply = () => load(filters);
  const clear = () => { const d = defaultFilters(); setFilters(d); load(d); };

  const tableOptions = useMemo(
    () => (summary?.byTable ?? []).map((t) => t.tableName),
    [summary]
  );

  const subtitle = summary ? `${summary.total} events` : "Loading…";

  const columns = [
    { header: "WHEN", field: "changedAt", class: "text-nowrap", render: (r) => formatDateTime(Number(r.changedAt)) },
    {
      header: "ACTION", field: "changeType",
      render: (r) => {
        const m = typeMeta(r.changeType);
        return <span className="al-badge" style={{ background: m.color + "22", color: m.color }}>{m.label}</span>;
      },
    },
    { header: "ENTITY", field: "tableName", class: "text-nowrap" },
    { header: "RECORD", field: "recordId", isId: true },
    { header: "USER", field: "fullName", render: (r) => r.fullName || "-" },
  ];

  return (
    <MeridianPage title="Audit Log">
      <p className="ml-page-subtitle">{subtitle}</p>

      <form className="row g-2 align-items-end mb-3" onSubmit={(e) => { e.preventDefault(); apply(); }}>
        <div className="col-6 col-md-auto">
          <label className="form-label">From</label>
          <DateInput name="dateFrom" value={filters.dateFrom} onChange={(e) => setField("dateFrom", e.target.value)} />
        </div>
        <div className="col-6 col-md-auto">
          <label className="form-label">To</label>
          <DateInput name="dateTo" value={filters.dateTo} onChange={(e) => setField("dateTo", e.target.value)} />
        </div>
        <div className="col-12 col-md">
          <label className="form-label">Entity</label>
          <select className="form-select" value={filters.tableName} onChange={(e) => setField("tableName", e.target.value)}>
            <option value="">All entities</option>
            {tableOptions.map((t) => <option key={t} value={t}>{t}</option>)}
          </select>
        </div>
        <div className="col-12 col-md-auto">
          <label className="form-label">Action</label>
          <select className="form-select" value={filters.changeType} onChange={(e) => setField("changeType", e.target.value)}>
            <option value="">All actions</option>
            {Object.entries(TYPE_META).map(([k, m]) => <option key={k} value={k}>{m.label}</option>)}
          </select>
        </div>
        <div className="col-12 col-md-auto d-flex gap-2 ms-md-auto">
          <button type="submit" className="ml-btn-action ml-fab" disabled={loading}>Apply</button>
          <button type="button" className="ml-btn-ghost" onClick={clear} disabled={loading}>Clear</button>
        </div>
      </form>

      <div className="al-chart-grid">
        <Card title="Activity over time" empty={!summary?.byDay?.length}>
          <ResponsiveContainer width="100%" height={220}>
            <AreaChart data={summary?.byDay ?? []}>
              <CartesianGrid stroke={GRID} vertical={false} />
              <XAxis dataKey="day" tick={{ fill: AXIS, fontSize: 11 }} stroke={GRID} />
              <YAxis allowDecimals={false} tick={{ fill: AXIS, fontSize: 11 }} stroke={GRID} />
              <Tooltip />
              <Area type="monotone" dataKey="count" stroke="#6ea8fe" fill="rgba(110,168,254,0.2)" />
            </AreaChart>
          </ResponsiveContainer>
        </Card>

        <Card title="By action" empty={!summary?.byType?.length}>
          <ResponsiveContainer width="100%" height={220}>
            <PieChart>
              <Pie data={summary?.byType ?? []} dataKey="count" nameKey="label" innerRadius={45} outerRadius={78} paddingAngle={2}>
                {(summary?.byType ?? []).map((d) => <Cell key={d.changeType} fill={typeMeta(d.changeType).color} />)}
              </Pie>
              <Tooltip />
              <Legend />
            </PieChart>
          </ResponsiveContainer>
        </Card>

        <Card title="Top entities changed" empty={!summary?.byTable?.length}>
          <ResponsiveContainer width="100%" height={220}>
            <BarChart data={(summary?.byTable ?? []).slice(0, 8)} layout="vertical" margin={{ left: 16 }}>
              <XAxis type="number" allowDecimals={false} tick={{ fill: AXIS, fontSize: 11 }} stroke={GRID} />
              <YAxis type="category" dataKey="tableName" width={130} tick={{ fill: AXIS, fontSize: 10 }} stroke={GRID} />
              <Tooltip />
              <Bar dataKey="count" fill="#3fb950" radius={[0, 4, 4, 0]} />
            </BarChart>
          </ResponsiveContainer>
        </Card>

        <Card title="Top users" empty={!summary?.byUser?.length}>
          <ResponsiveContainer width="100%" height={220}>
            <BarChart data={(summary?.byUser ?? []).slice(0, 8)}>
              <CartesianGrid stroke={GRID} vertical={false} />
              <XAxis dataKey="fullName" tick={{ fill: AXIS, fontSize: 10 }} stroke={GRID} />
              <YAxis allowDecimals={false} tick={{ fill: AXIS, fontSize: 11 }} stroke={GRID} />
              <Tooltip />
              <Bar dataKey="count" fill="#d2a8ff" radius={[4, 4, 0, 0]} />
            </BarChart>
          </ResponsiveContainer>
        </Card>
      </div>

      <DataTable
        columns={columns}
        data={feed}
        loading={loading}
        name="AuditLog"
        onRowSelect={(row) => navigate(`/audit-log/record/${row.tableName}/${row.recordId}`)}
        // //features={{ actionColumnsLeftEnd: true, columnVisibility: true, csvExport: true }}
      />
    </MeridianPage>
  );
}
