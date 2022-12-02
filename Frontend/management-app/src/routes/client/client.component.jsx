import { useState, useEffect, Fragment } from "react";
import { useParams } from "react-router-dom";
import { root_api } from "../../utils/constants";
import { Title } from "./client.styles";
import PropTypes from 'prop-types';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Profile from "../../components/profile/profile.component";
import AddressList from "../../components/address-list/address-list.component";
import { TabContainer } from "./client.styles";
import ProfileManager from "../../components/profile-manager/profile-manager.component";

const defaultClient = {
    name: "",
    lastname: "",
    birthDate: "",
    clientAddresses: []
}
function TabPanel(props) {
    const { children, value, index, ...other } = props;
  
    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`simple-tabpanel-${index}`}
        aria-labelledby={`simple-tab-${index}`}
        {...other}
      >
        {value === index && (
          <Box sx={{ p: 3 }}>
            <Typography component={'span'}>{children}</Typography>
          </Box>
        )}
      </div>
    );
  }
  
  TabPanel.propTypes = {
    children: PropTypes.node,
    index: PropTypes.number.isRequired,
    value: PropTypes.number.isRequired,
  };
  
  function a11yProps(index) {
    return {
      id: `simple-tab-${index}`,
      'aria-controls': `simple-tabpanel-${index}`,
    };
  }
  

const Client = () => {
    const {id} = useParams();
    const [client, setClient] = useState(defaultClient)
    const [isLoading, setIsLoading] = useState(false)
    const [value, setValue] = useState(0);

    const handleChange = (event, newValue) => {
      setValue(newValue);
    };
  
    useEffect(() => {
        setIsLoading(true)
        fetch(
            `${root_api.clients}/${id}`, {
            method:"get",    
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
                },
        })
         .then( response => response.json())
         .then(result => 
            {
                setIsLoading(false)
                setClient(result.data)
            })
            setIsLoading(false)
      }, [])


    return (
        <TabContainer>
            <Title>{client.name} {client.lastname}</Title>
            <Box sx={{ width: '100%' , bgcolor: 'background.paper'}}>
                <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                    <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
                    <Tab label="General" {...a11yProps(0)} />
                    <Tab label="Addresses" {...a11yProps(1)} />
                    <Tab label="Configurations" {...a11yProps(2)} />
                    </Tabs>
                </Box>
                <TabPanel value={value} index={0}>
                    <Profile client={client} isLoading={isLoading}/>
                </TabPanel>
                <TabPanel value={value} index={1}>
                    <AddressList addresses={client.clientAddresses}/>
                </TabPanel>
                <TabPanel value={value} index={2}>
                  <ProfileManager client={client}/>
                </TabPanel>
            </Box>
        </TabContainer>
    )
}
export default Client;