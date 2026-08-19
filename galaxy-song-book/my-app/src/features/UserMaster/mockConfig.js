// Mock configuration for Users entity (consumed by generic mock API registry)
// Seed data (inlined after merging former seedData.js)
const userRolesSeed = [
  { id: 1, roleName: 'Admin' },
  { id: 2, roleName: 'Manager' },
  { id: 3, roleName: 'User' },
];

const usersSeedData = [
  {
    id: 1,
    userName: 'admin',
    fullName: 'System Administrator',
    email: 'admin@example.com',
    phone: '0711111111',
    phone2: '',
    roleId: 1,
    active: true,
  },
  {
    id: 2,
    userName: 'manager',
    fullName: 'Site Manager',
    email: 'manager@example.com',
    phone: '0722222222',
    phone2: '',
    roleId: 2,
    active: true,
  },
  {
    id: 3,
    userName: 'user1',
    fullName: 'First User',
    email: 'user1@example.com',
    phone: '0733333333',
    phone2: '',
    roleId: 3,
    active: true,
  }
];

const usersMockConfig = {
  storage: 'mock.users',
  seed: usersSeedData,
  idField: 'id',
  createFields: ['userName','password','fullName','email','phone','phone2','roleId','active'],
  updateFields: ['fullName','email','phone','phone2','roleId','active','password'],
  uiData: { Role: userRolesSeed },
  omitEmptyOnUpdate: ['password']
};

export default usersMockConfig;
