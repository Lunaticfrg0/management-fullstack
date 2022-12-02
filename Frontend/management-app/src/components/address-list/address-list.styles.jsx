import styled from "styled-components"
import { BaseButton } from "../button/button.styles"
export const EmptyMessage = styled.span`
  background: white;
  border-radius: 20%;
  font-size: large;
  font-family: sans-serif;
`
export const DeleteBtn = styled(BaseButton)`
    background-color: red;
    color: black;
    &:hover {
    background-color: white;
    color: red;
    border: 1px solid black;
  }
`

export const UpdateBtn = styled(BaseButton)`
  
`
export const ButtonsContainer = styled.div`
    display: flex;
    justify-content: space-between;
    width: 40vw;    
    top:0;
    bottom: 0;
    left: 0;
    right: 0;
    align-items:center;
    margin: auto;
    padding: 10px;
  button{
    font-size: 12px
  }
`;