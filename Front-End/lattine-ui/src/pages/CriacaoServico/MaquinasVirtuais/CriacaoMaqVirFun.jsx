import { Component } from "react";
import axios from "axios";
import { parseJWT } from '../../../services/auth';

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default class CadastroMaqVirCli extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nomeMaquinaVirtual: '',
            opcoesDisponibilidade: '',
            sistemaOperacional: '',
            tamanho: '',
            nomeAdmin: '',
            origemChavePublicaSsh: '',
            dataCadastro: new Date(),
            idUsuario: 0,

            listaMaquinas: [],

            isLoading: false,
        };
    }

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
        console.log(parseJWT().jti);
        console.log('inicia ciclo de vida');
        this.buscarMaquinasVirtuais();
    }

    cadastrarMaquina = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let maquina = {
            nomeMaquinaVirtual: this.state.nomeMaquinaVirtual,
            opcoesDisponibilidade: this.state.opcoesDisponibilidade,
            sistemaOperacional: this.state.sistemaOperacional,
            tamanho: this.state.tamanho,
            nomeAdmin: this.state.nomeAdmin,
            origemChavePublicaSsh: this.state.origemChavePublicaSsh,
            dataCadastro: new Date(this.state.dataCadastro),
            idUsuario: parseJWT().jti
        };

        axios
            .post('http://localhost:5000/api/maquinavirtuals', maquina, {
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

            window.location.href = "maqvirusuariocli";
    };

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.cadastrarMaquina} className="container-conteudo-edicao-servico">
                        <h1>Dados do Serviço</h1>

                        <h2>Detalhes da Instância</h2>
                        <label htmlFor="nomemaqvir">Nome da Máquina Virtual</label>
                        <input
                            required
                            type="text"
                            name="nomeMaquinaVirtual"
                            value={this.state.nomeMaquinaVirtual}
                            onChange={this.atualizaStateCampo}
                            className="input-text-edicao"
                            id="nomemaqvir" />

                        <label htmlFor="disponibilidade">Disponibilidade</label>
                        <select
                            id="disponibilidade"
                            name="opcoesDisponibilidade"
                            value={this.state.opcoesDisponibilidade}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" hidden>Selecione</option>
                            <option value="Zona de disponibilidade">Zona de disponibilidade</option>
                            <option value="Conjuto de dimensionamento da máquinas virtuais">Conjuto de dimensionamento da máquinas virtuais</option>
                            <option value="Conjuto de disponibilidade">Conjuto de disponibilidade</option>
                        </select>

                        <label htmlFor="sistemaoperacional">Sistema Operacional</label>
                        <select
                            id="sistemaoperacional"
                            name="sistemaOperacional"
                            value={this.state.sistemaOperacional}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" hidden>Selecione</option>
                            <option value="Windows Server 2019">Windows Server 2019</option>
                            <option value="Ubuntu Server 20.04 - Gen2">Ubuntu Server 20.04 - Gen2</option>
                            <option value='Debian 11 "Bullseye" - Gen2'>Debian 11 "Bullseye" - Gen2</option>
                        </select>

                        <label htmlFor="tamanho">Tamanho</label>
                        <select
                            id="tamanho"
                            name="tamanho"
                            value={this.state.tamanho}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" hidden>Selecione</option>
                            <option value="Standard_D2s_v3 - 2vCPU,8Gib de memória">Standard_D2s_v3 - 2vCPU,8Gib de memória</option>
                            <option value="Standard_D4s_v3 - 4vCPU,16Gib de memória">Standard_D4s_v3 - 4vCPU,16Gib de memória</option>
                            <option value="Standard_E2s_v3 - 2vCPU,16Gib de memória">Standard_E2s_v3 - 2vCPU,16Gib de memória</option>
                        </select>

                        <h2>Conta do Administrador</h2>
                        <label htmlFor="nomeadmin">Nome do Administrador</label>
                        <input
                            className="input-text-edicao"
                            required
                            type="text"
                            name="nomeAdmin"
                            value={this.state.nomeAdmin}
                            onChange={this.atualizaStateCampo}
                            id="nomeadmin"></input>

                        <label htmlFor="chave">Origem Chave Pública SSH</label>
                        <select
                            id="chave"
                            name="origemChavePublicaSsh"
                            value={this.state.origemChavePublicaSsh}
                            onChange={this.atualizaStateCampo}>
                            <option value="0" hidden>Selecione</option>
                            <option value="Gerar novo par de chaves">Gerar novo par de chaves</option>
                            <option value="Utilizar chave existente">Utilizar chave existente</option>
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