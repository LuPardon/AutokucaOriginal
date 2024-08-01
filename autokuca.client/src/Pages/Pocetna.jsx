import LogoutLink from "../Components/LogoutLink.jsx";
import AuthorizeView, { AuthorizedUser } from "../Components/AuthorizeView.jsx";

function Pocetna() {
    return (
        <AuthorizeView>
            <span><LogoutLink>Logout <AuthorizedUser value="email" /></LogoutLink></span>
            <div><iframe src="https://www.google.com/maps/d/embed?mid=18_BF7vSwbmR8eriblFAm57WUO65zb_U&ehbc=2E312F&noprof=1" width="640" height="480"></iframe></div>
        </AuthorizeView>
    );
}

export default Pocetna;