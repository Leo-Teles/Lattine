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
                        <p>Rede Virtual</p>
                        <h3>Data de Cadastro</h3>
                        <p>28/04/2022</p>
                        <h3>Grupo de Recursos</h3>
                        <p>Grupo 1</p>

                        <h2>Detalhes da Instância</h2>

                        <h3>Nome da Rede Virtual</h3>
                        <p>Minha Rede Virtual</p>

                        <h2>Endereço de IP</h2>

                        <h3>Espaço de Endereço IPv4</h3>
                        <p>192.168.3.151</p>

                        <h2>Sub-rede</h2>

                        <h3>Nome de Sub-rede</h3>
                        <p>Minha Sub-Rede</p>
                        <h3>Intervalos de Endereço de Sub-Rede</h3>
                        <p>10.0.0.1.0/24</p>

                        <h2>Segurança</h2>

                        <h3>BastionHost</h3>
                        <p>Ativo</p>
                        <h3>Padrão de Proteção DDoS</h3>
                        <p>Ativo</p>
                        <h3>Firewall</h3>
                        <p>Ativo</p>
                        <a href="#">Editar informações</a>
                    </div>
                </div>
            </div>
        )
    }
}