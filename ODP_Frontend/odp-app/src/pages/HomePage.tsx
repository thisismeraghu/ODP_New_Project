import React, { useState } from "react";
import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Header from "../components/Header";
import Footer from "../components/Footer";
import LoginDialog from "../components/LoginDialog";
import { loginUser } from "../features/auth/authApi";
import { useNavigate } from 'react-router-dom';
import { Snackbar } from "@mui/material";
import { useAuth } from "../context/AuthContext";

const HomePage: React.FC = () => {
  const [loginOpen, setLoginOpen] = useState(false);
  const [snackbarOpen, setSnackbarOpen] = useState(false);
  const navigate = useNavigate(); // Call the hook to get the function
  const { setAuth } = useAuth();

  // Define the handler to close login dialog
  const closeLoginDialogBox = () => {
    setLoginOpen(false);
  };

  const openLoginDialogBox = () => {
    setLoginOpen(true);
  };

  const handleLoginSubmit = async (username: string, password: string) => {
    try{
        console.log("Credentials received in HomePage:", { username, password });
        const response = await loginUser({ username, password });
        setAuth(response.user, response.token);
        
        setSnackbarOpen(true);
        setTimeout(() => {
        setSnackbarOpen(false);
        closeLoginDialogBox();
        navigate("/landing"); // Redirect to landing page after login
        }, 1500);
    }catch(error){
        console.error("Login failed:", error);
    }
  };

  return (
    <>
      <Box minHeight="100vh" display="flex" flexDirection="column">
        <Header
          title="Orphan Development Product"
          backgroundColor="#00695c"
          titleColor="#fff"
          buttons={[
            {
              label: "Login",
              onClick: openLoginDialogBox,
              color: "secondary",
              variant: "contained",
            },
            {
              label: "SignUp",
              onClick: () => alert("SignUp clicked"),
              color: "secondary",
              variant: "contained",
            },
          ]}
        />
        {/* Rest of page */}
        <Container sx={{ flexGrow: 1, py: 5 }}>
          <Grid container spacing={4} alignItems="center">
            <Grid item xs={12} md={6}>
              <Typography variant="h3" component="h1" gutterBottom>
                Welcome to ODP
              </Typography>
              <Typography variant="h6" color="text.secondary" paragraph>
                Manage orphans, service providers, and organization problems,
                all in one place. Responsive, intuitive and built for every
                device!
              </Typography>
            </Grid>
            <Grid item xs={12} md={6}>
              <Box
                component="img"
                src="https://images.unsplash.com/photo-1506744038136-46273834b3fb?w=800"
                alt="Orphans"
                sx={{
                  width: "100%",
                  maxHeight: 300,
                  borderRadius: 3,
                  boxShadow: 3,
                  objectFit: "cover",
                }}
              />
            </Grid>
          </Grid>
        </Container>
        <LoginDialog
          open={loginOpen}
          onClose={closeLoginDialogBox}
          onLoginSubmit={handleLoginSubmit}
        />
         <Snackbar
        open={snackbarOpen}
        autoHideDuration={2000}
        message="Login Successful!"
        onClose={() => setSnackbarOpen(false)}
        anchorOrigin={{ vertical: 'top', horizontal: 'center' }}
      />
        <Footer />
      </Box>
    </>
  );
};

export default HomePage;
