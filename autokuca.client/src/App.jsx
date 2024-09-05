import { Routes, Route } from "react-router-dom";
import Pocetna from "./Pages/Pocetna.jsx";
import Login from "./Pages/Login.jsx";
//import Register from './Pages/Register.jsx';
import SviSaloni from "./Pages/SviSaloni.jsx";
import Kontakt from "./Pages/Kontakt.jsx";
import SvaVozila from "./Pages/SvaVozila.jsx";
import Header from "./Components/Header.jsx";
import Footer from "./Components/Footer.jsx";
import { useState } from "react";
import Vozilo from "./Pages/Vozilo.jsx";

function App() {
  let [user, setUser] = useState(null);
  console.log("iget reloaded");
  4;
  const LoginUser = (userObject) => {
    setUser(userObject);
  };

  const LogoutUser = () => {
    fetch("/logout", {
      method: "POST",
    });
    setUser(() => null);
  };
  return (
    <>
      <Header user={user} LogoutUser={LogoutUser} />
      <main className="w-full max-w-7xl d-flex flex-col justify-items-center mx-auto py-2">
        <Routes>
          <Route path="/" element={<Pocetna />} />
          <Route
            path="/prijava"
            element={<Login user={user} LoginUser={LoginUser} />}
          />
          {/*<Route path="/register" element={<Register />} />*/}
          <Route path="/kontakt" element={<Kontakt />} />
          <Route path="/saloni" element={<SviSaloni />} />
          <Route path="/vozila" element={<SvaVozila />} />
          <Route path="/vozila/:autoId" element={<Vozilo />} />
        </Routes>
      </main>
      <Footer />
    </>
  );
}
export default App;
