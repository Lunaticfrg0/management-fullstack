import { Fragment } from "react"
import { CardContainer, Image, ButtonsContainer } from "./profile.styles"
const Profile = ({client, isLoading}) => {
    const {id, name, lastname} = client
    return(
        <Fragment>
            <CardContainer key={id}>
                <Image alt={`Client ${name}`} 
                    src={`https://robohash.org/${id}?set=set2`}
                />
                <h2>
                {name} {lastname}
                </h2>
                <p>emilio3scano@gmail.com</p>
            </CardContainer>  
        </Fragment>
    )
}

export default Profile;