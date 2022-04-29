import { Component } from "react";

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-escolher">
                        <h1>Tipos de Serviços</h1>
                        <div className="escolha-servico"></div>
                        <div className="escolha-servico"></div>
                        <div className="escolha-servico"></div>
                    </div>
                </div>
            </div>
        )
    }
}