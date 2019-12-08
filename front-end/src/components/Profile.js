import React, { Component } from 'react';
import { withRouter, Link } from 'react-router-dom';
import { apiUrl, posterUrl } from '../Constants';
import {Card} from 'react-bootstrap';

export class Profile extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoaded: false,
            profileId: parseInt(props.match.params.profileId, 10) || 1,
            orderedMovies: []
        };
    }

    componentDidMount() {
        fetch(`${apiUrl}/movieorder/${this.state.profileId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        orderedMovies: result
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
        const { orderedMovies } = this.state;
        return (
            <div style={{ margin: '10px auto' }}>
                <h2>Куплені фільми користувача</h2>
                {orderedMovies.map(movie => (
                    <Card style={{ width: '16rem', float: 'left', marginRight: '10px', marginBottom: '10px' }}>
                        <Link to={"/movie/" + movie.movieId}>
                            <Card.Img variant="top" src={posterUrl + '/' + movie.movie.poster} />
                        </Link>
                        <Card.Body>
                            <Card.Title><Link to={"/movie/" + movie.movieId}>{movie.movie.ukrName} - {movie.movie.originName} ({movie.movie.year})</Link></Card.Title>
                        </Card.Body>
                    </Card>))}
            </div>
        );
    }
}

export default withRouter(Profile)