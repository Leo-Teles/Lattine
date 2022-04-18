import { Component } from "react";
import { Link } from "react-router-dom";

import '../../assets/css/ListagemUsuarios.css';

import SidebarAdm from "../../components/Sidebar/SidebarAdm";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <SidebarAdm />
                <div className="conteudo">
                    <div className="container-conteudo-users">
                        <div className="container-input">
                            <input type="text" placeholder="Buscar" />
                        </div>
                        <div className="listagem">
                            <div className="retangulo-usuario">
                                <h1>Nome do Usuário</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Usuário</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Usuário</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Usuário</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Usuário</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                            <div className="retangulo-usuario">
                                <h1>Nome do Usuário</h1>
                                <h2>Data de Cadastro:</h2>
                                <p>14/04/2022</p>
                            </div>
                        </div>
                        <div className="proxima-pagina">
                            <button>Próxima página <img src="" alt="" /></button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}