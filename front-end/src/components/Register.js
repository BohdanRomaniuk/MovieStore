import React, { Component } from 'react';
import { Form, Button, Alert } from 'react-bootstrap'
import styled from 'styled-components';
import { apiUrl } from '../Constants';

const Styles = styled.form`
  form {
    margin: 0 auto;
    max-width: 400px;
  }
`;

export class Register extends Component {
    constructor(props) {
        super(props);
        this.state = {
            registered: false,
            message: null,

            UserName: '',
            FirstName: '',
            LastName: '',
            Password: '',
        };
    }

    handleOnChangeUserName = (event) => {
        this.setState({ UserName: event.target.value});
    }

    handleOnChangeFirstName = (event) => {
        this.setState({ FirstName: event.target.value});
    }

    handleOnChangeLastName = (event) => {
        this.setState({ LastName: event.target.value});
    }

    handleOnChangePassword = (event) => {
        this.setState({ Password: event.target.value});
    }

    hangleOnSubmit = () => {
        const url = `${apiUrl}/auth/register`;
        fetch(url, {
            method: "POST",
            body: JSON.stringify(this.state),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            if (!response.ok) {
                this.setState({registered: false});
            }
            else
            {
                this.setState({registered: true});
                setTimeout(()=>{this.props.history.push("/")}, 1000);
            }
            this.setState({ message: "Помилка реєстрації" }); 
        });
    }

    render() {
        return (
            <Styles>
                {(this.state.registered) ? 
                    <Alert variant="success">Успішно зареєстровано</Alert> : 
                    (this.state.message !== null) ? <Alert variant="danger">{this.state.message}</Alert> : ''
                }
                <Form>
                    <Form.Group controlId="userName">
                        <Form.Label>Ім'я користувача</Form.Label>
                        <Form.Control type="username" onChange={this.handleOnChangeUserName} placeholder="Ім'я користувача..." required/>
                    </Form.Group>
                    <Form.Group controlId="firstName">
                        <Form.Label>Прізвище</Form.Label>
                        <Form.Control type="username" onChange={this.handleOnChangeLastName} placeholder="Прізвище..." />
                    </Form.Group>
                    <Form.Group controlId="lastName">
                        <Form.Label>Ім'я</Form.Label>
                        <Form.Control type="username" onChange={this.handleOnChangeFirstName} placeholder="Ім'я..." />
                    </Form.Group>
                    <Form.Group controlId="password">
                        <Form.Label>Пароль</Form.Label>
                        <Form.Control type="password" onChange={this.handleOnChangePassword} placeholder="Пароль..." />
                    </Form.Group>
                    <Button variant="outline-success" onClick={this.hangleOnSubmit}>
                        Зареєструватися
                    </Button>
                </Form>
            </Styles>
        );
    }
}
