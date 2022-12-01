import { Outlet } from "react-router-dom";
import CardList from "../../components/card-list/card-list.component";
import { Fragment, useState, useEffect } from "react";
import { Title, PaginationContainer } from "./home.styles";
import { root_api } from "../../utils/constants";
import ReactPaginate from 'react-paginate';
import './home.styles.css';
import SearchBox from "../../components/search-box/search-box.component";

const Home = () => {
    const [pageNumber, setPageNumber] = useState(1);
    const [totalItems, setTotalItems] = useState(0);
    const [totalPages, setTotalPages] = useState(1);
    const [searchTerm, setSearchTerm] = useState("")
    const amountPerPage = 8
    const [clientsList, setClientsList] = useState([]);

    const changePage = ({ selected }) => {
        setPageNumber(selected+1);
      };

    useEffect(() => {
        fetch(
            `${root_api.clients}?pageSize=${encodeURIComponent(amountPerPage)}&currentPage=${encodeURIComponent(pageNumber)}&searchTerm=${encodeURIComponent(searchTerm)}&`, {
            method:"get",    
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
                },
        })
         .then( response => response.json())
         .then(result => 
            {
                setClientsList(result.data.list)
                setTotalItems(result.data.totalItems)
                setTotalPages(result.data.totalPages)
            })
      }, [pageNumber, searchTerm])

      const onSearchChange = (e) => {
        const searchFieldString = e.target.value.toLocaleLowerCase()
        setSearchTerm(searchFieldString)
    
    }
    return (
        <Fragment>
            <Title>Contacts</Title>
            <SearchBox onChangeHandler = {onSearchChange} 
                placeholder="Search for clients" />
            <CardList clients={clientsList}/>
            <PaginationContainer>
                <ReactPaginate
                    previousLabel={"← Previous"}
                    nextLabel={"Next →"}
                    pageCount={totalPages}
                    onPageChange={changePage}
                    containerClassName={"pagination"}
                    previousLinkClassName={"pagination__link"}
                    nextLinkClassName={"pagination__link"}
                    disabledClassName={"pagination__link--disabled"}
                    activeClassName={"pagination__link--active"}
                />
            </PaginationContainer>
            <Outlet/>
        </Fragment>
        
    );
};
export default Home;