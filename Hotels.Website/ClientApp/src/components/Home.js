import React, { Component } from 'react';

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = { hotels: [], loading: true };

        // Get the full list on initial load.
        fetch('api/hotels')
            .then(response => response.json())
            .then(data => {
                this.setState({ hotels: data, loading: false });
            });
    }

    // Render the current hotel array to the screen.
    static renderHotelsTable(hotels) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Location</th>
                        <th>Rating</th>
                    </tr>
                </thead>
                <tbody>
                    {hotels.map(hotel =>
                        <tr key={hotel.id}>
                            <td>{hotel.name}</td>
                            <td>{hotel.description}</td>
                            <td>{hotel.location}</td>
                            <td>{hotel.rating}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : Home.renderHotelsTable(this.state.hotels);

        return (
            <div>
                <h1>Available hotels</h1>
                <br />
                {contents}
            </div>
        );
    }
}
