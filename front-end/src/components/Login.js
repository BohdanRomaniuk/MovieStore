import React, { Component } from 'react';
import { Form, Button } from 'react-bootstrap'
import styled from 'styled-components';

const Styles = styled.form`
  form {
    margin: 30px auto;
    max-width: 400px;
  }
`;

export class Login extends Component {
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
