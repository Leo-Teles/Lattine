import { Component } from "react";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SidebarCli/SidebarCliServicos";


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
                            <option value="0" disabled selected>Selecione</option>
                            <option value="1">Grupo 1</option>
                        </select>

                        <h2>Detalhes da Instância</h2>
                        <label for="nomeredevir">Nome da Rede Virtual</label>
                        <input className="input-text-edicao" id="nomeredevir"></input>
                        
                        <h2>Endereço de IP</h2>
                        <label for="ip">Espaço de Endereço IPv4</label>
                        <input className="input-text-edicao" id="ip"></input>

                        <h2>Sub-Rede</h2>
                        <label for="nomesubrede">Nome de Sub-Rede</label>
                        <input className="input-text-edicao" id="nomesubrede"></input>
                        <label for="enderecos">Intervalo de Endereços de Sub-Rede</label>
                        <input className="input-text-edicao" id="enderecos"></input>

                        <h2>Segurança</h2>
                        <label for="bastionhost">BastionHost</label>
                        <input className="input-check-edicao" type="checkbox" id="bastionhost"></input>
                        <label for="ddos">Padrão de Proteção DDoS</label>
                        <input className="input-check-edicao" type="checkbox" id="ddos"></input>
                        <label for="firewall">Firewall</label>
                        <input className="input-check-edicao" type="checkbox" id="firewall"></input>


                        <div>
                            <button className="botao-editar">Editar</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}