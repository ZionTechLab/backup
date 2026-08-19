import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    proxy: {
      '/ado-api': {
        target: 'https://dev.azure.com',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/ado-api/, ''),
        configure: (proxy) => {
          proxy.on('proxyReq', (proxyReq, req) => {
            const pat = req.headers['x-ado-pat']
            if (pat) {
              const encoded = Buffer.from(`:${pat}`).toString('base64')
              proxyReq.setHeader('Authorization', `Basic ${encoded}`)
              proxyReq.removeHeader('x-ado-pat')
            }
          })
        }
      }
    }
  }
})
