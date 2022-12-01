import CardProfile from "../card-profile/card-profile.component"
import { CardListContainer } from "./card-list.styles"
const CardList = ({clients}) =>  {
    return (
        <CardListContainer>
            { clients.map((client) => {
                return (
                      <CardProfile key={client.id} client={client}/>
                    )   
                }
            )}
        </CardListContainer>
    )
}
export default CardList