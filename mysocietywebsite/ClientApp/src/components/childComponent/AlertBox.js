import React from 'react'

const AlertBox = ({ message, alertType, setError }) => {
 
    setTimeout(() => {
        setError('')
    },2000)
    return (
            <div className={`alert alert-${alertName[`${alertType}`]}`} style={{position:'absolute',top:'0px',left:'0px',width:'100%'}}>
            <strong>{alertType}!</strong><p> {message}</p>.
            </div>
        )
}
export default AlertBox

export const type = {
    Success: 'Success',
    Error: 'Error',
    Wait:'Waiting'
}

export const alertName = {
    Success: 'success',
    Error: 'danger',
    Wait:'info'
}