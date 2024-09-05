import { useState, useEffect } from "react";
export default function SviSaloni() {
  let [saloni, setSaloni] = useState([]);

  useEffect(() => {
    fetchData();
  }, []);

  async function fetchData() {
    await fetch("/api/saloni", {
      method: "GET",
    })
      .then(async (response) => {
        let json = await response.json();
        console.log(json);
        setSaloni(() => json);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }
  return (
    <ul>
      {saloni.map((salon, index) => (
        <li
          key={index}
          className="d-flex flex-col border-2 border-solid border-grey-200"
        >
          <h4>{salon?.naziv}</h4>
          <p>Adresa: {salon?.adresa}</p>
          <p>Radno vrijeme {salon?.radnoVrijeme}</p>
          <p>{salon?.kontakt.split(",")[0]}</p>
          <p>{salon?.kontakt.split(",")[1]}</p>
          
        </li>
      ))}
    </ul>
  );
}
