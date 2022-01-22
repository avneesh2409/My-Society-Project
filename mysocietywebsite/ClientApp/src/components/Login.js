import React, { useState } from 'react'
import { useHistory } from 'react-router-dom'
import { setToken } from '../helper/tokenAuth'
import AlertBox, { type } from './childComponent/AlertBox'

const Login = ({ setState:setLogin }) => {
    const history = useHistory()
    const [state, setState] = useState({ email: '', password: '' })
    const [error, setError] = useState('');
    const changeHandler = (e) => {
        const { name, value } = e.target;
        setState(s => ({
            ...s,
            [name]:value
        }))
    }
    const submitHandler = (e) => {
        e.preventDefault()
        console.log(state)
        fetch(`/api/account/login`, {
            method:'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept':'application/json'
            },
            body: JSON.stringify(state)
        })
            .then(r => r.json())
            .then(res => {
                if (res) {
                    if (res.token) {
                        setLogin(s => ({
                            ...s,
                            isLoggedIn: true
                        }))
                        setToken(res)
                        history.push('/home')
                    }
                    else {
                        setLogin(s => ({
                            ...s,
                            isLoggedIn: false
                        }))
                        setError("email or password is incorrect !!")
                    }
                }
                else{
                    setLogin(s => ({
                        ...s,
                        isLoggedIn: false
                    }))
                    setError("email or password is incorrect !!")
                }
            })
            .catch(err => {
                console.log(err);
                setLogin(s => ({
                    ...s,
                    isLoggedIn: false
                }))
                setError("Something went wrong !!")
            })
    }
    return (
        <section className="vh-100" style={{ backgroundColor: '#9A616D' }}>
            <div className="container py-5 h-100">
                <div className="row d-flex justify-content-center align-items-center h-100">
                    <div className="col col-xl-10">
                        <div className="card" style={{borderRadius: '1rem'}}>
                            <div className="row g-0">
                                <div className="col-md-6 col-lg-5 d-none d-md-block">
                                    <img
                                        src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp"
                                        alt="login form"
                                        className="img-fluid" style={{borderRadius: '1rem 0 0 1rem'}}
                                    />
                                </div>
                                <div className="col-md-6 col-lg-7 d-flex align-items-center">
                                    <div className="card-body p-4 p-lg-5 text-black">
                                            <div className="d-flex align-items-center mb-3 pb-1">
                                            <i className="fas fa-cubes fa-2x me-3" style={{ "color": '#ff6219' }}></i>
                                                <span className="h1 fw-bold mb-0">Logo</span>
                                            </div>

                                        <h5 className="fw-normal mb-3 pb-3" style={{letterSpacing: '1px'}}>Sign into your account</h5>
                                        <form>
                                            <div className="form-outline mb-4">
                                            <label className="form-label" htmlFor="form2Example17">Email address</label>
                                            <input type="email" name="email" onChange={changeHandler} value={state.email}  className="form-control form-control-lg" />
                                               
                                            </div>

                                        <div className="form-outline mb-4">
                                                <label className="form-label" htmlFor="form2Example27">Password</label>
                                                <input type="password" name="password" onChange={changeHandler} value={state.password} className="form-control form-control-lg" />
                                              
                                            </div>

                                            <div className="pt-1 mb-4">
                                                <button className="btn btn-dark btn-lg btn-block" onClick={ submitHandler} type="button">Login</button>
                                            </div>
                                        </form>
                                            {/*<a className="small text-muted" href="#!">Forgot password?</a>*/}
                                        <p className="mb-5 pb-lg-2" style={{ color: '#393f81' }}>Don't have an account? <a href="#" onClick={(e) => { e.preventDefault(); history.push('/register'); }} style={{color: '#393f81'}}>Register here</a></p>
                                            
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            {
                error ? <AlertBox alertType={type.Error} message={error} setError={setError} /> : null
            }
        </section>
    )
}

export default Login