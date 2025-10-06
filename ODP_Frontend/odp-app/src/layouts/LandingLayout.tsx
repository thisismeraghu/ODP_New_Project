import React from "react";
import { Grid, Box } from "@mui/material";

interface LandingLayoutProps {
  left: React.ReactNode;
  right: React.ReactNode;
}

const LandingLayout: React.FC<LandingLayoutProps> = ({ left, right }) => (
  <Grid
    container
    sx={{
    minHeight: "100vh",
    marginX: "auto",
    bgcolor: "background.default",
    display: "flex",
  }}
  >
    {/* Left Section: 65% */}
    <Grid
      item
      xs={12}
      md={8}
      sx={{
        background: "linear-gradient(135deg,#2155cd 55%,#e6eafc 100%)",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        minHeight: "100vh",
        p: { xs: 3, md: 6 },
      }}
    >
      <Box
        sx={{
          width: "100%",
          maxWidth: 600,
          color: "#fff",
        }}
      >
        {left}
      </Box>
    </Grid>

    {/* Right Section: 35% */}
    <Grid
      item
      xs={12}
      md={4}
      sx={{
        p: { xs: 3, md: 6 },
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        minHeight: "100vh",
      }}
    >
      <Box sx={{ width: "100%", maxWidth: 400 }}>{right}</Box>
    </Grid>
  </Grid>
);

export default LandingLayout;
