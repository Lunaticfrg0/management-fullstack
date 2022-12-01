import { CardContainer } from "./card-profile.styles"
import { useNavigate } from "react-router-dom";

const CardProfile = ({client}) => {
    const {id, name, lastname} = client
    const navigate = useNavigate();

    const onNavigateHandler = () => navigate(`client/${id}`)
    return (
        <CardContainer key={id} onClick={onNavigateHandler}>
            <img alt={`Client ${name}`} 
                src={`https://robohash.org/${id}?set=set2`}
            />
            <h2>
            {name} {lastname}
            </h2>
            <p>emilio3scano@gmail.com</p>
        </CardContainer>  
    )
}

export default CardProfile