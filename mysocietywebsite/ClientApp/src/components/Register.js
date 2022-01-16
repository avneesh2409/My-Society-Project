import React, { useEffect, useState } from 'react'
import { useHistory } from 'react-router-dom';
import Dropdown from './childComponent/DropDown';


const Register = (props) => {
    const history = useHistory()
    const [state, setState] = useState({
        fullname: '',
        email: '',
        username: '',
        password: '',
        address: '',
        contact: '',
        role: ''
    })
    const changeHandler = (e) => {
        const { name, value } = e.target
        setState(s => ({
            ...s,
            [name]: value
        }))
    }
    const [values, setValues] = useState({ values: [] })

    useEffect(() => {
        fetch(`/api/role`)
            .then(r => r.json())
            .then(json => {
                setValues(s => ({
                    values: json
                }))
            })
            .catch(err => {
                console.log(err)
            })
    },[])
    const submitHandler = (e) => {
        e.preventDefault();
        console.log(state)
    }
    const dropdownHandler = (e) => {
        const { value } = e.target;
        setState(s => ({
            ...s,
            role: value
        }))
    }
    return (
        <section className="vh-100">
            <div className="container-fluid h-custom">
                <div className="row d-flex justify-content-center align-items-center h-100">
                    <div className="col-md-9 col-lg-6 col-xl-5">
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp" className="img-fluid"
                            alt="Sample image" />
                    </div>
                    <div className="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                        <div className="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                            <p className="lead fw-normal mb-10 me-3 ">Sign Up</p>
                        </div>
                        <form>
                            <div className="form-outline mb-4">
                                <label className="form-label" htmlFor="form3Example3">Full Name</label>
                                <input type="text" name="fullname" onChange={changeHandler} className="form-control form-control-lg" placeholder="Enter Full Name" />

                            </div>

                            <div className="form-outline mb-4">
                                <label className="form-label" htmlFor="form3Example3">User Name</label>
                                <input type="text" name="username" onChange={changeHandler} className="form-control form-control-lg"
                                    placeholder="Enter User Name" />

                            </div>

                            <div className="form-outline mb-4">
                                <label className="form-label" htmlFor="form3Example3">Email address</label>
                                <input type="email" name="email" onChange={changeHandler} className="form-control form-control-lg"
                                    placeholder="Enter a valid email address" />

                            </div>

                            <div className="form-outline mb-4">
                                <label className="form-label" htmlFor="form3Example3">Contact</label>
                                <input type="text" name="contact" onChange={changeHandler} className="form-control form-control-lg"
                                    placeholder="Enter Contact" />

                            </div>

                            <div className="form-outline mb-4">
                                <label className="form-label" htmlFor="form3Example3">Role</label>
                                <Dropdown values={values.values} value={state.role} changeHandler={dropdownHandler} />

                            </div>



                            <div className="form-outline mb-4">
                                <label className="form-label" htmlFor="form3Example3">Address</label>
                                <input type="text" name="address" onChange={changeHandler} className="form-control form-control-lg"
                                    placeholder="Enter Address" />

                            </div>

                            <div className="form-outline mb-3">
                                <label className="form-label" htmlFor="form3Example4">Password</label>
                                <input type="password" name="password" onChange={changeHandler} className="form-control form-control-lg"
                                    placeholder="Enter password" />

                            </div>
                            <div className="text-center text-lg-start mt-4 pt-2">
                                <button type="button" className="btn btn-primary btn-lg" onClick={submitHandler} style={{ paddingLeft: '2.5rem', paddingRight: '2.5rem' }}>Register</button>
                                <p className="small fw-bold mt-2 pt-1 mb-0">Already have an account? <a href="#" onClick={(e) => { e.preventDefault(); history.push('/login'); }} className="link-danger">Login</a></p>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div className="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary">

                <div className="text-white mb-3 mb-md-0">
                    Copyright © 2020. All rights reserved.
                </div>
            </div>
        </section>

    )
}

export default Register