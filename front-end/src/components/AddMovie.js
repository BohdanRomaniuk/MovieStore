import React, { Component } from 'react';
import styled from 'styled-components';
import { withRouter } from 'react-router-dom';
import { Form, Button, Row, Col, InputGroup, FormControl, Alert } from 'react-bootstrap'
import { apiUrl } from '../Constants';

const Styles = styled.form`
  form {
    margin: 0 auto;
  }
`;

export class AddMovie extends Component {
    constructor(props) {
        super(props);
        this.state = {
            submitted: false,
            message: null,

            UkrName: '',
            OriginName: '',
            Year: 1990,
            Length: '',
            Poster: '',
            Genre: '',
            Country: '',
            Companies: '',
            Director: '',
            Actors: '',
            Story: '',
            Price: 0.0
        }
    }

    componentDidMount() {
        this.setState({ submitted: false });
    }

    handleOnChangeUkrName = (event) => {
        this.setState({ UkrName: event.target.value });
    }

    handleOnChangeOriginName = (event) => {
        this.setState({ OriginName: event.target.value });
    }

    handleOnChangeYear = (event) => {
        this.setState({ Year: parseInt(event.target.value, 10) || 1990 });
    }

    handleOnChangeYear = (event) => {
        this.setState({ Length: event.target.value });
    }

    handleOnChangePoster = (event) => {
        this.setState({ Poster: event.target.value });
    }

    handleOnChangeGenre = (event) => {
        this.setState({ Genre: event.target.value });
    }

    handleOnChangeCountry = (event) => {
        this.setState({ Country: event.target.value });
    }

    handleOnChangeCompanies = (event) => {
        this.setState({ Companies: event.target.value });
    }

    handleOnChangeDirector = (event) => {
        this.setState({ Director: event.target.value });
    }

    handleOnChangeActors = (event) => {
        this.setState({ Actors: event.target.value });
    }

    handleOnChangeStory = (event) => {
        this.setState({ Story: event.target.value });
    }

    handleOnChangePrice = (event) => {
        this.setState({ Price: parseFloat(event.target.value) || 0 });
    }

    handleOnSubmit = () => {
        const url = `${apiUrl}/movie`;
        fetch(url, {
            method: "POST",
            body: JSON.stringify(this.state),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            console.log(response.json());
            if (!response.ok) {
                this.setState({submitted: false, message: 'Помилка не заповнно усі поля!'});
            }
            else
            {
                this.setState({submitted: true});
            }
        });
    }

    render() {
        return (
            <Styles>
                <h4>Додати новий фільм</h4>
                {(this.state.submitted) ?
                    <Alert variant="success">Фільм {this.state.UkrName + ' ' + this.state.OriginName } успішно додано</Alert> :
                    (this.state.message !== null) ? <Alert variant="danger">{this.state.message}</Alert> : ''
                }
                <Form>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Назва українською:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeUkrName} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Оригінальна назва:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeOriginName} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Рік випуску:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeYear} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Постер:
                        </Form.Label>
                        <Col sm="6">
                            <InputGroup className="mb-3">
                                <FormControl
                                    placeholder="Виберіть файл"
                                    aria-label="Виберіть файл"
                                    aria-describedby="basic-addon2"
                                    onChange={this.handleOnChangePoster}
                                />
                                <InputGroup.Append>
                                    <Button variant="outline-secondary">Вибрати</Button>
                                </InputGroup.Append>
                            </InputGroup>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Жанр:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeGenre} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Країна:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeCountry} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Кінокомпанія/кіностудія:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeCompanies} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Режисер:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeDirector} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Актори:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control type="text" onChange={this.handleOnChangeActors} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Сюжет:
                        </Form.Label>
                        <Col sm="6">
                            <Form.Control as="textarea" rows="3" onChange={this.handleOnChangeStory} />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label column sm="3">
                            Ціна:
                        </Form.Label>
                        <Col sm="6">
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                    <InputGroup.Text>₴</InputGroup.Text>
                                </InputGroup.Prepend>
                                <FormControl aria-label="вкажіть вартість у гривнях" onChange={this.handleOnChangePrice} />
                                <InputGroup.Append>
                                    <InputGroup.Text>.00</InputGroup.Text>
                                </InputGroup.Append>
                            </InputGroup>
                        </Col>
                    </Form.Group>
                    <Button variant="outline-success" onClick={this.handleOnSubmit}>
                        Додати фільм
                    </Button>
                </Form>
            </Styles>
        );
    }
}

export default withRouter(AddMovie)