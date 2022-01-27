import React, { useEffect, useState} from 'react';
import { Route } from 'react-router';
import { Redirect, Switch, useHistory, useLocation, useParams } from 'react-router-dom';
import { Layout } from './components/Layout';
import './custom.css'
import { getToken } from './helper/tokenAuth';
import { routes } from './router';

const App = (props) => {
    const [state, setState] = useState({ isLoggedIn: false })
    const history = useHistory()
    const location = useLocation()
    useEffect(() => {
        if (location.pathname) {
            const token = getToken();
            if (token) {
                setState(s => ({
                    ...s,
                    isLoggedIn: true
                }))
                history.push(location.pathname)
            }
            else {
                setState(s => ({
                    ...s,
                    isLoggedIn: false
                }))
            }
        }
    }, [location.pathname])
    return (
        <Layout isLoggedIn={state.isLoggedIn}>
            <React.Fragment>
                <Switch>
                    {
                    
                        (state.isLoggedIn ? routes.registered : routes.naive).map(r => {
                            return (r.title === 'default') ? <Redirect key={r.key} to={r.path} /> : <Route key={r.key} exact={r.exact} path={r.path} render={(props) => <r.component setState={setState} {...props} />} />
                    })
                    }
                    
                </Switch>
            </React.Fragment>
        </Layout>
    );
}

export default App
