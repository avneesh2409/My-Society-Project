import React, { useState} from 'react';
import { Route } from 'react-router';
import { Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import './custom.css'
import { routes } from './router';

const App = (props) => {
    const [state, setState] = useState({ isLoggedIn: false })
    return (
        <Layout isLoggedIn={state.isLoggedIn}>
            <React.Fragment>
                <Switch>
                    {
                    
                        (state.isLoggedIn ? routes.registered : routes.naive).map(r => {
                            return <Route key={r.key} exact={r.exact} path={r.path} render={(props) => <r.component setState={setState} {...props} />} />
                    })
                }
                    <Route path="*" render={() => <h1>Route Not found</h1>} />
                </Switch>
            </React.Fragment>
        </Layout>
    );
}

export default App
