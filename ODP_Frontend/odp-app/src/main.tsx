import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { AuthProvider } from './context/AuthContext.tsx'
import { Provider } from 'react-redux'
import { store } from './store/redux_store.ts'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    {/* <AuthProvider>
      <App />
    </AuthProvider> */}
     {/* <App /> */}
     <Provider store={store}>
      <App />
     </Provider>
  </StrictMode>,
)
