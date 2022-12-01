import { Outlet } from "react-router-dom"
import { Fragment} from "react";
import { ReactComponent as HomeLogo } from "../../assets/crown.svg";

import { NavigationContainer, LogoContainer } from "./navigation-bar.styles";

const NavigationBar = () => {
    return(
      <Fragment>
        <NavigationContainer>
            <LogoContainer to="/">
                <HomeLogo className="logo"/>
            </LogoContainer>
        </NavigationContainer>
        <Outlet/>
      </Fragment>
    )
}
export default NavigationBar;