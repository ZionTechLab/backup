---
description: 'Custom chat mode for create feature. AI should help generate new features based on user requirements.'
tools: ['codebase', 'usages', 'vscodeAPI', 'problems', 'changes', 'testFailure', 'terminalSelection', 'terminalLastCommand', 'openSimpleBrowser', 'fetch', 'findTestFiles', 'searchResults', 'githubRepo', 'extensions', 'todos', 'editFiles', 'runNotebooks', 'search', 'new', 'runCommands', 'runTasks']
---
# Create Feature Chat Mode

## 1. Preparation
- Confirm the feature name and targeted route. Ask for any missing details.
- Collect back-end endpoint information.
- Collect fields information (names, types, validation rules).

## 2. Generate Artifacts

Create the folder `src/features/<FeatureName>/` and generate the following three files.

---

### `index.jsx` — List view

```jsx
import { Link, useNavigate } from 'react-router-dom';
import { DataTable } from '../../components/DataTable';
import { useEffect, useState } from 'react';
import ApiService from './service';
import MessageBoxService from '../../services/MessageBoxService';

function FeatureNameList() {
  const [uiData, setUiData] = useState({ loading: false, success: false, error: '', data: [] });
  const navigate = useNavigate();

  useEffect(() => {
    fetchUi();
    // eslint-disable-next-line
  }, []);

  const fetchUi = async () => {
    setUiData((prev) => ({ ...prev, loading: true, error: '', data: [] }));
    const data = await ApiService.getAll();
    setUiData((prev) => ({ ...prev, ...data, loading: false }));
  };

  const handleDelete = async (id) => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this FeatureName?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: 'FeatureName deleted successfully!',
        type: 'success',
        onClose: () => { fetchUi(); },
      });
    }
  };

  const handleEdit = (id) => {
    navigate(`/feature-url/edit/${id}`);
  };

  const columns = [
    {
      header: 'Actions',
      isAction: true,
      actionTemplate: (row) => (
        <div className="d-flex gap-2 justify-content-center">
          <button className="btn btn-outline-primary btn-sm btn-borderless" title="Edit" onClick={() => handleEdit(row.id)}>
            <i className="bi bi-pencil"></i>
          </button>
          <button className="btn btn-outline-danger btn-sm btn-borderless" title="Delete" onClick={() => handleDelete(row.id)}>
            <i className="bi bi-trash"></i>
          </button>
        </div>
      ),
    },
    { header: 'ID', field: 'id' },
    // add columns based on collected fields
  ];

  return (
    <div>
      {!uiData.error && (
        <DataTable loading={uiData.loading} name="FeatureName" data={uiData.data} columns={columns}>
          <Link to="/feature-url/add">
            <button className="btn btn-primary">+ Add</button>
          </Link>
        </DataTable>
      )}
      {uiData.error && (
        <div className="alert alert-danger mt-3">{uiData.error}</div>
      )}
    </div>
  );
}

export default FeatureNameList;
```

---

### `Add.jsx` — Add / edit form

