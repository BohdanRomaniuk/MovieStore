import React, { Component } from 'react';
import { Card } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import {apiUrl, posterUrl} from '../Constants';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            movies: []
        };
    }

    componentDidMount() {
        fetch(`${apiUrl}/movie`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        movies: result
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }

    render() {
        const { movies } = this.state;
        console.log(movies);
        return (
            <div style={{ margin: '10px auto' }}>
                {movies.map(movie => (
                    <Card style={{ width: '16rem', float: 'left', marginRight: '10px', marginBottom: '10px' }}>
                        <Link to={"/movie/" + movie.id}>
                            <Card.Img variant="top" src={posterUrl + '/' + movie.poster}/>
                        </Link>
                        <Card.Body>
                            <Card.Title><Link to={"/movie/" + movie.id}>{movie.ukrName} - {movie.originName} ({movie.year})</Link></Card.Title>
                        </Card.Body>
                    </Card>))}
            </div>
        );
    }
}
