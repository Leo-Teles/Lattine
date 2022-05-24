import { Component } from "react";
import axios from "axios";
import { parseJWT } from '../../../services/auth';
import '../../../assets/css/style.css'
import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";
import { Link } from "react-router-dom";


export default class CadastroRedeVirtualCli extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nomeRedeVirtual: '',
            idEnderecoIp: '',
            idSubRede: '',
            bastionHost: false,
            protecaoDdoS: false,
            fireWall: false,
            dataCadastro: new Date(),
            idUsuario: 0,

            listaRedes: [],
            listaIp: [],
            listaSubRedes: [],

            isLoading: false,
        };
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    buscarSubRedes = () => {
        axios('http://localhost:5000/api/subredes/minhas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaSubRedes: resposta.data });
                    console.log(this.state.listaSubRedes);
                }
            })
            .catch((erro) => console.log(erro));
    };

    buscarIps = () => {
        axios('http://localhost:5000/api/enderecoips/meus', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaIp: resposta.data });
                    console.log(this.state.listaIp);
                }
            })
            .catch((erro) => console.log(erro));
    };

    buscarRedesVirtuais = () => {
        axios('http://localhost:5000/api/redevirtuals')
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaredes: resposta.data });
                    console.log(this.state.listaredes);
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
        this.buscarSubRedes();
        this.buscarIps();
        this.buscarRedesVirtuais();
    }

    cadastrarRede = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let rede = {
            nomeRedeVirtual: this.state.nomeRedeVirtual,
            idEnderecoIp: this.state.idEnderecoIp,
            idSubRede: this.state.idSubRede,
            bastionHost: this.state.bastionHost,
            protecaoDdoS: this.state.protecaoDdoS,
            fireWall: this.state.fireWall,
            dataCadastro: new Date(this.state.dataCadastro),
            idUsuario: parseJWT().jti
        };

        axios
            .post('http://localhost:5000/api/redevirtuals', rede, {
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
            .then(this.buscarredesVirtuais);

        window.location.href = "redesvirtuaisusuariocli";
    };

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.cadastrarRede} className="container-conteudo-edicao-servico">
                        <h1>Dados do Serviço</h1>

                        <h2>Detalhes da Instância</h2>
                        <label for="nomeredevir">Nome da Rede Virtual</label>
                        <input
                            type="text"
                            name="nomeRedeVirtual"
                            value={this.state.nomeRedeVirtual}
                            onChange={this.atualizaStateCampo}
                            className="input-text-edicao"
                            id="nomeredevir" />

                        <h2>Endereço de IP</h2>
                        <label htmlFor="idEnderecoIp">Endereço IPv4</label>
                        <select
                            name="idEnderecoIp"
                            value={this.state.idEnderecoIp}
                            onChange={this.atualizaStateCampo}
                            id="idEnderecoIp">
                            <option value="0" hidden>Selecione</option>
                            {this.state.listaIp.map((ip) => {
                                return (
                                    <option
                                        key={ip.idEnderecoIp}
                                        value={ip.idEnderecoIp}>{ip.endereco}</option>
                                );
                            })}
                        </select>
                        <Link to="criacaoipcli"><a className="criarredeip">+ Criar Endereço IP</a></Link>

                        <h2>Sub-Rede</h2>
                        <label htmlFor="idSubRede">Sub-Rede</label>
                        <select
                            name="idSubRede"
                            value={this.state.idSubRede}
                            onChange={this.atualizaStateCampo}
                            id="idSubRede">
                            <option value="0" hidden>Selecione</option>
                            {this.state.listaSubRedes.map((subrede) => {
                                return (
                                    <option
                                        key={subrede.idSubRede}
                                        value={subrede.idSubRede}>{subrede.nomeSubRede}</option>
                                );
                            })}
                        </select>
                        <Link to="criacaosubredecli"><a className="criarredeip">+ Criar Sub-Rede</a></Link>

                        <h2>Segurança</h2>
                        <label for="bastionhost">BastionHost</label>
                        <input
                            className="input-check-edicao"
                            type="checkbox"
                            id="bastionhost"
                            name="bastionHost"
                            checked={this.state.bastionHost}
                            onChange={this.handleInputChange}></input>
                        <label for="ddos">Padrão de Proteção DDoS</label>
                        <input
                            className="input-check-edicao"
                            type="checkbox"
                            id="ddos"
                            name="protecaoDdoS"
                            checked={this.state.protecaoDdoS}
                            onChange={this.handleInputChange}></input>
                        <label for="firewall">Firewall</label>
                        <input
                            className="input-check-edicao"
                            type="checkbox"
                            id="firewall"
                            name="fireWall"
                            checked={this.state.fireWall}
                            onChange={this.handleInputChange}></input>
                        <div>
                            <button className="botao-editar">Criar</button>
                        </div>
                    </form>
                </div>
            </div>
        )
    }
}