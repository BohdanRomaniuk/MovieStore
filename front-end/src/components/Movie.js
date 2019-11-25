import React, {Component} from 'react';
import {Card} from 'react-bootstrap';
import {Link} from 'react-router-dom';
import apiUrl from '../Constants';

export class Movie extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            movieId : parseInt(props.match.params.movieId, 10) || 1,
            movieInfo: {}
        };
    }

    componentDidMount() {
        fetch(`${apiUrl}/movie/${this.state.movieId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        movieInfo: result
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            );
    }

    render() {
        const { movieInfo, movieId } = this.state;
        return (
            <div style={{ margin: '10px auto' }}>
                    <Card style={{ width: '18rem' }}>
                        <Link to={"/movie/" + movieId}>
                            <Card.Img variant="top" src={movieId} />
                        </Link>
                        <Card.Body>
                            <Card.Title><Link to={"/movie/" + movieId}>{movieInfo.ukrName} - {movieInfo.originName} ({movieInfo.year})</Link></Card.Title>
                        </Card.Body>
                    </Card>
            </div>
        );
    }
}

export default Movie
