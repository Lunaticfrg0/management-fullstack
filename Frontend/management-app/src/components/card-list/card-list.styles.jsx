import styled from "styled-components";

export const CardListContainer = styled.div`
    width: 85vw;
    margin: 0 auto;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    grid-gap: 20px;
`
export const EmptyMessage = styled.span`
  background: white;
  border-radius: 20%;
  font-size: large;
  font-family: sans-serif;
`