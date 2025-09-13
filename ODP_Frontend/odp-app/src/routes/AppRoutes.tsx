// src/routes/AppRoutes.tsx
import React, { lazy, Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import CircularProgress from '@mui/material/CircularProgress';

// Lazy load pages
const HomePage = lazy(() => import('../pages/HomePage'));
const LandingPage = lazy(() => import('../pages/LandingPage'));
// Add other lazy imports for your pages here

const LoadingFallback: React.FC = () => (
  <div style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}>
    <CircularProgress />
  </div>
);

const AppRoutes: React.FC = () => {
  return (
    <Router>
      <Suspense fallback={<LoadingFallback />}>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/landing" element={<LandingPage />} />
          {/* Add more routes here with lazy-loaded components */}
        </Routes>
      </Suspense>
    </Router>
  );
};

export default AppRoutes;
