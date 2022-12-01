import { SearchBoxInput } from "./search-box.styles";

const SearchBox = ({className, placeholder, onChangeHandler}) => {
    return (
        <SearchBoxInput className={`search-box ${className}`} type="search" 
            placeholder={placeholder} onChange={onChangeHandler}
        />
    )
}

export default SearchBox;