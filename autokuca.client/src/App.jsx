import './App.css';

import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Pocetna from './Pages/Pocetna.jsx';
import Login from './Pages/Login.jsx';
import Register from './Pages/Register.jsx';


function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route path="/" element={<Pocetna />} />
            </Routes>
        </BrowserRouter>
    );

}
export default App;