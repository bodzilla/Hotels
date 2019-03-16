import React, { Component } from 'react';

export class Search extends Component {

    constructor(props) {
        super(props);
        this.state = {
            searchTerms: "",
            rating: "",
            ratingSort: "",
            hotels: []
        };

        // Bind all elements.
        this.handleSearchChange = this.handleSearchChange.bind(this);
        this.handleRatingFilterChange = this.handleRatingFilterChange.bind(this);
        this.handleRatingSortChange = this.handleRatingSortChange.bind(this);

        // Get the full list on initial load.
        fetch('api/hotels')
            .then(response => response.json())
            .then(data => { this.setState({ hotels: data }); });
    }

    // Get hotels with given search criteria.
    handleSearchChange(event) {
        // Set / clear other fields.
        this.setState({ searchTerms: event.target.value });
        this.setState({ rating: 0 });
        this.setState({ ratingSort: 0 });

        // If the value is empty, return all hotels, otherwise search the given terms.
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

    handleRatingFilterChange(event) {
        // Set / clear other fields.
        this.setState({ rating: event.target.value });
        this.setState({ searchTerms: "" });
        this.setState({ ratingSort: 0 });

        fetch(`api/hotels/rating/${event.target.value}`)
            .then(response => response.json())
            .then(data => { this.setState({ hotels: data }); }
            );

        event.preventDefault();
    }

    // Sort the current data set by given mode.
    handleRatingSortChange(event) {
        // Set / clear other fields.
        this.setState({ ratingSort: event.target.value });
        this.setState({ rating: 0 });

        if (event.target.value === "1") {
            // Ascending.
            this.setState({
                hotels: this.state.hotels.sort((a, b) => (a.rating - b.rating)).reverse()
            });
        } else if (event.target.value === "2") {
            // Descending.
            this.setState({
                hotels: this.state.hotels.sort((a, b) => (a.rating - b.rating))
            });
            event.preventDefault();
        }
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
        let contents =
            <div className='form-group'>
                <div className='form-row align-items-center'>
                    <div className='col-sm-3 my-2'>
                        <input type='text' className='form-control' placeholder='Search' value={this.state.searchTerms} onChange={this.handleSearchChange} />
                    </div>
                </div>
                <div className='form-row align-items-center'>
                    <div className='dropdown col-auto my-2'>
                        <select className='form-control' value={this.state.rating} onChange={this.handleRatingFilterChange}>
                            <option hidden>Filter by rating</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                        </select>
                    </div>
                    <div className='dropdown col-auto my-2'>
                        <select className='form-control' value={this.state.ratingSort} onChange={this.handleRatingSortChange}>
                            <option hidden>Order by rating</option>
                            <option value="1">Highest first</option>
                            <option value="2">Lowest first</option>
                        </select>
                    </div>
                </div>
            </div>;

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
