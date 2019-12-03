import React, { Component } from 'react';
import { Button, Alert } from 'react-bootstrap';
import { withRouter } from 'react-router-dom';
import {apiUrl, posterUrl} from '../Constants';

export class Movie extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            movieId: parseInt(props.match.params.movieId, 10) || 1,
            movieInfo: {},
            comments: [{ user: {}}],
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
        let model = {CommentText: text, MovieId: movieId, UserId: 1};
        fetch(url, {
            method: "POST",
            body: JSON.stringify(model),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            if (!response.ok) {
                this.setState({commentPosted: false});
            }
            else
            {
                this.setState({commentPosted: true});
                this.reloadComments();
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
                        <img itemprop="image" class="img-responsive" src={posterUrl + '/' + movieInfo.poster} alt={movieInfo.ukrName} style={{maxWidth: '23rem'}}/>
                    </a>
                </div>
                <div class="col-md-8 col-sm-6">
                    <div></div>
                    <table class="table movie-detail">
                        <tbody>
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
                <Button variant="outline-success" style={{float: "right"}} onClick={this.handleOnSubmitMovie}>
                    Купити фільм
                </Button>
            </h4>
            <h4 class="altname">Відгуки користувачів</h4>
            {(comments.length==0) ? <Alert variant="primary">Коментарів ще немає, будьте першими</Alert> : '' }
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
            <form method="post">
                <div class="form-group">
                    <textarea name="commentText" class="form-control" rows="5" onChange={this.handleOnChangeCommentText} required="required"></textarea>
                </div>
                <Button variant="outline-success" style={{float: "right"}} onClick={this.handleOnSubmitComment}>
                    Надіслати
                </Button>
            </form>
            <br></br>
            <br></br>
            <br></br>
        </div>
        );
    }
}

export default withRouter(Movie)
