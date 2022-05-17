import { Component } from "react";

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarFun/SidebarFunSuporte";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-edicao">
                        <h1>Contatos - Lattine Group</h1>
                        <label for="telefone">Telefone</label>
                        <input id="telefone" placeholder="+55 11 4209-1000"></input>
                        <label for="telefone">Telefone</label>
                        <input id="telefone" placeholder="+55 11 4209-1000"></input>

                        <button className="adicionar-telefone">+ Adicionar telefone</button>

                        <label for="localizacao">Localização</label>
                        <input id="localizacao" placeholder="Alameda Tocantins, 350 Barueri - São Paulo / SP"></input>
                        <div className="ei">
                            <button className="botao-editar">Editar</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}