import { FormContainer, ButtonsContainer } from "./client-create.styles"
import { useState } from "react"
import FormInput from "../../components/form-input/form-input.component"
import Button from "../../components/button/button.component"

const defaultFormFields = {
    name: '',
    lastname:'',
    birthDate: '',
}

const ClientCreate = () => {

    const [formFields, setFormFields] = useState(defaultFormFields)
    const { name, lastname, birthDate } = formFields;
    const handleChange = (event) => {
        const {name, value} = event.target;
        setFormFields({...formFields, [name]: value})
    }
    const handleSubmit = async (event) => {
        event.preventDefault();
       
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
                <Button type="submit">Create</Button>
            </form>
      </FormContainer>
    )
}

export default ClientCreate