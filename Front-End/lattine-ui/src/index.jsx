import React from 'react';
import ReactDOM from 'react-dom';
import reportWebVitals from './reportWebVitals';
import { parseJWT, usuarioAutenticado } from './services/auth';
import './index.css';

import Home from './pages/Home/Home';
import Login from './pages/Login/Login';
import Cadastro from './pages/Cadastro/Cadastro'
import NotFound from './pages/NotFound/NotFound';
import Servicos from './pages/Servicos/Servicos';
import Usuarios from './pages/ListagemUsuarios/ListagemUsuarios';
import EdicaoDadosUsuario from './pages/EdicaoDadosUsuario/EdicaoDadosUsuario'
import DadosUsuarioAdm from './pages/DadosUsuario/DadosUsuarioAdm'
import DadosMaqVirAdm from './pages/DadosServico/DadosServicoAdm/DadosMaqVirAdm'
import DadosRedeVirtualAdm from './pages/DadosServico/DadosServicoAdm/DadosRedeVirtualAdm'
import DadosSerApliAdm from './pages/DadosServico/DadosServicoAdm/DadosSerApliAdm'
import ContatosAdm from './pages/ContatosLattineGroup/ContatosAdm'
import ContatosFun from './pages/ContatosLattineGroup/ContatosFun'
<<<<<<< HEAD
import ContatosCli from './pages/ContatosLattineGroup/ContatosCli'
import EdicaoContatosAdm from './pages/EdicaoContatos/EdicaoContatosAdm'
import EdicaoContatosFun from './pages/EdicaoContatos/EdicaoContatosFun'
import EscolherServicoAdm from './pages/EscolherServico/EscolherServicoAdm'

/* Sidebars */
import SidebarAdm from './components/Sidebar/SiderbarAdm/SidebarAdm'
import SidebarAdmConfig from './components/Sidebar/SiderbarAdm/SidebarAdmConfig'
import SidebarAdmUsuarios from './components/Sidebar/SiderbarAdm/SidebarAdmUsuarios'
import SidebarAdmServicos from './components/Sidebar/SiderbarAdm/SidebarAdmServicos'
import SidebarAdmSuporte from './components/Sidebar/SiderbarAdm/SidebarAdmSuporte'
=======
import Cadastro from './pages/Cadastro/Cadastro'
import Home from './pages/Home/Home';
>>>>>>> 04cd197115ba9bcbeaf11bcc095fc5f08279bba8

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
        <Route exact path="/" component={Home} />
        <Route exact path="/login" component={props => <Login {...props} />} />
        <Route path="/cadastro" component={Cadastro} />
        <Route path="/sidebaradm" component={SidebarAdm} />
        <Route path="/sidebaradmconfig" component={SidebarAdmConfig} />
        <Route path="/sidebaradmusuarios" component={SidebarAdmUsuarios} />
        <Route path="/sidebaradmservicos" component={SidebarAdmServicos} />
        <Route path="/sidebaradmsuporte" component={SidebarAdmSuporte} />

<<<<<<< HEAD
        <Route path="/usuarios" component={Usuarios} />
        <PermissaoAdm path="/edicaodadosusuario" component={EdicaoDadosUsuario} />
        <PermissaoAdm path="/dadosusuarioadm" component={DadosUsuarioAdm} />
        <PermissaoAdm path="/dadosmaqviradm" component={DadosMaqVirAdm} />
        <PermissaoAdm path="/dadosredevirtualadm" component={DadosRedeVirtualAdm} />
        <PermissaoAdm path="/dadosserapliadm" component={DadosSerApliAdm} />
=======
        <Route path="/sidebar" component={Sidebar} />
        <Route exact path="/" component={Home} />
>>>>>>> 04cd197115ba9bcbeaf11bcc095fc5f08279bba8
        <PermissaoAdm path="/contatosadm" component={ContatosAdm} />
        <PermissaoAdm path="/edicaocontatosadm" component={EdicaoContatosAdm} />
        <PermissaoAdm path="/servicos" component={Servicos} />
        <PermissaoAdm path="/edicaocontatosadm" component={EdicaoContatosAdm} />
        <PermissaoAdm path="/escolherservicoadm" component={EscolherServicoAdm} />

        <PermissaoFun path="/contatosfun" component={ContatosFun} />
        <PermissaoFun path="/edicaocontatosfun" component={EdicaoContatosFun} />
        <PermissaoFun path="/servicos" component={Servicos} />
<<<<<<< HEAD

        <PermissaoCli path="/contatoscli" component={ContatosCli} />
        <PermissaoCli path="/servicos" component={Servicos} />
=======
        <Route path="/login" component={props => <Login {...props} />} />
        <Route path="/servicos" component={Servicos} />
        <Route path="/usuarios" component={Usuarios} />
        <Route path="/cadastro" component={Cadastro} />
>>>>>>> 04cd197115ba9bcbeaf11bcc095fc5f08279bba8

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
