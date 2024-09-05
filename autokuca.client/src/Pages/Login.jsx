import { useState } from "react";
import { useNavigate } from "react-router-dom";

function Login({ user, LoginUser }) {
    // Ispisivanje korisnika u konzolu
    console.log("User ", user || "User nije postavljen");

    // State promenljive za email, lozinku i opciju 'zapamti me'
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [rememberme, setRememberme] = useState(false);

    // State promenljiva za greške
    const [error, setError] = useState("");

    // Hook za navigaciju između ruta
    const navigate = useNavigate();

    // Funkcija za upravljanje promenama u input poljima
    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === "email") setEmail(value);
        if (name === "password") setPassword(value);
        if (name === "rememberme") setRememberme(e.target.checked);
    };

    // Funkcija za upravljanje slanjem forme
    const handleSubmit = (e) => {
        e.preventDefault();

        // Validacija unosa
        if (!email || !password) {
            setError("Molim popunite sva polja.");
        } else {
            // Čišćenje poruke o grešci
            setError("");

            // Postavljanje URL-a za login na osnovu opcije 'zapamti me'
            let loginurl = rememberme ? "/login?useCookies=true" : "/login?useSessionCookies=true";

            // Slanje podataka na server
            fetch(loginurl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    email: email,
                    password: password,
                }),
            })
                .then((response) => {
                    // Provera odgovora servera
                    if (response.ok) {
                        setError("Uspješna prijava.");
                        handleSuccess();
                    } else {
                        setError("Greška prilikom prijave.");
                    }
                })
                .catch((error) => {
                    // Upravljanje mrežnim greškama
                    console.error(error.message);
                    setError("Greška prilikom prijave.");
                });
        }
    };

    // Funkcija za uspešnu prijavu
    const handleSuccess = async () => {
        await fetch(`/api/users?mail=${email}&lozinka=${password}`, {
            method: "GET"
        })
            .then(async (response) => {
                if (response.ok) {
                    setError("Success");
                    let json = await response.json();
                    const contentType = response.headers.get("content-type");
                    if (contentType && contentType.includes("application/json")) {
                        LoginUser(() => json.item1);
                        navigate("/");
                    } else {
                        throw new Error("Unexpected content type: " + contentType);
                    }
                } else {
                        throw new Error("Greška prilikom dohvaćanja korisnika.");
                    }
                })
            .catch((e) => {
                console.error(e);
                setError("Greška prilikom prijave.");
            });
    };

    return (
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
            <div className="w-full max-w-md bg-white p-8 rounded-lg shadow-md">
                <h3 className="text-2xl font-semibold mb-6 text-center">Prijava</h3>
                <form onSubmit={handleSubmit} className="space-y-4">
                    <div>
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700">Email:</label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            value={email}
                            onChange={handleChange}
                            className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                        />
                    </div>
                    <div>
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">Lozinka:</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            value={password}
                            onChange={handleChange}
                            className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                        />
                    </div>
                    <div className="flex items-center">
                        <input
                            type="checkbox"
                            id="rememberme"
                            name="rememberme"
                            checked={rememberme}
                            onChange={handleChange}
                            className="h-4 w-4 text-indigo-600 focus:ring-indigo-500 border-gray-300 rounded"
                        />
                        <label htmlFor="rememberme" className="ml-2 block text-sm text-gray-900">Zapamti me</label>
                    </div>
                    <div>
                        <button type="submit" className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">Prijava</button>
                    </div>
                </form>
                {error && <p className="mt-4 text-sm text-red-600 text-center">{error}</p>}
            </div>
        </div>
    );
}

export default Login;
