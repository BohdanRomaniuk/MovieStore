import React, { Component } from 'react';
import {apiUrl, posterUrl} from '../Constants';

export class Movie extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            movieId: parseInt(props.match.params.movieId, 10) || 1,
            movieInfo: {},
            comments: []
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
            <h4 class="altname">Перегляд онлайн</h4>
            <h4 class="altname">Відгуки користувачів</h4>
            {comments.map(comment => (
            <div class="panel panel-default">
                <div style={{ padding: '10px' }}>
                    <a class="label label-primary" style={{ fontSize: '12px' }}>{comment.commentText}</a>
            <span class="label label-default" style={{ fontSize: '12px' }}>{comment.commentDate}</span>
                    <br />
                    <div style={{ padding: '5px' }}>{comment.commentText}</div>
                </div>
            </div>))}

            <hr />
            <h4>Відправити відгук:</h4>
            <form method="post" asp-controller="Movie" asp-action="AddComment">
                <div class="form-group">
                    <label for="inputComment">Текст відгуку</label>
                    <textarea name="commentText" class="form-control" id="inputComment" rows="5" required="required"></textarea>
                </div>
                <input type="hidden" name="movieId" value="Model.Id" />
                <button type="submit" class="btn btn-success">Надіслати</button>
            </form>
        </div>
        );
    }
}

export default Movie
