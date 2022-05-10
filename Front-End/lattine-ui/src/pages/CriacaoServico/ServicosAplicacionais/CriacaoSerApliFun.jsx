import { Component } from "react";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";

export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-edicao-servico">
                        <h1>Dados do Serviço</h1>
                        <h2>Detalhes do Serviço</h2>
                        <label for="gruporecursos">Grupo de Recursos</label>
                        <select id="gruporecursos">
                            <option value="1">Grupo 1</option>
                        </select>

                        <h2>Detalhes da Instância</h2>
                        <label for="nomemaqvir">Nome da Máquina Virtual</label>
                        <input className="input-text-edicao" id="nomemaqvir" placeholder="Minha Máquina Virtual"></input>

                        <label for="disponibilidade">Disponibilidade</label>
                        <select id="disponibilidade">
                            <option value="1">Zona de disponibilidade</option>
                            <option value="2">Conjuto de dimensionamento da máquinas virtuais</option>
                            <option value="3">Conjuto de disponibilidade</option>
                        </select>

                        <label for="sistemaoperacional">Sistema Operacional</label>
                        <select id="sistemaoperacional">
                            <option value="1">Windows Server 2019</option>
                            <option value="2">Ubuntu Server 20.04 - Gen2</option>
                            <option value="3">Debian 11 "Bullseye" - Gen2</option>
                        </select>

                        <label for="tamanho">Tamanho</label>
                        <select id="tamanho">
                            <option value="1">Standard_D2s_v3 - 2vCPU,8Gib de memória</option>
                            <option value="2">Standard_D4s_v3 - 4vCPU,16Gib de memória</option>
                            <option value="3">Standard_E2s_v3 - 2vCPU,16Gib de memória</option>
                        </select>
                        
                        <h2>Conta do Administrador</h2>
                        <label for="nomeadmin">Nome do Administrador</label>
                        <input className="input-text-edicao" id="nomeadmin" placeholder="Luca"></input>

                        <label for="chave">Origem Chave Pública SSH</label>
                        <select id="chave">
                            <option value="1">Gerar novo par de chaves</option>
                            <option value="2">Utilizar chave existente</option>
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