import React from "react";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";

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
  {/* Left Section: 70% width on medium screens and up */}
  <Grid
    item
    xs={12}
    sx={{
      width: { md: '70%' }, // Explicitly set width to 70% on medium screens and up
      background: "linear-gradient(135deg,#2155cd 55%,#e6eafc 100%)",
      display: "flex",
      alignItems: "center",
      justifyContent: "center",
      minHeight: "100vh",
      marginY: { xs: 0, md: 'auto' },
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

  {/* Right Section: 30% width on medium screens and up */}
  <Grid
    item
    xs={12}
    sx={{
      width: { md: '30%' }, // Explicitly set width to 30% on medium screens and up
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
