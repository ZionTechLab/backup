# Dynamic Validation Generator

This utility provides a flexible way to generate Yup validation schemas dynamically based on configuration objects.

## Basic Usage

```javascript
import { generateValidation } from '../helpers/validationGenerator';

// Simple required string
const validation = generateValidation({
  dataType: 'string',
  isRequired: true,
  errorMessage: 'Name is required',
  fieldName: 'Name'
});

// Number with min/max
const ageValidation = generateValidation({
  dataType: 'number',
  isRequired: true,
  min: 18,
  max: 100,
  fieldName: 'Age'
});

// Email validation
const emailValidation = generateValidation({
  dataType: 'string',
  email: true,
  isRequired: true,
  fieldName: 'Email'
});
```

## Configuration Options

### Common Options
- **dataType** (string): Type of data - `string`, `number`, `integer`, `date`, `boolean`, `array`, `object`
- **isRequired** (boolean): Whether the field is required
- **errorMessage** (string): Custom error message for required validation
- **fieldName** (string): Field name used in error messages (default: "This field")

### String Validation Options
```javascript
{
  dataType: 'string',
  isRequired: true,
  minLength: 3,
  maxLength: 50,
  pattern: /^[A-Z][a-z]+$/,  // or as string: '^[A-Z][a-z]+$'
  patternMessage: 'Must start with uppercase letter',
  email: true,  // validates email format
  url: true,    // validates URL format
  fieldName: 'Username'
}
```

### Number Validation Options
```javascript
{
  dataType: 'number',
  isRequired: true,
  min: 0,
  max: 1000,
  positive: true,  // must be positive
  fieldName: 'Price'
}
```

For integers specifically:
```javascript
{
  dataType: 'integer',
  isRequired: true,
  min: 1,
  max: 100,
  fieldName: 'Quantity'
}
```

### Date Validation Options
```javascript
{
  dataType: 'date',
  isRequired: true,
  minDate: new Date('2024-01-01'),
  maxDate: new Date('2024-12-31'),
  fieldName: 'Birth Date'
}
```

### Boolean Validation Options
```javascript
{
  dataType: 'boolean',
  mustBeTrue: true,  // for terms & conditions
  fieldName: 'Terms and Conditions'
}
```

### Array Validation Options
```javascript
{
  dataType: 'array',
  isRequired: true,
  minLength: 1,  // minimum items
  maxLength: 10, // maximum items
  fieldName: 'Tags'
}
```

### Enum/Select Options (oneOf)
```javascript
{
  dataType: 'string',
  isRequired: true,
  oneOf: ['active', 'inactive', 'pending'],
  oneOfMessage: 'Status must be active, inactive, or pending',
  fieldName: 'Status'
}
```

## Real-World Examples

### 1. User Registration Form
```javascript
const fields = {
  username: {
    name: 'username',
    type: 'text',
    placeholder: 'Username',
    initialValue: '',
    validation: generateValidation({
      dataType: 'string',
      isRequired: true,
      minLength: 3,
      maxLength: 20,
      pattern: /^[a-zA-Z0-9_]+$/,
      patternMessage: 'Username can only contain letters, numbers, and underscores',
      fieldName: 'Username'
    }),
    className: 'col-12'
  },
  
  email: {
    name: 'email',
    type: 'email',
    placeholder: 'Email Address',
    initialValue: '',
    validation: generateValidation({
      dataType: 'string',
      email: true,
      isRequired: true,
      fieldName: 'Email'
    }),
    className: 'col-12'
  },
  
  age: {
    name: 'age',
    type: 'number',
    placeholder: 'Age',
    initialValue: '',
    validation: generateValidation({
      dataType: 'integer',
      isRequired: true,
      min: 18,
      max: 120,
      fieldName: 'Age'
    }),
    className: 'col-6'
  },
  
  password: {
    name: 'password',
    type: 'password',
    placeholder: 'Password',
    initialValue: '',
    validation: generateValidation({
      dataType: 'string',
      isRequired: true,
      minLength: 8,
      pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)/,
      patternMessage: 'Password must contain uppercase, lowercase, and number',
      fieldName: 'Password'
    }),
    className: 'col-12'
  }
};
```

