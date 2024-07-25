import { fileURLToPath, URL } from 'node:url';

import { defineConfig, loadEnv } from 'vite';
import vue from '@vitejs/plugin-vue';

// https://vitejs.dev/config/
export default defineConfig(({ command, mode }) => {
  const env = loadEnv(mode, process.cwd(), '');
  const vite_env = env.VITE_ENV;

  // 設定proxy
  let proxy;
  if (vite_env === 'development') {
    proxy = {
      '/todo_baseUrl': {
        //target: 'https://localhost:7081',
        target: 'https://61.63.82.181/todo',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/todo_baseUrl/, ''),
        secure: false
      }
    };
  } else {
    proxy = {};
  }

  return {
    build: {
      emptyOutDir: true
    },
    plugins: [vue()],
    resolve: {
      alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url))
      }
    },
    server: {
      proxy: proxy
    }
  };
});
