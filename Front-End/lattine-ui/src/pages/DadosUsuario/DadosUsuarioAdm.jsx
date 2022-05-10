import { Component } from "react";

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarAdm/SidebarAdmUsuarios";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo">
                        <h1>Dados do Usuário</h1>
                        <h2>Nome</h2>
                        <p>Carlos</p>
                        <h2>Sobrenome</h2>
                        <p>Santos Fausto Silva</p>
                        <h2>E-mail</h2>
                        <p>carlosltt.fausto@gmail.com</p>
                        <h2>Senha</h2>
                        <p>********</p>
                        <h2>Tipo de Usuário</h2>
                        <p>Cliente</p>
                        <a href="#">Editar informações</a>
                    </div>
                </div>
            </div>
        )
    }
}