import {
  createSlice,
  createAsyncThunk,
  type PayloadAction,
} from "@reduxjs/toolkit";
import type { LoginResponseDTO } from "./types";
import { loginUser } from "./authApi";
import type { LoginRequestDTO } from "../../types/DTOs/loginRequestDTO";
import type { AuthDomainModel } from "../../types/DomainModels/authDomainModel";
import { mapLoginResponseDtoToAuthDomainModel } from "../../utils/mappers/ResponseDtoToDomainMapper";

interface AuthState {
  user: AuthDomainModel | null;
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
  localStorage.setItem(
    "authState",
    JSON.stringify({
      user: state.user,
    })
  );
};

// Retrieve persisted auth state from localStorage
export const getPersistedAuthState = (): Partial<AuthState> => {
  const data = localStorage.getItem("authState");
  if (!data) return {};
  try {
    const parsed = JSON.parse(data); // Defensive: Make sure parsed.user is not null/undefined/empty
    if (parsed && parsed.user) {
      return { user: parsed.user };
    }
    return {};
  } catch {
    return {};
  }
};

// Async thunk handles login API call lifecycle
export const loginAsync = createAsyncThunk<AuthDomainModel, LoginRequestDTO>(
  "auth/login",
  async (payload, { rejectWithValue }) => {              
    try {
      const response = await loginUser(payload);
      if (!response) throw new Error("Login failed");
      const dto: LoginResponseDTO = await response;
      return mapLoginResponseDtoToAuthDomainModel(dto); // Map DTO to Domain Model

    } catch (error: any) {
      return rejectWithValue(error.response?.data?.message || error.message);
    }
  }
);
const persisted = getPersistedAuthState();

const authSlice = createSlice({
  name: "auth",
  initialState: { ...initialState, ...persisted },
  reducers: {
    logout(state) {
      state.user = null;
      state.error = null;
      state.loading = false;
      localStorage.removeItem("authState"); // Remove on logout
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(loginAsync.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(
        loginAsync.fulfilled,
        (state, action: PayloadAction<AuthDomainModel>) => {
          state.user = action.payload;
          state.loading = false;
          state.error = null;
          persistAuthState(state); // Save to localStorage!
        }
      )
      .addCase(loginAsync.rejected, (state, action) => {
        state.error = (action.payload as string) || "Login failed";
        state.loading = false;
      });
  },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
