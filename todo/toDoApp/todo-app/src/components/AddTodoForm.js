import React, { useState } from 'react';
import { MDBBtn, MDBInput, MDBRow, MDBCol } from 'mdb-react-ui-kit';

const AddTodoForm = ({ addTodo }) => {
  const [value, setValue] = useState('');
  const [dueDate, setDueDate] = useState('');
  const [priority, setPriority] = useState('medium');
  const [tags, setTags] = useState('');

  const handleSubmit = e => {
    e.preventDefault();
    if (!value) return;
    const tagsArray = tags.split(',').map(tag => tag.trim());
    addTodo(value, dueDate, priority, tagsArray);
    setValue('');
    setDueDate('');
    setPriority('medium');
    setTags('');
  };

  return (
    <form onSubmit={handleSubmit} className="mb-4">
      <MDBRow className="g-3">
        <MDBCol md="12">
          <MDBInput
            label="Add a new task"
            type="text"
            value={value}
            onChange={e => setValue(e.target.value)}
          />
        </MDBCol>
        <MDBCol md="6">
          <MDBInput
            label="Due Date"
            type="date"
            value={dueDate}
            onChange={e => setDueDate(e.target.value)}
          />
        </MDBCol>
        <MDBCol md="6">
          <select
            className="form-select"
            value={priority}
            onChange={e => setPriority(e.target.value)}
          >
            <option value="low">Low</option>
            <option value="medium">Medium</option>
            <option value="high">High</option>
          </select>
        </MDBCol>
        <MDBCol md="12">
          <MDBInput
            label="Tags (comma-separated)"
            type="text"
            value={tags}
            onChange={e => setTags(e.target.value)}
          />
        </MDBCol>
        <MDBCol md="12">
          <MDBBtn type="submit" block>
            Add Todo
          </MDBBtn>
        </MDBCol>
      </MDBRow>
    </form>
  );
};

export default AddTodoForm;
