import Home from '../components/Home';
import Login from '../components/Login';
import Logout from '../components/Logout';

export const routes = {
    naive: [
        {
            key: 1,
            title: 'login',
            exact: true,
            path: '/login',
            component: Login
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
        }
    ]
}