// src/pages/LandingPage.tsx
import React, { useEffect, useState } from "react";
import Header from "../components/Header";
import Footer from "../components/Footer";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import { Navigate, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../store/hooks";
import { logout } from "../features/auth/authSlice";
import { GetFormatedUserInfo } from "../utils/userFormatter";
import { selectLoginDisplayModel } from "../features/auth/authSelector";
  const LandingPage: React.FC = () => {
  const [notifications, setNotifications] = useState(5);
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
// Select user from auth slice
  // const user = useAppSelector(state => state.auth.user);
  const loginDisplay = useAppSelector(selectLoginDisplayModel);
  
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
      <Container sx={{ mt: 4, mb: 4 }}>
        <Typography variant="h4" component="h1" gutterBottom>
          Welcome to the ODP Dashboard!
        </Typography>
        <Typography variant="body1">
          Here is the personalized landing page content after login.
        </Typography>
      </Container>
      <Footer isAuthenticated />
    </>
  );
};

export default LandingPage;
