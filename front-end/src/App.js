import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Layout } from './components/layout/Layout';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Register } from './components/Register';
import { Home } from './components/Home';
import NavMenu from './components/layout/NavMenu';
import { Login } from './components/Login';

function App() {
  return (
    <React.Fragment>
        <BrowserRouter>
          <NavMenu />
          <Layout>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/register" component={Register} />
              <Route path="/login" component={Login} />
            </Switch>
          </Layout>
        </BrowserRouter>
      </React.Fragment>
  );
}

export default App;