```jsx
import { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { useFormikBuilder, FieldsRenderer } from '../../helpers/formikBuilder';
import ApiService from './service';
import MessageBoxService from '../../services/MessageBoxService';

// Fields declared at module level — avoids new object reference on every render
const fields = {
  id: {
    name: 'id',
    type: 'text',
    placeholder: 'ID',
    initialValue: '<Auto>',
    disabled: true,
    visible: false,
  },
  // replace / extend with actual fields based on collected information
  fieldName: {
    name: 'fieldName',
    type: 'text',
    placeholder: 'Field Label',
    initialValue: '',
    validation: Yup.string().required('Field is required'),
    className: 'col-12',
  },
  active: {
    name: 'active',
    type: 'switch',
    initialValue: true,
    validation: Yup.boolean(),
    placeholder: 'Active',
  },
};

function AddFeatureName() {
  const { id } = useParams();
  const navigate = useNavigate();

  const handleSubmit = async (values, { resetForm }) => {
    const param = {
      header: { ...values, id: parseInt(id ?? 0) },
      isUpdate: !!id,
    };
    const response = await ApiService.update(param);

    if (response.success) {
      MessageBoxService.show({
        message: 'FeatureName saved successfully!',
        type: 'success',
        onClose: () => navigate('/feature-url'),
      });
      resetForm();
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  useEffect(() => {
    if (!id) return;
    const fetchTxn = async () => {
      const response = await ApiService.get(id);
      if (response.success && response.data) {
        formik.setValues({ ...response.data });
      }
    };
    fetchTxn();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const handleDelete = async () => {
    const confirmed = await MessageBoxService.confirmAsync({
      message: 'Are you sure you want to delete this FeatureName?',
      type: 'danger',
      confirmText: 'Delete',
      cancelText: 'Cancel',
    });

    if (!confirmed) return;

    const response = await ApiService.delete({ id });
    if (response.success) {
      MessageBoxService.show({
        message: 'FeatureName deleted successfully!',
        type: 'success',
        onClose: () => navigate('/feature-url'),
      });
    }
  };

  return (
    <div className="container container-small">
      <form onSubmit={formik.handleSubmit} className="g-3">
        <div className="card mb-3">
          <div className="card-body">
            <div className="row g-2">
              <FieldsRenderer fields={fields} formik={formik} inputProps={{ autoComplete: 'off' }} />
            </div>
            <div className="d-flex justify-content-end mt-3">
              {id && (
                <button type="button" className="btn btn-outline-danger me-2" onClick={handleDelete}>
                  Delete
                </button>
              )}
              <button type="submit" className="btn btn-primary" disabled={formik.isSubmitting}>
                Save
              </button>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddFeatureName;
```

---

### `service.js` — API service

```js
import axios from 'axios';
import config from '../../config/config';

class FeatureNameService {
  constructor() {
    this.apiBase = config.apiBaseUrl + 'feature-endpoint';
  }

  async getAll() {
    try {
      const res = await axios.get(`${this.apiBase}/get-all`);
      return { success: true, data: res.data };
    } catch (error) {
      return { success: false, error: error?.response?.data?.message || 'Failed to load data.' };
    }
  }

  async get(id) {
    try {
      const res = await axios.get(`${this.apiBase}/get`, { params: { id } });
      return { success: true, data: res.data };
    } catch (error) {
      return { success: false, error: error?.response?.data?.message || 'Failed to load record.' };
    }
  }

  async update(param) {
    try {
      const res = await axios.post(`${this.apiBase}/update`, param);
      return { success: true, data: res.data };
    } catch (error) {
      return { success: false, error: error?.response?.data?.message || 'Failed to save.' };
    }
  }

  async delete(param) {
    try {
      const res = await axios.post(`${this.apiBase}/delete`, param);
      return { success: true, data: res.data };
    } catch (error) {
      return { success: false, error: error?.response?.data?.message || 'Failed to delete.' };
    }
  }
}

const FeatureNameServiceInstance = new FeatureNameService();
export default FeatureNameServiceInstance;
```

---

## 3. Wire Into the App Shell

- Add lazy-loaded routes in `src/AppRoutes.jsx`:
  ```jsx
  const FeatureNameList = React.lazy(() => import('./features/FeatureName'));
  const AddFeatureName  = React.lazy(() => import('./features/FeatureName/Add'));

  // inside <Routes>
  <Route path="/feature-url" element={<ProtectedRoute><FeatureNameList /></ProtectedRoute>} />
  <Route path="/feature-url/add" element={<ProtectedRoute><AddFeatureName /></ProtectedRoute>} />
  <Route path="/feature-url/edit/:id" element={<ProtectedRoute><AddFeatureName /></ProtectedRoute>} />
  ```

- Add a menu entry in `src/helpers/menuItems.js`:
  ```js
  { label: 'Feature Name', path: '/feature-url', icon: 'bi-grid' },
  ```

## 4. If UI Reference Data Is Needed

If the form requires dropdown data from the API (e.g. a `select` field bound to a lookup table), add a `getUi()` method to `service.js` and load it with `useState` + `useEffect` in `Add.jsx`, then pass the result into the relevant field's `dataBinding.data`.

## 5. Final Checks

- Replace all `FeatureName`, `feature-url`, and `feature-endpoint` placeholders with actual values.
- Verify naming consistency across routes, menu entries, folder names, and service exports.
- Confirm API endpoint paths with the back-end contract.
- Remind the user to add any required environment variables to `.env` if the endpoint base URL differs.
