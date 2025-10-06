// src/pages/LandingPage.tsx
import React, { useEffect, useState } from "react";
import Header from "../components/Header";
import Footer from "../components/Footer";
import { Navigate, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../store/hooks";
import { logout } from "../features/auth/authSlice";
import { selectLoginDisplayModel } from "../features/auth/authSelector";
import LandingLayout from "../layouts/LandingLayout";
import ModuleCardsWrapper from "../components/ModuleCardsWrapper";
import Box from "@mui/material/Box";
  const LandingPage: React.FC = () => {
  const [notifications, setNotifications] = useState(5);
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
// Select user from auth slice
  // const user = useAppSelector(state => state.auth.user);
  const loginDisplay = useAppSelector(selectLoginDisplayModel);

  const modules = [
  { title: "Orphans", desc: "Manage orphan records; track and support." },
  { title: "Companies", desc: "Register, list, and manage company partners." },
  { title: "Service Providers", desc: "View and onboard service providers." }
];

const adsContent = (
  <>
    <h2>Welcome to ODP!</h2>
    <ul>
      <li>🎉 Exclusive offers for first-time users!</li>
      <li>🚀 Explore Service Provider module</li>
    </ul>
    <p>Stay tuned for updates and new features.</p>
  </>
);
  
  useEffect(() => {
    if (!loginDisplay) {
      navigate("/"); // Navigate after render
    }
  }, [loginDisplay, navigate]);

  const handleOnLogout = () => {
    dispatch(logout());
    navigate('/'); 
  };
  if (!loginDisplay) {
    return <Navigate to="/" replace />;
  }
  return (
    <>
      <Header
        companyName= {loginDisplay ? loginDisplay.orgName : ""}
        roleType= {loginDisplay ? loginDisplay.roleType : ""}
        userName= {loginDisplay ? loginDisplay.firstName : ""}
        title="Orphan Development Product"
        backgroundColor="#4109ff"
        showSearch
        onSearchChange={(val) => setSearchTerm(val)}
        showNotifications
        notificationCount={notifications}
        onNotificationClick={() => alert("Notification clicked!")}
        buttons={[
          {
            label: "Logout",
            onClick: handleOnLogout,
            color: "secondary",
            variant: "contained",
          },
        ]}
      />
     <Box
        sx={{
          height: "calc(100vh - 66px - 66px)", // adjust if header/footer heights differ
          overflowY: "hidden",
          display: "flex",
          flexDirection: "column",
        }}
      >
        <LandingLayout
          left={adsContent}
          right={<ModuleCardsWrapper modules={modules} />}
        />
      </Box>
      <Footer isAuthenticated />
    </>
  );
};

export default LandingPage;
