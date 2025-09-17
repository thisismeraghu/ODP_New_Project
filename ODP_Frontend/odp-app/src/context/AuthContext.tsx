// src/context/AuthContext.tsx
import React, { createContext, useState, useContext } from 'react';

interface User {
  username: string;
}

interface AuthContextType {
  user: string | null;
  token: string | null;
  setAuth: (user: string, token: string) => void;
  clearAuth: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<string | null>(null);
  const [token, setToken] = useState<string | null>(null);

   const setAuth = (user: string, token: string) => {
    setUser(user);
    setToken(token);
  };

  const clearAuth = () => {
    setUser(null);
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ user, token, setAuth, clearAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error('useAuth must be used within AuthProvider');
  return context;
};
