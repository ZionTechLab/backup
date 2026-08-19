import React, { useState, useEffect } from 'react';
import { v4 as uuidv4 } from 'uuid';
import TodoList from './components/TodoList';
import AddTodoForm from './components/AddTodoForm';
import ThemeToggler from './components/ThemeToggler';
import FilterControls from './components/FilterControls';
import { MDBContainer } from 'mdb-react-ui-kit';

function App() {
  const [todos, setTodos] = useState([
    { id: uuidv4(), text: 'Learn React', completed: false, dueDate: null, priority: 'medium', tags: ['react', 'learning'] },
    { id: uuidv4(), text: 'Build a Todo App', completed: false, dueDate: null, priority: 'high', tags: ['project'] },
  ]);
  const [theme, setTheme] = useState('light');
  const [showCompleted, setShowCompleted] = useState(true);

  useEffect(() => {
    if (theme === 'dark') {
      document.body.classList.add('dark-theme');
    } else {
      document.body.classList.remove('dark-theme');
    }
  }, [theme]);

  const toggleTheme = () => {
    setTheme(theme === 'light' ? 'dark' : 'light');
  };

  const toggleShowCompleted = () => {
    setShowCompleted(!showCompleted);
  };

  const addTodo = (text, dueDate, priority, tags) => {
    const newTodos = [...todos, { id: uuidv4(), text, completed: false, dueDate, priority, tags }];
    setTodos(newTodos);
  };

  const editTodo = (id, newText) => {
    const newTodos = todos.map(todo =>
      todo.id === id ? { ...todo, text: newText } : todo
    );
    setTodos(newTodos);
  };

  const toggleComplete = id => {
    const newTodos = todos.map(todo =>
      todo.id === id ? { ...todo, completed: !todo.completed } : todo
    );
    setTodos(newTodos);
  };

  const deleteTodo = id => {
    if (window.confirm('Are you sure you want to delete this task?')) {
      const newTodos = todos.filter(todo => todo.id !== id);
      setTodos(newTodos);
    }
  };

  const handleOnDragEnd = (result) => {
    if (!result.destination) return;
    const items = Array.from(todos);
    const [reorderedItem] = items.splice(result.source.index, 1);
    items.splice(result.destination.index, 0, reorderedItem);
    setTodos(items);
  };

  const filteredTodos = showCompleted ? todos : todos.filter(todo => !todo.completed);

  return (
    <MDBContainer className={`py-5 ${theme}`}>
      <div className="d-flex justify-content-between align-items-center mb-4">
        <h1>Todo List</h1>
        <ThemeToggler theme={theme} toggleTheme={toggleTheme} />
      </div>
      <AddTodoForm addTodo={addTodo} />
      <FilterControls
        showCompleted={showCompleted}
        toggleShowCompleted={toggleShowCompleted}
      />
      <TodoList
        todos={filteredTodos}
        toggleComplete={toggleComplete}
        deleteTodo={deleteTodo}
        editTodo={editTodo}
        handleOnDragEnd={handleOnDragEnd}
      />
    </MDBContainer>
  );
}

export default App;
