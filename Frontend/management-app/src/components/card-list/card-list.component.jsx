import CardProfile from "../card-profile/card-profile.component"
import { CardListContainer, EmptyMessage } from "./card-list.styles"
const CardList = ({clients}) =>  {
    return (
        <CardListContainer>
            {
                clients.length ?  (clients.map((item ) => (
                    <CardProfile key={item.id}  client={item}></CardProfile>
                ))): (
                    <EmptyMessage>No contacts added</EmptyMessage>
                )
                }
        </CardListContainer>
    )
}
export default CardList