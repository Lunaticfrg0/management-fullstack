import Address from "../address/address.component"
import { useState } from "react"
import { DeleteBtn, EmptyMessage, UpdateBtn, ButtonsContainer, AddBtn } from "./address-list.styles"
import { root_api } from "../../utils/constants"
import AddressModal from "../address-modal/address-modal.component"
const defaultAddress = {
    firstLine: '',
    secondLine:'',
    zipCode: "",
    additionalDetails: "",
    id: ""
  }
const AddressList = ({addresses}) =>  {

    const [isLoading, setIsLoading] = useState(false)
    const [open, setOpen] = useState(false);
    const [currentAddress, setCurrentAddress] = useState(defaultAddress)
      const handleClickUpdateOpen = (address) => {
        setOpen(true);
        setCurrentAddress(address)
      };
      const handleClickAddOpen = () => {
        setOpen(true);
        setCurrentAddress(defaultAddress)
      }
      const handleClose = () => {
        setOpen(false);
      };

    const deleteAddress = async (id) => {
        setIsLoading(true)
        if(window.confirm("Are you sure you want to delete the address?")){
            await fetch(root_api.clientsAddress + `/${id}`, {
                method: 'Delete',
                headers: {
                'Content-type': 'application/json; charset=UTF-8',
                },
                }).then((response) => response.json())
                .then((data) => {
                   alert("Address Deleted")
                   window.location.reload(false);
                })
                .catch((err) => {
                   alert(err.message)
                   setIsLoading(false)
                });
                setIsLoading(false)
        }
        else{
            return
        }
        
    }
    return (
        <div>
            <AddBtn onClick={() => handleClickAddOpen()}>Add address</AddBtn>
            <AddressModal address={currentAddress} openState={open} closeHandler={()=> handleClose}/>
            {
                addresses.length ?  (addresses.map((item, i ) => (
                    <div key={item.id}>
                        <h2>Address #{i+1}</h2>
                        <ButtonsContainer>
                            <DeleteBtn disable={isLoading} onClick={() => deleteAddress(item.id)}>Borrar</DeleteBtn>
                            <UpdateBtn disable={isLoading} onClick={() => handleClickUpdateOpen(item)}>Update</UpdateBtn>
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