import React from 'react';
import { MDBSwitch } from 'mdb-react-ui-kit';

const FilterControls = ({ showCompleted, toggleShowCompleted }) => {
  return (
    <div className="d-flex justify-content-end mb-3">
      <MDBSwitch
        checked={showCompleted}
        onChange={toggleShowCompleted}
        label="Show Completed Tasks"
      />
    </div>
  );
};

export default FilterControls;
