# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can't go back!**

If you aren't satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you're on your own.

You don't have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn't feel obligated to use this feature. However we understand that this tool wouldn't be useful if you couldn't customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).

## Development Mock API (UOM Master)

For local testing without a backend, a lightweight mock API is provided for the UOM Master feature.

How it works:
* Controlled by `config.features.useMockApi` and `config.features.mockEntities` (see `src/config/config.js`).
* When true, `src/index.js` dynamically imports `mocks/fakeApi`.
* `mockEntities: ['uom','item']` enables multiple entity mocks in one framework.
* Intercepts axios requests to `${config.apiBaseUrl}uom/*` endpoints.
* Data is persisted in `localStorage` under key `mock.uoms`.

Supported mocked endpoints:
* `GET  uom/get-all` – returns full list.
* `GET  uom/get?id={id}` – returns a single record.
* `POST uom/update` – create (`id` 0 / missing) or update (existing id) with body `{ header: { ...fields }, isUpdate }`.
* `POST uom/delete` – delete via body `{ id }`.

Seed Data (auto-inserted once):
```
1 PCS  Pieces
2 KG   Kilogram
3 LTR  Liter
```

Resetting data:
* Clear browser localStorage key `mock.uoms` (DevTools > Application > Local Storage) and refresh.

Disabling mock:
* Remove or comment the import block in `src/index.js`:
	```js
	// if (process.env.NODE_ENV === 'development') {
	//   import('./mocks/fakeApi').then(mod => mod.registerFakeApi && mod.registerFakeApi());
	// }
	```

Extending mock for other entities:
1. Add an entry in `ENTITY_CONFIG` inside `mocks/fakeApi.js` with:
	- storage (localStorage key)
	- seed (array)
	- buildNew(header, id, gen)
	- mapUpdate(existing, header)
	- optional codeField + nameField for auto-code generation.
2. Add the entity key to `config.features.mockEntities`.
3. Use endpoints: `{apiBaseUrl}<entity>/get-all|get|update|delete` matching existing pattern.

All auth goes through the real backend. No mock auth in the codebase.

Security Note: Never commit real credentials into the mock file; keep it generic.


### Code Splitting

This section has moved here: [https://facebook.github.io/create-react-app/docs/code-splitting](https://facebook.github.io/create-react-app/docs/code-splitting)

### Analyzing the Bundle Size

This section has moved here: [https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size](https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size)

### Making a Progressive Web App

This section has moved here: [https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app](https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app)

### Advanced Configuration

This section has moved here: [https://facebook.github.io/create-react-app/docs/advanced-configuration](https://facebook.github.io/create-react-app/docs/advanced-configuration)

### Deployment

This section has moved here: [https://facebook.github.io/create-react-app/docs/deployment](https://facebook.github.io/create-react-app/docs/deployment)

### `npm run build` fails to minify

This section has moved here: [https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify](https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify)
