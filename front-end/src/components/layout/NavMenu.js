import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { Navbar, Nav, Form, FormControl, Button } from 'react-bootstrap';
import styled from 'styled-components';
import { withRouter } from 'react-router-dom'

const Styles = styled.div`
  .navbar {
    padding: 5px;
    background-color: #20232a !important;
  }

  .navbar-brand {
    color: #28a745;
  }
  
  a, .navbar-nav .nav-link {
    color: #bbb;

    &:hover {
      color: #28a745;
      text-decoration: none;
    }
  }
`;

export class NavMenu extends Component {
    constructor(props) {
        super(props);
        this.state = {
            searchQuery: '',
            loggedIn: false,
            userName: '',
            userId: 0
        };
    }

    componentDidMount() {
        this.setState({ loggedIn: this.props.loggedIn, userName: this.props.userName, userId: this.props.userId });
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ loggedIn: nextProps.loggedIn, userName: nextProps.userName, userId: nextProps.userId });
    }

    handleOnChangeSearchQuery = (event) => {
        this.setState({ searchQuery: event.target.value });
    }

    handleOnSubmit = () => {
        this.props.history.push("/search/" + this.state.searchQuery);
    }

    render() {
        return (
            <Styles>
                <Navbar bg="dark" variant="dark">
                    <Navbar.Brand href="/">Movie Store</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="mr-auto">
                            <Nav.Item>
                                <Nav.Link>
                                    <Link to="/">Список фільмів</Link>
                                </Nav.Link>
                            </Nav.Item>
                        </Nav>
                        <Nav className="ml-auto">
                            <Nav.Item>
                                {(this.state.loggedIn) ?
                                    <Nav.Link>
                                        <Link to={"/profile/" + this.state.userId}>Романюк Богдан</Link>
                                    </Nav.Link>
                                    :
                                    <Nav.Link>
                                        <Link to="/register">Зареєструватися</Link>
                                    </Nav.Link>
                                }
                            </Nav.Item>
                            <Nav.Item>
                                {(this.state.loggedIn) ?
                                    <Nav.Link>
                                        <Link to="/logout">Вийти</Link>
                                    </Nav.Link>
                                    :
                                    <Nav.Link>
                                        <Link to="/login">Увійти</Link>
                                    </Nav.Link>
                                }
                            </Nav.Item>
                        </Nav>
                        <Form inline>
                            <FormControl type="text" placeholder="Пошук..." onChange={this.handleOnChangeSearchQuery} className="mr-sm-2" />
                            <Button variant="outline-success" onClick={this.handleOnSubmit}>Пошук</Button>
                        </Form>
                    </Navbar.Collapse>
                </Navbar>
            </Styles>
        );
    }
}

export default withRouter(NavMenu)
