import { Component } from "react";

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarAdm-Fun/SidebarAdmUsuarios";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-edicao">
                        <h1>Dados do Usuário</h1>
                        <label for="nome">Nome</label>
                        <input id="nome" placeholder="Carlos"></input>
                        <label for="sobrenome">Sobrenome</label>
                        <input id="sobrenome" placeholder="Santos Fausto Silva"></input>
                        <label for="email">E-mail</label>
                        <input id="email" placeholder="carlosltt.fausto@gmail.com"></input>
                        <label for="senha">Senha</label>
                        <input id="senha" placeholder="carlos123"></input>
                        <label for="tipousuario">Tipo de Usuário</label>
                        <select id="tipousuario">
                            <option value="1">Administrador</option>
                            <option value="2">Cliente</option>
                            <option value="3">Funcionário Lattine Group</option>
                        </select>
                        <div>
                            <button className="botao-editar">Editar</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}