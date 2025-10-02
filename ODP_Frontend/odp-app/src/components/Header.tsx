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
  title?: string;
  companyName: string;
  userName: string;
  roleType: string;
  backgroundColor?: string;
  buttons?: HeaderButton[];
  showSearch?: boolean;
  searchPlaceholder?: string;
  onSearchChange?: (value: string) => void;
  showNotifications?: boolean;
  notificationCount?: number;
  onNotificationClick?: () => void;
}

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

// Container for the left side user info
const UserInfoContainer = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  gap: theme.spacing(1),
  flexGrow: 1,
}));

// Different styled spans for company, username and role
const CompanyText = styled(Typography)(({ theme }) => ({
  color: '#64B5F6', // Light Blue
  fontWeight: '700',
  fontSize: '1.25rem',
  fontFamily: 'Montserrat, sans-serif',
}));

const UserNameText = styled(Typography)(({ theme }) => ({
  color: '#81C784', // Light Green
  fontWeight: '600',
  fontSize: '1rem',
  fontStyle: 'italic',
  fontFamily: 'Roboto, sans-serif',
}));

const RoleText = styled(Typography)(({ theme }) => ({
  color: '#FFB74D', // Light Orange
  fontWeight: '500',
  fontSize: '0.875rem',
  fontFamily: 'Arial, sans-serif',
}));

const Header: React.FC<HeaderProps> = ({
  companyName,
  userName,
  roleType,
  backgroundColor = '#0D47A1',
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
        <UserInfoContainer>
          <CompanyText component="span">{companyName}</CompanyText>
          <Typography component="span" sx={{ color: '#FFFFFF' }}> - </Typography>
          <UserNameText component="span">{userName}</UserNameText>
          <RoleText component="span">({roleType})</RoleText>
        </UserInfoContainer>

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
