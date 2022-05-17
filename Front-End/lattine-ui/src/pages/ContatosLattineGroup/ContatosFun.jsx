import { Component } from "react";

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarFun/SidebarFunSuporte";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo">
                        <h1>Contatos - Lattine Group</h1>
                        <h2>Telefone 1</h2>
                        <p>+55 11 4209-1000</p>
                        <h2>Telefone 2</h2>
                        <p>+55 11 4209-1000</p>
                        <h2>Localização</h2>
                        <p>Alameda Tocantins, 350 Barueri - São Paulo / SP</p>
                        <a href="edicaocontatosfun">Editar informações</a>
                    </div>
                </div>
            </div>
        )
    }
}