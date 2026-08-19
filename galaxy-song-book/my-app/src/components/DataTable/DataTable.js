import { useState, useEffect, useMemo, Fragment } from 'react';
import { getDataTableConfig } from './DataTableConfig';
import { useMediaQuery } from './useMediaQuery';
import { Pagination } from './Pagination';
import { ColumnVisibilityModal } from './ColumnVisibilityModal';
import { DefaultCard } from './DefaultCard';
import { GroupCard } from './GroupCard';
import { formatColumnValue } from './formatColumnValue';
import './DataTable.css';

const DataTable = ({
  data = [],
  columns = [],
  name,
  children,
  onRowSelect,
  showHeader = true,
  pageSize = 10,
  loading = false,
  pageSizeOptions,
  features: propFeatures,
  onExport: propOnExport,
  page: pageProp,
  onPageChange: onPageChangeProp,
  grouping,
  cardRenderer,
}) => {
  const globalConfig = getDataTableConfig();
  const features = propFeatures || globalConfig.features;
  const onExport = propOnExport || globalConfig.onExport;
  const isGrouped = !!(grouping && grouping.childrenField);
  const groupCollapsible = isGrouped && grouping.collapsible !== false;
  const safeLower = (val) => {
    if (val === undefined || val === null) return '';
    try { return String(val).toLowerCase(); } catch { return ''; }
  };
  const [searchTerm, setSearchTerm] = useState('');
  const [searchKey, setSearchKey] = useState(null);
  const [sortKey, setSortKey] = useState(null);
  const [sortDir, setSortDir] = useState('asc');
  const [internalPage, setInternalPage] = useState(pageProp || 1);
  const [rowsPerPage, setRowsPerPage] = useState(pageSize);
  const [visibleColumns, setVisibleColumns] = useState([]);
  const [showColumnModal, setShowColumnModal] = useState(false);
  const [selectedRowIndex, setSelectedRowIndex] = useState(null);
  const [expandedGroups, setExpandedGroups] = useState({});

  // Below the table breakpoint, render cards instead of a scrolling table
  // (only when the screen supplies a cardRenderer). Grouped tables keep the table.
  const isCardViewport = useMediaQuery('(max-width: 767.98px)');
  // Cards are the default mobile layout for every table. Screens can opt out
  // with features.cardView === false, or override the markup with a cardRenderer.
  // Grouped data renders as collapsible group cards (GroupCard) from the same
  // grouping config — no per-screen card code needed.
  const useCardView = isCardViewport && features.cardView !== false;

  const filterableCols = useMemo(() => {
    const safeColumns = Array.isArray(columns) ? columns : [];
    return safeColumns.filter(c => !c.isAction);
  }, [columns]);

  useEffect(() => {
    if (filterableCols.length) {
      setVisibleColumns(filterableCols.map(c => c.field));
      setSearchKey(filterableCols[0].field);
      setSortKey(filterableCols[0]);
    }
  }, [filterableCols]);

  const displayColumns = useMemo(() => {
    const safeColumns = Array.isArray(columns) ? columns : [];
    const cols = safeColumns.filter(col => col.isAction || visibleColumns.includes(col.field));
    const nonAction = cols.filter(c => !c.isAction);
    const action = cols.filter(c => c.isAction);
    if (features.actionColumnsRightEnd) return [...nonAction, ...action];
    if (features.actionColumnsLeftEnd) return [...action, ...nonAction];
    return cols;
  }, [columns, visibleColumns, features.actionColumnsRightEnd, features.actionColumnsLeftEnd]);

  const visibleFilterableCols = useMemo(() => {
    return filterableCols.filter(col => visibleColumns.includes(col.field));
  }, [filterableCols, visibleColumns]);

  useEffect(() => {
    if (searchKey && !visibleColumns.includes(searchKey) && visibleFilterableCols.length > 0) {
      setSearchKey(visibleFilterableCols[0].field);
    }
  }, [searchKey, visibleColumns, visibleFilterableCols]);

  useEffect(() => {
    if (sortKey && !visibleColumns.includes(sortKey.field) && visibleFilterableCols.length > 0) {
      setSortKey(visibleFilterableCols[0]);
    }
  }, [sortKey, visibleColumns, visibleFilterableCols]);

  const handleColumnToggle = (field) => {
    setVisibleColumns(prev => {
      if (prev.includes(field)) {
        if (prev.length === 1) return prev;
        return prev.filter(c => c !== field);
      }
      return [...prev, field];
    });
  };

  const handleExportCSV = () => {
    if (!features.csvExport) return;
    const filename = name ? name.replace(/\s+/g, '_').toLowerCase() : 'data_export';
    if (onExport) onExport(filteredData, columns, filename);
  };

  const handleSort = (col) => {
    if (sortKey && sortKey.field === col.field) {
      setSortDir(prev => prev === 'asc' ? 'desc' : 'asc');
    } else {
      setSortKey(col);
      setSortDir('asc');
    }
  };

  const compareRows = useMemo(() => {
    if (!sortKey) return null;
    const dir = sortDir === 'asc' ? 1 : -1;
    return (a, b) => {
      const aRaw = a[sortKey.field];
      const bRaw = b[sortKey.field];
      const aNum = Number(aRaw);
      const bNum = Number(bRaw);
      if (!isNaN(aNum) && !isNaN(bNum) && aRaw !== '' && aRaw != null && bRaw !== '' && bRaw != null) {
        return (aNum - bNum) * dir;
      }
      const aValue = safeLower(aRaw);
      const bValue = safeLower(bRaw);
      return (aValue > bValue ? 1 : aValue < bValue ? -1 : 0) * dir;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [sortKey, sortDir]);

  const sortRows = (rows) => {
    const safe = Array.isArray(rows) ? rows : [];
    return compareRows ? [...safe].sort(compareRows) : safe;
  };

  const filterRows = (rows) => {
    const safe = Array.isArray(rows) ? rows : [];
    if (!searchTerm || !searchKey) return safe;
    const term = searchTerm.toLowerCase();
    return safe.filter(row => safeLower(row[searchKey]).includes(term));
  };

  // eslint-disable-next-line react-hooks/exhaustive-deps
  const rawFilteredData = useMemo(
    () => filterRows(data),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [data, searchTerm, searchKey]
  );

  const filteredData = useMemo(
    // ⚡ Bolt: Optimize performance by filtering before sorting (O(N) + O(K log K) instead of O(N log N) + O(N))
    () => sortRows(rawFilteredData),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [rawFilteredData, compareRows]
  );

  const groupedData = useMemo(() => {
    if (!isGrouped) return [];
    const safe = Array.isArray(data) ? data : [];
    const searching = !!(searchTerm && searchKey);
    const out = [];
    safe.forEach((group, i) => {
      // ⚡ Bolt: Optimize performance by filtering before sorting
      const children = sortRows(filterRows(group?.[grouping.childrenField]));
      if (searching && children.length === 0) return;
      const key = grouping.groupKey ? String(grouping.groupKey(group, i)) : String(i);
      out.push({ group, children, key });
    });
    return out;
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isGrouped, data, grouping, compareRows, searchTerm, searchKey]);

  const effectivePage = pageProp ?? internalPage;
  const effectiveSetPage = onPageChangeProp ?? setInternalPage;

  const paginatedData = useMemo(() => {
    const safeFilteredData = Array.isArray(filteredData) ? filteredData : [];
    const start = (effectivePage - 1) * rowsPerPage;
    return safeFilteredData.slice(start, start + rowsPerPage);
  }, [filteredData, effectivePage, rowsPerPage]);

  const paginatedGroups = useMemo(() => {
    const start = (effectivePage - 1) * rowsPerPage;
    return groupedData.slice(start, start + rowsPerPage);
  }, [groupedData, effectivePage, rowsPerPage]);

  useEffect(() => {
    setExpandedGroups({});
  }, [data]);

  const defaultExpanded = !grouping || grouping.defaultExpanded !== false;
  const isGroupExpanded = (key) => (key in expandedGroups ? expandedGroups[key] : defaultExpanded);

  const toggleGroup = (key) => {
    setExpandedGroups(prev => {
      const cur = key in prev ? prev[key] : defaultExpanded;
      return { ...prev, [key]: !cur };
    });
  };

  const renderCaret = (expanded) => (
    <span className={`dt-group-caret ${expanded ? 'dt-group-caret-open' : ''}`} aria-hidden="true">
      {expanded ? '▾' : '▸'}
    </span>
  );

  const renderGroupHeaderRow = (group, key, expanded) => {
    const ctx = { expanded, toggle: () => toggleGroup(key), displayColumns };
    if (grouping.groupHeaderCells) {
      const cells = grouping.groupHeaderCells(group, ctx) || [];
      return cells.map((cell, idx) => (
        <td key={idx} colSpan={cell.colSpan || 1} className={cell.className || ''}>
          {idx === 0 && groupCollapsible ? <>{renderCaret(expanded)}{cell.content}</> : cell.content}
        </td>
      ));
    }
    const node = grouping.groupHeader ? grouping.groupHeader(group, ctx) : null;
    return (
      <td colSpan={displayColumns.length} className="dt-group-banner">
        {groupCollapsible && renderCaret(expanded)}
        {node}
      </td>
    );
  };

  const renderGroupFooterRow = (group, key, expanded) => {
    const ctx = { expanded, toggle: () => toggleGroup(key), displayColumns };
    const out = grouping.groupFooter(group, ctx);
    if (Array.isArray(out)) {
      return out.map((cell, idx) => (
        <td key={idx} colSpan={cell.colSpan || 1} className={cell.className || ''}>{cell.content}</td>
      ));
    }
    return <td colSpan={displayColumns.length}>{out}</td>;
  };

  return (



    <div>
    {
            loading ? (
              <div className="py-4 px-3 text-center">
                {/* <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true" /> */}
                ...
              </div>
            ) :(

      <div>

        {showHeader && (
          <div className="card dt-toolbar">
            <div className="card-body row">
              <div className="col-sm-3">{children && <>{children}</>}</div>
              <div className="col-sm" />
              <div className="col-sm-auto filterby">
                <span className="filterby-label ">  <i className="bi bi-search" /></span>

                <div className="filterby-search">
                      <select className="filterby-select" value={searchKey || ''} onChange={e => setSearchKey(e.target.value)}>
                  {visibleFilterableCols.map(opt => (
                    <option key={opt.field} value={opt.field}>{opt.header}</option>
                  ))}
                </select>
                  {/* <i className="bi bi-search" /> */}
                  <input type="text" className="form-control" placeholder="Filter Text..." value={searchTerm} onChange={e => setSearchTerm(e.target.value)} />
                </div>
              </div>
              <div className="col-sm-auto">
                <div className="d-flex align-items-center gap-2 ">
                  {features.csvExport && (
                    <button className="btn btn-outline-secondary btn-sm ml-fab-1 ml-tip" aria-label="Export to CSV" onClick={handleExportCSV}>
                      <i className="bi bi-download" />
                    </button>
                  )}
                  {features.columnVisibility && (
                    <button className="btn btn-outline-secondary  btn-sm ml-fab-2 ml-tip" aria-label="Column Visibility" onClick={() => setShowColumnModal(true)}>
                      <i className="bi bi-layout-three-columns" />
                    </button>
                  )}
                </div>
              </div>
            </div>
          </div>
        )}
        <ColumnVisibilityModal columns={columns} visibleColumns={visibleColumns} onToggle={handleColumnToggle} isOpen={showColumnModal} onClose={() => setShowColumnModal(false)} />
        {useCardView ? (
          <div className="d-flex flex-column gap-3 mt-3">
            {
            // loading ? (
            //   <div className="dt-cards-state">
            //     <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true" />
            //     ...
            //   </div>
            // ) :
             !paginatedData.length ? (
              <div className="py-4 px-3 text-center text-muted">No results found</div>
            ) : (
              paginatedData.map((row, i) => {
                if (isGrouped && !cardRenderer) {
                  return (
                    <GroupCard
                      key={i}
                      group={row}
                      columns={displayColumns}
                      grouping={grouping}
                      defaultExpanded={defaultExpanded}
                    />
                  );
                }
                const globalIndex = (effectivePage - 1) * rowsPerPage + i;
                return (
                  <div
                    key={i}
                    className={`dt-card card bg-white p-3 ${selectedRowIndex === globalIndex ? 'dt-card-active' : ''}`}
                    onClick={() => { setSelectedRowIndex(globalIndex); if (onRowSelect) onRowSelect(row); }}
                  >
                    {cardRenderer
                      ? cardRenderer(row)
                      : <DefaultCard row={row} columns={displayColumns} />}
                  </div>
                );
              })
            )}
          </div>
        ) : (
        <div className="mt-3 card">
          <div className="table-responsive">
            <table className="table table-hover">
              <thead className="table-header">
                <tr>
                  {displayColumns.map((col, idx) => (
                    <th key={idx} className={`sort ${!col.isAction ? 'cursor-pointer' : ''} ${col.class || ''}`} onClick={() => !col.isAction && handleSort(col)}>
                      {col.header}
                      {sortKey && sortKey.field === col.field && <span className="ms-1">{sortDir === 'asc' ? '↑' : '↓'}</span>}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {
                // loading ? (
                //   <tr>
                //     <td colSpan={displayColumns.length} className="text-center py-3">
                //       {/* <span className="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true" /> */}
                //       ...
                //     </td>
                //   </tr>
                // ) :
                isGrouped ? (
                  !paginatedGroups.length ? (
                    <tr>
                      <td colSpan={displayColumns.length} className="text-center text-muted">No results found</td>
                    </tr>
                  ) : (
                    paginatedGroups.map(({ group, children, key }) => {
                      const expanded = isGroupExpanded(key);
                      const groupClass = grouping.groupRowClassName ? grouping.groupRowClassName(group) : '';
                      return (
                        <Fragment key={key}>
                          <tr
                            className={`dt-group-row ${groupClass} ${groupCollapsible ? 'cursor-pointer' : ''}`}
                            onClick={groupCollapsible ? () => toggleGroup(key) : undefined}
                          >
                            {renderGroupHeaderRow(group, key, expanded)}
                          </tr>
                          {expanded && children.map((child, ci) => (
                            <tr key={ci}>
                              {displayColumns.map((col, j) => (
                                <td key={j} className={col.class || ''}>{formatColumnValue(col, child)}</td>
                              ))}
                            </tr>
                          ))}
                          {expanded && grouping.groupFooter && (
                            <tr className="dt-group-footer">
                              {renderGroupFooterRow(group, key, expanded)}
                            </tr>
                          )}
                        </Fragment>
                      );
                    })
                  )
                ) : !paginatedData.length ? (
                  <tr>
                    <td colSpan={displayColumns.length} className="text-center text-muted">No results found</td>
                  </tr>
                ) : (
                  paginatedData.map((row, i) => {
                    const globalIndex = (effectivePage - 1) * rowsPerPage + i;
                    return (
                      <tr key={i} className={`cursor-pointer ${selectedRowIndex === globalIndex ? 'table-active' : ''}`} onClick={() => { setSelectedRowIndex(globalIndex); if (onRowSelect) onRowSelect(row); }}>
                        {displayColumns.map((col, j) => (
                          <td key={j} className={col.class || ''}>{formatColumnValue(col, row)}</td>
                        ))}
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
        </div>
        )}
        <div className="d-flex align-items-center justify-content-between flex-wrap gap-2 mt-1">
          {pageSizeOptions && pageSizeOptions.length > 0 ? (
            <div className="d-flex align-items-center gap-2 small text-muted">
              <span>Rows:</span>
              <select className="form-select form-select-sm w-auto" value={rowsPerPage} onChange={e => { setRowsPerPage(Number(e.target.value)); effectiveSetPage(1); }}>
                {pageSizeOptions.map(opt => <option key={opt} value={opt}>{opt}</option>)}
              </select>
            </div>
          ) : <div />}
          <Pagination total={isGrouped ? groupedData.length : (Array.isArray(filteredData) ? filteredData.length : 0)} currentPage={effectivePage} pageSize={rowsPerPage} onPageChange={effectiveSetPage} />
        </div>
      </div>)}
    </div>

  );
};

export { DataTable };
