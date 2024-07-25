import todoInstance from '../utils/todoInstance.js';

export const todoService = {
  getTodo: (quertString = '') => todoInstance.get(`/api/todo/get?${quertString}`),
  insertTodo: (data) => todoInstance.post('/api/todo/insertTodo', data),
  updateTodoStatus: (todoId, data) =>
    todoInstance.put(`/api/todo/updateTodoStatus/${todoId}`, data),
  deleteTodo: (todoId) => todoInstance.delete(`/api/todo/delete/${todoId}`),
  updateTodoContent: (todoId, data) =>
    todoInstance.put(`/api/todo/updateTodoContent/${todoId}`, data)
};