### 2. Dynamic API-Driven Validation

If your backend provides validation rules:

```javascript
// Backend response example:
const metaValue = {
  name: 'companyName',
  type: 'text',
  placeholder: 'Company Name',
  initialValue: '',
  className: 'col-12',
  validation: {
    dataType: 'string',
    isRequired: true,
    minLength: 2,
    maxLength: 100,
    errorMessage: 'Please enter a valid company name',
    fieldName: 'Company Name'
  }
};

// Use it in your field definition:
const fields = {
  companyName: {
    ...metaValue,
    validation: generateValidation(metaValue.validation)
  }
};
```

### 3. Product Form Example
```javascript
const productFields = {
  productName: {
    name: 'productName',
    type: 'text',
    placeholder: 'Product Name',
    initialValue: '',
    validation: generateValidation({
      dataType: 'string',
      isRequired: true,
      minLength: 3,
      maxLength: 200,
      fieldName: 'Product Name'
    })
  },
  
  price: {
    name: 'price',
    type: 'number',
    placeholder: 'Price',
    initialValue: '',
    validation: generateValidation({
      dataType: 'number',
      isRequired: true,
      min: 0.01,
      positive: true,
      fieldName: 'Price'
    })
  },
  
  category: {
    name: 'category',
    type: 'select',
    placeholder: 'Category',
    initialValue: '',
    validation: generateValidation({
      dataType: 'string',
      isRequired: true,
      oneOf: ['electronics', 'clothing', 'food', 'books'],
      fieldName: 'Category'
    })
  },
  
  launchDate: {
    name: 'launchDate',
    type: 'date',
    placeholder: 'Launch Date',
    initialValue: '',
    validation: generateValidation({
      dataType: 'date',
      isRequired: true,
      minDate: new Date(),
      fieldName: 'Launch Date'
    })
  }
};
```

## Integration with Your Current Code

In `AddRefferances.jsx`:

```javascript
import { generateValidation } from '../../helpers/validationGenerator';

const fields = {
  value: {
    ...uiData.data.meta?.metaValue,
    validation: generateValidation(uiData.data.meta?.metaValue?.validation),
  },
  
  ref1: {
    name: 'ref1',
    type: 'text',
    placeholder: uiData.data.meta?.ref1,
    isVisible: uiData.data.meta?.ref1 ? true : false,
    initialValue: '',
    validation: generateValidation(uiData.data.meta?.ref1Validation),
    className: 'col-12',
  }
};
```

## Expected Backend Data Structure

Your backend should provide validation configuration like this:

```json
{
  "meta": {
    "metaValue": {
      "name": "value",
      "type": "text",
      "placeholder": "Company Name",
      "initialValue": "",
      "className": "col-md-9 col-sm-6 col-12",
      "validation": {
        "dataType": "string",
        "isRequired": true,
        "minLength": 2,
        "maxLength": 100,
        "errorMessage": "Company Name is required",
        "fieldName": "Company Name"
      }
    },
    "ref1": "Reference 1",
    "ref1Validation": {
      "dataType": "string",
      "isRequired": false,
      "maxLength": 50,
      "fieldName": "Reference 1"
    }
  }
}
```

## No Validation

If you don't want any validation for a field, you can:

1. Not pass a validation config:
```javascript
validation: generateValidation()  // Returns Yup.mixed().notRequired()
```

2. Pass an empty object:
```javascript
validation: generateValidation({})  // Same as above
```

3. Explicitly set isRequired to false:
```javascript
validation: generateValidation({
  dataType: 'string',
  isRequired: false
})
```

## Tips

1. **Field Names in Errors**: Always provide `fieldName` for better error messages
2. **Required Last**: The generator always applies `required()` last in the chain
3. **Type Safety**: Use specific dataTypes (`integer`, `email`) instead of generic `string` when possible
4. **Pattern Messages**: Always provide `patternMessage` for regex validations
5. **Default Behavior**: If no config is provided, returns `Yup.mixed().notRequired()`
