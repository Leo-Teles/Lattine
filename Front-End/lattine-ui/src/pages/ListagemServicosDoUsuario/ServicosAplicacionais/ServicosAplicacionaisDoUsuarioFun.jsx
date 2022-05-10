import { Component } from "react";
import { Link } from "react-router-dom";

import '../../../assets/css/style.css'

import Flecha from '../../../assets/img/flecha.png'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-users">
                        <div className="container-titulo">
                            <h1>Serviços Aplicacionais de "Nome do Usuário"</h1>
                        </div>
                        <div className="container-input">
                            <input type="text" placeholder="Buscar"/>
                        </div>
                        <div className="listagem">
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Serviço Aplicacional</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                        </div>
                        <div className="proxima-pagina">
                            <Link><a>Próxima página <img src={Flecha} alt="Imagem de Flecha" /></a></Link>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}