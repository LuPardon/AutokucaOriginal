// Pages/Header.jsx
// Components/Header.jsx
import { Link } from "react-router-dom";

const Header = ({ user, LogoutUser }) => (
  // a elemente pretvorio u link element da se stranica ne osvježava
  // dodano import za user i LogoutUser čija se logika nalazi u App.jsx
  <header className="bg-gray-800 text-white">
    <div className="w-full max-w-7xl mx-auto flex justify-between items-center py-4">
      <div className="text-2xl font-bold">Autokuća VuV</div>
      <nav className="flex space-x-4 items-center">
        <Link to="/" className="hover:text-yellow-500">
          Početna
        </Link>
        <Link to="/vozila" className="hover:text-yellow-500">
          Vozila
        </Link>
        <Link to="/kontakt" className="hover:text-yellow-500">
          Kontakt
        </Link>
        <Link to="/saloni" className="hover:text-yellow-500">
          Saloni
        </Link>
        {user != null ? (
          <button
            className="bg-yellow-500 text-gray-800 px-3 py-2 rounded hover:bg-yellow-600"
            onClick={() => LogoutUser()}
          >
            Logout
          </button>
        ) : (
          <Link
            to="/prijava"
            className="bg-yellow-500 text-gray-800 px-3 py-2 rounded hover:bg-yellow-600"
          >
            Prijava
          </Link>
        )}
      </nav>
    </div>
  </header>
);

export default Header;
