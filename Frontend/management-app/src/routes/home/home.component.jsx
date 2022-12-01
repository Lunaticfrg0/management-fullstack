import { Outlet } from "react-router-dom";
import CardList from "../../components/card-list/card-list.component";
import { Fragment, useState } from "react";
import { Title } from "./home.styles";

const newDate = 'Thu Dec 01 2022'
const clientsDemo = [
    {
        name: "Emilio",
        lastname: "Escano",
        birthDate : newDate,
        id: "11111"
    },
    {
        name: "Jose",
        lastname: "Escano",
        birthDate : newDate,
        id: "11131"
    },
    {
        name: "Pedro",
        lastname: "Escano",
        birthDate : newDate,
        id: "1121"
    },
    {
        name: "wddd",
        lastname: "Escano",
        birthDate : newDate,
        id: "1121117"
    },
];
const Home = () => {
    const [clientsList, setClientsList] = useState(clientsDemo);
    return (
        <Fragment>
            <Title>Contacts</Title>
            <CardList clients={clientsList}/>
            <Outlet/>
        </Fragment>
        
    );
};
export default Home;