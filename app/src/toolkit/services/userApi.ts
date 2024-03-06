import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

type User = {
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
    baseUrl: "http://localhost:8080/api/",
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
    getUserById: builder.query<User, { id: string }>({
      query: ({ id }) => `users/${id}`,
    }),
  }),
});

export const { useGetUsersQuery, useGetUserByIdQuery } = userApi;