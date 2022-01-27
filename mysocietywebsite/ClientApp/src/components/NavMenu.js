import React, { useEffect, useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { routes } from '../router';
import { getToken } from '../helper/tokenAuth';

export const NavMenu = ({ isLoggedIn }) => {
    const [state, setState] = useState({ collapsed: true,userEmail:'' })

    const toggleNavbar = () => {
        setState(s=>({
            ...s,
            collapsed: !state.collapsed
        }));
    }
    useEffect(() => {
        if (isLoggedIn && getToken()) {
            const { email} = getToken() 
            setState(s => ({
                ...s,
                userEmail: email
            }))
        }

    },[])
    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">mysocietywebsite</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            {
                                (isLoggedIn ? routes.registered : routes.naive).map(r => {
                                    return (r.title !== 'default') && < NavItem key = { r.key } >
                                        <NavLink tag={Link} className="text-dark" to={r.path}>{r.title}</NavLink>
                                    </NavItem>
                                })
                            }
                            {
                                isLoggedIn && <NavItem style={{ textAlign: 'center' }}>
                                    <div className="text-dark img-thumbnail" style={{ fontWeight: 'bold', fontFamily: 'Algerian', backgroundColor: 'white', borderRadius: '50%', width: '40px', height: '40px' }}>{state.userEmail && state.userEmail.slice(0, 2).toUpperCase()}</div>
                                </NavItem>
                                

                            }
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );

}
