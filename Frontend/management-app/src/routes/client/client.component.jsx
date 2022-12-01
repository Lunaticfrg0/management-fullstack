import { useState, useEffect, Fragment } from "react";
import { useParams } from "react-router-dom";

const Client = () => {
    const {id} = useParams();
    //const isLoading = useSelector(selectCategoriesIsLoading

    // useEffect(() => {
        
    // }, )

    return (
        <Fragment>
            <h1>{id}</h1>
        </Fragment>
    )
}
export default Client;