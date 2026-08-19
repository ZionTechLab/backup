// Generic validation utility for yup schemas
module.exports = function validate(schema, data) {
  try {
    return schema.validateSync(data, { abortEarly: false });
  } catch (error) {
      //  console.error('Validation error:', error);
    console.error('Validation error:', error.errors.join(", "));
  throw error;
  }
};
