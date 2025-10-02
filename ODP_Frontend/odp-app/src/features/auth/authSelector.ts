import { createSelector } from "@reduxjs/toolkit";
import type { RootState } from "../../store/redux_store";
import { mapAuthDomainToLoginDisplay } from "../../utils/mappers/DomainToDisplayModelMapper";

export const selectAuthDomain = (state: RootState) => state.auth;

export const selectLoginDisplayModel = createSelector(
  [selectAuthDomain],
  (auth) => (auth.user ? mapAuthDomainToLoginDisplay(auth.user) : null)
);
