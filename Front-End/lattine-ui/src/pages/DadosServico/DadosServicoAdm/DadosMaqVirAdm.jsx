import { Component } from "react";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";


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
                        <p>Máquina Virtual</p>
                        <h3>Data de Cadastro</h3>
                        <p>28/04/2022</p>
                        <h3>Grupo de Recursos</h3>
                        <p>Grupo 1</p>

                        <h2>Detalhes da Instância</h2>

                        <h3>Nome da Máquina Virtual</h3>
                        <p>Minha Máquina Virtual</p>
                        <h3>Disponibilidade</h3>
                        <p>Zona de Disponibilidade</p>
                        <h3>Sistema Operacional</h3>
                        <p>Windows Server 2019</p>
                        <h3>Tamanho</h3>
                        <p>Standard_D2s_v3 - 2vCPU,8Gib de memória</p>

                        <h2>Conta do Administrador</h2>

                        <h3>Nome do Administrador</h3>
                        <p>Luca</p>
                        <h3>Origem Chave Pública SSH</h3>
                        <p>Gerar novo par de chaves</p>
                    </div>
                </div>
            </div>
        )
    }
}