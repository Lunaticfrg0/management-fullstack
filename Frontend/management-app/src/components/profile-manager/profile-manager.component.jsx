import { FormContainer } from "./profile-manager.styles";
import FormInput from "../form-input/form-input.component"
import { useState } from "react";
import { root_api } from "../../utils/constants";
import { useParams } from "react-router-dom";
import { useEffect } from "react";
import { DeleteBtnProfile, UpdateBtnProfile, ButtonsContainer } from "./profile-manager.styles";
import { useNavigate } from "react-router-dom";
import moment from "moment"
const defaultFormFields = {
    name: '',
    lastname:'',
    birthDate: ''
  }
const ProfileManager = ({client}) => {
    const navigate = useNavigate();

    const onNavigateHandler = () => navigate(`/`)
    const [formFields, setFormFields] = useState(defaultFormFields)
    const [isLoading, setIsLoading] = useState(false)
    useEffect(() => {
        client.birthDate = moment(client.birthDate,'YYYY/MM/DD/ HH:mm').format('yyyy-MM-DD');
      setFormFields(client)
    }, [client])
    const {id} = useParams();
    const handleChange = (event) => {
        const {name, value} = event.target;
        setFormFields({...formFields, [name]: value})
    }
    const { name, lastname, birthDate } = formFields;

    const handleSubmit = async (event) => {
        event.preventDefault();
        if(!name || !lastname || !birthDate){
            alert("All values should be added")
            return
        }
        try {
          await fetch(root_api.clients, {
            method: 'PUT',
            body: JSON.stringify({
                name,
                lastname,
                birthDate,
                id,
            }),
            headers: {
            'Content-type': 'application/json; charset=UTF-8',
            },
            }).then((response) => response.json())
            .then((data) => {
               alert("Address uploaded")
               window.location.reload(false);
            })
            .catch((err) => {
               alert(err.message)
               setIsLoading(false)
               window.location.reload(false);
            });
            setIsLoading(false)
        } catch (error) {
            switch(error.code){
                case "auth/wrong-password":
                    alert("Email or password incorrect")
                    break;
                case "auth/user-not-found":
                    alert("No user associates to email")
                    break;
                default:
                    console.log(error.code)
                    break;
            }
        }
    
    }
    const handleDelete = async (event) => {        
        if(window.confirm("Are you sure you want to delete the client?")){
            try {
                await fetch(root_api.clients+`/${id}`, {
                  method: 'Delete',
                  headers: {
                  'Content-type': 'application/json; charset=UTF-8',
                  },
                  }).then((response) => response.json())
                  .then((data) => {
                     alert("Address Deleted")
                     onNavigateHandler()
                  })
                  .catch((err) => {
                     alert(err.message)
                     setIsLoading(false)
                     onNavigateHandler()
                  });
                  setIsLoading(false)
              } catch (error) {
                    console.log(error.message)
              }
            }
        else{
            return
        }
    }
    
    return(
        <FormContainer>
            <h2>Update client</h2>
            <span>Update client data</span>
            <form onSubmit={handleSubmit}>
            <FormInput
                label='Name'
                type='text'
                required
                onChange={handleChange}
                name='name'
                value={name}
            />
            <FormInput
                label='Lastname'
                type='text'
                required
                onChange={handleChange}
                name='lastname'
                value={lastname}
            />
            <FormInput
                type='date'
                required
                onChange={handleChange}
                name='birthDate'
                value={birthDate}
            />
            <ButtonsContainer>
                <DeleteBtnProfile onClick={handleDelete} disable={isLoading} >Delete</DeleteBtnProfile>
                <UpdateBtnProfile type="submit" disable={isLoading}>Update</UpdateBtnProfile>
            </ButtonsContainer>
            </form>
      </FormContainer>
    )
}
export default ProfileManager;