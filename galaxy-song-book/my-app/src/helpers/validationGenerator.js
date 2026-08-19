import * as Yup from "yup";

/**
 * Generates Yup validation schema dynamically based on field configuration
 * @param {Object} config - Validation configuration
 * @param {string} config.dataType - Data type (string, number, email, date, boolean, etc.)
 * @param {boolean} config.isRequired - Whether the field is required
 * @param {string} config.errorMessage - Custom error message for required validation
 * @param {number} config.minLength - Minimum length for string/array
 * @param {number} config.maxLength - Maximum length for string/array
 * @param {number} config.min - Minimum value for numbers
 * @param {number} config.max - Maximum value for numbers
 * @param {RegExp|string} config.pattern - Regex pattern for string validation
 * @param {string} config.patternMessage - Error message for pattern validation
 * @param {string} config.email - If true, validates email format
 * @param {string} config.url - If true, validates URL format
 * @param {Array} config.oneOf - Array of allowed values
 * @param {string} config.oneOfMessage - Error message for oneOf validation
 * @returns {Yup.Schema} Yup validation schema
 */
export const generateValidation = (config = {}) => {
  if (!config || Object.keys(config).length === 0) {
    return Yup.mixed().notRequired();
  }

  const {
    dataType = "string",
    isRequired = false,
    errorMessage,
    minLength,
    maxLength,
    min,
    max,
    pattern,
    patternMessage,
    email,
    url,
    oneOf,
    oneOfMessage,
    fieldName = "This field",
  } = config;

  let schema;

  // Initialize schema based on data type
  switch (dataType.toLowerCase()) {
    case "string":
    case "text":
      schema = Yup.string();

      // Email validation
      if (email) {
        schema = schema.email(`${fieldName} must be a valid email`);
      }

      // URL validation
      if (url) {
        schema = schema.url(`${fieldName} must be a valid URL`);
      }

      // Min length
      if (minLength !== undefined && minLength !== null) {
        schema = schema.min(
          minLength,
          `${fieldName} must be at least ${minLength} characters`,
        );
      }

      // Max length
      if (maxLength !== undefined && maxLength !== null) {
        schema = schema.max(
          maxLength,
          `${fieldName} must be at most ${maxLength} characters`,
        );
      }

      // Pattern/Regex validation
      if (pattern) {
        const regex =
          typeof pattern === "string" ? new RegExp(pattern) : pattern;
        schema = schema.matches(
          regex,
          patternMessage || `${fieldName} format is invalid`,
        );
      }
      break;

    case "number":
    case "integer":
    case "decimal":
    case "float":
      schema = Yup.number();

      // Type error message
      schema = schema.typeError(`${fieldName} must be a number`);

      // Min value
      if (min !== undefined && min !== null) {
        schema = schema.min(min, `${fieldName} must be at least ${min}`);
      }

      // Max value
      if (max !== undefined && max !== null) {
        schema = schema.max(max, `${fieldName} must be at most ${max}`);
      }

      // Integer validation
      if (dataType.toLowerCase() === "integer") {
        schema = schema.integer(`${fieldName} must be an integer`);
      }

      // Positive validation
      if (config.positive) {
        schema = schema.positive(`${fieldName} must be a positive number`);
      }
      break;

    case "date":
    case "datetime":
      schema = Yup.date();
      schema = schema.typeError(`${fieldName} must be a valid date`);

      // Min date
      if (config.minDate) {
        schema = schema.min(
          config.minDate,
          `${fieldName} must be after ${config.minDate}`,
        );
      }

      // Max date
      if (config.maxDate) {
        schema = schema.max(
          config.maxDate,
          `${fieldName} must be before ${config.maxDate}`,
        );
      }
      break;

    case "boolean":
    case "bool":
      schema = Yup.boolean();

      // OneOf for boolean (true/false)
      if (config.mustBeTrue) {
        schema = schema.oneOf([true], `${fieldName} must be accepted`);
      }
      break;

    case "array":
      schema = Yup.array();

      // Min items
      if (minLength !== undefined && minLength !== null) {
        schema = schema.min(
          minLength,
          `${fieldName} must have at least ${minLength} items`,
        );
      }

      // Max items
      if (maxLength !== undefined && maxLength !== null) {
        schema = schema.max(
          maxLength,
          `${fieldName} must have at most ${maxLength} items`,
        );
      }
      break;

    case "object":
      schema = Yup.object();
      break;

    default:
      schema = Yup.mixed();
  }

  // OneOf validation (for enums/select options)
  if (oneOf && Array.isArray(oneOf) && oneOf.length > 0) {
    schema = schema.oneOf(
      oneOf,
      oneOfMessage || `${fieldName} must be one of: ${oneOf.join(", ")}`,
    );
  }

  // Required validation (always last)
  if (isRequired) {
    schema = schema.required(errorMessage || `${fieldName} is required`);
  } else {
    schema = schema.notRequired();
  }

  return schema;
};

/**
 * Generates validation for multiple fields
 * @param {Object} fieldsConfig - Object with field names as keys and validation configs as values
 * @returns {Object} Object with field names as keys and Yup schemas as values
 */
export const generateValidations = (fieldsConfig) => {
  return Object.fromEntries(
    Object.entries(fieldsConfig).map(([key, config]) => [
      key,
      generateValidation(config),
    ]),
  );
};

export default generateValidation;
