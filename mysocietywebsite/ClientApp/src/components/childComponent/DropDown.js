import React from 'react'

const Dropdown = ({ values, value, changeHandler }) => {
    return (
        <select className="form-control form-control-lg"  value={value} onChange={changeHandler}>
                <option className="dropdown-item" value=''>none</option>
                {
                    values && values.length && values.map((e, i) => {
                        return <option key={ i} className="dropdown-item" value={e.id}>{e.name}</option>
                    })
                }
               
            </select>
    )
}

export default Dropdown