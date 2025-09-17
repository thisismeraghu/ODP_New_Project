import { createSlice, createAsyncThunk, type PayloadAction } from '@reduxjs/toolkit';
import type { LoginPayload, LoginResponse } from './types';
import { loginUser } from './authApi';


interface AuthState {
  user: LoginResponse | null;
  loading: boolean;
  error: string | null;
}

const initialState: AuthState = {
  user: null,
  loading: false,
  error: null,
};

// Persist auth state to localStorage
const persistAuthState = (state: AuthState) => {
  localStorage.setItem('authState', JSON.stringify({
    user: state.user,
  }));
};

// Retrieve persisted auth state from localStorage
export const getPersistedAuthState = (): Partial<AuthState> => {
  const data = localStorage.getItem('authState');
  if (!data) return {};
  try {
    return JSON.parse(data);
  } catch {
    return {};
  }
};

// Async thunk handles login API call lifecycle
export const loginAsync = createAsyncThunk<LoginResponse, LoginPayload>(
  'auth/login',
  async (payload, { rejectWithValue }) => {
    try {
      return await loginUser(payload);
    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || error.message);
    }
  }
);

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout(state) {
      state.user = null;
      state.error = null;
      state.loading = false;
      localStorage.removeItem('authState'); // Remove on logout
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(loginAsync.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(loginAsync.fulfilled, (state, action: PayloadAction<LoginResponse>) => {
        state.user = action.payload;
        state.loading = false;
        state.error = null;
        persistAuthState(state); // Save to localStorage!
      })
      .addCase(loginAsync.rejected, (state, action) => {
        state.error = action.payload as string || 'Login failed';
        state.loading = false;
      });
  },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
