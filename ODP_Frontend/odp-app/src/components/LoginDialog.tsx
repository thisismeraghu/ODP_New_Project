import React, { useState } from 'react';
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Snackbar from '@mui/material/Snackbar';

interface LoginDialogProps {
  open: boolean;
  onClose: () => void;
  onLoginSubmit: (username: string, password: string) => void;
}

const LoginDialog: React.FC<LoginDialogProps> = ({ open, onClose, onLoginSubmit }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

   const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onLoginSubmit(username, password);
    onClose();
  };


return (
    <>
      <Dialog open={open} onClose={onClose}>
        <form onSubmit={handleSubmit}>
          <DialogTitle>Login</DialogTitle>
          <DialogContent>
            <TextField autoFocus margin="dense" label="Username" type="text" fullWidth variant="standard"
                       value={username} onChange={e => setUsername(e.target.value)} required />
            <TextField margin="dense" label="Password" type="password" fullWidth variant="standard"
                       value={password} onChange={e => setPassword(e.target.value)} required />
          </DialogContent>
          <DialogActions>
            <Button onClick={onClose}>Cancel</Button>
            <Button type="submit" variant="contained">Login</Button>
          </DialogActions>
        </form>
      </Dialog>
    </>
  );
};

export default LoginDialog;
