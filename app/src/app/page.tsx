"use client";

import { useForm, SubmitHandler } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { userSchema, mappedGenres } from "@/validations/userSchema";

type Inputs = {
  firstName: string;
  secondName: string;
  fatherLastName: string;
  motherLastName: string;
  email: string;
  phone: string;
  address: string;
  age: string;
  genre: string;
};

function Home() {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<Inputs>({
    resolver: zodResolver(userSchema),
  });

  const genresOptions = Object.entries(mappedGenres).map(([key, value]) => (
    <option value={key} key={key}>
      {value}
    </option>
  ));

  console.log(errors);

  const onSubmit: SubmitHandler<Inputs> = (data) => {
    console.log(data);
  };

  return (
    <div className="d-flex justify-content-center">
      <form className="" onSubmit={handleSubmit(onSubmit)}>
        <div className="row g-5">
          <div className="col-md-12 text-dark d-flex justify-content-center">
            <h1 className="">REGISTRO</h1>
          </div>
          <div className="col-md-6">
            <input
              type="text"
              id="firstName"
              {...register("firstName")}
              placeholder="Primer Nombre"
              className="form-control"
            />
            {errors.firstName?.message && <p>{errors.firstName?.message}</p>}
          </div>
          <div className="col-md-6">
            <input
              type="text"
              id="secondName"
              {...register("secondName")}
              placeholder="Segundo Nombre"
              className="form-control"
            />
            {errors.secondName?.message && <p>{errors.secondName?.message}</p>}
          </div>
          <div className="col-md-6">
            <input
              type="text"
              id="fatherLastName"
              {...register("fatherLastName")}
              placeholder="Primer Apellido"
              className="form-control"
            />
            {errors.fatherLastName?.message && (
              <p>{errors.fatherLastName?.message}</p>
            )}
          </div>
          <div className="col-md-6">
            <input
              type="text"
              id="motherLastName"
              {...register("motherLastName")}
              placeholder="Segundo Apellido"
              className="form-control"
            />
            {errors.motherLastName?.message && (
              <p>{errors.motherLastName?.message}</p>
            )}
          </div>
          <div className="col-md-6">
            <input
              type="email"
              id="email"
              {...register("email")}
              placeholder="Correo"
              className="form-control"
            />
            {errors.email?.message && <p>{errors.email?.message}</p>}
          </div>
          <div className="col-md-6">
            <input
              type="text"
              id="phone"
              {...register("phone")}
              placeholder="Teléfono"
              className="form-control"
            />
            {errors.phone?.message && <p>{errors.phone?.message}</p>}
          </div>
          <div className="col-md-12">
            <input
              type="text"
              id="address"
              {...register("address")}
              placeholder="Dirección"
              className="form-control"
            />
            {errors.address?.message && <p>{errors.address?.message}</p>}
          </div>
          <div className="col-md-6">
            <input
              type="number"
              id="age"
              {...register("age")}
              placeholder="Edad"
              className="form-control"
            />
            {errors.age?.message && <p>{errors.age?.message}</p>}
          </div>
          <div className="col-md-6 d-flex flex-column">
            <select id="genre" {...register("genre")} placeholder="Género" 
              className="form-control">
              <option value="" defaultChecked>Elige tu género</option>
              {genresOptions}
            </select>
            {errors.genre?.message && <p>{errors.genre?.message}</p>}
          </div>
        </div>
        <div className="col-12 d-md-flex justify-content-md-center">
          <button type="submit" className="btn btn-dark hover:btn-light mt-3">Enviar</button>
        </div>
      </form>
    </div>
  );
}

export default Home;
