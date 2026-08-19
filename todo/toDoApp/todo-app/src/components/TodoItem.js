import React, { useState } from 'react';
import {
  MDBListGroupItem,
  MDBBtn,
  MDBBadge,
  MDBIcon,
  MDBInput,
} from 'mdb-react-ui-kit';

const TodoItem = ({ todo, toggleComplete, deleteTodo, editTodo }) => {
  const [isEditing, setIsEditing] = useState(false);
  const [newText, setNewText] = useState(todo.text);

  const handleSave = () => {
    editTodo(todo.id, newText);
    setIsEditing(false);
  };

  const getPriorityColor = (priority) => {
    switch (priority) {
      case 'high':
        return 'danger';
      case 'medium':
        return 'warning';
      case 'low':
        return 'success';
      default:
        return 'primary';
    }
  };

  return (
    <MDBListGroupItem
      className={`d-flex justify-content-between align-items-center ${
        todo.completed ? 'bg-light' : ''
      }`}
    >
      {isEditing ? (
        <div className="d-flex w-100">
          <MDBInput
            type="text"
            value={newText}
            onChange={(e) => setNewText(e.target.value)}
            className="me-2"
          />
          <MDBBtn color="success" size="sm" onClick={handleSave}>
            <MDBIcon fas icon="save" />
          </MDBBtn>
        </div>
      ) : (
        <>
          <div>
            <p
              className={`fw-bold mb-1 ${
                todo.completed ? 'text-decoration-line-through' : ''
              }`}
            >
              {todo.text}
            </p>
            {todo.dueDate && (
              <p className="text-muted mb-0">Due: {todo.dueDate}</p>
            )}
            <MDBBadge color={getPriorityColor(todo.priority)} pill>
              {todo.priority}
            </MDBBadge>
            <div className="mt-2">
              {todo.tags.map(tag => (
                <MDBBadge key={tag} color="info" pill className="me-2">
                  {tag}
                </MDBBadge>
              ))}
            </div>
          </div>
          <div>
            <MDBBtn
              color="primary"
              size="sm"
              onClick={() => setIsEditing(true)}
              className="me-2"
            >
              <MDBIcon fas icon="edit" />
            </MDBBtn>
            <MDBBtn
              color={todo.completed ? 'warning' : 'success'}
              size="sm"
              onClick={() => toggleComplete(todo.id)}
              className="me-2"
            >
              <MDBIcon fas icon={todo.completed ? 'undo' : 'check'} />
            </MDBBtn>
            <MDBBtn
              color="danger"
              size="sm"
              onClick={() => deleteTodo(todo.id)}
            >
              <MDBIcon fas icon="trash" />
            </MDBBtn>
          </div>
        </>
      )}
    </MDBListGroupItem>
  );
};

export default TodoItem;
