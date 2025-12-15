import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    // Proxy API requests to backend during development
    proxy: {
      '/api': {
        target: 'https://localhost:7224',
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path
      }
    },
    // History API fallback is enabled by default for Vite; keep this if custom server settings exist
    historyApiFallback: true
  }
});
