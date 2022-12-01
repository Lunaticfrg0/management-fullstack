import { FormContainer } from "./client-create.styles"
import { useState } from "react"
import FormInput from "../../components/form-input/form-input.component"
import Button from "../../components/button/button.component"
import { root_api } from "../../utils/constants"
import { useNavigate } from "react-router-dom";


const defaultFormFields = {
    name: '',
    lastname:'',
    birthDate: '',
}

const ClientCreate = () => {

    const [formFields, setFormFields] = useState(defaultFormFields)
    const { name, lastname, birthDate } = formFields;
    const [isLoading, setIsLoading] = useState(false)
    const navigate = useNavigate();

    const onNavigateHandler = (id) => navigate(`/client/${id}`)
    const handleChange = (event) => {
        const {name, value} = event.target;
        setFormFields({...formFields, [name]: value})
    }
    const handleSubmit = async (event) => {
        setIsLoading(true)
        event.preventDefault();
        await fetch(root_api.clients + "/", {
        method: 'POST',
        body: JSON.stringify({
            name,
            lastname,
            birthDate
        }),
        headers: {
        'Content-type': 'application/json; charset=UTF-8',
        },
        }).then((response) => response.json())
        .then((data) => {
            console.log(data)
           alert("Client created")
           onNavigateHandler(data.data)
        })
        .catch((err) => {
           console.log(err.message);
           alert(err.message)
           setIsLoading(false)
        });
        setIsLoading(false)
    }
    return (
        <FormContainer>
            <h2>Create clients</h2>
            <span>Create a client and register their data</span>
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
                <Button disabled={isLoading} type="submit">Create</Button>
            </form>
      </FormContainer>
    )
}

export default ClientCreate