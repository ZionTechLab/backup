const yup = require('yup');
const { phoneNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate:       yup.boolean(),
  tenantId:       yup.string().nullable().when('isUpdate', { is: true, then: s => s.required() }),
  tenantName:     yup.string().required(),
  legalName:      yup.string().nullable(),
  status:         yup.string().nullable(),
  email:          yup.string().email().nullable(),
  phone:          phoneNumber(),
  address_line1:  yup.string().nullable(),
  address_line2:  yup.string().nullable(),
  city:           yup.string().nullable(),
  state_province: yup.string().nullable(),
  postal_code:    yup.string().nullable(),
  country:        yup.string().nullable(),
});

const deleteSchema = yup.object({
  tenantId: yup.string().required(),
});

const settingsSchema = yup.object({
  tenantId: yup.string().required(),
  settings: yup.object({
    DISPLAY_DATE_FORMAT:       yup.string().nullable(),
    returnToListAfterSave:     yup.boolean().nullable(),
    showThemeControls:         yup.boolean().nullable(),
    dataTableColumnVisibility: yup.boolean().nullable(),
    actionColumnsRightEnd:     yup.boolean().nullable(),
    dataTableCSVExport:        yup.boolean().nullable(),
    selectSearch:               yup.boolean().nullable(),
    theme:                      yup.string().oneOf(['dark', 'light']).nullable(),
    colorTheme:                 yup.string().nullable(),
    uiTheme:                    yup.string().nullable(),
  }).required(),
});

const addUserSchema = yup.object({
  tenantId: yup.string().required(),
  userId: yup.string().required(),
});

const removeUserSchema = yup.object({
  id: yup.number().required(),
});

const setDefaultSchema = yup.object({
  id: yup.number().required(),
});

const listUsersSchema = yup.object({
  tenantId: yup.string().required(),
});

module.exports = { updateSchema, deleteSchema, settingsSchema, addUserSchema, removeUserSchema, setDefaultSchema, listUsersSchema };
