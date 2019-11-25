import React, { Component } from 'react';
import { Form, Button } from 'react-bootstrap'
import styled from 'styled-components';

const Styles = styled.form`
  form {
    margin: 0 auto;
    max-width: 400px;
  }
`;

export class Register extends Component {
    render() {
        return (
            <Styles>
                <Form>
                    <Form.Group controlId="userName">
                        <Form.Label>Ім'я користувача</Form.Label>
                        <Form.Control type="username" placeholder="Ім'я користувача..." />
                    </Form.Group>
                    <Form.Group controlId="firstName">
                        <Form.Label>Прізвище</Form.Label>
                        <Form.Control type="username" placeholder="Прізвище..." />
                    </Form.Group>
                    <Form.Group controlId="lastName">
                        <Form.Label>Ім'я</Form.Label>
                        <Form.Control type="username" placeholder="Ім'я..." />
                    </Form.Group>
                    <Form.Group controlId="password">
                        <Form.Label>Пароль</Form.Label>
                        <Form.Control type="password" placeholder="Пароль..." />
                    </Form.Group>
                    <Form.Group controlId="passwordConfirm">
                        <Form.Label>Повторіть пароль</Form.Label>
                        <Form.Control type="password" placeholder="Пароль..." />
                    </Form.Group>
                    <Button variant="outline-success" type="submit">
                        Зареєструватися
                </Button>
                </Form>
            </Styles>
        );
    }
}
