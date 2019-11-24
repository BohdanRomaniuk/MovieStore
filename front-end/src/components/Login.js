import React, { Component } from 'react';
import { Form, Button } from 'react-bootstrap'

export class Login extends Component {
    render() {
        return (
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
        );
    }
}
