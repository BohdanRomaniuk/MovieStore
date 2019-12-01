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
        this.setState({ UserName: event.target.value });
    }

    handleOnChangePassword = (event) => {
        this.setState({ Password: event.target.value });
    }

    handleOnSubmit = () => {
        const url = `${apiUrl}/auth/login`;
        fetch(url, {
            method: "POST",
            body: JSON.stringify(this.state),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            if (!response.ok) {
                this.setState({loggined: false});
                this.setState({ message: "Помилка входу. Перевірте ім'я користувача та пароль!" }); 
            }
            else
            {
                this.setState({loggined: true});
                setTimeout(()=>{this.props.history.push("/")}, 1000);
            }
        });
    }

    render() {
        return (
            <Styles>
                {(this.state.loggined) ?
                    <Alert variant="success">Ви успішно увійшли</Alert> :
                    (this.state.message !== null) ? <Alert variant="danger">{this.state.message}</Alert> : ''
                }
                <Form>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Ім'я користувача</Form.Label>
                        <Form.Control type="username" onChange={this.handleOnChangeUserName} placeholder="Ім'я користувача..." />
                    </Form.Group>
                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Пароль</Form.Label>
                        <Form.Control type="password" onChange={this.handleOnChangePassword} placeholder="Пароль..." />
                    </Form.Group>
                    <Button variant="outline-primary" style={{float: "right"}} onClick={this.handleOnSubmit}>
                        Увійти
                </Button>
                </Form>
            </Styles>
        );
    }
}
