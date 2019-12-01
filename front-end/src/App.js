import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Layout } from './components/layout/Layout';
import 'bootstrap/dist/css/bootstrap.min.css';
import NavMenu from './components/layout/NavMenu';
import { Home } from './components/Home';
import { Register } from './components/Register';
import { Login } from './components/Login';
import { Movie } from './components/Movie';

export default (props) => (
  <React.Fragment>
    <BrowserRouter>
      <NavMenu/>
      <Layout>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route exact path="/search/:query" component={Home} />
          <Route path="/register" component={Register} />
          <Route path="/login" component={Login} />
          <Route path="/movie/:movieId" component={Movie} />
        </Switch>
      </Layout>
    </BrowserRouter>
  </React.Fragment>
);
