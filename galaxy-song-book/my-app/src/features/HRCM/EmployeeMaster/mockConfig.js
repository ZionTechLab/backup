// // Mock configuration for UOM entity (consumed by generic mock API registry)
// // Keeps seed data separate in seedData.js for clarity and potential reuse.
// const uomSeedData = [
//   { id: 1, uomCode: 'PCS', uomName: 'Pieces', description: 'Single piece unit', active: true },
//   { id: 2, uomCode: 'KG',  uomName: 'Kilogram', description: 'Weight in kilograms', active: true },
//   { id: 3, uomCode: 'LTR', uomName: 'Liter', description: 'Volume in liters', active: true },
// ];

// const uomMockConfig = {
//   storage: 'mock.uoms',
//   seed: uomSeedData,
//   idField: 'id',
//   code: { field: 'uomCode', from: 'uomName', length: 3 },
//   createFields: ['uomName', 'description', 'active'],
//   updateFields: ['uomName', 'description', 'active'],
// };

// export default uomMockConfig;
