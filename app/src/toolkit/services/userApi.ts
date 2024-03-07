import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export type User = {
  id: number;
  firstName: string;
  secondName: string;
  fatherLastName: string;
  motherLastName: string;
  email: string;
  phone: string;
  address: string;
  age: number;
  genre: string;
};

export const userApi = createApi({
  reducerPath: "server",
  refetchOnFocus: true, // when the window is refocused, refetch the data
  baseQuery: fetchBaseQuery({
    baseUrl: "http://localhost:5263/api/"
  }),
  endpoints: (builder) => ({
    createUser: builder.mutation<User, { body: User }>({
      query: ({body}) => ({
        url: 'users',
        method: 'POST',
        body,
      })
    }),
    getUsers: builder.query<User[], null>({
      query: () => "users",
    }),
    countGenre: builder.query<any, { genre: string }>({
      query: ({ genre }) => `users/genre/${genre}`,
    }),
    getAverage: builder.query<any, null>({
      query: () => `users/average`,
    }),
    findMaxAge: builder.query<any, null>({
      query: () => `users/maxAge`,
    }),
  }),
});

export const { useGetUsersQuery, useCountGenreQuery, useCreateUserMutation, useFindMaxAgeQuery, useGetAverageQuery } = userApi;