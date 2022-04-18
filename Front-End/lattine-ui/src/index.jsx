import React from 'react';
import ReactDOM from 'react-dom';

import './index.css';

import Login from './pages/Login/Login';
import NotFound from './pages/NotFound/NotFound';
import reportWebVitals from './reportWebVitals';
import { parseJWT, usuarioAutenticado } from './services/auth';
import Servicos from './pages/Servicos/Servicos';
import Usuarios from './pages/ListagemUsuarios/ListagemUsuarios';
import Sidebar from './components/Sidebar/SidebarAdm'
import ContatosAdm from './pages/ContatosLattineGroup/ContatosAdm'
import ContatosFun from './pages/ContatosLattineGroup/ContatosFun'
import Cadastro from './pages/Cadastro/Cadastro'
import Home from './pages/Home/Home';

import {
  Route,
  BrowserRouter as Router,
  Redirect
} from 'react-router-dom';
import { Switch } from 'react-router-dom';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJWT().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="" />
      )
    }
  />
);

const PermissaoCli = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJWT().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="" />
      )
    }
  />
);

const PermissaoFun = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJWT().role === '3' ? (
        <Component {...props} />
      ) : (
        <Redirect to="" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>

        <Route path="/sidebar" component={Sidebar} />
        <Route exact path="/" component={Home} />
        <PermissaoAdm path="/contatosadm" component={ContatosAdm} />
        <PermissaoFun path="/contatosfun" component={ContatosFun} />
        <PermissaoAdm path="/servicos" component={Servicos} />
        <PermissaoCli path="/servicos" component={Servicos} />
        <PermissaoFun path="/servicos" component={Servicos} />
        <Route path="/login" component={props => <Login {...props} />} />
        <Route path="/servicos" component={Servicos} />
        <Route path="/usuarios" component={Usuarios} />
        <Route path="/cadastro" component={Cadastro} />

        <Route path="*" component={props => <NotFound {...props} />} />

      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

reportWebVitals();
