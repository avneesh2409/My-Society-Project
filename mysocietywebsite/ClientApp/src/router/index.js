import Contact from '../components/Contact';
import Dashboard from '../components/Dashboard';
import Home from '../components/Home';
import Login from '../components/Login';
import Logout from '../components/Logout';
import Register from '../components/Register';

export const routes = {
    naive: [
        {
            key: 1,
            title: 'login',
            exact: true,
            path: '/login',
            component: Login
        },
        {
            key: 2,
            title: 'register',
            exact: true,
            path: '/register',
            component: Register
        },
        {
            key: 4,
            title: 'Dashboard',
            exact: true,
            path: '/dashboard',
            component: Dashboard
        },
        {
            key: 5,
            title: 'Contact Us',
            exact: true,
            path: '/contact',
            component: Contact
        },
        {
            key: 3,
            title: 'default',
            exact: false,
            path: '/login',
            component: null
        }
    ],
    registered: [
        {
            key:1,
            title:'home',
            exact: true,
            path: '/home',
            component: Home
        },
        {
            key: 2,
            title: 'logout',
            exact: true,
            path: '/logout',
            component: Logout
        },
        {
            key: 3,
            title: 'default',
            exact: false,
            path: '/home',
            component: null
        }
    ]
}