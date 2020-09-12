import React, {Component} from 'react'

export default class Test extends Component {
    render() {
        return (
            <h1>{this.props.location.state.id}</h1>
        );
    }
}