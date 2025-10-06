import React from "react";
import { Box } from "@mui/material";
import ModuleCard from "./ModuleCard";

interface Module {
  title: string;
  desc: string;
  onClick?: () => void;
}

interface ModuleCardsWrapperProps {
  modules: Module[];
}

const ModuleCardsWrapper: React.FC<ModuleCardsWrapperProps> = ({ modules }) => (
  <Box sx={{ width: '100%', maxWidth: 350 }}>
    {modules.map((mod, i) =>
      <ModuleCard key={`${mod.title}-${i}`} {...mod} />
    )}
  </Box>
);

export default ModuleCardsWrapper;
