"use client";

import { useEffect, useState } from "react";
import {
  User,
  useCountGenreQuery,
  useFindMaxAgeQuery,
  useGetAverageQuery,
  useGetUsersQuery,
} from "../toolkit/services/userApi";
import Header from "./components/Header";

function Home() {
  const { data, error, isLoading, isFetching } = useGetUsersQuery(null);
  const { data: averageRes } = useGetAverageQuery(null);
  const { data: maxAgeUser } = useFindMaxAgeQuery(null);
  
  const [average, setAverage] = useState(null);
  const [totalMale, setTotalMale] = useState(null);
  const [totalFemale, setTotalFemale] = useState(null);
  const [currentData, setCurrentData] = useState<User[]>([]);

  const { data: genresFilterFemale } = useCountGenreQuery({ genre: "Female" });
  const { data: genresFilterMale } = useCountGenreQuery({ genre: "Male" });


  useEffect(() => {
    const info = data ? data : [];
    setCurrentData(info);
  }, [data]);

  const handleAverage = () => {
    setTotalFemale(null);
    setTotalMale(null);

    setAverage(averageRes.data);

  };

  const handleFilter = (e: any) => {

    setAverage(null);
    setTotalFemale(null);
    setTotalMale(null);


    if (e.target.value === 'Age'){
      setCurrentData([maxAgeUser]);
      return;
    }
    if (e.target.value === 'Male'){
      setCurrentData(genresFilterMale.userList);
      return;
    }

    if (e.target.value === 'Female'){
      setCurrentData(genresFilterFemale.userList);
      return;
    }

    if (data) {
      setCurrentData(data);
    }

    return;

  };

  const handleTotalF = () => {

    setAverage(null);
    setTotalMale(null);

    setTotalFemale(genresFilterFemale.count);

  }

  const handleTotalM = () => {

    setAverage(null);
    setTotalFemale(null);
    
    setTotalMale(genresFilterMale.count);

  }

  return (
    <div className="container-fluid m-0 p-0">
      <div>
        <Header />
      </div>
      <div className="col-3 d-flex flex-row justify-content-end m-4">
        <select
          onChange={handleFilter}
          className="form-select form-select-lg mb-1"
        >
          <option className="options" value="">Selecciona para filtrar</option>
          <option className="options" value="Age">Mayor Edad</option>
          <option className="options" value="Female">Mujer</option>
          <option className="options" value="Male">Hombre</option>
          <option className="options" value="All">Todos</option>
        </select>
      </div>
      <div className="container d-flex flex-column justify-content-center align-items-center">
        <h1 className="mb-4">Información de Usuarios</h1>
        <div className="container mt-4">
          <ul className="list-group">
            {isLoading ? (
              <p>Is Loading...</p>
            ) : (
              currentData?.map((user, i) => {
                return (
                  <li className="list-group-item" key={user.id}>{`${i + 1}. ${
                    user.firstName
                  } ${user.secondName ? user.secondName : ""} ${
                    user.fatherLastName
                  } ${user.motherLastName ? user.motherLastName : ""} / ${
                    user.age
                  } años / Correo: ${user.email}`}</li>
                );
              })
            )}
          </ul>
        </div>
      </div>  
      <div className="constainer d-flex flex-row justify-content-center">
        <div className="constainer d-flex flex-column align-items-center">
        <button className="btn btn-dark m-4" onClick={handleAverage}>
            Promedio de Edades
          </button>
          <p>{average}</p>
        </div>
        <div className="constainer d-flex flex-column align-items-center">
        <button className="btn btn-dark m-4" onClick={handleTotalF}>Total Mujeres</button>
        <p>{totalFemale}</p>
        </div><div className="constainer d-flex flex-column align-items-center">
        <button className="btn btn-dark m-4" onClick={handleTotalM}>Total Hombres</button>
        <p>{totalMale}</p>
        </div>
      </div>
    </div>
  );
}

export default Home;
