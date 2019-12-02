import React, { Component } from 'react';
import { Card } from 'react-bootstrap'
import { Link, withRouter } from 'react-router-dom'
import { apiUrl, posterUrl } from '../Constants';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            movies: [],
            searchquery: props.match.params.query
        };
    }

    componentDidMount() {
        this.reloadMovies(this.state.searchquery);
    }

    componentWillReceiveProps(nextProps) {
        this.reloadMovies(nextProps.match.params.query);
    }

    reloadMovies = (query) => {
        var url = (typeof query === "undefined") ? `${apiUrl}/movie` : `${apiUrl}/movie/searchQuery=${query}`;
        console.log(url);
        fetch(url)
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
        );
    }

    render() {
        const { movies } = this.state;
        return (
            <div style={{ margin: '10px auto' }}>
                {movies.map(movie => (
                    <Card style={{ width: '16rem', float: 'left', marginRight: '10px', marginBottom: '10px' }}>
                        <Link to={"/movie/" + movie.id}>
                            <Card.Img variant="top" src={posterUrl + '/' + movie.poster} />
                        </Link>
                        <Card.Body>
                            <Card.Title><Link to={"/movie/" + movie.id}>{movie.ukrName} - {movie.originName} ({movie.year})</Link></Card.Title>
                        </Card.Body>
                    </Card>))}
            </div>
        );
    }
}

export default withRouter(Home)