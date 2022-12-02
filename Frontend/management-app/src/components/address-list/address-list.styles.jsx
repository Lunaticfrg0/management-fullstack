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

export const AddBtn = styled(BaseButton)`
    background-color: green;
    color: black;
    &:hover {
    background-color: white;
    color: green;
    border: 1px solid black;
  }
`

export const UpdateBtn = styled(BaseButton)`
  
`
export const ButtonsContainer = styled.div`
    display: flex;
    justify-content: center;
    top:0;
    bottom: 0;
    left: 0;
    right: 0;
    align-items:center;
    margin: auto;
  button{
    font-size: medium;
    margin: 15px;
  }
`;