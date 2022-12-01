import { useState, useEffect, Fragment } from "react";
import { useParams } from "react-router-dom";
import { root_api } from "../../utils/constants";
import { CardContainer, Title, Image } from "./client.styles";

const defaultClient = {
    name: "",
    lastname: "",
    birthDate: "",
}

const Client = () => {
    const {id} = useParams();
    const [client, setClient] = useState(defaultClient)
    //const isLoading = useSelector(selectCategoriesIsLoading

    useEffect(() => {
        fetch(
            `${root_api.clients}/${id}`, {
            method:"get",    
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
                },
        })
         .then( response => response.json())
         .then(result => 
            {
                console.log(result.data)
                setClient(result.data)
            })
      }, [])


    return (
        <Fragment>
            <Title>{client.name} {client.lastname}</Title>
            <CardContainer key={id}>
                <Image alt={`Client ${client.name}`} 
                    src={`https://robohash.org/${id}?set=set2`}
                />
                <h2>
                {client.name} {client.lastname}
                </h2>
                <p>emilio3scano@gmail.com</p>
            </CardContainer>  
        </Fragment>
    )
}
export default Client;