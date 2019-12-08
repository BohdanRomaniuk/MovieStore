import React, { Component } from 'react';
import { BrowserRouter, Route, Switch, withRouter } from 'react-router-dom';
import { Layout } from './components/layout/Layout';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'video-react/dist/video-react.css';
import NavMenu from './components/layout/NavMenu';
import { Home } from './components/Home';
import { Register } from './components/Register';
import { Login } from './components/Login';
import { Logout } from './components/Logout';
import { Movie } from './components/Movie';
import { Profile } from './components/Profile';
import { AddMovie } from './components/AddMovie';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      logginedIn: false,
      userName: '',
      userRole: 'user',
      userToken: '',
      userId: 0
    };
  }

  componentDidMount() {
    this.setState({ logginedIn: false });
  }

  onChangeLogin = (success, name, id, role, token) => {
    this.setState({ logginedIn: success, userName: name, userId: id, userRole: role, userToken: token });
  }

  render() {
    return (
      <React.Fragment>
        <BrowserRouter>
          <NavMenu loggedIn={this.state.logginedIn}
            userName={this.state.userName}
            userId={this.state.userId}
            userRole={this.state.userRole} />
          <Layout>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route exact path="/search/:query" component={Home} />
              <Route path="/register" component={Register} />
              <Route path="/login" render={(props) => <Login onChangeLogin={this.onChangeLogin} {...props} />} />
              <Route path="/logout" render={(props) => <Logout onChangeLogin={this.onChangeLogin} {...props} />} />
              <Route path="/movie/:movieId" render={(props) => <Movie userId={this.state.userId} {...props} />} />
              <Route path="/profile/:profileId" component={Profile} />
              <Route path="/addMovie" component={AddMovie} />
            </Switch>
          </Layout>
        </BrowserRouter>
      </React.Fragment>
    );
  }
}

export default withRouter(App);
