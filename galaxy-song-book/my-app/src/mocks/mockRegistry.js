import uomMockConfig from '../features/UomMaster/mockConfig';
import usersMockConfig from '../features/UserMaster/mockConfig';
import jobRegistrationMockConfig from '../features/JobRegistration/mockConfig';
import jobLogMockConfig from '../features/JobRegistration/jobLogMockConfig';

const mockRegistry = {
  uom: uomMockConfig,
  users: usersMockConfig,
  'job-registration': jobRegistrationMockConfig,
  'job-registration-log': jobLogMockConfig,
};

export default mockRegistry;