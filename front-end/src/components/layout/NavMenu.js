import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { Navbar, Nav, Form, FormControl, Button } from 'react-bootstrap';
import styled from 'styled-components';

const Styles = styled.div`
  .navbar {
    background-color: #222;
  }

  a, .navbar-brand, .navbar-nav .nav-link {
    color: #bbb;

    &:hover {
      color: white;
      text-decoration: none;
    }
  }
`;

export class NavMenu extends Component {
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
                                <Nav.Link>
                                    <Link to="/register">Зареєструватися</Link>
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Nav.Link>
                                    <Link to="/login">Увійти</Link>
                                </Nav.Link>
                            </Nav.Item>
                        </Nav>
                        <Form inline>
                            <FormControl type="text" placeholder="Пошук..." className="mr-sm-2" />
                            <Button variant="outline-success">Пошук</Button>
                        </Form>
                    </Navbar.Collapse>
                </Navbar>
            </Styles>
        );
    }
}

export default NavMenu
