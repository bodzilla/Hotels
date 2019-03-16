import React, { Component } from 'react';

export class Search extends Component {

    static displayName = Search.name;

    handleChange(event) {
        this.setState({ searchTerms: event.target.value });
        this.setState({ rating: 0 });

        if (!event.target.value) {
            fetch('api/hotels')
                .then(response => response.json())
                .then(data => { this.setState({ hotels: data }); }
                );
        } else {
            fetch(`api/hotels/name/${event.target.value}`)
                .then(response => response.json())
                .catch(reason => { console.log(reason); })
                .then(data => { this.setState({ hotels: data }); }
                );
        }
        event.preventDefault();
    }

    handleRatingChange(event) {
        this.setState({ rating: event.target.value });
        this.setState({ searchTerms: "" });
        if (event.target.value !== "0") {
            fetch(`api/hotels/rating/${event.target.value}`)
                .then(response => response.json())
                .then(data => { this.setState({ hotels: data }); }
                );
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

    action() {
        alert("LOL");
    }

    constructor(props) {
        super(props);
        this.state = {
            searchTerms: "",
            rating: "",
            hotels: []
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleRatingChange = this.handleRatingChange.bind(this);

        fetch('api/hotels')
            .then(response => response.json())
            .then(data => { this.setState({ hotels: data }); });
    }

    render() {
        let contents =
            <form className='form-group' onSubmit={this.handleSubmit}>
                <div className='form-row align-items-center'>
                    <div className='col-sm-3 my-2'>
                        <input type='text' className='form-control' placeholder='Search' value={this.state.searchTerms} onChange={this.handleChange} />
                    </div>
                </div>
                <div className='form-row align-items-center'>
                    <div className='dropdown col-sm-2 my-2'>
                        <select className='form-control' value={this.state.rating} onChange={this.handleRatingChange}>
                            <option value="0">Filter by rating</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                        </select>
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
