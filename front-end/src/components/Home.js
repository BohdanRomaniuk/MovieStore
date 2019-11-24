import React, { Component } from 'react';
import { Card } from 'react-bootstrap'
import { Link } from 'react-router-dom'

export class Home extends Component {
    displayName = Home.name

    render() {
        return (
            <div style={{ margin: '10px auto' }}>
                <Card style={{ width: '18rem' }}>
                    <Link to="/movie/1">
                        <Card.Img variant="top" src="https://upload.wikimedia.org/wikipedia/uk/thumb/e/e3/Infinity_War_Poster.jpg/253px-Infinity_War_Poster.jpg" />
                    </Link>
                    <Card.Body>
                        <Card.Title><Link to="/movie/1">Месники війна нескінченності (2018)</Link></Card.Title>
                    </Card.Body>
                </Card>
            </div>
        );
    }
}
