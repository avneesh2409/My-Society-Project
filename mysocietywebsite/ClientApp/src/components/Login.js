import React from 'react'
import { useHistory } from 'react-router-dom'

const Login = (props) => {
    const history = useHistory()
    return (
        <>
            <h1>we are in login page</h1>
            <button onClick={e => {
                props.setState(s => ({ ...s, isLoggedIn: true }))
                history.push('/home')
            }
            }>login here</button>
        </>
    )
}

export default Login