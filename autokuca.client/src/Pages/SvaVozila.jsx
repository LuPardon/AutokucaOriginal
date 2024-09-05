import { useEffect, useState } from "react";
import VoziloKartica from "../Components/VoziloKartica";
import { MagnifyingGlassCircleIcon } from "@heroicons/react/24/outline";

// async function dohvatiVozila() {}
// async function dohvatiOblikeVozila() {}

export default function SvaVozila() {
  let [vozila, setVozila] = useState([]);
  // let [obliciVozila, setObliciVozila] = useState([]);

  useEffect(() => {
    fetchData();
  }, []);

  async function fetchData() {
    // await dohvatiVozila();
    await fetch("/api/vozila", {
      method: "GET",
    })
      .then(async (response) => {
        let json = await response.json();
        setVozila(() => json);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }

  async function handleFormSubmit(e) {
    e.preventDefault();

    // Read the form data
    const form = e.target;
    const formData = new FormData(form);

    await fetch("/api/vozila?" + new URLSearchParams(formData))
      .then(async (response) => {
        let json = await response.json();
        setVozila(json);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }

  return (
    <>
      <form
        method="GET"
        className="p-2 border-solid border-gray-200 border-2 mb-4 flex-auto justify-items-center items-center"
        onSubmit={handleFormSubmit}
      >
        <select name="id_oblik" defaultValue={""}>
          <option value="">Oblik vozila</option>
          <option value="1">Limuzina</option>
          <option value="2">Karavan</option>
          <option value="3">Hatchback</option>
          <option value="4">SUV</option>
          <option value="5">Sport</option>
          <option value="6">Touring</option>
          <option value="7">Standard</option>
          <option value="8">Ostalo</option>
        </select>
        <select name="id_mjenjac" defaultValue={""}>
          <option value="">Mjenjač</option>
          <option value="1">Automatik</option>
          <option value="2">Ručni</option>
        </select>
        <select name="id_gorivo" defaultValue={""}>
          <option value="">Gorivo</option>
          <option value="1">Benzin</option>
          <option value="2">Benzin + plin</option>
          <option value="3">Dizel</option>
          <option value="4">Električni</option>
        </select>
        <select name="id_tipVozila" defaultValue={""}>
          <option value="">Tip vozila</option>
          <option value="1">Automobil</option>
          <option value="2">Motocikl</option>
        </select>
        <select name="salon" defaultValue={""}>
          <option value="">Salon</option>
          <option value="">Ovo moram dodat još</option>
        </select>
        <button type="submit">
          <MagnifyingGlassCircleIcon className="size-6" />
        </button>
        <button
          type="button"
          className="border-2 border-grey-200 border-solid rounded px-3"
        >
          RESET
        </button>
      </form>
      <ul className="grid grid-cols-5 gap-3 md:grid-cols-4 sm:grid-cols-2">
        {vozila.map((vozilo, index) => (
          <VoziloKartica vozilo={vozilo} key={index} />
        ))}
      </ul>
    </>
  );
}
