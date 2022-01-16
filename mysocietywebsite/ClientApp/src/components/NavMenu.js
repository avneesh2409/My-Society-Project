import React, { useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { routes } from '../router';

export const NavMenu = ({ isLoggedIn }) => {

    const [state, setState] = useState({ collapsed: true })

    const toggleNavbar = () => {
        setState({
            collapsed: !state.collapsed
        });
    }

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
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );

}
