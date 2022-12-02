import Address from "../address/address.component"
import { DeleteBtn, EmptyMessage, UpdateBtn, ButtonsContainer } from "./address-list.styles"
const AddressList = ({addresses}) =>  {
    return (
        <div>
            {
                addresses.length ?  (addresses.map((item, i ) => (
                    <div key={item.id}>
                        <h2>Address {i+1}</h2>
                        <ButtonsContainer>
                            <DeleteBtn>Borrar</DeleteBtn>
                            <UpdateBtn>Update</UpdateBtn>
                        </ButtonsContainer>
                        <Address key={item.id}  address={item}></Address>
                    </div>
                ))): (
                    <EmptyMessage>No addresses added</EmptyMessage>
                )
                }
        </div>
    )
}
export default AddressList