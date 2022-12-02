import styled from "styled-components"
export const CardContainer = styled.div`
    display: flex;
    flex-direction: column;
    background-color: #f2f2f2;
    border: 1px solid grey;
    border-radius: 5px;
    padding: 25px;
    -moz-osx-font-smoothing: grayscale;
    backface-visibility: hidden;
    width: 40vw;    
    top:0;
    bottom: 0;
    left: 0;
    right: 0;
    align-items:center;
    margin: auto;
`
export const Title = styled.h2`
margin-top: 75px;
  margin-bottom: 50px;
  font-size: 76px;
  color: white;
`;

export const Image = styled.img`
    max-width: 500px;
    max-height: 500px;
`;
