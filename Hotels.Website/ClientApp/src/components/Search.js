import React, { Component } from 'react';

export class Search extends Component {

    static displayName = Search.name;

    handleChange(event) {
        this.setState({ searchTerms: event.target.value });
    }

    handleSubmit(event) {
        console.log(this.state.searchTerms);
        event.preventDefault();
    }

    constructor(props) {
        super(props);
        this.state = {
            searchTerms: '',
            loading: true
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        let contents =
            <form className='form-row align-items-center' onSubmit={this.handleSubmit}>
                <div>
                    <div className='col-sm-3 my-1'>
                        <input type='text' className='form-control' value={this.state.searchTerms} onChange={this.handleChange} />
                    </div>
                    <div className='col-auto'>
                        <input type="submit" value="Submit" className='btn btn-primary' />
                    </div>
                </div>
            </form>;

        return (
            <div>
                <h1>Search for hotels</h1>
                <br />
                {contents}
            </div>
        );
    }
}
