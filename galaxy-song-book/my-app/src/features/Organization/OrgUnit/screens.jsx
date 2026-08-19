import OrgUnitList from './index';
import AddOrgUnit from './Add';

export const BranchList = () => <OrgUnitList unitType="Branch" title="Branches" />;
export const DivisionList = () => <OrgUnitList unitType="Division" title="Divisions" />;
export const DepartmentList = () => <OrgUnitList unitType="Department" title="Departments" />;
export const SectionList = () => <OrgUnitList unitType="Section" title="Sections" />;

export const AddBranch = () => <AddOrgUnit unitType="Branch" />;
export const AddDivision = () => <AddOrgUnit unitType="Division" />;
export const AddDepartment = () => <AddOrgUnit unitType="Department" />;
export const AddSection = () => <AddOrgUnit unitType="Section" />;
