import React, { ChangeEvent } from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import Badge from '@mui/material/Badge';
import SearchIcon from '@mui/icons-material/Search';
import NotificationsIcon from '@mui/icons-material/Notifications';
import InputBase from '@mui/material/InputBase';
import { styled, alpha } from '@mui/material/styles';

interface HeaderButton {
  label: string;
  onClick: () => void;
  color?: 'inherit' | 'primary' | 'secondary' | 'default';
  variant?: 'text' | 'outlined' | 'contained';
  disabled?: boolean;
}

interface HeaderProps {
  title: string;
  titleColor?: string;
  backgroundColor?: string;
  buttons?: HeaderButton[];

  // Search
  showSearch?: boolean;
  searchPlaceholder?: string;
  onSearchChange?: (value: string) => void;

  // Notifications
  showNotifications?: boolean;
  notificationCount?: number;
  onNotificationClick?: () => void;
}

// Styled components for Search box
const Search = styled('div')(({ theme }) => ({
  position: 'relative',
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  '&:hover': {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginRight: theme.spacing(2),
  marginLeft: 0,
  width: '100%',
  [theme.breakpoints.up('sm')]: {
    width: 'auto',
  },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
  padding: theme.spacing(0, 1),
  height: '100%',
  position: 'absolute',
  pointerEvents: 'none',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: 'inherit',
  paddingLeft: `calc(1em + ${theme.spacing(3)})`,
  transition: theme.transitions.create('width'),
  width: '100%',
  [theme.breakpoints.up('sm')]: {
    width: '20ch',
    '&:focus': {
      width: '30ch',
    },
  },
}));

const Header: React.FC<HeaderProps> = ({
  title,
  titleColor = '#fff',
  backgroundColor = '#1976d2',
  buttons = [],
  showSearch = false,
  searchPlaceholder = 'Search…',
  onSearchChange,
  showNotifications = false,
  notificationCount = 0,
  onNotificationClick,
}) => {

  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    if (onSearchChange) {
      onSearchChange(event.target.value);
    }
  };

  return (
    <AppBar position="static" sx={{ backgroundColor }}>
      <Toolbar>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1, color: titleColor }}>
          {title}
        </Typography>

        {showSearch && (
          <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder={searchPlaceholder}
              inputProps={{ 'aria-label': 'search' }}
              onChange={handleSearchChange}
            />
          </Search>
        )}

        {showNotifications && (
          <IconButton color="inherit" onClick={onNotificationClick} aria-label="show notifications">
            <Badge badgeContent={notificationCount} color="error">
              <NotificationsIcon />
            </Badge>
          </IconButton>
        )}

        {buttons.map(({ label, onClick, color = 'inherit', variant = 'text', disabled }, index) => (
          <Button key={index} color={color} variant={variant} onClick={onClick} disabled={disabled} sx={{ ml: 1 }}>
            {label}
          </Button>
        ))}
      </Toolbar>
    </AppBar>
  );
};

export default Header;
