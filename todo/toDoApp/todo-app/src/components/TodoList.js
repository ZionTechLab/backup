import React from 'react';
import { DragDropContext, Droppable, Draggable } from '@hello-pangea/dnd';
import TodoItem from './TodoItem';
import { MDBListGroup } from 'mdb-react-ui-kit';

const TodoList = ({ todos, toggleComplete, deleteTodo, editTodo, handleOnDragEnd }) => {
  return (
    <DragDropContext onDragEnd={handleOnDragEnd}>
      <Droppable droppableId="todos">
        {(provided) => (
          <MDBListGroup {...provided.droppableProps} ref={provided.innerRef}>
            {todos.map((todo, index) => (
              <Draggable key={todo.id} draggableId={todo.id.toString()} index={index}>
                {(provided) => (
                  <div
                    ref={provided.innerRef}
                    {...provided.draggableProps}
                    {...provided.dragHandleProps}
                  >
                    <TodoItem
                      todo={todo}
                      toggleComplete={toggleComplete}
                      deleteTodo={deleteTodo}
                      editTodo={editTodo}
                    />
                  </div>
                )}
              </Draggable>
            ))}
            {provided.placeholder}
          </MDBListGroup>
        )}
      </Droppable>
    </DragDropContext>
  );
};

export default TodoList;
