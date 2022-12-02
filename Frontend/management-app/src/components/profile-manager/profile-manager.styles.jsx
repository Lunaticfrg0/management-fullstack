import styled from 'styled-components';
import { BaseButton } from '../button/button.styles';
export const FormContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
    
  h2 {
    margin: 10px 0;
  }
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 20px;
`;

export const UpdateBtnProfile = styled(BaseButton)`
  
`
export const DeleteBtnProfile = styled(BaseButton)`
    background-color: red;
    color: black;
    &:hover {
    background-color: white;
    color: red;
    border: 1px solid black;
  }
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