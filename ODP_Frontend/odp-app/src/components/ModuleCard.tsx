import React from "react";
import { Card, CardContent, Typography } from "@mui/material";

interface ModuleCardProps {
  title: string;
  desc: string;
  onClick?: () => void;
}

const ModuleCard: React.FC<ModuleCardProps> = ({ title, desc, onClick }) => (
  <Card
    variant="outlined"
    onClick={onClick}
    sx={{
      cursor: 'pointer',
      mb: 2,
      '&:hover': {
        boxShadow: 4,
        borderColor: '#2155cd',
      }
    }}
  >
    <CardContent>
      <Typography variant="h6" color="primary">{title}</Typography>
      <Typography variant="body2">{desc}</Typography>
    </CardContent>
  </Card>
);

export default ModuleCard;
