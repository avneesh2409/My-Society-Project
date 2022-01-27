import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { getToken } from '../helper/tokenAuth';

const Home = (props) => {
    const [state, setState] = useState({ data: [], loading: false, error: '' })
    const location = useLocation()
    useEffect(() => {
        fetch(`/api/media/gallery`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${getToken().token}`
            }
        })
            .then(r => r.json())
            .then(res => {
                setState(s => ({
                    ...s,
                    loading: false,
                    data: [...res]
                }))
            })
            .catch(err => {
                setState(s => ({
                    ...s,
                    loading: false,
                    error: err.message
                }))
            })
    }, [location.pathname])
    return (
        <div>

            <h1>we are in home page,only registered user can see this</h1>
            {
                state.data && state.data.length > 0 &&
                state.data.map((e, i) => {
                    return <div key={ i}>
                        <a href={e.imageUrl} target="_blank">
                            <img src={e.thumbnail} width={72} height={72} alt={e.name} />
                        </a>
                    </div>

                })
            }
        </div>
    );
}
export default Home
