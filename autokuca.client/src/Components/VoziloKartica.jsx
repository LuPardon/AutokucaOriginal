import React from "react";

import temp from "../assets/peugeot-208.png";
import { useNavigate } from "react-router-dom";
const VoziloKartica = ({ vozilo }) => {
  let navigate = useNavigate();
  return (
    <li
      className="border-solid border-gray-200 border-2 p-4 cursor-pointer"
      onClick={() => {
        navigate("/vozila/" + vozilo.voziloId);
      }}
    >
      <img src={temp} alt="slika vozila" style={{ height: 100 }} />
      <div>
        <h4>
          {vozilo.model} {vozilo.godina}
        </h4>
        <p>{vozilo.opis}</p>
      </div>
    </li>
  );
};

export default VoziloKartica;
