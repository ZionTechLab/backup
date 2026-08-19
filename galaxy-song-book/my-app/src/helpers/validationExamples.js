// Example API Response Structure for Dynamic Validation

// Example 1: Simple required field
const example1 = {
  meta: {
    metaValue: {
      name: "value",
      type: "text",
      placeholder: "Company Name",
      initialValue: "",
      className: "col-md-9 col-sm-6 col-12",
      validation: {
        dataType: "string",
        isRequired: true,
        errorMessage: "Company Name is required",
        fieldName: "Company Name",
      },
    },
  },
};

// Example 2: With min/max length constraints
const example2 = {
  meta: {
    metaValue: {
      name: "value",
      type: "text",
      placeholder: "Department Code",
      initialValue: "",
      className: "col-12",
      validation: {
        dataType: "string",
        isRequired: true,
        minLength: 2,
        maxLength: 10,
        errorMessage: "Department Code is required",
        fieldName: "Department Code",
      },
    },
  },
};

// Example 3: Email validation
const example3 = {
  meta: {
    metaValue: {
      name: "value",
      type: "email",
      placeholder: "Contact Email",
      initialValue: "",
      className: "col-12",
      validation: {
        dataType: "string",
        email: true,
        isRequired: true,
        errorMessage: "Valid email is required",
        fieldName: "Contact Email",
      },
    },
  },
};

// Example 4: Number with range
const example4 = {
  meta: {
    metaValue: {
      name: "value",
      type: "number",
      placeholder: "Employee Count",
      initialValue: "",
      className: "col-6",
      validation: {
        dataType: "integer",
        isRequired: true,
        min: 1,
        max: 10000,
        positive: true,
        errorMessage: "Employee count is required",
        fieldName: "Employee Count",
      },
    },
  },
};

// Example 5: Pattern validation (e.g., phone number)
const example5 = {
  meta: {
    metaValue: {
      name: "value",
      type: "text",
      placeholder: "Phone Number",
      initialValue: "",
      className: "col-12",
      validation: {
        dataType: "string",
        isRequired: true,
        pattern: "^[0-9]{10}$",
        patternMessage: "Phone number must be 10 digits",
        fieldName: "Phone Number",
      },
    },
  },
};

// Example 6: Select/Enum validation
const example6 = {
  meta: {
    metaValue: {
      name: "value",
      type: "select",
      placeholder: "Status",
      initialValue: "",
      className: "col-6",
      validation: {
        dataType: "string",
        isRequired: true,
        oneOf: ["active", "inactive", "pending"],
        oneOfMessage: "Please select a valid status",
        fieldName: "Status",
      },
    },
  },
};

// Example 7: Optional field (not required)
const example7 = {
  meta: {
    metaValue: {
      name: "value",
      type: "text",
      placeholder: "Description",
      initialValue: "",
      className: "col-12",
      validation: {
        dataType: "string",
        isRequired: false,
        maxLength: 500,
        fieldName: "Description",
      },
    },
  },
};

// Example 8: Complete form with multiple fields
const completeExample = {
  meta: {
    categoryName: "Companies",
    categoryType: 70,

    metaValue: {
      name: "value",
      type: "text",
      placeholder: "Company Name",
      initialValue: "",
      className: "col-md-9 col-sm-6 col-12",
      validation: {
        dataType: "string",
        isRequired: true,
        minLength: 2,
        maxLength: 100,
        errorMessage: "Company Name is required",
        fieldName: "Company Name",
      },
    },

    ref1: "Registration Number",
    ref1Validation: {
      dataType: "string",
      isRequired: true,
      pattern: "^[A-Z0-9]{10}$",
      patternMessage: "Registration number must be 10 alphanumeric characters",
      fieldName: "Registration Number",
    },

    ref2: "Tax ID",
    ref2Validation: {
      dataType: "string",
      isRequired: false,
      minLength: 9,
      maxLength: 15,
      fieldName: "Tax ID",
    },

    ref3: "Website URL",
    ref3Validation: {
      dataType: "string",
      url: true,
      isRequired: false,
      fieldName: "Website URL",
    },

    parentCategory: "Parent Company",
    parentCategoryType: 71,
    parentCategoryData: [
      { id: 1, value: "Parent Company 1" },
      { id: 2, value: "Parent Company 2" },
    ],
  },
};

// Example 9: Date validation
const example9 = {
  meta: {
    metaValue: {
      name: "value",
      type: "date",
      placeholder: "Establishment Date",
      initialValue: "",
      className: "col-6",
      validation: {
        dataType: "date",
        isRequired: true,
        // maxDate could be today's date or a specific date
        fieldName: "Establishment Date",
      },
    },
  },
};

// Example 10: No validation (optional field without constraints)
const example10 = {
  meta: {
    metaValue: {
      name: "value",
      type: "text",
      placeholder: "Notes",
      initialValue: "",
      className: "col-12",
      // No validation property means no validation will be applied
    },
  },
};

export {
  example1,
  example2,
  example3,
  example4,
  example5,
  example6,
  example7,

  example9,
  example10,
  completeExample,
};
