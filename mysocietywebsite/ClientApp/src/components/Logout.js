import React from 'react'
import { useHistory } from 'react-router-dom'
import { clearStore } from '../helper/tokenAuth'


const Logout = (props) => {
    const history = useHistory()
    return (
        <h1>you are logged out <button onClick={() => {
            props.setState(s => ({ ...s, isLoggedIn: false }))
            clearStore()
            history.push('/login')
        }}>Login Here</button></h1>
        )
}

export default Logout