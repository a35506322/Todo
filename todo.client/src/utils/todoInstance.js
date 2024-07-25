import axios from 'axios';

const env = import.meta.env;
console.log(env.VITE_TODO_API_BASEURL);

const todoInstance = axios.create({
  baseURL: env.VITE_TODO_API_BASEURL
});

const errorHandle = (error) => {
  const { response } = error;
  const { status, data } = response;
  switch (status) {
    case 400:
      const { returnData } = data;
      let errorMsg = [];
      for (const [key, value] of Object.entries(returnData)) {
        errorMsg.push(`${key}: ${value.join(', ')}`);
      }
      alert(errorMsg.join('\n'));
      break;
    case 401:
      console.log('401', data);
      break;
    case 500:
      console.log('500', data);
      break;
    default:
      console.log('default', data);
      break;
  }
};

// Add a request interceptor
todoInstance.interceptors.request.use(
  function (config) {
    console.log('Request', config);
    return config;
  },
  function (error) {
    console.log('Request error', error);
    return Promise.reject(error);
  }
);

// Add a response interceptor
todoInstance.interceptors.response.use(
  function (response) {
    console.log('Response', response);
    return response;
  },
  function (error) {
    errorHandle(error);
    return Promise.reject(error);
  }
);

export default todoInstance;
