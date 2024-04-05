import { todoInstance } from '../utils/todoInstance.js';

export const getTodo = (quertString = '') => todoInstance.get(`/api/todo/get?${quertString}`);
