import React, { Component } from 'react';
import { Button, Alert } from 'react-bootstrap';
import { withRouter, Link } from 'react-router-dom';
import { apiUrl, posterUrl } from '../Constants';
import { Player } from 'video-react';

export class Movie extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,


            movieId: parseInt(props.match.params.movieId, 10) || 1,
            movieInfo: {},
            isMovieOrdered: false,

            comments: [{ user: {} }],
            commentText: '',
            commentPosted: false,
        };
    }

    componentDidMount() {
        fetch(`${apiUrl}/movie/${this.state.movieId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        movieInfo: result,
                        comments: result.comments
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            );
        this.checkIfMovieOrdered();
    }

    checkIfMovieOrdered = () => {
        if (this.props.userId !== 0) {
            fetch(`${apiUrl}/movieorder/movieId=${this.state.movieId}&userId=${this.props.userId}`)
                .then(res => res.json())
                .then(
                    (result) => {
                        this.setState({ isMovieOrdered: result });
                    },
                    (error) => {
                        this.setState({ isMovieOrdered: false });
                    }
                );

        }
    }

    handleOnChangeCommentText = (event) => {
        this.setState({ commentText: event.target.value });
    }

    reloadComments = () => {
        fetch(`${apiUrl}/comment/movieId=${this.state.movieId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        comments: result
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

    handleOnSubmitComment = () => {
        const url = `${apiUrl}/comment`;
        let text = this.state.commentText;
        let movieId = this.state.movieId;
        let model = { CommentText: text, MovieId: movieId, UserId: 1 };
        fetch(url, {
            method: "POST",
            body: JSON.stringify(model),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            if (!response.ok) {
                this.setState({ commentPosted: false });
            }
            else {
                this.setState({ commentPosted: true });
                this.reloadComments();
            }
        });
        this.refs.commentArea.value = '';
    }

    handleOnSubmitMovie = () => {
        if (this.props.userId === 0) {
            return;
        }

        const url = `${apiUrl}/movieorder`;
        let model = { UserId: this.props.userId, MovieId: this.state.movieId };
        fetch(url, {
            method: "POST",
            body: JSON.stringify(model),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            console.log(response.json());
            if (!response.ok) {
                alert("Помилка купівлі фільму");
            }
            else {
                this.checkIfMovieOrdered();
            }
        });
    }

    render() {
        const { movieInfo, comments } = this.state;
        return (<div>
            <h4 class="altname">{movieInfo.ukrName} - {movieInfo.originName} ({movieInfo.year})</h4>
            <div class="row details-panel">
                <div class="col-md-4">
                    <a rel="posters">
                        <img itemprop="image" class="img-responsive" src={posterUrl + '/' + movieInfo.poster} alt={movieInfo.ukrName} style={{ maxWidth: '23rem' }} />
                    </a>
                </div>
                <div class="col-md-8 col-sm-6">
                    <div></div>
                    <table class="table movie-detail">
                        <tbody>
                            <tr>
                                <td>Ціна:</td>
                                <td>
                                    <Button variant="success" size="sm" disabled style={{  marginRight: '10px' }}>
                                        {movieInfo.price} грн.
                                    </Button>
                                    {(this.props.userId === 0) ? ''
                                        : (this.state.isMovieOrdered) ?
                                            <Button variant="success" size="sm" disabled >
                                                Фільм придбано
                                    </Button>
                                            : <Button variant="outline-success" size="sm" onClick={this.handleOnSubmitMovie}>
                                                Купити фільм
                                    </Button>
                                    }
                                </td>
                            </tr>
                            <tr>
                                <td>Рейтинг:</td>
                                <td>
                                    <a class="label label-primary">0/10</a>
                                </td>
                            </tr>
                            <tr>
                                <td>Жанр:</td>
                                <td>
                                    <a class="label label-primary">{movieInfo.genre}</a>
                                </td>
                            </tr>
                            <tr>
                                <td>Країна:</td>
                                <td>
                                    <a class="label label-primary">{movieInfo.country}</a>
                                </td>
                            </tr>
                            <tr>
                                <td>Тривалість:</td>
                                <td>{movieInfo.length}</td>
                            </tr>
                            <tr>
                                <td>Кінокомпанія</td>
                                <td>{movieInfo.companies}</td>
                            </tr>
                            <tr>
                                <td>Режисер:</td>
                                <td>{movieInfo.director}</td>
                            </tr>
                            <tr>
                                <td>Актори:</td>
                                <td>{movieInfo.actors}</td>
                            </tr>
                            <tr>
                                <td>Сюжет:</td>
                                <td>{movieInfo.story}</td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                </div>
            </div>
            <h4 class="altname">Перегляд онлайн
                {(this.props.userId === 0) ? ''
                    : (this.state.isMovieOrdered) ?
                        <Button variant="success" disabled style={{ float: "right", marginRight: '10px' }} >
                            Фільм придбано
                </Button>
                        : <Button variant="outline-success" style={{ float: "right" }} onClick={this.handleOnSubmitMovie}>
                            Купити фільм
                </Button>}
                <Button variant="success" disabled style={{ float: "right", marginRight: '10px' }} >
                    {movieInfo.price} грн.
                </Button>

            </h4>
            <br />
            {(this.state.isMovieOrdered) ?
                <Player
                    playsInline
                    poster={posterUrl + '/' + movieInfo.poster}
                    src="https://media.w3.org/2010/05/sintel/trailer_hd.mp4"
                />
                : <Alert variant="danger">Для перегляду фільму його треба купити. Ціна {this.state.movieInfo.price} грн.</Alert>
            }
            <h4 class="altname">Відгуки користувачів</h4>
            {(comments.length == 0) ? <Alert variant="primary">Коментарів ще немає, будьте першими</Alert> : ''}
            {comments.map(comment => (
                <div class="panel panel-default">
                    <div style={{ padding: '10px' }}>
                        <a class="label label-primary" style={{ fontSize: '12px' }}>{comment.user.firstName} {comment.user.lastName} {comment.changeDate}</a>
                        <span class="label label-default" style={{ fontSize: '12px' }}>{comment.commentDate}</span>
                        <br />
                        <div style={{ padding: '5px' }}>{comment.commentText}</div>
                    </div>
                </div>))}
            <hr />
            <h4>Залишити відгук:</h4>
            {(this.props.userId !== 0) ?
                <form method="post">
                    <div class="form-group">
                        <textarea ref="commentArea" class="form-control" rows="5" onChange={this.handleOnChangeCommentText} required="required"></textarea>
                    </div>
                    <Button variant="outline-success" style={{ float: "right" }} onClick={this.handleOnSubmitComment}>
                        Надіслати
                </Button>
                </form>
                : <Alert variant="primary"><Link to="/login">Увійдіть</Link> аби залишити коментар</Alert>
            }
            <br></br>
            <br></br>
            <br></br>
        </div>
        );
    }
}

export default withRouter(Movie)
