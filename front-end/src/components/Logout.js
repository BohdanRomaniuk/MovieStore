import React, { Component } from 'react';
import { Redirect, withRouter } from 'react-router-dom';

export class Logout extends Component {

    constructor(props) {
        super(props);
        this.props.onChangeLogin(false, '', 0, 'user', '');
    }

    render() {
        return <Redirect to='/'/>;
    }
}

export default withRouter(Logout)
