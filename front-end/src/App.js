import React, { Component } from 'react';
import { BrowserRouter, Route, Switch, withRouter } from 'react-router-dom';
import { Layout } from './components/layout/Layout';
import 'bootstrap/dist/css/bootstrap.min.css';
import NavMenu from './components/layout/NavMenu';
import { Home } from './components/Home';
import { Register } from './components/Register';
import { Login } from './components/Login';
import { Movie } from './components/Movie';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      logginedIn: false,
      userName: '',
      userId: 0
    };
  }

  componentDidMount() {
    this.setState({ logginedIn: true });
  }

  onChangeLogin = (success, name, id) => {
    this.setState({ loggedIn: success, userName: name, userId: id });
  }

  render() {
    return (
      <React.Fragment>
        <BrowserRouter>
          <NavMenu loggedIn={this.state.logginedIn} userName={this.state.userName} userId={this.state.userId} />
          <Layout>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route exact path="/search/:query" component={Home} />
              <Route path="/register" component={Register} />
              <Route path="/login" render={(props) => <Login onChangeLogin={this.onChangeLogin} {...props} /> } />
              <Route path="/movie/:movieId" component={Movie} />
            </Switch>
          </Layout>
        </BrowserRouter>
      </React.Fragment>
    );
  }
}

export default App;
