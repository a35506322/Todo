import axios from 'axios';

const env = import.meta.env;
console.log(env.VITE_TODO_API_BASEURL);
export const todoInstance = axios.create({
  baseURL: env.VITE_TODO_API_BASEURL
});
