import { Component } from "react";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-servico">
                        <h1>Dados do Serviço</h1>

                        <h2>Detalhes do Serviço</h2>

                        <h3>Tipo de Serviço</h3>
                        <p>Serviço Aplicacional</p>
                        <h3>Data de Cadastro</h3>
                        <p>28/04/2022</p>
                        <h3>Grupo de Recursos</h3>
                        <p>Grupo 1</p>

                        <h2>Detalhes da Instância</h2>

                        <h3>Nome do Serviço Aplicacional</h3>
                        <p>Meu Serviço Aplicacional</p>
                        <h3>Pilha de Runtime</h3>
                        <p>.NET 6 (LTS)</p>
                        <h3>SKU  e Tamanho</h3>
                        <p>Básico B1- 100 ACU total, 1.75 GB de memória</p>
                        <a href="#">Editar informações</a>
                    </div>
                </div>
            </div>
        )
    }
}