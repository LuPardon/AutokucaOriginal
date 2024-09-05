import { useEffect, useState } from "react";
import { useParams } from "../../node_modules/react-router-dom/dist/index";

function Vozilo() {
// za dohvaćanje parametra iz url-a
  let { autoId } = useParams();
  let [auto, setAuto] = useState(null);

  // pri učitavanju stranice se zove funkcija fetchData
  useEffect(() => {
    fetchData();
  }, []);

  async function fetchData() {
    await fetch(`/api/vozila/${autoId}`, {
      method: "GET",
    })
      .then(async (response) => {
        let json = await response.json();
        setAuto(() => json);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }
  return (
    <p>
      {auto?.model} {autoId}!
    </p>
  );
}

export default Vozilo;
