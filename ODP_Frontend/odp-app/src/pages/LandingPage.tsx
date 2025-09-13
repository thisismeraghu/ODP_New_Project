// src/pages/LandingPage.tsx
import React, { useState } from "react";
import Header from "../components/Header";
import Footer from "../components/Footer";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";

const LandingPage: React.FC = () => {
  const [notifications, setNotifications] = useState(5);
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();
  const { user } = useAuth();

//   if (!user) {
//     return navigate("/");; // or redirect
//   }
  const registerOrphan = () => {
    alert("Register Orphan Clicked");
  };

  return (
    <>
      <Header
        title={user?.name ? user?.name:" User"}
        backgroundColor="#410069ff"
        titleColor="#b74040ff"
        showSearch
        onSearchChange={(val) => setSearchTerm(val)}
        showNotifications
        notificationCount={notifications}
        onNotificationClick={() => alert("Notification clicked!")}
        buttons={[
          {
            label: "Register Orphan",
            onClick: registerOrphan,
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
