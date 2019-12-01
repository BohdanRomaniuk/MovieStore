import React, { Component } from 'react';
import { Form, Button } from 'react-bootstrap'
import styled from 'styled-components';

const Styles = styled.form`
  form {
    margin: 0 auto;
    max-width: 400px;
  }
`;

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loggined: false,
            message: null,

            UserName: '',
            Password: '',
        };
    }

    handleOnChangeUserName = (event) => {
        this.setState({ UserName: event.target.value});
    }

    handleOnChangePassword = (event) => {
        this.setState({ Password: event.target.value});
    }

    render() {
        return (
            <Styles>
                <Form>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Ім'я користувача</Form.Label>
                        <Form.Control type="username" placeholder="Ім'я користувача..." />
                    </Form.Group>
                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Пароль</Form.Label>
                        <Form.Control type="password" placeholder="Пароль..." />
                    </Form.Group>
                    <Button variant="outline-primary" type="submit">
                        Увійти
                </Button>
                </Form>
            </Styles>
        );
    }
}
