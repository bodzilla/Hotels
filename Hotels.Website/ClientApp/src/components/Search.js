import React, { Component } from 'react';

export class Search extends Component {
    static displayName = Search.name;

    constructor(props) {
        super(props);
        this.state = { loading: true };
    }

    render() {
        let contents =
            <form onSubmit={this.handleSubmit}>
                <div class="form-row align-items-center">
                    <div class="col-sm-3 my-1">
                        <input type="text" class="form-control " value={this.state.value} onChange={this.handleChange} />
                    </div>
                    <div class="col-auto">
                        <input type="submit" class="btn btn-primary" value="Search" />
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