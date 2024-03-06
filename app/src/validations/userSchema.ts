import { z } from "zod";

const genres = ["female", "male"] as const;

export type Genres = (typeof genres)[number];

export const mappedGenres: {[key in Genres]: string} = {
    male: "Masculino",
    female: "Femenino",
}

export const userSchema = z.object({
  firstName: z
    .string()
    .min(2, {
      message: "El Primer Nombre debe contener al menos 2 caracteres",
    })
    .max(100, {
      message: "El Primer Nombre contiene demasiados caracteres",
    }),
  secondName: z
    .string()
    .min(2, {
      message: "El Segundo Nombre debe contener al menos 2 caracteres",
    })
    .max(100, {
      message: "El Segundo Nombre contiene demasiados caracteres",
    })
    .optional(),
  fatherLastName: z
    .string()
    .min(2, {
      message: "El Primer Apellido debe contener al menos 2 caracteres",
    })
    .max(100, {
      message: "El Primer Apellido contiene demasiados caracteres",
    }),
  motherLastName: z
    .string()
    .min(2, {
      message: "El Segundo Apellido debe contener al menos 2 caracteres",
    })
    .max(100, {
      message: "El Segundo Apellido contiene demasiados caracteres",
    })
    .optional(),
  email: z
    .string()
    .email({
      message: "Please enter a valid email",
    })
    .optional(),
  phone: z
    .string()
    .min(6, {
      message: "Password must be at least 6 characters long",
    })
    .optional(),
  address: z
    .string()
    .min(6, {
      message: "La dirección debe ser válida",
    }),
  age: z
    .string()
    .refine((age) => !isNaN(parseFloat(age)), {
      message: "La edad debe ser válida",
    })
    .transform((age) => parseInt(age, 10))
    .refine((age) => age >= 0 && age < 120, {
      message: "La edad debe ser válida",
    }),
  genre: z
    .enum(genres, {
      errorMap: () => ({ message: "Por favor selecciona tu género" }),
    }),
})
