import React, { useEffect } from 'react'
import { useHistory } from 'react-router-dom'
import { clearStore } from '../helper/tokenAuth'


const Logout = (props) => {
    const history = useHistory()
    useEffect(() => {
        setTimeout(() => {
            props.setState(s => ({ ...s, isLoggedIn: false }))
            clearStore()
            history.push('/login')
        },1000)
    },[])
    return (
        <h1>you are logging out......</h1>
        )
}

export default Logout