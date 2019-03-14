import React, { Component } from 'react';

export class Search extends Component {

    static displayName = Search.name;

    handleChange(event) {
        this.setState({ searchTerms: event.target.value });
    }

    handleSubmit(event) {
        if (!this.state.searchTerms) {
            fetch('api/hotels')
                .then(response => response.json())
                .then(data => { this.setState({ hotels: data }); });
        } else {
            fetch(`api/hotels/name/${this.state.searchTerms}`)
                .then(response => response.json())
                .catch(reason => { console.log(reason); })
                .then(data => { this.setState({ hotels: data }); });
        }
        event.preventDefault();
    }

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

    constructor(props) {
        super(props);
        this.state = {
            searchTerms: '',
            hotels: []
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        let contents =
            <form className='form-group' onSubmit={this.handleSubmit}>
                <div className='form-row align-items-center'>
                    <div className='col-sm-3 my-1'>
                        <input type='text' className='form-control' value={this.state.searchTerms} onChange={this.handleChange} />
                    </div>
                    <div className='col-auto'>
                        <input type="submit" value="Submit" className='btn btn-primary' />
                    </div>
                </div>
            </form >;

        let table = Search.renderHotelsTable(this.state.hotels);

        return (
            <div>
                <h1>Search for hotels</h1>
                <br />
                {contents}
                {table}
            </div>
        );
    }
}
