import { Fragment } from "react"
import { CardContainer, Image, ContactMail, ContactName } from "./profile.styles"
const Profile = ({client, isLoading}) => {
    const {id, name, lastname} = client
    return(
        <Fragment>
            <CardContainer key={id}>
                <Image alt={`Client ${name}`} 
                    src={`https://robohash.org/${id}?set=set2`}
                />
                <ContactName>
                {name} {lastname}
                </ContactName>
                <ContactMail>
                    <p>emilio3scano@gmail.com</p>
                </ContactMail>
            </CardContainer>  
        </Fragment>
    )
}

export default Profile;