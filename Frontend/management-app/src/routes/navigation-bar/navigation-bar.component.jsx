import { Outlet } from "react-router-dom"
import { Fragment} from "react";
import { ReactComponent as HomeLogo } from "../../assets/crown.svg";

import { NavigationContainer, NavLink, NavLinks, LogoContainer } from "./navigation-bar.styles";

const NavigationBar = () => {
    return(
      <Fragment>
        <NavigationContainer>
            <LogoContainer to="/">
                <HomeLogo className="logo"/>
            </LogoContainer>
            <NavLinks>
                <NavLink to="/create-client">
                    Create Clients
                </NavLink>
            </NavLinks>
        </NavigationContainer>
        <Outlet/>
      </Fragment>
    )
}
export default NavigationBar;