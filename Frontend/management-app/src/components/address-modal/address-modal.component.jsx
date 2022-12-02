import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import useMediaQuery from '@mui/material/useMediaQuery';
import { useTheme } from '@mui/material/styles';
import { Fragment, useEffect, useState } from 'react';
import { root_api } from '../../utils/constants';
import { useParams } from 'react-router-dom';

const defaultFormFields = {
  firstLine: '',
  secondLine:'',
  zipCode: "",
  additionalDetails: ""
}
const AddressModal = ({openState, closeHandler, address}) => {
    const {id} = useParams();
    const theme = useTheme();
    const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
    const [formFields, setFormFields] = useState(defaultFormFields)
    useEffect(() => {
      setFormFields(address)
    }, [address])
    const [isLoading, setIsLoading] = useState(false)
    const { firstLine, secondLine, zipCode, additionalDetails } = formFields;

    const handleChange = (event) => {
      const {name, value} = event.target;
      setFormFields({...formFields, [name]: value})
  }
  const resetFormFields = () => {
    setFormFields(defaultFormFields)
}
  const handleSubmit = async (event) => {
    event.preventDefault();
    if(!firstLine || !secondLine || !zipCode){
        alert("All values should be added")
        return
    }
    try {
      await fetch(root_api.clientsAddress, {
        method: address.id !== '' ? 'PUT': "POST",
        body: JSON.stringify({
            firstLine,
            secondLine,
            zipCode,
            additionalDetails,
            clientId: id,
            id: address.id !== '' ? address.id : undefined,
        }),
        headers: {
        'Content-type': 'application/json; charset=UTF-8',
        },
        }).then((response) => response.json())
        .then((data) => {
           alert("Address uploaded")
           window.location.reload(false);
           closeHandler()
        })
        .catch((err) => {
           alert(err.message)
           setIsLoading(false)
           window.location.reload(false);
        });
        setIsLoading(false)
        resetFormFields()
    } catch (error) {
        console.log(error)
    }

}
    return (
      <div>
        <Dialog
          fullScreen={fullScreen}
          open={openState}
          onClose={closeHandler}
          aria-labelledby="responsive-dialog-title"
        >
          <DialogTitle id="responsive-dialog-title">
            {address.id !== '' ? "Update address" : "Add address"}
          </DialogTitle>
          <DialogContent>
          <form >
            <div className="row g-1">
            <div className="col">
                <div className="form-outline">
                <input type="text" id="form9Example1" name='firstLine' required className="form-control" value={firstLine } onChange={handleChange}/>
                <label className="form-label" htmlFor="form9Example1">First Line</label>
                </div>
            </div>
            <div className="col">
                <div className="form-outline">
                <input type="email" id="form9Example2" name='secondLine'  required className="form-control" value={secondLine }  onChange={handleChange}/>
                <label className="form-label" htmlFor="form9Example2">Second Line</label>
                </div>
            </div>
            </div>
            <div className="row g-5">
            <div className="col">
                <div className="form-outline">
                <input type="text" id="form9Example3" name='zipCode' required className="form-control" value={zipCode} onChange={handleChange}/>
                <label className="form-label" htmlFor="form9Example3">Zip code</label>
                </div>
            </div>
            <div className="col">
                <div className="form-outline">
                <input type="text" id="form9Example4" name='additionalDetails' className="form-control" value={additionalDetails} onChange={handleChange}/>
                <label className="form-label" htmlFor="form9Example4">Additional Details</label>
                </div>
            </div>
            </div>
        </form>
          </DialogContent>
          <DialogActions>
            <Button autoFocus onClick={closeHandler()}>
              Cancel
            </Button>
            <Button onClick={handleSubmit} autoFocus>
              Proceed
            </Button>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
export default AddressModal;