exports.up = function(knex) {
  const data = [
    { tenantId:1,companyId:1,id: 10, parentId: 0, route: '/', displayName: 'Dashboard', icon: 'bi bi-speedometer2',order:10,active:true},
    {tenantId:1,companyId:1,id: 20, parentId: 0, route: '/invoice', displayName: 'Invoice', icon: 'bi bi-file-earmark-text',order:20, active:true},
    {tenantId:1,companyId:1,id: 30, parentId: 0, route: '/tax-invoice', displayName: 'Tax Invoice', icon: 'bi bi-file-earmark-text',order:30, active:true},
    {tenantId:1,companyId:1,id: 40, parentId: 0, route: '/advance', displayName: 'Advance', icon: 'bi bi-person-badge',order:40, active:true},
    {tenantId:1,companyId:1,id: 50, parentId: 0, route: '/payment', displayName: 'Payment', icon: 'bi bi-person-badge',order:50, active: true },
    { tenantId:1,companyId:1,id: 60, parentId: 0,route: '/vehicale-confirmation', displayName: 'Vehicle Details', icon: 'bi bi-file-earmark-text',order:60, active: true },
    { tenantId:1,companyId:1,id: 70, parentId: 0,route: '/daily-report', displayName: 'Daily Report', icon: 'bi bi-journal-text',order:70, active: true },
    {tenantId:1,companyId:1,id: 80, parentId: 0, route: '/reports', displayName: 'Reports', icon: 'bi bi-person-badge', order:80, active: true },
    { tenantId:1,companyId:1,id: 90, parentId: 0,route: '/inquiry', displayName: 'Faulty Acknowledgment', icon: 'bi bi-headset', order:90, active: false },
    { tenantId:1,companyId:1,id: 100, parentId: 0,route: '/item-master', displayName: 'Item Master', icon: 'bi bi-box-seam-fill', order:100, active: false },
    { tenantId:1,companyId:1,id: 110, parentId: 0,route: '/item-category', displayName: 'Item Category', icon: 'bi bi-tags', order:110, active: false },
    {tenantId:1,companyId:1,id: 120, parentId: 0, route: '/grn', displayName: 'GRN', icon: 'bi bi-receipt', order:120, active: false },
  ];

  const mappedData = data.map(({ active, ...item }) => ({
    ...item,
    isActive: active
  }));

  return knex('sec_menu').insert(mappedData).onConflict('id').ignore();
};
exports.down = function(knex) {
      // return knex('sec_menu')
      //   .del();
                return knex('sec_menu').whereIn('id', ['10','20','30','40','50','60','70','80','90','100','110','120']).del();
};


