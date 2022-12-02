import { Fragment } from "react";

const Address = ({address}) => {
    const {firstLine, secondLine, zipCode, additionalDetails, id} = address
    return (
        <Fragment key={id} >
            <div className="row g-1">
            <div className="col">
                <div className="form-outline">
                <input type="text" id="form9Example1" readOnly className="form-control" value={firstLine}/>
                <label className="form-label" htmlFor="form9Example1">First Line</label>
                </div>
            </div>
            <div className="col">
                <div className="form-outline">
                <input type="email" id="form9Example2" readOnly className="form-control" value={secondLine} />
                <label className="form-label" htmlFor="form9Example2">Second Line</label>
                </div>
            </div>
            </div>
            <div className="row g-5">
            <div className="col">
                <div className="form-outline">
                <input type="text" id="form9Example3" readOnly className="form-control" value={zipCode} />
                <label className="form-label" htmlFor="form9Example3">Zip code</label>
                </div>
            </div>
            <div className="col">
                <div className="form-outline">
                <input type="text" id="form9Example4" readOnly className="form-control" value={additionalDetails}/>
                <label className="form-label" htmlFor="form9Example4">Additional Details</label>
                </div>
            </div>
            </div>
        </Fragment>
    )
}
export default Address;