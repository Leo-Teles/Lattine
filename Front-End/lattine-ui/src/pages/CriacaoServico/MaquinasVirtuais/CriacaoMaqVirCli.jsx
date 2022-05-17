import { Component } from "react";
import axios from "axios";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SidebarCli/SidebarCliServicos";


export default class CadastroMaqVirCli extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idInfraestrutura: 0,
            nomeMaquinaVirtual: '',
            opcoesDisponibilidade: '',
            sistemaOperacional: '',
            tamanho: '',
            nomeAdmin: '',
            origemChavePublicaSsh: '',

            listaMaquinas: [],
            listaInfraestruturas: [],

            isLoading: false,
        };
    }

    buscarInfraestruturas = () => {
        axios('http://localhost:5000/api/infraestruturas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaInfraestruturas: resposta.data });
                    console.log(this.state.listaInfraestruturas);
                }
            })
            .catch((erro) => console.log(erro));
    };

    buscarMaquinasVirtuais = () => {
        axios('http://localhost:5000/api/maquinavirtuals')
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaMaquinas: resposta.data });
                    console.log(this.state.listaMaquinas);
                }
            })
            .catch((erro) => console.log(erro));
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    componentDidMount() {
        console.log('inicia ciclo de vida');
        this.buscarInfraestruturas();
        this.buscarMaquinasVirtuais();
    }

    cadastrarMaquina = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let evento = {
            idInfraestrutura: "5",
            nomeMaquinaVirtual: this.state.nomeMaquinaVirtual,
            opcoesDisponibilidade: this.state.opcoesDisponibilidade,
            sistemaOperacional: this.state.sistemaOperacional,
            tamanho: this.state.tamanho,
            nomeAdmin: this.state.nomeAdmin,
            origemChavePublicaSsh: this.state.origemChavePublicaSsh,
        };

        axios
            .post('http://localhost:5000/api/maquinavirtuals', evento, {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Máquina Virtual Cadastrada.');
                    this.setState({ isLoading: false });
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })
            .then(this.buscarMaquinasVirtuais);
    };

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.cadastrarMaquina} className="container-conteudo-edicao-servico">
                        <h1>Dados do Serviço</h1>

                        <h2>Detalhes da Instância</h2>
                        <label for="nomemaqvir">Nome da Máquina Virtual</label>
                        <input
                            required
                            type="text"
                            name="nomeMaquinaVirtual"
                            value={this.state.nomeMaquinaVirtual}
                            onChange={this.atualizaStateCampo}
                            className="input-text-edicao"
                            id="nomemaqvir" />

                        <label for="disponibilidade">Disponibilidade</label>
                        <select
                            id="disponibilidade"
                            name="opcoesDisponibilidade"
                            value={this.state.opcoesDisponibilidade}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" disabled selected>Selecione</option>
                            <option value="1">Zona de disponibilidade</option>
                            <option value="2">Conjuto de dimensionamento da máquinas virtuais</option>
                            <option value="3">Conjuto de disponibilidade</option>
                        </select>

                        <label for="sistemaoperacional">Sistema Operacional</label>
                        <select
                            id="sistemaoperacional"
                            name="sistemaOperacional"
                            value={this.state.sistemaOperacional}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" disabled selected>Selecione</option>
                            <option value="1">Windows Server 2019</option>
                            <option value="2">Ubuntu Server 20.04 - Gen2</option>
                            <option value="3">Debian 11 "Bullseye" - Gen2</option>
                        </select>

                        <label for="tamanho">Tamanho</label>
                        <select
                            id="tamanho"
                            name="tamanho"
                            value={this.state.tamanho}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" disabled selected>Selecione</option>
                            <option value="1">Standard_D2s_v3 - 2vCPU,8Gib de memória</option>
                            <option value="2">Standard_D4s_v3 - 4vCPU,16Gib de memória</option>
                            <option value="3">Standard_E2s_v3 - 2vCPU,16Gib de memória</option>
                        </select>

                        <h2>Conta do Administrador</h2>
                        <label for="nomeadmin">Nome do Administrador</label>
                        <input
                            className="input-text-edicao"
                            required
                            type="text"
                            name="nomeAdmin"
                            value={this.state.nomeAdmin}
                            onChange={this.atualizaStateCampo}
                            id="nomeadmin"></input>

                        <label for="chave">Origem Chave Pública SSH</label>
                        <select
                            id="chave"
                            name="origemChavePublicaSsh"
                            value={this.state.origemChavePublicaSsh}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" disabled selected>Selecione</option>
                            <option value="1">Gerar novo par de chaves</option>
                            <option value="2">Utilizar chave existente</option>
                        </select>

                        <div>
                            <button className="botao-editar">Criar</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}