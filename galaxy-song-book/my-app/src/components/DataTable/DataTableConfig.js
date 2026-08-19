let dataTableConfig = {
  features: {
    columnVisibility: false,
    csvExport: false,
    actionColumnsRightEnd: false,
  },
  onExport: null,
};

export const initDataTableConfig = (config) => {
  if (config.features) {
    dataTableConfig.features = {
      ...dataTableConfig.features,
      ...config.features,
    };
  }
  if (config.onExport) {
    dataTableConfig.onExport = config.onExport;
  }
};

export const getDataTableConfig = () => dataTableConfig;

export const resetDataTableConfig = () => {
  dataTableConfig = {
    features: {
      columnVisibility: false,
      csvExport: false,
      actionColumnsRightEnd: false,
    },
    onExport: null,
  };
};
