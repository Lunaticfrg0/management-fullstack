import { Fragment } from "react";
import { Link } from "react-router-dom";
import { Title } from "./not-found.styles";


const NotFound = () => {
    return (
        <Fragment>
            <Title>
               404 Not Found 
            </Title>
            <Link to={"/"}>Go to Home</Link>
        </Fragment>
    )
}

export default NotFound;