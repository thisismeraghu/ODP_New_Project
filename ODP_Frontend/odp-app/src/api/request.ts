import httpClient from './httpClient';

export type HttpMethod = 'GET' | 'POST' | 'PUT' | 'DELETE' | 'PATCH';

// TData is the generic type for the request body
export interface ApiRequestConfig<TData> {
  path: string;
  method?: HttpMethod;
  data?: TData;
  // Using Record<string, unknown> is safer than any
  params?: Record<string, unknown>;
}

// Add TData generic to the function signature
export async function apiRequest<T, TData = unknown>({
  path,
  method = 'GET',
  data,
  params,
}: ApiRequestConfig<TData>): Promise<T> {
  try {
    const response = await httpClient.request<T>({
      url: path,
      method,
      data,
      params,
    });
    return response.data;
  } catch (error) { // Error is now type unknown by default in strict mode
    // Safely check and handle the error
    if (error instanceof Error) {
      // You can now access error properties with type safety
      console.error('API Error:', error.message);
    }
    throw error; // Re-throw the error to propagate it
  }
}
