import React from 'react';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';

interface FooterProps {
  isAuthenticated?: boolean;
}

const Footer: React.FC<FooterProps> = ({ isAuthenticated }) => (
  <Box component="footer" sx={{
    py: 2,
    px: 2,
    mt: 'auto',
    backgroundColor: (theme) => theme.palette.grey[200],
    textAlign: 'center',
  }}>
    <Typography variant="body2" color="text.secondary">
      {isAuthenticated
        ? `© ${new Date().getFullYear()} ODP Dashboard`
        : `© ${new Date().getFullYear()} this is TEXVEX Software Solutions`}
    </Typography>
  </Box>
);

export default Footer;